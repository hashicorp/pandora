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

func TestComponentAttributes_TopLevelOnly(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: models.TerraformResourceDefinition{
			DisplayName: "Test Resource",
		},
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
	actual, err := codeForAttributesReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// NOTE: this should only handle the attributes for the top-level model, nested attributes
	// are output within the relevant block within the 'blocks reference' section
	expected := strings.ReplaceAll(`## Attributes Reference

In addition to the Arguments listed above - the following Attributes are exported:

* 'id' - The ID of the Test Resource.

* 'computed_integer' - Description for computed_integer.

* 'computed_string' - Description for computed_string.

---`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentAttributes_NestedBlock(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: models.TerraformResourceDefinition{
			DisplayName: "Test Resource",
		},
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"ComputedNestedItem": {
						Computed: true,
						HCLName:  "computed_nested_item",
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
							PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
								Values: []interface{}{"string1", "string2", "string3"},
							},
						},
					},
				},
			},
		},
	}
	actual, err := codeForAttributesReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// NOTE: this should only handle the attributes for the top-level model, nested attributes
	// are output within the relevant block within the 'blocks reference' section
	expected := strings.ReplaceAll(`## Attributes Reference

In addition to the Arguments listed above - the following Attributes are exported:

* 'id' - The ID of the Test Resource.

* 'computed_integer' - Description for computed_integer.

* 'computed_nested_item' - A 'computed_nested_item' block as defined below. 

* 'computed_string' - Description for computed_string.

---`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentAttributes_WithIdentitySystemAssigned(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: models.TerraformResourceDefinition{
			DisplayName: "Test Resource",
		},
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
					"Identity": {
						HCLName: "identity",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Defines the System Assigned Identity which should be assigned to this Resource.",
						},
					},
				},
			},
		},
	}
	actual, err := codeForAttributesReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// NOTE: this should only handle the attributes for the top-level model, nested attributes
	// are output within the relevant block within the 'blocks reference' section
	expected := strings.ReplaceAll(`## Attributes Reference

In addition to the Arguments listed above - the following Attributes are exported:

* 'id' - The ID of the Test Resource.

* 'computed_integer' - Description for computed_integer.

* 'computed_string' - Description for computed_string.

* 'identity' - An 'identity' block as defined below. Defines the System Assigned Identity which should be assigned to this Resource.

---`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentAttributes_WithIdentitySystemAndUserAssigned(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: models.TerraformResourceDefinition{
			DisplayName: "Test Resource",
		},
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
					"Identity": {
						HCLName: "identity",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Defines the System and User Assigned Identity which should be assigned to this Resource.",
						},
					},
				},
			},
		},
	}
	actual, err := codeForAttributesReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// NOTE: this should only handle the attributes for the top-level model, nested attributes
	// are output within the relevant block within the 'blocks reference' section
	expected := strings.ReplaceAll(`## Attributes Reference

In addition to the Arguments listed above - the following Attributes are exported:

* 'id' - The ID of the Test Resource.

* 'computed_integer' - Description for computed_integer.

* 'computed_string' - Description for computed_string.

* 'identity' - An 'identity' block as defined below. Defines the System and User Assigned Identity which should be assigned to this Resource.

---`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentAttributes_WithIdentitySystemOrUserAssigned(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: models.TerraformResourceDefinition{
			DisplayName: "Test Resource",
		},
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
					"Identity": {
						HCLName: "identity",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Defines the System or User Assigned Identity which should be assigned to this Resource.",
						},
					},
				},
			},
		},
	}
	actual, err := codeForAttributesReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// NOTE: this should only handle the attributes for the top-level model, nested attributes
	// are output within the relevant block within the 'blocks reference' section
	expected := strings.ReplaceAll(`## Attributes Reference

In addition to the Arguments listed above - the following Attributes are exported:

* 'id' - The ID of the Test Resource.

* 'computed_integer' - Description for computed_integer.

* 'computed_string' - Description for computed_string.

* 'identity' - An 'identity' block as defined below. Defines the System or User Assigned Identity which should be assigned to this Resource.

---`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentAttributes_WithIdentityUserAssigned(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: models.TerraformResourceDefinition{
			DisplayName: "Test Resource",
		},
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
						Validation: &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
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
					"Identity": {
						HCLName: "identity",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
						},
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Defines the User Assigned Identity which should be assigned to this Resource.",
						},
					},
				},
			},
		},
	}
	actual, err := codeForAttributesReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// NOTE: this should only handle the attributes for the top-level model, nested attributes
	// are output within the relevant block within the 'blocks reference' section
	expected := strings.ReplaceAll(`## Attributes Reference

In addition to the Arguments listed above - the following Attributes are exported:

* 'id' - The ID of the Test Resource.

* 'computed_integer' - Description for computed_integer.

* 'computed_string' - Description for computed_string.

* 'identity' - An 'identity' block as defined below. Defines the User Assigned Identity which should be assigned to this Resource.

---`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentAttributes_WithTheSameModelUsedAtTheTopLevelAndInMultipleNestedBlocks(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: models.TerraformResourceDefinition{
			DisplayName: "Test Resource",
		},
		SchemaModels: map[string]models.TerraformSchemaModel{
			"TopLevelModelResourceSchema": {
				Fields: map[string]models.TerraformSchemaField{
					"Blobby": {
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("BlobbySchema"),
						},
						Computed: true,
						HCLName:  "blobby",
					},
					"OptionalNestedItem": {
						Computed: true,
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
						Computed: true,
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
						Computed: true,
						Documentation: models.TerraformSchemaFieldDocumentationDefinition{
							Markdown: "Description for makes_sounds.",
						},
					},
				},
			},
		},
	}
	actual, err := codeForAttributesReference(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// NOTE: this should only handle the attributes for the top-level model, nested attributes
	// are output within the relevant block within the 'blocks reference' section
	expected := strings.ReplaceAll(`## Attributes Reference

In addition to the Arguments listed above - the following Attributes are exported:

* 'id' - The ID of the Test Resource.

* 'blobby' - A 'blobby' block as defined below.

* 'optional_nested_item' - An 'optional_nested_item' block as defined below.

---`, "'", "`")

	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForAttribute_ReferencingAModel(t *testing.T) {
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
	actual, err := documentationLineForAttribute(input, "")
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := "* `some_item` - A `some_item` block as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForAttribute_ReferencingAList(t *testing.T) {
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
	actual, err := documentationLineForAttribute(input, "")
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := "* `some_item` - A list of `some_item` blocks as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForAttribute_ReferencingASet(t *testing.T) {
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
	actual, err := documentationLineForAttribute(input, "")
	if err != nil {
		t.Fatal(err.Error())
	}
	// Sets are technically different internally, but still exposed to users in the same fashion, so we reuse `List` here
	expected := "* `some_item` - A list of `some_item` blocks as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForAttribute_LocationAbove(t *testing.T) {
	// The block `person` contains a field `animal`
	input := models.TerraformSchemaField{
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
			ReferenceName: pointer.To("Animal"),
		},
		HCLName:  "animal",
		Optional: true,
	}
	actual, err := documentationLineForAttribute(input, "person")
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := "* `animal` - An `animal` block as defined above."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForAttribute_LocationBelow(t *testing.T) {
	// The block `cat` contains a field `napping_place`
	input := models.TerraformSchemaField{
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
			ReferenceName: pointer.To("NappingPlace"),
		},
		HCLName:  "napping_place",
		Optional: true,
	}
	actual, err := documentationLineForAttribute(input, "cat")
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := "* `napping_place` - A `napping_place` block as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForAttribute_LocationForTopLevelItemShouldAlwaysSayBelow(t *testing.T) {
	input := models.TerraformSchemaField{
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
			ReferenceName: pointer.To("Animal"),
		},
		HCLName:  "animal",
		Optional: true,
	}
	actual, err := documentationLineForAttribute(input, "")
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := "* `animal` - An `animal` block as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
