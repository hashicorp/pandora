package processors

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type modelFlattenSkuName struct{}

func (modelFlattenSkuName) ProcessModel(modelName string, models map[string]resourcemanager.TerraformSchemaModelDefinition) (map[string]resourcemanager.TerraformSchemaModelDefinition, error) {
	model, ok := models[modelName]
	if !ok {
		return nil, fmt.Errorf("a model was not found with the name %q", modelName)
	}

	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
	for fieldName, fieldValue := range model.Fields {
		fields[fieldName] = fieldValue

		if strings.EqualFold(fieldName, "Sku") && fieldValue.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
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
