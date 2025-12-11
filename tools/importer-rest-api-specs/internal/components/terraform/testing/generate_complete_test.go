// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/hcl/v2"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/zclconf/go-cty/cty"
)

func TestGenerateCompleteTest_NameOnlyRequired(t *testing.T) {
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	testData := definitions.ResourceTestDataDefinition{}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.generateCompleteTest(&actualDependencies, testData)
	if err != nil {
		t.Fatal(err.Error())
	}

	if actual != nil {
		t.Fatalf("expected complete test to be nil but got %q", *actual)
	}
}

func TestGenerateCompleteTest_NameOnlyOptional(t *testing.T) {
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("example"),
		},
	}
	testData := definitions.ResourceTestDataDefinition{}
	builder := newTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
  name = "acctestr-${var.random_string}"
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies, testData)
	if err != nil {
		t.Fatal(err.Error())
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

func TestGenerateCompleteTest_NameOnlyComputedShouldBeIgnored(t *testing.T) {
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Computed: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	testData := definitions.ResourceTestDataDefinition{}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("example"),
		},
	}
	builder := newTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies, testData)
	if err != nil {
		t.Fatal(err.Error())
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
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Identity": {
						HCLName:  "identity",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	testData := definitions.ResourceTestDataDefinition{}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{},
	}
	builder := newTestBuilder("example", "resource", details)
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
	actual, err := builder.generateCompleteTest(&actualDependencies, testData)
	if err != nil {
		t.Fatal(err.Error())
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
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"Location": {
						HCLName:  "location",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.LocationTerraformSchemaObjectDefinitionType,
						},
					},
					"ResourceGroupName": {
						HCLName:  "resource_group_name",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.ResourceGroupTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	testData := definitions.ResourceTestDataDefinition{}
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
	builder := newTestBuilder("example", "resource", details)
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
	actual, err := builder.generateCompleteTest(&actualDependencies, testData)
	if err != nil {
		t.Fatal(err.Error())
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

func TestGenerateCompleteTest_BothRequiredAndOptionalPropertiesShouldBeOutput(t *testing.T) {
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SomeOptionalField": {
						HCLName:  "some_optional_field",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	testData := definitions.ResourceTestDataDefinition{}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"var": cty.ObjectVal(map[string]cty.Value{
				"random_string": cty.StringVal("example"),
			}),
		},
	}
	builder := newTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}

resource "example_resource" "test" {
  name                = "acctestr-${var.random_string}"
  some_optional_field = "val-${var.random_string}"
}
`
	actual, err := builder.generateCompleteTest(&actualDependencies, testData)
	if err != nil {
		t.Fatal(err.Error())
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

func TestGenerateCompleteTest_NestedObject(t *testing.T) {
	// NestedObjects are output as a List of one-item
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"NestedBlock": {
						HCLName:  "nested_block",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("NestedModel"),
						},
					},
				},
			},
			"NestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	testData := definitions.ResourceTestDataDefinition{}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("example"),
		},
	}
	builder := newTestBuilder("example", "resource", details)
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
	actual, err := builder.generateCompleteTest(&actualDependencies, testData)
	if err != nil {
		t.Fatal(err.Error())
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

func TestGenerateCompleteTest_ListOfANestedObject(t *testing.T) {
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"NestedBlock": {
						HCLName:  "nested_block",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.ListTerraformSchemaObjectDefinitionType,
							NestedObject: &sdkModels.TerraformSchemaObjectDefinition{
								Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: pointer.To("NestedModel"),
							},
						},
					},
				},
			},
			"NestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	testData := definitions.ResourceTestDataDefinition{}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("example"),
		},
	}
	builder := newTestBuilder("example", "resource", details)
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
	actual, err := builder.generateCompleteTest(&actualDependencies, testData)
	if err != nil {
		t.Fatal(err.Error())
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

func TestGenerateCompleteTest_SetOfAnOptionalNestedObject(t *testing.T) {
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"NestedBlock": {
						HCLName:  "nested_block",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.SetTerraformSchemaObjectDefinitionType,
							NestedObject: &sdkModels.TerraformSchemaObjectDefinition{
								Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: pointer.To("NestedModel"),
							},
						},
					},
				},
			},
			"NestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	testData := definitions.ResourceTestDataDefinition{}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("example"),
		},
	}
	builder := newTestBuilder("example", "resource", details)
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
	actual, err := builder.generateCompleteTest(&actualDependencies, testData)
	if err != nil {
		t.Fatal(err.Error())
	}

	if actual == nil {
		t.Fatalf("no complete test was generated")
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

func TestGenerateCompleteTest_SetOfANestedObjectWithOptionalField(t *testing.T) {
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"NestedBlock": {
						HCLName:  "nested_block",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.SetTerraformSchemaObjectDefinitionType,
							NestedObject: &sdkModels.TerraformSchemaObjectDefinition{
								Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: pointer.To("NestedModel"),
							},
						},
					},
				},
			},
			"NestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	testData := definitions.ResourceTestDataDefinition{}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{
			"random_string": cty.StringVal("example"),
		},
	}
	builder := newTestBuilder("example", "resource", details)
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
	actual, err := builder.generateCompleteTest(&actualDependencies, testData)
	if err != nil {
		t.Fatal(err.Error())
	}

	if actual == nil {
		t.Fatalf("no complete test was generated")
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
