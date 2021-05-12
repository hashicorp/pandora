package parser

import (
	"fmt"
	"net/http"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"

	"github.com/go-openapi/spec"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (d *SwaggerDefinition) findOperationsForTag(tag *string, uriToDetails map[string]idDetails) (*map[string]models.OperationDetails, error) {
	out := make(map[string]models.OperationDetails, 0)
	for httpMethod, operation := range d.swaggerSpecExpanded.Operations() {
		for uri, operationDetails := range operation {
			if !operationMatchesTag(operationDetails, tag) {
				continue
			}

			operationName := normalizeOperationName(operationDetails.ID, tag)
			if existingVal, hasExisting := out[operationName]; hasExisting {
				return nil, fmt.Errorf("duplicate operation ID %q - first %q %q - second %q %q", operationName, existingVal.Method, existingVal.Uri, httpMethod, uri)
			}

			url := newOperationUri(uri)
			if !url.isArmResourceId() || url.shouldBeIgnored() {
				continue
			}

			details, ok := uriToDetails[url.normalizedUri()]
			if !ok {
				return nil, fmt.Errorf("missing details for %q", url.normalizedUri())
			}
			operationData, err := d.parseOperation(operationName, httpMethod, url, &details, operationDetails)
			if err != nil {
				return nil, fmt.Errorf("parsing operation %q: %+v", operationName, err)
			}

			if operationData != nil {
				out[operationName] = *operationData
			}
		}
	}
	return &out, nil
}

func (d *SwaggerDefinition) parseOperation(operationName, httpMethod string, uri operationUri, operation *idDetails, operationDetails *spec.Operation) (*models.OperationDetails, error) {
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

	expectedStatusCodes := expectedStatusCodesForOperation(operationDetails)
	requestObjectName := d.requestObjectForOperation(operationDetails, operationName)
	responseObjectName := d.responseObjectForOperation(operationDetails, operationName)
	longRunning := operationIsLongRunning(operationDetails)
	options := optionsForOperation(operationDetails)
	paginationField := fieldContainingPaginationDetailsForOperation(operationDetails)

	operationData := models.OperationDetails{
		ApiVersion:                       nil, // TODO: investigate 'security' and other packages which use this
		ContentType:                      contentType,
		ExpectedStatusCodes:              expectedStatusCodes,
		FieldContainingPaginationDetails: paginationField,
		LongRunning:                      longRunning,
		Method:                           strings.ToUpper(httpMethod),
		Options:                          options,
		RequestObjectName:                requestObjectName,
		ResponseObjectName:               responseObjectName,
		Uri:                              uri.normalizedUri(),
		// TODO: add the Options to the generator
	}

	if operation != nil {
		operationData.ResourceIdName = operation.resourceIdName
		operationData.UriSuffix = operation.suffix
	}

	if operationShouldBeIgnored(operationData) {
		return nil, nil
	}

	return &operationData, nil
}

func optionsForOperation(input *spec.Operation) map[string]models.OperationOption {
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
			// looks like these can be dates etc too
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "name": "reportedEndTime",
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "in": "query",
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "required": true,
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "type": "string",
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json:            "format": "date-time",
			//./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "description": "The end of the time range to retrieve data for."
			output[name] = models.OperationOption{
				FieldType:       param.Type, // TODO: this'll likely need to be parsed but it's fine for now
				QueryStringName: param.Name,
				Required:        param.Required,
			}
		}
	}

	return output
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

func (d *SwaggerDefinition) requestObjectForOperation(operationDetails *spec.Operation, operationName string) *string {
	// find the same operation in the unexpanded swagger spec since we need the reference name
	_, _, unexpandedOperation, found := d.swaggerSpecWithReferences.OperationForName(operationDetails.ID)
	if !found {
		return nil
	}

	for _, param := range unexpandedOperation.Parameters {
		if strings.EqualFold(param.In, "body") {
			var fragmentName *string

			// if it's a singular type
			if param.Schema != nil {
				fragmentName = fragmentNameFromReference(param.Schema.Ref)

				// if it's taking a list
				if param.Schema.Type.Contains("array") {
					if param.Schema.Items != nil && param.Schema.Items.Schema != nil {
						fragmentName = fragmentNameFromReference(param.Schema.Items.Schema.Ref)
					}
				}
			}

			// TODO: should we fall back to normalizing the name of this field? is that reliable?

			if fragmentName != nil {
				v := normalizeModelName(*fragmentName)
				fragmentName = &v
			}
			return fragmentName
		}
	}
	return nil
}

func (d *SwaggerDefinition) responseObjectForOperation(operationDetails *spec.Operation, operationName string) *string {
	// find the same operation in the unexpanded swagger spec since we need the reference name
	_, _, unexpandedOperation, found := d.swaggerSpecWithReferences.OperationForName(operationDetails.ID)
	if !found {
		return nil
	}

	for statusCode, details := range unexpandedOperation.Responses.StatusCodeResponses {
		if operationIsASuccess(statusCode) {
			var fragmentName *string

			// if it's a singular type
			if details.ResponseProps.Schema != nil {
				fragmentName = fragmentNameFromReference(details.ResponseProps.Schema.Ref)
			}

			// if it's taking a list
			if details.ResponseProps.Schema != nil && details.ResponseProps.Schema.Type.Contains("array") {
				if details.ResponseProps.Schema.Items != nil && details.ResponseProps.Schema.Items.Schema != nil {
					fragmentName = fragmentNameFromReference(details.ResponseProps.Schema.Items.Schema.Ref)
				}
			}

			// TODO: should we fall back to normalizing the name of this field? is that reliable?

			if fragmentName != nil {
				v := normalizeModelName(*fragmentName)
				fragmentName = &v
			}
			return fragmentName
		}
	}

	return nil
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
