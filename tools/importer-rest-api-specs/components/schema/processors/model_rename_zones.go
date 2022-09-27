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
				updatedName := fmt.Sprint("Zones")
				fields[updatedName] = fieldValue
				delete(fields, fieldName)

				// also go through and replace the mapping
				mappings = applyFieldRenameToMappings(mappings, modelName, fieldName, updatedName)
			}
		}

		if strings.EqualFold(fieldName, "AvailabilityZone") && fieldValue.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeString {
			updatedName := fmt.Sprint("Zone")
			fields[updatedName] = fieldValue
			delete(fields, fieldName)

			// also go through and replace the mapping
			mappings = applyFieldRenameToMappings(mappings, modelName, fieldName, updatedName)
		}
	}
	model.Fields = fields
	models[modelName] = model
	return &models, &mappings, nil
}
