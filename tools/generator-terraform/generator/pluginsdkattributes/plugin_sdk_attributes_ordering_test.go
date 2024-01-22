// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pluginsdkattributes

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestPluginSdkAttributes_FieldOrdering_TopLevel(t *testing.T) {
	// NOTE: Since this is a top-level model we /shouldn't/ output the top level Computed fields
	// as such the expectation below intentionally doesn't include them - this is not a bug but
	// the design of the Typed SDK at this time (requiring the use of the `Attributes` method).
	input := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"OptionalNestedItem": {
				HclName: "optional_nested_item",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: pointer.To("NestedSchema"),
				},
				Optional: true,
			},
			"RequiredInteger": {
				HclName: "required_integer",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
				Required: true,
			},
			"OptionalInteger": {
				HclName: "optional_integer",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
				Optional: true,
			},
			"ComputedInteger": {
				HclName: "computed_integer",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
				Computed: true,
			},
			"RequiredString": {
				HclName: "required_string",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				Required: true,
			},
			"OptionalString": {
				HclName: "optional_string",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				Optional: true,
			},
			"ComputedString": {
				HclName: "computed_string",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				Computed: true,
			},
		},
	}
	helper := PluginSdkAttributesHelpers{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"NestedSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"NestedItem": {
						HclName: "nested_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Optional: true,
					},
					"ComputedItem": {
						HclName: "computed_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
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
	input := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"OptionalNestedItem": {
				HclName: "optional_nested_item",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: pointer.To("NestedSchema"),
				},
				Optional: true,
			},
			"RequiredInteger": {
				HclName: "required_integer",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
				Required: true,
			},
			"OptionalInteger": {
				HclName: "optional_integer",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
				Optional: true,
			},
			"ComputedInteger": {
				HclName: "computed_integer",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
				Computed: true,
			},
			"RequiredString": {
				HclName: "required_string",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				Required: true,
			},
			"OptionalString": {
				HclName: "optional_string",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				Optional: true,
			},
			"ComputedString": {
				HclName: "computed_string",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				Computed: true,
			},
		},
	}
	helper := PluginSdkAttributesHelpers{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"NestedSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"NestedItem": {
						HclName: "nested_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Optional: true,
					},
					"ComputedItem": {
						HclName: "computed_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
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
	input := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"OptionalNestedItem": {
				HclName: "optional_nested_item",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: pointer.To("NestedSchema"),
				},
				Optional: true,
			},
			"RequiredInteger": {
				HclName: "required_integer",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
				Required: true,
			},
			"OptionalInteger": {
				HclName: "optional_integer",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
				Optional: true,
			},
			"ComputedInteger": {
				HclName: "computed_integer",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
				Computed: true,
			},
			"RequiredString": {
				HclName: "required_string",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				Required: true,
			},
			"OptionalString": {
				HclName: "optional_string",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				Optional: true,
			},
			"ComputedString": {
				HclName: "computed_string",
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				Computed: true,
			},
		},
	}
	helper := PluginSdkAttributesHelpers{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"NestedSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"NestedItem": {
						HclName: "nested_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Optional: true,
					},
					"ComputedItem": {
						HclName: "computed_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
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
