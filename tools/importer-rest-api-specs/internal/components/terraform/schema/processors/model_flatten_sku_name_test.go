// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestProcessModel_FlattenSkuName_Valid(t *testing.T) {
	testData := []struct {
		modelNameInput   string
		mappingsInput    sdkModels.TerraformMappingDefinition
		modelsInput      map[string]sdkModels.TerraformSchemaModel
		expectedMappings sdkModels.TerraformMappingDefinition
		expectedModels   map[string]sdkModels.TerraformSchemaModel
	}{
		{
			modelNameInput: "Disco",
			modelsInput: map[string]sdkModels.TerraformSchemaModel{
				"Disco": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Sku": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("Sku"),
							},
						},
					},
				},
				"Sku": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Name": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
				"Status": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Code": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
						"Message": {
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
							TerraformSchemaModelName: "Disco",
							TerraformSchemaFieldName: "Sku",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "Sku",
						},
					},
				},
			},
			expectedModels: map[string]sdkModels.TerraformSchemaModel{
				"Disco": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"SkuName": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
				"Sku": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Name": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
				"Status": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Code": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
						"Message": {
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
							TerraformSchemaModelName: "Disco",
							TerraformSchemaFieldName: "SkuName",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "Sku",
						},
					},
				},
			},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actualModels, actualMappings, err := modelFlattenSkuName{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
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

func TestProcessModel_FlattenSkuName_Invalid(t *testing.T) {
	testData := []struct {
		modelNameInput   string
		mappingsInput    sdkModels.TerraformMappingDefinition
		modelsInput      map[string]sdkModels.TerraformSchemaModel
		expectedMappings sdkModels.TerraformMappingDefinition
		expectedModels   map[string]sdkModels.TerraformSchemaModel
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
			// unchanged since the nested model doesn't match
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

		actualModels, actualMappings, err := modelFlattenSkuName{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
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
