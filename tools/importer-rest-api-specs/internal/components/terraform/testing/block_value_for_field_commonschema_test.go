// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func emptyTestVariables() definitions.VariablesDefinition {
	return definitions.VariablesDefinition{}
}

func TestBlockValueForField_CommonSchemaIdentitySystemAssigned(t *testing.T) {
	t.Parallel()
	field := sdkModels.TerraformSchemaField{
		HCLName:  "identity",
		Optional: false,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Identity": field,
				},
			},
		},
	}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `
identity {
  type = "SystemAssigned"
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
	}
	actualRendered := renderBlocksToHcl(*actual)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actualRendered)
	expectedDependencies := testDependencies{
		variables:                 testVariables{},
		needsClientConfig:         false,
		needsEdgeZone:             false,
		needsNetworkInterface:     false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestBlockValueForField_CommonSchemaIdentitySystemAndUserAssigned(t *testing.T) {
	t.Parallel()
	field := sdkModels.TerraformSchemaField{
		HCLName:  "identity",
		Optional: false,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Identity": field,
				},
			},
		},
	}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `
identity {
  type         = "SystemAssigned, UserAssigned"
  identity_ids = [example_user_assigned_identity.test.id]
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
	}
	actualRendered := renderBlocksToHcl(*actual)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actualRendered)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomInteger:   true,
			needsPrimaryLocation: true,
		},
		needsClientConfig:         false,
		needsEdgeZone:             false,
		needsNetworkInterface:     false,
		needsPublicIP:             false,
		needsResourceGroup:        true,
		needsSubnet:               false,
		needsUserAssignedIdentity: true,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestBlockValueForField_CommonSchemaIdentitySystemOrUserAssigned(t *testing.T) {
	t.Parallel()
	field := sdkModels.TerraformSchemaField{
		HCLName:  "identity",
		Optional: false,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Identity": field,
				},
			},
		},
	}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	// SystemAssigned - or - UserAssigned is either of these literal values, so let's pick System for simplicity
	// however specifying `identity_ids` validate the field exists/is unset
	expected := `
identity {
  type         = "SystemAssigned"
  identity_ids = []
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
	}
	actualRendered := renderBlocksToHcl(*actual)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actualRendered)
	expectedDependencies := testDependencies{
		variables:                 testVariables{},
		needsClientConfig:         false,
		needsEdgeZone:             false,
		needsNetworkInterface:     false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestBlockValueForField_CommonSchemaIdentityUserAssigned(t *testing.T) {
	t.Parallel()
	field := sdkModels.TerraformSchemaField{
		HCLName:  "identity",
		Optional: false,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Identity": field,
				},
			},
		},
	}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `
identity {
  type         = "UserAssigned"
  identity_ids = [example_user_assigned_identity.test.id]
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
	}
	actualRendered := renderBlocksToHcl(*actual)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actualRendered)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomInteger:   true,
			needsPrimaryLocation: true,
		},
		needsClientConfig:         false,
		needsEdgeZone:             false,
		needsNetworkInterface:     false,
		needsPublicIP:             false,
		needsResourceGroup:        true,
		needsSubnet:               false,
		needsUserAssignedIdentity: true,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}
