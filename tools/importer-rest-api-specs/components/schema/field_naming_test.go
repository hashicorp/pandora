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

		actual := fieldNameIs{}.updatedNameForField(v.input, nil, nil, nil)

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

		actual := fieldNamePluralToSingular{}.updatedNameForField(v.fieldInput, nil, &v.modelInput, nil)

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

		actual := fieldNameRenameBoolean{}.updatedNameForField(v.fieldInput, nil, &v.modelInput, nil)

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
			fieldInput: "animalPandas",
			resourceInput: resourcemanager.TerraformResourceDetails{
				ResourceName: "animal",
			},
			expected: stringPointer("Pandas"),
		},
		{
			fieldInput: "mars",
			resourceInput: resourcemanager.TerraformResourceDetails{
				ResourceName: "Planets",
			},
			expected: nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.fieldInput)

		actual := fieldNameRemoveResourcePrefix{}.updatedNameForField(v.fieldInput, nil, nil, &v.resourceInput)

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
		//{
		//	fieldInput: "mars",
		//	resourceInput: resourcemanager.TerraformResourceDetails{
		//		ResourceName: "Planets",
		//	},
		//	expected: nil,
		//},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.fieldInput)

		actual := fieldNameFlattenReferenceId{}.updatedNameForField(v.fieldInput, &v.builderInput, &v.modelInput, nil)

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
