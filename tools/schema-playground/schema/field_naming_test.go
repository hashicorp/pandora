package schema

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"testing"
)

func TestUpdateNameForField_Is(t *testing.T) {
	testData := []struct {
		input    string
		expected *string
	}{
		{
			input:    "is_default",
			expected: stringPointer("default"),
		},
		{
			input:    "default",
			expected: nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)

		actual := fieldNameIs{}.updatedNameForField(v.input, nil)

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

func TestUpdateNameForField_PluralToSingular(t *testing.T) {
	testData := []struct {
		fieldInput string
		modelInput resourcemanager.ModelDetails
		expected   *string
	}{
		{
			fieldInput: "pandas",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"pandas": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
						},
					},
				},
			},
			expected: stringPointer("panda"),
		},
		{
			fieldInput: "planets",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"planets": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
			},
			expected: nil,
		},
		{
			fieldInput: "bass",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"bass": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
			},
			expected: nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.fieldInput)

		actual := fieldNamePluralToSingular{}.updatedNameForField(v.fieldInput, &v.modelInput)

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

func TestUpdateNameForField_AppendEnabled(t *testing.T) {
	testData := []struct {
		fieldInput string
		modelInput resourcemanager.ModelDetails
		expected   *string
	}{
		{
			fieldInput: "pandas",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"pandas": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
					},
				},
			},
			expected: stringPointer("pandas_enabled"),
		},
		{
			fieldInput: "planets",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"planets": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
			},
			expected: nil,
		},
		{
			fieldInput: "security_enabled",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"security_enabled": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
					},
				},
			},
			expected: nil,
		},
		{
			fieldInput: "securityDisabled",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"securityDisabled": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
					},
				},
			},
			expected: nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.fieldInput)

		actual := fieldNameAppendEnabled{}.updatedNameForField(v.fieldInput, &v.modelInput)

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
