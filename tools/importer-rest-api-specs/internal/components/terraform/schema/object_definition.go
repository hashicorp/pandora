// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var sdkObjectDefinitionTypesToFieldObjectDefinitionTypes = map[models.SDKObjectDefinitionType]models.TerraformSchemaObjectDefinitionType{
	models.BooleanSDKObjectDefinitionType:    models.BooleanTerraformSchemaObjectDefinitionType,
	models.DateTimeSDKObjectDefinitionType:   models.DateTimeTerraformSchemaObjectDefinitionType,
	models.DictionarySDKObjectDefinitionType: models.DictionaryTerraformSchemaObjectDefinitionType,
	models.IntegerSDKObjectDefinitionType:    models.IntegerTerraformSchemaObjectDefinitionType,
	models.FloatSDKObjectDefinitionType:      models.FloatTerraformSchemaObjectDefinitionType,
	models.ListSDKObjectDefinitionType:       models.ListTerraformSchemaObjectDefinitionType,
	models.ReferenceSDKObjectDefinitionType:  models.ReferenceTerraformSchemaObjectDefinitionType,
	models.StringSDKObjectDefinitionType:     models.StringTerraformSchemaObjectDefinitionType,

	// Custom Types
	models.EdgeZoneSDKObjectDefinitionType:                                models.EdgeZoneTerraformSchemaObjectDefinitionType,
	models.LocationSDKObjectDefinitionType:                                models.LocationTerraformSchemaObjectDefinitionType,
	models.SystemAssignedIdentitySDKObjectDefinitionType:                  models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.SystemAndUserAssignedIdentityListSDKObjectDefinitionType:       models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType:        models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType:  models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.SystemOrUserAssignedIdentityListSDKObjectDefinitionType:        models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType:         models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.UserAssignedIdentityListSDKObjectDefinitionType:                models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.UserAssignedIdentityMapSDKObjectDefinitionType:                 models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.TagsSDKObjectDefinitionType:                                    models.TagsTerraformSchemaObjectDefinitionType,
	models.ZoneSDKObjectDefinitionType:                                    models.ZoneTerraformSchemaObjectDefinitionType,
	models.ZonesSDKObjectDefinitionType:                                   models.ZonesTerraformSchemaObjectDefinitionType,
	// NOTE: we intentionally don't implement SystemData since it's not exposed at this time
}

func (b Builder) convertToFieldObjectDefinition(modelPrefix string, input models.SDKObjectDefinition) (*models.TerraformSchemaObjectDefinition, error) {
	out := models.TerraformSchemaObjectDefinition{}

	var isConstant bool
	var constant models.SDKConstant
	if input.ReferenceName != nil {
		reference := *input.ReferenceName
		if constant, isConstant = b.apiResource.Constants[reference]; !isConstant {
			// models are prefixed to be globally unique
			reference = fmt.Sprintf("%s%s", modelPrefix, reference)
		} else {
			switch constant.Type {
			case models.StringSDKConstantType:
				out.Type = models.StringTerraformSchemaObjectDefinitionType
			case models.IntegerSDKConstantType:
				out.Type = models.IntegerTerraformSchemaObjectDefinitionType
			case models.FloatSDKConstantType:
				out.Type = models.FloatTerraformSchemaObjectDefinitionType
			default:
				return nil, fmt.Errorf("constant has unknown or unsupported type: %+v", constant.Type)
			}
		}
		out.ReferenceName = &reference
	}

	if input.NestedItem != nil {
		nested, err := b.convertToFieldObjectDefinition(modelPrefix, *input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("converting nested item: %+v", err)
		}
		out.NestedObject = nested
	}

	if !isConstant {
		v, ok := sdkObjectDefinitionTypesToFieldObjectDefinitionTypes[input.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing object definition mapping for type %q", string(input.Type))
		}
		out.Type = v
	}

	return &out, nil
}
