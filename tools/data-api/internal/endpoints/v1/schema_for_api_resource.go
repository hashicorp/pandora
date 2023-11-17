package v1

import (
	"fmt"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func (api Api) schemaForApiResource(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	resource, ok := ctx.Value("resourceName").(*repositories.ServiceApiVersionResourceDetails)
	if !ok {
		internalServerError(w, fmt.Errorf("missing resourceName"))
		return
	}

	constants := make(map[string]models.ConstantDetails, 0)
	schemaModels := make(map[string]models.ModelDetails, 0)
	resourceIds := make(map[string]models.ResourceIdDefinition, 0)

	for k, constant := range resource.Schema.Constants {
		constantType, err := mapConstantType(constant.Type)
		if err != nil {
			internalServerError(w, fmt.Errorf("mapping constant %q: %+v", k, err))
			return
		}
		constants[k] = models.ConstantDetails{
			Type:   *constantType,
			Values: constant.Values,
		}
	}

	for k, schemaModel := range resource.Schema.Models {
		fields, err := mapSchemaFields(schemaModel.Fields)
		if err != nil {
			internalServerError(w, fmt.Errorf("mapping fields for model %q: %+v", k, err))
			return
		}
		schemaModels[k] = models.ModelDetails{
			Fields:         fields,
			ParentTypeName: schemaModel.ParentTypeName,
			TypeHintIn:     schemaModel.TypeHintIn,
			TypeHintValue:  schemaModel.TypeHintValue,
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
