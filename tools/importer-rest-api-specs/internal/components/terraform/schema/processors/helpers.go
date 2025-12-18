// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func applyFieldRenameToMappings(input sdkModels.TerraformMappingDefinition, modelName string, oldFieldName string, updatedFieldName string) sdkModels.TerraformMappingDefinition {
	output := sdkModels.TerraformMappingDefinition{
		ResourceID: input.ResourceID,
	}
	for _, v := range input.Fields {
		v = applyFieldRenameToFieldMapping(v, modelName, oldFieldName, updatedFieldName)
		output.Fields = append(output.Fields, v)
	}
	return output
}

func applyFieldRenameToFieldMapping(input sdkModels.TerraformFieldMappingDefinition, modelName string, oldFieldName string, updatedFieldName string) sdkModels.TerraformFieldMappingDefinition {
	if v, ok := input.(sdkModels.TerraformDirectAssignmentFieldMappingDefinition); ok {
		if v.DirectAssignment.TerraformSchemaModelName == modelName && v.DirectAssignment.TerraformSchemaFieldName == oldFieldName {
			v.DirectAssignment.TerraformSchemaFieldName = updatedFieldName
		}
		return v
	}
	if v, ok := input.(sdkModels.TerraformModelToModelFieldMappingDefinition); ok {
		// nothing to do
		return v
	}

	panic(fmt.Sprintf("unimplemented: field rename for mapping type %T", input))
}
