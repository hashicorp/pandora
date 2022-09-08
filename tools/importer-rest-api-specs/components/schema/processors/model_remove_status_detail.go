package processors

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"regexp"
	"strings"
)

type modelRemoveStatusAndDetail struct{}

func (modelRemoveStatusAndDetail) ProcessModel(modelName string, models map[string]resourcemanager.TerraformSchemaModelDefinition) (map[string]resourcemanager.TerraformSchemaModelDefinition, error) {
	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)

	model, ok := models[modelName]
	if !ok {
		return nil, fmt.Errorf("a model was not found with the name %s", modelName)
	}

	status := regexp.MustCompile("\\w?(Status)$")

	for fieldName, fieldValue := range model.Fields {
		if status.MatchString(fieldName) && fieldValue.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
			continue
		}

		if strings.EqualFold(fieldName, "Detail") && fieldValue.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
			continue
		}

		fields[fieldName] = fieldValue
	}
	model.Fields = fields
	models[modelName] = model
	return models, nil
}
