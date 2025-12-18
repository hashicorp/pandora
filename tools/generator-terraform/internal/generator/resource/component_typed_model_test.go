// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestCodeForTopLevelTypedModelAndDefinition_Disabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			GenerateModel: false,
		},
	}
	actual, err := codeForTopLevelTypedModelAndDefinition(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestCodeForTopLevelTypedModelAndDefinition_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			GenerateModel: true,
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "ExampleModel",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"ExampleModel": {
				Fields: map[string]models.TerraformSchemaField{
					"RequiredBoolean": {
						HCLName: "required_boolean",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"OptionalBoolean": {
						HCLName: "optional_boolean",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
					},
					"OptionalComputedBoolean": {
						Computed: true,
						HCLName:  "optional_computed_boolean",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
					},
					"ComputedBoolean": {
						Computed: true,
						HCLName:  "computed_boolean",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.BooleanTerraformSchemaObjectDefinitionType,
						},
					},
					"RequiredString": {
						HCLName: "required_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"OptionalString": {
						HCLName: "optional_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
					},
					"OptionalComputedString": {
						Computed: true,
						HCLName:  "optional_computed_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Optional: true,
					},
					"ComputedString": {
						Computed: true,
						HCLName:  "computed_string",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
	}
	actual, err := codeForTopLevelTypedModelAndDefinition(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	// NOTE: whilst we could test references/lists/sets etc, these are tested via the ObjectDefinition methods
	// so it'd be overkill for now
	expected := strings.ReplaceAll(`
func (r ExampleResource) ModelObject() interface{} {
	return &ExampleModel{}
}

type ExampleModel struct {
	ComputedBoolean bool 'tfschema:"computed_boolean"'
	ComputedString string 'tfschema:"computed_string"'
	OptionalBoolean bool 'tfschema:"optional_boolean"'
	OptionalComputedBoolean bool 'tfschema:"optional_computed_boolean"'
	OptionalComputedString string 'tfschema:"optional_computed_string"'
	OptionalString string 'tfschema:"optional_string"'
	RequiredBoolean bool 'tfschema:"required_boolean"'
	RequiredString string 'tfschema:"required_string"'
}
`, "'", "`")
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestCodeForNonTopLevelModels_Disabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			GenerateModel: false,
		},
	}
	actual, err := codeForNonTopLevelModels(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestCodeForNonTopLevelModels_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			GenerateModel: true,
		},
		SchemaModelName: "TopLevelModel",
		SchemaModels: map[string]models.TerraformSchemaModel{
			// top level model shouldn't be output here
			"TopLevelModel": {
				Fields: map[string]models.TerraformSchemaField{
					"Field1": {
						HCLName: "field1",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"NestedModel1": {
				Fields: map[string]models.TerraformSchemaField{
					"Field2": {
						HCLName: "field2",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				}},
			"NestedModel2": {
				Fields: map[string]models.TerraformSchemaField{
					"Field3": {
						HCLName: "field3",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				}},
		},
	}
	actual, err := codeForNonTopLevelModels(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := strings.ReplaceAll(`
type NestedModel1 struct {
	Field2 string 'tfschema:"field2"'
}
type NestedModel2 struct {
	Field3 string 'tfschema:"field3"'
}
`, "'", "`")
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestCodeForModel(t *testing.T) {
	input := models.TerraformSchemaModel{
		Fields: map[string]models.TerraformSchemaField{
			"RequiredBoolean": {
				HCLName: "required_boolean",
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.BooleanTerraformSchemaObjectDefinitionType,
				},
				Required: true,
			},
			"OptionalBoolean": {
				HCLName: "optional_boolean",
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.BooleanTerraformSchemaObjectDefinitionType,
				},
				Optional: true,
			},
			"OptionalComputedBoolean": {
				Computed: true,
				HCLName:  "optional_computed_boolean",
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.BooleanTerraformSchemaObjectDefinitionType,
				},
				Optional: true,
			},
			"ComputedBoolean": {
				Computed: true,
				HCLName:  "computed_boolean",
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.BooleanTerraformSchemaObjectDefinitionType,
				},
			},
			"RequiredString": {
				HCLName: "required_string",
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.StringTerraformSchemaObjectDefinitionType,
				},
				Required: true,
			},
			"OptionalString": {
				HCLName: "optional_string",
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.StringTerraformSchemaObjectDefinitionType,
				},
				Optional: true,
			},
			"OptionalComputedString": {
				Computed: true,
				HCLName:  "optional_computed_string",
				Optional: true,
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.StringTerraformSchemaObjectDefinitionType,
				},
			},
			"ComputedString": {
				Computed: true,
				HCLName:  "computed_string",
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.StringTerraformSchemaObjectDefinitionType,
				},
			},
		},
	}
	actual, err := codeForModel("ExampleModel", input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	// NOTE: whilst we could test references/lists/sets etc, these are tested via the ObjectDefinition methods
	// so it'd be overkill for now
	expected := strings.ReplaceAll(`
type ExampleModel struct {
	ComputedBoolean bool 'tfschema:"computed_boolean"'
	ComputedString string 'tfschema:"computed_string"'
	OptionalBoolean bool 'tfschema:"optional_boolean"'
	OptionalComputedBoolean bool 'tfschema:"optional_computed_boolean"'
	OptionalComputedString string 'tfschema:"optional_computed_string"'
	OptionalString string 'tfschema:"optional_string"'
	RequiredBoolean bool 'tfschema:"required_boolean"'
	RequiredString string 'tfschema:"required_string"'
}
`, "'", "`")
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
