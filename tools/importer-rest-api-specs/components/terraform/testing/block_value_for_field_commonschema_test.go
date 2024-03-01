// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func emptyTestData() resourcemanager.TerraformTestDataVariables {
	return resourcemanager.TerraformTestDataVariables{}
}

func TestBlockValueForField_CommonSchemaIdentitySystemAssigned(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "identity",
		Optional: false,
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Identity": field,
				},
			},
		},
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
identity {
  type = "SystemAssigned"
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestData())
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "identity",
		Optional: false,
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Identity": field,
				},
			},
		},
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
identity {
  type         = "SystemAssigned, UserAssigned"
  identity_ids = [example_user_assigned_identity.test.id]
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestData())
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "identity",
		Optional: false,
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Identity": field,
				},
			},
		},
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	// SystemAssigned - or - UserAssigned is either of these literal values, so let's pick System for simplicity
	// however specifying `identity_ids` validate the field exists/is unset
	expected := `
identity {
  type         = "SystemAssigned"
  identity_ids = []
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestData())
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "identity",
		Optional: false,
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Identity": field,
				},
			},
		},
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
identity {
  type         = "UserAssigned"
  identity_ids = [example_user_assigned_identity.test.id]
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestData())
	if err != nil {
		t.Fatalf(err.Error())
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
