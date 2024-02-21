// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestAttributeValueForField_PossibleValuesInteger(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_field",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeString,
		},
		Validation: &resourcemanager.TerraformSchemaValidationDefinition{
			Type: resourcemanager.TerraformSchemaValidationTypePossibleValues,
			PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
				Type: resourcemanager.TerraformSchemaValidationPossibleValueTypeInt,
				Values: []interface{}{
					int64(32),
					int64(21),
					int64(96),
				},
			},
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := resourcemanager.TerraformTestDataVariables{}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `32`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatalf(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables:                 testVariables{},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_PossibleValuesFloat(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_field",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeFloat,
		},
		Validation: &resourcemanager.TerraformSchemaValidationDefinition{
			Type: resourcemanager.TerraformSchemaValidationTypePossibleValues,
			PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
				Type: resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat,
				Values: []interface{}{
					float64(32.02),
					float64(21.94),
					float64(96.51),
				},
			},
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := resourcemanager.TerraformTestDataVariables{}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `32.02`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatalf(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables:                 testVariables{},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_PossibleValuesString(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_field",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeString,
		},
		Validation: &resourcemanager.TerraformSchemaValidationDefinition{
			Type: resourcemanager.TerraformSchemaValidationTypePossibleValues,
			PossibleValues: &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
				Type: resourcemanager.TerraformSchemaValidationPossibleValueTypeString,
				Values: []interface{}{
					"First",
					"Second",
					"Third",
				},
			},
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := resourcemanager.TerraformTestDataVariables{}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `"First"`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatalf(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables:                 testVariables{},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}
