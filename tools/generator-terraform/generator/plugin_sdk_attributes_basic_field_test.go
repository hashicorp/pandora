package generator

import (
	"fmt"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO:  w/Validation

func TestPluginSdkAttributes_CodeForBasicFields(t *testing.T) {
	basicFieldTypes := map[resourcemanager.TerraformSchemaFieldType]string{
		resourcemanager.TerraformSchemaFieldTypeBoolean: "pluginsdk.TypeBool",
		resourcemanager.TerraformSchemaFieldTypeFloat:   "pluginsdk.TypeFloat",
		resourcemanager.TerraformSchemaFieldTypeInteger: "pluginsdk.TypeInt",
		resourcemanager.TerraformSchemaFieldTypeString:  "pluginsdk.TypeString",
	}
	for fieldType, pluginSdkType := range basicFieldTypes {
		t.Run(fmt.Sprintf("Field Type %s", string(fieldType)), func(t *testing.T) {
			testData := []struct {
				input    resourcemanager.TerraformSchemaFieldDefinition
				expected string
			}{
				{
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
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
				helper := pluginSdkAttributesHelpers{}
				actual, err := helper.codeForPluginSdkAttribute(testCase.input, true)
				if err != nil {
					if testCase.expected == "" {
						continue
					}

					t.Fatalf("unexpected error for index %d: %+v", i, err)
				}
				if testCase.expected == "" {
					t.Fatalf("expected an error but didn't get one for index %d", i)
				}
				assertTemplatedCodeMatches(t, testCase.expected, *actual)
			}
		})
	}
}

func TestPluginSdkAttributes_CodeForReference(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaFieldDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: stringPointer("NestedSchemaModel"),
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
		helper := pluginSdkAttributesHelpers{
			schemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"NestedSchemaModel": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"nested_field": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
							Optional: true,
						},
					},
				},
			},
		}
		actual, err := helper.codeForPluginSdkAttribute(testCase.input, true)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d: %+v", i, err)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, *actual)
	}
}

func TestPluginSdkAttributes_CodeForListOfBasicType(t *testing.T) {
	basicFieldTypes := map[resourcemanager.TerraformSchemaFieldType]string{
		resourcemanager.TerraformSchemaFieldTypeBoolean: "pluginsdk.TypeBool",
		resourcemanager.TerraformSchemaFieldTypeFloat:   "pluginsdk.TypeFloat",
		resourcemanager.TerraformSchemaFieldTypeInteger: "pluginsdk.TypeInt",
		resourcemanager.TerraformSchemaFieldTypeString:  "pluginsdk.TypeString",
	}
	for fieldType, pluginSdkType := range basicFieldTypes {
		t.Run(fmt.Sprintf("Field Type %s", string(fieldType)), func(t *testing.T) {

			testData := []struct {
				input    resourcemanager.TerraformSchemaFieldDefinition
				expected string
			}{
				{
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeList,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeList,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeList,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeList,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeList,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeList,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
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
				helper := pluginSdkAttributesHelpers{}
				actual, err := helper.codeForPluginSdkAttribute(testCase.input, true)
				if err != nil {
					if testCase.expected == "" {
						continue
					}

					t.Fatalf("unexpected error for index %d: %+v", i, err)
				}
				if testCase.expected == "" {
					t.Fatalf("expected an error but didn't get one for index %d", i)
				}
				assertTemplatedCodeMatches(t, testCase.expected, *actual)
			}
		})
	}
}

func TestPluginSdkAttributes_CodeForListOfReferenceType(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaFieldDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
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
		helper := pluginSdkAttributesHelpers{
			schemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"NestedSchemaModel": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"nested_field": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
							Optional: true,
						},
					},
				},
			},
		}
		actual, err := helper.codeForPluginSdkAttribute(testCase.input, true)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d: %+v", i, err)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, *actual)
	}
}

func TestPluginSdkAttributes_CodeForSetOfBasicType(t *testing.T) {
	basicFieldTypes := map[resourcemanager.TerraformSchemaFieldType]string{
		resourcemanager.TerraformSchemaFieldTypeBoolean: "pluginsdk.TypeBool",
		resourcemanager.TerraformSchemaFieldTypeFloat:   "pluginsdk.TypeFloat",
		resourcemanager.TerraformSchemaFieldTypeInteger: "pluginsdk.TypeInt",
		resourcemanager.TerraformSchemaFieldTypeString:  "pluginsdk.TypeString",
	}
	for fieldType, pluginSdkType := range basicFieldTypes {
		t.Run(fmt.Sprintf("Field Type %s", string(fieldType)), func(t *testing.T) {

			testData := []struct {
				input    resourcemanager.TerraformSchemaFieldDefinition
				expected string
			}{
				{
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeSet,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeSet,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeSet,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeSet,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeSet,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
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
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeSet,
							NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
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
				helper := pluginSdkAttributesHelpers{}
				actual, err := helper.codeForPluginSdkAttribute(testCase.input, true)
				if err != nil {
					if testCase.expected == "" {
						continue
					}

					t.Fatalf("unexpected error for index %d: %+v", i, err)
				}
				if testCase.expected == "" {
					t.Fatalf("expected an error but didn't get one for index %d", i)
				}
				assertTemplatedCodeMatches(t, testCase.expected, *actual)
			}
		})
	}
}

func TestPluginSdkAttributes_CodeForSetOfReferenceType(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaFieldDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeSet,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeSet,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeSet,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeSet,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeSet,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeSet,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
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
		helper := pluginSdkAttributesHelpers{
			schemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"NestedSchemaModel": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"nested_field": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
							Optional: true,
						},
					},
				},
			},
		}
		actual, err := helper.codeForPluginSdkAttribute(testCase.input, true)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d: %+v", i, err)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, *actual)
	}
}
