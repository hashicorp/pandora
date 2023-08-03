package v1

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func commonTypes(w http.ResponseWriter, r *http.Request) {
	ctx := r.Context()

	opts, ok := ctx.Value("options").(Options)
	if !ok {
		internalServerError(w, fmt.Errorf("missing options"))
		return
	}
	payload := models.CommonTypesDetails{
		Constants: map[string]models.ConstantDetails{},
		Models:    map[string]models.ModelDetails{},
	}
	if !opts.UsesCommonTypes {
		render.JSON(w, r, payload)
		return
	}

	commonTypes, ok := ctx.Value("commonTypes").(repositories.CommonTypesDetails)
	if !ok {
		internalServerError(w, fmt.Errorf("missing commonTypes"))
		return
	}

	payload.Constants = mapCommonTypesConstants(commonTypes.Constants)
	payload.Models = mapCommonTypesModels(commonTypes.Models)

	render.JSON(w, r, payload)
}

func mapCommonTypesConstants(input map[string]repositories.CommonTypesConstantDetails) map[string]models.ConstantDetails {
	output := make(map[string]models.ConstantDetails, 0)

	for name, constant := range input {
		values := make(map[string]string, 0)

		for name, value := range constant.Values {
			values[name] = value
		}

		output[name] = models.ConstantDetails{
			CaseInsensitive: constant.CaseInsensitive,
			Type:            models.ConstantType(constant.Type),
			Values:          values,
		}
	}

	return output
}

func mapCommonTypesModels(input map[string]repositories.CommonTypesModelDetails) map[string]models.ModelDetails {
	output := make(map[string]models.ModelDetails, 0)

	for name, model := range input {
		output[name] = models.ModelDetails{
			Fields:         mapSchemaFields(model.Fields),
			ParentTypeName: model.ParentTypeName,
			TypeHintIn:     model.TypeHintIn,
			TypeHintValue:  model.TypeHintValue,
		}
	}

	return output
}
