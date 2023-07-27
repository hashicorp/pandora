package resourcemanager

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func detailsForApiVersion(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()
	service, ok := ctx.Value("service").(*repositories.ServiceDetails)
	if !ok {
		w.WriteHeader(http.StatusBadRequest)
		return
	}
	apiVersion, ok := ctx.Value("serviceApiVersion").(*repositories.ServiceApiVersionDetails)
	if !ok {
		w.WriteHeader(http.StatusBadRequest)
		return
	}
	resources := make(map[string]models.ResourceSummary, 0)

	for k := range apiVersion.Resources {
		resources[k] = models.ResourceSummary{
			OperationsUri: fmt.Sprintf("/v1/resource-manager/services/%s/%s/%s/operations", service.Name, apiVersion.Name, k),
			SchemaUri:     fmt.Sprintf("/v1/resource-manager/services/%s/%s/%s/schema", service.Name, apiVersion.Name, k),
		}
	}

	payload := models.ServiceVersionDetails{
		Resources: resources,
		Source:    models.ApiDefinitionsSource(apiVersion.Source),
	}
	render.JSON(w, r, payload)
}
