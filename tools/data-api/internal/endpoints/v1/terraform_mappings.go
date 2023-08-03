package v1

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func mapSchemaModels(input *map[string]repositories.TerraformSchemaModelDefinition) map[string]models.TerraformSchemaModelDefinition {
	if input == nil {
		return nil
	}

	output := make(map[string]models.TerraformSchemaModelDefinition, 0)

	for name, model := range *input {
		output[name] = models.TerraformSchemaModelDefinition{
			Fields: mapFields(model.Fields),
		}
	}

	return output
}

func mapFields(input map[string]repositories.TerraformSchemaFieldDefinition) map[string]models.TerraformSchemaFieldDefinition {
	output := make(map[string]models.TerraformSchemaFieldDefinition, 0)

	for name, field := range input {
		output[name] = models.TerraformSchemaFieldDefinition{
			ObjectDefinition: mapTerraformObjectDefinition(field.ObjectDefinition),
			Computed:         field.Computed,
			ForceNew:         field.ForceNew,
			HclName:          field.HclName,
			Optional:         field.Optional,
			Required:         field.Required,
			Documentation: models.TerraformSchemaDocumentationDefinition{
				Markdown: field.Documentation.Markdown,
			},
			Validation: mapValidation(field.Validation),
		}
	}

	return output
}

func mapTerraformObjectDefinition(input repositories.TerraformSchemaFieldObjectDefinition) models.TerraformSchemaFieldObjectDefinition {
	output := models.TerraformSchemaFieldObjectDefinition{}

	if input.NestedObject != nil {
		output.NestedObject = pointer.To(mapTerraformObjectDefinition(*input.NestedObject))
	}
	output.ReferenceName = input.ReferenceName
	output.Type = models.TerraformSchemaFieldType(input.Type)

	return output
}

func mapUpdateMethod(input *repositories.MethodDefinition) *models.MethodDefinition {
	if input == nil {
		return nil
	}

	return &models.MethodDefinition{
		Generate:         input.Generate,
		MethodName:       input.MethodName,
		TimeoutInMinutes: input.TimeoutInMinutes,
	}
}

func mapValidation(input *repositories.TerraformSchemaValidationDefinition) *models.TerraformSchemaValidationDefinition {
	if input == nil {
		return nil
	}

	output := models.TerraformSchemaValidationDefinition{
		Type:           models.TerraformSchemaValidationType(input.Type),
		PossibleValues: nil,
	}

	possibleValues := models.TerraformSchemaValidationPossibleValuesDefinition{}

	if input.PossibleValues != nil {
		possibleValues.Type = models.TerraformSchemaValidationPossibleValueType(input.PossibleValues.Type)
		possibleValues.Values = input.PossibleValues.Values
	}

	return &output
}
