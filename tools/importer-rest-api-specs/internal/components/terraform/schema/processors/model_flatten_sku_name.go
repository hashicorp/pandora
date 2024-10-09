// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"fmt"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ ModelProcessor = modelFlattenSkuName{}

type modelFlattenSkuName struct{}

func (modelFlattenSkuName) ProcessModel(modelName string, model sdkModels.TerraformSchemaModel, schemaModels map[string]sdkModels.TerraformSchemaModel, mappings sdkModels.TerraformMappingDefinition) (map[string]sdkModels.TerraformSchemaModel, *sdkModels.TerraformMappingDefinition, error) {
	fields := make(map[string]sdkModels.TerraformSchemaField)
	for fieldName, fieldValue := range model.Fields {
		fields[fieldName] = fieldValue

		if strings.EqualFold(fieldName, "Sku") && fieldValue.ObjectDefinition.Type == sdkModels.ReferenceTerraformSchemaObjectDefinitionType {
			if fieldValue.ObjectDefinition.ReferenceName == nil {
				return nil, nil, fmt.Errorf("processing model %q: had no reference for field %q", modelName, fieldName)
			}
			nested, ok := schemaModels[*fieldValue.ObjectDefinition.ReferenceName]
			if !ok {
				return nil, nil, fmt.Errorf("processing model %q: no nested model was not found with name %q", modelName, *fieldValue.ObjectDefinition.ReferenceName)
			}

			if len(nested.Fields) != 1 {
				continue
			}

			nestedField, ok := nested.Fields["Name"]
			if !ok {
				continue
			}

			fieldValue.ObjectDefinition = nestedField.ObjectDefinition
			updatedName := fmt.Sprintf("%sName", fieldName)
			fields[updatedName] = fieldValue
			delete(fields, fieldName)

			// TODO: switch this mapping type out in the future
			mappings = applyFieldRenameToMappings(mappings, modelName, fieldName, updatedName)
		}
	}
	model.Fields = fields
	schemaModels[modelName] = model
	return schemaModels, &mappings, nil
}
