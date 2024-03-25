// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestProcessModel_RenameZones_Valid(t *testing.T) {
	testData := []struct {
		modelNameInput   string
		mappingsInput    resourcemanager.MappingDefinition
		modelsInput      map[string]resourcemanager.TerraformSchemaModelDefinition
		expectedMappings resourcemanager.MappingDefinition
		expectedModels   map[string]resourcemanager.TerraformSchemaModelDefinition
	}{
		{
			// Availability Zones
			modelNameInput: "Disco",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Disco": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"AvailabilityZones": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.ListTerraformSchemaObjectDefinitionType,
								NestedObject: &models.TerraformSchemaObjectDefinition{
									Type: models.StringTerraformSchemaObjectDefinitionType,
								},
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
							SchemaModelName: "Disco",
							SchemaFieldPath: "AvailabilityZones",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "AvailabilityZones",
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Disco": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Zones": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.ZonesTerraformSchemaObjectDefinitionType,
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
							SchemaModelName: "Disco",
							SchemaFieldPath: "Zones",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "AvailabilityZones",
						},
					},
				},
			},
		},
		{
			// Zones
			modelNameInput: "Disco",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Disco": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Zones": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.ListTerraformSchemaObjectDefinitionType,
								NestedObject: &models.TerraformSchemaObjectDefinition{
									Type: models.StringTerraformSchemaObjectDefinitionType,
								},
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
							SchemaModelName: "Disco",
							SchemaFieldPath: "Zones",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "Zones",
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Disco": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Zones": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.ZonesTerraformSchemaObjectDefinitionType,
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
							SchemaModelName: "Disco",
							SchemaFieldPath: "Zones",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "Zones",
						},
					},
				},
			},
		},
	}

	for i, v := range testData {
		t.Logf("[DEBUG] Testing %s (%d)", v.modelNameInput, i)

		actualModels, actualMappings, err := modelRenameZones{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
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

func TestProcessModel_RenameZone_Valid(t *testing.T) {
	testData := []struct {
		modelNameInput   string
		mappingsInput    resourcemanager.MappingDefinition
		modelsInput      map[string]resourcemanager.TerraformSchemaModelDefinition
		expectedMappings resourcemanager.MappingDefinition
		expectedModels   map[string]resourcemanager.TerraformSchemaModelDefinition
	}{
		{
			// Availability Zone
			modelNameInput: "Disco",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Disco": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"AvailabilityZone": {
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
							SchemaModelName: "Disco",
							SchemaFieldPath: "Zone",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "AvailabilityZone",
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Disco": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Zone": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.ZoneTerraformSchemaObjectDefinitionType,
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
							SchemaModelName: "Disco",
							SchemaFieldPath: "Zone",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "AvailabilityZone",
						},
					},
				},
			},
		},
		{
			// Zone
			modelNameInput: "Disco",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Disco": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Zone": {
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
							SchemaModelName: "Disco",
							SchemaFieldPath: "Zone",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "Zone",
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"Disco": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Zone": {
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.ZoneTerraformSchemaObjectDefinitionType,
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
							SchemaModelName: "Disco",
							SchemaFieldPath: "Zone",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "Zone",
						},
					},
				},
			},
		},
	}

	for i, v := range testData {
		t.Logf("[DEBUG] Testing %s (%d)", v.modelNameInput, i)

		actualModels, actualMappings, err := modelRenameZones{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
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

func TestProcessModel_RenameZones_Invalid(t *testing.T) {
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
							SchemaModelName: "Disco",
							SchemaFieldPath: "AvailabilityZones",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "AvailabilityZones",
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
							SchemaModelName: "Disco",
							SchemaFieldPath: "AvailabilityZones",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "AvailabilityZones",
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
							SchemaModelName: "Disco",
							SchemaFieldPath: "AvailabilityZone",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "AvailabilityZone",
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
							SchemaModelName: "Disco",
							SchemaFieldPath: "AvailabilityZone",
							SdkModelName:    "SomeModel",
							SdkFieldPath:    "AvailabilityZone",
						},
					},
				},
			},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actualModels, actualMappings, err := modelRenameZones{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
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
