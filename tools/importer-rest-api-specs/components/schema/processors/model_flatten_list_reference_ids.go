package processors

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ ModelProcessor = modelFlattenListReferenceIds{}

type modelFlattenListReferenceIds struct{}

func (modelFlattenListReferenceIds) ProcessModel(modelName string, model resourcemanager.TerraformSchemaModelDefinition, models map[string]resourcemanager.TerraformSchemaModelDefinition, mappings resourcemanager.MappingDefinition) (*map[string]resourcemanager.TerraformSchemaModelDefinition, *resourcemanager.MappingDefinition, error) {
	if len(model.Fields) != 1 {
		return &models, &mappings, nil
	}

	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
	for fieldName, fieldValue := range model.Fields {
		fields[fieldName] = fieldValue

		// the ObjectDefinition for a List to a Reference will be:
		// ObjectDefinition Type: List (no reference name) with a NestedObject
		// of ObjectDefinition Type: Reference (and a reference name)
		if fieldValue.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeList {
			continue
		}

		referenceName := ""
		if nested := fieldValue.ObjectDefinition.NestedObject; nested != nil {
			if nested.Type != resourcemanager.TerraformSchemaFieldTypeReference {
				continue
			}
			if nested.Type == resourcemanager.TerraformSchemaFieldTypeReference && nested.ReferenceName != nil {
				referenceName = *nested.ReferenceName
			}
		}
		if referenceName == "" {
			return nil, nil, fmt.Errorf("processing model %q: nested list had no reference for field %q", modelName, fieldName)
		}

		// NOTE: at this point Constants will have been transformed to a String so this *will* be a Model
		nestedModel, ok := models[referenceName]
		if !ok {
			return nil, nil, fmt.Errorf("processing %q: nested model with reference name %q was not found for field %q", modelName, referenceName, fieldName)
		}

		if len(nestedModel.Fields) != 1 {
			continue
		}

		nestedField, ok := nestedModel.Fields["Ids"]
		if !ok {
			continue
		}

		fieldValue.ObjectDefinition = nestedField.ObjectDefinition
		updatedName := fmt.Sprintf("%sIds", fieldName)
		fields[updatedName] = fieldValue
		delete(fields, fieldName)

		mappings = applyFieldRenameToMappings(mappings, modelName, fieldName, updatedName)
	}
	model.Fields = fields
	models[modelName] = model
	return &models, &mappings, nil
}
