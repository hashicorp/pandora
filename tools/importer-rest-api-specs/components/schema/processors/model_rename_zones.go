package processors

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"regexp"
)

type modelRenameZones struct{}

func (modelRenameZones) ProcessModel(modelName string, model resourcemanager.TerraformSchemaModelDefinition, models map[string]resourcemanager.TerraformSchemaModelDefinition) (map[string]resourcemanager.TerraformSchemaModelDefinition, error) {
	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
	for fieldName, fieldValue := range model.Fields {
		fields[fieldName] = fieldValue

		re := regexp.MustCompile("AvailabilityZones?")

		if re.MatchString(fieldName) && fieldValue.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
			if fieldValue.ObjectDefinition.ReferenceName == nil {
				return nil, fmt.Errorf("processing model %q: had no reference for field %q", modelName, fieldName)
			}
			nested, ok := models[*fieldValue.ObjectDefinition.ReferenceName]
			if !ok {
				return nil, fmt.Errorf("processing model %q: no nested model was not found with name %q", modelName, *fieldValue.ObjectDefinition.ReferenceName)
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
		}
	}
	model.Fields = fields
	models[modelName] = model
	return models, nil
}
