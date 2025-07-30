// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestAttributeValueForField_EdgeZone(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "edge_zone",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.EdgeZoneTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"EdgeZone": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := "element(data.azurerm_extended_locations.test.extended_locations, 0)"
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsPrimaryLocation: true,
		},
		needsEdgeZone:             true,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_Location(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "location",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.LocationTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Location": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := "example_resource_group.test.location"
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomInteger:   true,
			needsPrimaryLocation: true,
		},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        true,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_LocationWithinTheResourceGroupResource(t *testing.T) {
	// When the Location field is present within the Resource Group resource, it should be
	// a regular `location` field, rather than a reference to the Resource Group's Location
	field := sdkModels.TerraformSchemaField{
		HCLName:  "location",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.LocationTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Location": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource_group", details)
	expected := `var.primary_location`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsPrimaryLocation: true,
		},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_ResourceGroup(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "resource_group_name",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.ResourceGroupTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"ResourceGroupName": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := "example_resource_group.test.name"
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomInteger:   true,
			needsPrimaryLocation: true,
		},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        true,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_ResourceGroupWithinTheResourceGroupResource(t *testing.T) {
	// When the Resource Group Name field is present within the Resource Group resource, it should be
	// a regular `name` field, rather than a reference to the Resource Group
	field := sdkModels.TerraformSchemaField{
		HCLName:  "resource_group_name",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.ResourceGroupTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"ResourceGroupName": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource_group", details)
	expected := `"acctestrg-${var.random_integer}"`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomInteger: true,
		},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_Tags(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "tags",
		Optional: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.TagsTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Tags": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `
{
	environment = "terraform-acctests"
	some_key    = "some-value"
}
`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomInteger:   false,
			needsPrimaryLocation: false,
		},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_Zone(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "zone",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.ZoneTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Zone": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `"1"`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables:                 testVariables{},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_Zones(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "zones",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.ZonesTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Zones": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `["1", "2", "3"]`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables:                 testVariables{},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}
