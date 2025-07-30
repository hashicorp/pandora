// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestObjectDefinitionToGolangFieldType(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaObjectDefinition
		expected *string
	}{
		// Simple Types
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.BooleanTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("bool"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.DateTimeTerraformSchemaObjectDefinitionType,
			},
			// whilst DateTime could be output as *time.Time the Go SDK outputs
			// this as a String with Get/Set methods to allow exposing this value
			// either as a raw string or by formatting the value, so we output
			// a string here rather than a *time.Time
			expected: pointer.To("string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.FloatTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("float64"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.IntegerTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("int64"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.StringTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("string"),
		},

		// References
		{
			input: models.TerraformSchemaObjectDefinition{
				Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
				ReferenceName: pointer.To("SomeModel"),
			},
			expected: pointer.To("[]SomeModel"),
		},

		// Common Types
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.EdgeZoneTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.LocationTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("[]identity.ModelSystemAssigned"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("[]identity.ModelUserAssigned"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ResourceGroupTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.TagsTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("map[string]interface{}"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ZoneTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ZonesTerraformSchemaObjectDefinitionType,
			},
			expected: pointer.To("[]string"),
		},
	}
	for i, data := range testData {
		result, err := GolangFieldTypeFromObjectFieldDefinition(data.input)
		if err != nil {
			if data.expected == nil {
				continue
			}

			t.Fatalf("unexpected error for iteration %d: %+v", i, err)
		}
		if data.expected == nil {
			t.Fatalf("expected an error but didn't get one for iteration %d", i)
		}
		if result == nil {
			t.Fatal("expected no error and a result but got no error and no result")
		}
		if *result != *data.expected {
			t.Fatalf("expected %q but got %q", *data.expected, *result)
		}
	}
}

func TestObjectDefinitionToGolangFieldType_Lists(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaObjectDefinition
		expected *string
	}{
		// Simple Types
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.BooleanTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]bool"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.DateTimeTerraformSchemaObjectDefinitionType,
				},
			},
			// whilst DateTime could be output as *time.Time the Go SDK outputs
			// this as a String with Get/Set methods to allow exposing this value
			// either as a raw string or by formatting the value, so we output
			// a string here rather than a *time.Time
			expected: pointer.To("[]string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.FloatTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]float64"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.IntegerTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]int64"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.StringTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]string"),
		},

		// References
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
			},
			expected: pointer.To("[]SomeModel"),
		},

		// Common Types
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.EdgeZoneTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.LocationTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]identity.ModelSystemAssigned"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]identity.ModelUserAssigned"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.ResourceGroupTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.TagsTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]map[string]interface{}"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.ZoneTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.ListTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.ZonesTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[][]string"),
		},
	}
	for i, data := range testData {
		result, err := GolangFieldTypeFromObjectFieldDefinition(data.input)
		if err != nil {
			if data.expected == nil {
				continue
			}

			t.Fatalf("unexpected error for iteration %d: %+v", i, err)
		}
		if data.expected == nil {
			t.Fatalf("expected an error but didn't get one for iteration %d", i)
		}
		if result == nil {
			t.Fatal("expected no error and a result but got no error and no result")
		}
		if *result != *data.expected {
			t.Fatalf("expected %q but got %q", *data.expected, *result)
		}
	}
}

func TestObjectDefinitionToGolangFieldType_Sets(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaObjectDefinition
		expected *string
	}{
		// Simple Types
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.BooleanTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]bool"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.DateTimeTerraformSchemaObjectDefinitionType,
				},
			},
			// whilst DateTime could be output as *time.Time the Go SDK outputs
			// this as a String with Get/Set methods to allow exposing this value
			// either as a raw string or by formatting the value, so we output
			// a string here rather than a *time.Time
			expected: pointer.To("[]string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.FloatTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]float64"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.IntegerTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]int64"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.StringTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]string"),
		},

		// References
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
			},
			expected: pointer.To("[]SomeModel"),
		},

		// Common Types
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.EdgeZoneTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.LocationTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]identity.ModelSystemAssigned"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]identity.ModelUserAssigned"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.ResourceGroupTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.TagsTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]map[string]interface{}"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.ZoneTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: models.TerraformSchemaObjectDefinition{
				Type: models.SetTerraformSchemaObjectDefinitionType,
				NestedObject: &models.TerraformSchemaObjectDefinition{
					Type: models.ZonesTerraformSchemaObjectDefinitionType,
				},
			},
			expected: pointer.To("[][]string"),
		},
	}
	for i, data := range testData {
		result, err := GolangFieldTypeFromObjectFieldDefinition(data.input)
		if err != nil {
			if data.expected == nil {
				continue
			}

			t.Fatalf("unexpected error for iteration %d: %+v", i, err)
		}
		if data.expected == nil {
			t.Fatalf("expected an error but didn't get one for iteration %d", i)
		}
		if result == nil {
			t.Fatalf("expected no error and a result but got no error and no result")
		}
		if *result != *data.expected {
			t.Fatalf("expected %q but got %q", *data.expected, *result)
		}
	}
}
