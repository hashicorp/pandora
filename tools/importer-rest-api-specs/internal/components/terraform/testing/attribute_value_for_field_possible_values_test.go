// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestAttributeValueForField_PossibleValuesInteger(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "some_field",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
		Validation: sdkModels.TerraformSchemaFieldValidationPossibleValuesDefinition{
			PossibleValues: &sdkModels.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
				Type: sdkModels.IntegerTerraformSchemaFieldValidationPossibleValuesType,
				Values: []interface{}{
					int64(32),
					int64(21),
					int64(96),
				},
			},
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `32`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
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
	field := sdkModels.TerraformSchemaField{
		HCLName:  "some_field",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.FloatTerraformSchemaObjectDefinitionType,
		},
		Validation: sdkModels.TerraformSchemaFieldValidationPossibleValuesDefinition{
			PossibleValues: &sdkModels.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
				Type: sdkModels.FloatTerraformSchemaFieldValidationPossibleValuesType,
				Values: []interface{}{
					float64(32.02),
					float64(21.94),
					float64(96.51),
				},
			},
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `32.02`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
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
	field := sdkModels.TerraformSchemaField{
		HCLName:  "some_field",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
		Validation: sdkModels.TerraformSchemaFieldValidationPossibleValuesDefinition{
			PossibleValues: &sdkModels.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
				Type: sdkModels.StringTerraformSchemaFieldValidationPossibleValuesType,
				Values: []interface{}{
					"First",
					"Second",
					"Third",
				},
			},
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `"First"`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
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
