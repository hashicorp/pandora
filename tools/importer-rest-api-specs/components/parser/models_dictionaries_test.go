// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseModelWithADictionaryOfIntegers(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_integers.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"Example": {
						Fields: map[string]models.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.DictionarySDKObjectDefinitionType,
									NestedItem: &models.SDKObjectDefinition{
										Type: models.IntegerSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfIntegersInlined(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_integers_inlined.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"Example": {
						Fields: map[string]models.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.DictionarySDKObjectDefinitionType,
									NestedItem: &models.SDKObjectDefinition{
										Type: models.IntegerSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfAnObject(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_object.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"Example": {
						Fields: map[string]models.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("MapFieldProperties"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"MapFieldProperties": {
						Fields: map[string]models.SDKField{
							"Line1": {
								JsonName: "line1",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Line2": {
								JsonName: "line2",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"City": {
								JsonName: "city",
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
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfAnObjectInlined(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_object_inlined.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"Example": {
						Fields: map[string]models.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("MapFieldProperties"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"MapFieldProperties": {
						Fields: map[string]models.SDKField{
							"Line1": {
								JsonName: "line1",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Line2": {
								JsonName: "line2",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"City": {
								JsonName: "city",
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
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfString(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_string.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"Example": {
						Fields: map[string]models.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.DictionarySDKObjectDefinitionType,
									NestedItem: &models.SDKObjectDefinition{
										Type: models.StringSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfStringInlined(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_string_inlined.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"Example": {
						Fields: map[string]models.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.DictionarySDKObjectDefinitionType,
									NestedItem: &models.SDKObjectDefinition{
										Type: models.StringSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
