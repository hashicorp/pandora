// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"regexp"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ ModelProcessor = modelRemoveStatusAndDetail{}

type modelRemoveStatusAndDetail struct{}

func (modelRemoveStatusAndDetail) ProcessModel(modelName string, model sdkModels.TerraformSchemaModel, schemaModels map[string]sdkModels.TerraformSchemaModel, mappings sdkModels.TerraformMappingDefinition) (map[string]sdkModels.TerraformSchemaModel, *sdkModels.TerraformMappingDefinition, error) {
	fields := make(map[string]sdkModels.TerraformSchemaField)

	status := regexp.MustCompile("\\w?(Status)$")

	for fieldName, fieldValue := range model.Fields {
		if status.MatchString(fieldName) && fieldValue.ObjectDefinition.Type == sdkModels.ReferenceTerraformSchemaObjectDefinitionType {
			continue
		}

		if strings.EqualFold(fieldName, "Detail") && fieldValue.ObjectDefinition.Type == sdkModels.ReferenceTerraformSchemaObjectDefinitionType {
			continue
		}

		fields[fieldName] = fieldValue
	}
	model.Fields = fields
	schemaModels[modelName] = model
	return schemaModels, &mappings, nil
}
