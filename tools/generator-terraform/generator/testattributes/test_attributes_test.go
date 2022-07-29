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
			"required_bool_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Boolean",
				},
				Required: true,
			},
			"required_float_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Float",
				},
				Required: true,
			},
			"required_int_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Integer",
				},
				Required: true,
			},
			"required_string_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "String",
				},
				Required: true,
			},
			"required_list_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
					},
				},
				Required: true,
			},
			"required_set_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
					},
				},
				Required: true,
			},
		},
	}
	expected := `
	required_bool_attribute  = false
	required_float_attribute = 10.1
	required_int_attribute   = 15
	required_list_attribute {
		required_nested_bool   = false
		required_nested_string = "foo"
	}
	required_set_attribute {
		required_nested_bool   = false
		required_nested_string = "foo"
	}
	required_string_attribute = "foo"
`

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"NestedSchemaModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"required_nested_string": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
					},
					"required_nested_bool": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						Required: true,
					},
					"optional_nested_string": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
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
			"required_bool_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Boolean",
				},
				Required: true,
			},
			"required_float_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Float",
				},
				Required: true,
			},
			"optional_int_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Integer",
				},
				Optional: true,
			},
			"optional_string_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "String",
				},
				Optional: true,
			},
			"required_list_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
					},
				},
				Required: true,
			},
			"optional_set_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("NestedSchemaModel"),
					},
				},
				Optional: true,
			},
		},
	}
	expected := `
	required_bool_attribute  = false
	required_float_attribute = 10.1
	required_list_attribute {
		required_nested_bool   = false
		required_nested_string = "foo"
		optional_nested_string = "foo"
	}
	optional_int_attribute = 15
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
					"required_nested_string": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
					},
					"required_nested_bool": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						Required: true,
					},
					"optional_nested_string": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
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
