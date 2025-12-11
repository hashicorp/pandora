// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package parser_test

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/testhelpers"
)

func TestParsingOperationsUsingTheSameSwaggerTagInDifferentCasings(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_tag_different_casing.json", nil)
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
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{

					"First": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						// https://github.com/hashicorp/pandora/issues/3807
						URISuffix: pointer.To("/someotheruri"),
					},
					"PutBar": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/bar"),
					},
					"PutFoo": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/foo"),
					},
					"Second": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PATCH",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						// https://github.com/hashicorp/pandora/issues/3807
						URISuffix: pointer.To("/someotheruri"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParsingOperationsOnResources(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_on_resources.json", nil)
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
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"First": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						// https://github.com/hashicorp/pandora/issues/3807
						URISuffix: pointer.To("/someotheruri"),
					},
					"PutBar": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/bar"),
					},
					"Second": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PATCH",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						// https://github.com/hashicorp/pandora/issues/3807
						URISuffix: pointer.To("/someotheruri"),
					},
				},
			},
			"HelloOperations": {
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
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"HelloRestart": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "POST",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/foo"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}
