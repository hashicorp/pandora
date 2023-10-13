package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func (api Api) detailsForApiVersion(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	opts, ok := ctx.Value("options").(Options)
	if !ok {
		internalServerError(w, fmt.Errorf("missing options"))
		return
	}

	service, ok := ctx.Value("service").(*repositories.ServiceDetails)
	if !ok {
		internalServerError(w, fmt.Errorf("missing service"))
		return
	}
	apiVersion, ok := ctx.Value("serviceApiVersion").(*repositories.ServiceApiVersionDetails)
	if !ok {
		internalServerError(w, fmt.Errorf("missing serviceApiVersion"))
		return
	}
	resources := make(map[string]models.ResourceSummary, 0)

	for k := range apiVersion.Resources {
		resources[k] = models.ResourceSummary{
			OperationsUri: fmt.Sprintf("%s/services/%s/%s/%s/operations", opts.UriPrefix, service.Name, apiVersion.Name, k),
			SchemaUri:     fmt.Sprintf("%s/services/%s/%s/%s/schema", opts.UriPrefix, service.Name, apiVersion.Name, k),
		}
	}

	payload := models.ServiceVersionDetails{
		Resources: resources,
		Source:    models.ApiDefinitionsSource(apiVersion.Source),
	}
	render.JSON(w, r, payload)
}
