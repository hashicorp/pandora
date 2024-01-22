// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func (api Api) services(w http.ResponseWriter, r *http.Request) {
	opts, ok := r.Context().Value("options").(Options)
	if !ok {
		internalServerError(w, fmt.Errorf("missing options"))
		return
	}

	payload := models.ServicesDefinition{
		Services: make(map[string]models.ServiceSummary, 0),
	}
	services, err := api.servicesRepository.GetAll(opts.ServiceType)
	if err != nil {
		internalServerError(w, fmt.Errorf("loading services: %+v", err))
		return
	}

	for _, service := range *services {
		payload.Services[service.Name] = models.ServiceSummary{
			Generate: service.Generate,
			Uri:      fmt.Sprintf("%s/services/%s", opts.UriPrefix, service.Name),
		}
	}
	render.JSON(w, r, payload)
}
