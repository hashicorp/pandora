// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestCodeForTopLevelTypedModelAndDefinition_Disabled(t *testing.T) {
	input := models.ResourceInput{
		Details: resourcemanager.TerraformResourceDetails{
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
	input := models.ResourceInput{
		Details: resourcemanager.TerraformResourceDetails{
			GenerateModel: true,
		},
		ResourceTypeName: "Example",
		SchemaModelName:  "ExampleModel",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"ExampleModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"RequiredBoolean": {
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						HclName: "required_boolean",
					},
					"OptionalBoolean": {
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						HclName: "optional_boolean",
					},
					"OptionalComputedBoolean": {
						Optional: true,
						Computed: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						HclName: "optional_computed_boolean",
					},
					"ComputedBoolean": {
						Computed: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
						},
						HclName: "computed_boolean",
					},
					"RequiredString": {
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName: "required_string",
					},
					"OptionalString": {
						Optional: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName: "optional_string",
					},
					"OptionalComputedString": {
						Optional: true,
						Computed: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName: "optional_computed_string",
					},
					"ComputedString": {
						Computed: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName: "computed_string",
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
	input := models.ResourceInput{
		Details: resourcemanager.TerraformResourceDetails{
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
	input := models.ResourceInput{
		Details: resourcemanager.TerraformResourceDetails{
			GenerateModel: true,
		},
		SchemaModelName: "TopLevelModel",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			// top level model shouldn't be output here
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Field1": {
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName: "field1",
					},
				},
			},
			"NestedModel1": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Field2": {
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName: "field2",
					},
				}},
			"NestedModel2": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Field3": {
						Required: true,
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName: "field3",
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
	input := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"RequiredBoolean": {
				Required: true,
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
				},
				HclName: "required_boolean",
			},
			"OptionalBoolean": {
				Optional: true,
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
				},
				HclName: "optional_boolean",
			},
			"OptionalComputedBoolean": {
				Optional: true,
				Computed: true,
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
				},
				HclName: "optional_computed_boolean",
			},
			"ComputedBoolean": {
				Computed: true,
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
				},
				HclName: "computed_boolean",
			},
			"RequiredString": {
				Required: true,
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				HclName: "required_string",
			},
			"OptionalString": {
				Optional: true,
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				HclName: "optional_string",
			},
			"OptionalComputedString": {
				Optional: true,
				Computed: true,
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				HclName: "optional_computed_string",
			},
			"ComputedString": {
				Computed: true,
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				HclName: "computed_string",
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
