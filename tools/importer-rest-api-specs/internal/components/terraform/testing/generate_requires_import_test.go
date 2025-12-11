// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/hcl/v2"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/zclconf/go-cty/cty"
)

// TODO: split these tests out
// TODO: ensure that Lists, References and Sets work

func TestGenerateRequiresImport(t *testing.T) {
	// all of these expect the resource `example_resource` with the model name `TopLevel`
	testData := []struct {
		Name            string
		TerraformModels map[string]sdkModels.TerraformSchemaModel
		Expected        string
		HclContext      *hcl.EvalContext
	}{
		{
			Name: "Name is the only and required field",
			TerraformModels: map[string]sdkModels.TerraformSchemaModel{
				"TopLevel": {
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
			Expected: `
resource "example_resource" "import" {
  name = example_resource.test.name
}
`,
			HclContext: &hcl.EvalContext{
				Variables: map[string]cty.Value{
					"example_resource": cty.ObjectVal(map[string]cty.Value{
						"test": cty.ObjectVal(map[string]cty.Value{
							"name": cty.StringVal("monsieur-blobby"),
						}),
					}),
				},
			},
		},
		{
			Name: "Basic Resource",
			TerraformModels: map[string]sdkModels.TerraformSchemaModel{
				"TopLevel": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Name": {
							HCLName:  "name",
							Required: true,
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
						"Location": {
							HCLName:  "location",
							Required: true,
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.LocationTerraformSchemaObjectDefinitionType,
							},
						},
						"ResourceGroupName": {
							HCLName:  "resource_group_name",
							Required: true,
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			Expected: `
resource "example_resource" "import" {
  name                = example_resource.test.name
  location            = example_resource.test.location
  resource_group_name = example_resource.test.resource_group_name
}
`,
			HclContext: &hcl.EvalContext{
				Variables: map[string]cty.Value{
					"example_resource": cty.ObjectVal(map[string]cty.Value{
						"test": cty.ObjectVal(map[string]cty.Value{
							"name":                cty.StringVal("monsieur-blobby"),
							"location":            cty.StringVal("television-studios"),
							"resource_group_name": cty.StringVal("some-resource-group"),
						}),
					}),
				},
			},
		},
		{
			Name: "All fields are optional so nothing should be output",
			TerraformModels: map[string]sdkModels.TerraformSchemaModel{
				"TopLevel": {
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
			Expected: `
resource "example_resource" "import" {
}
`,
			HclContext: &hcl.EvalContext{
				Variables: map[string]cty.Value{},
			},
		},
		{
			Name: "Required Block",
			TerraformModels: map[string]sdkModels.TerraformSchemaModel{
				"TopLevel": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Name": {
							HCLName:  "name",
							Required: true,
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
						"Location": {
							HCLName:  "location",
							Required: true,
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.LocationTerraformSchemaObjectDefinitionType,
							},
						},
						"ResourceGroupName": {
							HCLName:  "resource_group_name",
							Required: true,
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
						"SomeItem": {
							HCLName:  "some_item",
							Required: true,
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: pointer.To("SomeNestedItem"),
							},
						},
					},
				},
				"SomeNestedItem": {
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
			Expected: `
resource "example_resource" "import" {
  name                = example_resource.test.name
  location            = example_resource.test.location
  resource_group_name = example_resource.test.resource_group_name

  some_item {
    name = example_resource.test.some_item.0.name
  }
}
`,
			HclContext: &hcl.EvalContext{
				Variables: map[string]cty.Value{
					"example_resource": cty.ObjectVal(map[string]cty.Value{
						"test": cty.ObjectVal(map[string]cty.Value{
							"name":                cty.StringVal("monsieur-blobby"),
							"location":            cty.StringVal("television-studios"),
							"resource_group_name": cty.StringVal("some-resource-group"),
							"some_item": cty.ListVal([]cty.Value{
								cty.ObjectVal(map[string]cty.Value{
									"name": cty.StringVal("nested-value"),
								}),
							}),
						}),
					}),
				},
			},
		},
	}
	for _, test := range testData {
		t.Run(test.Name, func(t *testing.T) {
			details := sdkModels.TerraformResourceDefinition{
				SchemaModels:    test.TerraformModels,
				SchemaModelName: "TopLevel",
			}
			builder := newTestBuilder("example", "resource", details)
			actual, err := builder.generateRequiresImportTest()
			if err != nil {
				t.Fatal(err.Error())
			}
			assertTerraformConfigurationsAreSemanticallyTheSame(t, test.Expected, *actual, test.HclContext)
		})
	}
}
