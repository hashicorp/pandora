package processors

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ModelProcessor interface {
	ProcessModel(modelName string, model resourcemanager.TerraformSchemaModelDefinition, models map[string]resourcemanager.TerraformSchemaModelDefinition, mappings resourcemanager.MappingDefinition) (*map[string]resourcemanager.TerraformSchemaModelDefinition, *resourcemanager.MappingDefinition, error)
}

var ModelRules = []ModelProcessor{
	modelFlattenListReferenceIds{},
	modelFlattenPropertiesIntoParent{},
	modelFlattenReferenceId{},
	modelRemoveStatusAndDetail{},
	modelRenameZones{},
	modelFlattenSkuName{},
}
