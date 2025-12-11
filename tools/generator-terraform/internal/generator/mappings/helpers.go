// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// TODO: tests

func FindMappingsBetween(input models.TerraformModelToModelMappingDefinition, mappings []models.TerraformFieldMappingDefinition) (*[]models.TerraformFieldMappingDefinition, error) {
	output := make([]models.TerraformFieldMappingDefinition, 0)

	for _, item := range mappings {
		if v, ok := item.(models.TerraformDirectAssignmentFieldMappingDefinition); ok {
			if v.DirectAssignment.TerraformSchemaModelName == input.TerraformSchemaModelName && v.DirectAssignment.SDKModelName == input.SDKModelName {
				output = append(output, v)
			}
			continue
		}

		if v, ok := item.(models.TerraformModelToModelFieldMappingDefinition); ok {
			if v.ModelToModel.TerraformSchemaModelName == input.TerraformSchemaModelName && v.ModelToModel.SDKModelName == input.SDKModelName {
				output = append(output, item)
			}
			continue
		}

		return nil, fmt.Errorf("internal-error: unimplemented mapping type %+v", item)
	}

	return &output, nil
}
