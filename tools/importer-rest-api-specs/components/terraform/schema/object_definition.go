// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var sdkObjectDefinitionTypesToFieldObjectDefinitionTypes = map[models.SDKObjectDefinitionType]resourcemanager.TerraformSchemaFieldType{
	models.BooleanSDKObjectDefinitionType:    resourcemanager.TerraformSchemaFieldTypeBoolean,
	models.DateTimeSDKObjectDefinitionType:   resourcemanager.TerraformSchemaFieldTypeDateTime,
	models.DictionarySDKObjectDefinitionType: resourcemanager.TerraformSchemaFieldTypeDictionary,
	models.IntegerSDKObjectDefinitionType:    resourcemanager.TerraformSchemaFieldTypeInteger,
	models.FloatSDKObjectDefinitionType:      resourcemanager.TerraformSchemaFieldTypeFloat,
	models.ListSDKObjectDefinitionType:       resourcemanager.TerraformSchemaFieldTypeList,
	models.ReferenceSDKObjectDefinitionType:  resourcemanager.TerraformSchemaFieldTypeReference,
	models.StringSDKObjectDefinitionType:     resourcemanager.TerraformSchemaFieldTypeString,

	// Custom Types
	models.EdgeZoneSDKObjectDefinitionType:                                resourcemanager.TerraformSchemaFieldTypeEdgeZone,
	models.LocationSDKObjectDefinitionType:                                resourcemanager.TerraformSchemaFieldTypeLocation,
	models.SystemAssignedIdentitySDKObjectDefinitionType:                  resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
	models.SystemAndUserAssignedIdentityListSDKObjectDefinitionType:       resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
	models.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType:        resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
	models.LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
	models.LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType:  resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
	models.SystemOrUserAssignedIdentityListSDKObjectDefinitionType:        resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
	models.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType:         resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
	models.UserAssignedIdentityListSDKObjectDefinitionType:                resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
	models.UserAssignedIdentityMapSDKObjectDefinitionType:                 resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
	models.TagsSDKObjectDefinitionType:                                    resourcemanager.TerraformSchemaFieldTypeTags,
	models.ZoneSDKObjectDefinitionType:                                    resourcemanager.TerraformSchemaFieldTypeZone,
	models.ZonesSDKObjectDefinitionType:                                   resourcemanager.TerraformSchemaFieldTypeZones,
	// NOTE: we intentionally don't implement SystemData since it's not exposed at this time
}

func (b Builder) convertToFieldObjectDefinition(modelPrefix string, input models.SDKObjectDefinition) (*resourcemanager.TerraformSchemaFieldObjectDefinition, error) {
	out := resourcemanager.TerraformSchemaFieldObjectDefinition{}

	var isConstant bool
	var constant models.SDKConstant
	if input.ReferenceName != nil {
		reference := *input.ReferenceName
		if constant, isConstant = b.constants[reference]; !isConstant {
			// models are prefixed to be globally unique
			reference = fmt.Sprintf("%s%s", modelPrefix, reference)
		} else {
			switch constant.Type {
			case models.StringSDKConstantType:
				out.Type = resourcemanager.TerraformSchemaFieldTypeString
			case models.IntegerSDKObjectDefinitionType:
				out.Type = resourcemanager.TerraformSchemaFieldTypeInteger
			case models.FloatSDKConstantType:
				out.Type = resourcemanager.TerraformSchemaFieldTypeFloat
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
