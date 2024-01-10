package v1

import (
	"fmt"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func mapSchemaModels(input *map[string]repositories.TerraformSchemaModelDefinition) (map[string]models.TerraformSchemaModelDefinition, error) {
	if input == nil {
		return nil, nil
	}

	output := make(map[string]models.TerraformSchemaModelDefinition, 0)

	for name, model := range *input {
		var modelDefinition models.TerraformSchemaModelDefinition

		fields, err := mapFields(model.Fields)
		if err != nil {
			return nil, fmt.Errorf("mapping fields for %s: %+v", name, err)
		}
		modelDefinition.Fields = fields

		output[name] = modelDefinition
	}

	return output, nil
}

func mapFields(input map[string]repositories.TerraformSchemaFieldDefinition) (map[string]models.TerraformSchemaFieldDefinition, error) {
	output := make(map[string]models.TerraformSchemaFieldDefinition, 0)

	for name, field := range input {
		fieldDefinition := models.TerraformSchemaFieldDefinition{
			Computed: field.Computed,
			ForceNew: field.ForceNew,
			HclName:  field.HclName,
			Optional: field.Optional,
			Required: field.Required,
			Documentation: models.TerraformSchemaDocumentationDefinition{
				Markdown: field.Documentation.Markdown,
			},
			Validation: mapValidation(field.Validation),
		}

		objectDefinition, err := mapTerraformObjectDefinition(field.ObjectDefinition)
		if err != nil {
			return output, fmt.Errorf("mapping object definition for %s: %+v", name, err)
		}
		fieldDefinition.ObjectDefinition = objectDefinition

		output[name] = fieldDefinition
	}

	return output, nil
}

var terraformSchemaObjectDefinitionToTerraformFieldSchemaTypes = map[repositories.TerraformSchemaFieldType]models.TerraformSchemaFieldType{
	repositories.BooleanTerraformSchemaObjectDefinitionType:                       models.TerraformSchemaFieldTypeBoolean,
	repositories.DateTimeTerraformSchemaObjectDefinitionType:                      models.TerraformSchemaFieldTypeDateTime,
	repositories.DictionaryTerraformSchemaObjectDefinitionType:                    models.TerraformSchemaFieldTypeDictionary,
	repositories.EdgeZoneTerraformSchemaObjectDefinitionType:                      models.TerraformSchemaFieldTypeEdgeZone,
	repositories.SystemAssignedIdentityTerraformSchemaObjectDefinitionType:        models.TerraformSchemaFieldTypeIdentitySystemAssigned,
	repositories.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType: models.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
	repositories.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType:  models.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
	repositories.UserAssignedIdentityTerraformSchemaObjectDefinitionType:          models.TerraformSchemaFieldTypeIdentityUserAssigned,
	repositories.LocationTerraformSchemaObjectDefinitionType:                      models.TerraformSchemaFieldTypeLocation,
	repositories.FloatTerraformSchemaObjectDefinitionType:                         models.TerraformSchemaFieldTypeFloat,
	repositories.IntegerTerraformSchemaObjectDefinitionType:                       models.TerraformSchemaFieldTypeInteger,
	repositories.ListTerraformSchemaObjectDefinitionType:                          models.TerraformSchemaFieldTypeList,
	repositories.ReferenceTerraformSchemaObjectDefinitionType:                     models.TerraformSchemaFieldTypeReference,
	repositories.ResourceGroupTerraformSchemaObjectDefinitionType:                 models.TerraformSchemaFieldTypeResourceGroup,
	repositories.SetTerraformSchemaObjectDefinitionType:                           models.TerraformSchemaFieldTypeSet,
	repositories.StringTerraformSchemaFieldType:                                   models.TerraformSchemaFieldTypeString,
	repositories.TagsTerraformSchemaObjectDefinitionType:                          models.TerraformSchemaFieldTypeTags,
	repositories.SkuTerraformSchemaObjectDefinitionType:                           models.TerraformSchemaFieldTypeSku,
	repositories.ZoneTerraformSchemaObjectDefinitionType:                          models.TerraformSchemaFieldTypeZone,
	repositories.ZonesTerraformSchemaObjectDefinitionType:                         models.TerraformSchemaFieldTypeZones,
}

func mapTerraformObjectDefinition(input repositories.TerraformSchemaFieldObjectDefinition) (models.TerraformSchemaFieldObjectDefinition, error) {
	output := models.TerraformSchemaFieldObjectDefinition{}

	if input.NestedObject != nil {
		nestedObject, err := mapTerraformObjectDefinition(*input.NestedObject)
		if err != nil {
			return output, err
		}
		output.NestedObject = pointer.To(nestedObject)
	}
	output.ReferenceName = input.ReferenceName
	output.Type = models.TerraformSchemaFieldType(input.Type)

	mapped, ok := terraformSchemaObjectDefinitionToTerraformFieldSchemaTypes[input.Type]
	if !ok {
		return output, fmt.Errorf("internal-error: missing mapping for Terraform Schema Field Type %q", string(input.Type))
	}
	output.Type = mapped

	return output, nil
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

func mapMappings(input repositories.MappingDefinition) models.MappingDefinition {
	var output models.MappingDefinition

	fieldMappings := make([]models.FieldMappingDefinition, 0)
	for _, field := range input.Fields {
		fieldMapping := models.FieldMappingDefinition{
			Type: models.MappingDefinitionType(field.Type),
		}

		if field.DirectAssignment != nil {
			fieldMapping.DirectAssignment = &models.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: field.DirectAssignment.SchemaModelName,
				SchemaFieldPath: field.DirectAssignment.SchemaFieldPath,
				SdkModelName:    field.DirectAssignment.SdkModelName,
				SdkFieldPath:    field.DirectAssignment.SdkFieldPath,
			}
		}

		if field.ModelToModel != nil {
			fieldMapping.ModelToModel = &models.FieldMappingModelToModelDefinition{
				SchemaModelName: field.ModelToModel.SchemaModelName,
				SdkModelName:    field.ModelToModel.SdkModelName,
				SdkFieldName:    field.ModelToModel.SdkFieldName,
			}
		}

		if field.Manual != nil {
			fieldMapping.Manual = &models.FieldManualMappingDefinition{
				MethodName: field.Manual.MethodName,
			}
		}

		fieldMappings = append(fieldMappings, fieldMapping)
	}
	output.Fields = fieldMappings

	if input.ResourceId != nil {
		resourceIds := make([]models.ResourceIdMappingDefinition, 0)
		for _, id := range input.ResourceId {
			resourceIds = append(resourceIds, models.ResourceIdMappingDefinition{
				SchemaFieldName:    id.SchemaFieldName,
				SegmentName:        id.SegmentName,
				ParsedFromParentID: id.ParsedFromParentID,
			})
		}

		output.ResourceId = resourceIds
	}

	if input.ModelToModels != nil {
		modelToModels := make([]models.ModelToModelMappingDefinition, 0)
		for _, modelToModelMapping := range input.ModelToModels {
			modelToModels = append(modelToModels, models.ModelToModelMappingDefinition{
				SchemaModelName: modelToModelMapping.SchemaModelName,
				SdkModelName:    modelToModelMapping.SdkModelName,
			})
		}

		output.ModelToModels = modelToModels
	}

	return output
}
