package processors

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"strings"
	"testing"
)

func TestProcessModel_FlattenEncryptionPropertiesValid(t *testing.T) {
	testData := []struct {
		modelNameInput string
		modelsInput    map[string]resourcemanager.TerraformSchemaModelDefinition
		expectedModels map[string]resourcemanager.TerraformSchemaModelDefinition
		mappingsInput  resourcemanager.MappingDefinition
	}{
		{
			modelNameInput: "EncryptionProperties",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"EncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"EncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"KeyVaultKeyId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
		},
	}
	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actualModels, _, err := modelFlattenEncryptionProperties{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
		if err != nil {
			if v.expectedModels == nil {
				continue
			}

			t.Fatalf("error: %+v", err)
		}

		modelDefinitionsMatch(t, actualModels, v.expectedModels)
	}
}

func TestProcessModel_FlattenEncryptionPropertiesInValid(t *testing.T) {
	testData := []struct {
		modelNameInput string
		modelsInput    map[string]resourcemanager.TerraformSchemaModelDefinition
		expectedModels map[string]resourcemanager.TerraformSchemaModelDefinition
		mappingsInput  resourcemanager.MappingDefinition
		expectedError  string
	}{
		{
			modelNameInput: "NotEncryptionPropertiesNot",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"EncryptionPropertiesNot": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"EncryptionPropertiesNot": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
		},
		{
			modelNameInput: "ModelWasNotFoundEncryptionProperties",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
			expectedError: "the model \"ModelWasNotFoundEncryptionProperties\" was not found",
		},
		{
			modelNameInput: "ExtraInfoEncryptionProperties",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"ExtraInfoEncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"ExtraStuff": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"ExtraInfoEncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"ExtraStuff": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
		},
		{
			modelNameInput: "IdentityWrongTypeEncryptionProperties",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"IdentityWrongTypeEncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"IdentityWrongTypeEncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
		},
		{
			modelNameInput: "KeyUrlWrongTypeEncryptionProperties",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"KeyUrlWrongTypeEncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"KeyUrlWrongTypeEncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
		},
		{
			modelNameInput: "IdentityModelTooManyFieldsEncryptionProperties",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"IdentityModelTooManyFieldsEncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"ExtraStuff": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"IdentityModelTooManyFieldsEncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"ExtraStuff": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
		},
		{
			modelNameInput: "IdentityUserAssignedIdentityTypeWrongEncryptionProperties",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"IdentityUserAssignedIdentityTypeWrongEncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"IdentityUserAssignedIdentityTypeWrongEncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
					},
				},
			},
		},
		{
			modelNameInput: "IdentityUserAssignedIdentityTypeWrongEncryptionProperties",
			modelsInput: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"IdentityUserAssignedIdentityTypeWrongEncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
			expectedModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"IdentityUserAssignedIdentityTypeWrongEncryptionProperties": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Identity": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type:          resourcemanager.TerraformSchemaFieldTypeReference,
								ReferenceName: stringPointer("EncryptionPropertiesIdentity"),
							},
						},
						"KeyUrl": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
					},
				},
				"EncryptionPropertiesIdentity": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Type": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeInteger,
							},
						},
						"UserAssignedIdentityId": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
						},
					},
				},
			},
		},
	}
	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.modelNameInput)

		actualModels, _, err := modelFlattenEncryptionProperties{}.ProcessModel(v.modelNameInput, v.modelsInput[v.modelNameInput], v.modelsInput, v.mappingsInput)
		if err != nil {
			if v.expectedModels == nil {
				continue
			}

			if v.expectedError != "" {
				if !strings.EqualFold(err.Error(), v.expectedError) {
					t.Fatalf("expected error to match %q. instead got %q", v.expectedError, err)
				}
				continue
			}

			t.Fatalf("error: %+v", err)
		}

		modelDefinitionsMatch(t, actualModels, v.expectedModels)
	}
}
