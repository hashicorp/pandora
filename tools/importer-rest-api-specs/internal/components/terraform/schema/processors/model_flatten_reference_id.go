// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"fmt"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ ModelProcessor = modelFlattenReferenceId{}

type modelFlattenReferenceId struct{}

func (modelFlattenReferenceId) ProcessModel(modelName string, model sdkModels.TerraformSchemaModel, schemaModels map[string]sdkModels.TerraformSchemaModel, mappings sdkModels.TerraformMappingDefinition) (map[string]sdkModels.TerraformSchemaModel, *sdkModels.TerraformMappingDefinition, error) {
	fields := make(map[string]sdkModels.TerraformSchemaField)

	for fieldName, fieldValue := range model.Fields {
		fields[fieldName] = fieldValue

		if strings.EqualFold(fieldName, "Id") && len(model.Fields) > 1 {
			continue
		}

		if fieldValue.ObjectDefinition.Type != sdkModels.ReferenceTerraformSchemaObjectDefinitionType {
			continue
		}

		if fieldValue.ObjectDefinition.ReferenceName == nil {
			return nil, nil, fmt.Errorf("processing model %q: field %q was a reference with no reference name", modelName, fieldName)
		}

		// NOTE: at this point Constants will have been transformed to a String so this *will* be a Model
		nestedModel, ok := schemaModels[*fieldValue.ObjectDefinition.ReferenceName]
		if !ok {
			return nil, nil, fmt.Errorf("processing model %q: field %q had a reference to %q but it wasn't found", modelName, fieldName, *fieldValue.ObjectDefinition.ReferenceName)
		}

		if len(nestedModel.Fields) != 1 {
			continue
		}

		nestedField, ok := nestedModel.Fields["Id"]
		if !ok {
			continue
		}

		fieldValue.ObjectDefinition = nestedField.ObjectDefinition
		updatedName := fmt.Sprintf("%sId", fieldName)
		fields[updatedName] = fieldValue
		delete(fields, fieldName)

		// TODO: switch this mapping type out in the future
		mappings = applyFieldRenameToMappings(mappings, modelName, fieldName, updatedName)
	}
	model.Fields = fields
	schemaModels[modelName] = model
	return schemaModels, &mappings, nil
}
