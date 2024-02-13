// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package endpoints

import (
	"log"

	"github.com/go-chi/chi/v5"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints/infrastructure"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints/v1"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func Router(directory string, serviceNames *[]string) func(chi.Router) {
	return func(router chi.Router) {
		router.Route("/v1", infrastructure.Router)
		router.Route("/v1/microsoft-graph", func(r chi.Router) {
			opts := v1.Options{
				ServiceType:     repositories.MicrosoftGraphServiceType,
				UriPrefix:       "/v1/microsoft-graph",
				UsesCommonTypes: true,
			}
			serviceRepo, err := repositories.NewServicesRepository(directory, opts.ServiceType, serviceNames)
			if err != nil {
				// TODO logging
				log.Fatalf("Error: %+v", err)
			}
			v1.Router(r, opts, serviceRepo)
		})
		router.Route("/v1/resource-manager", func(r chi.Router) {
			opts := v1.Options{
				ServiceType:     repositories.ResourceManagerServiceType,
				UriPrefix:       "/v1/resource-manager",
				UsesCommonTypes: false,
			}
			serviceRepo, err := repositories.NewServicesRepository(directory, opts.ServiceType, serviceNames)
			if err != nil {
				// TODO logging
				log.Fatalf("Error: %+v", err)
			}
			v1.Router(r, opts, serviceRepo)
		})
		router.Get("/", HomePage(router))
	}
}
