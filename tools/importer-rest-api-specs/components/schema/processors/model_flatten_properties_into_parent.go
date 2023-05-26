package processors

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ ModelProcessor = modelFlattenPropertiesIntoParent{}

type modelFlattenPropertiesIntoParent struct{}

func (modelFlattenPropertiesIntoParent) ProcessModel(modelName string, model resourcemanager.TerraformSchemaModelDefinition, models map[string]resourcemanager.TerraformSchemaModelDefinition, mappings resourcemanager.MappingDefinition) (*map[string]resourcemanager.TerraformSchemaModelDefinition, *resourcemanager.MappingDefinition, error) {
	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
	fieldKeys := make(map[string]struct{})
	// first ensure we have a canonical list of all fields within the model to be able to use for a unique check
	for fieldName := range model.Fields {
		fieldKeys[strings.ToLower(fieldName)] = struct{}{}
	}

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
			return nil, nil, fmt.Errorf("processing model %q: had no reference for field %q", modelName, fieldName)
		}

		if !strings.HasSuffix(*fieldValue.ObjectDefinition.ReferenceName, "Properties") {
			continue
		}

		nestedPropsModel := models[*fieldValue.ObjectDefinition.ReferenceName]
		for nestedFieldName, nestedFieldValue := range nestedPropsModel.Fields {
			if _, hasExisting := fieldKeys[strings.ToLower(nestedFieldName)]; hasExisting {
				// if the top level model contains a field with the same name then we shouldn't be flattening
				// the nested model into it, otherwise we'll have naming conflicts
				return &models, &mappings, nil
			}

			fields[nestedFieldName] = nestedFieldValue
		}
		delete(fields, fieldName)
	}
	model.Fields = fields
	models[modelName] = model
	return &models, &mappings, nil
}
