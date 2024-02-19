// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseModelWithADictionaryOfIntegers(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_integers.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionDictionary,
									NestedItem: &models.ObjectDefinition{
										Type: models.ObjectDefinitionInteger,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfIntegersInlined(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_integers_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionDictionary,
									NestedItem: &models.ObjectDefinition{
										Type: models.ObjectDefinitionInteger,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfAnObject(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_object.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("MapFieldProperties"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
					"MapFieldProperties": {
						Fields: map[string]models.FieldDetails{
							"Line1": {
								JsonName: "line1",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"Line2": {
								JsonName: "line2",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"City": {
								JsonName: "city",
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
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfAnObjectInlined(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_object_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: &models.ObjectDefinition{
									NestedItem: &models.ObjectDefinition{
										ReferenceName: pointer.To("MapFieldProperties"),
										Type:          models.ObjectDefinitionReference,
									},
									Type: models.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
					"MapFieldProperties": {
						Fields: map[string]models.FieldDetails{
							"Line1": {
								JsonName: "line1",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"Line2": {
								JsonName: "line2",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"City": {
								JsonName: "city",
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
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfString(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_string.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionDictionary,
									NestedItem: &models.ObjectDefinition{
										Type: models.ObjectDefinitionString,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfStringInlined(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_string_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionDictionary,
									NestedItem: &models.ObjectDefinition{
										Type: models.ObjectDefinitionString,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
