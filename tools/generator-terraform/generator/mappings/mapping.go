package mappings

import (
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// Two types of Mappings:
//  1. Resource ID Segments <-> SDK Path
//  2. Schema Model/Field <-> SDK Path
// TODO: support for Resource ID Mappings

type Mappings struct {
	apiResourcePackageName string
	sdkConstants           map[string]resourcemanager.ConstantDetails
	sdkModels              map[string]resourcemanager.ModelDetails
	schemaModels           map[string]resourcemanager.TerraformSchemaModelDefinition
}

func NewResourceMappings(terraformDefinition resourcemanager.TerraformResourceDetails, sdkConstants map[string]resourcemanager.ConstantDetails, sdkModels map[string]resourcemanager.ModelDetails) Mappings {
	return Mappings{
		apiResourcePackageName: strings.ToLower(terraformDefinition.Resource),
		schemaModels:           terraformDefinition.SchemaModels,
		sdkConstants:           sdkConstants,
		sdkModels:              sdkModels,
	}
}
