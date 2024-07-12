// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"net/http"
	"sort"
	"strings"

	"github.com/go-openapi/spec"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/constants"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/ignore"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

type operationsParser struct {
	operations                     []parsedOperation
	operationIdsToParsedOperations map[string]resourceids.ParsedOperation
	swaggerDefinition              *SwaggerDefinition
}

func (d *SwaggerDefinition) parseOperationsWithinTag(tag *string, operationIdsToParsedOperations map[string]resourceids.ParsedOperation, resourceProvider *string, found parserModels.ParseResult) (*map[string]sdkModels.SDKOperation, *parserModels.ParseResult, error) {
	operations := make(map[string]sdkModels.SDKOperation, 0)
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	result.Append(found)

	parser := operationsParser{
		operationIdsToParsedOperations: operationIdsToParsedOperations,
		swaggerDefinition:              d,
	}

	// first find the operations then pull out everything we can
	operationsForThisTag := d.findOperationsMatchingTag(tag)
	for _, operation := range *operationsForThisTag {
		logging.Debugf("Operation - %s %q..", operation.httpMethod, operation.uri)

		if ignore.Operation(operation.uri) {
			logging.Debugf("Operation should be ignored - skipping..")
			continue
		}

		op, nestedResult, err := parser.parseOperation(operation, resourceProvider)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing %s operation %q: %+v", operation.httpMethod, operation.uri, err)
		}
		if nestedResult != nil {
			if err := result.Append(*nestedResult); err != nil {
				return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
			}
		}

		if existing, hasExisting := operations[operation.name]; hasExisting {
			return nil, nil, fmt.Errorf("conflicting operations with the Name %q - first %q - second %q", operation.name, existing.Method, op.Method)
		}

		if op == nil {
			continue
		}
		operations[operation.name] = *op
	}

	return &operations, &result, nil
}

func (p operationsParser) parseOperation(operation parsedOperation, resourceProvider *string) (*sdkModels.SDKOperation, *parserModels.ParseResult, error) {
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}

	contentType := p.determineContentType(operation)
	expectedStatusCodes := p.expectedStatusCodesForOperation(operation)
	paginationField := p.fieldContainingPaginationDetailsForOperation(operation)
	requestObject, nestedResult, err := p.requestObjectForOperation(operation, result)
	if err != nil {
		return nil, nil, fmt.Errorf("determining request operation for %q (method %q / ID %q): %+v", operation.name, operation.httpMethod, operation.operation.ID, err)
	}
	if nestedResult != nil {
		if err := result.Append(*nestedResult); err != nil {
			return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
	}
	responseResult, nestedResult, err := p.responseObjectForOperation(operation, result)
	if err != nil {
		return nil, nil, fmt.Errorf("determining response operation for %q (method %q / ID %q): %+v", operation.name, operation.httpMethod, operation.operation.ID, err)
	}
	if nestedResult != nil {
		if err := result.Append(*nestedResult); err != nil {
			return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
	}
	if paginationField == nil && responseResult.paginationFieldName != nil {
		paginationField = responseResult.paginationFieldName
	}
	longRunning := p.operationIsLongRunning(operation)

	options, nestedResult, err := p.optionsForOperation(operation)
	if err != nil {
		return nil, nil, fmt.Errorf("building options for operation %q: %+v", operation.name, err)
	}
	if nestedResult != nil {
		if err := result.Append(*nestedResult); err != nil {
			return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
	}

	resourceId := p.operationIdsToParsedOperations[operation.operation.ID]
	usesADifferentResourceProvider, err := resourceIdUsesAResourceProviderOtherThan(resourceId.ResourceId, resourceProvider)
	if err != nil {
		return nil, nil, err
	}
	if usesADifferentResourceProvider != nil && *usesADifferentResourceProvider {
		return nil, nil, nil
	}

	operationData := sdkModels.SDKOperation{
		ContentType:                      contentType,
		ExpectedStatusCodes:              expectedStatusCodes,
		FieldContainingPaginationDetails: paginationField,
		LongRunning:                      longRunning,
		Method:                           strings.ToUpper(operation.httpMethod),
		Options:                          *options,
		RequestObject:                    requestObject,
		ResourceIDName:                   resourceId.ResourceIdName,
		ResponseObject:                   responseResult.objectDefinition,
		URISuffix:                        resourceId.UriSuffix,
	}

	if p.operationShouldBeIgnored(operationData) {
		return nil, nil, nil
	}

	return &operationData, &result, nil
}

func (p operationsParser) determineObjectDefinitionForOption(input spec.Parameter) (*sdkModels.SDKOperationOptionObjectDefinition, error) {
	if strings.EqualFold(input.Type, "array") {
		// https://github.com/Azure/azure-rest-api-specs/blob/1b0ed8edd58bb7c9ade9a27430759527bd4eec8e/specification/trafficmanager/resource-manager/Microsoft.Network/stable/2018-03-01/trafficmanager.json#L735-L738
		if input.Items == nil {
			return nil, fmt.Errorf("an array/csv option type was specified with no items")
		}

		innerType, err := p.determineObjectDefinitionForOptionRaw(input.Items.Type, input.Items.CollectionFormat, input.Items.Format)
		if err != nil {
			return nil, fmt.Errorf("determining nested object definition for option: %+v", err)
		}

		if strings.EqualFold(input.CollectionFormat, "csv") {
			return &sdkModels.SDKOperationOptionObjectDefinition{
				Type:       sdkModels.CSVSDKOperationOptionObjectDefinitionType,
				NestedItem: innerType,
			}, nil
		}

		return &sdkModels.SDKOperationOptionObjectDefinition{
			Type:       sdkModels.ListSDKOperationOptionObjectDefinitionType,
			NestedItem: innerType,
		}, nil
	}

	return p.determineObjectDefinitionForOptionRaw(input.Type, input.CollectionFormat, input.Format)
}

func (p operationsParser) determineObjectDefinitionForOptionRaw(paramType string, collectionFormat string, format string) (*sdkModels.SDKOperationOptionObjectDefinition, error) {
	switch strings.ToLower(paramType) {
	case "array":
		{
			if strings.EqualFold(collectionFormat, "csv") {
				return nil, fmt.Errorf("cannot contain a csv")
			}

			return nil, fmt.Errorf("cannot contain an array")
		}

	case "boolean":
		return &sdkModels.SDKOperationOptionObjectDefinition{
			Type: sdkModels.BooleanSDKOperationOptionObjectDefinitionType,
		}, nil

	case "integer":
		return &sdkModels.SDKOperationOptionObjectDefinition{
			Type: sdkModels.IntegerSDKOperationOptionObjectDefinitionType,
		}, nil

	case "number":
		{
			if strings.EqualFold(format, "double") {
				return &sdkModels.SDKOperationOptionObjectDefinition{
					Type: sdkModels.FloatSDKOperationOptionObjectDefinitionType,
				}, nil
			}

			if strings.EqualFold(format, "decimal") {
				return &sdkModels.SDKOperationOptionObjectDefinition{
					Type: sdkModels.FloatSDKOperationOptionObjectDefinitionType,
				}, nil
			}

			if format != "" {
				// we don't know what this is, better to raise an error and handle it than make
				// it an integer if it should be a float or something
				return nil, fmt.Errorf("unsupported format type for number %q", format)
			}

			return &sdkModels.SDKOperationOptionObjectDefinition{
				Type: sdkModels.IntegerSDKOperationOptionObjectDefinitionType,
			}, nil
		}

	case "string":
		return &sdkModels.SDKOperationOptionObjectDefinition{
			Type: sdkModels.StringSDKOperationOptionObjectDefinitionType,
		}, nil
	}
	return nil, fmt.Errorf("unsupported field type %q", paramType)
}

func (p operationsParser) determineContentType(operation parsedOperation) string {
	contentType := "application/json"

	if strings.EqualFold(operation.httpMethod, "HEAD") || strings.EqualFold(operation.httpMethod, "GET") {
		if len(operation.operation.Produces) > 0 {
			contentType = operation.operation.Produces[0]
		}
	} else {
		if len(operation.operation.Consumes) > 0 {
			contentType = operation.operation.Consumes[0]
		}
	}

	return contentType
}

func (p operationsParser) expectedStatusCodesForOperation(input parsedOperation) []int {
	statusCodes := make([]int, 0)

	for statusCode, resp := range input.operation.Responses.StatusCodeResponses {
		// sanity checking
		if p.operationIsASuccess(statusCode, resp) {
			statusCodes = append(statusCodes, statusCode)
		}
	}

	if !usesNonDefaultStatusCodes(input, statusCodes) {
		if p.operationIsLongRunning(input) {
			if strings.EqualFold(input.httpMethod, "delete") {
				statusCodes = []int{200, 202}
			}
			if strings.EqualFold(input.httpMethod, "post") {
				statusCodes = []int{201, 202}
			}
			if strings.EqualFold(input.httpMethod, "put") {
				statusCodes = []int{201, 202}
			}
		}
		if p.isListOperation(input) {
			if strings.EqualFold(input.httpMethod, "get") {
				statusCodes = []int{200}
			}
		}
		if strings.EqualFold(input.httpMethod, "delete") || strings.EqualFold(input.httpMethod, "get") || strings.EqualFold(input.httpMethod, "post") || strings.EqualFold(input.httpMethod, "head") {
			statusCodes = []int{200}
		}
		if strings.EqualFold(input.httpMethod, "put") || strings.EqualFold(input.httpMethod, "patch") {
			statusCodes = []int{200, 201}
		}
	}
	sort.Ints(statusCodes)

	return statusCodes
}

func (p operationsParser) fieldContainingPaginationDetailsForOperation(input parsedOperation) *string {
	if raw, ok := input.operation.VendorExtensible.Extensions["x-ms-pageable"]; ok {
		val, ok := raw.(map[string]interface{})
		if ok {
			for k, v := range val {
				// this can be 'null' in the swagger
				if v == nil {
					continue
				}
				if strings.EqualFold("nextLinkName", k) {
					str := v.(string)
					return &str
				}
			}
		}
	}

	return nil
}

func (p operationsParser) isListOperation(input parsedOperation) bool {
	paginationField := p.fieldContainingPaginationDetailsForOperation(input)
	if paginationField != nil {
		return true
	}

	// otherwise if we have a parameter of `$skiptoken` in the query, we assume that it is
	for _, parameter := range input.operation.Parameters {
		if strings.EqualFold(parameter.Name, "$skipToken") {
			return true
		}
	}

	return false
}

func (p operationsParser) operationIsLongRunning(input parsedOperation) bool {
	// Some Swaggers have the following defined on an Operation:
	//   > "x-ms-long-running-operation": true,
	//   > "x-ms-long-running-operation-options": {
	//   >   "final-state-via": "azure-async-operation"
	//   > }
	// Whilst these _could_ be useful at some point we can likely ignore them for
	// the moment since the convention is either `Location` or `Azure-AsyncOperation`
	val, exists := input.operation.Extensions.GetBool("x-ms-long-running-operation")
	if !exists {
		return false
	}

	return val
}

func (p operationsParser) optionsForOperation(input parsedOperation) (*map[string]sdkModels.SDKOperationOption, *parserModels.ParseResult, error) {
	output := make(map[string]sdkModels.SDKOperationOption)
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
	}

	for _, param := range input.operation.Parameters {
		// these are (currently) handled elsewhere, so we're good for now
		if strings.EqualFold(param.Name, "$skipToken") {
			// NOTE: we may also need to do the odata ones, media has an example
			continue
		}

		// handled elsewhere
		if strings.EqualFold(param.Name, "api-version") {
			continue
		}

		if strings.EqualFold(param.In, "header") || strings.EqualFold(param.In, "query") {
			val := param.Name
			name := cleanup.NormalizeName(val)

			option := sdkModels.SDKOperationOption{
				Required: param.Required,
			}

			if strings.EqualFold(param.In, "header") {
				option.HeaderName = &val
			}
			if strings.EqualFold(param.In, "query") {
				option.QueryStringName = &val
			}

			// looks like these can be dates etc too
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "name": "reportedEndTime",
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "in": "query",
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "required": true,
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "type": "string",
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json:            "format": "date-time",
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "description": "The end of the time range to retrieve data for."
			objectDefinition, err := p.determineObjectDefinitionForOption(param)
			if err != nil {
				return nil, nil, fmt.Errorf("determining field type for operation: %+v", err)
			}
			option.ObjectDefinition = *objectDefinition

			if param.Enum != nil {
				types := []string{
					param.Type,
				}
				constant, err := constants.Parse(types, param.Name, nil, param.Enum, param.Extensions)
				if err != nil {
					return nil, nil, fmt.Errorf("mapping %q: %+v", param.Name, err)
				}
				result.Constants[constant.Name] = constant.Details

				option.ObjectDefinition = sdkModels.SDKOperationOptionObjectDefinition{
					Type:          sdkModels.ReferenceSDKOperationOptionObjectDefinitionType,
					ReferenceName: &constant.Name,
				}
			}

			output[name] = option
		}
	}

	return &output, &result, nil
}

func (p operationsParser) operationShouldBeIgnored(input sdkModels.SDKOperation) bool {
	// Some HTTP Operations don't make sense for us to expose at this time, for example
	// a GET request which returns no content. They may at some point in the future but
	// for now there's not much point
	//
	// Example: the 'GetSubscriptionOperationWithAsyncResponse' in Web, which returns the
	// result of a LRO - but in our case that's handled elsewhere so we don't need it
	if strings.EqualFold(input.Method, "GET") {
		if len(input.ExpectedStatusCodes) == 1 && input.ExpectedStatusCodes[0] == http.StatusNoContent && input.ResponseObject == nil {
			return true
		}
	}

	return false
}

func (p operationsParser) requestObjectForOperation(input parsedOperation, known parserModels.ParseResult) (*sdkModels.SDKObjectDefinition, *parserModels.ParseResult, error) {
	// all we should parse out is the top level object - nothing more.

	// find the same operation in the unexpanded swagger spec since we need the reference name
	_, _, unexpandedOperation, found := p.swaggerDefinition.swaggerSpecWithReferences.OperationForName(input.operation.ID)
	if !found {
		return nil, nil, nil
	}

	for _, param := range unexpandedOperation.Parameters {
		if strings.EqualFold(param.In, "body") {
			parsingModel := true
			objectDefinition, result, err := p.swaggerDefinition.parseObjectDefinition(param.Schema.Title, param.Schema.Title, param.Schema, known, parsingModel)
			if err != nil {
				return nil, nil, fmt.Errorf("parsing request object for parameter %q: %+v", param.Name, err)
			}
			if objectDefinition != nil {
				return objectDefinition, result, nil
			}
		}
	}

	return nil, nil, nil
}

type operationResponseObjectResult struct {
	objectDefinition    *sdkModels.SDKObjectDefinition
	paginationFieldName *string
}

func (p operationsParser) operationIsASuccess(statusCode int, resp spec.Response) bool {
	// Status Codes with the extension `x-ms-error-response` reference an error response
	// which should be ignored in our case - as errors will instead be pulled out via the
	// base layer
	isErrorValue, exists := resp.Extensions.GetBool("x-ms-error-response")
	if exists && isErrorValue {
		return false
	}

	return statusCode >= 200 && statusCode < 300
}

func (p operationsParser) responseObjectForOperation(input parsedOperation, known parserModels.ParseResult) (*operationResponseObjectResult, *parserModels.ParseResult, error) {
	output := operationResponseObjectResult{}
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	result.Append(known)

	// find the same operation in the unexpanded swagger spec since we need the reference name
	_, _, unexpandedOperation, found := p.swaggerDefinition.swaggerSpecWithReferences.OperationForName(input.operation.ID)
	if !found {
		return nil, nil, fmt.Errorf("couldn't find Operation ID %q in the unexpanded Swagger spec", input.operation.ID)
	}

	// since it's possible for operations to have multiple status codes, parse out all the objects and then find the most applicable
	statusCodes := make([]int, 0)
	objectDefinitionsByStatusCode := map[int]sdkModels.SDKObjectDefinition{}
	for statusCode, details := range unexpandedOperation.Responses.StatusCodeResponses {
		if !p.operationIsASuccess(statusCode, details) {
			continue
		}

		if details.ResponseProps.Schema == nil {
			continue
		}

		parsingModel := true
		objectDefinition, nestedResult, err := p.swaggerDefinition.parseObjectDefinition(details.ResponseProps.Schema.Title, details.ResponseProps.Schema.Title, details.ResponseProps.Schema, result, parsingModel)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing response object from status code %d: %+v", statusCode, err)
		}

		statusCodes = append(statusCodes, statusCode)
		objectDefinitionsByStatusCode[statusCode] = *objectDefinition
		result.Append(*nestedResult)
	}

	sort.Ints(statusCodes)
	// if there's multiple status codes, pick the first successful one (which should be a 200)
	for _, statusCode := range statusCodes {
		if statusCode < 200 || statusCode >= 300 {
			continue
		}

		object, ok := objectDefinitionsByStatusCode[statusCode]
		if !ok {
			return nil, nil, fmt.Errorf("internal-error: missing object definitions by status code for %d", statusCode)
		}
		output.objectDefinition = &object
		break
	}
	// otherwise just take the first one
	if len(statusCodes) > 0 && output.objectDefinition == nil {
		statusCode := statusCodes[0]
		object, ok := objectDefinitionsByStatusCode[statusCode]
		if !ok {
			return nil, nil, fmt.Errorf("internal-error: missing object definitions by status code for %d", statusCode)
		}
		output.objectDefinition = &object
	}

	return &output, &result, nil
}

type parsedOperation struct {
	name       string
	uri        string
	httpMethod string
	operation  *spec.Operation
}

func (d *SwaggerDefinition) findOperationsMatchingTag(tag *string) *[]parsedOperation {
	result := make([]parsedOperation, 0)
	for httpMethod, operation := range d.swaggerSpecExpanded.Operations() {
		// operation = inferMissingTags(operation, tag)
		for uri, operationDetails := range operation {
			if !operationMatchesTag(operationDetails, tag) {
				continue
			}

			operationName := cleanup.NormalizeOperationName(operationDetails.ID, tag)
			result = append(result, parsedOperation{
				name:       operationName,
				uri:        uri,
				httpMethod: httpMethod,
				operation:  operationDetails,
			})
		}
	}

	return &result
}

func usesNonDefaultStatusCodes(input parsedOperation, statusCodes []int) bool {
	defaultStatusCodes := map[string][]int{
		"get":    {200},
		"post":   {200, 201},
		"put":    {200, 201},
		"delete": {200, 201},
		"patch":  {200, 201},
	}
	expected, ok := defaultStatusCodes[strings.ToLower(input.httpMethod)]
	if !ok {
		// potentially an unsupported use-case but fine for now
		return true
	}

	if len(expected) != len(statusCodes) {
		return true
	}

	sort.Ints(expected)
	sort.Ints(statusCodes)
	for i, ev := range expected {
		av := statusCodes[i]
		if ev != av {
			return true
		}
	}

	return false
}
