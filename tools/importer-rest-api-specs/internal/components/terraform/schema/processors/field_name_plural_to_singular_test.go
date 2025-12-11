// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
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
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"Pandas": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.ListSDKObjectDefinitionType,
								NestedItem: pointer.To(models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								}),
							},
						},
					},
				},
			},
			expected: nil,
		},
		{
			fieldInput: "Statuses",
			metadataInput: FieldMetadata{
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"Statuses": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.ListSDKObjectDefinitionType,
								NestedItem: pointer.To(models.SDKObjectDefinition{
									Type: models.ReferenceSDKObjectDefinitionType,
								}),
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
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"Metadata": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.ListSDKObjectDefinitionType,
								NestedItem: pointer.To(models.SDKObjectDefinition{
									Type: models.ReferenceSDKObjectDefinitionType,
								}),
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
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"Planets": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.StringSDKObjectDefinitionType,
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
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"Bass": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.StringSDKObjectDefinitionType,
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
