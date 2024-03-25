// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/zclconf/go-cty/cty"
)

func TestGenerateBasicTest_NoRequiredProperties(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeOptionalField": {
						HclName:  "some_optional_field",
						Optional: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
		},
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
	actual, err := builder.generateBasicTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
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

func TestGenerateBasicTest_NameOnly(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
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
	actual, err := builder.generateBasicTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
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

func TestGenerateBasicTest_SystemAssignedIdentityOnly(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Identity": {
						HclName:  "identity",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
		},
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
	actual, err := builder.generateBasicTest(&actualDependencies)
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

func TestGenerateBasicTest_CoreProperties(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"Location": {
						HclName:  "location",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.LocationTerraformSchemaObjectDefinitionType,
						},
					},
					"ResourceGroupName": {
						HclName:  "resource_group_name",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.ResourceGroupTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
		},
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
	actual, err := builder.generateBasicTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomInteger:   true,
			needsRandomString:    true,
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

func TestGenerateBasicTest_OnlyRequiredPropertiesShouldBeOutput(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SomeOptionalField": {
						HclName:  "some_optional_field",
						Optional: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
		},
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
	actual, err := builder.generateBasicTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
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

func TestGenerateBasicTest_NestedObject(t *testing.T) {
	// NestedObjects are output as a List of one-item
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"NestedBlock": {
						HclName:  "nested_block",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("NestedModel"),
						},
					},
				},
			},
			"NestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
		},
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
	actual, err := builder.generateBasicTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
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

func TestGenerateBasicTest_ListOfANestedObject(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"NestedBlock": {
						HclName:  "nested_block",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.ListTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
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
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
		},
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
	actual, err := builder.generateBasicTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
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

func TestGenerateBasicTest_SetOfANestedObject(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName:  "name",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"NestedBlock": {
						HclName:  "nested_block",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SetTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
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
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
		},
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
	actual, err := builder.generateBasicTest(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
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
