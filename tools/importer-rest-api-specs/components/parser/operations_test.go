// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"net/http"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestParseOperationsEmpty(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_empty.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources:   map[string]models.AzureApiResource{},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseOperationSingleWithTag(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "operations_single_with_tag.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{http.StatusOK},
						LongRunning:         false,
						Method:              http.MethodHead,
						OperationId:         "Hello_HeadWorld",
						UriSuffix:           pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						OperationId:         "Hello_HeadWorld",
						ResourceIdName:      pointer.To("ThingId"),
					},
				},
				ResourceIds: map[string]models.ParsedResourceId{
					"ThingId": {
						Segments: []resourcemanager.ResourceIdSegment{
							NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							NewSubscriptionIDResourceIDSegment("subscriptionId"),
							NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							NewStaticValueResourceIDSegment("staticProviders", "providers"),
							NewResourceProviderResourceIDSegment("staticMicrosoftFooBar", "Microsoft.FooBar"),
							NewStaticValueResourceIDSegment("staticThings", "things"),
							NewUserSpecifiedResourceIDSegment("thing", "thing"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						OperationId:         "Hello_HeadWorld",
						ResourceIdName:      pointer.To("ThingId"),
						UriSuffix:           pointer.To("/restart"),
					},
				},
				ResourceIds: map[string]models.ParsedResourceId{
					"ThingId": {
						Segments: []resourcemanager.ResourceIdSegment{
							NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							NewSubscriptionIDResourceIDSegment("subscriptionId"),
							NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							NewStaticValueResourceIDSegment("staticProviders", "providers"),
							NewResourceProviderResourceIDSegment("staticMicrosoftFooBar", "Microsoft.FooBar"),
							NewStaticValueResourceIDSegment("staticThings", "things"),
							NewUserSpecifiedResourceIDSegment("thing", "thing"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Hello_PutWorld",
						RequestObject: &models.ObjectDefinition{
							Type:          models.ObjectDefinitionReference,
							ReferenceName: pointer.To("Example"),
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Hello_PutWorld",
						RequestObject: &models.ObjectDefinition{
							Type:          models.ObjectDefinitionReference,
							ReferenceName: pointer.To("Example"),
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &models.ObjectDefinition{
							Type:          models.ObjectDefinitionReference,
							ReferenceName: pointer.To("Example"),
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &models.ObjectDefinition{
							Type:          models.ObjectDefinitionReference,
							ReferenceName: pointer.To("Example"),
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"GetWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GetWorld",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionList,
							NestedItem: &models.ObjectDefinition{
								Type:          models.ObjectDefinitionReference,
								ReferenceName: pointer.To("Example"),
							},
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Hello_PutWorld",
						RequestObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionBoolean,
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Hello_PutWorld",
						RequestObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionInteger,
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Hello_PutWorld",
						RequestObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionDictionary,
							NestedItem: &models.ObjectDefinition{
								Type: models.ObjectDefinitionString,
							},
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Hello_PutWorld",
						RequestObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionList,
							NestedItem: &models.ObjectDefinition{
								Type: models.ObjectDefinitionString,
							},
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Hello_PutWorld",
						RequestObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionString,
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"GimmeABoolean": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeABoolean",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionBoolean,
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"GimmeAFloat": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeAFloat",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionFloat,
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"GimmeAFile": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeAFile",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionRawFile,
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"GimmeAnInteger": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeAnInteger",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionInteger,
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"GimmeAString": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeAString",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionString,
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"GimmeAString": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeAString",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionString,
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"RawObjectToMeToYou": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_RawObjectToMeToYou",
						RequestObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionRawObject,
						},
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionRawObject,
						},
						UriSuffix: pointer.To("/chuckle"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Person": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"GimmeADictionaryOfAModel": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeADictionaryOfAModel",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionDictionary,
							NestedItem: &models.ObjectDefinition{
								ReferenceName: pointer.To("Person"),
								Type:          models.ObjectDefinitionReference,
							},
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"GimmeADictionaryOfStrings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeADictionaryOfStrings",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionDictionary,
							NestedItem: &models.ObjectDefinition{
								Type: models.ObjectDefinitionString,
							},
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"GimmeAListOfIntegers": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeAListOfIntegers",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionList,
							NestedItem: &models.ObjectDefinition{
								Type: models.ObjectDefinitionInteger,
							},
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Person": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"GimmeAListOfModels": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeAListOfModels",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionList,
							NestedItem: &models.ObjectDefinition{
								ReferenceName: pointer.To("Person"),
								Type:          models.ObjectDefinitionReference,
							},
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"GimmeAListOfStrings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeAListOfStrings",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionList,
							NestedItem: &models.ObjectDefinition{
								Type: models.ObjectDefinitionString,
							},
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Person": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"GimmeAListOfListOfModels": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeAListOfListOfModels",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionList,
							NestedItem: &models.ObjectDefinition{
								Type: models.ObjectDefinitionList,
								NestedItem: &models.ObjectDefinition{
									ReferenceName: pointer.To("Person"),
									Type:          models.ObjectDefinitionReference,
								},
							},
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"GimmeAListOfListOfStrings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_GimmeAListOfListOfStrings",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionList,
							NestedItem: &models.ObjectDefinition{
								Type: models.ObjectDefinitionList,
								NestedItem: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
							},
						},
						UriSuffix: pointer.To("/worlds/favourite"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"World": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"ListWorlds": {
						ContentType:                      "application/json",
						ExpectedStatusCodes:              []int{200},
						FieldContainingPaginationDetails: pointer.To("nextLink"),
						IsListOperation:                  true,
						Method:                           "GET",
						OperationId:                      "Hello_ListWorlds",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("World"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/worlds"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"World": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"ListWorlds": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						// This signifies there's a list of items without a means of paging over it.
						// This is _likely_ a badly documented API Definition, but it's hard to say for sure.
						FieldContainingPaginationDetails: nil,
						IsListOperation:                  true,
						Method:                           "GET",
						OperationId:                      "Hello_ListWorlds",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("World"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/worlds"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"ListWorlds": {
						ContentType:                      "application/json",
						ExpectedStatusCodes:              []int{200},
						FieldContainingPaginationDetails: pointer.To("nextLink"),
						IsListOperation:                  true,
						Method:                           "GET",
						OperationId:                      "Hello_ListWorlds",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionString,
						},
						UriSuffix: pointer.To("/worlds"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"World": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"ListWorlds": {
						ContentType:                      "application/json",
						ExpectedStatusCodes:              []int{200},
						FieldContainingPaginationDetails: pointer.To("nextLink"),
						IsListOperation:                  true,
						Method:                           "GET",
						OperationId:                      "Hello_ListWorlds",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("World"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/worlds"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						LongRunning:         true,
						Method:              "PUT",
						OperationId:         "Hello_PutWorld",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"Example": {
						Fields: map[string]models.FieldDetails{
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"PutWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Hello_PutWorld",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ObjectDefinitionReference,
						},
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Example"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"HeadThings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						OperationId:         "Hello_HeadThings",
						UriSuffix:           pointer.To("/things"),
					},
				},
			},
			"Other": {
				Operations: map[string]models.OperationDetails{
					// Whilst the operation name should be `HeadThings`, since this is another Tag
					// it's intentionally prefixed for when things cross boundaries (to avoid conflicts)
					"HelloHeadThings": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						OperationId:         "Hello_HeadThings",
						UriSuffix:           pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			// since there's no tags, the file name is used to infer the tag (in this case, 'OperationsSingleWithNoTags')
			"OperationsSingleWithNoTags": {
				Operations: map[string]models.OperationDetails{
					// since the prefix doesn't match the Tag (since no tag) this gets a combined name
					"HelloHeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						OperationId:         "Hello_HeadWorld",
						UriSuffix:           pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						OperationId:         "Hello_HeadWorld",
						Options: map[string]models.OperationOption{
							"BoolValue": {
								HeaderName: pointer.To("boolValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionBoolean,
								},
								Required: true,
							},
							"CsvOfDoubleValue": {
								HeaderName: pointer.To("csvOfDoubleValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionCsv,
									NestedItem: &models.ObjectDefinition{
										Type: models.ObjectDefinitionFloat,
									},
								},
								Required: true,
							},
							"CsvOfStringValue": {
								HeaderName: pointer.To("csvOfStringValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionCsv,
									NestedItem: &models.ObjectDefinition{
										Type: models.ObjectDefinitionString,
									},
								},
								Required: true,
							},
							"DecimalValue": {
								HeaderName: pointer.To("decimalValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionFloat,
								},
								Required: true,
							},
							"DoubleValue": {
								HeaderName: pointer.To("doubleValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionFloat,
								},
								Required: true,
							},
							"IntValue": {
								HeaderName: pointer.To("intValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionInteger,
								},
								Required: true,
							},
							"StringValue": {
								HeaderName: pointer.To("stringValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						OperationId:         "Hello_HeadWorld",
						Options: map[string]models.OperationOption{
							"BoolValue": {
								QueryStringName: pointer.To("boolValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionBoolean,
								},
								Required: true,
							},
							"CsvOfDoubleValue": {
								QueryStringName: pointer.To("csvOfDoubleValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionCsv,
									NestedItem: &models.ObjectDefinition{
										Type: models.ObjectDefinitionFloat,
									},
								},
								Required: true,
							},
							"CsvOfStringValue": {
								QueryStringName: pointer.To("csvOfStringValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionCsv,
									NestedItem: &models.ObjectDefinition{
										Type: models.ObjectDefinitionString,
									},
								},
								Required: true,
							},
							"DecimalValue": {
								QueryStringName: pointer.To("decimalValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionFloat,
								},
								Required: true,
							},
							"DoubleValue": {
								QueryStringName: pointer.To("doubleValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionFloat,
								},
								Required: true,
							},
							"IntValue": {
								QueryStringName: pointer.To("intValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionInteger,
								},
								Required: true,
							},
							"StringValue": {
								QueryStringName: pointer.To("stringValue"),
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: true,
							},
						},
						UriSuffix: pointer.To("/things"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						OperationId:         "Hello_HeadWorld",
						ResourceIdName:      pointer.To("ThingId"),
					},
					"RestartWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						OperationId:         "Hello_RestartWorld",
						ResourceIdName:      pointer.To("ThingId"),
						UriSuffix:           pointer.To("/restart"),
					},
				},
				ResourceIds: map[string]models.ParsedResourceId{
					"ThingId": {
						Segments: []resourcemanager.ResourceIdSegment{
							NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
							NewSubscriptionIDResourceIDSegment("subscriptionId"),
							NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
							NewResourceGroupNameResourceIDSegment("resourceGroupName"),
							NewStaticValueResourceIDSegment("staticProviders", "providers"),
							NewResourceProviderResourceIDSegment("staticMicrosoftFooBar", "Microsoft.FooBar"),
							NewStaticValueResourceIDSegment("staticThings", "things"),
							NewUserSpecifiedResourceIDSegment("thing", "thing"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Operations: map[string]models.OperationDetails{
					"Default": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "HEAD",
						OperationId:         "Hello_Default",
						UriSuffix:           pointer.To("/default"),
					},
					"JsonRequest": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_JsonRequest",
						RequestObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionString,
						},
						// this can become `/json-request` when https://github.com/hashicorp/pandora/issues/3807 is fixed
						UriSuffix: pointer.To("/jsonRequest"),
					},
					"JsonResponse": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Hello_JsonResponse",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionString,
						},
						UriSuffix: pointer.To("/jsonResponse"),
					},
					"XmlRequest": {
						ContentType:         "application/xml",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Hello_XmlRequest",
						RequestObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionString,
						},
						UriSuffix: pointer.To("/xmlRequest"),
					},
					"XmlResponse": {
						ContentType:         "application/xml",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Hello_XmlResponse",
						ResponseObject: &models.ObjectDefinition{
							Type: models.ObjectDefinitionString,
						},
						UriSuffix: pointer.To("/xmlResponse"),
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

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Hello": {
				Models: map[string]models.ModelDetails{
					"FirstModel": {
						Fields: map[string]models.FieldDetails{
							"Hello": {
								JsonName: "hello",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"HeadWorld": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200, 202},
						Method:              "PUT",
						OperationId:         "Hello_HeadWorld",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("FirstModel"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/things"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
