// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/hcl/v2/hclwrite"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestBlockValueForModel_RequiredOnly_OnlyTopLevelProperties(t *testing.T) {
	t.Parallel()
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeRequiredField": {
						HCLName:  "some_required_field",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SomeOptionalField": {
						HCLName:  "some_optional_field",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		Tests: sdkModels.TerraformResourceTestsDefinition{},
	}
	onlyRequiredFields := true
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getBlockValueForModel("wrapper", details.SchemaModels["TopLevelModel"], &actualDependencies, onlyRequiredFields, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
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
	t.Parallel()
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeRequiredField": {
						HCLName:  "some_required_field",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SomeOptionalField": {
						HCLName:  "some_optional_field",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		Tests: sdkModels.TerraformResourceTestsDefinition{},
	}
	onlyRequiredFields := false
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getBlockValueForModel("wrapper", details.SchemaModels["TopLevelModel"], &actualDependencies, onlyRequiredFields, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
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
	t.Parallel()
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeRequiredField": {
						HCLName:  "some_required_field",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SomeOptionalField": {
						HCLName:  "some_optional_field",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SomeNestedBlock": {
						HCLName:  "some_nested_block",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("NestedModel"),
						},
					},
					"AnotherNestedBlock": {
						HCLName:  "another_nested_block",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("NestedModel"),
						},
					},
				},
			},
			"NestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeRequiredNestedField": {
						HCLName:  "some_required_nested_field",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SomeOptionalNestedField": {
						HCLName:  "some_optional_nested_field",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		Tests: sdkModels.TerraformResourceTestsDefinition{},
	}
	onlyRequiredFields := true
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getBlockValueForModel("wrapper", details.SchemaModels["TopLevelModel"], &actualDependencies, onlyRequiredFields, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
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
	t.Parallel()
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeRequiredField": {
						HCLName:  "some_required_field",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SomeOptionalField": {
						HCLName:  "some_optional_field",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SomeNestedBlock": {
						HCLName:  "some_nested_block",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("NestedModel"),
						},
					},
					"AnotherNestedBlock": {
						HCLName:  "another_nested_block",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("NestedModel"),
						},
					},
				},
			},
			"NestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeRequiredNestedField": {
						HCLName:  "some_required_nested_field",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SomeOptionalNestedField": {
						HCLName:  "some_optional_nested_field",
						Optional: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		Tests: sdkModels.TerraformResourceTestsDefinition{},
	}
	onlyRequiredFields := false
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getBlockValueForModel("wrapper", details.SchemaModels["TopLevelModel"], &actualDependencies, onlyRequiredFields, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
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
