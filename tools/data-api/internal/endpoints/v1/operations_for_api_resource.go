package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func operationsForApiResource(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	resource, ok := ctx.Value("resourceName").(*repositories.ServiceApiVersionResourceDetails)
	if !ok {
		internalServerError(w, fmt.Errorf("missing resourceName"))
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

	render.JSON(w, r, payload)
}
