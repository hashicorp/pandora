// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestBlockValueForField_Reference(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "some_nested_item",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
			ReferenceName: pointer.To("NestedModel"),
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeNestedItem": field,
				},
			},
			"NestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeKey": {
						HCLName:  "some_key",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `
some_nested_item {
  some_key = "val-${var.random_string}"
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
	}
	actualRendered := renderBlocksToHcl(*actual)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actualRendered)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
		},
		needsClientConfig:         false,
		needsEdgeZone:             false,
		needsNetworkInterface:     false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestBlockValueForField_ReferenceContainingAReference(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "some_nested_item",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
			ReferenceName: pointer.To("NestedModel"),
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeNestedItem": field,
				},
			},
			"NestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeKey": {
						HCLName:  "some_key",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SecondNestedItem": {
						HCLName:  "second_nested_item",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("SecondNestedModel"),
						},
					},
				},
			},
			"SecondNestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeField": {
						HCLName:  "some_field",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `
some_nested_item {
  some_key = "val-${var.random_string}"

  second_nested_item {
    some_field = "val-${var.random_string}"
  }
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
	}
	actualRendered := renderBlocksToHcl(*actual)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actualRendered)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
		},
		needsClientConfig:         false,
		needsEdgeZone:             false,
		needsNetworkInterface:     false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestBlockValueForField_ReferenceContainingAReferenceThatContainsAReference(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "some_nested_item",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
			ReferenceName: pointer.To("NestedModel"),
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeNestedItem": field,
				},
			},
			"NestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeKey": {
						HCLName:  "some_key",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SecondNestedItem": {
						HCLName:  "second_nested_item",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("SecondNestedModel"),
						},
					},
				},
			},
			"SecondNestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeField": {
						HCLName:  "some_field",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"ThirdNestedItem": {
						HCLName:  "third_nested_item",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("ThirdNestedModel"),
						},
					},
				},
			},
			"ThirdNestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"YetAnotherField": {
						HCLName:  "yet_another_field",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.IntegerTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `
some_nested_item {
  some_key = "val-${var.random_string}"

  second_nested_item {
    some_field = "val-${var.random_string}"

    third_nested_item {
      yet_another_field = 21
    }
  }
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
	}
	actualRendered := renderBlocksToHcl(*actual)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actualRendered)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
		},
		needsClientConfig:         false,
		needsEdgeZone:             false,
		needsNetworkInterface:     false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestBlockValueForField_List(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "some_nested_item",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.ListTerraformSchemaObjectDefinitionType,
			NestedObject: &sdkModels.TerraformSchemaObjectDefinition{
				Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
				ReferenceName: pointer.To("NestedModel"),
			},
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeNestedItem": field,
				},
			},
			"NestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeKey": {
						HCLName:  "some_key",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `
some_nested_item {
  some_key = "val-${var.random_string}"
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
	}
	actualRendered := renderBlocksToHcl(*actual)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actualRendered)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
		},
		needsClientConfig:         false,
		needsEdgeZone:             false,
		needsNetworkInterface:     false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestBlockValueForField_Set(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "some_nested_item",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.SetTerraformSchemaObjectDefinitionType,
			NestedObject: &sdkModels.TerraformSchemaObjectDefinition{
				Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
				ReferenceName: pointer.To("NestedModel"),
			},
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeNestedItem": field,
				},
			},
			"NestedModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeKey": {
						HCLName:  "some_key",
						Required: true,
						ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
							Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests:           sdkModels.TerraformResourceTestsDefinition{},
	}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `
some_nested_item {
  some_key = "val-${var.random_string}"
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestVariables())
	if err != nil {
		t.Fatal(err.Error())
	}
	actualRendered := renderBlocksToHcl(*actual)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actualRendered)
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
		},
		needsClientConfig:         false,
		needsEdgeZone:             false,
		needsNetworkInterface:     false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}
