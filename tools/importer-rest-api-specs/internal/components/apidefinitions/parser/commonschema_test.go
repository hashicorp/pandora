// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser_test

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/testhelpers"
)

// TODO: Edge Zones
// TODO: SystemData
// TODO: Tags
// TODO: Zone
// TODO: Zones

func TestParseModel_CommonSchema_IdentityLegacySystemAndUserAssignedList(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identitylegacysystemanduserassignedlist.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentityLegacySystemAndUserAssignedMap(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identitylegacysystemanduserassignedmap.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentityLegacySystemAndUserAssignedMap_ExtraFields(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having extra fields
	// in the user assigned identity block (#1066) - for example an extra `appId`
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identitylegacysystemanduserassignedmap_extrafields.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentityLegacySystemAndUserAssignedMap_GenericDictionary(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identitylegacysystemanduserassignedmap_genericdictionary.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentitySystemAssigned(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemassigned.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.SystemAssignedIdentitySDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentitySystemAndUserAssignedList(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemanduserassignedlist.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.SystemAndUserAssignedIdentityListSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentitySystemAndUserAssignedMap(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemanduserassignedmap.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentitySystemAndUserAssignedMap_ExtraFields(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having extra fields
	// in the user assigned identity block (#1066) - for example an extra `appId`
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemanduserassignedmap.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentitySystemOrUserAssignedList(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemoruserassignedlist.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.SystemOrUserAssignedIdentityListSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentitySystemOrUserAssignedMap(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemoruserassignedmap.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentitySystemOrUserAssignedMap_DelegatedResources(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having a DelegatedResources block
	// this block isn't intended to be used by users of the API (and is for internal ARM usage only)
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemoruserassignedmap_delegatedresources.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentitySystemOrUserAssignedMap_ExtraFields(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having extra fields
	// in the user assigned identity block (#1066) - for example an extra `appId`
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemoruserassignedmap_extrafields.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentityUserAssignedList(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identityuserassignedlist.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.UserAssignedIdentityListSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentityUserAssignedMap(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identityuserassignedmap.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.UserAssignedIdentityMapSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentityUserAssignedMap_PrincipalID(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identityuserassignedmap_principalid.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.UserAssignedIdentityMapSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_IdentityUserAssignedMap_TenantID(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_identityuserassignedmap_tenantid.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.UserAssignedIdentityMapSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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

func TestParseModel_CommonSchema_Location(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_commonschema_location.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Resource": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Location": {
								JsonName: "location",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.LocationSDKObjectDefinitionType,
								},
								Required: false,
							},
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
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
