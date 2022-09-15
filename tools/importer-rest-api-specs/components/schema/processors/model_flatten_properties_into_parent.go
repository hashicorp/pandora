package processors

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type modelFlattenPropertiesIntoParent struct{}

func (modelFlattenPropertiesIntoParent) ProcessModel(modelName string, model resourcemanager.TerraformSchemaModelDefinition, models map[string]resourcemanager.TerraformSchemaModelDefinition) (map[string]resourcemanager.TerraformSchemaModelDefinition, error) {
	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
	for fieldName, fieldValue := range model.Fields {
		fields[fieldName] = fieldValue

		// Skip Properties field in the top level model
		if strings.EqualFold(fieldName, "Properties") {
			continue
		}

		if fieldValue.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeReference {
			continue
		}

		if fieldValue.ObjectDefinition.ReferenceName == nil {
			return nil, fmt.Errorf("processing model %q: had no reference for field %q", modelName, fieldName)
		}

		if !strings.HasSuffix(*fieldValue.ObjectDefinition.ReferenceName, "Properties") {
			continue
		}

		nestedPropsModel := models[*fieldValue.ObjectDefinition.ReferenceName]
		for nestedFieldName, nestedFieldValue := range nestedPropsModel.Fields {
			fields[nestedFieldName] = nestedFieldValue
		}
		delete(fields, fieldName)
	}
	model.Fields = fields
	models[modelName] = model
	return models, nil
}
