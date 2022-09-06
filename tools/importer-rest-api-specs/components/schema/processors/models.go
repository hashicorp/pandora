package processors

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ModelProcessor interface {
	ProcessModel(modelName string, models map[string]resourcemanager.TerraformSchemaModelDefinition) (*map[string]resourcemanager.TerraformSchemaFieldDefinition, error)
}

var ModelRules = []ModelProcessor{
	modelFlattenReferenceId{},
}

type modelFlattenListReferenceIds struct{}

func (modelFlattenListReferenceIds) ProcessModel(modelName string, models map[string]resourcemanager.TerraformSchemaModelDefinition) (*map[string]resourcemanager.TerraformSchemaFieldDefinition, error) {
	// TODO implement me
	return nil, nil
}

type modelFlattenReferenceId struct{}

func (modelFlattenReferenceId) ProcessModel(modelName string, models map[string]resourcemanager.TerraformSchemaModelDefinition) (*map[string]resourcemanager.TerraformSchemaFieldDefinition, error) {
	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
	shouldFlattenField := false

	for fieldName, fieldValue := range models[modelName].Fields {
		if fieldValue.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
			nestedModel, ok := models[*fieldValue.ObjectDefinition.ReferenceName]
			if !ok {
				return nil, fmt.Errorf("processing %s: nested model with referencen name %s not found", modelName, *fieldValue.ObjectDefinition.ReferenceName)
			}

			if len(nestedModel.Fields) != 1 {
				return nil, nil
			}

			_, ok = nestedModel.Fields["Id"]
			if !ok {
				return nil, nil
			}

			shouldFlattenField = true

			if shouldFlattenField {
				fieldValue.ObjectDefinition = resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				}
			}
			fieldName = fmt.Sprintf("%sId", fieldName)
			fields[fieldName] = fieldValue
		}
	}
	return &fields, nil
}

// TODO move this to helpers like for field processors?
func processModels(input map[string]resourcemanager.TerraformSchemaModelDefinition) (*map[string]resourcemanager.TerraformSchemaModelDefinition, error) {
	output := make(map[string]resourcemanager.TerraformSchemaModelDefinition)

	for key, value := range input {
		for _, matcher := range ModelRules {
			updatedFieldDefinition, err := matcher.ProcessModel(key, input)
			if err != nil {
				return nil, err
			}
			value.Fields = *updatedFieldDefinition
			output[key] = value
		}
	}

	return &output, nil
}

func topLevelObjectDefinition(input resourcemanager.TerraformSchemaFieldObjectDefinition) resourcemanager.TerraformSchemaFieldObjectDefinition {
	if input.NestedObject != nil {
		return topLevelObjectDefinition(*input.NestedObject)
	}

	return input
}

func findUnusedModels(topLevelModelName string, input map[string]resourcemanager.TerraformSchemaModelDefinition) map[string]resourcemanager.TerraformSchemaModelDefinition {
	usedModels := map[string]struct{}{
		topLevelModelName: {},
	}
	for _, modelDetails := range input {
		for _, fieldDetails := range modelDetails.Fields {
			topLevelObjectDefinition := topLevelObjectDefinition(fieldDetails.ObjectDefinition)
			if topLevelObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
				// TODO: check if it's a constant
				usedModels[*topLevelObjectDefinition.ReferenceName] = struct{}{}
			}
		}
	}

	output := make(map[string]resourcemanager.TerraformSchemaModelDefinition)
	for modelName := range usedModels {
		output[modelName] = input[modelName]
	}
	return output
}
