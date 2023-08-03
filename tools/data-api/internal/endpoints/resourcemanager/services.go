package resourcemanager

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

var servicesRepository = &repositories.ServicesRepositoryImpl{}

func services(w http.ResponseWriter, r *http.Request) {
	opts, ok := r.Context().Value("options").(Options)
	if !ok {
		internalServerError(w, fmt.Errorf("missing options"))
		return
	}

	payload := models.ServicesDefinition{
		Services: make(map[string]models.ServiceSummary, 0),
	}
	services, err := servicesRepository.GetAll(opts.ServiceType)
	if err != nil {
		internalServerError(w, fmt.Errorf("loading services: %+v", err))
		return
	}
	for _, service := range *services {
		payload.Services[service.Name] = models.ServiceSummary{
			Generate: service.Generate,
			Uri:      fmt.Sprintf("/v1/resource-manager/services/%s", service.Name),
		}
	}
	render.JSON(w, r, payload)
}
