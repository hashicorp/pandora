// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (api Api) commonTypes(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	opts, ok := ctx.Value("options").(Options)
	if !ok {
		internalServerError(w, fmt.Errorf("missing options"))
		return
	}

	services, err := api.servicesRepository.GetAllServices()
	if err != nil {
		internalServerError(w, fmt.Errorf("loading services: %+v", err))
		return
	}

	payload := models.CommonTypes{
		Constants: map[string]models.SDKConstant{},
		Models:    map[string]models.SDKModel{},
	}
	if !opts.UsesCommonTypes || services == nil {
		render.JSON(w, r, payload)
		return
	}

	for serviceName, service := range *services {
		for apiVersion, apiVersionDetails := range service.APIVersions {
			for resourceName, resource := range apiVersionDetails.Resources {
				for k, v := range resource.Constants {
					payload.Constants[k] = v
				}

				for k, v := range resource.Models {
					if _, ok := payload.Models[k]; ok {
						internalServerError(w, fmt.Errorf("model %q already exists in common types, there is a duplicated definition in the source data for service: %s, version: %s, resource: %s", k, serviceName, apiVersion, resourceName))
						return
					}
					payload.Models[k] = v
				}
			}

		}
	}

	render.JSON(w, r, payload)
}
