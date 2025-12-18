// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package parser_test

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/testhelpers"
)

func TestParseModelWithADictionaryOfIntegers(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_dictionary_of_integers.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"Example": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.DictionarySDKObjectDefinitionType,
									NestedItem: &sdkModels.SDKObjectDefinition{
										Type: sdkModels.IntegerSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfIntegersInlined(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_dictionary_of_integers_inlined.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"Example": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.DictionarySDKObjectDefinitionType,
									NestedItem: &sdkModels.SDKObjectDefinition{
										Type: sdkModels.IntegerSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfAnObject(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_dictionary_of_object.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"Example": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("MapFieldProperties"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"MapFieldProperties": {
						Fields: map[string]sdkModels.SDKField{
							"Line1": {
								JsonName: "line1",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Line2": {
								JsonName: "line2",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"City": {
								JsonName: "city",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Country": {
								JsonName: "country",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfAnObjectInlined(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_dictionary_of_object_inlined.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"Example": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("MapFieldProperties"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"MapFieldProperties": {
						Fields: map[string]sdkModels.SDKField{
							"Line1": {
								JsonName: "line1",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Line2": {
								JsonName: "line2",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"City": {
								JsonName: "city",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Country": {
								JsonName: "country",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfString(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_dictionary_of_string.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"Example": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.DictionarySDKObjectDefinitionType,
									NestedItem: &sdkModels.SDKObjectDefinition{
										Type: sdkModels.StringSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithADictionaryOfStringInlined(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_dictionary_of_string_inlined.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"Example": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MapField": {
								JsonName: "mapField",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.DictionarySDKObjectDefinitionType,
									NestedItem: &sdkModels.SDKObjectDefinition{
										Type: sdkModels.StringSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}
