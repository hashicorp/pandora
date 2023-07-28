package resourcemanager

import (
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func schemaForApiResource(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	resource, ok := ctx.Value("resourceName").(*repositories.ServiceApiVersionResourceDetails)
	if !ok {
		w.WriteHeader(http.StatusBadRequest)
		return
	}

	constants := make(map[string]models.ConstantDetails, 0)
	schemaModels := make(map[string]models.ModelDetails, 0)
	resourceIds := make(map[string]models.ResourceIdDefinition, 0)

	for k, constant := range resource.Schema.Constants {
		constants[k] = models.ConstantDetails{
			CaseInsensitive: constant.CaseInsensitive,
			Type:            models.ConstantType(constant.Type),
			Values:          constant.Values,
		}
	}

	for k, schemaModel := range resource.Schema.Models {
		schemaModels[k] = models.ModelDetails{
			Fields:        mapSchemaFields(schemaModel.Fields),
			TypeHintIn:    schemaModel.TypeHintIn,
			TypeHintValue: schemaModel.TypeHintValue,
		}
	}

	for k, resourceId := range resource.Schema.ResourceIds {
		resourceIds[k] = models.ResourceIdDefinition{
			CommonAlias:   resourceId.CommonAlias,
			ConstantNames: resourceId.ConstantNames,
			Id:            resourceId.Id,
			Segments:      mapResourceIdSegments(resourceId.Segments),
		}
	}

	payload := models.ApiSchemaDetails{
		Constants:   constants,
		Models:      schemaModels,
		ResourceIds: resourceIds,
	}

	render.JSON(w, r, payload)
}
