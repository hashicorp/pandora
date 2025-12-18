// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package endpoints

import (
	"github.com/go-chi/chi/v5"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints/infrastructure"
	v1 "github.com/hashicorp/pandora/tools/data-api/internal/endpoints/v1"
	"github.com/hashicorp/pandora/tools/data-api/internal/logging"
)

func Router(workingDirectory string, serviceNames *[]string) func(chi.Router) {
	return func(router chi.Router) {
		router.Route("/v1", infrastructure.Router)
		router.Route("/v1/microsoft-graph", func(r chi.Router) {
			opts := v1.Options{
				ServiceType: sdkModels.MicrosoftGraphSourceDataType,
				UriPrefix:   "/v1/microsoft-graph",
			}
			serviceRepo, err := repository.NewRepository(workingDirectory, opts.ServiceType, serviceNames, logging.Log)
			if err != nil {
				logging.Fatalf("Error: %+v", err)
			}
			v1.Router(r, opts, serviceRepo)
		})
		router.Route("/v1/resource-manager", func(r chi.Router) {
			opts := v1.Options{
				ServiceType: sdkModels.ResourceManagerSourceDataType,
				UriPrefix:   "/v1/resource-manager",
			}
			serviceRepo, err := repository.NewRepository(workingDirectory, opts.ServiceType, serviceNames, logging.Log)
			if err != nil {
				logging.Fatalf("Error: %+v", err)
			}
			v1.Router(r, opts, serviceRepo)
		})
		router.Get("/", HomePage(router))
	}
}
