// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// TODO: tests for the different types of Object Definition

func TestParseModelTopLevel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_top_level.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionInteger,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionBoolean,
								},
								Required: false,
							},
							"Height": {
								JsonName: "height",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionFloat,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
							"Tags": {
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeTags),
								JsonName:        "tags",
								Required:        false,
							},
							"Value": {
								JsonName: "value",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionRawObject,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &importerModels.ObjectDefinition{
							Type: importerModels.ObjectDefinitionRawFile,
						},
						ResponseObject: &importerModels.ObjectDefinition{
							Type: importerModels.ObjectDefinitionRawFile,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("ModelProperties"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
						},
					},
					"ModelProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionInteger,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionBoolean,
								},
								Required: false,
							},
							"Height": {
								JsonName: "height",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionFloat,
								},
								Required: false,
							},
							"Nickname": {
								JsonName: "nickname",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"Tags": {
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeTags),
								JsonName:        "tags",
								Required:        false,
							},
							"Value": {
								JsonName: "value",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionRawObject,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"SomeDateValue": {
								JsonName: "someDateValue",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionDateTime,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"UserAssignedIdentities": {
								JsonName: "userAssignedIdentities",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("UserAssignedIdentitiesProperties"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
					"UserAssignedIdentitiesProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"ClientId": {
								JsonName: "clientId",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								ReadOnly: true,
								Required: false,
							},
							"PrincipalId": {
								JsonName: "principalId",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								ReadOnly: true,
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"Five0PercentDone": {
								JsonName: "50PercentDone",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("UserAssignedIdentityProperties"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
						},
					},
					"UserAssignedIdentityProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"UserAssignedIdentity": {
								JsonName: "userAssignedIdentity",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"Pets": {
								JsonName: "pets",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("Pet"),
										Type:          importerModels.ObjectDefinitionReference,

										// note: these change substantially in the sdk swap
										Minimum:     pointer.To(1),
										Maximum:     pointer.To(2),
										UniqueItems: pointer.To(true),
									},
									Type: importerModels.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"Pet": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"AnimalType": {
						Type: models.StringSDKConstantType,
						Values: map[string]string{
							"Cat": "Cat",
							"Dog": "Dog",
						},
					},
				},
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"Animal": {
								JsonName: "animal",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("AnimalType"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"FullyQualifiedDomainName": {
								JsonName: "fullyQualifiedDomainName",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Animal": {
						Fields: map[string]importerModels.FieldDetails{
							"FavouriteHouse": {
								JsonName: "favouriteHouse",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("House"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
							"FavouriteHuman": {
								JsonName: "favouriteHuman",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("Human"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
					"House": {
						Fields: map[string]importerModels.FieldDetails{
							"Address": {
								JsonName: "address",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"Residents": {
								JsonName: "residents",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("Human"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"Human": {
						Fields: map[string]importerModels.FieldDetails{
							"Pets": {
								JsonName: "pets",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("Animal"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionList,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("House"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"FirstObject": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							// whilst the response model references SecondObject, it's only inheriting from FirstObject
							// and doesn't contain any new fields, so it should be switched out
							ReferenceName: pointer.To("FirstObject"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"FirstObject": {
						Fields: map[string]importerModels.FieldDetails{
							"Endpoints": {
								JsonName: "endpoints",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("SecondObject"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
					"SecondObject": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("FirstObject"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"FirstObject": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							// whilst the response model references SecondObject, it's only inheriting from FirstObject
							// and doesn't contain any new fields, so it should be switched out
							ReferenceName: pointer.To("FirstObject"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"SecondObject": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							// SecondObject is referenced as the Response Object, but because it inherits from one Model
							// (FirstObject) and uses another (ThirdObject) it shouldn't be flattened into the parent type(s)
							// and should instead remain `SecondObject`.
							ReferenceName: pointer.To("SecondObject"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
							"Country": {
								JsonName: "country",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"Country": {
								JsonName: "country",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Country": {
								JsonName: "country",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("ModelProperties"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
						},
					},
					"ModelProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"MoreNested": {
								JsonName: "moreNested",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Options": {
								JsonName: "options",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("ResourceWithLocation"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
							"Resource": {
								JsonName: "resource",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("ModelResource"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
						},
					},
					"ModelResource": {
						Fields: map[string]importerModels.FieldDetails{
							"Country": {
								JsonName: "country",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"MoreNested": {
								JsonName: "moreNested",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
					"ResourceWithLocation": {
						Fields: map[string]importerModels.FieldDetails{
							"Country": {
								JsonName: "country",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Animals": {
								JsonName: "animals",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("Animal"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionList,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
							"Plants": {
								JsonName: "plants",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										Type: importerModels.ObjectDefinitionString,

										// NOTE: these change substantially in the new SDK
										Maximum:     pointer.To(10),
										Minimum:     pointer.To(1),
										UniqueItems: pointer.To(true),
									},
									Type: importerModels.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"Animal": {
						Fields: map[string]importerModels.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionInteger,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Container": {
						Fields: map[string]importerModels.FieldDetails{
							"Planets": {
								JsonName: "planets",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("ContainerPlanetsInlined"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionList,
								},
								Required: false,
							},
						},
					},
					"ContainerPlanetsInlined": {
						Fields: map[string]importerModels.FieldDetails{
							"ExampleField": {
								JsonName: "exampleField",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Container"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionInteger,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionBoolean,
								},
								Required: true,
							},
							"Height": {
								JsonName: "height",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionFloat,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
							"Tags": {
								JsonName:        "tags",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeTags),
								Required:        true,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Test",
						RequestObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"GetExample": {
						Fields: map[string]importerModels.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionInteger,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionBoolean,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
							"Tags": {
								JsonName:        "tags",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeTags),
								Required:        false,
							},
						},
					},
					"PutExample": {
						Fields: map[string]importerModels.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionInteger,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionBoolean,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: true,
							},
							"Tags": {
								JsonName:        "tags",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeTags),
								Required:        false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Get": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Get",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("GetExample"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
					"Put": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_Put",
						RequestObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("PutExample"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("PutExample"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]importerModels.ModelDetails{
					"EnvironmentRole": {
						Fields: map[string]importerModels.FieldDetails{
							"Description": {
								JsonName: "description",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								ReadOnly: true,
								Required: false,
							},
							"RoleName": {
								JsonName: "roleName",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								ReadOnly: true,
								Required: false,
							},
						},
					},
					"ExampleEnvironment": {
						Fields: map[string]importerModels.FieldDetails{
							"Location": {
								JsonName:        "location",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeLocation),
								Required:        false,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentProperties"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"CreatorRoleAssignment": {
								JsonName: "creatorRoleAssignment",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
							"DeploymentTargetId": {
								JsonName: "deploymentTargetId",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"ProvisioningState": {
								JsonName: "provisioningState",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								ReadOnly: true,
								Required: false,
							},
							"UserRoleAssignments": {
								JsonName: "userRoleAssignments",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("UserRoleAssignment"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentUpdate": {
						Fields: map[string]importerModels.FieldDetails{
							"Example": {
								JsonName: "example",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentUpdateProperties"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentUpdateProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"CreatorRoleAssignment": {
								JsonName: "creatorRoleAssignment",
								ObjectDefinition: &importerModels.ObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment"),
									Type:          importerModels.ObjectDefinitionReference,
								},
								Required: false,
							},
							"DeploymentTargetId": {
								JsonName: "deploymentTargetId",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"UserRoleAssignments": {
								JsonName: "userRoleAssignments",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("UserRoleAssignment"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment": {
						Fields: map[string]importerModels.FieldDetails{
							"Roles": {
								JsonName: "roles",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("EnvironmentRole"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
					"UserRoleAssignment": {
						Fields: map[string]importerModels.FieldDetails{
							"Roles": {
								JsonName: "roles",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("EnvironmentRole"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"CreateOrUpdate": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Example_CreateOrUpdate",
						RequestObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						ResourceIdName: pointer.To("EnvironmentId"),
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          importerModels.ObjectDefinitionReference,
						},
					},
					"Get": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Example_Get",
						ResourceIdName:      pointer.To("EnvironmentId"),
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          importerModels.ObjectDefinitionReference,
						},
					},
					"Update": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PATCH",
						OperationId:         "Example_Update",
						RequestObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironmentUpdate"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						ResourceIdName: pointer.To("EnvironmentId"),
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          importerModels.ObjectDefinitionReference,
						},
					},
				},
				ResourceIds: map[string]importerModels.ParsedResourceId{
					"EnvironmentId": {
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("staticEnvironments", "environments"),
							models.NewUserSpecifiedResourceIDSegment("environmentName", "environmentName"),
						},
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
