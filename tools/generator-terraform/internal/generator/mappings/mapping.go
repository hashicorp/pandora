// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// Two types of Mappings:
//  1. Resource ID Segments <-> SDK Path
//  2. Schema Model/Field <-> SDK Path
// TODO: support for Resource ID Mappings

type Mappings struct {
	apiResourcePackageName string
	sdkConstants           map[string]models.SDKConstant
	sdkModels              map[string]models.SDKModel
	schemaModels           map[string]models.TerraformSchemaModel
}

func NewResourceMappings(terraformDefinition models.TerraformResourceDefinition, sdkConstants map[string]models.SDKConstant, sdkModels map[string]models.SDKModel) Mappings {
	return Mappings{
		apiResourcePackageName: strings.ToLower(terraformDefinition.APIResource),
		schemaModels:           terraformDefinition.SchemaModels,
		sdkConstants:           sdkConstants,
		sdkModels:              sdkModels,
	}
}
