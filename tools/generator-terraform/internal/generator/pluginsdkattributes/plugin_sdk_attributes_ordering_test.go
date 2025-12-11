// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pluginsdkattributes

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestPluginSdkAttributes_FieldOrdering_TopLevel(t *testing.T) {
	// NOTE: Since this is a top-level model we /shouldn't/ output the top level Computed fields
	// as such the expectation below intentionally doesn't include them - this is not a bug but
	// the design of the Typed SDK at this time (requiring the use of the `Attributes` method).
	input := models.TerraformSchemaModel{
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
	}
	helper := PluginSdkAttributesHelpers{
		SchemaModels: map[string]models.TerraformSchemaModel{
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
	expected := `
map[string]*pluginsdk.Schema{
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
`
	actual, err := helper.CodeForModel(input, true)
	if err != nil {
		t.Fatalf("unexpected error: %+v", err)
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestPluginSdkAttributes_FieldOrdering_NestedLevel(t *testing.T) {
	input := models.TerraformSchemaModel{
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
	}
	helper := PluginSdkAttributesHelpers{
		SchemaModels: map[string]models.TerraformSchemaModel{
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
	expected := `
map[string]*pluginsdk.Schema{
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
	"computed_integer": {
		Computed: true,
		Type: pluginsdk.TypeInt,
	},
	"computed_string": {
		Computed: true,
		Type: pluginsdk.TypeString,
	},
}
`
	actual, err := helper.CodeForModel(input, false)
	if err != nil {
		t.Fatalf("unexpected error: %+v", err)
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestPluginSdkAttributes_FieldOrdering_TopLevelAttributesOnly(t *testing.T) {
	// NOTE: Since this is a top-level model we /shouldn't/ output the top level Computed fields
	// as such the expectation below intentionally doesn't include them - this is not a bug but
	// the design of the Typed SDK at this time (requiring the use of the `Attributes` method).
	input := models.TerraformSchemaModel{
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
	}
	helper := PluginSdkAttributesHelpers{
		SchemaModels: map[string]models.TerraformSchemaModel{
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
	expected := `
map[string]*pluginsdk.Schema{
	"computed_integer": {
		Computed: true,
		Type: pluginsdk.TypeInt,
	},
	"computed_string": {
		Computed: true,
		Type: pluginsdk.TypeString,
	},
}
`
	actual, err := helper.CodeForModelAttributesOnly(input)
	if err != nil {
		t.Fatalf("unexpected error: %+v", err)
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
