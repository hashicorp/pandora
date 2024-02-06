// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func mapSchemaModels(input map[string]repositories.TerraformSchemaModelDefinition) (*map[string]models.TerraformSchemaModelDefinition, error) {
	output := make(map[string]models.TerraformSchemaModelDefinition)

	for name, model := range input {
		fields, err := mapFields(model.Fields)
		if err != nil {
			return nil, fmt.Errorf("mapping fields for %s: %+v", name, err)
		}

		output[name] = models.TerraformSchemaModelDefinition{
			Fields: *fields,
		}
	}

	return &output, nil
}

func mapFields(input map[string]repositories.TerraformSchemaFieldDefinition) (*map[string]models.TerraformSchemaFieldDefinition, error) {
	output := make(map[string]models.TerraformSchemaFieldDefinition)

	for name, field := range input {
		objectDefinition, err := mapTerraformObjectDefinition(field.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("mapping object definition for %q: %+v", name, err)
		}
		validation, err := mapValidation(field.Validation)
		if err != nil {
			return nil, fmt.Errorf("mapping validation for %q: %+v", name, err)
		}

		output[name] = models.TerraformSchemaFieldDefinition{
			Computed:         field.Computed,
			ForceNew:         field.ForceNew,
			HclName:          field.HclName,
			Optional:         field.Optional,
			ObjectDefinition: *objectDefinition,
			Required:         field.Required,
			Documentation: models.TerraformSchemaDocumentationDefinition{
				Markdown: field.Documentation.Markdown,
			},
			Validation: validation,
		}
	}

	return &output, nil
}

var terraformSchemaObjectDefinitionToTerraformFieldSchemaTypes = map[repositories.TerraformSchemaFieldType]models.TerraformSchemaFieldType{
	repositories.BooleanTerraformSchemaObjectDefinitionType:                       models.TerraformSchemaFieldTypeBoolean,
	repositories.DateTimeTerraformSchemaObjectDefinitionType:                      models.TerraformSchemaFieldTypeDateTime,
	repositories.DictionaryTerraformSchemaObjectDefinitionType:                    models.TerraformSchemaFieldTypeDictionary,
	repositories.EdgeZoneTerraformSchemaObjectDefinitionType:                      models.TerraformSchemaFieldTypeEdgeZone,
	repositories.FloatTerraformSchemaObjectDefinitionType:                         models.TerraformSchemaFieldTypeFloat,
	repositories.IntegerTerraformSchemaObjectDefinitionType:                       models.TerraformSchemaFieldTypeInteger,
	repositories.ListTerraformSchemaObjectDefinitionType:                          models.TerraformSchemaFieldTypeList,
	repositories.LocationTerraformSchemaObjectDefinitionType:                      models.TerraformSchemaFieldTypeLocation,
	repositories.ReferenceTerraformSchemaObjectDefinitionType:                     models.TerraformSchemaFieldTypeReference,
	repositories.ResourceGroupTerraformSchemaObjectDefinitionType:                 models.TerraformSchemaFieldTypeResourceGroup,
	repositories.SetTerraformSchemaObjectDefinitionType:                           models.TerraformSchemaFieldTypeSet,
	repositories.SkuTerraformSchemaObjectDefinitionType:                           models.TerraformSchemaFieldTypeSku,
	repositories.StringTerraformSchemaObjectDefinitionType:                        models.TerraformSchemaFieldTypeString,
	repositories.SystemAssignedIdentityTerraformSchemaObjectDefinitionType:        models.TerraformSchemaFieldTypeIdentitySystemAssigned,
	repositories.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType: models.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
	repositories.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType:  models.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
	repositories.TagsTerraformSchemaObjectDefinitionType:                          models.TerraformSchemaFieldTypeTags,
	repositories.UserAssignedIdentityTerraformSchemaObjectDefinitionType:          models.TerraformSchemaFieldTypeIdentityUserAssigned,
	repositories.ZoneTerraformSchemaObjectDefinitionType:                          models.TerraformSchemaFieldTypeZone,
	repositories.ZonesTerraformSchemaObjectDefinitionType:                         models.TerraformSchemaFieldTypeZones,
}

func mapTerraformObjectDefinition(input repositories.TerraformSchemaFieldObjectDefinition) (*models.TerraformSchemaFieldObjectDefinition, error) {
	output := models.TerraformSchemaFieldObjectDefinition{}

	if input.NestedObject != nil {
		nestedObject, err := mapTerraformObjectDefinition(*input.NestedObject)
		if err != nil {
			return nil, err
		}
		output.NestedObject = nestedObject
	}
	output.ReferenceName = input.ReferenceName

	mapped, ok := terraformSchemaObjectDefinitionToTerraformFieldSchemaTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Terraform Schema Field Type %q", string(input.Type))
	}
	output.Type = mapped

	return &output, nil
}

func mapMethodDefinition(input repositories.MethodDefinition) models.MethodDefinition {
	return models.MethodDefinition{
		Generate:         input.Generate,
		MethodName:       input.MethodName,
		TimeoutInMinutes: input.TimeoutInMinutes,
	}
}

var repositoryToApiResponseTerraformSchemaValidationType = map[repositories.TerraformSchemaValidationType]models.TerraformSchemaValidationType{
	repositories.PossibleValuesTerraformSchemaValidationType: models.TerraformSchemaValidationTypePossibleValues,
}

var repositoryToApiResponseTerraformSchemaValidationPossibleValueType = map[repositories.TerraformSchemaValidationPossibleValueType]models.TerraformSchemaValidationPossibleValueType{
	repositories.TerraformSchemaValidationPossibleValueTypeInt:    models.TerraformSchemaValidationPossibleValueTypeInt,
	repositories.TerraformSchemaValidationPossibleValueTypeFloat:  models.TerraformSchemaValidationPossibleValueTypeFloat,
	repositories.TerraformSchemaValidationPossibleValueTypeString: models.TerraformSchemaValidationPossibleValueTypeString,
}

func mapValidation(input *repositories.TerraformSchemaValidationDefinition) (*models.TerraformSchemaValidationDefinition, error) {
	if input == nil {
		return nil, nil
	}

	typeVal, ok := repositoryToApiResponseTerraformSchemaValidationType[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for `TerraformSchemaValidationType` %q", string(input.Type))
	}

	output := models.TerraformSchemaValidationDefinition{
		Type:           typeVal,
		PossibleValues: nil,
	}

	if input.PossibleValues != nil {
		possibleTypesVal, ok := repositoryToApiResponseTerraformSchemaValidationPossibleValueType[input.PossibleValues.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing mapping for `TerraformSchemaValidationPossibleValueType` %q", string(input.PossibleValues.Type))
		}

		output.PossibleValues = &models.TerraformSchemaValidationPossibleValuesDefinition{
			Type:   possibleTypesVal,
			Values: input.PossibleValues.Values,
		}
	}

	return &output, nil
}

var repositoryToApiResourceFieldMappingDefinitionType = map[repositories.MappingDefinitionType]models.MappingDefinitionType{
	repositories.DirectAssignmentTerraformFieldMappingDefinitionType: models.DirectAssignmentMappingDefinitionType,
	repositories.ModelToModelTerraformFieldMappingDefinitionType:     models.ModelToModelMappingDefinitionType,
	repositories.ManualTerraformFieldMappingDefinitionType:           models.ManualMappingDefinitionType,
}

func mapMappings(input repositories.MappingDefinition) (*models.MappingDefinition, error) {
	output := models.MappingDefinition{
		Fields:        make([]models.FieldMappingDefinition, 0),
		ModelToModels: make([]models.ModelToModelMappingDefinition, 0),
		ResourceId:    make([]models.ResourceIdMappingDefinition, 0),
	}

	for _, field := range input.Fields {
		mappingType, ok := repositoryToApiResourceFieldMappingDefinitionType[field.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing mapping for `MappingDefinitionType` %q", string(field.Type))
		}

		fieldMapping := models.FieldMappingDefinition{
			Type: mappingType,
		}

		if field.DirectAssignment != nil {
			fieldMapping.DirectAssignment = &models.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: field.DirectAssignment.SchemaModelName,
				SchemaFieldPath: field.DirectAssignment.SchemaFieldPath,
				SdkModelName:    field.DirectAssignment.SdkModelName,
				SdkFieldPath:    field.DirectAssignment.SdkFieldPath,
			}
			output.Fields = append(output.Fields, fieldMapping)
			continue
		}

		if field.ModelToModel != nil {
			fieldMapping.ModelToModel = &models.FieldMappingModelToModelDefinition{
				SchemaModelName: field.ModelToModel.SchemaModelName,
				SdkModelName:    field.ModelToModel.SdkModelName,
				SdkFieldName:    field.ModelToModel.SdkFieldName,
			}
			output.Fields = append(output.Fields, fieldMapping)
			continue
		}

		if field.Manual != nil {
			fieldMapping.Manual = &models.FieldManualMappingDefinition{
				MethodName: field.Manual.MethodName,
			}
			output.Fields = append(output.Fields, fieldMapping)
			continue
		}

		return nil, fmt.Errorf("internal-error: unimplemented mapping type %q", string(field.Type))
	}

	if input.ResourceId != nil {
		for _, id := range input.ResourceId {
			output.ResourceId = append(output.ResourceId, models.ResourceIdMappingDefinition{
				SchemaFieldName:    id.SchemaFieldName,
				SegmentName:        id.SegmentName,
				ParsedFromParentID: id.ParsedFromParentID,
			})
		}
	}

	if input.ModelToModels != nil {
		for _, modelToModelMapping := range input.ModelToModels {
			output.ModelToModels = append(output.ModelToModels, models.ModelToModelMappingDefinition{
				SchemaModelName: modelToModelMapping.SchemaModelName,
				SdkModelName:    modelToModelMapping.SdkModelName,
			})
		}
	}

	return &output, nil
}
