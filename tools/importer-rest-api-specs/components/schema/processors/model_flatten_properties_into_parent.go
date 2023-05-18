package processors

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ ModelProcessor = modelFlattenPropertiesIntoParent{}

type modelFlattenPropertiesIntoParent struct{}

func (modelFlattenPropertiesIntoParent) ProcessModel(modelName string, model resourcemanager.TerraformSchemaModelDefinition, models map[string]resourcemanager.TerraformSchemaModelDefinition, mappings resourcemanager.MappingDefinition) (*map[string]resourcemanager.TerraformSchemaModelDefinition, *resourcemanager.MappingDefinition, error) {
	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
	// add fields that are not properties, and remember fields that need flatten
	// to do not let flatten field overwrite existing top-level field
	var flattenKeys []string
	for fieldName, fieldValue := range model.Fields {
		if strings.EqualFold(fieldName, "Properties") || fieldValue.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeReference {
			fields[fieldName] = fieldValue
		} else if !strings.HasSuffix(*fieldValue.ObjectDefinition.ReferenceName, "Properties") {
			fields[fieldName] = fieldValue
		} else {
			flattenKeys = append(flattenKeys, fieldName)
		}
	}

	sort.Strings(flattenKeys) // sort for a stable loop
	for _, fieldName := range flattenKeys {
		fieldValue := model.Fields[fieldName]
		if _, ok := fields[fieldName]; ok {
			continue
		}

		if fieldValue.ObjectDefinition.ReferenceName == nil {
			return nil, nil, fmt.Errorf("processing model %q: had no reference for field %q", modelName, fieldName)
		}

		referenceName := *fieldValue.ObjectDefinition.ReferenceName
		if !strings.HasSuffix(referenceName, "Properties") {
			continue
		}

		nestedPropsModel := models[referenceName]
		for nestedFieldName, nestedFieldValue := range nestedPropsModel.Fields {
			flattenFieldName := nestedFieldName
			if _, ok := fields[nestedFieldName]; ok {
				// rename field if name conflict exists
				flattenFieldName = fmt.Sprintf("%s%s", fieldName, nestedFieldName)
			}
			fields[flattenFieldName] = nestedFieldValue
			// also update mappings: delete old mapping and add new one
			updateMappings(mappings, modelName, flattenFieldName, referenceName, nestedFieldName)
		}
		delete(fields, fieldName)
		// find old filedName mapping and modify to new nested mapping
		// add a model2model mapping of schemaModel to sdk filed of parent
		for _, field := range mappings.Fields {
			if fd := field.DirectAssignment; fd != nil {
				if fd.SchemaModelName == modelName && fd.SchemaFieldPath == fieldName {
					mappings.Fields = append(mappings.Fields, resourcemanager.ModelToModelMappingBetween(modelName, fd.SdkModelName, fd.SdkFieldPath))
				}
			}
		}
		mappings.RemoveField(modelName, fieldName)
	}
	model.Fields = fields
	models[modelName] = model
	return &models, &mappings, nil
}

func updateMappings(mappings resourcemanager.MappingDefinition, modelName, newFieldName string, nestedModelName, nestedFieldName string) {
	for idx, field := range mappings.Fields {
		if fd := field.DirectAssignment; fd != nil {
			if fd.SchemaModelName == nestedModelName && fd.SchemaFieldPath == nestedFieldName {
				mappings.Fields[idx].DirectAssignment.SchemaModelName = modelName
				mappings.Fields[idx].DirectAssignment.SchemaFieldPath = newFieldName
			}
		}
	}
}
