// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"strings"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mapTerraformSchemaObjectDefinitionFromRepository(input repositoryModels.TerraformSchemaObjectDefinition) (*sdkModels.TerraformSchemaObjectDefinition, error) {
	mapped, ok := terraformSchemaObjectDefinitionTypesFromRepository[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for the Terraform Schema Field Object Definition %q", string(input.Type))
	}

	objectDefinition := sdkModels.TerraformSchemaObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          mapped,
	}

	if input.NestedItem != nil {
		nestedItem, err := mapTerraformSchemaObjectDefinitionFromRepository(*input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("mapping nested Object Definition: %+v", err)
		}
		objectDefinition.NestedObject = nestedItem
	}

	return &objectDefinition, nil
}

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

var terraformSchemaObjectDefinitionTypesFromRepository = map[repositoryModels.TerraformSchemaObjectDefinitionType]sdkModels.TerraformSchemaObjectDefinitionType{
	// Simple Types
	repositoryModels.BooleanTerraformSchemaObjectDefinitionType:  sdkModels.BooleanTerraformSchemaObjectDefinitionType,
	repositoryModels.DateTimeTerraformSchemaObjectDefinitionType: sdkModels.DateTimeTerraformSchemaObjectDefinitionType,
	repositoryModels.FloatTerraformSchemaObjectDefinitionType:    sdkModels.FloatTerraformSchemaObjectDefinitionType,
	repositoryModels.IntegerTerraformSchemaObjectDefinitionType:  sdkModels.IntegerTerraformSchemaObjectDefinitionType,
	repositoryModels.StringTerraformSchemaObjectDefinitionType:   sdkModels.StringTerraformSchemaObjectDefinitionType,

	// Complex Types
	repositoryModels.DictionaryTerraformSchemaObjectDefinitionType: sdkModels.DictionaryTerraformSchemaObjectDefinitionType,
	repositoryModels.ListTerraformSchemaObjectDefinitionType:       sdkModels.ListTerraformSchemaObjectDefinitionType,
	repositoryModels.ReferenceTerraformSchemaObjectDefinitionType:  sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
	repositoryModels.SetTerraformSchemaObjectDefinitionType:        sdkModels.SetTerraformSchemaObjectDefinitionType,

	// Common Schema Types
	repositoryModels.EdgeZoneTerraformSchemaObjectDefinitionType:                      sdkModels.EdgeZoneTerraformSchemaObjectDefinitionType,
	repositoryModels.LocationTerraformSchemaObjectDefinitionType:                      sdkModels.LocationTerraformSchemaObjectDefinitionType,
	repositoryModels.ResourceGroupTerraformSchemaObjectDefinitionType:                 sdkModels.ResourceGroupTerraformSchemaObjectDefinitionType,
	repositoryModels.SystemAssignedIdentityTerraformSchemaObjectDefinitionType:        sdkModels.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
	repositoryModels.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType: sdkModels.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	repositoryModels.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType:  sdkModels.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	repositoryModels.TagsTerraformSchemaObjectDefinitionType:                          sdkModels.TagsTerraformSchemaObjectDefinitionType,
	repositoryModels.UserAssignedIdentityTerraformSchemaObjectDefinitionType:          sdkModels.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
	repositoryModels.ZoneTerraformSchemaObjectDefinitionType:                          sdkModels.ZoneTerraformSchemaObjectDefinitionType,
	repositoryModels.ZonesTerraformSchemaObjectDefinitionType:                         sdkModels.ZonesTerraformSchemaObjectDefinitionType,
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
