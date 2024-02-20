// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func MapTerraformSchemaObjectDefinitionToRepository(input resourcemanager.TerraformSchemaFieldObjectDefinition) (*dataapimodels.TerraformSchemaObjectDefinition, error) {
	mapped, ok := terraformSchemaObjectDefinitionTypesToRepository[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for the Terraform Schema Field Object Definition %q", string(input.Type))
	}

	objectDefinition := dataapimodels.TerraformSchemaObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          mapped,
	}

	if input.ReferenceName != nil && !strings.HasSuffix(*input.ReferenceName, "Schema") {
		// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
		referenceName := fmt.Sprintf("%sSchema", *input.ReferenceName)
		objectDefinition.ReferenceName = &referenceName
	}

	if input.NestedObject != nil {
		nestedItem, err := MapTerraformSchemaObjectDefinitionToRepository(*input.NestedObject)
		if err != nil {
			return nil, fmt.Errorf("mapping nested Object Definition: %+v", err)
		}
		objectDefinition.NestedItem = nestedItem
	}

	return &objectDefinition, nil
}

var terraformSchemaObjectDefinitionTypesToRepository = map[resourcemanager.TerraformSchemaFieldType]dataapimodels.TerraformSchemaObjectDefinitionType{
	resourcemanager.TerraformSchemaFieldTypeBoolean:                       dataapimodels.BooleanTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeDateTime:                      dataapimodels.DateTimeTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeDictionary:                    dataapimodels.DictionaryTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeEdgeZone:                      dataapimodels.EdgeZoneTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned:        dataapimodels.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: dataapimodels.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned:  dataapimodels.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned:          dataapimodels.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeLocation:                      dataapimodels.LocationTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeFloat:                         dataapimodels.FloatTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeInteger:                       dataapimodels.IntegerTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeList:                          dataapimodels.ListTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeReference:                     dataapimodels.ReferenceTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeResourceGroup:                 dataapimodels.ResourceGroupTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeSet:                           dataapimodels.SetTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeString:                        dataapimodels.StringTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeTags:                          dataapimodels.TagsTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeSku:                           dataapimodels.SkuTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeZone:                          dataapimodels.ZoneTerraformSchemaObjectDefinitionType,
	resourcemanager.TerraformSchemaFieldTypeZones:                         dataapimodels.ZonesTerraformSchemaObjectDefinitionType,
}
