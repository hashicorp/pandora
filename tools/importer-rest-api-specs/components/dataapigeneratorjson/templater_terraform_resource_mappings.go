package dataapigeneratorjson

import (
	"encoding/json"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTerraformResourceMappings(details resourcemanager.TerraformResourceDetails) ([]byte, error) {
	resourceMapping := models.TerraformResourceMappingDefinition{}

	resourceIdMappings := make([]models.TerraformResourceIdMapping, 0)
	for _, item := range details.Mappings.ResourceId {
		mapping := models.TerraformResourceIdMapping{
			SchemaFieldName:    item.SchemaFieldName,
			SegmentName:        item.SegmentName,
			ParsedFromParentID: item.ParsedFromParentID,
		}

		resourceIdMappings = append(resourceIdMappings, mapping)
	}
	if len(resourceIdMappings) > 0 {
		resourceMapping.ResourceIdMapping = &resourceIdMappings
	}

	directAssignmentFieldMappings := make([]models.TerraformDirectAssignmentMappings, 0)
	modelToModelAssignmentFieldMappings := make([]models.TerraformModelToModelMappings, 0)
	for _, item := range details.Mappings.Fields {
		switch item.Type {
		// TODO: BooleanEquals etc
		case resourcemanager.DirectAssignmentMappingDefinitionType:
			{
				directAssignmentFieldMapping := models.TerraformDirectAssignmentMappings{
					SchemaModelName: item.DirectAssignment.SchemaModelName,
					SchemaFieldPath: item.DirectAssignment.SchemaFieldPath,
					SdkModelName:    item.DirectAssignment.SdkModelName,
					SdkFieldPath:    item.DirectAssignment.SdkFieldPath,
				}
				directAssignmentFieldMappings = append(directAssignmentFieldMappings, directAssignmentFieldMapping)
			}
		case resourcemanager.ModelToModelMappingDefinitionType:
			{
				modelToModelAssignmentFieldMapping := models.TerraformModelToModelMappings{
					SchemaModelName: item.ModelToModel.SchemaModelName,
					SdkModelName:    item.ModelToModel.SdkModelName,
					SdkFieldName:    item.ModelToModel.SdkFieldName,
				}
				modelToModelAssignmentFieldMappings = append(modelToModelAssignmentFieldMappings, modelToModelAssignmentFieldMapping)
			}
		}
	}

	if len(directAssignmentFieldMappings) > 0 {
		resourceMapping.DirectAssignmentMappings = &directAssignmentFieldMappings
	}

	if len(modelToModelAssignmentFieldMappings) > 0 {
		resourceMapping.ModelToModelMappings = &modelToModelAssignmentFieldMappings
	}

	data, err := json.MarshalIndent(resourceMapping, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}
