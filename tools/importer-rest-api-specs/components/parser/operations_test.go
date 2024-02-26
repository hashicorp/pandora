// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"net/http"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// TODO: tests for the different types of Operation Object Definition - including CSV's inner object

func TestParseOperationsEmpty(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_empty.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources:   map[string]importerModels.AzureApiResource{},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithTag(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_tag.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{http.StatusOK},
						LongRunning:         false,
						Method:              http.MethodHead,
						URISuffix:           pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithTagAndResourceId(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_tag_resource_id.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ThingId"),
					},
				},
				ResourceIds: map[string]models.ResourceID{
					"ThingId": {
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							models.NewResourceProviderResourceIDSegment("staticMicrosoftFooBar", "Microsoft.FooBar"),
							models.NewStaticValueResourceIDSegment("staticThings", "things"),
							models.NewUserSpecifiedResourceIDSegment("thing", "thing"),
						},
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithTagAndResourceIdSuffix(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_tag_resource_id_suffix.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ThingId"),
						URISuffix:           pointer.To("/restart"),
					},
				},
				ResourceIds: map[string]models.ResourceID{
					"ThingId": {
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							models.NewResourceProviderResourceIDSegment("staticMicrosoftFooBar", "Microsoft.FooBar"),
							models.NewStaticValueResourceIDSegment("staticThings", "things"),
							models.NewUserSpecifiedResourceIDSegment("thing", "thing"),
						},
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithRequestObject(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_request_object.json")
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
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Example"),
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithRequestObjectInlined(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_request_object_inlined.json")
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
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Example"),
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithResponseObject(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_response_object.json")
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
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Example"),
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithResponseObjectInlined(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_response_object_inlined.json")
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
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Example"),
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithResponseObjectInlinedList(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_response_object_inlined_list.json")
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
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("Example"),
							},
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleRequestingWithABool(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_bool.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							Type: models.BooleanSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleRequestingWithAInteger(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_int.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							Type: models.IntegerSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleRequestingWithADictionaryOfStrings(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_dictionary_of_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							Type: models.DictionarySDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type: models.StringSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleRequestingWithAListOfStrings(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_list_of_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type: models.StringSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

// Models are already tested above

func TestParseOperationSingleRequestingWithAString(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_string.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningABool(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_bool.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"GimmeABoolean": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.BooleanSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAFloat(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_float.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"GimmeAFloat": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.FloatSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAFile(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_file.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"GimmeAFile": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.RawFileSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAnInteger(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_an_integer.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"GimmeAnInteger": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.IntegerSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAString(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_string.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"GimmeAString": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAnErrorStatusCode(t *testing.T) {
	// In this instance the error status code should be ignored we're only concerned with 2XX status codes
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_an_error_status_code.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"GimmeAString": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningATopLevelRawObject(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_top_level_raw_object.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"RawObjectToMeToYou": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						RequestObject: &models.SDKObjectDefinition{
							Type: models.RawObjectSDKObjectDefinitionType,
						},
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.RawObjectSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/chuckle"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningADictionaryOfAModel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_dictionary_of_model.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"Person": {
						Fields: map[string]models.SDKField{
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
					"GimmeADictionaryOfAModel": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.DictionarySDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								ReferenceName: pointer.To("Person"),
								Type:          models.ReferenceSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningADictionaryOfStrings(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_dictionary_of_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"GimmeADictionaryOfStrings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.DictionarySDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type: models.StringSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAListOfIntegers(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_ints.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"GimmeAListOfIntegers": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type: models.IntegerSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAListOfAModel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_model.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"Person": {
						Fields: map[string]models.SDKField{
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
					"GimmeAListOfModels": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								ReferenceName: pointer.To("Person"),
								Type:          models.ReferenceSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAListOfStrings(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"GimmeAListOfStrings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type: models.StringSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAListOfListOfAModel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_list_of_model.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"Person": {
						Fields: map[string]models.SDKField{
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
					"GimmeAListOfListOfModels": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type: models.ListSDKObjectDefinitionType,
								NestedItem: &models.SDKObjectDefinition{
									ReferenceName: pointer.To("Person"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAListOfListOfStrings(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_list_of_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"GimmeAListOfListOfStrings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type: models.ListSDKObjectDefinitionType,
								NestedItem: &models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithList(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_list.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"World": {
						Fields: map[string]models.SDKField{
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
					"ListWorlds": {
						ContentType:                      "application/json",
						ExpectedStatusCodes:              []int{200},
						FieldContainingPaginationDetails: pointer.To("nextLink"),
						Method:                           "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("World"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithListWhichIsNotAList(t *testing.T) {
	// all List operations should have an `x-ms-pageable` attribute, but some don't due to bad data
	// as such this checks we can duck-type it out
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_list_which_is_not_a_list.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"World": {
						Fields: map[string]models.SDKField{
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
					"ListWorlds": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						// This signifies there's a list of items without a means of paging over it.
						// This is _likely_ a badly documented API Definition, but it's hard to say for sure.
						// Since there isn't a pagination field present in the response, we have to assume this isn't
						// a list operation, even if there's a `skipToken` present.
						FieldContainingPaginationDetails: nil,
						Method:                           "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("World"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithListReturningAListOfStrings(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_list_of_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"ListWorlds": {
						ContentType:                      "application/json",
						ExpectedStatusCodes:              []int{200},
						FieldContainingPaginationDetails: pointer.To("nextLink"),
						Method:                           "GET",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithListWithoutPageable(t *testing.T) {
	// all List operations should have an `x-ms-pageable` attribute, but some don't due to bad data
	// as such this checks we can duck-type it out
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_list_without_pageable.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"World": {
						Fields: map[string]models.SDKField{
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
					"ListWorlds": {
						ContentType:                      "application/json",
						ExpectedStatusCodes:              []int{200},
						FieldContainingPaginationDetails: pointer.To("nextLink"),
						Method:                           "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("World"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithLongRunningOperation(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_long_running.json")
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
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						LongRunning:         true,
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
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

func TestParseOperationSingleWithRequestAndResponseObject(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_request_and_response_object.json")
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
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
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

func TestParseOperationSingleWithMultipleTags(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_multiple_tags.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"HeadThings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						URISuffix:           pointer.To("/things"),
					},
				},
			},
			"Other": {
				Operations: map[string]models.SDKOperation{
					// Whilst the operation name should be `HeadThings`, since this is another Tag
					// it's intentionally prefixed for when things cross boundaries (to avoid conflicts)
					"HelloHeadThings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						URISuffix:           pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithInferredTag(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_no_tag.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			// since there's no tags, the file name is used to infer the tag (in this case, 'OperationsSingleWithNoTags')
			"OperationsSingleWithNoTags": {
				Operations: map[string]models.SDKOperation{
					// since the prefix doesn't match the Tag (since no tag) this gets a combined name
					"HelloHeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						URISuffix:           pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithHeaderOptions(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_header_options.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						Options: map[string]models.SDKOperationOption{
							"BoolValue": {
								HeaderName: pointer.To("boolValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.BooleanSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"CsvOfDoubleValue": {
								HeaderName: pointer.To("csvOfDoubleValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.CSVSDKOperationOptionObjectDefinitionType,
									NestedItem: &models.SDKOperationOptionObjectDefinition{
										Type: models.FloatSDKOperationOptionObjectDefinitionType,
									},
								},
								Required: true,
							},
							"CsvOfStringValue": {
								HeaderName: pointer.To("csvOfStringValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.CSVSDKOperationOptionObjectDefinitionType,
									NestedItem: &models.SDKOperationOptionObjectDefinition{
										Type: models.StringSDKOperationOptionObjectDefinitionType,
									},
								},
								Required: true,
							},
							"DecimalValue": {
								HeaderName: pointer.To("decimalValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.FloatSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"DoubleValue": {
								HeaderName: pointer.To("doubleValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.FloatSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"IntValue": {
								HeaderName: pointer.To("intValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.IntegerSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"StringValue": {
								HeaderName: pointer.To("stringValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.StringSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithQueryStringOptions(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_querystring_options.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						Options: map[string]models.SDKOperationOption{
							"BoolValue": {
								QueryStringName: pointer.To("boolValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.BooleanSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"CsvOfDoubleValue": {
								QueryStringName: pointer.To("csvOfDoubleValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.CSVSDKOperationOptionObjectDefinitionType,
									NestedItem: &models.SDKOperationOptionObjectDefinition{
										Type: models.FloatSDKOperationOptionObjectDefinitionType,
									},
								},
								Required: true,
							},
							"CsvOfStringValue": {
								QueryStringName: pointer.To("csvOfStringValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.CSVSDKOperationOptionObjectDefinitionType,
									NestedItem: &models.SDKOperationOptionObjectDefinition{
										Type: models.StringSDKOperationOptionObjectDefinitionType,
									},
								},
								Required: true,
							},
							"DecimalValue": {
								QueryStringName: pointer.To("decimalValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.FloatSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"DoubleValue": {
								QueryStringName: pointer.To("doubleValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.FloatSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"IntValue": {
								QueryStringName: pointer.To("intValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.IntegerSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"StringValue": {
								QueryStringName: pointer.To("stringValue"),
								ObjectDefinition: models.SDKOperationOptionObjectDefinition{
									Type: models.StringSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationMultipleBasedOnTheSameResourceId(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_multiple_same_resource_id.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ThingId"),
					},
					"RestartWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ThingId"),
						URISuffix:           pointer.To("/restart"),
					},
				},
				ResourceIds: map[string]models.ResourceID{
					"ThingId": {
						Segments: []models.ResourceIDSegment{
							models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							models.NewResourceProviderResourceIDSegment("staticMicrosoftFooBar", "Microsoft.FooBar"),
							models.NewStaticValueResourceIDSegment("staticThings", "things"),
							models.NewUserSpecifiedResourceIDSegment("thing", "thing"),
						},
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationsContainingContentTypes(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operation_content_types.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Operations: map[string]models.SDKOperation{
					"Default": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						URISuffix:           pointer.To("/default"),
					},
					"JsonRequest": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						RequestObject: &models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						// this can become `/json-request` when https://github.com/hashicorp/pandora/issues/3807 is fixed
						URISuffix: pointer.To("/jsonRequest"),
					},
					"JsonResponse": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/jsonResponse"),
					},
					"XmlRequest": {
						ContentType:         "application/xml",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						RequestObject: &models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/xmlRequest"),
					},
					"XmlResponse": {
						ContentType:         "application/xml",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						ResponseObject: &models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/xmlResponse"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationContainingMultipleReturnObjects(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_multiple_return_objects.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Hello": {
				Models: map[string]models.SDKModel{
					"FirstModel": {
						Fields: map[string]models.SDKField{
							"Hello": {
								JsonName: "hello",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200, 202},
						Method:              "PUT",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("FirstModel"),
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

func TestParseOperationsWithStutteringNames(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_with_stuttering_names.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"ExampleTag": {
				Operations: map[string]models.SDKOperation{
					"Mars": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						URISuffix:           pointer.To("/mars"),
					},
					"There": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						URISuffix:           pointer.To("/there"),
					},
					"World": {
						// TODO: change the Swagger Tag to be `ExampleTag` for this operation
						// There's a bug where multiple operations using the same (normalized) Swagger Tag aren't being
						// flattened correctly.
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						URISuffix:           pointer.To("/world"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
