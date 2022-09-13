package processors

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"strings"
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
			nested, ok := models[*fieldValue.ObjectDefinition.ReferenceName]
			if !ok {
				return nil, fmt.Errorf("a nested model was not found with name %q", *fieldValue.ObjectDefinition.ReferenceName)
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
