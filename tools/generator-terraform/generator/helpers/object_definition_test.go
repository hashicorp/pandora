package helpers

import (
	"testing"

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
			expected: stringPointer("bool"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeDateTime,
			},
			// whilst DateTime could be output as *time.Time the Go SDK outputs
			// this as a String with Get/Set methods to allow exposing this value
			// either as a raw string or by formatting the value, so we output
			// a string here rather than a *time.Time
			expected: stringPointer("string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeFloat,
			},
			expected: stringPointer("float64"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeInteger,
			},
			expected: stringPointer("int64"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeString,
			},
			expected: stringPointer("string"),
		},

		// References
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type:          resourcemanager.TerraformSchemaFieldTypeReference,
				ReferenceName: stringPointer("SomeModel"),
			},
			expected: stringPointer("[]SomeModel"),
		},

		// Common Types
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
			},
			expected: stringPointer("string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeLocation,
			},
			expected: stringPointer("string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
			},
			expected: stringPointer("[]identity.ModelSystemAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
			},
			expected: stringPointer("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
			},
			expected: stringPointer("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
			},
			expected: stringPointer("[]identity.ModelUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
			},
			expected: stringPointer("string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeTags,
			},
			expected: stringPointer("map[string]interface{}"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeZone,
			},
			expected: stringPointer("string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeZones,
			},
			expected: stringPointer("[]string"),
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

func stringPointer(input string) *string {
	return &input
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
			expected: stringPointer("[]bool"),
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
			expected: stringPointer("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeFloat,
				},
			},
			expected: stringPointer("[]float64"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
			},
			expected: stringPointer("[]int64"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
			},
			expected: stringPointer("[]string"),
		},

		// References
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: stringPointer("SomeModel"),
				},
			},
			expected: stringPointer("[]SomeModel"),
		},

		// Common Types
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
				},
			},
			expected: stringPointer("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
				},
			},
			expected: stringPointer("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
				},
			},
			expected: stringPointer("[]identity.ModelSystemAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
				},
			},
			expected: stringPointer("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
				},
			},
			expected: stringPointer("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
				},
			},
			expected: stringPointer("[]identity.ModelUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
				},
			},
			expected: stringPointer("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeTags,
				},
			},
			expected: stringPointer("[]map[string]interface{}"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeZone,
				},
			},
			expected: stringPointer("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeList,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeZones,
				},
			},
			expected: stringPointer("[][]string"),
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
			expected: stringPointer("[]bool"),
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
			expected: stringPointer("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeFloat,
				},
			},
			expected: stringPointer("[]float64"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeInteger,
				},
			},
			expected: stringPointer("[]int64"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
			},
			expected: stringPointer("[]string"),
		},

		// References
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type:          resourcemanager.TerraformSchemaFieldTypeReference,
					ReferenceName: stringPointer("SomeModel"),
				},
			},
			expected: stringPointer("[]SomeModel"),
		},

		// Common Types
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
				},
			},
			expected: stringPointer("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
				},
			},
			expected: stringPointer("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
				},
			},
			expected: stringPointer("[]identity.ModelSystemAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
				},
			},
			expected: stringPointer("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
				},
			},
			expected: stringPointer("[]identity.ModelSystemAssignedUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
				},
			},
			expected: stringPointer("[]identity.ModelUserAssigned"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
				},
			},
			expected: stringPointer("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeTags,
				},
			},
			expected: stringPointer("[]map[string]interface{}"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeZone,
				},
			},
			expected: stringPointer("[]string"),
		},
		{
			input: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeSet,
				NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeZones,
				},
			},
			expected: stringPointer("[][]string"),
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
