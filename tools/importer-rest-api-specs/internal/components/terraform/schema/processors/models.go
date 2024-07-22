// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type ModelProcessor interface {
	ProcessModel(modelName string, model sdkModels.TerraformSchemaModel, schemaModels map[string]sdkModels.TerraformSchemaModel, mappings sdkModels.TerraformMappingDefinition) (map[string]sdkModels.TerraformSchemaModel, *sdkModels.TerraformMappingDefinition, error)
}

var ModelRules = []ModelProcessor{
	modelFlattenListReferenceIds{},
	modelFlattenPropertiesIntoParent{},
	modelFlattenReferenceId{},
	modelRemoveStatusAndDetail{},
	modelRenameZones{},
	modelFlattenSkuName{},
}
