// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseModelTopLevel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_top_level.json")
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

// --- Refactored above this line ---

func TestParseModelSingleContainingAllOfToTypeObject(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_containing_allof_object_type.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	hello, ok := result.Resources["Hello"]
	if !ok {
		t.Fatalf("no resources were output with the tag Hello")
	}

	if len(hello.Constants) != 0 {
		t.Fatalf("expected no Constants but got %d", len(hello.Constants))
	}
	if len(hello.Models) != 1 {
		t.Fatalf("expected 1 Model but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	example, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model named Example")
	}
	if len(example.Fields) != 2 {
		t.Fatalf("expected the model Example to have 2 fields but got %d", len(example.Fields))
	}
}

func TestParseModelSingleContainingAllOfToTypeObjectWithProperties(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_containing_allof_object_type_with_properties.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	hello, ok := result.Resources["Hello"]
	if !ok {
		t.Fatalf("no resources were output with the tag Hello")
	}

	if len(hello.Constants) != 0 {
		t.Fatalf("expected no Constants but got %d", len(hello.Constants))
	}
	if len(hello.Models) != 1 {
		t.Fatalf("expected 1 Model but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	example, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model named Example")
	}
	if len(example.Fields) != 2 {
		t.Fatalf("expected the model Example to have 2 fields but got %d", len(example.Fields))
	}
}

func TestParseModelSingleContainingAllOfWithinProperties(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_containing_allof_within_properties.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	hello, ok := result.Resources["Hello"]
	if !ok {
		t.Fatalf("no resources were output with the tag Hello")
	}

	if len(hello.Constants) != 0 {
		t.Fatalf("expected no Constants but got %d", len(hello.Constants))
	}
	if len(hello.Models) != 2 {
		t.Fatalf("expected 2 Model but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	example, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model named Example")
	}
	if len(example.Fields) != 2 {
		t.Fatalf("expected the model Example to have 2 fields but got %d", len(example.Fields))
	}

	props, ok := hello.Models["ExampleProperties"]
	if !ok {
		t.Fatalf("expected there to be a model named ExampleProperties")
	}
	if len(props.Fields) != 3 {
		t.Fatalf("expected the model ExampleProperties to have 3 fields but got %d", len(props.Fields))
	}
}

func TestParseModelSingleContainingMultipleAllOfWithinProperties(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_containing_allof_within_properties_multiple.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	hello, ok := result.Resources["Hello"]
	if !ok {
		t.Fatalf("no resources were output with the tag Hello")
	}

	if len(hello.Constants) != 0 {
		t.Fatalf("expected no Constants but got %d", len(hello.Constants))
	}
	if len(hello.Models) != 3 {
		t.Fatalf("expected 2 Model but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	example, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model named Example")
	}
	if len(example.Fields) != 2 {
		t.Fatalf("expected the model Example to have 2 fields but got %d", len(example.Fields))
	}

	props, ok := hello.Models["ExampleResource"]
	if !ok {
		t.Fatalf("expected there to be a model named ExampleProperties")
	}
	if len(props.Fields) != 3 {
		t.Fatalf("expected the model ExampleProperties to have 3 fields but got %d", len(props.Fields))
	}
}

func TestParseModelInlinedWithNoName(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_inlined_with_no_name.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Example"]
	if !ok {
		t.Fatal("the Resource 'Example' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 0 {
		t.Fatalf("expected 0 constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 0 {
		t.Fatalf("expected no Resource IDs but got %d", len(resource.ResourceIds))
	}

	test, ok := resource.Operations["Test"]
	if !ok {
		t.Fatalf("the operation Test was not found")
	}
	if test.ResponseObject == nil {
		t.Fatalf("the operation Test had no response object")
	}
	if *test.ResponseObject.ReferenceName != "Container" {
		t.Fatalf("expected the operation Test to have Response Model of `Container` but got %q", *test.ResponseObject.ReferenceName)
	}

	container, ok := resource.Models["Container"]
	if !ok {
		t.Fatalf("the model Container was not found")
	}
	field, ok := container.Fields["Planets"]
	if !ok {
		t.Fatalf("the field Planets was not found within the model Container")
	}
	if field.ObjectDefinition.Type != models.ObjectDefinitionList {
		t.Fatalf("the field Planets within the model Container should be a List but got %q", string(field.ObjectDefinition.Type))
	}
	if field.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("the field Planets within the model Container should be a List of a Reference but got %q", string(field.ObjectDefinition.NestedItem.Type))
	}
	if *field.ObjectDefinition.NestedItem.ReferenceName != "ContainerPlanetsInlined" {
		t.Fatalf("the field Planets within the model Container should be a List of a Reference to ContainerPlanetsInlined but got %q", *field.ObjectDefinition.NestedItem.ReferenceName)
	}

	containerPlanet, ok := resource.Models["ContainerPlanetsInlined"]
	if !ok {
		t.Fatalf("the model ContainerPlanetsInlined was not found")
	}
	if len(containerPlanet.Fields) != 1 {
		t.Fatalf("expected the model ContainerPlanetsInlined to have 1 field but got %d", len(containerPlanet.Fields))
	}
}

func TestParseModelMultipleTopLevel(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_multiple.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 0 {
		t.Fatalf("expected 0 constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 2 {
		t.Fatalf("expected 2 operations but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	var validateModel = func(t *testing.T, input models.ModelDetails) {
		if len(input.Fields) != 4 {
			t.Fatalf("expected input.Fields to have 4 fields but got %d", len(input.Fields))
		}

		name, ok := input.Fields["Name"]
		if !ok {
			t.Fatalf("input.Fields['Name'] was missing")
		}
		if name.ObjectDefinition.Type != models.ObjectDefinitionString {
			t.Fatalf("expected input.Fields['Name'] to be a string but got %q", string(name.ObjectDefinition.Type))
		}
		if name.JsonName != "name" {
			t.Fatalf("expected input.Fields['Name'].JsonName to be 'name' but got %q", name.JsonName)
		}

		age, ok := input.Fields["Age"]
		if !ok {
			t.Fatalf("input.Fields['Age'] was missing")
		}
		if age.ObjectDefinition.Type != models.ObjectDefinitionInteger {
			t.Fatalf("expected input.Fields['Age'] to be an integer but got %q", string(age.ObjectDefinition.Type))
		}
		if age.JsonName != "age" {
			t.Fatalf("expected input.Fields['Age'].JsonName to be 'age' but got %q", age.JsonName)
		}

		enabled, ok := input.Fields["Enabled"]
		if !ok {
			t.Fatalf("input.Fields['Enabled'] was missing")
		}
		if enabled.ObjectDefinition.Type != models.ObjectDefinitionBoolean {
			t.Fatalf("expected input.Fields['Enabled'] to be a boolean but got %q", string(enabled.ObjectDefinition.Type))
		}
		if enabled.JsonName != "enabled" {
			t.Fatalf("expected input.Fields['Enabled'].JsonName to be 'enabled' but got %q", enabled.JsonName)
		}

		tags, ok := input.Fields["Tags"]
		if !ok {
			t.Fatalf("input.Fields['Tags'] was missing")
		}
		if tags.ObjectDefinition != nil {
			t.Fatalf("expected input.Fields['Tags'] to have no ObjectDefinition but got %+v", *tags.ObjectDefinition)
		}
		if tags.CustomFieldType == nil {
			t.Fatalf("expected input.Fields['Tags'] to have a CustomFieldType but it was nil")
		}
		if *tags.CustomFieldType != models.CustomFieldTypeTags {
			t.Fatalf("expected input.Fields['Tags'].CustomFieldType to be Tags but got %q", string(*tags.CustomFieldType))
		}
		if tags.JsonName != "tags" {
			t.Fatalf("expected input.Fields['Tags'].JsonName to be 'tags' but got %q", tags.JsonName)
		}
	}

	t.Log("Testing GetExample..")
	getExample, ok := resource.Models["GetExample"]
	if !ok {
		t.Fatalf("the Model `GetExample` was not found")
	}
	validateModel(t, getExample)

	t.Log("Testing PutExample..")
	putExample, ok := resource.Models["PutExample"]
	if !ok {
		t.Fatalf("the Model `PutExample` was not found")
	}
	validateModel(t, putExample)
}

func TestParseModelMultipleTopLevelWithList(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_multiple_list.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 0 {
		t.Fatalf("expected 0 constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	person, ok := resource.Models["Person"]
	if !ok {
		t.Fatalf("the Model `Person` was not found")
	}
	if len(person.Fields) != 3 {
		t.Fatalf("expected person.Fields to have 3 fields but got %d", len(person.Fields))
	}

	personName, ok := person.Fields["Name"]
	if !ok {
		t.Fatalf("person.Fields['Name'] was missing")
	}
	if personName.ObjectDefinition.Type != models.ObjectDefinitionString {
		t.Fatalf("expected person.Fields['Name'] to be a string but got %q", string(personName.ObjectDefinition.Type))
	}
	if personName.JsonName != "name" {
		t.Fatalf("expected person.Fields['Name'].JsonName to be 'name' but got %q", personName.JsonName)
	}

	animals, ok := person.Fields["Animals"]
	if !ok {
		t.Fatalf("person.Fields['Animals'] was missing")
	}
	if animals.ObjectDefinition.Type != models.ObjectDefinitionList {
		t.Fatalf("expected person.Fields['Animals'] to be a List but got %q", string(animals.ObjectDefinition.Type))
	}
	if animals.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected person.Fields['Animals'] to be a List but got %q", string(animals.ObjectDefinition.NestedItem.Type))
	}
	if *animals.ObjectDefinition.NestedItem.ReferenceName != "Animal" {
		t.Fatalf("person.Fields['Animals'].ModelReference should be 'Animal' but was %q", *animals.ObjectDefinition.NestedItem.ReferenceName)
	}
	if animals.ObjectDefinition.NestedItem.Minimum != nil {
		t.Fatalf("expected person.Fields['Animals'].ObjectDefinition.NestedItem.Minimum to be nil but got %v", *animals.ObjectDefinition.NestedItem.Minimum)
	}
	if animals.ObjectDefinition.NestedItem.Maximum != nil {
		t.Fatalf("expected person.Fields['Animals'].ObjectDefinition.NestedItem.Maximum to be nil but got %v", *animals.ObjectDefinition.NestedItem.Maximum)
	}
	if animals.ObjectDefinition.NestedItem.UniqueItems == nil {
		t.Fatalf("expected person.Fields['Animals'].ObjectDefinition.NestedItem.UniqueItems to be false but got nil")
	}
	if *animals.ObjectDefinition.NestedItem.UniqueItems {
		t.Fatalf("expected person.Fields['Animals'].ObjectDefinition.NestedItem.UniqueItems to be false but got true")
	}
	if animals.JsonName != "animals" {
		t.Fatalf("expected person.Fields['Animals'].JsonName to be 'animals' but got %q", animals.JsonName)
	}

	plants, ok := person.Fields["Plants"]
	if !ok {
		t.Fatalf("person.Fields['Plants'] was missing")
	}
	if plants.ObjectDefinition.NestedItem.Maximum == nil {
		t.Fatalf("expected person.Fields['Plants'].ObjectDefinition.NestedItem.Maximum to be 10 but got nil")
	}
	if *plants.ObjectDefinition.NestedItem.Maximum != 10 {
		t.Fatalf("expected person.Fields['Plants'].ObjectDefinition.NestedItem.Maximum to be 10 but got %d", *plants.ObjectDefinition.NestedItem.Maximum)
	}
	if plants.ObjectDefinition.NestedItem.Minimum == nil {
		t.Fatalf("expected person.Fields['Plants'].ObjectDefinition.NestedItem.Minimum to be 1 but got nil")
	}
	if *plants.ObjectDefinition.NestedItem.Minimum != 1 {
		t.Fatalf("expected person.Fields['Plants'].ObjectDefinition.NestedItem.Minimum to be 1 but got %d", *plants.ObjectDefinition.NestedItem.Minimum)
	}
	if plants.ObjectDefinition.NestedItem.UniqueItems == nil {
		t.Fatalf("expected person.Fields['Plants'].ObjectDefinition.NestedItem.UniqueItems to be true but got nil")
	}
	if !*plants.ObjectDefinition.NestedItem.UniqueItems {
		t.Fatalf("expected person.Fields['Plants'].ObjectDefinition.NestedItem.UniqueItems to be true but got false")
	}

	animalModel, ok := resource.Models["Animal"]
	if !ok {
		t.Fatal("expected resource.Models['Animal'] was not found")
	}
	if len(animalModel.Fields) != 2 {
		t.Fatalf("expected resource.Models['Animal'].Fields to have 2 items but got %d", len(animalModel.Fields))
	}

	animalName, ok := animalModel.Fields["Name"]
	if !ok {
		t.Fatalf("animalModel.Fields['Name'] was missing")
	}
	if animalName.ObjectDefinition.Type != models.ObjectDefinitionString {
		t.Fatalf("expected animalModel.Fields['Name'] to be a string but got %q", string(animalName.ObjectDefinition.Type))
	}
	if animalName.JsonName != "name" {
		t.Fatalf("expected animalModel.Fields['Name'].JsonName to be 'name' but got %q", animalName.JsonName)
	}
	if animalName.ObjectDefinition.Minimum != nil {
		t.Fatalf("expected person.Fields['Name'].ObjectDefinition.Minimum to be nil but got %v", *animalName.ObjectDefinition.Minimum)
	}
	if animalName.ObjectDefinition.Maximum != nil {
		t.Fatalf("expected person.Fields['Name'].ObjectDefinition.Maximum to be nil but got %v", *animalName.ObjectDefinition.Maximum)
	}
	if animalName.ObjectDefinition.UniqueItems != nil {
		t.Fatalf("expected person.Fields['Name'].ObjectDefinition.UniqueItems to be nil but got %v", *animalName.ObjectDefinition.UniqueItems)
	}

	animalAge, ok := animalModel.Fields["Age"]
	if !ok {
		t.Fatalf("animalModel.Fields['Age'] was missing")
	}
	if animalAge.ObjectDefinition.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected animalModel.Fields['Age'] to be a string but got %q", string(animalAge.ObjectDefinition.Type))
	}
	if animalAge.JsonName != "age" {
		t.Fatalf("expected animalModel.Fields['Age'].JsonName to be 'age' but got %q", animalAge.JsonName)
	}
}

func TestParseModelMultipleTopLevelInheritance(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_multiple_inheritance.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 0 {
		t.Fatalf("expected 0 constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 1 {
		t.Fatalf("expected 1 model but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	example, ok := resource.Models["Example"]
	if !ok {
		t.Fatalf("the Model `Example` was not found")
	}
	if len(example.Fields) != 5 {
		t.Fatalf("expected example.Fields to have 5 fields but got %d", len(example.Fields))
	}

	name, ok := example.Fields["Name"]
	if !ok {
		t.Fatalf("example.Fields['Name'] was missing")
	}
	if name.ObjectDefinition.Type != models.ObjectDefinitionString {
		t.Fatalf("expected example.Fields['Name'] to be a string but got %q", string(name.ObjectDefinition.Type))
	}
	if name.JsonName != "name" {
		t.Fatalf("expected example.Fields['Name'].JsonName to be 'name' but got %q", name.JsonName)
	}
	if !name.Required {
		t.Fatalf("expected example.Fields['Name'].Required to be 'true'")
	}

	age, ok := example.Fields["Age"]
	if !ok {
		t.Fatalf("example.Fields['Age'] was missing")
	}
	if age.ObjectDefinition.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected example.Fields['Age'] to be an integer but got %q", string(age.ObjectDefinition.Type))
	}
	if age.JsonName != "age" {
		t.Fatalf("expected example.Fields['Age'].JsonName to be 'age' but got %q", age.JsonName)
	}
	if age.Required {
		t.Fatalf("expected example.Fields['Age'].Required to be 'false'")
	}

	enabled, ok := example.Fields["Enabled"]
	if !ok {
		t.Fatalf("example.Fields['Enabled'] was missing")
	}
	if enabled.ObjectDefinition.Type != models.ObjectDefinitionBoolean {
		t.Fatalf("expected example.Fields['Enabled'] to be a boolean but got %q", string(enabled.ObjectDefinition.Type))
	}
	if enabled.JsonName != "enabled" {
		t.Fatalf("expected example.Fields['Enabled'].JsonName to be 'enabled' but got %q", enabled.JsonName)
	}
	if !enabled.Required {
		t.Fatalf("expected example.Fields['Enabled'].Required to be 'true'")
	}

	height, ok := example.Fields["Height"]
	if !ok {
		t.Fatalf("example.Fields['Height'] was missing")
	}
	if height.ObjectDefinition.Type != models.ObjectDefinitionFloat {
		t.Fatalf("expected example.Fields['Height'] to be a float but got %q", string(height.ObjectDefinition.Type))
	}
	if height.JsonName != "height" {
		t.Fatalf("expected example.Fields['Height'].JsonName to be 'height' but got %q", height.JsonName)
	}
	if height.Required {
		t.Fatalf("expected example.Fields['Height'].Required to be 'false'")
	}

	tags, ok := example.Fields["Tags"]
	if !ok {
		t.Fatalf("example.Fields['Tags'] was missing")
	}
	if tags.ObjectDefinition != nil {
		t.Fatalf("expected example.Fields['Tags'] to have no ObjectDefinition but got %+v", *tags.ObjectDefinition)
	}
	if tags.CustomFieldType == nil {
		t.Fatalf("expected example.Fields['Tags'] to have a CustomFieldType but it was nil")
	}
	if *tags.CustomFieldType != models.CustomFieldTypeTags {
		t.Fatalf("expected example.Fields['Tags'] to be Tags but got %q", string(*tags.CustomFieldType))
	}
	if tags.JsonName != "tags" {
		t.Fatalf("expected example.Fields['Tags'].JsonName to be 'tags' but got %q", tags.JsonName)
	}
	if !tags.Required {
		t.Fatalf("expected example.Fields['Tags'].Required to be 'true'")
	}
}

func TestParseModelMultipleWithStuttering(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_multiple_with_stuttering.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}
	exampleTag, ok := result.Resources["ExampleTag"]
	if !ok {
		t.Fatalf("expected a resource named `ExampleTag` but didn't get one")
	}
	if len(exampleTag.Operations) != 3 {
		t.Fatalf("expected the resource `ExampleTag` to have 2 operations but got %q", len(exampleTag.Operations))
	}
	if _, ok := exampleTag.Operations["Mars"]; !ok {
		t.Fatalf("expected the resource to have an operation named `Mars` but didn't get one")
	}
	if _, ok := exampleTag.Operations["There"]; !ok {
		t.Fatalf("expected the resource to have an operation named `There` but didn't get one")
	}
	if _, ok := exampleTag.Operations["World"]; !ok {
		t.Fatalf("expected the resource to have an operation named `World` but didn't get one")
	}
}

func TestParseModelBug2675DuplicateModel(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "models_bug_2675_duplicate_model.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}

	example, ok := result.Resources["Example"]
	if !ok {
		t.Fatal("the Resource 'Example' was not found")
	}

	if len(example.Operations) != 3 {
		t.Fatalf("expected the resource `Example` to have 3 operation but got %d", len(example.Operations))
	}

	if len(example.Models) != 7 {
		t.Fatalf("expected the resource `Example` to have 7 models but got %d", len(example.Models))
	}

	if _, ok := example.Models["ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment"]; !ok {
		t.Fatalf("expected the resource `Example` to have a model named `ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment` but didn't get one")
	}
}
