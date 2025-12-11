// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
)

func (api Api) services(w http.ResponseWriter, r *http.Request) {
	opts, ok := r.Context().Value("options").(Options)
	if !ok {
		internalServerError(w, fmt.Errorf("missing options"))
		return
	}

	payload := v1.GetAvailableServices{
		Services: make(map[string]v1.AvailableServiceSummary),
	}
	services, err := api.servicesRepository.GetAllServices()
	if err != nil {
		internalServerError(w, fmt.Errorf("loading services: %+v", err))
		return
	}

	for serviceName, service := range *services {
		payload.Services[serviceName] = v1.AvailableServiceSummary{
			Generate: service.Generate,
			Uri:      fmt.Sprintf("%s/services/%s", opts.UriPrefix, serviceName),
		}
	}
	render.JSON(w, r, payload)
}
