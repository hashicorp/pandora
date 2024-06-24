// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/featureflags"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseModelWithDataFactoryCustomTypes(t *testing.T) {
	// This test ensures that we parse the Data Factory Custom Types out to regular Object Definitions.
	if !featureflags.ParseDataFactoryCustomTypesAsRegularObjectDefinitionTypes {
		t.Fatalf("Skipping since `ParseDataFactoryCustomTypesAsRegularObjectDefinitionTypes` is disabled")
	}

	actual, err := ParseSwaggerFileForTesting(t, "model_using_datafactory_custom_types.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Models: map[string]models.SDKModel{
					"Model": {
						Fields: map[string]models.SDKField{
							// Simple Types
							"BooleanField": {
								JsonName: "booleanField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"DoubleField": {
								JsonName: "doubleField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.FloatSDKObjectDefinitionType,
								},
								Required: false,
							},
							"KeyValuePairField": {
								JsonName: "keyValuePairField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.DictionarySDKObjectDefinitionType,
									NestedItem: &models.SDKObjectDefinition{
										Type: models.StringSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
							"IntegerField": {
								JsonName: "integerField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"StringField": {
								JsonName: "stringField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"UnknownField": {
								// In this case, the `dfe-*` value is unknown, so we should return an object
								// this is the default behaviour, mostly for sanity-checking
								JsonName: "unknownField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.RawObjectSDKObjectDefinitionType,
								},
								Required: false,
							},

							// Dictionaries of a Simple Type (using the regular Swagger/OpenAPI syntax)
							"DictionaryOfBooleanField": {
								JsonName: "dictionaryOfBooleanField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.DictionarySDKObjectDefinitionType,
									NestedItem: &models.SDKObjectDefinition{
										Type: models.BooleanSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
							"DictionaryOfDoubleField": {
								JsonName: "dictionaryOfDoubleField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.DictionarySDKObjectDefinitionType,
									NestedItem: &models.SDKObjectDefinition{
										Type: models.FloatSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
							"DictionaryOfIntegerField": {
								JsonName: "dictionaryOfIntegerField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.DictionarySDKObjectDefinitionType,
									NestedItem: &models.SDKObjectDefinition{
										Type: models.IntegerSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
							"DictionaryOfStringField": {
								JsonName: "dictionaryOfStringField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.DictionarySDKObjectDefinitionType,
									NestedItem: &models.SDKObjectDefinition{
										Type: models.StringSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
							"DictionaryOfUnknownField": {
								// In this case, the `dfe-*` value is unknown, so we should return an object
								// this is the default behaviour, mostly for sanity-checking
								JsonName: "dictionaryOfUnknownField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.DictionarySDKObjectDefinitionType,
									NestedItem: &models.SDKObjectDefinition{
										Type: models.RawObjectSDKObjectDefinitionType,
									},
								},
								Required: false,
							},

							// DFE specific List implementations
							"DfeCustomListOfString": {
								JsonName: "dfeCustomListOfString",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.ListSDKObjectDefinitionType,
									NestedItem: &models.SDKObjectDefinition{
										Type: models.StringSDKObjectDefinitionType,
									},
								},
								Required: false,
							},
							"DfeCustomListOfAnotherObject": {
								JsonName: "dfeCustomListOfAnotherObject",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.ListSDKObjectDefinitionType,
									NestedItem: &models.SDKObjectDefinition{
										Type:          models.ReferenceSDKObjectDefinitionType,
										ReferenceName: pointer.To("SecondModel"),
									},
								},
								Required: false,
							},
						},
					},
					"SecondModel": {
						Fields: map[string]models.SDKField{
							"Example": {
								JsonName: "example",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
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
						URISuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
