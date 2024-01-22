// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/models"
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

	payload := models.CommonTypesDetails{
		Constants: map[string]models.ConstantDetails{},
		Models:    map[string]models.ModelDetails{},
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
				for k, v := range resource.Schema.Constants {
					if _, ok := payload.Constants[k]; ok {
						internalServerError(w, fmt.Errorf("constant %q already exists in common types, there is a duplicated definition in the source data for service: %s, version: %s, resource: %s", k, service.Name, version, resourceName))
						return
					}
					payload.Constants[k] = models.ConstantDetails{
						Type:   models.ConstantType(v.Type),
						Values: v.Values,
					}
				}

				for k, v := range resource.Schema.Models {
					if _, ok := payload.Models[k]; ok {
						internalServerError(w, fmt.Errorf("model %q already exists in common types, there is a duplicated definition in the source data for service: %s, version: %s, resource: %s", k, service.Name, version, resourceName))
						return
					}
					fields, err := mapSchemaFields(v.Fields)
					if err != nil {
						internalServerError(w, fmt.Errorf("mapping fields for model %q in service: %s, version: %s, resource: %s: %+v", k, service.Name, version, resourceName, err))
						return
					}
					payload.Models[k] = models.ModelDetails{
						Fields:         fields,
						ParentTypeName: v.ParentTypeName,
						TypeHintIn:     v.TypeHintIn,
						TypeHintValue:  v.TypeHintValue,
					}
				}

			}

		}
	}

	render.JSON(w, r, payload)
}
