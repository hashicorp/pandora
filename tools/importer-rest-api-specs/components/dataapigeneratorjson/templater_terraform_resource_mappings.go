package dataapigeneratorjson

import (
	"encoding/json"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ResourceMapping struct {
	ResourceIdMapping             *[]ResourceIdMapping            `json:"ResourceIdMapping,omitempty"`
	DirectAssignmentFieldMappings *[]DirectAssignmentFieldMapping `json:"DirectAssignmentFieldMappings,omitempty"`
	ModelToModelFieldMappings     *[]ModelToModelFieldMapping     `json:"ModelToModelFieldMappings,omitempty"`
}

type ResourceIdMapping struct {
	SchemaFieldName    string `json:"SchemaFieldName"`
	SegmentName        string `json:"SegmentName"`
	ParsedFromParentID bool   `json:"ParsedFromParentID"`
}

type DirectAssignmentFieldMapping struct {
	SchemaModelName string `json:"SchemaModelName"`
	SchemaFieldPath string `json:"SchemaFieldPath"`
	SdkModelName    string `json:"SdkModelName"`
	SdkFieldPath    string `json:"SdkFieldPath"`
}

type ModelToModelFieldMapping struct {
	SchemaModelName string `json:"SchemaModelName"`
	SdkModelName    string `json:"SdkModelName"`
	SdkFieldName    string `json:"SdkFieldName"`
}

func codeForTerraformResourceMappings(details resourcemanager.TerraformResourceDetails) ([]byte, error) {
	resourceMapping := ResourceMapping{}

	resourceIdMappings := make([]ResourceIdMapping, 0)
	for _, item := range details.Mappings.ResourceId {
		mapping := ResourceIdMapping{
			SchemaFieldName:    item.SchemaFieldName,
			SegmentName:        item.SegmentName,
			ParsedFromParentID: item.ParsedFromParentID,
		}

		resourceIdMappings = append(resourceIdMappings, mapping)
	}
	if len(resourceIdMappings) > 0 {
		resourceMapping.ResourceIdMapping = &resourceIdMappings
	}

	directAssignmentFieldMappings := make([]DirectAssignmentFieldMapping, 0)
	modelToModelAssignmentFieldMappings := make([]ModelToModelFieldMapping, 0)
	for _, item := range details.Mappings.Fields {
		switch item.Type {
		// TODO: BooleanEquals etc
		case resourcemanager.DirectAssignmentMappingDefinitionType:
			{
				directAssignmentFieldMapping := DirectAssignmentFieldMapping{
					SchemaModelName: item.DirectAssignment.SchemaModelName,
					SchemaFieldPath: item.DirectAssignment.SchemaFieldPath,
					SdkModelName:    item.DirectAssignment.SdkModelName,
					SdkFieldPath:    item.DirectAssignment.SdkFieldPath,
				}
				directAssignmentFieldMappings = append(directAssignmentFieldMappings, directAssignmentFieldMapping)
			}
		case resourcemanager.ModelToModelMappingDefinitionType:
			{
				modelToModelAssignmentFieldMapping := ModelToModelFieldMapping{
					SchemaModelName: item.ModelToModel.SchemaModelName,
					SdkModelName:    item.ModelToModel.SdkModelName,
					SdkFieldName:    item.ModelToModel.SdkFieldName,
				}
				modelToModelAssignmentFieldMappings = append(modelToModelAssignmentFieldMappings, modelToModelAssignmentFieldMapping)
			}
		}
	}

	if len(directAssignmentFieldMappings) > 0 {
		resourceMapping.DirectAssignmentFieldMappings = &directAssignmentFieldMappings
	}

	if len(modelToModelAssignmentFieldMappings) > 0 {
		resourceMapping.ModelToModelFieldMappings = &modelToModelAssignmentFieldMappings
	}

	data, err := json.MarshalIndent(resourceMapping, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}
