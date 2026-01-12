// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestProcessField_Exists(t *testing.T) {
	t.Parallel()
	testData := []struct {
		fieldInput    string
		metadataInput FieldMetadata
		expectError   bool
	}{
		{
			fieldInput: "Pandas",
			metadataInput: FieldMetadata{
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"Pandas": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.ListSDKObjectDefinitionType,
								NestedItem: &models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
				Model: models.SDKModel{
					Fields: map[string]models.SDKField{
						"Pandas": {
							ObjectDefinition: models.SDKObjectDefinition{
								Type: models.StringSDKObjectDefinitionType,
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
