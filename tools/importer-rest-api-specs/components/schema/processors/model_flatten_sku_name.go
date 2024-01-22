// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ ModelProcessor = modelFlattenSkuName{}

type modelFlattenSkuName struct{}

func (modelFlattenSkuName) ProcessModel(modelName string, model resourcemanager.TerraformSchemaModelDefinition, models map[string]resourcemanager.TerraformSchemaModelDefinition, mappings resourcemanager.MappingDefinition) (*map[string]resourcemanager.TerraformSchemaModelDefinition, *resourcemanager.MappingDefinition, error) {
	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
	for fieldName, fieldValue := range model.Fields {
		fields[fieldName] = fieldValue

		if strings.EqualFold(fieldName, "Sku") && fieldValue.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
			if fieldValue.ObjectDefinition.ReferenceName == nil {
				return nil, nil, fmt.Errorf("processing model %q: had no reference for field %q", modelName, fieldName)
			}
			nested, ok := models[*fieldValue.ObjectDefinition.ReferenceName]
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
	models[modelName] = model
	return &models, &mappings, nil
}
