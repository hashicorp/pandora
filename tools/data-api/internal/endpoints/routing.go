package endpoints

import (
	"github.com/go-chi/chi/v5"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints/infrastructure"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints/v1"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func Router(router chi.Router) {
	router.Route("/infrastructure", infrastructure.Router)
	router.Route("/v1/microsoft-graph/beta", func(r chi.Router) {
		opts := v1.Options{
			ServiceType:     repositories.MicrosoftGraphV1BetaServiceType,
			UriPrefix:       "/v1/microsoft-graph/beta",
			UsesCommonTypes: true,
		}
		v1.Router(r, opts)
	})
	router.Route("/v1/microsoft-graph/stable-v1", func(r chi.Router) {
		opts := v1.Options{
			ServiceType:     repositories.MicrosoftGraphV1StableServiceType,
			UriPrefix:       "/v1/microsoft-graph/stable-v1",
			UsesCommonTypes: true,
		}
		v1.Router(r, opts)
	})
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
