package testattributes

import (
	"fmt"
	"testing"

	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestRequiredTestAttributes_CodeForBasicFields(t *testing.T) {
	input := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"RequiredBoolAttribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Boolean",
				},
				HclName:  "required_bool_attribute",
				Required: true,
			},
			"RequiredFloatAttribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Float",
				},
				HclName:  "required_float_attribute",
				Required: true,
			},
			"RequiredIntAttribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Integer",
				},
				HclName:  "required_int_attribute",
				Required: true,
			},
			"RequiredStringAttribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "String",
				},
				HclName:  "required_string_attribute",
				Required: true,
			},
			"RequiredListAttribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
					},
				},
				HclName:  "required_list_attribute",
				Required: true,
			},
			"RequiredSetAttribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
					},
				},
				HclName:  "required_set_attribute",
				Required: true,
			},
			"RequiredStringList": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeSet,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: "String",
					},
				},
				HclName:  "required_string_list",
				Required: true,
			},
			"RequiredFloatSet": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeSet,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: "Float",
					},
				},
				HclName:  "required_float_set",
				Required: true,
			},
			"OptionalIntSet": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeSet,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: "Integer",
					},
				},
				HclName:  "optional_int_set",
				Optional: true,
			},
			"RequiredReference": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: stringPointer("NestedSchemaModel"),
				},
				HclName:  "required_reference",
				Required: true,
			},
		},
	}
	expected := `
	required_bool_attribute  = false
	required_float_attribute = 10.1
	required_float_set = [1.1, 2.2, 3.3]
	required_int_attribute = 15
	required_list_attribute {
		required_nested_bool   = false
		required_nested_string = "foo"
	}
	required_reference {
		required_nested_bool   = false
		required_nested_string = "foo"
	}
	required_set_attribute {
		required_nested_bool   = false
		required_nested_string = "foo"
	}
	required_string_attribute = "foo"
	required_string_list = ["foo", "baz"]
`

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"NestedSchemaModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"RequiredNestedString": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "required_nested_string",
						Required: true,
					},
					"RequiredNestedBool": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						HclName:  "required_nested_bool",
						Required: true,
					},
					"OptionalNestedString": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "optional_nested_string",
						Optional: true,
					},
				},
			},
		},
	}
	err := helper.GetAttributesForTests(input, *file.Body(), true)
	if err != nil {
		t.Fatalf("unexpected error: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, fmt.Sprintf("%s", file.Bytes()))
}

func TestRequiredAndOptionalTestAttributes_CodeForBasicField(t *testing.T) {
	input := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"RequiredBoolAttribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Boolean",
				},
				HclName:  "required_bool_attribute",
				Required: true,
			},
			"RequiredFloatAttribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Float",
				},
				HclName:  "required_float_attribute",
				Required: true,
			},
			"OptionalIntAttribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Integer",
				},
				HclName:  "optional_int_attribute",
				Optional: true,
			},
			"OptionalStringAttribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "String",
				},
				HclName:  "optional_string_attribute",
				Optional: true,
			},
			"RequiredListAttribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
					},
				},
				HclName:  "required_list_attribute",
				Required: true,
			},
			"OptionalSetAttribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
					},
				},
				HclName:  "optional_set_attribute",
				Optional: true,
			},
			"RequiredStringList": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeSet,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: "String",
					},
				},
				HclName:  "required_string_list",
				Required: true,
			},
			"RequiredFloatSet": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeSet,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: "Float",
					},
				},
				HclName:  "required_float_set",
				Required: true,
			},
			"OptionalIntSet": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeSet,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: "Integer",
					},
				},
				HclName:  "optional_int_set",
				Optional: true,
			},
			"OptionalReference": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: stringPointer("NestedSchemaModel"),
				},
				HclName:  "optional_reference",
				Optional: true,
			},
		},
	}
	expected := `
	required_bool_attribute  = false
	required_float_attribute = 10.1
	required_float_set = [1.1, 2.2, 3.3]
	required_list_attribute {
		required_nested_bool   = false
		required_nested_string = "foo"
		optional_nested_string = "foo"
	}
	required_string_list = ["foo", "baz"]
	optional_int_attribute = 15
	optional_int_set = [1, 2, 3]
	optional_reference {
		required_nested_bool   = false
		required_nested_string = "foo"
		optional_nested_string = "foo"
	}
	optional_set_attribute {
		required_nested_bool   = false
		required_nested_string = "foo"
		optional_nested_string = "foo"
	}
	optional_string_attribute = "foo"
`

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"NestedSchemaModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"RequiredNestedString": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "required_nested_string",
						Required: true,
					},
					"RequiredNestedBool": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						HclName:  "required_nested_bool",
						Required: true,
					},
					"OptionalNestedString": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "optional_nested_string",
						Optional: true,
					},
				},
			},
		},
	}
	err := helper.GetAttributesForTests(input, *file.Body(), false)
	if err != nil {
		t.Fatalf("unexpected error: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, fmt.Sprintf("%s", file.Bytes()))
}

func TestStringAttributes(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaModelDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaModelDefinition{
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "name",
						Optional: true,
					},
				},
			},
			expected: `
name ="acctest-${local.random_integer}"
`,
		},
		{
			input: resourcemanager.TerraformSchemaModelDefinition{
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"ResourceGroupName": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "resource_group_name",
						Optional: true,
					},
				},
			},
			expected: `
  // todo add azurerm_resource_group.test to template
  resource_group_name = azurerm_resource_group.test.name
`,
		},
	}

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{}
	for i, testCase := range testData {
		err := helper.GetAttributesForTests(testCase.input, *file.Body(), false)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, fmt.Sprintf("%s", file.Bytes()))
		file.Body().Clear()
	}
}
