// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestProcessModel_RemoveStatusAndDetail_Valid(t *testing.T) {
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
						"Age": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
						"Status": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("Status"),
							},
						},
						"ConfigurationStatus": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("Status"),
							},
						},
						"Detail": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type:          sdkModels.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("Detail"),
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
				"Detail": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Message": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			mappingsInput: sdkModels.TerraformMappingDefinition{
				// TODO: add me
			},
			expectedModels: map[string]sdkModels.TerraformSchemaModel{
				"Panda": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Age": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.IntegerTerraformSchemaObjectDefinitionType,
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
				"Detail": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Message": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			expectedMappings: sdkModels.TerraformMappingDefinition{
				// TODO: add me
			},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actualModels, actualMappings, err := modelRemoveStatusAndDetail{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
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

func TestProcessModel_RemoveStatusAndDetail_Invalid(t *testing.T) {
	t.Parallel()
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
				// TODO: add me
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
				// TODO: add me
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
				// TODO: add me
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
				// TODO: add me
			},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actualModels, actualMappings, err := modelRemoveStatusAndDetail{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
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
