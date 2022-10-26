package processors

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

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
