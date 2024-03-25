// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestBlockValueForField_Reference(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_nested_item",
		Required: true,
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
			ReferenceName: pointer.To("NestedModel"),
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeNestedItem": field,
				},
			},
			"NestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeKey": {
						HclName:  "some_key",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
		},
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
some_nested_item {
  some_key = "val-${var.random_string}"
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestData())
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_nested_item",
		Required: true,
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
			ReferenceName: pointer.To("NestedModel"),
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeNestedItem": field,
				},
			},
			"NestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeKey": {
						HclName:  "some_key",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SecondNestedItem": {
						HclName:  "second_nested_item",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("SecondNestedModel"),
						},
					},
				},
			},
			"SecondNestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": {
						HclName:  "some_field",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
		},
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
some_nested_item {
  some_key = "val-${var.random_string}"

  second_nested_item {
    some_field = "val-${var.random_string}"
  }
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestData())
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_nested_item",
		Required: true,
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
			ReferenceName: pointer.To("NestedModel"),
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeNestedItem": field,
				},
			},
			"NestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeKey": {
						HclName:  "some_key",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"SecondNestedItem": {
						HclName:  "second_nested_item",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("SecondNestedModel"),
						},
					},
				},
			},
			"SecondNestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": {
						HclName:  "some_field",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
					"ThirdNestedItem": {
						HclName:  "third_nested_item",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
							ReferenceName: pointer.To("ThirdNestedModel"),
						},
					},
				},
			},
			"ThirdNestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"YetAnotherField": {
						HclName:  "yet_another_field",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.IntegerTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
		},
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
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
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestData())
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_nested_item",
		Required: true,
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type: models.ListTerraformSchemaObjectDefinitionType,
			NestedObject: &models.TerraformSchemaObjectDefinition{
				Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
				ReferenceName: pointer.To("NestedModel"),
			},
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeNestedItem": field,
				},
			},
			"NestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeKey": {
						HclName:  "some_key",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
		},
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
some_nested_item {
  some_key = "val-${var.random_string}"
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestData())
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_nested_item",
		Required: true,
		ObjectDefinition: models.TerraformSchemaObjectDefinition{
			Type: models.SetTerraformSchemaObjectDefinitionType,
			NestedObject: &models.TerraformSchemaObjectDefinition{
				Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
				ReferenceName: pointer.To("NestedModel"),
			},
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeNestedItem": field,
				},
			},
			"NestedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeKey": {
						HclName:  "some_key",
						Required: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
					},
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		Tests: resourcemanager.TerraformResourceTestsDefinition{
			TestData: pointer.To(resourcemanager.TerraformResourceTestDataDefinition{}),
		},
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
some_nested_item {
  some_key = "val-${var.random_string}"
}
`
	actual, err := builder.getBlockValueForField(field, &actualDependencies, true, emptyTestData())
	if err != nil {
		t.Fatalf(err.Error())
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
