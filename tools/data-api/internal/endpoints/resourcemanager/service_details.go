package resourcemanager

import (
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func serviceDetails(w http.ResponseWriter, r *http.Request) {
	payload := models.ServiceDetails{
		ResourceProvider:     "Microsoft.Compute",
		TerraformPackageName: pointer.To("compute"),
		TerraformUri:         "/v1/resource-manager/services/Compute/terraform",
		Versions: map[string]models.ServiceVersion{
			"2020-01-01": {
				Generate: true,
				Uri:      "/v1/resource-manager/services/Compute/2020-01-01",
				Preview:  false,
			},
			"2021-01-01": {
				Generate: true,
				Uri:      "/v1/resource-manager/services/Compute/2021-01-01",
				Preview:  false,
			},
		},
	}
	render.JSON(w, r, payload)
}
