package testing

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"testing"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/zclconf/go-cty/cty"
)

func TestGenerateCompleteTest_NoProperties(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{},
	}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomInteger:   false,
			needsPrimaryLocation: false,
		},
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

func TestGenerateCompleteTest_NameOnlyRequired(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("example"),
		},
	}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
  name = "acctestr-${var.random_string}"
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
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

func TestGenerateCompleteTest_NameOnlyOptional(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("example"),
		},
	}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
  name = "acctestr-${var.random_string}"
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
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

func TestGenerateCompleteTest_NameOnlyComputedShouldBeIgnored(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Computed: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("example"),
		},
	}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
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

func TestGenerateCompleteTest_SystemAssignedIdentityOnly(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Identity": {
						HclName:  "identity",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{},
	}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
  identity {
    type = "SystemAssigned"
  }
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
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

func TestGenerateCompleteTest_CoreProperties(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"Location": {
						HclName:  "location",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeLocation,
						},
					},
					"ResourceGroupName": {
						HclName:  "resource_group_name",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("some-value"),
			"example_resource_group": cty.ObjectVal(map[string]cty.Value{
				"test": cty.ObjectVal(map[string]cty.Value{
					"name":     cty.StringVal("some-name"),
					"location": cty.StringVal("some-location"),
				}),
			}),
		},
	}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
  location            = example_resource_group.test.location
  name                = "acctest-${var.random_string}"
  resource_group_name = example_resource_group.test.name
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
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

func TestGenerateCompleteTest_BothRequiredAndOptionalPropertiesShouldBeOutput(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"SomeOptionalField": {
						HclName:  "some_optional_field",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"var": cty.ObjectVal(map[string]cty.Value{
				"random_string": cty.StringVal("example"),
			}),
		},
	}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
  name                = "acctestr-${var.random_string}"
  some_optional_field = "val-${var.random_string}"
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomInteger: true,
			needsRandomString:  true,
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

func TestGenerateCompleteTest_NestedObject(t *testing.T) {
	// NestedObjects are output as a List of one-item
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"NestedBlock": {
						HclName:  "nested_block",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("NestedModel"),
						},
					},
				},
			},
			"NestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("example"),
		},
	}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
  name = "acctest-${var.random_string}"

  nested_block {
    name = "acctest-${var.random_string}"
  }
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
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

func TestGenerateCompleteTest_ListOfANestedObject(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"NestedBlock": {
						HclName:  "nested_block",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeList,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: pointer.To("NestedModel"),
							},
						},
					},
				},
			},
			"NestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("example"),
		},
	}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
  name = "acctest-${var.random_string}"

  nested_block {
    name = "acctest-${var.random_string}"
  }
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
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

func TestGenerateCompleteTest_SetOfANestedObject(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"NestedBlock": {
						HclName:  "nested_block",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeSet,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: pointer.To("NestedModel"),
							},
						},
					},
				},
			},
			"NestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("example"),
		},
	}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
  name = "acctest-${var.random_string}"

  nested_block {
    name = "acctest-${var.random_string}"
  }
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
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
