// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestComponentArguments(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModel",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]models.TerraformSchemaField{
					"OptionalNestedItem": {
						HCLName: "optional_nested_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("NestedSchema"),
						},
						Optional: true,
					},
					"RequiredInteger": {
						HCLName: "required_integer",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"OptionalInteger": {
						HCLName: "optional_integer",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
					},
					"ComputedInteger": {
						HCLName: "computed_integer",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
					},
					"RequiredString": {
						HCLName: "required_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"OptionalString": {
						HCLName: "optional_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
					},
					"ComputedString": {
						HCLName: "computed_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
					},
				},
			},
			"NestedSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"NestedItem": {
						HCLName: "nested_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
					},
					"ComputedItem": {
						HCLName: "computed_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
					},
				},
			},
		},
	}
	actual, err := argumentsCodeFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Arguments() map[string]*pluginsdk.Schema {
	return map[string]*pluginsdk.Schema{
		"required_integer": {
			Required: true,
			Type: pluginsdk.TypeInt,
		},
		"required_string": {
			Required: true,
			Type: pluginsdk.TypeString,
		},
		"optional_integer": {
			Optional: true,
			Type: pluginsdk.TypeInt,
		},
		"optional_nested_item": {
			Elem: &pluginsdk.Resource{
				Schema: map[string]*pluginsdk.Schema{
					"nested_item": {
						Optional: true,
						Type: pluginsdk.TypeString,
					},
					"computed_item": {
						Computed: true,
						Type: pluginsdk.TypeString,
					},
				},
			},
			MaxItems: 1,
			Optional: true,
			Type: pluginsdk.TypeList,
		},
		"optional_string": {
			Optional: true,
			Type: pluginsdk.TypeString,
		},
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
