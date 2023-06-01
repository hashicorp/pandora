package testing

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestAttributeValueForField_EdgeZone(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "edge_zone",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"EdgeZone": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := "element(data.azurerm_extended_locations.test.extended_locations, 0)"
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "location",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeLocation,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Location": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := "example_resource_group.test.location"
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "location",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeLocation,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Location": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource_group", details)
	expected := `var.primary_location`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "resource_group_name",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"ResourceGroupName": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := "example_resource_group.test.name"
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "resource_group_name",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"ResourceGroupName": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource_group", details)
	expected := `"acctestrg-${var.random_integer}"`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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

func TestAttributeValueForField_Sku(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "sku_name",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeSku,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SkuName": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `"Standard"`
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

func TestAttributeValueForField_Tags(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "tags",
		Optional: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeTags,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Tags": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
{
	environment = "terraform-acctests"
	some_key    = "some-value"
}
`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "zone",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeZone,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Zone": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `"1"`
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

func TestAttributeValueForField_Zones(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "zones",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeZones,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Zones": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `["1", "2", "3"]`
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
