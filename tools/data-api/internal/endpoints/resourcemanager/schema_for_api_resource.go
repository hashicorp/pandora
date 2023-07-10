package resourcemanager

import (
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func schemaForApiResource(w http.ResponseWriter, r *http.Request) {
	payload := models.ApiSchemaDetails{
		Constants: map[string]models.ConstantDetails{},
		Models: map[string]models.ModelDetails{
			"Computa": {
				Fields: map[string]models.FieldDetails{
					"Name": {
						ObjectDefinition: models.ApiObjectDefinition{
							Type: models.StringApiObjectDefinitionType,
						},
						Required: true,
					},
				},
				ParentTypeName: nil,
				TypeHintIn:     nil,
				TypeHintValue:  nil,
			},
		},
		ResourceIds: map[string]models.ResourceIdDefinition{},
	}
	render.JSON(w, r, payload)
}
