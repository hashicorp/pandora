// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// TODO: Edge Zones
// TODO: SystemData
// TODO: Tags
// TODO: Zone
// TODO: Zones

func TestParseModel_CommonSchema_IdentityLegacySystemAndUserAssignedList(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitylegacysystemanduserassignedlist.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityList),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentityLegacySystemAndUserAssignedMap(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitylegacysystemanduserassignedmap.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentityLegacySystemAndUserAssignedMap_ExtraFields(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having extra fields
	// in the user assigned identity block (#1066) - for example an extra `appId`
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitylegacysystemanduserassignedmap_extrafields.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentityLegacySystemAndUserAssignedMap_GenericDictionary(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitylegacysystemanduserassignedmap_genericdictionary.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentitySystemAssigned(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemassigned.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeSystemAssignedIdentity),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentitySystemAndUserAssignedList(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemanduserassignedlist.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeSystemAndUserAssignedIdentityList),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentitySystemAndUserAssignedMap(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemanduserassignedmap.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeSystemAndUserAssignedIdentityMap),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentitySystemAndUserAssignedMap_ExtraFields(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having extra fields
	// in the user assigned identity block (#1066) - for example an extra `appId`
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemanduserassignedmap.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeSystemAndUserAssignedIdentityMap),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentitySystemOrUserAssignedList(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemoruserassignedlist.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeSystemOrUserAssignedIdentityList),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentitySystemOrUserAssignedMap(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemoruserassignedmap.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeSystemOrUserAssignedIdentityMap),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentitySystemOrUserAssignedMap_DelegatedResources(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having a DelegatedResources block
	// this block isn't intended to be used by users of the API (and is for internal ARM usage only)
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemoruserassignedmap_delegatedresources.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeSystemOrUserAssignedIdentityMap),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentitySystemOrUserAssignedMap_ExtraFields(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having extra fields
	// in the user assigned identity block (#1066) - for example an extra `appId`
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemoruserassignedmap_extrafields.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeSystemOrUserAssignedIdentityMap),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentityUserAssignedList(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identityuserassignedlist.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeUserAssignedIdentityList),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentityUserAssignedMap(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identityuserassignedmap.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeUserAssignedIdentityMap),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentityUserAssignedMap_PrincipalID(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identityuserassignedmap_principalid.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeUserAssignedIdentityMap),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentityUserAssignedMap_TenantID(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identityuserassignedmap_tenantid.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeUserAssignedIdentityMap),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_Location(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_location.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Resource": {
				Models: map[string]importerModels.ModelDetails{
					"Model": {
						Fields: map[string]importerModels.FieldDetails{
							"Location": {
								JsonName:        "location",
								CustomFieldType: pointer.To(importerModels.CustomFieldTypeLocation),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &importerModels.ObjectDefinition{
									Type: importerModels.ObjectDefinitionString,
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
						OperationId:         "Resource_Test",
						ResponseObject: &importerModels.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          importerModels.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
