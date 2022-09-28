package processors

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ ModelProcessor = modelFlattenReferenceId{}

type modelFlattenReferenceId struct{}

func (modelFlattenReferenceId) ProcessModel(modelName string, model resourcemanager.TerraformSchemaModelDefinition, models map[string]resourcemanager.TerraformSchemaModelDefinition, mappings resourcemanager.MappingDefinition) (*map[string]resourcemanager.TerraformSchemaModelDefinition, *resourcemanager.MappingDefinition, error) {
	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)

	for fieldName, fieldValue := range model.Fields {
		fields[fieldName] = fieldValue

		if strings.EqualFold(fieldName, "Id") && len(model.Fields) > 1 {
			continue
		}

		if fieldValue.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeReference {
			continue
		}

		if fieldValue.ObjectDefinition.ReferenceName == nil {
			return nil, nil, fmt.Errorf("processing model %q: field %q was a reference with no reference name", modelName, fieldName)
		}

		// NOTE: at this point Constants will have been transformed to a String so this *will* be a Model
		nestedModel, ok := models[*fieldValue.ObjectDefinition.ReferenceName]
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
	}
	model.Fields = fields
	models[modelName] = model
	return &models, &mappings, nil
}
