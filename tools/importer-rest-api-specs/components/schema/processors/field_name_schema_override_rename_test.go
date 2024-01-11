package processors

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestProcessField_SchemaOverrideRename(t *testing.T) {
	testData := []struct {
		fieldInput    string
		metadataInput FieldMetadata
		expected      *string
	}{
		{
			fieldInput: "name",
			metadataInput: FieldMetadata{
				TerraformDetails: resourcemanager.TerraformResourceDetails{
					SchemaOverrides: &map[string]string{
						"name": "target_resource_id",
					},
				},
			},
			expected: stringPointer("TargetResourceId"),
		},
		{
			fieldInput: "ThreeCoffeesADay",
			metadataInput: FieldMetadata{
				TerraformDetails: resourcemanager.TerraformResourceDetails{
					SchemaOverrides: &map[string]string{
						"name": "target_resource_id",
					},
				},
			},
			expected: nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.fieldInput)

		actual, _ := fieldNameSchemaOverrideRename{}.ProcessField(v.fieldInput, v.metadataInput)

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
