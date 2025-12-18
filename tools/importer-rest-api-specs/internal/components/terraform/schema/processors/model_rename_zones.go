// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"fmt"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ ModelProcessor = modelRenameZones{}

type modelRenameZones struct{}

func (modelRenameZones) ProcessModel(modelName string, model sdkModels.TerraformSchemaModel, schemaModels map[string]sdkModels.TerraformSchemaModel, mappings sdkModels.TerraformMappingDefinition) (map[string]sdkModels.TerraformSchemaModel, *sdkModels.TerraformMappingDefinition, error) {
	fields := make(map[string]sdkModels.TerraformSchemaField)
	for fieldName, fieldValue := range model.Fields {
		fields[fieldName] = fieldValue

		if strings.EqualFold(fieldName, "AvailabilityZones") && fieldValue.ObjectDefinition.Type == sdkModels.ListTerraformSchemaObjectDefinitionType {
			if fieldValue.ObjectDefinition.NestedObject.Type == sdkModels.StringTerraformSchemaObjectDefinitionType {
				oldName := fieldName
				delete(fields, oldName)

				fieldName = fmt.Sprint("Zones")
				fields[fieldName] = fieldValue

				// also go through and replace the mapping
				mappings = applyFieldRenameToMappings(mappings, modelName, oldName, fieldName)
			}
		}

		if strings.EqualFold(fieldName, "AvailabilityZone") && fieldValue.ObjectDefinition.Type == sdkModels.StringTerraformSchemaObjectDefinitionType {
			oldName := fieldName
			delete(fields, oldName)

			fieldName = fmt.Sprint("Zone")
			fields[fieldName] = fieldValue

			// also go through and replace the mapping
			mappings = applyFieldRenameToMappings(mappings, modelName, fieldName, fieldName)
		}

		// Whilst Zones shouldn't be present within nested models (per the ARM Spec) - some APIs do it anyway.
		// as such we now look at the updated field name and type and switch out the ObjectDefinition
		// to use the Zone/s custom type as needed.
		if strings.EqualFold(fieldName, "Zone") {
			if fieldValue.ObjectDefinition.Type == sdkModels.StringTerraformSchemaObjectDefinitionType {
				fieldValue.ObjectDefinition = sdkModels.TerraformSchemaObjectDefinition{
					Type: sdkModels.ZoneTerraformSchemaObjectDefinitionType,
				}
				fields[fieldName] = fieldValue
			}
		}
		if strings.EqualFold(fieldName, "Zones") {
			if fieldValue.ObjectDefinition.Type == sdkModels.ListTerraformSchemaObjectDefinitionType && fieldValue.ObjectDefinition.NestedObject.Type == sdkModels.StringTerraformSchemaObjectDefinitionType {
				fieldValue.ObjectDefinition = sdkModels.TerraformSchemaObjectDefinition{
					Type: sdkModels.ZonesTerraformSchemaObjectDefinitionType,
				}
				fields[fieldName] = fieldValue
			}
		}
	}
	model.Fields = fields
	schemaModels[modelName] = model
	return schemaModels, &mappings, nil
}
