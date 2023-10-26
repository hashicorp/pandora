package dataapigeneratorjson

import (
	"fmt"
	dataApiModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mapTerraformSchemaMappings(input resourcemanager.MappingDefinition) (*dataApiModels.TerraformMappingDefinition, error) {
	output := dataApiModels.TerraformMappingDefinition{}

	resourceIdMappings := make([]dataApiModels.TerraformResourceIdMapping, 0)
	for _, item := range input.ResourceId {
		mapping := dataApiModels.TerraformResourceIdMapping{
			SchemaFieldName:    item.SchemaFieldName,
			SegmentName:        item.SegmentName,
			ParsedFromParentId: item.ParsedFromParentID,
		}

		resourceIdMappings = append(resourceIdMappings, mapping)
	}
	if len(resourceIdMappings) > 0 {
		output.ResourceIdMapping = &resourceIdMappings
	}

	directAssignmentFieldMappings := make([]dataApiModels.TerraformDirectAssignmentMappings, 0)
	modelToModelAssignmentFieldMappings := make([]dataApiModels.TerraformModelToModelMappings, 0)
	for _, item := range input.Fields {
		switch item.Type {
		// TODO: BooleanEquals etc
		case resourcemanager.DirectAssignmentMappingDefinitionType:
			{
				directAssignmentFieldMapping := dataApiModels.TerraformDirectAssignmentMappings{
					SchemaModelName: item.DirectAssignment.SchemaModelName,
					SchemaFieldPath: item.DirectAssignment.SchemaFieldPath,
					SdkModelName:    item.DirectAssignment.SdkModelName,
					SdkFieldPath:    item.DirectAssignment.SdkFieldPath,
				}
				directAssignmentFieldMappings = append(directAssignmentFieldMappings, directAssignmentFieldMapping)
			}
		case resourcemanager.ModelToModelMappingDefinitionType:
			{
				modelToModelAssignmentFieldMapping := dataApiModels.TerraformModelToModelMappings{
					SchemaModelName: item.ModelToModel.SchemaModelName,
					SdkModelName:    item.ModelToModel.SdkModelName,
					SdkFieldName:    item.ModelToModel.SdkFieldName,
				}
				modelToModelAssignmentFieldMappings = append(modelToModelAssignmentFieldMappings, modelToModelAssignmentFieldMapping)
			}

		default:
			{
				return nil, fmt.Errorf("internal-error: unimplemented MappingDefinitionType %q", string(item.Type))
			}
		}
	}

	if len(directAssignmentFieldMappings) > 0 {
		output.DirectAssignmentMappings = &directAssignmentFieldMappings
	}
	if len(modelToModelAssignmentFieldMappings) > 0 {
		output.ModelToModelMappings = &modelToModelAssignmentFieldMappings
	}

	return &output, nil
}
