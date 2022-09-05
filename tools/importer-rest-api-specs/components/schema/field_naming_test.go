package schema

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"testing"
)

func TestUpdateNameForField_Exists(t *testing.T) {
	testData := []struct {
		fieldInput  string
		modelInput  resourcemanager.ModelDetails
		expectError bool
	}{
		{
			fieldInput: "Pandas",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"Pandas": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
						},
					},
				},
			},
			expectError: false,
		},
		{
			fieldInput: "Planets",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"Pandas": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
			},
			expectError: true,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.fieldInput)

		_, err := fieldNameExists{}.updatedNameForField(v.fieldInput, nil, &v.modelInput, nil)

		if v.expectError && err != nil {
			continue
		}
		if err != nil {
			t.Fatalf("Unexpected error: %s", err)
		}
	}
}

func TestUpdateNameForField_Is(t *testing.T) {
	testData := []struct {
		input    string
		expected *string
	}{
		{
			input:    "IsDefault",
			expected: stringPointer("Default"),
		},
		{
			input:    "Default",
			expected: nil,
		},
		{
			input:    "Isolate",
			expected: nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)

		actual, _ := fieldNameIs{}.updatedNameForField(v.input, nil, nil, nil)

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
			fieldInput: "Pandas",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"Pandas": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
						},
					},
				},
			},
			expected: stringPointer("Panda"),
		},
		{
			fieldInput: "Planets",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"Planets": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
			},
			expected: nil,
		},
		{
			fieldInput: "Bass",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"Bass": {
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

		actual, _ := fieldNamePluralToSingular{}.updatedNameForField(v.fieldInput, nil, &v.modelInput, nil)

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
			fieldInput: "enablePandas",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"enablePandas": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
					},
				},
			},
			expected: stringPointer("PandasEnabled"),
		},
		{
			fieldInput: "disablePlanets",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"disablePlanets": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
					},
				},
			},
			expected: stringPointer("PlanetsDisabled"),
		},
		{
			fieldInput: "AllowedPublicAccess",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"AllowedPublicAccess": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
					},
				},
			},
			expected: stringPointer("PublicAccessEnabled"),
		},
		{
			fieldInput: "AllowTethering",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"AllowTethering": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
					},
				},
			},
			expected: stringPointer("TetheringEnabled"),
		},
		{
			fieldInput: "TastesLikePancakes",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"TastesLikePancakes": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
					},
				},
			},
			expected: nil,
		},
		{
			fieldInput: "ThreeCoffeesADay",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"ThreeCoffeesADay": {
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

		actual, _ := fieldNameRenameBoolean{}.updatedNameForField(v.fieldInput, nil, &v.modelInput, nil)

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

func TestUpdateNameForField_RemoveResourcePrefix(t *testing.T) {
	testData := []struct {
		fieldInput    string
		resourceInput resourcemanager.TerraformResourceDetails
		expected      *string
	}{
		{
			fieldInput: "AnimalPandas",
			resourceInput: resourcemanager.TerraformResourceDetails{
				ResourceName: "Animal",
			},
			expected: stringPointer("Pandas"),
		},
		{
			fieldInput: "Mars",
			resourceInput: resourcemanager.TerraformResourceDetails{
				ResourceName: "Planets",
			},
			expected: nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.fieldInput)

		actual, _ := fieldNameRemoveResourcePrefix{}.updatedNameForField(v.fieldInput, nil, nil, &v.resourceInput)

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

func TestUpdateNameForField_FlattenReferenceId(t *testing.T) {
	testData := []struct {
		fieldInput   string
		modelInput   resourcemanager.ModelDetails
		builderInput Builder
		expected     *string
	}{
		{
			fieldInput: "Panda",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"Panda": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SubResource"),
						},
					},
				},
			},
			builderInput: Builder{
				models: map[string]resourcemanager.ModelDetails{
					"SubResource": {
						Fields: map[string]resourcemanager.FieldDetails{
							"Id": {
								Required: true,
							},
						},
					},
				},
			},
			expected: stringPointer("PandaId"),
		},
		{
			fieldInput: "Planets",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"Planets": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SubResource"),
						},
					},
				},
			},
			builderInput: Builder{
				models: map[string]resourcemanager.ModelDetails{
					"Mars": {
						Fields: map[string]resourcemanager.FieldDetails{
							"Id": {
								Required: true,
							},
							"Mass": {
								Required: true,
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

		actual, _ := fieldNameFlattenReferenceId{}.updatedNameForField(v.fieldInput, &v.builderInput, &v.modelInput, nil)

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

func TestUpdateNameForField_FlattenListReferenceIds(t *testing.T) {
	testData := []struct {
		fieldInput   string
		modelInput   resourcemanager.ModelDetails
		builderInput Builder
		expected     *string
	}{
		{
			fieldInput: "Panda",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"Panda": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ListApiObjectDefinitionType,
							ReferenceName: stringPointer("SubResource"),
						},
					},
				},
			},
			builderInput: Builder{
				models: map[string]resourcemanager.ModelDetails{
					"SubResource": {
						Fields: map[string]resourcemanager.FieldDetails{
							"Ids": {
								Required: true,
							},
						},
					},
				},
			},
			expected: stringPointer("PandaIds"),
		},
		{
			fieldInput: "Planets",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"Planets": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ListApiObjectDefinitionType,
							ReferenceName: stringPointer("SubResource"),
						},
					},
				},
			},
			builderInput: Builder{
				models: map[string]resourcemanager.ModelDetails{
					"Mars": {
						Fields: map[string]resourcemanager.FieldDetails{
							"Ids": {
								Required: true,
							},
							"Mass": {
								Required: true,
							},
						},
					},
				},
			},
			expected: nil,
		},
		{
			fieldInput: "Planets",
			modelInput: resourcemanager.ModelDetails{
				Fields: map[string]resourcemanager.FieldDetails{
					"Planets": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SubResource"),
						},
					},
				},
			},
			builderInput: Builder{
				models: map[string]resourcemanager.ModelDetails{
					"Mars": {
						Fields: map[string]resourcemanager.FieldDetails{
							"Ids": {
								Required: true,
							},
							"Mass": {
								Required: true,
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

		actual, _ := fieldNameFlattenListReferenceIds{}.updatedNameForField(v.fieldInput, &v.builderInput, &v.modelInput, nil)

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
