// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestObjectDefinitionToGolangFieldType(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaFieldObjectDefinition
		expected *string
	}{
		// Simple Types
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
			},
			expected: pointer.To("bool"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeDateTime,
			},
			// whilst DateTime could be output as *time.Time the Go SDK outputs
			// this as a String with Get/Set methods to allow exposing this value
			// either as a raw string or by formatting the value, so we output
			// a string here rather than a *time.Time
			expected: pointer.To("string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeFloat,
			},
			expected: pointer.To("float64"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeInteger,
			},
			expected: pointer.To("int64"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeString,
			},
			expected: pointer.To("string"),
		},

		// References
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type:          resourcemanager.TerraformSchemaFieldTypeReference,
				ReferenceName: pointer.To("SomeModel"),
			},
			expected: pointer.To("[]SomeModel"),
		},

		// Common Types
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
			},
			expected: pointer.To("string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeLocation,
			},
			expected: pointer.To("string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
			},
			expected: pointer.To("[]identity.ModelSystemAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
			},
			expected: pointer.To("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
			},
			expected: pointer.To("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
			},
			expected: pointer.To("[]identity.ModelUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
			},
			expected: pointer.To("string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeTags,
			},
			expected: pointer.To("map[string]interface{}"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeZone,
			},
			expected: pointer.To("string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeZones,
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
			t.Fatalf("expected no error and a result but got no error and no result")
		}
		if *result != *data.expected {
			t.Fatalf("expected %q but got %q", *data.expected, *result)
		}
	}
}

func TestObjectDefinitionToGolangFieldType_Lists(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaFieldObjectDefinition
		expected *string
	}{
		// Simple Types
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
				},
			},
			expected: pointer.To("[]bool"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeDateTime,
				},
			},
			// whilst DateTime could be output as *time.Time the Go SDK outputs
			// this as a String with Get/Set methods to allow exposing this value
			// either as a raw string or by formatting the value, so we output
			// a string here rather than a *time.Time
			expected: pointer.To("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeFloat,
				},
			},
			expected: pointer.To("[]float64"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
			},
			expected: pointer.To("[]int64"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
			},
			expected: pointer.To("[]string"),
		},

		// References
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: pointer.To("SomeModel"),
				},
			},
			expected: pointer.To("[]SomeModel"),
		},

		// Common Types
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
				},
			},
			expected: pointer.To("[]identity.ModelSystemAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
				},
			},
			expected: pointer.To("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
				},
			},
			expected: pointer.To("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
				},
			},
			expected: pointer.To("[]identity.ModelUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeTags,
				},
			},
			expected: pointer.To("[]map[string]interface{}"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeZone,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeZones,
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

func TestObjectDefinitionToGolangFieldType_Sets(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaFieldObjectDefinition
		expected *string
	}{
		// Simple Types
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
				},
			},
			expected: pointer.To("[]bool"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeDateTime,
				},
			},
			// whilst DateTime could be output as *time.Time the Go SDK outputs
			// this as a String with Get/Set methods to allow exposing this value
			// either as a raw string or by formatting the value, so we output
			// a string here rather than a *time.Time
			expected: pointer.To("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeFloat,
				},
			},
			expected: pointer.To("[]float64"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
			},
			expected: pointer.To("[]int64"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
			},
			expected: pointer.To("[]string"),
		},

		// References
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: pointer.To("SomeModel"),
				},
			},
			expected: pointer.To("[]SomeModel"),
		},

		// Common Types
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
				},
			},
			expected: pointer.To("[]identity.ModelSystemAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
				},
			},
			expected: pointer.To("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
				},
			},
			expected: pointer.To("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
				},
			},
			expected: pointer.To("[]identity.ModelUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeTags,
				},
			},
			expected: pointer.To("[]map[string]interface{}"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeZone,
				},
			},
			expected: pointer.To("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeZones,
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
