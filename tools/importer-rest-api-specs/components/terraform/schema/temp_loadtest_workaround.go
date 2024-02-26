// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func applyTemporaryWorkaroundToLoadTestModelsAndMappings(models map[string]models.SDKModel, mappings *resourcemanager.MappingDefinition) (*map[string]models.SDKModel, *resourcemanager.MappingDefinition, error) {

	// 1: remove the `Encryption` field within the `LoadTestProperties` model
	loadTestProps, ok := models["LoadTestProperties"]
	if !ok {
		return nil, nil, fmt.Errorf("the model `LoadTestProperties` was not found")
	}
	delete(loadTestProps.Fields, "Encryption")
	models["LoadTestProperties"] = loadTestProps

	// 2. delete the nested models
	delete(models, "EncryptionProperties")
	delete(models, "EncryptionPropertiesIdentity")

	// 3: remove the associated DirectAssignment and ModelToModel mappings
	// NOTE: the unused mappings cleanup will remove the nested `EncryptionProperties` and `EncryptionPropertiesIdentity` models
	// we're intentionally not doing that here incase the model names change
	updatedFieldMappings := make([]resourcemanager.FieldMappingDefinition, 0)
	for _, item := range mappings.Fields {
		if item.Type == resourcemanager.DirectAssignmentMappingDefinitionType {
			if item.DirectAssignment.SchemaModelName == "LoadTestResource" && item.DirectAssignment.SchemaFieldPath == "Encryption" {
				continue
			}
		}

		if item.Type == resourcemanager.ModelToModelMappingDefinitionType {
			if item.ModelToModel.SchemaModelName == "LoadTestResourceEncryptionProperties" {
				continue
			}
		}

		updatedFieldMappings = append(updatedFieldMappings, item)
	}
	mappings.Fields = updatedFieldMappings

	return &models, mappings, nil
}
