package processors

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: could we split this to one per file?

func TestProcessField_Exists(t *testing.T) {
	testData := []struct {
		fieldInput    string
		metadataInput FieldMetadata
		expectError   bool
	}{
		{
			fieldInput: "Pandas",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"Pandas": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ListApiObjectDefinitionType,
								NestedItem: &resourcemanager.ApiObjectDefinition{
									Type: resourcemanager.StringApiObjectDefinitionType,
								},
							},
						},
					},
				},
			},
			expectError: false,
		},
		{
			fieldInput: "Planets",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"Pandas": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.StringApiObjectDefinitionType,
							},
						},
					},
				},
			},
			expectError: true,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.fieldInput)

		_, err := fieldNameExists{}.ProcessField(v.fieldInput, v.metadataInput)

		if v.expectError && err != nil {
			continue
		}
		if err != nil {
			t.Fatalf("Unexpected error: %s", err)
		}
	}
}

func TestProcessField_RemoveIsPrefix(t *testing.T) {
	testData := []struct {
		input         string
		metadataInput FieldMetadata
		expected      *string
	}{
		{
			input:         "IsDefault",
			metadataInput: FieldMetadata{},
			expected:      stringPointer("Default"),
		},
		{
			input:         "Default",
			metadataInput: FieldMetadata{},
			expected:      nil,
		},
		{
			input:         "Isolate",
			metadataInput: FieldMetadata{},
			expected:      nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)

		actual, _ := fieldNameRemoveIsPrefix{}.ProcessField(v.input, v.metadataInput)

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

func TestProcessField_RenameBoolean(t *testing.T) {
	testData := []struct {
		fieldInput    string
		metadataInput FieldMetadata
		expected      *string
	}{
		{
			fieldInput: "enablePandas",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"enablePandas": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.BooleanApiObjectDefinitionType,
							},
						},
					},
				},
			},
			expected: stringPointer("PandasEnabled"),
		},
		{
			fieldInput: "disablePlanets",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"disablePlanets": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.BooleanApiObjectDefinitionType,
							},
						},
					},
				},
			},
			expected: stringPointer("PlanetsDisabled"),
		},
		{
			fieldInput: "AllowedPublicAccess",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"AllowedPublicAccess": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.BooleanApiObjectDefinitionType,
							},
						},
					},
				},
			},
			expected: stringPointer("PublicAccessEnabled"),
		},
		{
			fieldInput: "AllowTethering",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"AllowTethering": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.BooleanApiObjectDefinitionType,
							},
						},
					},
				},
			},
			expected: stringPointer("TetheringEnabled"),
		},
		{
			fieldInput: "TastesLikePancakes",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"TastesLikePancakes": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.BooleanApiObjectDefinitionType,
							},
						},
					},
				},
			},
			expected: nil,
		},
		{
			fieldInput: "ThreeCoffeesADay",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"ThreeCoffeesADay": {
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
			fieldInput: "Enabled",
			metadataInput: FieldMetadata{
				Model: resourcemanager.ModelDetails{
					Fields: map[string]resourcemanager.FieldDetails{
						"Enabled": {
							ObjectDefinition: resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.BooleanApiObjectDefinitionType,
							},
						},
					},
				},
			},
			expected: stringPointer("Enabled"),
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.fieldInput)

		actual, _ := fieldNameRenameBoolean{}.ProcessField(v.fieldInput, v.metadataInput)

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

func TestProcessField_RemoveResourcePrefix(t *testing.T) {
	testData := []struct {
		fieldInput    string
		metadataInput FieldMetadata
		expected      *string
	}{
		{
			fieldInput: "AnimalPandas",
			metadataInput: FieldMetadata{
				TerraformDetails: resourcemanager.TerraformResourceDetails{
					ResourceName: "Animal",
				},
			},
			expected: stringPointer("Pandas"),
		},
		{
			fieldInput: "Mars",
			metadataInput: FieldMetadata{
				TerraformDetails: resourcemanager.TerraformResourceDetails{
					ResourceName: "Planets",
				},
			},
			expected: nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.fieldInput)

		actual, _ := fieldNameRemoveResourcePrefix{}.ProcessField(v.fieldInput, v.metadataInput)

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
