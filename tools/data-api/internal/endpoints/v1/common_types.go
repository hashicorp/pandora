// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints/v1/transforms"
)

func (api Api) commonTypes(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	opts, ok := ctx.Value("options").(Options)
	if !ok {
		internalServerError(w, fmt.Errorf("missing options"))
		return
	}

	services, err := api.servicesRepository.GetAll(opts.ServiceType)
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

	for _, service := range *services {
		for version, details := range service.ApiVersions {
			if details == nil {
				continue
			}

			for resourceName, resource := range details.Resources {
				if resource == nil {
					continue
				}

				mappedConstants, err := transforms.MapConstants(resource.Schema.Constants)
				if err != nil {
					internalServerError(w, fmt.Errorf("mapping constants for API Resource %q: %+v", resourceName, err))
					return
				}
				for k, v := range *mappedConstants {
					if _, ok := payload.Constants[k]; ok {
						internalServerError(w, fmt.Errorf("constant %q already exists in common types, there is a duplicated definition in the source data for service: %s, version: %s, resource: %s", k, service.Name, version, resourceName))
						return
					}
					payload.Constants[k] = v
				}

				mappedModels, err := transforms.MapSDKModels(resource.Schema.Models)
				if err != nil {
					internalServerError(w, fmt.Errorf("mapping models for API Resource %q: %+v", resourceName, err))
					return
				}
				for k, v := range *mappedModels {
					if _, ok := payload.Models[k]; ok {
						internalServerError(w, fmt.Errorf("model %q already exists in common types, there is a duplicated definition in the source data for service: %s, version: %s, resource: %s", k, service.Name, version, resourceName))
						return
					}
					payload.Models[k] = v
				}
			}

		}
	}

	render.JSON(w, r, payload)
}
