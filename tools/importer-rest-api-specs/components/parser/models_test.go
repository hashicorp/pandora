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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Height": {
								JsonName: "height",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.FloatSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Tags": {
								JsonName: "tags",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.TagsSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Value": {
								JsonName: "value",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.RawObjectSDKObjectDefinitionType,
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
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
						RequestObject: &models.SDKObjectDefinition{
							Type: models.RawFileSDKObjectDefinitionType,
						},
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.RawFileSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("ModelProperties"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ModelProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Height": {
								JsonName: "height",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.FloatSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Nickname": {
								JsonName: "nickname",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Tags": {
								JsonName: "tags",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.TagsSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Value": {
								JsonName: "value",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.RawObjectSDKObjectDefinitionType,
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
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.DateTimeSDKObjectDefinitionType,
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
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"UserAssignedIdentities": {
								JsonName: "userAssignedIdentities",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("UserAssignedIdentitiesProperties"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"UserAssignedIdentitiesProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"ClientId": {
								JsonName: "clientId",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								ReadOnly: true,
								Required: false,
							},
							"PrincipalId": {
								JsonName: "principalId",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Five0PercentDone": {
								JsonName: "50PercentDone",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("UserAssignedIdentityProperties"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"UserAssignedIdentityProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"UserAssignedIdentity": {
								JsonName: "userAssignedIdentity",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Pets": {
								JsonName: "pets",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("Pet"),
										Type:          models.ReferenceSDKObjectDefinitionType,

										// TODO: re-enable min/max/unique
										// Minimum:     pointer.To(1),
										// Maximum:     pointer.To(2),
										// UniqueItems: pointer.To(true),
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"Pet": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"Animal": {
								JsonName: "animal",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("AnimalType"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"FullyQualifiedDomainName": {
								JsonName: "fullyQualifiedDomainName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("House"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"FavouriteHuman": {
								JsonName: "favouriteHuman",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("Human"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"House": {
						Fields: map[string]importerModels.FieldDetails{
							"Address": {
								JsonName: "address",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Residents": {
								JsonName: "residents",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("Human"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"Human": {
						Fields: map[string]importerModels.FieldDetails{
							"Pets": {
								JsonName: "pets",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("Animal"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("House"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							// whilst the response model references SecondObject, it's only inheriting from FirstObject
							// and doesn't contain any new fields, so it should be switched out
							ReferenceName: pointer.To("FirstObject"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("SecondObject"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"SecondObject": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("FirstObject"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							// whilst the response model references SecondObject, it's only inheriting from FirstObject
							// and doesn't contain any new fields, so it should be switched out
							ReferenceName: pointer.To("FirstObject"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							// SecondObject is referenced as the Response Object, but because it inherits from one Model
							// (FirstObject) and uses another (ThirdObject) it shouldn't be flattened into the parent type(s)
							// and should instead remain `SecondObject`.
							ReferenceName: pointer.To("SecondObject"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Country": {
								JsonName: "country",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Country": {
								JsonName: "country",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("ModelProperties"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ModelProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"MoreNested": {
								JsonName: "moreNested",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("ResourceWithLocation"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Resource": {
								JsonName: "resource",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("ModelResource"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ModelResource": {
						Fields: map[string]importerModels.FieldDetails{
							"Country": {
								JsonName: "country",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MoreNested": {
								JsonName: "moreNested",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ResourceWithLocation": {
						Fields: map[string]importerModels.FieldDetails{
							"Country": {
								JsonName: "country",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("Animal"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Plants": {
								JsonName: "plants",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										Type: models.StringSDKObjectDefinitionType,

										// TODO: re-enable min/max/unique
										// Maximum:     pointer.To(10),
										// Minimum:     pointer.To(1),
										// UniqueItems: pointer.To(true),
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"Animal": {
						Fields: map[string]importerModels.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("ContainerPlanetsInlined"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ContainerPlanetsInlined": {
						Fields: map[string]importerModels.FieldDetails{
							"ExampleField": {
								JsonName: "exampleField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Container"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Height": {
								JsonName: "height",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.FloatSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Tags": {
								JsonName: "tags",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.TagsSDKObjectDefinitionType,
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
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Tags": {
								JsonName: "tags",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.TagsSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"PutExample": {
						Fields: map[string]importerModels.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Tags": {
								JsonName: "tags",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.TagsSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Get": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("GetExample"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						UriSuffix: pointer.To("/example"),
					},
					"Put": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("PutExample"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("PutExample"),
							Type:          models.ReferenceSDKObjectDefinitionType,
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								ReadOnly: true,
								Required: false,
							},
							"RoleName": {
								JsonName: "roleName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								ReadOnly: true,
								Required: false,
							},
						},
					},
					"ExampleEnvironment": {
						Fields: map[string]importerModels.FieldDetails{
							"Location": {
								JsonName: "location",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.LocationSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentProperties"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"CreatorRoleAssignment": {
								JsonName: "creatorRoleAssignment",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"DeploymentTargetId": {
								JsonName: "deploymentTargetId",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"ProvisioningState": {
								JsonName: "provisioningState",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								ReadOnly: true,
								Required: false,
							},
							"UserRoleAssignments": {
								JsonName: "userRoleAssignments",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("UserRoleAssignment"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentUpdate": {
						Fields: map[string]importerModels.FieldDetails{
							"Example": {
								JsonName: "example",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentUpdateProperties"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentUpdateProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"CreatorRoleAssignment": {
								JsonName: "creatorRoleAssignment",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"DeploymentTargetId": {
								JsonName: "deploymentTargetId",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"UserRoleAssignments": {
								JsonName: "userRoleAssignments",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("UserRoleAssignment"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment": {
						Fields: map[string]importerModels.FieldDetails{
							"Roles": {
								JsonName: "roles",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("EnvironmentRole"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"UserRoleAssignment": {
						Fields: map[string]importerModels.FieldDetails{
							"Roles": {
								JsonName: "roles",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("EnvironmentRole"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.DictionarySDKObjectDefinitionType,
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
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						ResourceIdName: pointer.To("EnvironmentId"),
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
					},
					"Get": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResourceIdName:      pointer.To("EnvironmentId"),
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
					},
					"Update": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PATCH",
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironmentUpdate"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						ResourceIdName: pointer.To("EnvironmentId"),
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
					},
				},
				ResourceIds: map[string]models.ResourceID{
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
