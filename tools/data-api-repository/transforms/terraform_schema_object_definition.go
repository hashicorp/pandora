// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	repositoryModels "github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapTerraformSchemaObjectDefinitionToRepository(input sdkModels.TerraformSchemaObjectDefinition) (*repositoryModels.TerraformSchemaObjectDefinition, error) {
	mapped, ok := terraformSchemaObjectDefinitionTypesToRepository[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for the Terraform Schema Field Object Definition %q", string(input.Type))
	}

	objectDefinition := repositoryModels.TerraformSchemaObjectDefinition{
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

var terraformSchemaObjectDefinitionTypesToRepository = map[sdkModels.TerraformSchemaObjectDefinitionType]repositoryModels.TerraformSchemaObjectDefinitionType{
	// Simple Types
	sdkModels.BooleanTerraformSchemaObjectDefinitionType:  repositoryModels.BooleanTerraformSchemaObjectDefinitionType,
	sdkModels.DateTimeTerraformSchemaObjectDefinitionType: repositoryModels.DateTimeTerraformSchemaObjectDefinitionType,
	sdkModels.FloatTerraformSchemaObjectDefinitionType:    repositoryModels.FloatTerraformSchemaObjectDefinitionType,
	sdkModels.IntegerTerraformSchemaObjectDefinitionType:  repositoryModels.IntegerTerraformSchemaObjectDefinitionType,
	sdkModels.StringTerraformSchemaObjectDefinitionType:   repositoryModels.StringTerraformSchemaObjectDefinitionType,

	// Complex Types
	sdkModels.DictionaryTerraformSchemaObjectDefinitionType: repositoryModels.DictionaryTerraformSchemaObjectDefinitionType,
	sdkModels.ListTerraformSchemaObjectDefinitionType:       repositoryModels.ListTerraformSchemaObjectDefinitionType,
	sdkModels.ReferenceTerraformSchemaObjectDefinitionType:  repositoryModels.ReferenceTerraformSchemaObjectDefinitionType,
	sdkModels.SetTerraformSchemaObjectDefinitionType:        repositoryModels.SetTerraformSchemaObjectDefinitionType,

	// Common Schema Types
	sdkModels.EdgeZoneTerraformSchemaObjectDefinitionType:                      repositoryModels.EdgeZoneTerraformSchemaObjectDefinitionType,
	sdkModels.LocationTerraformSchemaObjectDefinitionType:                      repositoryModels.LocationTerraformSchemaObjectDefinitionType,
	sdkModels.ResourceGroupTerraformSchemaObjectDefinitionType:                 repositoryModels.ResourceGroupTerraformSchemaObjectDefinitionType,
	sdkModels.SystemAssignedIdentityTerraformSchemaObjectDefinitionType:        repositoryModels.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
	sdkModels.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType: repositoryModels.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	sdkModels.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType:  repositoryModels.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	sdkModels.TagsTerraformSchemaObjectDefinitionType:                          repositoryModels.TagsTerraformSchemaObjectDefinitionType,
	sdkModels.UserAssignedIdentityTerraformSchemaObjectDefinitionType:          repositoryModels.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
	sdkModels.ZoneTerraformSchemaObjectDefinitionType:                          repositoryModels.ZoneTerraformSchemaObjectDefinitionType,
	sdkModels.ZonesTerraformSchemaObjectDefinitionType:                         repositoryModels.ZonesTerraformSchemaObjectDefinitionType,
}
