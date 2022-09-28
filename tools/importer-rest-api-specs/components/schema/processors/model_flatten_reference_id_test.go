package processors

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestProcessModel_FlattenReferenceId_Valid(t *testing.T) {
	testData := []struct {
		modelNameInput   string
		mappingsInput    resourcemanager.MappingDefinition
		modelsInput      map[string]resourcemanager.TerraformSchemaModelDefinition
		expectedModels   map[string]resourcemanager.TerraformSchemaModelDefinition
		expectedMappings resourcemanager.MappingDefinition
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
			mappingsInput: resourcemanager.MappingDefinition{
				Fields: []resourcemanager.FieldMappingDefinition{
					{
						Type: resourcemanager.DirectAssignmentMappingDefinitionType,
						DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
							SchemaModelName: "Panda",
							SchemaFieldPath: "Subnet",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "Subnet",
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Panda": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"SubnetId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
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
			expectedMappings: resourcemanager.MappingDefinition{
				Fields: []resourcemanager.FieldMappingDefinition{
					{
						Type: resourcemanager.DirectAssignmentMappingDefinitionType,
						DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
							SchemaModelName: "Panda",
							SchemaFieldPath: "SubnetId",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "Subnet",
						},
					},
				},
			},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actualModels, actualMappings, err := modelFlattenReferenceId{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
		if err != nil {
			if v.expectedModels == nil {
				continue
			}

			t.Fatalf("error: %+v", err)
		}

		modelDefinitionsMatch(t, actualModels, v.expectedModels)
		mappingDefinitionsMatch(t, actualMappings, v.expectedMappings)
	}
}

func TestProcessModel_FlattenReferenceId_Invalid(t *testing.T) {
	testData := []struct {
		modelNameInput   string
		mappingsInput    resourcemanager.MappingDefinition
		modelsInput      map[string]resourcemanager.TerraformSchemaModelDefinition
		expectedMappings resourcemanager.MappingDefinition
		expectedModels   map[string]resourcemanager.TerraformSchemaModelDefinition
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
			mappingsInput: resourcemanager.MappingDefinition{
				Fields: []resourcemanager.FieldMappingDefinition{
					{
						Type: resourcemanager.DirectAssignmentMappingDefinitionType,
						DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
							SchemaModelName: "Leopard",
							SchemaFieldPath: "Id",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "Id",
						},
					},
				},
			},
			// unchanged
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
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
			expectedMappings: resourcemanager.MappingDefinition{
				Fields: []resourcemanager.FieldMappingDefinition{
					{
						Type: resourcemanager.DirectAssignmentMappingDefinitionType,
						DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
							SchemaModelName: "Leopard",
							SchemaFieldPath: "Id",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "Id",
						},
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
			mappingsInput: resourcemanager.MappingDefinition{
				Fields: []resourcemanager.FieldMappingDefinition{
					{
						Type: resourcemanager.DirectAssignmentMappingDefinitionType,
						DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
							SchemaModelName: "Meerkat",
							SchemaFieldPath: "Id",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "Id",
						},
					},
				},
			},
			// unchanged since the nested model doesn't match
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
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
			expectedMappings: resourcemanager.MappingDefinition{
				Fields: []resourcemanager.FieldMappingDefinition{
					{
						Type: resourcemanager.DirectAssignmentMappingDefinitionType,
						DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
							SchemaModelName: "Meerkat",
							SchemaFieldPath: "Id",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "Id",
						},
					},
				},
			},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actualModels, actualMappings, err := modelFlattenReferenceId{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
		if err != nil {
			if v.expectedModels == nil {
				continue
			}

			t.Fatalf("error: %+v", err)
		}

		modelDefinitionsMatch(t, actualModels, v.expectedModels)
		mappingDefinitionsMatch(t, actualMappings, v.expectedMappings)
	}
}
