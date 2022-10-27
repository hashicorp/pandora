package processors

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestProcessField_PluralToSingular(t *testing.T) {
	testData := []struct {
		fieldInput    string
		metadataInput FieldMetadata
		expected      *string
	}{
		{
			fieldInput: "Pandas",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"Pandas": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ListApiObjectDefinitionType,
							},
						},
					},
				},
			},
			expected: stringPointer("Panda"),
		},
		{
			fieldInput: "Statuses",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"Statuses": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ListApiObjectDefinitionType,
							},
						},
					},
				},
			},
			expected: stringPointer("Status"),
		},
		{
			fieldInput: "Metadata",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"Metadata": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ListApiObjectDefinitionType,
							},
						},
					},
				},
			},
			expected: stringPointer("Metadata"),
		},
		{
			fieldInput: "Planets",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"Planets": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.StringApiObjectDefinitionType,
							},
						},
					},
				},
			},
			expected: nil,
		},
		{
			fieldInput: "Bass",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"Bass": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.StringApiObjectDefinitionType,
							},
						},
					},
				},
			},
			expected: nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.fieldInput)

		actual, _ := fieldNamePluralToSingular{}.ProcessField(v.fieldInput, v.metadataInput)

		if actual == nil {
			if v.expected == nil {
				continue
			}
			t.Fatalf("expected a result but didn't get one")
		}
		if v.expected == nil {
			t.Fatalf("expected no result but got %s", *actual)
		}
		if *actual != *v.expected {
			t.Fatalf("Expected %s but got %s", *v.expected, *actual)
		}
	}
}
