// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pluginsdkattributes

import (
	"fmt"
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

// TODO:  w/Validation

func TestPluginSdkAttributes_CodeForBasicFields(t *testing.T) {
	basicFieldTypes := map[models.TerraformSchemaObjectDefinitionType]string{
		models.BooleanTerraformSchemaObjectDefinitionType: "pluginsdk.TypeBool",
		models.FloatTerraformSchemaObjectDefinitionType:   "pluginsdk.TypeFloat",
		models.IntegerTerraformSchemaObjectDefinitionType: "pluginsdk.TypeInt",
		models.StringTerraformSchemaObjectDefinitionType:  "pluginsdk.TypeString",
	}
	for fieldType, pluginSdkType := range basicFieldTypes {
		t.Run(fmt.Sprintf("Field Type %s", string(fieldType)), func(t *testing.T) {
			testData := []struct {
				input    models.TerraformSchemaField
				expected string
			}{
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: fieldType,
						},
						Computed: false,
						ForceNew: false,
						Optional: false,
						Required: true,
					},
					expected: fmt.Sprintf(`
{
	Required: true,
	Type: %[1]s,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: fieldType,
						},
						Computed: false,
						ForceNew: true,
						Optional: false,
						Required: true,
					},
					expected: fmt.Sprintf(`
{
	ForceNew: true,
	Required: true,
	Type: %[1]s,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: fieldType,
						},
						Computed: false,
						ForceNew: false,
						Optional: true,
						Required: false,
					},
					expected: fmt.Sprintf(`
{
	Optional: true,
	Type: %[1]s,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: fieldType,
						},
						Computed: false,
						ForceNew: true,
						Optional: true,
						Required: false,
					},
					expected: fmt.Sprintf(`
{
	ForceNew: true,
	Optional: true,
	Type: %[1]s,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: fieldType,
						},
						Computed: true,
						ForceNew: true,
						Optional: true,
						Required: false,
					},
					expected: fmt.Sprintf(`
{
	Computed: true,
	ForceNew: true,
	Optional: true,
	Type: %[1]s,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: fieldType,
						},
						Computed: true,
						ForceNew: false,
						Optional: false,
						Required: false,
					},
					expected: fmt.Sprintf(`
{
	Computed: true,
	Type: %[1]s,
}
`, pluginSdkType),
				},
			}
			for i, testCase := range testData {
				helper := PluginSdkAttributesHelpers{}
				actual, err := helper.codeForPluginSdkAttribute(testCase.input)
				if err != nil {
					if testCase.expected == "" {
						continue
					}

					t.Fatalf("unexpected error for index %d: %+v", i, err)
				}
				if testCase.expected == "" {
					t.Fatalf("expected an error but didn't get one for index %d", i)
				}
				testhelpers.AssertTemplatedCodeMatches(t, testCase.expected, *actual)
			}
		})
	}
}

func TestPluginSdkAttributes_CodeForReference(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
					ReferenceName: pointer.To("NestedSchemaModel"),
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: `
{
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	MaxItems: 1,
	Required: true,
	Type: pluginsdk.TypeList,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
					ReferenceName: pointer.To("NestedSchemaModel"),
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: `
{
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	ForceNew: true,
	MaxItems: 1,
	Required: true,
	Type: pluginsdk.TypeList,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
					ReferenceName: pointer.To("NestedSchemaModel"),
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: `
{
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	MaxItems: 1,
	Optional: true,
	Type: pluginsdk.TypeList,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
					ReferenceName: pointer.To("NestedSchemaModel"),
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: `
{
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	ForceNew: true,
	MaxItems: 1,
	Optional: true,
	Type: pluginsdk.TypeList,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
					ReferenceName: pointer.To("NestedSchemaModel"),
				},
				Computed: true,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: `
{
	Computed: true,
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	ForceNew: true,
	MaxItems: 1,
	Optional: true,
	Type: pluginsdk.TypeList,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
					ReferenceName: pointer.To("NestedSchemaModel"),
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: `
{
	Computed: true,
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	MaxItems: 1,
	Type: pluginsdk.TypeList,
}
`,
		},
	}
	for i, testCase := range testData {
		helper := PluginSdkAttributesHelpers{
			SchemaModels: map[string]models.TerraformSchemaModel{
				"NestedSchemaModel": {
					Fields: map[string]models.TerraformSchemaField{
						"NestedField": {
							HCLName: "nested_field",
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
							Optional: true,
						},
					},
				},
			},
		}
		actual, err := helper.codeForPluginSdkAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d: %+v", i, err)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		testhelpers.AssertTemplatedCodeMatches(t, testCase.expected, *actual)
	}
}

func TestPluginSdkAttributes_CodeForListOfBasicType(t *testing.T) {
	basicFieldTypes := map[models.TerraformSchemaObjectDefinitionType]string{
		models.BooleanTerraformSchemaObjectDefinitionType: "pluginsdk.TypeBool",
		models.FloatTerraformSchemaObjectDefinitionType:   "pluginsdk.TypeFloat",
		models.IntegerTerraformSchemaObjectDefinitionType: "pluginsdk.TypeInt",
		models.StringTerraformSchemaObjectDefinitionType:  "pluginsdk.TypeString",
	}
	for fieldType, pluginSdkType := range basicFieldTypes {
		t.Run(fmt.Sprintf("Field Type %s", string(fieldType)), func(t *testing.T) {

			testData := []struct {
				input    models.TerraformSchemaField
				expected string
			}{
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.ListTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type: fieldType,
							},
						},
						Computed: false,
						ForceNew: false,
						Optional: false,
						Required: true,
					},
					expected: fmt.Sprintf(`
{
	Elem: &pluginsdk.Schema{
		Type:	%[1]s,
	},
	Required: true,
	Type: pluginsdk.TypeList,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.ListTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type: fieldType,
							},
						},
						Computed: false,
						ForceNew: true,
						Optional: false,
						Required: true,
					},
					expected: fmt.Sprintf(`
{
	Elem: &pluginsdk.Schema{
		Type:	%[1]s,
	},
	ForceNew: true,
	Required: true,
	Type: pluginsdk.TypeList,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.ListTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type: fieldType,
							},
						},
						Computed: false,
						ForceNew: false,
						Optional: true,
						Required: false,
					},
					expected: fmt.Sprintf(`
{
	Elem: &pluginsdk.Schema{
		Type:	%[1]s,
	},
	Optional: true,
	Type: pluginsdk.TypeList,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.ListTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type: fieldType,
							},
						},
						Computed: false,
						ForceNew: true,
						Optional: true,
						Required: false,
					},
					expected: fmt.Sprintf(`
{
	Elem: &pluginsdk.Schema{
		Type:	%[1]s,
	},
	ForceNew: true,
	Optional: true,
	Type: pluginsdk.TypeList,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.ListTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type: fieldType,
							},
						},
						Computed: true,
						ForceNew: true,
						Optional: true,
						Required: false,
					},
					expected: fmt.Sprintf(`
{
	Computed: true,
	Elem: &pluginsdk.Schema{
		Type:	%[1]s,
	},
	ForceNew: true,
	Optional: true,
	Type: pluginsdk.TypeList,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.ListTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type: fieldType,
							},
						},
						Computed: true,
						ForceNew: false,
						Optional: false,
						Required: false,
					},
					expected: fmt.Sprintf(`
{
	Computed: true,
	Elem: &pluginsdk.Schema{
		Type:	%[1]s,
	},
	Type: pluginsdk.TypeList,
}
`, pluginSdkType),
				},
			}
			for i, testCase := range testData {
				helper := PluginSdkAttributesHelpers{}
				actual, err := helper.codeForPluginSdkAttribute(testCase.input)
				if err != nil {
					if testCase.expected == "" {
						continue
					}

					t.Fatalf("unexpected error for index %d: %+v", i, err)
				}
				if testCase.expected == "" {
					t.Fatalf("expected an error but didn't get one for index %d", i)
				}
				testhelpers.AssertTemplatedCodeMatches(t, testCase.expected, *actual)
			}
		})
	}
}

func TestPluginSdkAttributes_CodeForListOfReferenceType(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ListTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("NestedSchemaModel"),
					},
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: `
{
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	Required: true,
	Type: pluginsdk.TypeList,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ListTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("NestedSchemaModel"),
					},
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: `
{
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	ForceNew: true,
	Required: true,
	Type: pluginsdk.TypeList,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ListTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("NestedSchemaModel"),
					},
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: `
{
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	Optional: true,
	Type: pluginsdk.TypeList,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ListTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("NestedSchemaModel"),
					},
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: `
{
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	ForceNew: true,
	Optional: true,
	Type: pluginsdk.TypeList,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ListTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("NestedSchemaModel"),
					},
				},
				Computed: true,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: `
{
	Computed: true,
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	ForceNew: true,
	Optional: true,
	Type: pluginsdk.TypeList,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ListTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("NestedSchemaModel"),
					},
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: `
{
	Computed: true,
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	Type: pluginsdk.TypeList,
}
`,
		},
	}
	for i, testCase := range testData {
		helper := PluginSdkAttributesHelpers{
			SchemaModels: map[string]models.TerraformSchemaModel{
				"NestedSchemaModel": {
					Fields: map[string]models.TerraformSchemaField{
						"NestedField": {
							HCLName: "nested_field",
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
							Optional: true,
						},
					},
				},
			},
		}
		actual, err := helper.codeForPluginSdkAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d: %+v", i, err)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		testhelpers.AssertTemplatedCodeMatches(t, testCase.expected, *actual)
	}
}

func TestPluginSdkAttributes_CodeForSetOfBasicType(t *testing.T) {
	basicFieldTypes := map[models.TerraformSchemaObjectDefinitionType]string{
		models.BooleanTerraformSchemaObjectDefinitionType: "pluginsdk.TypeBool",
		models.FloatTerraformSchemaObjectDefinitionType:   "pluginsdk.TypeFloat",
		models.IntegerTerraformSchemaObjectDefinitionType: "pluginsdk.TypeInt",
		models.StringTerraformSchemaObjectDefinitionType:  "pluginsdk.TypeString",
	}
	for fieldType, pluginSdkType := range basicFieldTypes {
		t.Run(fmt.Sprintf("Field Type %s", string(fieldType)), func(t *testing.T) {

			testData := []struct {
				input    models.TerraformSchemaField
				expected string
			}{
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SetTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type: fieldType,
							},
						},
						Computed: false,
						ForceNew: false,
						Optional: false,
						Required: true,
					},
					expected: fmt.Sprintf(`
{
	Elem: &pluginsdk.Schema{
		Type:	%[1]s,
	},
	Required: true,
	Type: pluginsdk.TypeSet,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SetTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type: fieldType,
							},
						},
						Computed: false,
						ForceNew: true,
						Optional: false,
						Required: true,
					},
					expected: fmt.Sprintf(`
{
	Elem: &pluginsdk.Schema{
		Type:	%[1]s,
	},
	ForceNew: true,
	Required: true,
	Type: pluginsdk.TypeSet,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SetTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type: fieldType,
							},
						},
						Computed: false,
						ForceNew: false,
						Optional: true,
						Required: false,
					},
					expected: fmt.Sprintf(`
{
	Elem: &pluginsdk.Schema{
		Type:	%[1]s,
	},
	Optional: true,
	Type: pluginsdk.TypeSet,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SetTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type: fieldType,
							},
						},
						Computed: false,
						ForceNew: true,
						Optional: true,
						Required: false,
					},
					expected: fmt.Sprintf(`
{
	Elem: &pluginsdk.Schema{
		Type:	%[1]s,
	},
	ForceNew: true,
	Optional: true,
	Type: pluginsdk.TypeSet,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SetTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type: fieldType,
							},
						},
						Computed: true,
						ForceNew: true,
						Optional: true,
						Required: false,
					},
					expected: fmt.Sprintf(`
{
	Computed: true,
	Elem: &pluginsdk.Schema{
		Type:	%[1]s,
	},
	ForceNew: true,
	Optional: true,
	Type: pluginsdk.TypeSet,
}
`, pluginSdkType),
				},
				{
					input: models.TerraformSchemaField{
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SetTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type: fieldType,
							},
						},
						Computed: true,
						ForceNew: false,
						Optional: false,
						Required: false,
					},
					expected: fmt.Sprintf(`
{
	Computed: true,
	Elem: &pluginsdk.Schema{
		Type:	%[1]s,
	},
	Type: pluginsdk.TypeSet,
}
`, pluginSdkType),
				},
			}
			for i, testCase := range testData {
				helper := PluginSdkAttributesHelpers{}
				actual, err := helper.codeForPluginSdkAttribute(testCase.input)
				if err != nil {
					if testCase.expected == "" {
						continue
					}

					t.Fatalf("unexpected error for index %d: %+v", i, err)
				}
				if testCase.expected == "" {
					t.Fatalf("expected an error but didn't get one for index %d", i)
				}
				testhelpers.AssertTemplatedCodeMatches(t, testCase.expected, *actual)
			}
		})
	}
}

func TestPluginSdkAttributes_CodeForSetOfReferenceType(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SetTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("NestedSchemaModel"),
					},
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: `
{
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	Required: true,
	Type: pluginsdk.TypeSet,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SetTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("NestedSchemaModel"),
					},
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: `
{
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	ForceNew: true,
	Required: true,
	Type: pluginsdk.TypeSet,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SetTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("NestedSchemaModel"),
					},
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: `
{
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	Optional: true,
	Type: pluginsdk.TypeSet,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SetTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("NestedSchemaModel"),
					},
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: `
{
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	ForceNew: true,
	Optional: true,
	Type: pluginsdk.TypeSet,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SetTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("NestedSchemaModel"),
					},
				},
				Computed: true,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: `
{
	Computed: true,
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	ForceNew: true,
	Optional: true,
	Type: pluginsdk.TypeSet,
}
`,
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SetTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("NestedSchemaModel"),
					},
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: `
{
	Computed: true,
	Elem: &pluginsdk.Resource{
		Schema: map[string]*pluginsdk.Schema{
			"nested_field": {
				Optional: true,
				Type: pluginsdk.TypeString,
			},
		},
	},
	Type: pluginsdk.TypeSet,
}
`,
		},
	}
	for i, testCase := range testData {
		helper := PluginSdkAttributesHelpers{
			SchemaModels: map[string]models.TerraformSchemaModel{
				"NestedSchemaModel": {
					Fields: map[string]models.TerraformSchemaField{
						"NestedField": {
							HCLName: "nested_field",
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
							Optional: true,
						},
					},
				},
			},
		}
		actual, err := helper.codeForPluginSdkAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d: %+v", i, err)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		testhelpers.AssertTemplatedCodeMatches(t, testCase.expected, *actual)
	}
}
