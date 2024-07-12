// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// TODO: tests for the different types of Object Definition

func TestParseModelTopLevel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_top_level.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Age": {
								JsonName: "age",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Height": {
								JsonName: "height",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.FloatSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Tags": {
								JsonName: "tags",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.TagsSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Value": {
								JsonName: "value",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.RawObjectSDKObjectDefinitionType,
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelTopLevelWithRawFile(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_top_level_with_rawfile.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Operations: map[string]sdkModels.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.RawFileSDKObjectDefinitionType,
						},
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.RawFileSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelTopLevelWithInlinedModel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_top_level_with_inlined_model.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("ModelProperties"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ModelProperties": {
						Fields: map[string]sdkModels.SDKField{
							"Age": {
								JsonName: "age",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Height": {
								JsonName: "height",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.FloatSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Nickname": {
								JsonName: "nickname",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Tags": {
								JsonName: "tags",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.TagsSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Value": {
								JsonName: "value",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.RawObjectSDKObjectDefinitionType,
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithDateTimeNoType(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_datetime_no_type.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"SomeDateValue": {
								JsonName: "someDateValue",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.DateTimeSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
				},
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithInlinedObject(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_inlined_object.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]sdkModels.SDKField{
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"UserAssignedIdentities": {
								JsonName: "userAssignedIdentities",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("UserAssignedIdentitiesProperties"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"UserAssignedIdentitiesProperties": {
						Fields: map[string]sdkModels.SDKField{
							"ClientId": {
								JsonName: "clientId",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								ReadOnly: true,
								Required: false,
							},
							"PrincipalId": {
								JsonName: "principalId",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								ReadOnly: true,
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithNumberPrefixedField(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_number_prefixed_field.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Five0PercentDone": {
								JsonName: "50PercentDone",
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithReference(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_reference.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]sdkModels.SDKField{
							"KeyName": {
								JsonName: "keyName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Identity": {
								JsonName: "identity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("UserAssignedIdentityProperties"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"UserAssignedIdentityProperties": {
						Fields: map[string]sdkModels.SDKField{
							"UserAssignedIdentity": {
								JsonName: "userAssignedIdentity",
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithReferenceToArray(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_reference_array.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Pets": {
								JsonName: "pets",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("Pet"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,

										// TODO: re-enable min/max/unique
										// Minimum:     pointer.To(1),
										// Maximum:     pointer.To(2),
										// UniqueItems: pointer.To(true),
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"Pet": {
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithReferenceToConstant(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_reference_constant.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Constants: map[string]sdkModels.SDKConstant{
					"AnimalType": {
						Type: sdkModels.StringSDKConstantType,
						Values: map[string]string{
							"Cat": "Cat",
							"Dog": "Dog",
						},
					},
				},
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]sdkModels.SDKField{
							"Animal": {
								JsonName: "animal",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("AnimalType"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"KeyName": {
								JsonName: "keyName",
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithReferenceToString(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_reference_string.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"ThingProps": {
								JsonName: "thingProps",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("ThingProperties"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ThingProperties": {
						Fields: map[string]sdkModels.SDKField{
							"FullyQualifiedDomainName": {
								JsonName: "fullyQualifiedDomainName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"KeyName": {
								JsonName: "keyName",
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelWithCircularReferences(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_with_circular_reference.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Animal": {
						Fields: map[string]sdkModels.SDKField{
							"FavouriteHouse": {
								JsonName: "favouriteHouse",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("House"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"FavouriteHuman": {
								JsonName: "favouriteHuman",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("Human"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
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
					"House": {
						Fields: map[string]sdkModels.SDKField{
							"Address": {
								JsonName: "address",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Residents": {
								JsonName: "residents",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("Human"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"Human": {
						Fields: map[string]sdkModels.SDKField{
							"Pets": {
								JsonName: "pets",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("Animal"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
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
							ReferenceName: pointer.To("House"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelInheritingFromObjectWithNoExtraFields(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_inheriting_from_other_model_no_new_fields.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"FirstObject": {
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							// whilst the response model references SecondObject, it's only inheriting from FirstObject
							// and doesn't contain any new fields, so it should be switched out
							ReferenceName: pointer.To("FirstObject"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelInheritingFromObjectWithNoExtraFieldsInlined(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_inheriting_from_other_model_no_new_fields_inlined.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"FirstObject": {
						Fields: map[string]sdkModels.SDKField{
							"Endpoints": {
								JsonName: "endpoints",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("SecondObject"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
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
					"SecondObject": {
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("FirstObject"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelInheritingFromObjectWithOnlyDescription(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_inheriting_from_other_model_with_only_description.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"FirstObject": {
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							// whilst the response model references SecondObject, it's only inheriting from FirstObject
							// and doesn't contain any new fields, so it should be switched out
							ReferenceName: pointer.To("FirstObject"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelInheritingFromObjectWithPropertiesWithinAllOf(t *testing.T) {
	// This test ensures that when a Model inherits from a Model and defines properties within
	// the `AllOf` field, that the Model isn't flattened into the Parent Model.
	// This covers a regression from https://github.com/hashicorp/pandora/pull/3720
	// which surfaced in https://github.com/hashicorp/pandora/pull/3726 for the model `AgentPool`
	// within `ContainerService@2019-08-01/AgentPools` which was renamed `SubResource`.
	actual, err := ParseSwaggerFileForTesting(t, "model_inheriting_from_other_model_with_properties_within_allof.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"SecondObject": {
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
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							// SecondObject is referenced as the Response Object, but because it inherits from one Model
							// (FirstObject) and uses another (ThirdObject) it shouldn't be flattened into the parent type(s)
							// and should instead remain `SecondObject`.
							ReferenceName: pointer.To("SecondObject"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelContainingAllOfToTypeObject(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_containing_allof_object_type.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Country": {
								JsonName: "country",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
				},
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelContainingAllOfToTypeObjectWithProperties(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_containing_allof_object_type_with_properties.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Name": {
								JsonName: "name",
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
								Required: true,
							},
						},
					},
				},
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelContainingAllOfWithinProperties(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_containing_allof_within_properties.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Country": {
								JsonName: "country",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("ModelProperties"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ModelProperties": {
						Fields: map[string]sdkModels.SDKField{
							"MoreNested": {
								JsonName: "moreNested",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Nested": {
								JsonName: "nested",
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelContainingMultipleAllOfWithinProperties(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_containing_allof_within_properties_multiple.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Options": {
								JsonName: "options",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("ResourceWithLocation"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Resource": {
								JsonName: "resource",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("ModelResource"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ModelResource": {
						Fields: map[string]sdkModels.SDKField{
							"Country": {
								JsonName: "country",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"MoreNested": {
								JsonName: "moreNested",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ResourceWithLocation": {
						Fields: map[string]sdkModels.SDKField{
							"Country": {
								JsonName: "country",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
				},
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelContainingLists(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_containing_lists.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Animals": {
								JsonName: "animals",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("Animal"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Plants": {
								JsonName: "plants",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										Type: sdkModels.StringSDKObjectDefinitionType,

										// TODO: re-enable min/max/unique
										// Maximum:     pointer.To(10),
										// Minimum:     pointer.To(1),
										// UniqueItems: pointer.To(true),
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"Animal": {
						Fields: map[string]sdkModels.SDKField{
							"Age": {
								JsonName: "age",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelInlinedWithNoName(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_inlined_with_no_name.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Container": {
						Fields: map[string]sdkModels.SDKField{
							"Planets": {
								JsonName: "planets",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("ContainerPlanetsInlined"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ContainerPlanetsInlined": {
						Fields: map[string]sdkModels.SDKField{
							"ExampleField": {
								JsonName: "exampleField",
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
							ReferenceName: pointer.To("Container"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelInheritingFromParent(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_inheriting_from_parent.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"Model": {
						Fields: map[string]sdkModels.SDKField{
							"Age": {
								JsonName: "age",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Height": {
								JsonName: "height",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.FloatSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Tags": {
								JsonName: "tags",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.TagsSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
				},
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
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelMultipleTopLevelModelsAndOperations(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_multiple_top_level_models_and_operations.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"GetExample": {
						Fields: map[string]sdkModels.SDKField{
							"Age": {
								JsonName: "age",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Tags": {
								JsonName: "tags",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.TagsSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"PutExample": {
						Fields: map[string]sdkModels.SDKField{
							"Age": {
								JsonName: "age",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Enabled": {
								JsonName: "enabled",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Tags": {
								JsonName: "tags",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.TagsSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"Get": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("GetExample"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/example"),
					},
					"Put": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("PutExample"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("PutExample"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModelBug2675DuplicateModel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "models_bug_2675_duplicate_model.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Models: map[string]sdkModels.SDKModel{
					"EnvironmentRole": {
						Fields: map[string]sdkModels.SDKField{
							"Description": {
								JsonName: "description",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								ReadOnly: true,
								Required: false,
							},
							"RoleName": {
								JsonName: "roleName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								ReadOnly: true,
								Required: false,
							},
						},
					},
					"ExampleEnvironment": {
						Fields: map[string]sdkModels.SDKField{
							"Location": {
								JsonName: "location",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.LocationSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentProperties"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentProperties": {
						Fields: map[string]sdkModels.SDKField{
							"CreatorRoleAssignment": {
								JsonName: "creatorRoleAssignment",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"DeploymentTargetId": {
								JsonName: "deploymentTargetId",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"ProvisioningState": {
								JsonName: "provisioningState",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								ReadOnly: true,
								Required: false,
							},
							"UserRoleAssignments": {
								JsonName: "userRoleAssignments",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("UserRoleAssignment"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentUpdate": {
						Fields: map[string]sdkModels.SDKField{
							"Example": {
								JsonName: "example",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Properties": {
								JsonName: "properties",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentUpdateProperties"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentUpdateProperties": {
						Fields: map[string]sdkModels.SDKField{
							"CreatorRoleAssignment": {
								JsonName: "creatorRoleAssignment",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"DeploymentTargetId": {
								JsonName: "deploymentTargetId",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"UserRoleAssignments": {
								JsonName: "userRoleAssignments",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("UserRoleAssignment"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"ExampleEnvironmentUpdatePropertiesCreatorRoleAssignment": {
						Fields: map[string]sdkModels.SDKField{
							"Roles": {
								JsonName: "roles",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("EnvironmentRole"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"UserRoleAssignment": {
						Fields: map[string]sdkModels.SDKField{
							"Roles": {
								JsonName: "roles",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("EnvironmentRole"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.DictionarySDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"CreateOrUpdate": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						ResourceIDName: pointer.To("EnvironmentId"),
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
					},
					"Get": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResourceIDName:      pointer.To("EnvironmentId"),
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
					},
					"Update": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PATCH",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironmentUpdate"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						ResourceIDName: pointer.To("EnvironmentId"),
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleEnvironment"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
					},
				},
				ResourceIDs: map[string]sdkModels.ResourceID{
					"EnvironmentId": {
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("staticEnvironments", "environments"),
							sdkModels.NewUserSpecifiedResourceIDSegment("environmentName", "environmentName"),
						},
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
