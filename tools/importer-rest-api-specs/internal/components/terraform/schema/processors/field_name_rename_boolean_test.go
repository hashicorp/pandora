// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestProcessField_RenameBoolean(t *testing.T) {
	t.Parallel()
	testData := []struct {
		fieldInput    string
		metadataInput FieldMetadata
		expected      *string
	}{
		{
			fieldInput: "enablePandas",
			metadataInput: FieldMetadata{
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"enablePandas": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.BooleanSDKObjectDefinitionType,
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
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"disablePlanets": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.BooleanSDKObjectDefinitionType,
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
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"AllowedPublicAccess": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.BooleanSDKObjectDefinitionType,
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
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"AllowTethering": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.BooleanSDKObjectDefinitionType,
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
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"TastesLikePancakes": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.BooleanSDKObjectDefinitionType,
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
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"ThreeCoffeesADay": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.BooleanSDKObjectDefinitionType,
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
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"Enabled": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.BooleanSDKObjectDefinitionType,
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
