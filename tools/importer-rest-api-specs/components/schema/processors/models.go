package processors

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ModelProcessor interface {
	ProcessModel(modelName string, models map[string]resourcemanager.TerraformSchemaModelDefinition) (map[string]resourcemanager.TerraformSchemaModelDefinition, error)
}

var ModelRules = []ModelProcessor{
	modelFlattenListReferenceIds{},
	modelFlattenReferenceId{},
}

// TODO move this to helpers like for field processors?
func processModels(input map[string]resourcemanager.TerraformSchemaModelDefinition) (*map[string]resourcemanager.TerraformSchemaModelDefinition, error) {
	output := make(map[string]resourcemanager.TerraformSchemaModelDefinition)

	// first map all the existing models over to output so that they're present, since we're going to be updating it
	for k, v := range input {
		output[k] = v
	}

	// then iterate over the original input to process the models into `output` as needed
	for key, value := range input {
		for _, matcher := range ModelRules {
			updatedFieldDefinition, err := matcher.ProcessModel(key, output)
			if err != nil {
				return nil, err
			}

			if updatedFieldDefinition != nil {
				//value.Fields = *updatedFieldDefinition
			}
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
