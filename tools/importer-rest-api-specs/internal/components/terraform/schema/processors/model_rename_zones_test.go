// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestProcessModel_RenameZones_Valid(t *testing.T) {
	testData := []struct {
		modelNameInput   string
		mappingsInput    sdkModels.TerraformMappingDefinition
		modelsInput      map[string]sdkModels.TerraformSchemaModel
		expectedMappings sdkModels.TerraformMappingDefinition
		expectedModels   map[string]sdkModels.TerraformSchemaModel
	}{
		{
			// Availability Zones
			modelNameInput: "Disco",
			modelsInput: map[string]sdkModels.TerraformSchemaModel{
				"Disco": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"AvailabilityZones": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.ListTerraformSchemaObjectDefinitionType,
								NestedObject: &sdkModels.TerraformSchemaObjectDefinition{
									Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
								},
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
							TerraformSchemaFieldName: "AvailabilityZones",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "AvailabilityZones",
						},
					},
				},
			},
			expectedModels: map[string]sdkModels.TerraformSchemaModel{
				"Disco": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Zones": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.ZonesTerraformSchemaObjectDefinitionType,
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
							TerraformSchemaFieldName: "Zones",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "AvailabilityZones",
						},
					},
				},
			},
		},
		{
			// Zones
			modelNameInput: "Disco",
			modelsInput: map[string]sdkModels.TerraformSchemaModel{
				"Disco": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Zones": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.ListTerraformSchemaObjectDefinitionType,
								NestedObject: &sdkModels.TerraformSchemaObjectDefinition{
									Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
								},
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
							TerraformSchemaFieldName: "Zones",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "Zones",
						},
					},
				},
			},
			expectedModels: map[string]sdkModels.TerraformSchemaModel{
				"Disco": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Zones": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.ZonesTerraformSchemaObjectDefinitionType,
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
							TerraformSchemaFieldName: "Zones",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "Zones",
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
		mappingsInput    sdkModels.TerraformMappingDefinition
		modelsInput      map[string]sdkModels.TerraformSchemaModel
		expectedMappings sdkModels.TerraformMappingDefinition
		expectedModels   map[string]sdkModels.TerraformSchemaModel
	}{
		{
			// Availability Zone
			modelNameInput: "Disco",
			modelsInput: map[string]sdkModels.TerraformSchemaModel{
				"Disco": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"AvailabilityZone": {
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
							TerraformSchemaFieldName: "Zone",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "AvailabilityZone",
						},
					},
				},
			},
			expectedModels: map[string]sdkModels.TerraformSchemaModel{
				"Disco": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Zone": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.ZoneTerraformSchemaObjectDefinitionType,
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
							TerraformSchemaFieldName: "Zone",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "AvailabilityZone",
						},
					},
				},
			},
		},
		{
			// Zone
			modelNameInput: "Disco",
			modelsInput: map[string]sdkModels.TerraformSchemaModel{
				"Disco": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Zone": {
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
							TerraformSchemaFieldName: "Zone",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "Zone",
						},
					},
				},
			},
			expectedModels: map[string]sdkModels.TerraformSchemaModel{
				"Disco": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Zone": {
							ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
								Type: sdkModels.ZoneTerraformSchemaObjectDefinitionType,
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
							TerraformSchemaFieldName: "Zone",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "Zone",
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
							TerraformSchemaModelName: "Disco",
							TerraformSchemaFieldName: "AvailabilityZones",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "AvailabilityZones",
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
							TerraformSchemaModelName: "Disco",
							TerraformSchemaFieldName: "AvailabilityZones",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "AvailabilityZones",
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
							TerraformSchemaModelName: "Disco",
							TerraformSchemaFieldName: "AvailabilityZone",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "AvailabilityZone",
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
							TerraformSchemaModelName: "Disco",
							TerraformSchemaFieldName: "AvailabilityZone",
							SDKModelName:             "SomeModel",
							SDKFieldName:             "AvailabilityZone",
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
