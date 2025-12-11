// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package docs

import (
	"strings"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

// NOTE: in all of these we should only be outputting the top-level arguments, the blocks themselves need to be output
// in the blocks section

func TestComponentArguments_TopLevelOnly(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"RequiredInteger": {
						HCLName: "required_integer",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for required_integer.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{1, 2, 3},
							},
						},
					},
					"OptionalInteger": {
						HCLName: "optional_integer",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for optional_integer.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{4, 5, 6},
							},
						},
					},
					"ComputedInteger": {
						HCLName: "computed_integer",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for computed_integer.",
						},
					},
					"RequiredString": {
						HCLName: "required_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for required_string.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"BooleanItem": {
						HCLName: "boolean_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for boolean_item.",
						},
					},
					"OptionalString": {
						HCLName: "optional_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for optional_string.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"ComputedString": {
						HCLName: "computed_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
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
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"OptionalNestedItem": {
						Optional: true,
						HCLName:  "optional_nested_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("NestedSchema"),
						},
					},
					"RequiredInteger": {
						HCLName: "required_integer",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for required_integer.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{1, 2, 3},
							},
						},
					},
					"OptionalInteger": {
						HCLName: "optional_integer",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for optional_integer.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{4, 5, 6},
							},
						},
					},
					"ComputedInteger": {
						HCLName: "computed_integer",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for computed_integer.",
						},
					},
					"RequiredNestedItem": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("RequiredNestedSchema"),
						},
						Required: true,
						HCLName:  "required_nested_item",
					},
					"RequiredString": {
						HCLName: "required_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for required_string.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"BooleanItem": {
						HCLName: "boolean_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for boolean_item.",
						},
					},
					"OptionalString": {
						HCLName: "optional_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for optional_string.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"ComputedString": {
						HCLName: "computed_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for computed_string.",
						},
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
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for nested_item.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"AnotherNestedItem": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("AnotherNestedSchema"),
						},
						Optional: true,
						HCLName:  "another_nested_item",
					},
					"ComputedItem": {
						HCLName: "computed_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for computed_string.",
						},
					},
				},
			},
			"RequiredNestedSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"OptionalItem": {
						HCLName: "optional_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for optional_item.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"ComputedItem": {
						HCLName: "computed_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for computed_item.",
						},
					},
					"RequiredItem": {
						HCLName: "required_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for required_item.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
					"BooleanItem": {
						HCLName: "boolean_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for boolean_item.",
						},
					},
				},
			},
			"AnotherNestedSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"OptionalItem": {
						HCLName: "optional_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for optional_item.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
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
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"Identity": {
						Optional: true,
						HCLName:  "identity",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
					},
					"MakeSounds": {
						Required: true,
						HCLName:  "make_sounds",
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Specifies whether this blobby instance makes sounds.",
						},
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
					},
					"NumberOfSpots": {
						Optional: true,
						HCLName:  "number_of_spots",
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Specifies the number of spots this blobby instance should have.",
						},
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		Details: models.TerraformResourceDefinition{
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
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"Identity": {
						Optional: true,
						HCLName:  "identity",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
					},
					"MakeSounds": {
						Required: true,
						HCLName:  "make_sounds",
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Specifies whether this blobby instance makes sounds.",
						},
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
					},
					"NumberOfSpots": {
						Optional: true,
						HCLName:  "number_of_spots",
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Specifies the number of spots this blobby instance should have.",
						},
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		Details: models.TerraformResourceDefinition{
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
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"Identity": {
						Optional: true,
						HCLName:  "identity",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
					},
					"MakeSounds": {
						Required: true,
						HCLName:  "make_sounds",
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Specifies whether this blobby instance makes sounds.",
						},
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
					},
					"NumberOfSpots": {
						Optional: true,
						HCLName:  "number_of_spots",
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Specifies the number of spots this blobby instance should have.",
						},
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		Details: models.TerraformResourceDefinition{
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
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"Identity": {
						Optional: true,
						HCLName:  "identity",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
					},
					"MakeSounds": {
						Required: true,
						HCLName:  "make_sounds",
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Specifies whether this blobby instance makes sounds.",
						},
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
					},
					"NumberOfSpots": {
						Optional: true,
						HCLName:  "number_of_spots",
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Specifies the number of spots this blobby instance should have.",
						},
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		Details: models.TerraformResourceDefinition{
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
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"Blobby": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("BlobbySchema"),
						},
						Optional: true,
						HCLName:  "blobby",
					},
					"OptionalNestedItem": {
						Optional: true,
						HCLName:  "optional_nested_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("NestedSchema"),
						},
					},
				},
			},
			"NestedSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"Blobby": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("BlobbySchema"),
						},
						Optional: true,
						HCLName:  "blobby",
					},
				},
			},
			"BlobbySchema": {
				Fields: map[string]models.TerraformSchemaField{
					"MakesSounds": {
						HCLName: "makes_sounds",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
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
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"SomeNestedItem": {
						Optional: true,
						HCLName:  "some_nested_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("NestedSchema"),
						},
					},
					"OtherNestedItem": {
						Optional: true,
						HCLName:  "other_nested_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("NestedSchema"),
						},
					},
				},
			},
			"NestedSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"Blobby": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("BlobbySchema"),
						},
						Optional: true,
						HCLName:  "blobby",
					},
				},
			},
			"BlobbySchema": {
				Fields: map[string]models.TerraformSchemaField{
					"MakesSounds": {
						HCLName: "makes_sounds",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
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
	input := models.TerraformSchemaField{
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			ReferenceName: pointer.To("Other"),
			Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
		},
		Computed: false,
		ForceNew: false,
		HCLName:  "some_item",
		Optional: true,
		Required: false,
	}
	actual, err := documentationLineForArgument(input, "", "Example Resource")
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := "* `some_item` - (Optional) A `some_item` block as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForArgument_ReferencingAList(t *testing.T) {
	input := models.TerraformSchemaField{
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type: models.ListTerraformSchemaObjectDefinitionType,
			NestedObject: &models.TerraformSchemaObjectDefinition{
				ReferenceName: pointer.To("Other"),
				Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
			},
		},
		Computed: false,
		ForceNew: false,
		HCLName:  "some_item",
		Optional: true,
		Required: false,
	}
	actual, err := documentationLineForArgument(input, "", "Example Resource")
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := "* `some_item` - (Optional) A list of `some_item` blocks as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForArgument_ReferencingASet(t *testing.T) {
	input := models.TerraformSchemaField{
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type: models.SetTerraformSchemaObjectDefinitionType,
			NestedObject: &models.TerraformSchemaObjectDefinition{
				ReferenceName: pointer.To("Other"),
				Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
			},
		},
		Computed: false,
		ForceNew: false,
		HCLName:  "some_item",
		Optional: true,
		Required: false,
	}
	actual, err := documentationLineForArgument(input, "", "Example Resource")
	if err != nil {
		t.Fatal(err.Error())
	}
	// Sets are technically different internally, but still exposed to users in the same fashion, so we reuse `List` here
	expected := "* `some_item` - (Optional) A list of `some_item` blocks as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForArgument_LocationAbove(t *testing.T) {
	// The block `person` contains a field `animal`
	input := models.TerraformSchemaField{
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
			ReferenceName: pointer.To("Animal"),
		},
		HCLName:  "animal",
		Optional: true,
	}
	actual, err := documentationLineForArgument(input, "person", "Some Resource")
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := "* `animal` - (Optional) An `animal` block as defined above."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForArgument_LocationBelow(t *testing.T) {
	// The block `cat` contains a field `napping_place`
	input := models.TerraformSchemaField{
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
			ReferenceName: pointer.To("NappingPlace"),
		},
		HCLName:  "napping_place",
		Optional: true,
	}
	actual, err := documentationLineForArgument(input, "cat", "Some Resource")
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := "* `napping_place` - (Optional) A `napping_place` block as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForArgument_LocationForTopLevelItemShouldAlwaysSayBelow(t *testing.T) {
	input := models.TerraformSchemaField{
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
			ReferenceName: pointer.To("Animal"),
		},
		HCLName:  "animal",
		Optional: true,
	}
	actual, err := documentationLineForArgument(input, "", "Some Resource")
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := "* `animal` - (Optional) An `animal` block as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
