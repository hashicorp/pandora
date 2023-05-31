package testing

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/zclconf/go-cty/cty"
)

func TestGenerateRequiresImport(t *testing.T) {
	// all of these expect the resource `example_resource` with the model name `TopLevel`
	testData := []struct {
		Name            string
		TerraformModels map[string]resourcemanager.TerraformSchemaModelDefinition
		Expected        string
		HclContext      *hcl.EvalContext
	}{
		{
			Name: "Name is the only and required field",
			TerraformModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"TopLevel": {
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
			TerraformModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"TopLevel": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Name": {
							HclName:  "name",
							Required: true,
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"Location": {
							HclName:  "location",
							Required: true,
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeLocation,
							},
						},
						"ResourceGroupName": {
							HclName:  "resource_group_name",
							Required: true,
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
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
			TerraformModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"TopLevel": {
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
			TerraformModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"TopLevel": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Name": {
							HclName:  "name",
							Required: true,
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"Location": {
							HclName:  "location",
							Required: true,
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeLocation,
							},
						},
						"ResourceGroupName": {
							HclName:  "resource_group_name",
							Required: true,
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"SomeItem": {
							HclName:  "some_item",
							Required: true,
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: pointer.To("SomeNestedItem"),
							},
						},
					},
				},
				"SomeNestedItem": {
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
			details := resourcemanager.TerraformResourceDetails{
				SchemaModels:    test.TerraformModels,
				SchemaModelName: "TopLevel",
			}
			builder := NewTestBuilder("example", "resource", details)
			actual, err := builder.generateRequiresImportTest()
			if err != nil {
				t.Fatalf(err.Error())
			}
			assertTerraformConfigurationsAreSemanticallyTheSame(t, test.Expected, *actual, test.HclContext)
		})
	}
}
