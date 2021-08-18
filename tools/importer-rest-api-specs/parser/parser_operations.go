package parser

import (
	"fmt"
	"log"
	"net/http"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"

	"github.com/go-openapi/spec"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (d *SwaggerDefinition) findOperationsForTag(tag *string, uriToDetails map[string]idDetails) (*map[string]models.OperationDetails, *result, error) {
	out := make(map[string]models.OperationDetails, 0)
	result := result{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	for httpMethod, operation := range d.swaggerSpecExpanded.Operations() {
		for uri, operationDetails := range operation {
			if !operationMatchesTag(operationDetails, tag) {
				continue
			}

			operationName := normalizeOperationName(operationDetails.ID, tag)
			if existingVal, hasExisting := out[operationName]; hasExisting {
				return nil, nil, fmt.Errorf("duplicate operation ID %q - first %q %q - second %q %q", operationName, existingVal.Method, existingVal.Uri, httpMethod, uri)
			}

			url := newOperationUri(uri)
			if url.shouldBeIgnored() {
				if d.debugLog {
					log.Printf("[DEBUG] Skipping URI %q", url.normalizedUri())
				}
				continue
			}

			details, ok := uriToDetails[url.normalizedUri()]
			if !ok {
				return nil, nil, fmt.Errorf("missing details for %q", url.normalizedUri())
			}
			operationData, nestedResult, err := d.parseOperation(operationName, httpMethod, url, &details, operationDetails)
			if err != nil {
				return nil, nil, fmt.Errorf("parsing operation %q: %+v", operationName, err)
			}

			if operationData != nil {
				out[operationName] = *operationData
			}
			if nestedResult != nil {
				result.append(*nestedResult)
			}
		}
	}
	return &out, &result, nil
}

func (d *SwaggerDefinition) parseOperation(operationName, httpMethod string, uri operationUri, operation *idDetails, operationDetails *spec.Operation) (*models.OperationDetails, *result, error) {
	contentType := "application/json"
	if strings.EqualFold(httpMethod, "HEAD") || strings.EqualFold(httpMethod, "GET") {
		if len(operationDetails.Consumes) > 0 {
			contentType = operationDetails.Consumes[0]
		}
	} else {
		if len(operationDetails.Produces) > 0 {
			contentType = operationDetails.Produces[0]
		}
	}

	result := result{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}

	expectedStatusCodes := expectedStatusCodesForOperation(operationDetails)
	paginationField := fieldContainingPaginationDetailsForOperation(operationDetails)
	requestObjectName, nestedResult, err := d.requestObjectForOperation(operationDetails)
	if err != nil {
		return nil, nil, fmt.Errorf("determining request operation for %q (method %q / uri %q): %+v", operationName, httpMethod, uri.normalizedUri(), err)
	}
	if nestedResult != nil {
		result.append(*nestedResult)
	}
	responseObjectName, nestedResult, err := d.responseObjectForOperation(operationDetails, paginationField != nil)
	if err != nil {
		return nil, nil, fmt.Errorf("determining response operation for %q (method %q / uri %q): %+v", operationName, httpMethod, uri.normalizedUri(), err)
	}
	if nestedResult != nil {
		result.append(*nestedResult)
	}
	longRunning := operationIsLongRunning(operationDetails)

	nestedResult, err = constantsInOperationParameters(operationDetails)
	if err != nil {
		return nil, nil, fmt.Errorf("parsing constants within operation parameters: %+v", err)
	}
	if nestedResult != nil {
		result.append(*nestedResult)
	}

	options, err := optionsForOperation(operationDetails)
	if err != nil {
		return nil, nil, fmt.Errorf("building options for operation %q: %+v", operationName, err)
	}

	operationData := models.OperationDetails{
		ApiVersion:                       nil, // TODO: investigate 'security' and other packages which use this
		ContentType:                      contentType,
		ExpectedStatusCodes:              expectedStatusCodes,
		FieldContainingPaginationDetails: paginationField,
		LongRunning:                      longRunning,
		Method:                           strings.ToUpper(httpMethod),
		Options:                          *options,
		RequestObjectName:                requestObjectName,
		ResponseObjectName:               responseObjectName,
		Uri:                              uri.normalizedUri(),
	}

	if operation != nil {
		operationData.ResourceIdName = operation.resourceIdName
		operationData.UriSuffix = operation.suffix
	}

	if operationShouldBeIgnored(operationData) {
		return nil, nil, nil
	}

	return &operationData, &result, nil
}

func constantsInOperationParameters(input *spec.Operation) (*result, error) {
	out := result{
		constants: map[string]models.ConstantDetails{},
	}

	for _, param := range input.Parameters {
		if param.Enum == nil {
			continue
		}

		// these are (currently) handled elsewhere, so we're good for now
		if strings.EqualFold(param.Name, "$skipToken") {
			// NOTE: we may also need to do the odata ones, media has an example
			continue
		}

		// handled elsewhere
		if strings.EqualFold(param.Name, "api-version") {
			continue
		}

		types := []string{
			param.Type,
		}
		constant, err := mapConstant(types, param.Enum, param.Extensions)
		if err != nil {
			return nil, fmt.Errorf("mapping %q: %+v", param.Name, err)
		}
		out.constants[constant.name] = constant.details
	}

	return &out, nil
}

func optionsForOperation(input *spec.Operation) (*map[string]models.OperationOption, error) {
	output := make(map[string]models.OperationOption)

	for _, param := range input.Parameters {
		// these are (currently) handled elsewhere, so we're good for now
		if strings.EqualFold(param.Name, "$skipToken") {
			// NOTE: we may also need to do the odata ones, media has an example
			continue
		}

		// handled elsewhere
		if strings.EqualFold(param.Name, "api-version") {
			continue
		}

		// TODO: support parsing/generating these from Headers too
		if strings.EqualFold(param.In, "query") {
			name := cleanup.NormalizeName(param.Name)

			option := models.OperationOption{
				QueryStringName: param.Name,
				Required:        param.Required,
			}

			// looks like these can be dates etc too
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "name": "reportedEndTime",
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "in": "query",
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "required": true,
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "type": "string",
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json:            "format": "date-time",
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "description": "The end of the time range to retrieve data for."
			fieldType, err := determineFieldTypeForOption(param.Type, param.CollectionFormat)
			if err != nil {
				return nil, fmt.Errorf("determining field type for operation: %+v", err)
			}
			if fieldType != nil {
				option.FieldType = fieldType
			}

			if param.Enum != nil {
				constantName, err := parseConstantNameFromExtension(param.Extensions)
				if err != nil {
					return nil, fmt.Errorf("parsing constant name from extension for option %q: %+v", param.Name, err)
				}
				if constantName == nil {
					return nil, fmt.Errorf("missing x-ms-enum for option %q", param.Name)
				}

				option.ConstantObjectName = constantName
			}
			// TODO: FieldType within the struct should become a pointer
			// TODO: Add ConstantName *string to the struct

			output[name] = option
		}
	}

	return &output, nil
}

func determineFieldTypeForOption(input string, collectionFormat string) (*models.FieldDefinitionType, error) {
	var out models.FieldDefinitionType
	switch strings.ToLower(input) {
	case "boolean":
		out = models.Boolean
		return &out, nil
	case "array":
		{
			// https://github.com/Azure/azure-rest-api-specs/blob/1b0ed8edd58bb7c9ade9a27430759527bd4eec8e/specification/trafficmanager/resource-manager/Microsoft.Network/stable/2018-03-01/trafficmanager.json#L735-L738
			if strings.EqualFold(collectionFormat, "csv") {
				out = models.String
				return &out, nil
			}
		}
	case "integer":
		out = models.Integer
		return &out, nil
	case "string":
		out = models.String
		return &out, nil
	}
	return nil, fmt.Errorf("unsupported field type %q", input)
}

func fieldContainingPaginationDetailsForOperation(input *spec.Operation) *string {
	if raw, ok := input.VendorExtensible.Extensions["x-ms-pageable"]; ok {
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

func operationIsLongRunning(details *spec.Operation) bool {
	// Some Swaggers have the following defined on an Operation:
	//   > "x-ms-long-running-operation": true,
	//   > "x-ms-long-running-operation-options": {
	//   >   "final-state-via": "azure-async-operation"
	//   > }
	// Whilst these _could_ be useful at some point we can likely ignore them for
	// the moment since the convention is either `Location` or `Azure-AsyncOperation`
	val, exists := details.Extensions.GetBool("x-ms-long-running-operation")
	if !exists {
		return false
	}

	return val
}

func operationShouldBeIgnored(input models.OperationDetails) bool {
	// Some HTTP Operations don't make sense for us to expose at this time, for example
	// a GET request which returns no content. They may at some point in the future but
	// for now there's not much point
	//
	// Example: the 'GetSubscriptionOperationWithAsyncResponse' in Web, which returns the
	// result of a LRO - but in our case that's handled elsewhere so we don't need it
	if strings.EqualFold(input.Method, "GET") {
		if len(input.ExpectedStatusCodes) == 1 && input.ExpectedStatusCodes[0] == http.StatusNoContent && input.ResponseObjectName == nil {
			return true
		}
	}

	return false
}

func (d *SwaggerDefinition) requestObjectForOperation(operationDetails *spec.Operation) (*string, *result, error) {
	// find the same operation in the unexpanded swagger spec since we need the reference name
	_, _, unexpandedOperation, found := d.swaggerSpecWithReferences.OperationForName(operationDetails.ID)
	if !found {
		return nil, nil, nil
	}

	result := result{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	for _, param := range unexpandedOperation.Parameters {
		if strings.EqualFold(param.In, "body") {
			var objectName *string

			// if it's a singular type
			if param.Schema != nil {
				objectName = fragmentNameFromReference(param.Schema.Ref)
				if objectName == nil {
					if len(param.Schema.Properties) == 0 {
						return nil, nil, fmt.Errorf("request model must either be a reference or an inlined model but got neither")
					}

					nestedResult, err := d.parseModel(param.Schema.Title, *param.Schema)
					if err != nil {
						return nil, nil, fmt.Errorf("parsing object from inlined request model %q: %+v", param.Schema.Title, err)
					}

					if nestedResult != nil {
						objectName = &param.Schema.Title
						result.models[param.Schema.Title] = models.ModelDetails{
							Description: "",
							Fields:      nestedResult.fields.toMapOfModels(),
						}
						result.append(*nestedResult)
					}
				}

				// if it's taking a list
				if param.Schema.Items != nil && param.Schema.Items.Schema != nil {
					objectName = fragmentNameFromReference(param.Schema.Items.Schema.Ref)
					// @tombuildsstuff: appears you can't post a List of Items as a request param?
				}
			}

			if objectName != nil {
				v := normalizeModelName(*objectName)
				objectName = &v
			}
			return objectName, &result, nil
		}
	}

	return nil, &result, nil
}

func (d *SwaggerDefinition) responseObjectForOperation(operationDetails *spec.Operation, isListOperation bool) (*string, *result, error) {
	// find the same operation in the unexpanded swagger spec since we need the reference name
	_, _, unexpandedOperation, found := d.swaggerSpecWithReferences.OperationForName(operationDetails.ID)
	if !found {
		return nil, nil, nil
	}

	result := result{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}
	for statusCode, details := range unexpandedOperation.Responses.StatusCodeResponses {
		if operationIsASuccess(statusCode) {
			var objectName *string

			if details.ResponseProps.Schema == nil {
				continue
			}

			// if it's a singular type
			objectName = fragmentNameFromReference(details.ResponseProps.Schema.Ref)
			if objectName == nil {
				if len(details.ResponseProps.Schema.Properties) == 0 && details.ResponseProps.Schema.Type.Contains("object") {
					return nil, nil, fmt.Errorf("response model must either be a reference or an inlined model but got neither")
				}

				nestedResult, err := d.parseModel(details.ResponseProps.Schema.Title, *details.ResponseProps.Schema)
				if err != nil {
					return nil, nil, fmt.Errorf("parsing object from inlined response model %q: %+v", details.ResponseProps.Schema.Title, err)
				}

				if nestedResult != nil {
					objectName = &details.ResponseProps.Schema.Title
					result.models[details.ResponseProps.Schema.Title] = models.ModelDetails{
						Description: "",
						Fields:      nestedResult.fields.toMapOfModels(),
					}
					result.append(*nestedResult)
				}
			}

			// if it's taking a list
			if details.ResponseProps.Schema.Type.Contains("array") {
				if details.ResponseProps.Schema.Items != nil && details.ResponseProps.Schema.Items.Schema != nil {
					schema := details.ResponseProps.Schema.Items.Schema
					objectName = fragmentNameFromReference(schema.Ref)
					if objectName == nil {
						if len(schema.Properties) == 0 {
							return nil, nil, fmt.Errorf("response list model must either be a reference or an inlined model but got neither")
						}

						nestedResult, err := d.parseModel(schema.Title, *schema)
						if err != nil {
							return nil, nil, fmt.Errorf("parsing list object from inlined response model %q: %+v", schema.Title, err)
						}

						if nestedResult != nil {
							objectName = &schema.Title
							result.models[schema.Title] = models.ModelDetails{
								Description: "",
								Fields:      nestedResult.fields.toMapOfModels(),
							}
							result.append(*nestedResult)
						}
					}
				}
			}

			if objectName != nil {
				v := normalizeModelName(*objectName)
				objectName = &v
			}

			// however if this is a List operation, that is, we have a skipToken, we should find the model
			// and check for the `value` field to give us the real model
			if isListOperation {
				if objectName == nil {
					return nil, nil, fmt.Errorf("list operations must have a model, but this doesn't")
				}

				model, err := d.findTopLevelModel(*objectName)
				if err != nil {
					return nil, nil, fmt.Errorf("retrieving model %q for list operation to find real model: %+v", *objectName, err)
				}

				parsedModel, err := d.parseModel(*objectName, *model)
				if err != nil {
					return nil, nil, fmt.Errorf("parsing model %q for list operation to find real model: %+v", *objectName, err)
				}

				actualModelName := ""
				for k, v := range parsedModel.fields {
					if strings.EqualFold(k, "Value") {
						if v.Details.ModelReference == nil {
							return nil, nil, fmt.Errorf("parsing model %q for list operation to find real model: missing model reference for field 'value'", *objectName)
						}
						actualModelName = *v.Details.ModelReference
						break
					}
				}
				if actualModelName == "" {
					return nil, nil, fmt.Errorf("parsing model %q for list operation to find real model: model did not contain a field 'value'", *objectName)
				}
				objectName = &actualModelName
			}

			return objectName, &result, nil
		}
	}

	return nil, &result, nil
}

func expectedStatusCodesForOperation(operationDetails *spec.Operation) []int {
	statusCodes := make([]int, 0)

	for statusCode := range operationDetails.Responses.StatusCodeResponses {
		// sanity checking
		if operationIsASuccess(statusCode) {
			statusCodes = append(statusCodes, statusCode)
		}
	}

	return statusCodes
}

func operationIsASuccess(statusCode int) bool {
	return statusCode >= 200 && statusCode < 300
}
