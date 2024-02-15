package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func mapTerraformSchemaMappings(input repositories.MappingDefinition) (*models.TerraformMappingDefinition, error) {
	mappedFieldMappings, err := mapTerraformSchemaFieldMappings(input.Fields)
	if err != nil {
		return nil, fmt.Errorf("mapping TerraformSchemaFieldMappings: %+v", err)
	}

	mappedModelToModelMappings := mapTerraformSchemaModelToModelMappings(input.ModelToModels)
	mappedResourceIDMappings := mapTerraformSchemaResourceIDMappings(input.ResourceId)
	return &models.TerraformMappingDefinition{
		Fields:        *mappedFieldMappings,
		ModelToModels: mappedModelToModelMappings,
		ResourceID:    mappedResourceIDMappings,
	}, nil
}

func mapTerraformSchemaFieldMappings(input []repositories.FieldMappingDefinition) (*[]models.TerraformFieldMappingDefinition, error) {
	output := make([]models.TerraformFieldMappingDefinition, 0)
	for _, item := range input {
		if item.Type == repositories.DirectAssignmentTerraformFieldMappingDefinitionType {
			output = append(output, models.TerraformDirectAssignmentFieldMappingDefinition{
				DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
					TerraformSchemaModelName: item.DirectAssignment.SchemaModelName,
					TerraformSchemaFieldName: item.DirectAssignment.SchemaFieldPath,
					SDKModelName:             item.DirectAssignment.SdkModelName,
					SDKFieldName:             item.DirectAssignment.SdkFieldPath,
				},
			})
			continue
		}

		if item.Type == repositories.ModelToModelTerraformFieldMappingDefinitionType {
			output = append(output, models.TerraformModelToModelFieldMappingDefinition{
				ModelToModel: models.TerraformModelToModelFieldMappingDefinitionImpl{
					TerraformSchemaModelName: item.ModelToModel.SchemaModelName,
					SDKModelName:             item.ModelToModel.SdkModelName,
					SDKFieldName:             item.ModelToModel.SdkFieldName,
				},
			})
			continue
		}

		return nil, fmt.Errorf("internal-error: missing mapping for FieldMappingDefinitionType %q", string(item.Type))
	}

	return &output, nil
}

func mapTerraformSchemaModelToModelMappings(input []repositories.ModelToModelMappingDefinition) []models.TerraformModelToModelMappingDefinition {
	output := make([]models.TerraformModelToModelMappingDefinition, 0)

	for _, item := range input {
		output = append(output, models.TerraformModelToModelMappingDefinition{
			SDKModelName:             item.SdkModelName,
			TerraformSchemaModelName: item.SchemaModelName,
		})
	}

	return output
}

func mapTerraformSchemaResourceIDMappings(input []repositories.ResourceIdMappingDefinition) []models.TerraformResourceIDMappingDefinition {
	output := make([]models.TerraformResourceIDMappingDefinition, 0)
	for _, item := range input {
		output = append(output, models.TerraformResourceIDMappingDefinition{
			ParsedFromParentID:       item.ParsedFromParentID,
			SegmentName:              item.SegmentName,
			TerraformSchemaFieldName: item.SchemaFieldName,
		})
	}
	return output
}
