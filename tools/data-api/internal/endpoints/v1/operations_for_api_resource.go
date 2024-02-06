// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func (api Api) operationsForApiResource(w http.ResponseWriter, r *http.Request) {
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
					ObjectDefinition: *mapOptionObjectDefinition(option.ObjectDefinition),
					Required:         option.Required,
				}
			}
		}

		requestObject, err := mapObjectDefinition(details.RequestObject)
		if err != nil {
			internalServerError(w, fmt.Errorf("mapping request object for operation %q: %+v", method, err))
		}

		responseObject, err := mapObjectDefinition(details.ResponseObject)
		if err != nil {
			internalServerError(w, fmt.Errorf("mapping response object for operation %q: %+v", method, err))
		}

		operations[method] = models.ApiOperation{
			ContentType:                      pointer.To(details.ContentType),
			ExpectedStatusCodes:              details.ExpectedStatusCodes,
			LongRunning:                      details.LongRunning,
			Method:                           details.Method,
			RequestObject:                    requestObject,
			ResourceIdName:                   details.ResourceIdName,
			ResponseObject:                   responseObject,
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
