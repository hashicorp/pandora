// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser_test

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/testhelpers"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/featureflags"
)

func TestParseModelWithDataFactoryCustomTypes(t *testing.T) {
	// This test ensures that we parse the Data Factory Custom Types out to regular Object Definitions.
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_using_datafactory_custom_types.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expectedModels := map[string]sdkModels.SDKModel{
		"Model": {
			Fields: map[string]sdkModels.SDKField{
				// Simple Types
				"BooleanField": {
					JsonName: "booleanField",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.BooleanSDKObjectDefinitionType,
					},
					Required: false,
				},
				"DoubleField": {
					JsonName: "doubleField",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.FloatSDKObjectDefinitionType,
					},
					Required: false,
				},
				"KeyValuePairField": {
					JsonName: "keyValuePairField",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.DictionarySDKObjectDefinitionType,
						NestedItem: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
					},
					Required: false,
				},
				"IntegerField": {
					JsonName: "integerField",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.IntegerSDKObjectDefinitionType,
					},
					Required: false,
				},
				"StringField": {
					JsonName: "stringField",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
					Required: false,
				},
				"UnknownField": {
					// In this case, the `dfe-*` value is unknown, so we should return an object
					// this is the default behaviour, mostly for sanity-checking
					JsonName: "unknownField",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.RawObjectSDKObjectDefinitionType,
					},
					Required: false,
				},

				// Dictionaries of a Simple Type (using the regular Swagger/OpenAPI syntax)
				"DictionaryOfBooleanField": {
					JsonName: "dictionaryOfBooleanField",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.DictionarySDKObjectDefinitionType,
						NestedItem: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.BooleanSDKObjectDefinitionType,
						},
					},
					Required: false,
				},
				"DictionaryOfDoubleField": {
					JsonName: "dictionaryOfDoubleField",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.DictionarySDKObjectDefinitionType,
						NestedItem: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.FloatSDKObjectDefinitionType,
						},
					},
					Required: false,
				},
				"DictionaryOfIntegerField": {
					JsonName: "dictionaryOfIntegerField",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.DictionarySDKObjectDefinitionType,
						NestedItem: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.IntegerSDKObjectDefinitionType,
						},
					},
					Required: false,
				},
				"DictionaryOfStringField": {
					JsonName: "dictionaryOfStringField",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.DictionarySDKObjectDefinitionType,
						NestedItem: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
					},
					Required: false,
				},
				"DictionaryOfUnknownField": {
					// In this case, the `dfe-*` value is unknown, so we should return an object
					// this is the default behaviour, mostly for sanity-checking
					JsonName: "dictionaryOfUnknownField",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.DictionarySDKObjectDefinitionType,
						NestedItem: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.RawObjectSDKObjectDefinitionType,
						},
					},
					Required: false,
				},

				// DFE specific List implementations
				"DfeCustomListOfString": {
					JsonName: "dfeCustomListOfString",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.ListSDKObjectDefinitionType,
						NestedItem: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
					},
					Required: false,
				},
				"DfeCustomListOfAnotherObject": {
					JsonName: "dfeCustomListOfAnotherObject",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.ListSDKObjectDefinitionType,
						NestedItem: &sdkModels.SDKObjectDefinition{
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("SecondModel"),
						},
					},
					Required: false,
				},
			},
		},
		"SecondModel": {
			Fields: map[string]sdkModels.SDKField{
				"Example": {
					JsonName: "example",
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
				},
			},
		},
	}

	if !featureflags.ParseDataFactoryListsOfReferencesAsRegularObjectDefinitionTypes {
		delete(expectedModels, "SecondModel")
		expectedModels["Model"].Fields["DfeCustomListOfAnotherObject"] = sdkModels.SDKField{
			JsonName: "dfeCustomListOfAnotherObject",
			ObjectDefinition: sdkModels.SDKObjectDefinition{
				Type: sdkModels.RawObjectSDKObjectDefinitionType,
			},
			Required: false,
		}
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: expectedModels,
				Operations: map[string]sdkModels.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/example"),
					},
				},
			},
		},
	}

	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}
