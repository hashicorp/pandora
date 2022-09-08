package processors

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type modelFlattenReferenceId struct{}

func (modelFlattenReferenceId) ProcessModel(modelName string, models map[string]resourcemanager.TerraformSchemaModelDefinition) (map[string]resourcemanager.TerraformSchemaModelDefinition, error) {
	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)

	model, ok := models[modelName]
	if !ok {
		return nil, fmt.Errorf("a model was not found with the name %q", modelName)
	}

	if len(model.Fields) != 1 {
		return models, nil
	}

	for fieldName, fieldValue := range model.Fields {
		fields[fieldName] = fieldValue

		if fieldValue.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeReference {
			continue
		}

		if fieldValue.ObjectDefinition.ReferenceName == nil {
			return nil, fmt.Errorf("processing model %q: field %q was a reference with no reference name", modelName, fieldName)
		}

		// NOTE: at this point Constants will have been transformed to a String so this *will* be a Model
		nestedModel, ok := models[*fieldValue.ObjectDefinition.ReferenceName]
		if !ok {
			return nil, fmt.Errorf("processing model %q: field %q had a reference to %q but it wasn't found", modelName, fieldName, *fieldValue.ObjectDefinition.ReferenceName)
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
	}
	model.Fields = fields
	models[modelName] = model
	return models, nil
}
