// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParsingOperationsUsingTheSameSwaggerTagInDifferentCasings(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_tag_different_casing.json")
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{

					"First": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						// https://github.com/hashicorp/pandora/issues/3807
						URISuffix: pointer.To("/someotheruri"),
					},
					"PutBar": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/bar"),
					},
					"PutFoo": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/foo"),
					},
					"Second": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PATCH",
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						// https://github.com/hashicorp/pandora/issues/3807
						URISuffix: pointer.To("/someotheruri"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParsingOperationsOnResources(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_on_resources.json")
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
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"First": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						// https://github.com/hashicorp/pandora/issues/3807
						URISuffix: pointer.To("/someotheruri"),
					},
					"PutBar": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/bar"),
					},
					"Second": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PATCH",
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						// https://github.com/hashicorp/pandora/issues/3807
						URISuffix: pointer.To("/someotheruri"),
					},
				},
			},
			"HelloOperations": {
				Models: map[string]importerModels.ModelDetails{
					"Example": {
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
				Operations: map[string]models.SDKOperation{
					"HelloRestart": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "POST",
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/foo"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
