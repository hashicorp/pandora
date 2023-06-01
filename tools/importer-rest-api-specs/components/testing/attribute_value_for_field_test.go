package testing

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

// TODO: special-cases for Virtual Network ID, Subnet ID etc

func TestAttributeValueForField_BasicTypeBoolean(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_field",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `false`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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

func TestAttributeValueForField_BasicTypeInteger(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_field",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeInteger,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `21`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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

func TestAttributeValueForField_BasicTypeFloat(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_field",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeFloat,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `21.42`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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

func TestAttributeValueForField_BasicTypeString(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_field",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `"example"`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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
