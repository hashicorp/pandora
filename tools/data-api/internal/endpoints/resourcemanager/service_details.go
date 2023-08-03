package resourcemanager

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func serviceDetails(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()
	service, ok := ctx.Value("service").(*repositories.ServiceDetails)
	if !ok {
		internalServerError(w, fmt.Errorf("missing service"))
		return
	}

	payload := models.ServiceDetails{
		ResourceProvider:     service.ResourceProvider,
		TerraformPackageName: service.TerraformPackageName,
		TerraformUri:         fmt.Sprintf("/v1/resource-manager/services/%s/terraform", service.Name),
		Versions:             make(map[string]models.ServiceVersion, 0),
	}
	for _, version := range service.ApiVersions {
		payload.Versions[version.Name] = models.ServiceVersion{
			Generate: version.Generate,
			Uri:      fmt.Sprintf("/v1/resource-manager/services/%s/%s", service.Name, version.Name),
		}
	}
	render.JSON(w, r, payload)
}
