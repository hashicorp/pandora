// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package parser_test

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/testhelpers"
	"net/http"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// TODO: tests for the different types of Operation Object Definition - including CSV's inner object

func TestParseOperationsEmpty(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_empty.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources:  map[string]sdkModels.APIResource{},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithTag(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_with_tag.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
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
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithTagAndResourceId(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_with_tag_resource_id.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ThingId"),
					},
				},
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ThingId": {
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftFooBar", "Microsoft.FooBar"),
							sdkModels.NewStaticValueResourceIDSegment("staticThings", "things"),
							sdkModels.NewUserSpecifiedResourceIDSegment("thingName", "thing"),
						},
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithTagAndResourceIdSuffix(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_with_tag_resource_id_suffix.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						ResourceIDName:      pointer.To("ThingId"),
						URISuffix:           pointer.To("/restart"),
					},
				},
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ThingId": {
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftFooBar", "Microsoft.FooBar"),
							sdkModels.NewStaticValueResourceIDSegment("staticThings", "things"),
							sdkModels.NewUserSpecifiedResourceIDSegment("thingName", "thing"),
						},
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithRequestObject(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_with_request_object.json", nil)
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
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Example"),
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithRequestObjectInlined(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_with_request_object_inlined.json", nil)
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
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Example"),
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithResponseObject(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_with_response_object.json", nil)
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
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Example"),
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithResponseObjectInlined(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_with_response_object_inlined.json", nil)
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
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Example"),
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithResponseObjectInlinedList(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_with_response_object_inlined_list.json", nil)
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
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.ListSDKObjectDefinitionType,
							NestedItem: &sdkModels.SDKObjectDefinition{
								Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("Example"),
							},
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleRequestingWithABool(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_bool.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.BooleanSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleRequestingWithAInteger(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_int.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.IntegerSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleRequestingWithADictionaryOfStrings(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_dictionary_of_strings.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.DictionarySDKObjectDefinitionType,
							NestedItem: &sdkModels.SDKObjectDefinition{
								Type: sdkModels.StringSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleRequestingWithAListOfStrings(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_list_of_strings.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.ListSDKObjectDefinitionType,
							NestedItem: &sdkModels.SDKObjectDefinition{
								Type: sdkModels.StringSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

// Models are already tested above

func TestParseOperationSingleRequestingWithAString(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_string.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningABool(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_a_bool.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"GimmeABoolean": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.BooleanSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAFloat(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_a_float.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"GimmeAFloat": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.FloatSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAFile(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_a_file.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"GimmeAFile": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.RawFileSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAnInteger(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_an_integer.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"GimmeAnInteger": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.IntegerSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAString(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_a_string.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"GimmeAString": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAnErrorStatusCode(t *testing.T) {
	t.Parallel(
	// In this instance the error status code should be ignored we're only concerned with 2XX status codes
	)

	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_an_error_status_code.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"GimmeAString": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningATopLevelRawObject(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_a_top_level_raw_object.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"RawObjectToMeToYou": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						RequestObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.RawObjectSDKObjectDefinitionType,
						},
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.RawObjectSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/chuckle"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningADictionaryOfAModel(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_a_dictionary_of_model.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"Person": {
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
					"GimmeADictionaryOfAModel": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.DictionarySDKObjectDefinitionType,
							NestedItem: &sdkModels.SDKObjectDefinition{
								ReferenceName: pointer.To("Person"),
								Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningADictionaryOfStrings(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_a_dictionary_of_strings.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"GimmeADictionaryOfStrings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.DictionarySDKObjectDefinitionType,
							NestedItem: &sdkModels.SDKObjectDefinition{
								Type: sdkModels.StringSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAListOfIntegers(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_ints.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"GimmeAListOfIntegers": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.ListSDKObjectDefinitionType,
							NestedItem: &sdkModels.SDKObjectDefinition{
								Type: sdkModels.IntegerSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAListOfAModel(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_model.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"Person": {
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
					"GimmeAListOfModels": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.ListSDKObjectDefinitionType,
							NestedItem: &sdkModels.SDKObjectDefinition{
								ReferenceName: pointer.To("Person"),
								Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAListOfStrings(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_strings.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"GimmeAListOfStrings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.ListSDKObjectDefinitionType,
							NestedItem: &sdkModels.SDKObjectDefinition{
								Type: sdkModels.StringSDKObjectDefinitionType,
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAListOfListOfAModel(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_list_of_model.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"Person": {
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
					"GimmeAListOfListOfModels": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.ListSDKObjectDefinitionType,
							NestedItem: &sdkModels.SDKObjectDefinition{
								Type: sdkModels.ListSDKObjectDefinitionType,
								NestedItem: &sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("Person"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleReturningAListOfListOfStrings(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_list_of_strings.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"GimmeAListOfListOfStrings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.ListSDKObjectDefinitionType,
							NestedItem: &sdkModels.SDKObjectDefinition{
								Type: sdkModels.ListSDKObjectDefinitionType,
								NestedItem: &sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
							},
						},
						URISuffix: pointer.To("/worlds/favourite"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithList(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_list.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"World": {
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
					"ListWorlds": {
						ContentType:                      "application/json",
						ExpectedStatusCodes:              []int{200},
						FieldContainingPaginationDetails: pointer.To("nextLink"),
						Method:                           "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("World"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithListWhichIsNotAList(t *testing.T) {
	t.Parallel(
	// all List operations should have an `x-ms-pageable` attribute, but some don't due to bad data
	// as such this checks we can duck-type it out
	)

	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_list_which_is_not_a_list.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"World": {
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
					"ListWorlds": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						// This signifies there's a list of items without a means of paging over it.
						// This is _likely_ a badly documented API Definition, but it's hard to say for sure.
						// Since there isn't a pagination field present in the response, we have to assume this isn't
						// a list operation, even if there's a `skipToken` present.
						FieldContainingPaginationDetails: nil,
						Method:                           "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("World"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithListReturningAListOfStrings(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_list_of_strings.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"ListWorlds": {
						ContentType:                      "application/json",
						ExpectedStatusCodes:              []int{200},
						FieldContainingPaginationDetails: pointer.To("nextLink"),
						Method:                           "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithListWithoutPageable(t *testing.T) {
	t.Parallel(
	// all List operations should have an `x-ms-pageable` attribute, but some don't due to bad data
	// as such this checks we can duck-type it out
	)

	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_list_without_pageable.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"World": {
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
					"ListWorlds": {
						ContentType:                      "application/json",
						ExpectedStatusCodes:              []int{200},
						FieldContainingPaginationDetails: pointer.To("nextLink"),
						Method:                           "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("World"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/worlds"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithLongRunningOperation(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_long_running.json", nil)
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
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						LongRunning:         true,
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
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

func TestParseOperationSingleWithRequestAndResponseObject(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_with_request_and_response_object.json", nil)
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
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						RequestObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						},
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

func TestParseOperationSingleWithMultipleTags(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_multiple_tags.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"HeadThings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						URISuffix:           pointer.To("/things"),
					},
				},
			},
			"Other": {
				Operations: map[string]sdkModels.SDKOperation{
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
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithInferredTag(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_with_no_tag.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			// since there's no tags, the file name is used to infer the tag (in this case, 'OperationsSingleWithNoTags')
			"OperationsSingleWithNoTags": {
				Operations: map[string]sdkModels.SDKOperation{
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
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithHeaderOptions(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_with_header_options.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						Options: map[string]sdkModels.SDKOperationOption{
							"BoolValue": {
								HeaderName: pointer.To("boolValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.BooleanSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"CsvOfDoubleValue": {
								HeaderName: pointer.To("csvOfDoubleValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.CSVSDKOperationOptionObjectDefinitionType,
									NestedItem: &sdkModels.SDKOperationOptionObjectDefinition{
										Type: sdkModels.FloatSDKOperationOptionObjectDefinitionType,
									},
								},
								Required: true,
							},
							"CsvOfStringValue": {
								HeaderName: pointer.To("csvOfStringValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.CSVSDKOperationOptionObjectDefinitionType,
									NestedItem: &sdkModels.SDKOperationOptionObjectDefinition{
										Type: sdkModels.StringSDKOperationOptionObjectDefinitionType,
									},
								},
								Required: true,
							},
							"DecimalValue": {
								HeaderName: pointer.To("decimalValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.FloatSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"DoubleValue": {
								HeaderName: pointer.To("doubleValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.FloatSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"IntValue": {
								HeaderName: pointer.To("intValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.IntegerSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"StringValue": {
								HeaderName: pointer.To("stringValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.StringSDKOperationOptionObjectDefinitionType,
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
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithQueryStringOptions(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_with_querystring_options.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						Options: map[string]sdkModels.SDKOperationOption{
							"BoolValue": {
								QueryStringName: pointer.To("boolValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.BooleanSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"CsvOfDoubleValue": {
								QueryStringName: pointer.To("csvOfDoubleValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.CSVSDKOperationOptionObjectDefinitionType,
									NestedItem: &sdkModels.SDKOperationOptionObjectDefinition{
										Type: sdkModels.FloatSDKOperationOptionObjectDefinitionType,
									},
								},
								Required: true,
							},
							"CsvOfStringValue": {
								QueryStringName: pointer.To("csvOfStringValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.CSVSDKOperationOptionObjectDefinitionType,
									NestedItem: &sdkModels.SDKOperationOptionObjectDefinition{
										Type: sdkModels.StringSDKOperationOptionObjectDefinitionType,
									},
								},
								Required: true,
							},
							"DecimalValue": {
								QueryStringName: pointer.To("decimalValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.FloatSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"DoubleValue": {
								QueryStringName: pointer.To("doubleValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.FloatSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"IntValue": {
								QueryStringName: pointer.To("intValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.IntegerSDKOperationOptionObjectDefinitionType,
								},
								Required: true,
							},
							"StringValue": {
								QueryStringName: pointer.To("stringValue"),
								ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
									Type: sdkModels.StringSDKOperationOptionObjectDefinitionType,
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
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationMultipleBasedOnTheSameResourceId(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_multiple_same_resource_id.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
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
				ResourceIDs: map[string]sdkModels.ResourceID{
					"ThingId": {
						Segments: []sdkModels.ResourceIDSegment{
							sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
							sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
							sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftFooBar", "Microsoft.FooBar"),
							sdkModels.NewStaticValueResourceIDSegment("staticThings", "things"),
							sdkModels.NewUserSpecifiedResourceIDSegment("thingName", "thing"),
						},
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationsContainingContentTypes(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operation_content_types.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Operations: map[string]sdkModels.SDKOperation{
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
						RequestObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						// this can become `/json-request` when https://github.com/hashicorp/pandora/issues/3807 is fixed
						URISuffix: pointer.To("/jsonRequest"),
					},
					"JsonResponse": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/jsonResponse"),
					},
					"XmlRequest": {
						ContentType:         "application/xml",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						RequestObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/xmlRequest"),
					},
					"XmlResponse": {
						ContentType:         "application/xml",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/xmlResponse"),
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationContainingMultipleReturnObjects(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_single_multiple_return_objects.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Hello": {
				Models: map[string]sdkModels.SDKModel{
					"FirstModel": {
						Fields: map[string]sdkModels.SDKField{
							"Hello": {
								JsonName: "hello",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200, 202},
						Method:              "PUT",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("FirstModel"),
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

func TestParseOperationsWithStutteringNames(t *testing.T) {
	t.Parallel()
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "operations_with_stuttering_names.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"ExampleTag": {
				Operations: map[string]sdkModels.SDKOperation{
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
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}
