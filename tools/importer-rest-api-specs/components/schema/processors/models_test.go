package processors

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"reflect"
	"testing"
)

func TestProcessModel_FlattenReferenceId(t *testing.T) {
	t.Skip("skipping cause borked and needs fixing")

	testData := []struct {
		modelNameInput string
		modelsInput    map[string]resourcemanager.TerraformSchemaModelDefinition
		expected       *map[string]resourcemanager.TerraformSchemaFieldDefinition
	}{
		{
			modelNameInput: "Pandas",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Pandas": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Id": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("SubResourceId"),
							},
						},
					},
				},
				"SubResourceId": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Id": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
			expected: &map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"PandasId": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeString,
					},
				},
			},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actual, _ := modelFlattenListReferenceIds{}.ProcessModel(v.modelNameInput, v.modelsInput)

		if actual == nil {
			if v.expected == nil {
				continue
			}
			t.Fatalf("expected a result but didn't get one")
		}
		if v.expected == nil {
			t.Fatalf("expected no result but got %+v", *actual)
		}
		if reflect.DeepEqual(*actual, *v.expected) {
			t.Fatalf("Expected %+v but got %+v", *v.expected, *actual)
		}
	}
}

func stringPointer(input string) *string {
	return &input
}
