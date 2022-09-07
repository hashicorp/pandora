package processors

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestProcessModel_FlattenReferenceId_Valid(t *testing.T) {
	testData := []struct {
		modelNameInput string
		modelsInput    map[string]resourcemanager.TerraformSchemaModelDefinition
		expected       *map[string]resourcemanager.TerraformSchemaFieldDefinition
	}{
		{
			modelNameInput: "Panda",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Panda": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Subnet": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("SubResource"),
							},
						},
					},
				},
				"SubResource": {
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
				"SubnetId": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeString,
					},
				},
			},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actual, err := modelFlattenReferenceId{}.ProcessModel(v.modelNameInput, v.modelsInput)
		if err != nil {
			if v.expected == nil {
				continue
			}

			t.Fatalf("error: %+v", err)
		}

		if actual == nil {
			if v.expected == nil {
				continue
			}
			t.Fatalf("expected a result but didn't get one")
		}
		if v.expected == nil {
			t.Fatalf("expected no result but got %+v", *actual)
		}
		if !fieldDefinitionsMatch(t, *actual, *v.expected) {
			t.Fatalf("Expected %+v but got %+v", *v.expected, *actual)
		}
	}
}

func TestProcessModel_FlattenReferenceId_Invalid(t *testing.T) {
	testData := []struct {
		modelNameInput string
		modelsInput    map[string]resourcemanager.TerraformSchemaModelDefinition
		expected       *map[string]resourcemanager.TerraformSchemaFieldDefinition
	}{
		{
			modelNameInput: "Leopard",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Leopard": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Id": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("SubResource"),
							},
						},
						"Weight": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
					},
				},
				"SubResource": {
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
				// unchanged
				"Id": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("SubResource"),
					},
				},
				"Weight": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeInteger,
					},
				},
			},
		},
		{
			modelNameInput: "Meerkat",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Meerkat": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Id": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("SubResource"),
							},
						},
					},
				},
				"SubResource": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Id": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"Weight": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
					},
				},
			},
			expected: &map[string]resourcemanager.TerraformSchemaFieldDefinition{
				// unchanged since the nested model doesn't match
				"Id": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: stringPointer("SubResource"),
					},
				},
			},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actual, err := modelFlattenReferenceId{}.ProcessModel(v.modelNameInput, v.modelsInput)
		if err != nil {
			if v.expected == nil {
				continue
			}

			t.Fatalf("error: %+v", err)
		}

		if actual == nil {
			if v.expected == nil {
				continue
			}
			t.Fatalf("expected a result but didn't get one")
		}
		if v.expected == nil {
			t.Fatalf("expected no result but got %+v", *actual)
		}
		if !fieldDefinitionsMatch(t, *actual, *v.expected) {
			t.Fatalf("Expected %+v but got %+v", *v.expected, *actual)
		}
	}
}
