// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
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
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
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
