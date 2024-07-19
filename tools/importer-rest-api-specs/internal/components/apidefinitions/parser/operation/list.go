package operation

import (
	"net/http"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
)

type listOperationDetails struct {
	fieldContainingPaginationDetails *string
	valueObjectDefinition            *sdkModels.SDKObjectDefinition
}

func listOperationDetailsForOperation(input sdkModels.SDKOperation, known parserModels.ParseResult) *listOperationDetails {
	if !strings.EqualFold(input.Method, http.MethodGet) && !strings.EqualFold(input.Method, http.MethodPost) {
		return nil
	}

	// an operation without a response object isn't going to be listable
	if input.ResponseObject == nil {
		return nil
	}
	if input.ResponseObject.Type == sdkModels.ReferenceSDKObjectDefinitionType {
		responseModel, isModel := known.Models[*input.ResponseObject.ReferenceName]
		if !isModel {
			// a constant wouldn't be listable
			return nil
		}

		out := listOperationDetails{}
		if input.FieldContainingPaginationDetails != nil {
			out.fieldContainingPaginationDetails = input.FieldContainingPaginationDetails
		}
		for fieldName, v := range responseModel.Fields {
			if strings.EqualFold(fieldName, "nextLink") {
				out.fieldContainingPaginationDetails = pointer.To(fieldName)
				continue
			}

			if strings.EqualFold(fieldName, "Value") {
				// switch out the reference to be the SDKObjectDefinition for the `Value` field, rather than
				// the wrapper type
				definition := sdkHelpers.InnerMostSDKObjectDefinition(v.ObjectDefinition)
				out.valueObjectDefinition = pointer.To(definition)
				continue
			}
		}
		if out.fieldContainingPaginationDetails != nil && out.valueObjectDefinition != nil {
			return &out
		}
	}

	return nil
}

func RemoveWrapperModelForListOperations(input map[string]sdkModels.SDKOperation, known parserModels.ParseResult) (map[string]sdkModels.SDKOperation, error) {
	// List Operations return an object which contains a NextLink and a Value (which is the actual Object
	// being paginated on) - so we want to replace the wrapper object with the Value so that these can be
	// paginated correctly as needed.
	output := make(map[string]sdkModels.SDKOperation)

	for operationName := range input {
		operation := input[operationName]

		// if the Response Object is a List Operation (identifiable via
		listDetails := listOperationDetailsForOperation(operation, known)
		if listDetails != nil {
			operation.FieldContainingPaginationDetails = listDetails.fieldContainingPaginationDetails
			operation.ResponseObject = listDetails.valueObjectDefinition
		}

		output[operationName] = operation
	}

	return output, nil
}
