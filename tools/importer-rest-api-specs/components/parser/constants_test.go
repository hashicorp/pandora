// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseConstantsIntegersTopLevelAsInts(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is an Int that's output as an Integer.
	actual, err := ParseSwaggerFileForTesting(t, "constants_integers_as_ints.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"TableNumber": {
						Type: models.IntegerSDKConstantType,
						Values: map[string]string{
							"One":              "1",
							"Two":              "2",
							"Three":            "3",
							"FourFiveSixSeven": "4567",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"FavouriteTable": {
								JsonName: "favouriteTable",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("TableNumber"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsIntegersTopLevelAsIntsWithDisplayName(t *testing.T) {
	// This is an Integer Enum where there's a (Display) Name listed for the integer
	// so we should be using `Name (string): Value (integer`)
	actual, err := ParseSwaggerFileForTesting(t, "constants_integers_with_names.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"TableNumber": {
						Type: models.IntegerSDKConstantType,
						Values: map[string]string{
							"First":  "1",
							"Second": "2",
							"Third":  "3",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"FavouriteTable": {
								JsonName: "favouriteTable",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("TableNumber"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsIntegersTopLevelAsStrings(t *testing.T) {
	// Tests an Integer Constant with modelAsString, which is bad data / should be ignored
	actual, err := ParseSwaggerFileForTesting(t, "constants_integers_as_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"TableNumber": {
						Type: models.IntegerSDKConstantType,
						Values: map[string]string{
							"One":   "1",
							"Two":   "2",
							"Three": "3",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"FavouriteTable": {
								JsonName: "favouriteTable",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("TableNumber"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsIntegersInlinedAsInts(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is an Int that's output as an Integer.
	actual, err := ParseSwaggerFileForTesting(t, "constants_integers_as_ints_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"TableNumber": {
						Type: models.IntegerSDKConstantType,
						Values: map[string]string{
							"One":   "1",
							"Two":   "2",
							"Three": "3",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"FavouriteTable": {
								JsonName: "favouriteTable",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("TableNumber"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsIntegersInlinedAsIntsWithDisplayName(t *testing.T) {
	// This is an Integer Enum where there's a (Display) Name listed for the integer
	// so we should be using `Name (string): Value (integer`)
	actual, err := ParseSwaggerFileForTesting(t, "constants_integers_with_names_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"TableNumber": {
						Type: models.IntegerSDKConstantType,
						Values: map[string]string{
							"First":  "1",
							"Second": "2",
							"Third":  "3",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"FavouriteTable": {
								JsonName: "favouriteTable",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("TableNumber"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsMultipleTypeEnums(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "constants_multiple_type_enums.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"AnimalType": {
						Type: models.StringSDKConstantType,
						Values: map[string]string{
							"Cat":   "cat",
							"Dog":   "dog",
							"Panda": "panda",
						},
					},
					"PlanetType": {
						Type: models.StringSDKConstantType,
						Values: map[string]string{
							"Mercury": "mercury",
							"Saturn":  "saturn",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"Animal": {
						Fields: map[string]models.SDKField{
							"Type": {
								JsonName: "type",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("AnimalType"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
					"Planet": {
						Fields: map[string]models.SDKField{
							"Type": {
								JsonName: "type",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("PlanetType"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Animal": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Animal"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/animal"),
					},
					"Planet": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Planet"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						URISuffix: pointer.To("/planet"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseConstantsIntegersInlinedAsStrings(t *testing.T) {
	// Tests an Integer Constant defined Inline with modelAsString, which is bad data / should be ignored
	actual, err := ParseSwaggerFileForTesting(t, "constants_integers_as_strings_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"TableNumber": {
						Type: models.IntegerSDKConstantType,
						Values: map[string]string{
							"One":   "1",
							"Two":   "2",
							"Three": "3",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"FavouriteTable": {
								JsonName: "favouriteTable",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("TableNumber"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsFloatsTopLevelAsFloats(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is an Float that's output as a Float.
	actual, err := ParseSwaggerFileForTesting(t, "constants_floats_as_floats.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"TableNumber": {
						Type: models.FloatSDKConstantType,
						Values: map[string]string{
							"OnePointOne":                     "1.1",
							"TwoPointTwo":                     "2.2",
							"ThreePointThreeZeroZeroZeroFour": "3.30004",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"FavouriteTable": {
								JsonName: "favouriteTable",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("TableNumber"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsFloatsTopLevelAsStrings(t *testing.T) {
	// Tests an Float Constant with modelAsString, which is bad data / should be ignored
	actual, err := ParseSwaggerFileForTesting(t, "constants_floats_as_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"TableNumber": {
						Type: models.FloatSDKConstantType,
						Values: map[string]string{
							"OnePointOne":                     "1.1",
							"TwoPointTwo":                     "2.2",
							"ThreePointThreeZeroZeroZeroFour": "3.30004",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"FavouriteTable": {
								JsonName: "favouriteTable",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("TableNumber"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsFloatsInlinedAsFloats(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is an Float that's output as a Float.
	actual, err := ParseSwaggerFileForTesting(t, "constants_floats_as_floats_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"TableNumber": {
						Type: models.FloatSDKConstantType,
						Values: map[string]string{
							"OnePointOne":                     "1.1",
							"TwoPointTwo":                     "2.2",
							"ThreePointThreeZeroZeroZeroFour": "3.30004",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"FavouriteTable": {
								JsonName: "favouriteTable",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("TableNumber"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsFloatsInlinedAsStrings(t *testing.T) {
	// Tests an Float Constant defined inline with modelAsString, which is bad data / should be ignored
	actual, err := ParseSwaggerFileForTesting(t, "constants_floats_as_strings_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"TableNumber": {
						Type: models.FloatSDKConstantType,
						Values: map[string]string{
							"OnePointOne":                     "1.1",
							"TwoPointTwo":                     "2.2",
							"ThreePointThreeZeroZeroZeroFour": "3.30004",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"FavouriteTable": {
								JsonName: "favouriteTable",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("TableNumber"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsStringsTopLevel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "constants_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"AnimalType": {
						Type: models.StringSDKConstantType,
						Values: map[string]string{
							"Cat":   "cat",
							"Dog":   "dog",
							"Panda": "panda",
							"Any":   "*",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"Type": {
								JsonName: "type",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("AnimalType"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsStringsTopLevelAsNonStrings(t *testing.T) {
	// whilst the value is "string", due to (what appears to be) bad data the
	// "modelAsString" property can be set to false - as such we force it to
	// a string either way, since that's what it is
	actual, err := ParseSwaggerFileForTesting(t, "constants_strings_as_non_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"AnimalType": {
						Type: models.StringSDKConstantType,
						Values: map[string]string{
							"Cat":   "cat",
							"Dog":   "dog",
							"Panda": "panda",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"Type": {
								JsonName: "type",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("AnimalType"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsStringsInlined(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "constants_strings_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"AnimalType": {
						Type: models.StringSDKConstantType,
						Values: map[string]string{
							"Cat":   "cat",
							"Dog":   "dog",
							"Panda": "panda",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"Type": {
								JsonName: "type",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("AnimalType"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsStringsInlinedAsNonStrings(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "constants_strings_inlined_as_non_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"AnimalType": {
						Type: models.StringSDKConstantType,
						Values: map[string]string{
							"Cat":   "cat",
							"Dog":   "dog",
							"Panda": "panda",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"Type": {
								JsonName: "type",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("AnimalType"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsStringsTopLevelContainingFloats(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is a Float that's output as a String.
	actual, err := ParseSwaggerFileForTesting(t, "constants_strings_which_are_floats.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"TableNumber": {
						Type: models.StringSDKConstantType,
						Values: map[string]string{
							"OnePointOne":                     "1.1",
							"TwoPointTwo":                     "2.2",
							"ThreePointThreeZeroZeroZeroFour": "3.30004",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"FavouriteTable": {
								JsonName: "favouriteTable",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("TableNumber"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsStringsInlinedContainingFloats(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is a Float that's output as a Float.
	actual, err := ParseSwaggerFileForTesting(t, "constants_floats_as_floats_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Example": {
				Constants: map[string]models.SDKConstant{
					"TableNumber": {
						Type: models.FloatSDKConstantType,
						Values: map[string]string{
							"OnePointOne":                     "1.1",
							"TwoPointTwo":                     "2.2",
							"ThreePointThreeZeroZeroZeroFour": "3.30004",
						},
					},
				},
				Models: map[string]models.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]models.SDKField{
							"FavouriteTable": {
								JsonName: "favouriteTable",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("TableNumber"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseConstantsFromParameters(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "constants_in_operation_parameters.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["ConstantFunTime"]
	if !ok {
		t.Fatal("the Resource 'ConstantFunTime' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 0 {
		t.Fatalf("expected 0 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	favouriteTable, ok := resource.Constants["MediaType"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] was not found")
	}
	if favouriteTable.Type != models.StringSDKConstantType {
		t.Fatalf("expected resource.Constants['TableNumber'].Type to be 'String' but got %q", favouriteTable.Type)
	}
	if len(favouriteTable.Values) != 3 {
		t.Fatalf("expected resource.Constants['TableNumber'] to have 3 values but got %d", len(favouriteTable.Values))
	}
	v, ok := favouriteTable.Values["EightTrack"]
	if !ok {
		t.Fatalf("resource.Constants['MediaType'] didn't contain the key 'One'")
	}
	if v != "8Track" {
		t.Fatalf("expected the value for resource.Constants['MediaType'].Values['EightTrack'] to be '8Track' but got %q", v)
	}
	v, ok = favouriteTable.Values["Cassette"]
	if !ok {
		t.Fatalf("resource.Constants['MediaType'] didn't contain the key 'Cassette'")
	}
	if v != "Cassette" {
		t.Fatalf("expected the value for resource.Constants['MediaType'].Values['Cassette'] to be 'Cassette' but got %q", v)
	}
	v, ok = favouriteTable.Values["Vinyl"]
	if !ok {
		t.Fatalf("resource.Constants['MediaType'] didn't contain the key 'Vinyl'")
	}
	if v != "Vinyl" {
		t.Fatalf("expected the value for resource.Constants['MediaType'].Values['Vinyl'] to be 'Vinyl' but got %q", v)
	}
}
