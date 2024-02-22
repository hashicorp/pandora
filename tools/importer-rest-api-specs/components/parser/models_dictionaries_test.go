// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseModelWithADictionaryOfIntegers(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_integers.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]importerModels.ModelDetails{
					"Example": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionDictionary,
									NestedItem: &importerModels.ObjectDefinition{
										Type: importerModels.ObjectDefinitionInteger,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]importerModels.ModelDetails{
					"Example": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionDictionary,
									NestedItem: &importerModels.ObjectDefinition{
										Type: importerModels.ObjectDefinitionInteger,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]importerModels.ModelDetails{
					"Example": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("MapFieldProperties"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
					"MapFieldProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"Line1": {
								JsonName: "line1",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"Line2": {
								JsonName: "line2",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"City": {
								JsonName: "city",
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
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]importerModels.ModelDetails{
					"Example": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: &importerModels.ObjectDefinition{
									NestedItem: &importerModels.ObjectDefinition{
										ReferenceName: pointer.To("MapFieldProperties"),
										Type:          importerModels.ObjectDefinitionReference,
									},
									Type: importerModels.ObjectDefinitionDictionary,
								},
								Required: false,
							},
						},
					},
					"MapFieldProperties": {
						Fields: map[string]importerModels.FieldDetails{
							"Line1": {
								JsonName: "line1",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"Line2": {
								JsonName: "line2",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"City": {
								JsonName: "city",
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
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]importerModels.ModelDetails{
					"Example": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionDictionary,
									NestedItem: &importerModels.ObjectDefinition{
										Type: importerModels.ObjectDefinitionString,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          importerModels.ObjectDefinitionReference,
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

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]importerModels.ModelDetails{
					"Example": {
						Fields: map[string]importerModels.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionDictionary,
									NestedItem: &importerModels.ObjectDefinition{
										Type: importerModels.ObjectDefinitionString,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
