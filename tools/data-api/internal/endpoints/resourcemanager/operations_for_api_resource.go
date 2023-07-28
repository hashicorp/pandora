package resourcemanager

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
	"net/http"

	"github.com/go-chi/render"
)

func operationsForApiResource(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	resource, ok := ctx.Value("resourceName").(*repositories.ServiceApiVersionResourceDetails)
	if !ok {
		w.WriteHeader(http.StatusBadRequest)
		return
	}

	operations := make(map[string]models.ApiOperation, 0)

	for method, details := range resource.Operations {

		options := make(map[string]models.ApiOperationOption, 0)

		if details.Options != nil {
			for k, option := range *details.Options {
				options[k] = models.ApiOperationOption{
					HeaderName:       option.HeaderName,
					QueryStringName:  option.QueryStringName,
					ObjectDefinition: pointer.From(mapObjectDefinition(option.ObjectDefinition)),
					Required:         option.Required,
				}
			}
		}

		operations[method] = models.ApiOperation{
			ContentType:                      pointer.To(details.ContentType),
			ExpectedStatusCodes:              details.ExpectedStatusCodes,
			LongRunning:                      details.LongRunning,
			Method:                           details.Method,
			RequestObject:                    mapObjectDefinition(details.RequestObject),
			ResourceIdName:                   details.ResourceIdName,
			ResponseObject:                   mapObjectDefinition(details.ResponseObject),
			FieldContainingPaginationDetails: details.FieldContainingPaginationDetails,
			Options:                          options,
			UriSuffix:                        details.UriSuffix,
		}
	}

	payload := models.ApiOperationDetails{
		Operations: operations,
	}
	//payload := models.ApiOperationDetails{
	//	Operations: map[string]models.ApiOperation{
	//		"Get": {
	//			ContentType: pointer.To("application/json"),
	//			ExpectedStatusCodes: []int{
	//				http.StatusOK,
	//			},
	//			LongRunning:    false,
	//			Method:         http.MethodGet,
	//			RequestObject:  nil,
	//			ResourceIdName: nil,
	//			ResponseObject: &models.ApiObjectDefinition{
	//				ReferenceName: pointer.To("Computa"),
	//				Type:          models.ReferenceApiObjectDefinitionType,
	//			},
	//			FieldContainingPaginationDetails: nil,
	//			Options:                          nil,
	//			UriSuffix:                        nil,
	//		},
	//	},
	//}
	render.JSON(w, r, payload)
}

func mapObjectDefinition(input *repositories.ObjectDefinition) *models.ApiObjectDefinition {
	output := models.ApiObjectDefinition{}

	if input != nil {
		output.NestedItem = mapObjectDefinition(input.NestedItem)
		output.ReferenceName = input.ReferenceName
		output.Type = models.ApiObjectDefinitionType(input.Type)
	}

	return &output
}
