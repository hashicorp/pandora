// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseDiscriminatorsTopLevel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_discriminators_simple.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Discriminator": {
				Models: map[string]importerModels.ModelDetails{
					"ExampleWrapper": {
						Fields: map[string]importerModels.FieldDetails{
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("Animal"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"Animal": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						TypeHintIn: pointer.To("AnimalType"),
					},
					"Cat": {
						ParentTypeName: pointer.To("Animal"),
						TypeHintIn:     pointer.To("AnimalType"),
						TypeHintValue:  pointer.To("cat"),
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"Dog": {
						ParentTypeName: pointer.To("Animal"),
						TypeHintIn:     pointer.To("AnimalType"),
						TypeHintValue:  pointer.To("dog"),
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatorsWithinArray(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_discriminators_within_array.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Discriminator": {
				Models: map[string]importerModels.ModelDetails{
					"ExampleWrapper": {
						Fields: map[string]importerModels.FieldDetails{
							"BiologicalEntities": {
								JsonName: "biologicalEntities",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("BiologicalEntity"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"BiologicalEntity": {
						Fields: map[string]importerModels.FieldDetails{
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						TypeHintIn: pointer.To("TypeName"),
					},
					"Cat": {
						ParentTypeName: pointer.To("BiologicalEntity"),
						TypeHintIn:     pointer.To("TypeName"),
						TypeHintValue:  pointer.To("cat"),
						Fields: map[string]importerModels.FieldDetails{
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"Human": {
						ParentTypeName: pointer.To("BiologicalEntity"),
						TypeHintIn:     pointer.To("TypeName"),
						TypeHintValue:  pointer.To("human"),
						Fields: map[string]importerModels.FieldDetails{
							"FirstName": {
								JsonName: "firstName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"LastName": {
								JsonName: "lastName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatorsWithinDiscriminators(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_discriminators_within_discriminators.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Discriminator": {
				Models: map[string]importerModels.ModelDetails{
					"Animal": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"FavouriteToy": {
								JsonName: "favouriteToy",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("Toy"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
						TypeHintIn: pointer.To("AnimalType"),
					},
					"Bone": {
						Fields: map[string]importerModels.FieldDetails{
							"Length": {
								JsonName: "length",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.FloatSDKObjectDefinitionType,
								},
								Required: true,
							},
							"ToyType": {
								JsonName: "toyType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("Toy"),
						TypeHintIn:     pointer.To("ToyType"),
						TypeHintValue:  pointer.To("bone"),
					},
					"Cat": {
						ParentTypeName: pointer.To("Animal"),
						TypeHintIn:     pointer.To("AnimalType"),
						TypeHintValue:  pointer.To("cat"),
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"FavouriteToy": {
								JsonName: "favouriteToy",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("Toy"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"Dog": {
						ParentTypeName: pointer.To("Animal"),
						TypeHintIn:     pointer.To("AnimalType"),
						TypeHintValue:  pointer.To("dog"),
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"FavouriteToy": {
								JsonName: "favouriteToy",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("Toy"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"ExampleWrapper": {
						Fields: map[string]importerModels.FieldDetails{
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("Animal"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"LaserBeam": {
						Fields: map[string]importerModels.FieldDetails{
							"Colour": {
								JsonName: "colour",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Intensity": {
								JsonName: "intensity",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"ToyType": {
								JsonName: "toyType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("Toy"),
						TypeHintIn:     pointer.To("ToyType"),
						TypeHintValue:  pointer.To("laser-beam"),
					},
					"Toy": {
						Fields: map[string]importerModels.FieldDetails{
							"ToyType": {
								JsonName: "toyType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						TypeHintIn: pointer.To("ToyType"),
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatedParentTypeThatShouldntBe(t *testing.T) {
	// Some Swagger files define top level types with a Discriminator value which don't inherit
	// from anything. As such these aren't actually discriminated types but bad data - so we should
	// look to ensure these are parsed out as a regular non-discriminated type.
	actual, err := ParseSwaggerFileForTesting(t, "model_discriminators_parent_that_shouldnt_be.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Discriminator": {
				Models: map[string]importerModels.ModelDetails{
					"Animal": {
						Fields: map[string]importerModels.FieldDetails{
							"Type": {
								JsonName: "type",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Animal"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatedChildTypeThatShouldntBe(t *testing.T) {
	// Some Swagger files define top level types with a Discriminator value which don't inherit
	// from anything. As such these aren't actually discriminated types but bad data - so we should
	// look to ensure these are parsed out as a regular non-discriminated type.
	actual, err := ParseSwaggerFileForTesting(t, "model_discriminators_child_that_shouldnt_be.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Discriminator": {
				Models: map[string]importerModels.ModelDetails{
					"Dog": {
						Fields: map[string]importerModels.FieldDetails{
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
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
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("Dog"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatedChildTypeWhereParentShouldNotBeUsed(t *testing.T) {
	// Some Swagger files contain Models with a reference to a Discriminated Type (e.g. an implementation
	// where a Parent should be used instead) - this asserts that we shouldn't switch these out to
	// referencing the Parent, instead should just use the Implementation itself.
	actual, err := ParseSwaggerFileForTesting(t, "model_discriminators_child_used_as_parent.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Discriminator": {
				Models: map[string]importerModels.ModelDetails{
					"Animal": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						TypeHintIn: pointer.To("AnimalType"),
					},
					"Cat": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("Animal"),
						TypeHintIn:     pointer.To("AnimalType"),
						TypeHintValue:  pointer.To("cat"),
					},
					"Dog": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("Animal"),
						TypeHintIn:     pointer.To("AnimalType"),
						TypeHintValue:  pointer.To("dog"),
					},
					"ExampleWrapper": {
						Fields: map[string]importerModels.FieldDetails{
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("Dog"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatorsInheritingFromOtherDiscriminators(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_discriminators_inherited_from_discriminators.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Discriminator": {
				Models: map[string]importerModels.ModelDetails{
					"Animal": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						TypeHintIn: pointer.To("AnimalType"),
					},
					"Cat": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("Animal"),
						TypeHintIn:     pointer.To("AnimalType"),
						TypeHintValue:  pointer.To("cat"),
					},
					"Dog": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("Animal"),
						TypeHintIn:     pointer.To("AnimalType"),
						TypeHintValue:  pointer.To("dog"),
					},
					"ExampleWrapper": {
						Fields: map[string]importerModels.FieldDetails{
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("Animal"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatorsDeepInheritance(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_discriminators_deep_inheritance.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Discriminator": {
				Models: map[string]importerModels.ModelDetails{
					"Animal": {
						Fields: map[string]importerModels.FieldDetails{
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsPlantEater": {
								JsonName: "isPlantEater",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("BiologicalEntity"),
						TypeHintIn:     pointer.To("TypeName"),
						TypeHintValue:  pointer.To("animal"),
					},
					"BiologicalEntity": {
						Fields: map[string]importerModels.FieldDetails{
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						TypeHintIn: pointer.To("TypeName"),
					},
					"Carnivore": {
						Fields: map[string]importerModels.FieldDetails{
							"IsPlantEater": {
								JsonName: "isPlantEater",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsPredator": {
								JsonName: "isPredator",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("BiologicalEntity"),
						TypeHintIn:     pointer.To("TypeName"),
						TypeHintValue:  pointer.To("carnivore"),
					},
					"Cat": {
						Fields: map[string]importerModels.FieldDetails{
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsPlantEater": {
								JsonName: "isPlantEater",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"IsPredator": {
								JsonName: "isPredator",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("BiologicalEntity"),
						TypeHintIn:     pointer.To("TypeName"),
						TypeHintValue:  pointer.To("cat"),
					},
					"ExampleWrapper": {
						Fields: map[string]importerModels.FieldDetails{
							"BiologicalEntity": {
								JsonName: "biologicalEntity",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("BiologicalEntity"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"PersianCat": {
						ParentTypeName: pointer.To("BiologicalEntity"),
						TypeHintIn:     pointer.To("TypeName"),
						TypeHintValue:  pointer.To("persian-cat"),
						Fields: map[string]importerModels.FieldDetails{
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFriendly": {
								JsonName: "isFriendly",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsPlantEater": {
								JsonName: "isPlantEater",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"IsPredator": {
								JsonName: "isPredator",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatorsWithMultipleParents(t *testing.T) {
	// In this scenario the discriminated type Human inherits from NamedEntity (containing just properties)
	// which inherits from the discriminated parent type BiologicalEntity
	actual, err := ParseSwaggerFileForTesting(t, "model_discriminators_multiple_parents.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Discriminator": {
				Models: map[string]importerModels.ModelDetails{
					"BiologicalEntity": {
						Fields: map[string]importerModels.FieldDetails{
							"SomeField": {
								JsonName: "someField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						TypeHintIn: pointer.To("TypeName"),
					},
					"Cat": {
						Fields: map[string]importerModels.FieldDetails{
							"FirstName": {
								JsonName: "firstName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"LastName": {
								JsonName: "lastName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"SomeField": {
								JsonName: "someField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("BiologicalEntity"),
						TypeHintIn:     pointer.To("TypeName"),
						TypeHintValue:  pointer.To("cat"),
					},
					"ExampleWrapper": {
						Fields: map[string]importerModels.FieldDetails{
							"Item": {
								JsonName: "item",
								ObjectDefinition: models.SDKObjectDefinition{
									ReferenceName: pointer.To("BiologicalEntity"),
									Type:          models.ReferenceSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"Human": {
						Fields: map[string]importerModels.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.IntegerSDKObjectDefinitionType,
								},
								Required: true,
							},
							"FirstName": {
								JsonName: "firstName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"LastName": {
								JsonName: "lastName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"SomeField": {
								JsonName: "someField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("BiologicalEntity"),
						TypeHintIn:     pointer.To("TypeName"),
						TypeHintValue:  pointer.To("human"),
					},
					// NOTE: Whilst NamedEntity is present in the Swagger it shouldn't be in the result since
					// it's just an abstract type (defining the shared fields for Car and Human), rather than
					// being directly used.
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatorsWithMultipleParentsWithinArray(t *testing.T) {
	// In this scenario the discriminated type Human inherits from NamedEntity (containing just properties)
	// which inherits from the discriminated parent type BiologicalEntity
	actual, err := ParseSwaggerFileForTesting(t, "model_discriminators_multiple_parents_within_array.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			"Discriminator": {
				Models: map[string]importerModels.ModelDetails{
					"BiologicalEntity": {
						Fields: map[string]importerModels.FieldDetails{
							"SomeField": {
								JsonName: "someField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						TypeHintIn: pointer.To("TypeName"),
					},
					"Cat": {
						Fields: map[string]importerModels.FieldDetails{
							"FirstName": {
								JsonName: "firstName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"LastName": {
								JsonName: "lastName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"SomeField": {
								JsonName: "someField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("BiologicalEntity"),
						TypeHintIn:     pointer.To("TypeName"),
						TypeHintValue:  pointer.To("cat"),
					},
					"ExampleWrapper": {
						Fields: map[string]importerModels.FieldDetails{
							"Items": {
								JsonName: "items",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("BiologicalEntity"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"Human": {
						Fields: map[string]importerModels.FieldDetails{
							"Age": {
								JsonName: "age",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.IntegerSDKObjectDefinitionType,
								},
								Required: true,
							},
							"FirstName": {
								JsonName: "firstName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"LastName": {
								JsonName: "lastName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"SomeField": {
								JsonName: "someField",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("BiologicalEntity"),
						TypeHintIn:     pointer.To("TypeName"),
						TypeHintValue:  pointer.To("human"),
					},
					// NOTE: Whilst NamedEntity is present in the Swagger it shouldn't be in the result since
					// it's just an abstract type (defining the shared fields for Car and Human), rather than
					// being directly used.
				},
				Operations: map[string]importerModels.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &models.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatorsOrphanedChild(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "/nestedtestdata/model_discriminators_orphaned_child.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			// NOTE: since there's no Operations defined the Models are placed into an APIResource based on the
			// File Name. Whilst in a normal scenario this would make sense - for testing purposes it leads to
			// some unexpectedly named data, but this is fine providing the APIResource we're expecting exists.
			"ModelDiscriminatorsOrphanedChildren": {
				Models: map[string]importerModels.ModelDetails{
					"Animal": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						TypeHintIn: pointer.To("AnimalType"),
					},
					"Cat": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("Animal"),
						TypeHintIn:     pointer.To("AnimalType"),
						TypeHintValue:  pointer.To("cat"),
					},
					"Dog": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("Animal"),
						TypeHintIn:     pointer.To("AnimalType"),
						TypeHintValue:  pointer.To("dog"),
					},
					// ExampleWrapper is present in the Swagger but unused
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatorsOrphanedChildWithNestedModel(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "/nestedtestdata/model_discriminators_orphaned_child_with_nested_model.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := importerModels.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]importerModels.AzureApiResource{
			// NOTE: since there's no Operations defined the Models are placed into an APIResource based on the
			// File Name. Whilst in a normal scenario this would make sense - for testing purposes it leads to
			// some unexpectedly named data, but this is fine providing the APIResource we're expecting exists.
			"ModelDiscriminatorsOrphanedChildWithNestedModels": {
				Models: map[string]importerModels.ModelDetails{
					"Animal": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						TypeHintIn: pointer.To("AnimalType"),
					},
					"Cat": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName: pointer.To("Animal"),
						TypeHintIn:     pointer.To("AnimalType"),
						TypeHintValue:  pointer.To("cat"),
					},
					"Dog": {
						Fields: map[string]importerModels.FieldDetails{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Parameters": {
								JsonName: "parameters",
								ObjectDefinition: models.SDKObjectDefinition{
									NestedItem: &models.SDKObjectDefinition{
										ReferenceName: pointer.To("KeyValuePair"),
										Type:          models.ReferenceSDKObjectDefinitionType,
									},
									Type: models.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
						ParentTypeName: pointer.To("Animal"),
						TypeHintIn:     pointer.To("AnimalType"),
						TypeHintValue:  pointer.To("dog"),
					},
					// ExampleWrapper is present in the Swagger but unused
					"KeyValuePair": {
						Fields: map[string]importerModels.FieldDetails{
							"Key": {
								JsonName: "key",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Value": {
								JsonName: "value",
								ObjectDefinition: models.SDKObjectDefinition{
									Type: models.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
