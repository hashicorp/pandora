// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: tests for the different types of Object Definition

func TestParseModelTopLevel(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_top_level.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionInteger,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionBoolean,
								},
								Required: false,
							},
							"Height": {
								JsonName: "height",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionFloat,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
							"Tags": {
								CustomFieldType: pointer.To(models.CustomFieldTypeTags),
								JsonName:        "tags",
								Required:        false,
							},
							"Value": {
								JsonName: "value",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionRawObject,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelTopLevelWithRawFile(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_top_level_with_rawfile.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionRawFile,
						},
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionRawFile,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelTopLevelWithInlinedModel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_top_level_with_inlined_model.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("ModelProperties"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
						},
					},
					"ModelProperties": {
						Fields: map[string]models.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionInteger,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionBoolean,
								},
								Required: false,
							},
							"Height": {
								JsonName: "height",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionFloat,
								},
								Required: false,
							},
							"Nickname": {
								JsonName: "nickname",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"Tags": {
								CustomFieldType: pointer.To(models.CustomFieldTypeTags),
								JsonName:        "tags",
								Required:        false,
							},
							"Value": {
								JsonName: "value",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionRawObject,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithDateTimeNoType(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_datetime_no_type.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"SomeDateValue": {
								JsonName: "someDateValue",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionDateTime,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithInlinedObject(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_inlined_object.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]models.FieldDetails{
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"UserAssignedIdentities": {
								JsonName: "userAssignedIdentities",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("UserAssignedIdentitiesProperties"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
					"UserAssignedIdentitiesProperties": {
						Fields: map[string]models.FieldDetails{
							"ClientId": {
								JsonName: "clientId",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								ReadOnly: true,
								Required: false,
							},
							"PrincipalId": {
								JsonName: "principalId",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								ReadOnly: true,
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithNumberPrefixedField(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_number_prefixed_field.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"Five0PercentDone": {
								JsonName: "50PercentDone",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithReference(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_reference.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]models.FieldDetails{
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("UserAssignedIdentityProperties"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
						},
					},
					"UserAssignedIdentityProperties": {
						Fields: map[string]models.FieldDetails{
							"UserAssignedIdentity": {
								JsonName: "userAssignedIdentity",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithReferenceToArray(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_reference_array.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"Pets": {
								JsonName: "pets",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("Pet"),
										Type:          models.ObjectDefinitionReference,

										// note: these change substantially in the sdk swap
										Minimum:     pointer.To(1),
										Maximum:     pointer.To(2),
										UniqueItems: pointer.To(true),
									},
									Type: models.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"Pet": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithReferenceToConstant(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_reference_constant.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Constants: map[string]resourcemanager.ConstantDetails{
					"AnimalType": {
						Type: resourcemanager.StringConstant,
						Values: map[string]string{
							"Cat": "Cat",
							"Dog": "Dog",
						},
					},
				},
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]models.FieldDetails{
							"Animal": {
								JsonName: "animal",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("AnimalType"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithReferenceToString(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_reference_string.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]models.FieldDetails{
							"FullyQualifiedDomainName": {
								JsonName: "fullyQualifiedDomainName",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithCircularReferences(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_circular_reference.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Animal": {
						Fields: map[string]models.FieldDetails{
							"FavouriteHouse": {
								JsonName: "favouriteHouse",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("House"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
							"FavouriteHuman": {
								JsonName: "favouriteHuman",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("Human"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
					"House": {
						Fields: map[string]models.FieldDetails{
							"Address": {
								JsonName: "address",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"Residents": {
								JsonName: "residents",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("Human"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"Human": {
						Fields: map[string]models.FieldDetails{
							"Pets": {
								JsonName: "pets",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("Animal"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionList,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("House"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelInheritingFromObjectWithNoExtraFields(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_inheriting_from_other_model_no_new_fields.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"FirstObject": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							// whilst the response model references SecondObject, it's only inheriting from FirstObject
							// and doesn't contain any new fields, so it should be switched out
							ReferenceName: pointer.To("FirstObject"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelInheritingFromObjectWithNoExtraFieldsInlined(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_inheriting_from_other_model_no_new_fields_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"FirstObject": {
						Fields: map[string]models.FieldDetails{
							"Endpoints": {
								JsonName: "endpoints",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("SecondObject"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
					"SecondObject": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("FirstObject"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelInheritingFromObjectWithOnlyDescription(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_inheriting_from_other_model_with_only_description.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"FirstObject": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							// whilst the response model references SecondObject, it's only inheriting from FirstObject
							// and doesn't contain any new fields, so it should be switched out
							ReferenceName: pointer.To("FirstObject"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelInheritingFromObjectWithPropertiesWithinAllOf(t *testing.T) {
	// This test ensures that when a Model inherits from a Model and defines properties within
	// the `AllOf` field, that the Model isn't flattened into the Parent Model.
	// This covers a regression from https://github.com/hashicorp/pandora/pull/3720
	// which surfaced in https://github.com/hashicorp/pandora/pull/3726 for the model `AgentPool`
	// within `ContainerService@2019-08-01/AgentPools` which was renamed `SubResource`.
	actual, err := ParseSwaggerFileForTesting(t, "model_inheriting_from_other_model_with_properties_within_allof.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"SecondObject": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							// SecondObject is referenced as the Response Object, but because it inherits from one Model
							// (FirstObject) and uses another (ThirdObject) it shouldn't be flattened into the parent type(s)
							// and should instead remain `SecondObject`.
							ReferenceName: pointer.To("SecondObject"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelContainingAllOfToTypeObject(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_containing_allof_object_type.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
							"Country": {
								JsonName: "country",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelContainingAllOfToTypeObjectWithProperties(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_containing_allof_object_type_with_properties.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"Country": {
								JsonName: "country",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelContainingAllOfWithinProperties(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_containing_allof_within_properties.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Country": {
								JsonName: "country",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("ModelProperties"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
						},
					},
					"ModelProperties": {
						Fields: map[string]models.FieldDetails{
							"MoreNested": {
								JsonName: "moreNested",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelContainingMultipleAllOfWithinProperties(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_containing_allof_within_properties_multiple.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Options": {
								JsonName: "options",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("ResourceWithLocation"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
							"Resource": {
								JsonName: "resource",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("ModelResource"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
						},
					},
					"ModelResource": {
						Fields: map[string]models.FieldDetails{
							"Country": {
								JsonName: "country",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"MoreNested": {
								JsonName: "moreNested",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
					"ResourceWithLocation": {
						Fields: map[string]models.FieldDetails{
							"Country": {
								JsonName: "country",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelContainingLists(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_containing_lists.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Animals": {
								JsonName: "animals",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("Animal"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionList,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
							"Plants": {
								JsonName: "plants",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										Type: models.ObjectDefinitionString,

										// NOTE: these change substantially in the new SDK
										Maximum:     pointer.To(10),
										Minimum:     pointer.To(1),
										UniqueItems: pointer.To(true),
									},
									Type: models.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"Animal": {
						Fields: map[string]models.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionInteger,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelInlinedWithNoName(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_inlined_with_no_name.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Container": {
						Fields: map[string]models.FieldDetails{
							"Planets": {
								JsonName: "planets",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("ContainerPlanetsInlined"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"ContainerPlanetsInlined": {
						Fields: map[string]models.FieldDetails{
							"ExampleField": {
								JsonName: "exampleField",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Container"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelInheritingFromParent(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_inheriting_from_parent.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionInteger,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionBoolean,
								},
								Required: true,
							},
							"Height": {
								JsonName: "height",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionFloat,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
							"Tags": {
								JsonName:        "tags",
								CustomFieldType: pointer.To(models.CustomFieldTypeTags),
								Required:        true,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelMultipleTopLevelModelsAndOperations(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_multiple_top_level_models_and_operations.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"GetExample": {
						Fields: map[string]models.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionInteger,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionBoolean,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
							"Tags": {
								JsonName:        "tags",
								CustomFieldType: pointer.To(models.CustomFieldTypeTags),
								Required:        false,
							},
						},
					},
					"PutExample": {
						Fields: map[string]models.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionInteger,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionBoolean,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
							"Tags": {
								JsonName:        "tags",
								CustomFieldType: pointer.To(models.CustomFieldTypeTags),
								Required:        false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Get": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Get",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("GetExample"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
					"Put": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Put",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("PutExample"),
							Type:          models.ObjectDefinitionReference,
						},
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("PutExample"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelBug2675DuplicateModel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "models_bug_2675_duplicate_model.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Example": {
				Models: map[string]models.ModelDetails{
					"EnvironmentRole": {
						Fields: map[string]models.FieldDetails{
							"Description": {
								JsonName: "description",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								ReadOnly: true,
								Required: false,
							},
							"RoleName": {
								JsonName: "roleName",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								ReadOnly: true,
								Required: false,
							},
						},
					},
					"ExampleEnvironment": {
						Fields: map[string]models.FieldDetails{
							"Location": {
								JsonName:        "location",
								CustomFieldType: pointer.To(models.CustomFieldTypeLocation),
								Required:        false,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentProperties"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentProperties": {
						Fields: map[string]models.FieldDetails{
							"CreatorRoleAssignment": {
								JsonName: "creatorRoleAssignment",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
							"DeploymentTargetId": {
								JsonName: "deploymentTargetId",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"ProvisioningState": {
								JsonName: "provisioningState",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								ReadOnly: true,
								Required: false,
							},
							"UserRoleAssignments": {
								JsonName: "userRoleAssignments",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("UserRoleAssignment"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentUpdate": {
						Fields: map[string]models.FieldDetails{
							"Example": {
								JsonName: "example",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentUpdateProperties"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentUpdateProperties": {
						Fields: map[string]models.FieldDetails{
							"CreatorRoleAssignment": {
								JsonName: "creatorRoleAssignment",
								ObjectDefinition: &models.ObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment"),
									Type:          models.ObjectDefinitionReference,
								},
								Required: false,
							},
							"DeploymentTargetId": {
								JsonName: "deploymentTargetId",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"UserRoleAssignments": {
								JsonName: "userRoleAssignments",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("UserRoleAssignment"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment": {
						Fields: map[string]models.FieldDetails{
							"Roles": {
								JsonName: "roles",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("EnvironmentRole"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
					"UserRoleAssignment": {
						Fields: map[string]models.FieldDetails{
							"Roles": {
								JsonName: "roles",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("EnvironmentRole"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"CreateOrUpdate": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_CreateOrUpdate",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          models.ObjectDefinitionReference,
						},
						ResourceIdName: pointer.To("EnvironmentId"),
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          models.ObjectDefinitionReference,
						},
					},
					"Get": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Get",
						ResourceIdName:      pointer.To("EnvironmentId"),
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          models.ObjectDefinitionReference,
						},
					},
					"Update": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PATCH",
						OperationId:         "Example_Update",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironmentUpdate"),
							Type:          models.ObjectDefinitionReference,
						},
						ResourceIdName: pointer.To("EnvironmentId"),
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          models.ObjectDefinitionReference,
						},
					},
				},
				ResourceIds: map[string]models.ParsedResourceId{
					"EnvironmentId": {
						Segments: []resourcemanager.ResourceIdSegment{
							NewStaticValueResourceIDSegment("staticEnvironments", "environments"),
							NewUserSpecifiedResourceIDSegment("environmentName", "environmentName"),
						},
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
