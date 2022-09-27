package processors

import (
	"regexp"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ ModelProcessor = modelRemoveStatusAndDetail{}

type modelRemoveStatusAndDetail struct{}

func (modelRemoveStatusAndDetail) ProcessModel(modelName string, model resourcemanager.TerraformSchemaModelDefinition, models map[string]resourcemanager.TerraformSchemaModelDefinition, mappings resourcemanager.MappingDefinition) (*map[string]resourcemanager.TerraformSchemaModelDefinition, *resourcemanager.MappingDefinition, error) {
	fields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)

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
	return &models, &mappings, nil
}
