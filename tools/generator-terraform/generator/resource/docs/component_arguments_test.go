package docs

import (
	"strings"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

// NOTE: in all of these we should only be outputting the top-level arguments, the blocks themselves need to be output
// in the blocks section

func TestComponentArguments_TopLevelOnly(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModelResourceSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"RequiredInteger": {
						HclName: "required_integer",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
						Required: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for required_integer.",
						},
						Validation: &resourcemanager.TerraformSchemaValidationDefinition{
							Type: "PossibleValues",
							PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
								Values: []interface{}{1, 2, 3},
							},
						},
					},
					"OptionalInteger": {
						HclName: "optional_integer",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
						Optional: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for optional_integer.",
						},
						Validation: &resourcemanager.TerraformSchemaValidationDefinition{
							Type: "PossibleValues",
							PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
								Values: []interface{}{4, 5, 6},
							},
						},
					},
					"ComputedInteger": {
						HclName: "computed_integer",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
						Computed: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for computed_integer.",
						},
					},
					"RequiredString": {
						HclName: "required_string",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for required_string.",
						},
						Validation: &resourcemanager.TerraformSchemaValidationDefinition{
							Type: "PossibleValues",
							PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"BooleanItem": {
						HclName: "boolean_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						Optional: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for boolean_item.",
						},
					},
					"OptionalString": {
						HclName: "optional_string",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Optional: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for optional_string.",
						},
						Validation: &resourcemanager.TerraformSchemaValidationDefinition{
							Type: "PossibleValues",
							PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"ComputedString": {
						HclName: "computed_string",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Computed: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for computed_string.",
						},
					},
				},
			},
		},
	}
	actual, err := codeForArgumentsReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`
## Arguments Reference

The following arguments are supported:

* 'required_integer' - (Required) Description for required_integer. Possible values are '1', '2' and '3'.

* 'required_string' - (Required) Description for required_string. Possible values are 'string1', 'string2' and 'string3'.

* 'boolean_item' - (Optional) Description for boolean_item. Possible values are 'true' and 'false'.

* 'optional_integer' - (Optional) Description for optional_integer. Possible values are '4', '5' and '6'.

* 'optional_string' - (Optional) Description for optional_string. Possible values are 'string1', 'string2' and 'string3'.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentArguments_WithNestedBlocks(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModelResourceSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"OptionalNestedItem": {
						Optional: true,
						HclName:  "optional_nested_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("NestedSchema"),
						},
					},
					"RequiredInteger": {
						HclName: "required_integer",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
						Required: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for required_integer.",
						},
						Validation: &resourcemanager.TerraformSchemaValidationDefinition{
							Type: "PossibleValues",
							PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
								Values: []interface{}{1, 2, 3},
							},
						},
					},
					"OptionalInteger": {
						HclName: "optional_integer",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
						Optional: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for optional_integer.",
						},
						Validation: &resourcemanager.TerraformSchemaValidationDefinition{
							Type: "PossibleValues",
							PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
								Values: []interface{}{4, 5, 6},
							},
						},
					},
					"ComputedInteger": {
						HclName: "computed_integer",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
						Computed: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for computed_integer.",
						},
					},
					"RequiredNestedItem": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("RequiredNestedSchema"),
						},
						Required: true,
						HclName:  "required_nested_item",
					},
					"RequiredString": {
						HclName: "required_string",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for required_string.",
						},
						Validation: &resourcemanager.TerraformSchemaValidationDefinition{
							Type: "PossibleValues",
							PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"BooleanItem": {
						HclName: "boolean_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						Optional: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for boolean_item.",
						},
					},
					"OptionalString": {
						HclName: "optional_string",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Optional: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for optional_string.",
						},
						Validation: &resourcemanager.TerraformSchemaValidationDefinition{
							Type: "PossibleValues",
							PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"ComputedString": {
						HclName: "computed_string",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Computed: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for computed_string.",
						},
					},
				},
			},
			"NestedSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"NestedItem": {
						HclName: "nested_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Optional: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for nested_item.",
						},
						Validation: &resourcemanager.TerraformSchemaValidationDefinition{
							Type: "PossibleValues",
							PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"AnotherNestedItem": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("AnotherNestedSchema"),
						},
						Optional: true,
						HclName:  "another_nested_item",
					},
					"ComputedItem": {
						HclName: "computed_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Computed: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for computed_string.",
						},
					},
				},
			},
			"RequiredNestedSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"OptionalItem": {
						HclName: "optional_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Optional: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for optional_item.",
						},
						Validation: &resourcemanager.TerraformSchemaValidationDefinition{
							Type: "PossibleValues",
							PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"ComputedItem": {
						HclName: "computed_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Computed: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for computed_item.",
						},
					},
					"RequiredItem": {
						HclName: "required_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for required_item.",
						},
						Validation: &resourcemanager.TerraformSchemaValidationDefinition{
							Type: "PossibleValues",
							PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"BooleanItem": {
						HclName: "boolean_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						Optional: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for boolean_item.",
						},
					},
				},
			},
			"AnotherNestedSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"OptionalItem": {
						HclName: "optional_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Optional: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for optional_item.",
						},
						Validation: &resourcemanager.TerraformSchemaValidationDefinition{
							Type: "PossibleValues",
							PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
				},
			},
		},
	}
	actual, err := codeForArgumentsReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// NOTE: the nested blocks are intentionally not output, since these should be output within the `blocks reference` section
	expected := strings.ReplaceAll(`
## Arguments Reference

The following arguments are supported:

* 'required_integer' - (Required) Description for required_integer. Possible values are '1', '2' and '3'.

* 'required_nested_item' - (Required) A 'required_nested_item' block as defined below. 

* 'required_string' - (Required) Description for required_string. Possible values are 'string1', 'string2' and 'string3'.

* 'boolean_item' - (Optional) Description for boolean_item. Possible values are 'true' and 'false'.

* 'optional_integer' - (Optional) Description for optional_integer. Possible values are '4', '5' and '6'.

* 'optional_nested_item' - (Optional) An 'optional_nested_item' block as defined below. 

* 'optional_string' - (Optional) Description for optional_string. Possible values are 'string1', 'string2' and 'string3'.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentArguments_WithIdentitySystemAssigned(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModelResourceSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Identity": {
						Optional: true,
						HclName:  "identity",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
						},
					},
					"MakeSounds": {
						Required: true,
						HclName:  "make_sounds",
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Specifies whether this blobby instance makes sounds.",
						},
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
					},
					"NumberOfSpots": {
						Optional: true,
						HclName:  "number_of_spots",
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Specifies the number of spots this blobby instance should have.",
						},
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
					},
				},
			},
		},
		Details: resourcemanager.TerraformResourceDetails{
			DisplayName: "blobby instance",
		},
	}
	actual, err := codeForArgumentsReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`
## Arguments Reference

The following arguments are supported:

* 'make_sounds' - (Required) Specifies whether this blobby instance makes sounds. Possible values are 'true' and 'false'.

* 'identity' - (Optional) An 'identity' block as defined below.

* 'number_of_spots' - (Optional) Specifies the number of spots this blobby instance should have.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentArguments_WithIdentitySystemAndUserAssigned(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModelResourceSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Identity": {
						Optional: true,
						HclName:  "identity",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
						},
					},
					"MakeSounds": {
						Required: true,
						HclName:  "make_sounds",
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Specifies whether this blobby instance makes sounds.",
						},
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
					},
					"NumberOfSpots": {
						Optional: true,
						HclName:  "number_of_spots",
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Specifies the number of spots this blobby instance should have.",
						},
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
					},
				},
			},
		},
		Details: resourcemanager.TerraformResourceDetails{
			DisplayName: "blobby instance",
		},
	}
	actual, err := codeForArgumentsReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`
## Arguments Reference

The following arguments are supported:

* 'make_sounds' - (Required) Specifies whether this blobby instance makes sounds. Possible values are 'true' and 'false'.

* 'identity' - (Optional) An 'identity' block as defined below.

* 'number_of_spots' - (Optional) Specifies the number of spots this blobby instance should have.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentArguments_WithIdentitySystemOrUserAssigned(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModelResourceSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Identity": {
						Optional: true,
						HclName:  "identity",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
						},
					},
					"MakeSounds": {
						Required: true,
						HclName:  "make_sounds",
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Specifies whether this blobby instance makes sounds.",
						},
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
					},
					"NumberOfSpots": {
						Optional: true,
						HclName:  "number_of_spots",
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Specifies the number of spots this blobby instance should have.",
						},
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
					},
				},
			},
		},
		Details: resourcemanager.TerraformResourceDetails{
			DisplayName: "blobby instance",
		},
	}
	actual, err := codeForArgumentsReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`
## Arguments Reference

The following arguments are supported:

* 'make_sounds' - (Required) Specifies whether this blobby instance makes sounds. Possible values are 'true' and 'false'.

* 'identity' - (Optional) An 'identity' block as defined below.

* 'number_of_spots' - (Optional) Specifies the number of spots this blobby instance should have.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentArguments_WithIdentityUserAssigned(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModelResourceSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Identity": {
						Optional: true,
						HclName:  "identity",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
						},
					},
					"MakeSounds": {
						Required: true,
						HclName:  "make_sounds",
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Specifies whether this blobby instance makes sounds.",
						},
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
					},
					"NumberOfSpots": {
						Optional: true,
						HclName:  "number_of_spots",
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Specifies the number of spots this blobby instance should have.",
						},
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
					},
				},
			},
		},
		Details: resourcemanager.TerraformResourceDetails{
			DisplayName: "blobby instance",
		},
	}
	actual, err := codeForArgumentsReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`
## Arguments Reference

The following arguments are supported:

* 'make_sounds' - (Required) Specifies whether this blobby instance makes sounds. Possible values are 'true' and 'false'.

* 'identity' - (Optional) An 'identity' block as defined below.

* 'number_of_spots' - (Optional) Specifies the number of spots this blobby instance should have.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentArguments_WithTheSameModelUsedAtTheTopLevelAndInMultipleNestedBlocks(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModelResourceSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Blobby": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("BlobbySchema"),
						},
						Optional: true,
						HclName:  "blobby",
					},
					"OptionalNestedItem": {
						Optional: true,
						HclName:  "optional_nested_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("NestedSchema"),
						},
					},
				},
			},
			"NestedSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Blobby": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("BlobbySchema"),
						},
						Optional: true,
						HclName:  "blobby",
					},
				},
			},
			"BlobbySchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"MakesSounds": {
						HclName: "makes_sounds",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						Optional: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for makes_sounds.",
						},
					},
				},
			},
		},
	}
	actual, err := codeForArgumentsReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// we should only output the block names, the blocks themselves are output via the `blocks reference` section
	expected := strings.ReplaceAll(`
## Arguments Reference

The following arguments are supported:

* 'blobby' - (Optional) A 'blobby' block as defined below.

* 'optional_nested_item' - (Optional) An 'optional_nested_item' block as defined below.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentArguments_WithTheSameModelUsedInMultipleNestedBlocks(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModelResourceSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeNestedItem": {
						Optional: true,
						HclName:  "some_nested_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("NestedSchema"),
						},
					},
					"OtherNestedItem": {
						Optional: true,
						HclName:  "other_nested_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("NestedSchema"),
						},
					},
				},
			},
			"NestedSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Blobby": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("BlobbySchema"),
						},
						Optional: true,
						HclName:  "blobby",
					},
				},
			},
			"BlobbySchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"MakesSounds": {
						HclName: "makes_sounds",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						Optional: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
							Markdown: "Description for makes_sounds.",
						},
					},
				},
			},
		},
	}
	actual, err := codeForArgumentsReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// we should only output the block names, the blocks themselves are output via the `blocks reference` section

	expected := strings.ReplaceAll(`
## Arguments Reference

The following arguments are supported:

* 'other_nested_item' - (Optional) An 'other_nested_item' block as defined below.

* 'some_nested_item' - (Optional) A 'some_nested_item' block as defined below.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForArgument_ReferencingAModel(t *testing.T) {
	input := resourcemanager.TerraformSchemaFieldDefinition{
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			ReferenceName: pointer.To("Other"),
			Type:          resourcemanager.TerraformSchemaFieldTypeReference,
		},
		Computed: false,
		ForceNew: false,
		HclName:  "some_item",
		Optional: true,
		Required: false,
	}
	actual, err := documentationLineForArgument(input, "", "Example Resource")
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := "* `some_item` - (Optional) A `some_item` block as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForArgument_ReferencingAList(t *testing.T) {
	input := resourcemanager.TerraformSchemaFieldDefinition{
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeList,
			NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
				ReferenceName: pointer.To("Other"),
				Type:          resourcemanager.TerraformSchemaFieldTypeReference,
			},
		},
		Computed: false,
		ForceNew: false,
		HclName:  "some_item",
		Optional: true,
		Required: false,
	}
	actual, err := documentationLineForArgument(input, "", "Example Resource")
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := "* `some_item` - (Optional) A list of `some_item` blocks as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForArgument_ReferencingASet(t *testing.T) {
	input := resourcemanager.TerraformSchemaFieldDefinition{
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeSet,
			NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
				ReferenceName: pointer.To("Other"),
				Type:          resourcemanager.TerraformSchemaFieldTypeReference,
			},
		},
		Computed: false,
		ForceNew: false,
		HclName:  "some_item",
		Optional: true,
		Required: false,
	}
	actual, err := documentationLineForArgument(input, "", "Example Resource")
	if err != nil {
		t.Fatalf(err.Error())
	}
	// Sets are technically different internally, but still exposed to users in the same fashion, so we reuse `List` here
	expected := "* `some_item` - (Optional) A list of `some_item` blocks as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForArgument_LocationAbove(t *testing.T) {
	// The block `person` contains a field `animal`
	input := resourcemanager.TerraformSchemaFieldDefinition{
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type:          resourcemanager.TerraformSchemaFieldTypeReference,
			ReferenceName: pointer.To("Animal"),
		},
		HclName:  "animal",
		Optional: true,
	}
	actual, err := documentationLineForArgument(input, "person", "Some Resource")
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := "* `animal` - (Optional) An `animal` block as defined above."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForArgument_LocationBelow(t *testing.T) {
	// The block `cat` contains a field `napping_place`
	input := resourcemanager.TerraformSchemaFieldDefinition{
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type:          resourcemanager.TerraformSchemaFieldTypeReference,
			ReferenceName: pointer.To("NappingPlace"),
		},
		HclName:  "napping_place",
		Optional: true,
	}
	actual, err := documentationLineForArgument(input, "cat", "Some Resource")
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := "* `napping_place` - (Optional) A `napping_place` block as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForArgument_LocationForTopLevelItemShouldAlwaysSayBelow(t *testing.T) {
	input := resourcemanager.TerraformSchemaFieldDefinition{
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type:          resourcemanager.TerraformSchemaFieldTypeReference,
			ReferenceName: pointer.To("Animal"),
		},
		HclName:  "animal",
		Optional: true,
	}
	actual, err := documentationLineForArgument(input, "", "Some Resource")
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := "* `animal` - (Optional) An `animal` block as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
