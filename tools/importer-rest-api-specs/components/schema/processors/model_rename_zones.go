package processors

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ ModelProcessor = modelRenameZones{}

type modelRenameZones struct{}

func (modelRenameZones) ProcessModel(modelName string, model resourcemanager.TerraformSchemaModelDefinition, models map[string]resourcemanager.TerraformSchemaModelDefinition, mappings resourcemanager.MappingDefinition) (*map[string]resourcemanager.TerraformSchemaModelDefinition, *resourcemanager.MappingDefinition, error) {
	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
	for fieldName, fieldValue := range model.Fields {
		fields[fieldName] = fieldValue

		if strings.EqualFold(fieldName, "AvailabilityZones") && fieldValue.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeList {
			if fieldValue.ObjectDefinition.NestedObject.Type == resourcemanager.TerraformSchemaFieldTypeString {
				oldName := fieldName
				delete(fields, oldName)

				fieldName = fmt.Sprint("Zones")
				fields[fieldName] = fieldValue

				// also go through and replace the mapping
				mappings = applyFieldRenameToMappings(mappings, modelName, oldName, fieldName)
			}
		}

		if strings.EqualFold(fieldName, "AvailabilityZone") && fieldValue.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeString {
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
			if fieldValue.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeString {
				fieldValue.ObjectDefinition = resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeZone,
				}
				fields[fieldName] = fieldValue
			}
		}
		if strings.EqualFold(fieldName, "Zones") {
			if fieldValue.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeList && fieldValue.ObjectDefinition.NestedObject.Type == resourcemanager.TerraformSchemaFieldTypeString {
				fieldValue.ObjectDefinition = resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeZones,
				}
				fields[fieldName] = fieldValue
			}
		}
	}
	model.Fields = fields
	models[modelName] = model
	return &models, &mappings, nil
}
