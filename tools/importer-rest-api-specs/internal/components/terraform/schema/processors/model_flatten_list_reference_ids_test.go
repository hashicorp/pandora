// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestProcessModel_FlattenListReferenceIds_Valid(t *testing.T) {
	t.Parallel()
	testData := []struct {
		modelNameInput   string
		modelsInput      map[string]sdkModels.TerraformSchemaModel
		mappingsInput    sdkModels.TerraformMappingDefinition
		expectedModels   map[string]sdkModels.TerraformSchemaModel
		expectedMappings sdkModels.TerraformMappingDefinition
	}{
		{
			modelNameInput: "Panda",
			modelsInput: map[string]sdkModels.TerraformSchemaModel{
				"Panda": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Friend": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.ListTerraformSchemaObjectDefinitionType,
								NestedObject: &sdkModels.TerraformSchemaObjectDefinition{
									Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
									ReferenceName: stringPointer("SubResource"),
								},
							},
						},
					},
				},
				"SubResource": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Ids": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			mappingsInput: sdkModels.TerraformMappingDefinition{
				Fields: []sdkModels.TerraformFieldMappingDefinition{
					sdkModels.TerraformDirectAssignmentFieldMappingDefinition{
						DirectAssignment: sdkModels.TerraformDirectAssignmentFieldMappingDefinitionImpl{
							TerraformSchemaModelName: "Panda",
							TerraformSchemaFieldName: "Friend",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "Friend",
						},
					},
				},
			},
			expectedModels: map[string]sdkModels.TerraformSchemaModel{
				"Panda": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"FriendIds": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
				"SubResource": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Ids": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			expectedMappings: sdkModels.TerraformMappingDefinition{
				Fields: []sdkModels.TerraformFieldMappingDefinition{
					sdkModels.TerraformDirectAssignmentFieldMappingDefinition{
						DirectAssignment: sdkModels.TerraformDirectAssignmentFieldMappingDefinitionImpl{
							TerraformSchemaModelName: "Panda",
							TerraformSchemaFieldName: "FriendIds",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "Friend",
						},
					},
				},
			},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actualModels, actualMappings, err := modelFlattenListReferenceIds{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
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

func TestProcessModel_FlattenListReferenceIds_Invalid(t *testing.T) {
	t.Parallel()
	testData := []struct {
		modelNameInput   string
		mappingsInput    sdkModels.TerraformMappingDefinition
		modelsInput      map[string]sdkModels.TerraformSchemaModel
		expectedModels   map[string]sdkModels.TerraformSchemaModel
		expectedMappings sdkModels.TerraformMappingDefinition
	}{
		{
			modelNameInput: "Leopard",
			modelsInput: map[string]sdkModels.TerraformSchemaModel{
				"Leopard": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Id": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("SubResource"),
							},
						},
						"Weight": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
				"SubResource": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Id": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			mappingsInput: sdkModels.TerraformMappingDefinition{
				Fields: []sdkModels.TerraformFieldMappingDefinition{
					sdkModels.TerraformDirectAssignmentFieldMappingDefinition{
						DirectAssignment: sdkModels.TerraformDirectAssignmentFieldMappingDefinitionImpl{
							TerraformSchemaModelName: "Leopard",
							TerraformSchemaFieldName: "Id",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "Id",
						},
					},
				},
			},
			// unchanged
			expectedModels: map[string]sdkModels.TerraformSchemaModel{
				"Leopard": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Id": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("SubResource"),
							},
						},
						"Weight": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
				"SubResource": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Id": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			expectedMappings: sdkModels.TerraformMappingDefinition{
				Fields: []sdkModels.TerraformFieldMappingDefinition{
					sdkModels.TerraformDirectAssignmentFieldMappingDefinition{
						DirectAssignment: sdkModels.TerraformDirectAssignmentFieldMappingDefinitionImpl{
							TerraformSchemaModelName: "Leopard",
							TerraformSchemaFieldName: "Id",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "Id",
						},
					},
				},
			},
		},
		{
			modelNameInput: "Meerkat",
			modelsInput: map[string]sdkModels.TerraformSchemaModel{
				"Meerkat": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Id": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("SubResource"),
							},
						},
					},
				},
				"SubResource": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Id": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
						"Weight": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			mappingsInput: sdkModels.TerraformMappingDefinition{
				Fields: []sdkModels.TerraformFieldMappingDefinition{
					sdkModels.TerraformDirectAssignmentFieldMappingDefinition{
						DirectAssignment: sdkModels.TerraformDirectAssignmentFieldMappingDefinitionImpl{
							TerraformSchemaModelName: "Meerkat",
							TerraformSchemaFieldName: "Id",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "Id",
						},
					},
				},
			},
			// unchanged
			expectedModels: map[string]sdkModels.TerraformSchemaModel{
				"Meerkat": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Id": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("SubResource"),
							},
						},
					},
				},
				"SubResource": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Id": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
						"Weight": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			expectedMappings: sdkModels.TerraformMappingDefinition{
				Fields: []sdkModels.TerraformFieldMappingDefinition{
					sdkModels.TerraformDirectAssignmentFieldMappingDefinition{
						DirectAssignment: sdkModels.TerraformDirectAssignmentFieldMappingDefinitionImpl{
							TerraformSchemaModelName: "Meerkat",
							TerraformSchemaFieldName: "Id",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "Id",
						},
					},
				},
			},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actualModels, actualMappings, err := modelFlattenListReferenceIds{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
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
