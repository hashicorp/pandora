package resourcemanager

import (
	"net/http"
	
	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func terraform(w http.ResponseWriter, r *http.Request) {
	payload := models.TerraformDetails{
		DataSources: map[string]models.TerraformDataSourceDetails{},
		Resources:   map[string]models.TerraformResourceDetails{},
	}
	render.JSON(w, r, payload)
}
