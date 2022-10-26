package processors

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

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
