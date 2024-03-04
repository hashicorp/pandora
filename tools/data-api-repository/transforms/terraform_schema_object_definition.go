// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapTerraformSchemaObjectDefinitionToRepository(input models.TerraformSchemaObjectDefinition) (*dataapimodels.TerraformSchemaObjectDefinition, error) {
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

var terraformSchemaObjectDefinitionTypesToRepository = map[models.TerraformSchemaObjectDefinitionType]dataapimodels.TerraformSchemaObjectDefinitionType{
	// Simple Types
	models.BooleanTerraformSchemaObjectDefinitionType:  dataapimodels.BooleanTerraformSchemaObjectDefinitionType,
	models.DateTimeTerraformSchemaObjectDefinitionType: dataapimodels.DateTimeTerraformSchemaObjectDefinitionType,
	models.FloatTerraformSchemaObjectDefinitionType:    dataapimodels.FloatTerraformSchemaObjectDefinitionType,
	models.IntegerTerraformSchemaObjectDefinitionType:  dataapimodels.IntegerTerraformSchemaObjectDefinitionType,
	models.StringTerraformSchemaObjectDefinitionType:   dataapimodels.StringTerraformSchemaObjectDefinitionType,

	// Complex Types
	models.DictionaryTerraformSchemaObjectDefinitionType: dataapimodels.DictionaryTerraformSchemaObjectDefinitionType,
	models.ListTerraformSchemaObjectDefinitionType:       dataapimodels.ListTerraformSchemaObjectDefinitionType,
	models.ReferenceTerraformSchemaObjectDefinitionType:  dataapimodels.ReferenceTerraformSchemaObjectDefinitionType,
	models.SetTerraformSchemaObjectDefinitionType:        dataapimodels.SetTerraformSchemaObjectDefinitionType,

	// Common Schema Types
	models.EdgeZoneTerraformSchemaObjectDefinitionType:                      dataapimodels.EdgeZoneTerraformSchemaObjectDefinitionType,
	models.LocationTerraformSchemaObjectDefinitionType:                      dataapimodels.LocationTerraformSchemaObjectDefinitionType,
	models.ResourceGroupTerraformSchemaObjectDefinitionType:                 dataapimodels.ResourceGroupTerraformSchemaObjectDefinitionType,
	models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType:        dataapimodels.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType: dataapimodels.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType:  dataapimodels.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.TagsTerraformSchemaObjectDefinitionType:                          dataapimodels.TagsTerraformSchemaObjectDefinitionType,
	models.UserAssignedIdentityTerraformSchemaObjectDefinitionType:          dataapimodels.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
	models.ZoneTerraformSchemaObjectDefinitionType:                          dataapimodels.ZoneTerraformSchemaObjectDefinitionType,
	models.ZonesTerraformSchemaObjectDefinitionType:                         dataapimodels.ZonesTerraformSchemaObjectDefinitionType,
}
