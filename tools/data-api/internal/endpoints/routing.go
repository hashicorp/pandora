package endpoints

import (
	"github.com/go-chi/chi/v5"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints/infrastructure"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func Router(router chi.Router) {
	router.Route("/infrastructure", infrastructure.Router)
	router.Route("/v1/resource-manager", func(r chi.Router) {
		opts := v1.Options{
			ServiceType:     repositories.ResourceManagerServiceType,
			UriPrefix:       "/v1/resource-manager",
			UsesCommonTypes: false,
		}
		v1.Router(r, opts)
	})
	router.Get("/", HomePage)
}
