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

func TestComponentBlocks_ModelsSingle(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"RequiredNestedItem": {
						HCLName: "required_nested_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("RequiredNestedSchema"),
						},
						Required: true,
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
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'required_nested_item' Block

The 'required_nested_item' block supports the following arguments:

* 'required_item' - (Required) Description for required_item. Possible values are 'string1', 'string2' and 'string3'.

* 'boolean_item' - (Optional) Description for boolean_item. Possible values are 'true' and 'false'.

* 'optional_item' - (Optional) Description for optional_item. Possible values are 'string1', 'string2' and 'string3'.

In addition to the arguments defined above, the 'required_nested_item' block exports the following attributes:

* 'computed_item' - Description for computed_item.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentBlocks_ModelsSingleArgumentsOnly(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"RequiredNestedItem": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("RequiredNestedSchema"),
						},
						Required: true,
						HCLName:  "required_nested_item",
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
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'required_nested_item' Block

The 'required_nested_item' block supports the following arguments:

* 'required_item' - (Required) Description for required_item. Possible values are 'string1', 'string2' and 'string3'.

* 'boolean_item' - (Optional) Description for boolean_item. Possible values are 'true' and 'false'.

* 'optional_item' - (Optional) Description for optional_item. Possible values are 'string1', 'string2' and 'string3'.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentBlocks_ModelsSingleAttributesOnly(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"RequiredNestedItem": {
						HCLName: "required_nested_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("RequiredNestedSchema"),
						},
						Required: true,
					},
				},
			},
			"RequiredNestedSchema": {
				Fields: map[string]models.TerraformSchemaField{
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
				},
			},
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'required_nested_item' Block

The 'required_nested_item' block exports the following attributes:

* 'computed_item' - Description for computed_item.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentBlocks_ModelsMultiple(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
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
					"ZAnotherNestedItem2": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("ZAnotherNestedSchema2"),
						},
						Optional: true,
						HCLName:  "z_another_nested_item_2",
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
			"ZAnotherNestedSchema2": {
				Fields: map[string]models.TerraformSchemaField{
					"OptionalItem2": {
						HCLName: "optional_item_2",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for optional_item.",
						},
						Validation: models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{"string4", "string5", "string6"},
							},
						},
					},
				},
			},
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'another_nested_item' Block

The 'another_nested_item' block supports the following arguments:

* 'optional_item' - (Optional) Description for optional_item. Possible values are 'string1', 'string2' and 'string3'.

### 'optional_nested_item' Block

The 'optional_nested_item' block supports the following arguments:

* 'another_nested_item' - (Optional) An 'another_nested_item' block as defined above. 

* 'nested_item' - (Optional) Description for nested_item. Possible values are 'string1', 'string2' and 'string3'.

* 'z_another_nested_item_2' - (Optional) A 'z_another_nested_item_2' block as defined below. 

In addition to the arguments defined above, the 'optional_nested_item' block exports the following attributes:

* 'computed_item' - Description for computed_string.

### 'required_nested_item' Block

The 'required_nested_item' block supports the following arguments:

* 'required_item' - (Required) Description for required_item. Possible values are 'string1', 'string2' and 'string3'.

* 'boolean_item' - (Optional) Description for boolean_item. Possible values are 'true' and 'false'.

* 'optional_item' - (Optional) Description for optional_item. Possible values are 'string1', 'string2' and 'string3'.

In addition to the arguments defined above, the 'required_nested_item' block exports the following attributes:

* 'computed_item' - Description for computed_item.

### 'z_another_nested_item_2' Block

The 'z_another_nested_item_2' block supports the following arguments:

* 'optional_item_2' - (Optional) Description for optional_item. Possible values are 'string4', 'string5' and 'string6'.

`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentBlocks_ModelsMultipleNestingTheSameModelShouldBeDeduped(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"First": {
						HCLName: "first",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("First"),
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for first.",
						},
					},
					"Second": {
						HCLName: "second",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("Second"),
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for second.",
						},
					},
				},
			},
			"Example": {
				Fields: map[string]models.TerraformSchemaField{
					"SomeField": {
						HCLName: "some_field",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for some_field.",
						},
					},
					"ComputedField": {
						HCLName: "computed_field",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for computed_field.",
						},
					},
				},
			},
			"First": {
				Fields: map[string]models.TerraformSchemaField{
					"Example": {
						HCLName: "example",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("Example"),
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for example.",
						},
					},
				},
			},
			"Second": {
				Fields: map[string]models.TerraformSchemaField{
					"Example": {
						HCLName: "example",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("Example"),
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for example.",
						},
					},
				},
			},
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'example' Block

The 'example' block supports the following arguments:

* 'some_field' - (Optional) Description for some_field. 

In addition to the arguments defined above, the 'example' block exports the following attributes:

* 'computed_field' - Description for computed_field.

### 'first' Block

The 'first' block supports the following arguments:

* 'example' - (Required) An 'example' block as defined above. Description for example.

### 'second' Block

The 'second' block supports the following arguments:

* 'example' - (Required) An 'example' block as defined above. Description for example.

`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentBlocks_ModelsMultipleNestingDifferentModelsWithTheSameNameShouldBeOutputUniquely(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"First": {
						HCLName: "first",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("First"),
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for first.",
						},
					},
					"Second": {
						HCLName: "second",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("Second"),
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for second.",
						},
					},
				},
			},
			"Example1": {
				Fields: map[string]models.TerraformSchemaField{
					"SomeField": {
						HCLName: "some_field",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for some_field.",
						},
					},
					"ComputedField": {
						HCLName: "computed_field",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for computed_field.",
						},
					},
				},
			},
			"Example2": {
				Fields: map[string]models.TerraformSchemaField{
					"OtherField": {
						HCLName: "other_field",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for other_field.",
						},
					},
					"ComputedField": {
						HCLName: "computed_field",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for computed_field.",
						},
					},
				},
			},
			"First": {
				Fields: map[string]models.TerraformSchemaField{
					"Example": {
						HCLName: "example",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("Example1"),
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for example.",
						},
					},
				},
			},
			"Second": {
				Fields: map[string]models.TerraformSchemaField{
					"Example": {
						HCLName: "example",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("Example2"),
						},
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for example.",
						},
					},
				},
			},
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'example' Block (within the 'first' block)

The 'example' block within the 'first' block supports the following arguments:

* 'some_field' - (Optional) Description for some_field. 

In addition to the arguments defined above, the 'example' block within the 'first' block exports the following attributes:

* 'computed_field' - Description for computed_field.

### 'example' Block (within the 'second' block)

The 'example' block within the 'second' block supports the following arguments:

* 'other_field' - (Optional) Description for other_field. 

In addition to the arguments defined above, the 'example' block within the 'second' block exports the following attributes:

* 'computed_field' - Description for computed_field.

### 'first' Block

The 'first' block supports the following arguments:

* 'example' - (Required) An 'example' block as defined above. Description for example.

### 'second' Block

The 'second' block supports the following arguments:

* 'example' - (Required) An 'example' block as defined above. Description for example.

`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentBlocks_ModelsReferencingAListOfModels(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"RequiredNestedItem": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("RequiredNestedSchema"),
						},
						Required: true,
						HCLName:  "required_nested_item",
					},
				},
			},
			"RequiredNestedSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"RequiredItem": {
						HCLName: "required_item",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.ListTerraformSchemaObjectDefinitionType,
							NestedObject: &models.TerraformSchemaObjectDefinition{
								Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: pointer.To("NestedModel"),
							},
						},
						Required: true,
					},
				},
			},
			"NestedModel": {
				Fields: map[string]models.TerraformSchemaField{
					"Name": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						HCLName:  "name",
						Required: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "The name of the thing.",
						},
					},
				},
			},
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'required_item' Block

The 'required_item' block supports the following arguments:

* 'name' - (Required) The name of the thing.

### 'required_nested_item' Block

The 'required_nested_item' block supports the following arguments:

* 'required_item' - (Required) A list of 'required_item' blocks as defined above.

`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentBlocks_ModelsAndIdentityShouldBeOrderedAlphabetically(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"First": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("First"),
						},
						Required: true,
						HCLName:  "first",
					},
					"SystemAssignedIdentity": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						HCLName:  "system_assigned_identity",
					},
					"Second": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("Second"),
						},
						Required: true,
						HCLName:  "second",
					},
					"Third": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("Third"),
						},
						Required: true,
						HCLName:  "third",
					},
				},
			},
			"First": {
				Fields: map[string]models.TerraformSchemaField{
					"SomeField": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						HCLName:  "some_field",
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for `some_field`.",
						},
					},
				},
			},
			"Second": {
				Fields: map[string]models.TerraformSchemaField{
					"First": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("First"),
						},
						Optional: true,
						HCLName:  "first",
					},
					"SomeField": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						HCLName:  "some_field",
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for `some_field`.",
						},
					},
				},
			},
			"Third": {
				Fields: map[string]models.TerraformSchemaField{
					"SomeField": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						HCLName:  "some_field",
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for `some_field`.",
						},
					},
				},
			},
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'first' block

The 'first' block supports the following arguments:

* 'some_field' - (Required) Description for 'some_field'.

### 'second' block

The 'second' block supports the following arguments:

* 'some_field' - (Required) Description for 'some_field'.

* 'first' - (Optional) A 'first' block as defined above.

### 'system_assigned_identity' Block

The 'system_assigned_identity' block supports the following arguments:

* 'type' - (Required) Specifies the type of Managed Identity that should be assigned to this Blobby Instance. The only possible value is 'SystemAssigned'.

In addition to the arguments defined above, the 'system_assigned_identity' block exports the following attributes:

* 'principal_id' - The Principal ID for the System-Assigned Managed Identity assigned to this Blobby Instance.

* 'tenant_id' - The Tenant ID for the System-Assigned Managed Identity assigned to this Blobby Instance.

### 'third' block

The 'third' block supports the following arguments:

* 'some_field' - (Required) Description for 'some_field'.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentBlocks_NestedIdentityBlockGetsPulledOut(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"RequiredNestedItem": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("First"),
						},
						Required: true,
						HCLName:  "first",
					},
				},
			},
			"First": {
				Fields: map[string]models.TerraformSchemaField{
					"SomeIdentityField": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						HCLName:  "some_identity_field",
					},
				},
			},
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'first' block

The 'first' block supports the following arguments:

* 'some_identity_field' - (Required) A 'some_identity_field' block as defined below.

### 'some_identity_field' Block

The 'some_identity_field' block supports the following arguments:

* 'type' - (Required) Specifies the type of Managed Identity that should be assigned to this Blobby Instance. The only possible value is 'SystemAssigned'.

In addition to the arguments defined above, the 'some_identity_field' block exports the following attributes:

* 'principal_id' - The Principal ID for the System-Assigned Managed Identity assigned to this Blobby Instance.

* 'tenant_id' - The Tenant ID for the System-Assigned Managed Identity assigned to this Blobby Instance.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentBlocks_IdentitySystemAssigned(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"RequiredNestedItem": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						HCLName:  "required_nested_item",
					},
				},
			},
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'required_nested_item' Block

The 'required_nested_item' block supports the following arguments:

* 'type' - (Required) Specifies the type of Managed Identity that should be assigned to this Blobby Instance. The only possible value is 'SystemAssigned'.

In addition to the arguments defined above, the 'required_nested_item' block exports the following attributes:

* 'principal_id' - The Principal ID for the System-Assigned Managed Identity assigned to this Blobby Instance.

* 'tenant_id' - The Tenant ID for the System-Assigned Managed Identity assigned to this Blobby Instance.
`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentBlocks_IdentitySystemAndUserAssigned(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"RequiredNestedItem": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						HCLName:  "required_nested_item",
					},
				},
			},
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'required_nested_item' Block

The 'required_nested_item' block supports the following arguments:

* 'type' - (Required) Specifies the type of Managed Identity that should be assigned to this Blobby Instance. Possible values are 'SystemAssigned', 'SystemAssigned, UserAssigned' and 'UserAssigned'.

* 'identity_ids' - (Optional) A list of the User Assigned Identity IDs that should be assigned to this Blobby Instance.

In addition to the arguments defined above, the 'required_nested_item' block exports the following attributes:

* 'principal_id' - The Principal ID for the System-Assigned Managed Identity assigned to this Blobby Instance.

* 'tenant_id' - The Tenant ID for the System-Assigned Managed Identity assigned to this Blobby Instance.

`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentBlocks_IdentitySystemOrUserAssigned(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"RequiredNestedItem": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						HCLName:  "required_nested_item",
					},
				},
			},
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'required_nested_item' Block

The 'required_nested_item' block supports the following arguments:

* 'type' - (Required) Specifies the type of Managed Identity that should be assigned to this Blobby Instance. Possible values are 'SystemAssigned' and 'UserAssigned'.

* 'identity_ids' - (Optional) A list of the User Assigned Identity IDs that should be assigned to this Blobby Instance.

In addition to the arguments defined above, the 'required_nested_item' block exports the following attributes:

* 'principal_id' - The Principal ID for the System-Assigned Managed Identity assigned to this Blobby Instance.

* 'tenant_id' - The Tenant ID for the System-Assigned Managed Identity assigned to this Blobby Instance.

`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentBlocks_IdentityUserAssigned(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			DisplayName: "Blobby Instance",
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"RequiredNestedItem": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
						Required: true,
						HCLName:  "required_nested_item",
					},
				},
			},
		},
	}
	actual, err := codeForBlocksReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	expected := strings.ReplaceAll(`## Blocks Reference

### 'required_nested_item' Block

The 'required_nested_item' block supports the following arguments:

* 'identity_ids' - (Required) A list of the User Assigned Identity IDs that should be assigned to this Blobby Instance.

* 'type' - (Required) Specifies the type of Managed Identity that should be assigned to this Blobby Instance. The only possible value is 'UserAssigned'.

`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
