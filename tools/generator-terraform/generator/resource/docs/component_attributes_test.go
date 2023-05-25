package docs

import (
	"strings"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestComponentAttributes_TopLevelOnly(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: resourcemanager.TerraformResourceDetails{
			DisplayName: "Test Resource",
		},
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
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: resourcemanager.TerraformResourceDetails{
			DisplayName: "Test Resource",
		},
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModelResourceSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"ComputedNestedItem": {
						Computed: true,
						HclName:  "computed_nested_item",
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
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: resourcemanager.TerraformResourceDetails{
			DisplayName: "Test Resource",
		},
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
					"Identity": {
						HclName: "identity",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
						},
						Computed: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
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
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: resourcemanager.TerraformResourceDetails{
			DisplayName: "Test Resource",
		},
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
					"Identity": {
						HclName: "identity",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
						},
						Computed: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
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
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: resourcemanager.TerraformResourceDetails{
			DisplayName: "Test Resource",
		},
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
					"Identity": {
						HclName: "identity",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
						},
						Computed: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
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
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: resourcemanager.TerraformResourceDetails{
			DisplayName: "Test Resource",
		},
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
					"Identity": {
						HclName: "identity",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
						},
						Computed: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
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
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModelResourceSchema",
		Details: resourcemanager.TerraformResourceDetails{
			DisplayName: "Test Resource",
		},
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModelResourceSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Blobby": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("BlobbySchema"),
						},
						Computed: true,
						HclName:  "blobby",
					},
					"OptionalNestedItem": {
						Computed: true,
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
						Computed: true,
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
						Computed: true,
						Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
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
	actual, err := documentationLineForAttribute(input, "")
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := "* `some_item` - A `some_item` block as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForAttribute_ReferencingAList(t *testing.T) {
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
	actual, err := documentationLineForAttribute(input, "")
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := "* `some_item` - A list of `some_item` blocks as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForAttribute_ReferencingASet(t *testing.T) {
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
	actual, err := documentationLineForAttribute(input, "")
	if err != nil {
		t.Fatalf(err.Error())
	}
	// Sets are technically different internally, but still exposed to users in the same fashion, so we reuse `List` here
	expected := "* `some_item` - A list of `some_item` blocks as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForAttribute_LocationAbove(t *testing.T) {
	// The block `person` contains a field `animal`
	input := resourcemanager.TerraformSchemaFieldDefinition{
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type:          resourcemanager.TerraformSchemaFieldTypeReference,
			ReferenceName: pointer.To("Animal"),
		},
		HclName:  "animal",
		Optional: true,
	}
	actual, err := documentationLineForAttribute(input, "person")
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := "* `animal` - An `animal` block as defined above."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForAttribute_LocationBelow(t *testing.T) {
	// The block `cat` contains a field `napping_place`
	input := resourcemanager.TerraformSchemaFieldDefinition{
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type:          resourcemanager.TerraformSchemaFieldTypeReference,
			ReferenceName: pointer.To("NappingPlace"),
		},
		HclName:  "napping_place",
		Optional: true,
	}
	actual, err := documentationLineForAttribute(input, "cat")
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := "* `napping_place` - A `napping_place` block as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDocumentationLineForAttribute_LocationForTopLevelItemShouldAlwaysSayBelow(t *testing.T) {
	input := resourcemanager.TerraformSchemaFieldDefinition{
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type:          resourcemanager.TerraformSchemaFieldTypeReference,
			ReferenceName: pointer.To("Animal"),
		},
		HclName:  "animal",
		Optional: true,
	}
	actual, err := documentationLineForAttribute(input, "")
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := "* `animal` - An `animal` block as defined below."
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
