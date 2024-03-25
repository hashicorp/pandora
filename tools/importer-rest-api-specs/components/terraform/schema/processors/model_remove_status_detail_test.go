// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestProcessModel_RemoveStatusAndDetail_Valid(t *testing.T) {
	testData := []struct {
		modelNameInput   string
		modelsInput      map[string]resourcemanager.TerraformSchemaModelDefinition
		mappingsInput    resourcemanager.MappingDefinition
		expectedModels   map[string]resourcemanager.TerraformSchemaModelDefinition
		expectedMappings resourcemanager.MappingDefinition
	}{
		{
			modelNameInput: "Panda",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Panda": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Age": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
						"Status": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("Status"),
							},
						},
						"ConfigurationStatus": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("Status"),
							},
						},
						"Detail": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("Detail"),
							},
						},
					},
				},
				"Status": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Code": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
						"Message": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
				"Detail": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Message": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			mappingsInput: resourcemanager.MappingDefinition{
				// TODO: add me
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Panda": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Age": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
				"Status": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Code": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
						"Message": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
				"Detail": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Message": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			expectedMappings: resourcemanager.MappingDefinition{
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
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("SubResource"),
							},
						},
						"Weight": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
				"SubResource": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Id": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			mappingsInput: resourcemanager.MappingDefinition{
				// TODO: add me
			},
			// unchanged
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Leopard": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Id": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("SubResource"),
							},
						},
						"Weight": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
				"SubResource": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Id": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			expectedMappings: resourcemanager.MappingDefinition{
				// TODO: add me
			},
		},
		{
			modelNameInput: "Meerkat",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Meerkat": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Id": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("SubResource"),
							},
						},
					},
				},
				"SubResource": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Id": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
						},
						"Weight": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			mappingsInput: resourcemanager.MappingDefinition{
				// TODO: add me
			},
			// unchanged since the nested model doesn't match
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Meerkat": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Id": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
								ReferenceName: stringPointer("SubResource"),
							},
						},
					},
				},
				"SubResource": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Id": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
						},
						"Weight": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.IntegerTerraformSchemaObjectDefinitionType,
							},
						},
					},
				},
			},
			expectedMappings: resourcemanager.MappingDefinition{
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
