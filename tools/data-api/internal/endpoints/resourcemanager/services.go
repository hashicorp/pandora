package resourcemanager

import (
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func services(w http.ResponseWriter, r *http.Request) {
	payload := models.ServicesDefinition{
		Services: map[string]models.ServiceSummary{
			"Compute": {
				Generate: true,
				Uri:      "/v1/resource-manager/services/Compute",
			},
		},
	}
	render.JSON(w, r, payload)
}
