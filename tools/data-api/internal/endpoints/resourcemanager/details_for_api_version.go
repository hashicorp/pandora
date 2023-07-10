package resourcemanager

import (
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func detailsForApiVersion(w http.ResponseWriter, r *http.Request) {
	payload := models.ServiceVersionDetails{
		Resources: map[string]models.ResourceSummary{
			"VirtualMachines": {
				OperationsUri: "/v1/resource-manager/services/Compute/2020-01-01/VirtualMachines/operations",
				SchemaUri:     "/v1/resource-manager/services/Compute/2020-01-01/VirtualMachines/schema",
			},
		},
		Source: models.ApiDefinitionsSourceHandWritten,
	}
	render.JSON(w, r, payload)
}
