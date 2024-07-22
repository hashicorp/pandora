// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ ModelProcessor = modelFlattenListReferenceIds{}

type modelFlattenListReferenceIds struct{}

func (modelFlattenListReferenceIds) ProcessModel(modelName string, model sdkModels.TerraformSchemaModel, schemaModels map[string]sdkModels.TerraformSchemaModel, mappings sdkModels.TerraformMappingDefinition) (map[string]sdkModels.TerraformSchemaModel, *sdkModels.TerraformMappingDefinition, error) {
	if len(model.Fields) != 1 {
		return schemaModels, &mappings, nil
	}

	fields := make(map[string]sdkModels.TerraformSchemaField)
	for fieldName, fieldValue := range model.Fields {
		fields[fieldName] = fieldValue

		// the ObjectDefinition for a List to a Reference will be:
		// ObjectDefinition Type: List (no reference name) with a NestedObject
		// of ObjectDefinition Type: Reference (and a reference name)
		if fieldValue.ObjectDefinition.Type != sdkModels.ListTerraformSchemaObjectDefinitionType {
			continue
		}

		referenceName := ""
		if nested := fieldValue.ObjectDefinition.NestedObject; nested != nil {
			if nested.Type != sdkModels.ReferenceTerraformSchemaObjectDefinitionType {
				continue
			}
			if nested.Type == sdkModels.ReferenceTerraformSchemaObjectDefinitionType && nested.ReferenceName != nil {
				referenceName = *nested.ReferenceName
			}
		}
		if referenceName == "" {
			return nil, nil, fmt.Errorf("processing model %q: nested list had no reference for field %q", modelName, fieldName)
		}

		// NOTE: at this point Constants will have been transformed to a String so this *will* be a Model
		nestedModel, ok := schemaModels[referenceName]
		if !ok {
			return nil, nil, fmt.Errorf("processing %q: nested model with reference name %q was not found for field %q", modelName, referenceName, fieldName)
		}

		if len(nestedModel.Fields) != 1 {
			continue
		}

		nestedField, ok := nestedModel.Fields["Ids"]
		if !ok {
			continue
		}

		fieldValue.ObjectDefinition = nestedField.ObjectDefinition
		updatedName := fmt.Sprintf("%sIds", fieldName)
		fields[updatedName] = fieldValue
		delete(fields, fieldName)

		// TODO: switch this mapping type out in the future
		mappings = applyFieldRenameToMappings(mappings, modelName, fieldName, updatedName)
	}
	model.Fields = fields
	schemaModels[modelName] = model
	return schemaModels, &mappings, nil
}
