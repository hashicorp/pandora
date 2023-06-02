package testing

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestBlockValueForModel_RequiredOnly_OnlyTopLevelProperties(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeRequiredField": {
						HclName:  "some_required_field",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"SomeOptionalField": {
						HclName:  "some_optional_field",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
				},
			},
		},
	}
	onlyRequiredFields := true
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	actual, err := builder.getBlockValueForModel("wrapper", details.SchemaModels["TopLevelModel"], &actualDependencies, onlyRequiredFields)
	if err != nil {
		t.Fatalf(err.Error())
	}
	renderedActual := renderBlocksToHcl([]*hclwrite.Block{actual})
	expected := `
wrapper {
  some_required_field = "val-${var.random_string}"
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, renderedActual)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
		},
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestBlockValueForModel_RequiredAndOptional_OnlyTopLevelProperties(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeRequiredField": {
						HclName:  "some_required_field",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"SomeOptionalField": {
						HclName:  "some_optional_field",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
				},
			},
		},
	}
	onlyRequiredFields := false
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	actual, err := builder.getBlockValueForModel("wrapper", details.SchemaModels["TopLevelModel"], &actualDependencies, onlyRequiredFields)
	if err != nil {
		t.Fatalf(err.Error())
	}
	renderedActual := renderBlocksToHcl([]*hclwrite.Block{actual})
	expected := `
wrapper {
  some_required_field = "val-${var.random_string}"
  some_optional_field = "val-${var.random_string}"
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, renderedActual)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
		},
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestBlockValueForModel_RequiredOnly_MapsANestedItem(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeRequiredField": {
						HclName:  "some_required_field",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"SomeOptionalField": {
						HclName:  "some_optional_field",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"SomeNestedBlock": {
						HclName:  "some_nested_block",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("NestedModel"),
						},
					},
					"AnotherNestedBlock": {
						HclName:  "another_nested_block",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("NestedModel"),
						},
					},
				},
			},
			"NestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeRequiredNestedField": {
						HclName:  "some_required_nested_field",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"SomeOptionalNestedField": {
						HclName:  "some_optional_nested_field",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
				},
			},
		},
	}
	onlyRequiredFields := true
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	actual, err := builder.getBlockValueForModel("wrapper", details.SchemaModels["TopLevelModel"], &actualDependencies, onlyRequiredFields)
	if err != nil {
		t.Fatalf(err.Error())
	}
	renderedActual := renderBlocksToHcl([]*hclwrite.Block{actual})
	expected := `
wrapper {
  some_required_field = "val-${var.random_string}"

  some_nested_block {
    some_required_nested_field = "val-${var.random_string}"
  }
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, renderedActual)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
		},
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestBlockValueForModel_RequiredAndOptional_MapsANestedItem(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeRequiredField": {
						HclName:  "some_required_field",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"SomeOptionalField": {
						HclName:  "some_optional_field",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"SomeNestedBlock": {
						HclName:  "some_nested_block",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("NestedModel"),
						},
					},
					"AnotherNestedBlock": {
						HclName:  "another_nested_block",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("NestedModel"),
						},
					},
				},
			},
			"NestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeRequiredNestedField": {
						HclName:  "some_required_nested_field",
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
					"SomeOptionalNestedField": {
						HclName:  "some_optional_nested_field",
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
					},
				},
			},
		},
	}
	onlyRequiredFields := false
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	actual, err := builder.getBlockValueForModel("wrapper", details.SchemaModels["TopLevelModel"], &actualDependencies, onlyRequiredFields)
	if err != nil {
		t.Fatalf(err.Error())
	}
	renderedActual := renderBlocksToHcl([]*hclwrite.Block{actual})
	expected := `
wrapper {
  some_required_field = "val-${var.random_string}"

  some_nested_block {
    some_required_nested_field = "val-${var.random_string}"
    some_optional_nested_field = "val-${var.random_string}"
  }

  some_optional_field = "val-${var.random_string}"

  another_nested_block {
    some_required_nested_field = "val-${var.random_string}"
    some_optional_nested_field = "val-${var.random_string}"
  }
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, renderedActual)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
		},
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}
