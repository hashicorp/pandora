// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser_test

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/testhelpers"
)

func TestParseDiscriminatorsTopLevel(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_discriminators_simple.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Discriminator": {
				Models: map[string]sdkModels.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]sdkModels.SDKField{
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("Animal"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"Animal": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
					},
					"Cat": {
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("cat"),
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"Dog": {
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("dog"),
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
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
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseDiscriminatorsWithinArray(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_discriminators_within_array.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Discriminator": {
				Models: map[string]sdkModels.SDKModel{
					"ExampleWrapper": {
						Fields: map[string]sdkModels.SDKField{
							"BiologicalEntities": {
								JsonName: "biologicalEntities",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("BiologicalEntity"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"BiologicalEntity": {
						Fields: map[string]sdkModels.SDKField{
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
					},
					"Cat": {
						ParentTypeName:                        pointer.To("BiologicalEntity"),
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
						DiscriminatedValue:                    pointer.To("cat"),
						Fields: map[string]sdkModels.SDKField{
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"Human": {
						ParentTypeName:                        pointer.To("BiologicalEntity"),
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
						DiscriminatedValue:                    pointer.To("human"),
						Fields: map[string]sdkModels.SDKField{
							"FirstName": {
								JsonName: "firstName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"LastName": {
								JsonName: "lastName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"TypeName": {
								JsonName: "typeName",
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
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseDiscriminatorsWithinDiscriminators(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_discriminators_within_discriminators.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Discriminator": {
				Models: map[string]sdkModels.SDKModel{
					"Animal": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"FavouriteToy": {
								JsonName: "favouriteToy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("Toy"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
					},
					"Bone": {
						Fields: map[string]sdkModels.SDKField{
							"Length": {
								JsonName: "length",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.FloatSDKObjectDefinitionType,
								},
								Required: true,
							},
							"ToyType": {
								JsonName: "toyType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("Toy"),
						FieldNameContainingDiscriminatedValue: pointer.To("ToyType"),
						DiscriminatedValue:                    pointer.To("bone"),
					},
					"Cat": {
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("cat"),
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"FavouriteToy": {
								JsonName: "favouriteToy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("Toy"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"Dog": {
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("dog"),
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"FavouriteToy": {
								JsonName: "favouriteToy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("Toy"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: false,
							},
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"ExampleWrapper": {
						Fields: map[string]sdkModels.SDKField{
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("Animal"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"LaserBeam": {
						Fields: map[string]sdkModels.SDKField{
							"Colour": {
								JsonName: "colour",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Intensity": {
								JsonName: "intensity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.IntegerSDKObjectDefinitionType,
								},
								Required: false,
							},
							"ToyType": {
								JsonName: "toyType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("Toy"),
						FieldNameContainingDiscriminatedValue: pointer.To("ToyType"),
						DiscriminatedValue:                    pointer.To("laser-beam"),
					},
					"Toy": {
						Fields: map[string]sdkModels.SDKField{
							"ToyType": {
								JsonName: "toyType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("ToyType"),
					},
				},
				Operations: map[string]sdkModels.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseDiscriminatedParentTypeThatShouldntBe(t *testing.T) {
	// Some Swagger files define top level types with a Discriminator value which don't inherit
	// from anything. As such these aren't actually discriminated types but bad data - so we should
	// look to ensure these are parsed out as a regular non-discriminated type.
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_discriminators_parent_that_shouldnt_be.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Discriminator": {
				Models: map[string]sdkModels.SDKModel{
					"Animal": {
						Fields: map[string]sdkModels.SDKField{
							"Type": {
								JsonName: "type",
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
							ReferenceName: pointer.To("Animal"),
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

func TestParseDiscriminatedChildTypeThatShouldntBe(t *testing.T) {
	// Some Swagger files define top level types with a Discriminator value which don't inherit
	// from anything. As such these aren't actually discriminated types but bad data - so we should
	// look to ensure these are parsed out as a regular non-discriminated type.
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_discriminators_child_that_shouldnt_be.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Discriminator": {
				Models: map[string]sdkModels.SDKModel{
					"Dog": {
						Fields: map[string]sdkModels.SDKField{
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
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
							ReferenceName: pointer.To("Dog"),
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

func TestParseDiscriminatedChildTypeWhereParentShouldNotBeUsed(t *testing.T) {
	// Some Swagger files contain Models with a reference to a Discriminated Type (e.g. an implementation
	// where a Parent should be used instead) - this asserts that we shouldn't switch these out to
	// referencing the Parent, instead should just use the Implementation itself.
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_discriminators_child_used_as_parent.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Discriminator": {
				Models: map[string]sdkModels.SDKModel{
					"Animal": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
					},
					"Cat": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("cat"),
					},
					"Dog": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("dog"),
					},
					"ExampleWrapper": {
						Fields: map[string]sdkModels.SDKField{
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("Dog"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
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
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseDiscriminatorsInheritingFromOtherDiscriminators(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_discriminators_inherited_from_discriminators.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Discriminator": {
				Models: map[string]sdkModels.SDKModel{
					"Animal": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
					},
					"Cat": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("cat"),
					},
					"Dog": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("dog"),
					},
					"ExampleWrapper": {
						Fields: map[string]sdkModels.SDKField{
							"Nested": {
								JsonName: "nested",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("Animal"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
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
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseDiscriminatorsDeepInheritance(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_discriminators_deep_inheritance.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Discriminator": {
				Models: map[string]sdkModels.SDKModel{
					"Animal": {
						Fields: map[string]sdkModels.SDKField{
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsPlantEater": {
								JsonName: "isPlantEater",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("BiologicalEntity"),
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
						DiscriminatedValue:                    pointer.To("animal"),
					},
					"BiologicalEntity": {
						Fields: map[string]sdkModels.SDKField{
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
					},
					"Carnivore": {
						Fields: map[string]sdkModels.SDKField{
							"IsPlantEater": {
								JsonName: "isPlantEater",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsPredator": {
								JsonName: "isPredator",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("BiologicalEntity"),
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
						DiscriminatedValue:                    pointer.To("carnivore"),
					},
					"Cat": {
						Fields: map[string]sdkModels.SDKField{
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsPlantEater": {
								JsonName: "isPlantEater",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"IsPredator": {
								JsonName: "isPredator",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("BiologicalEntity"),
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
						DiscriminatedValue:                    pointer.To("cat"),
					},
					"ExampleWrapper": {
						Fields: map[string]sdkModels.SDKField{
							"BiologicalEntity": {
								JsonName: "biologicalEntity",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("BiologicalEntity"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"PersianCat": {
						ParentTypeName:                        pointer.To("BiologicalEntity"),
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
						DiscriminatedValue:                    pointer.To("persian-cat"),
						Fields: map[string]sdkModels.SDKField{
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFriendly": {
								JsonName: "isFriendly",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsPlantEater": {
								JsonName: "isPlantEater",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"IsPredator": {
								JsonName: "isPredator",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
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
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseDiscriminatorsWithMultipleParents(t *testing.T) {
	// In this scenario the discriminated type Human inherits from NamedEntity (containing just properties)
	// which inherits from the discriminated parent type BiologicalEntity
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_discriminators_multiple_parents.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Discriminator": {
				Models: map[string]sdkModels.SDKModel{
					"BiologicalEntity": {
						Fields: map[string]sdkModels.SDKField{
							"SomeField": {
								JsonName: "someField",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
					},
					"Cat": {
						Fields: map[string]sdkModels.SDKField{
							"FirstName": {
								JsonName: "firstName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"LastName": {
								JsonName: "lastName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"SomeField": {
								JsonName: "someField",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("BiologicalEntity"),
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
						DiscriminatedValue:                    pointer.To("cat"),
					},
					"ExampleWrapper": {
						Fields: map[string]sdkModels.SDKField{
							"Item": {
								JsonName: "item",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									ReferenceName: pointer.To("BiologicalEntity"),
									Type:          sdkModels.ReferenceSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"Human": {
						Fields: map[string]sdkModels.SDKField{
							"Age": {
								JsonName: "age",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.IntegerSDKObjectDefinitionType,
								},
								Required: true,
							},
							"FirstName": {
								JsonName: "firstName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"LastName": {
								JsonName: "lastName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"SomeField": {
								JsonName: "someField",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("BiologicalEntity"),
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
						DiscriminatedValue:                    pointer.To("human"),
					},
					// NOTE: Whilst NamedEntity is present in the Swagger it shouldn't be in the result since
					// it's just an abstract type (defining the shared fields for Car and Human), rather than
					// being directly used.
				},
				Operations: map[string]sdkModels.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseDiscriminatorsWithMultipleParentsWithinArray(t *testing.T) {
	// In this scenario the discriminated type Human inherits from NamedEntity (containing just properties)
	// which inherits from the discriminated parent type BiologicalEntity
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_discriminators_multiple_parents_within_array.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Discriminator": {
				Models: map[string]sdkModels.SDKModel{
					"BiologicalEntity": {
						Fields: map[string]sdkModels.SDKField{
							"SomeField": {
								JsonName: "someField",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
					},
					"Cat": {
						Fields: map[string]sdkModels.SDKField{
							"FirstName": {
								JsonName: "firstName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"LastName": {
								JsonName: "lastName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"SomeField": {
								JsonName: "someField",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("BiologicalEntity"),
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
						DiscriminatedValue:                    pointer.To("cat"),
					},
					"ExampleWrapper": {
						Fields: map[string]sdkModels.SDKField{
							"Items": {
								JsonName: "items",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("BiologicalEntity"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
					"Human": {
						Fields: map[string]sdkModels.SDKField{
							"Age": {
								JsonName: "age",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.IntegerSDKObjectDefinitionType,
								},
								Required: true,
							},
							"FirstName": {
								JsonName: "firstName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"LastName": {
								JsonName: "lastName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"SomeField": {
								JsonName: "someField",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: false,
							},
							"TypeName": {
								JsonName: "typeName",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("BiologicalEntity"),
						FieldNameContainingDiscriminatedValue: pointer.To("TypeName"),
						DiscriminatedValue:                    pointer.To("human"),
					},
					// NOTE: Whilst NamedEntity is present in the Swagger it shouldn't be in the result since
					// it's just an abstract type (defining the shared fields for Car and Human), rather than
					// being directly used.
				},
				Operations: map[string]sdkModels.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						ResponseObject: &sdkModels.SDKObjectDefinition{
							ReferenceName: pointer.To("ExampleWrapper"),
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

func TestParseDiscriminatorsOrphanedChild(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "/nestedtestdata/model_discriminators_orphaned_child.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			// NOTE: since there's no Operations defined the Models are placed into an APIResource based on the
			// File Name. Whilst in a normal scenario this would make sense - for testing purposes it leads to
			// some unexpectedly named data, but this is fine providing the APIResource we're expecting exists.
			"ModelDiscriminatorsOrphanedChildren": {
				Models: map[string]sdkModels.SDKModel{
					"Animal": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
					},
					"Cat": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("cat"),
					},
					"Dog": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("dog"),
					},
					// ExampleWrapper is present in the Swagger but unused
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatorsOrphanedChildWithNestedModel(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "/nestedtestdata/model_discriminators_orphaned_child_with_nested_model.json", nil)
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			// NOTE: since there's no Operations defined the Models are placed into an APIResource based on the
			// File Name. Whilst in a normal scenario this would make sense - for testing purposes it leads to
			// some unexpectedly named data, but this is fine providing the APIResource we're expecting exists.
			"ModelDiscriminatorsOrphanedChildWithNestedModels": {
				Models: map[string]sdkModels.SDKModel{
					"Animal": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
					},
					"Cat": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("cat"),
					},
					"Dog": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Barks": {
								JsonName: "barks",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Parameters": {
								JsonName: "parameters",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									NestedItem: &sdkModels.SDKObjectDefinition{
										ReferenceName: pointer.To("KeyValuePair"),
										Type:          sdkModels.ReferenceSDKObjectDefinitionType,
									},
									Type: sdkModels.ListSDKObjectDefinitionType,
								},
								Required: false,
							},
						},
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("dog"),
					},
					// ExampleWrapper is present in the Swagger but unused
					"KeyValuePair": {
						Fields: map[string]sdkModels.SDKField{
							"Key": {
								JsonName: "key",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"Value": {
								JsonName: "value",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
					},
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatorsOrphanedChildWithoutDiscriminatorValue(t *testing.T) {
	// see https://github.com/Azure/azure-rest-api-specs/issues/28380
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "/nestedtestdata/model_discriminators_orphaned_child_without_discriminator_value.json", pointer.To("DataFactory"))
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			// NOTE: since there's no Operations defined the Models are placed into an APIResource based on the
			// File Name. Whilst in a normal scenario this would make sense - for testing purposes it leads to
			// some unexpectedly named data, but this is fine providing the APIResource we're expecting exists.
			"ModelDiscriminatorsOrphanedChildWithoutDiscriminatorValues": {
				Models: map[string]sdkModels.SDKModel{
					"Animal": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
					},
					"Cat": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("Cat"),
					},
					"Dog": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("Dog"),
					},
					// ExampleWrapper is present in the Swagger but unused
				},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatorsReferenceInAnotherSpecFile(t *testing.T) {
	// This tests whether Swagger Refs from another spec file are parsed correctly. The go-openapi module actually does
	// the heaving lifting here (thankfully!), loading in another file transparently when an external Ref is encountered.
	// An external Ref looks something like this:
	//
	//     "$ref": "./model_discriminators_ref_in_another_spec.json#/definitions/Animal"
	//
	// Where the anchor is preceded by a path to a neighboring spec. We don't need to code for this explicitly, nor
	// do we _really_ need to test for this, but since DataFactory relies heavily on this, this helps ensure we don't
	// break this in the future.
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "model_discriminators_ref_from_another_spec.json", pointer.To("DataFactory"))
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources: map[string]sdkModels.APIResource{
			"Example": {
				Constants: make(map[string]sdkModels.SDKConstant),
				Models: map[string]sdkModels.SDKModel{
					"Animal": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
					},
					"Cat": {
						Fields: map[string]sdkModels.SDKField{
							"AnimalType": {
								JsonName: "animalType",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.StringSDKObjectDefinitionType,
								},
								Required: true,
							},
							"IsFluffy": {
								JsonName: "isFluffy",
								ObjectDefinition: sdkModels.SDKObjectDefinition{
									Type: sdkModels.BooleanSDKObjectDefinitionType,
								},
								Required: true,
							},
						},
						ParentTypeName:                        pointer.To("Animal"),
						FieldNameContainingDiscriminatedValue: pointer.To("AnimalType"),
						DiscriminatedValue:                    pointer.To("Cat"),
					},
				},
				Name: "Example",
				Operations: map[string]sdkModels.SDKOperation{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						URISuffix:           pointer.To("/example"),
						ResponseObject: &sdkModels.SDKObjectDefinition{
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Animal"),
						},
					},
				},
				ResourceIDs: map[string]sdkModels.ResourceID{},
			},
		},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseDiscriminatorsOrphanedChildWithoutDiscriminatorValueForDifferentService(t *testing.T) {
	actual, err := testhelpers.ParseSwaggerFileForTesting(t, "/nestedtestdata/model_discriminators_orphaned_child_without_discriminator_value.json", pointer.To("Compute"))
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	// This test ensures that this behaviour is scoped to Data Factory and won't impact other services
	expected := sdkModels.APIVersion{
		APIVersion: "2020-01-01",
		Resources:  map[string]sdkModels.APIResource{},
	}
	testhelpers.ValidateParsedSwaggerResultMatches(t, expected, actual)
}
