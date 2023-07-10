package endpoints

import (
	"github.com/go-chi/chi/v5"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints/infrastructure"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints/resourcemanager"
)

func Router(router chi.Router) {
	router.Route("/infrastructure", infrastructure.Router)
	router.Route("/v1/resource-manager", resourcemanager.Router)
	router.Get("/", HomePage)
}
