package parser

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseDiscriminatorsTopLevel(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_discriminators_simple.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 0 {
		t.Fatalf("expected no constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 4 {
		t.Fatalf("expected 4 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if wrapper.ParentTypeName != nil {
		t.Fatalf("wrapper.ParentTypeName should be nil but was %q", *wrapper.ParentTypeName)
	}
	if wrapper.TypeHintIn != nil {
		t.Fatalf("wrapper.TypeHintIn should be nil but was %q", *wrapper.TypeHintIn)
	}
	if wrapper.TypeHintValue != nil {
		t.Fatalf("wrapper.TypeHintValue should be nil but was %q", *wrapper.TypeHintValue)
	}

	animal, ok := resource.Models["Animal"]
	if !ok {
		t.Fatalf("the Model `Animal` was not found")
	}
	if animal.ParentTypeName != nil {
		t.Fatalf("animal.ParentTypeName should be nil but was %q", *animal.ParentTypeName)
	}
	if animal.TypeHintIn == nil {
		t.Fatal("animal.TypeHintIn should have a value but it doesn't")
	}
	if animal.TypeHintValue != nil {
		t.Fatalf("animal.TypeHintValue should be nil but was %q", *animal.TypeHintValue)
	}

	cat, ok := resource.Models["Cat"]
	if !ok {
		t.Fatalf("the Model `Cat` was not found")
	}
	if cat.ParentTypeName == nil {
		t.Fatalf("cat.ParentTypeName should have a value but it doesn't")
	}
	if *cat.ParentTypeName != "Animal" {
		t.Fatalf("cat.ParentTypeName should be `Animal` but it was %q", *cat.ParentTypeName)
	}
	if cat.TypeHintIn == nil {
		t.Fatal("cat.TypeHintIn should have a value but it doesn't")
	}
	if *cat.TypeHintIn != "AnimalType" {
		t.Fatalf("cat.TypeHintIn should be `AnimalType` but it was %q", *cat.TypeHintIn)
	}
	if cat.TypeHintValue == nil {
		t.Fatalf("cat.TypeHintValue should have a value but it doesn't")
	}
	if *cat.TypeHintValue != "cat" {
		t.Fatalf("cat.TypeHintValue should be `cat` but it was %q", *cat.TypeHintValue)
	}

	dog, ok := resource.Models["Dog"]
	if !ok {
		t.Fatalf("the Model `Dog` was not found")
	}
	if dog.ParentTypeName == nil {
		t.Fatalf("dog.ParentTypeName should have a value but it doesn't")
	}
	if *dog.ParentTypeName != "Animal" {
		t.Fatalf("dog.ParentTypeName should be `Animal` but it was %q", *dog.ParentTypeName)
	}
	if dog.TypeHintIn == nil {
		t.Fatal("dog.TypeHintIn should have a value but it doesn't")
	}
	if *dog.TypeHintIn != "AnimalType" {
		t.Fatalf("dog.TypeHintIn should be `AnimalType` but it was %q", *dog.TypeHintIn)
	}
	if dog.TypeHintValue == nil {
		t.Fatalf("dog.TypeHintValue should have a value but it doesn't")
	}
	if *dog.TypeHintValue != "dog" {
		t.Fatalf("dog.TypeHintValue should be `dog` but it was %q", *dog.TypeHintValue)
	}
}

func TestParseDiscriminatorsWithinArray(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_discriminators_within_array.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 0 {
		t.Fatalf("expected no constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 4 {
		t.Fatalf("expected 4 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if wrapper.ParentTypeName != nil {
		t.Fatalf("wrapper.ParentTypeName should be nil but was %q", *wrapper.ParentTypeName)
	}
	if wrapper.TypeHintIn != nil {
		t.Fatalf("wrapper.TypeHintIn should be nil but was %q", *wrapper.TypeHintIn)
	}
	if wrapper.TypeHintValue != nil {
		t.Fatalf("wrapper.TypeHintValue should be nil but was %q", *wrapper.TypeHintValue)
	}
	if len(wrapper.Fields) != 1 {
		t.Fatalf("wrapper should have 1 field but got %d", len(wrapper.Fields))
	}
	biologicalEntitiesField, ok := wrapper.Fields["BiologicalEntities"]
	if !ok {
		t.Fatalf("expected wrapper to have a field 'BiologicalEntities' but didn't find it")
	}
	if biologicalEntitiesField.ObjectDefinition.Type != models.ObjectDefinitionList {
		t.Fatalf("expected 'BiologicalEntities' to be a List but got %q", string(biologicalEntitiesField.ObjectDefinition.Type))
	}
	if biologicalEntitiesField.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected 'BiologicalEntities' to be a List of an Reference but got %q", string(biologicalEntitiesField.ObjectDefinition.NestedItem.Type))
	}
	if *biologicalEntitiesField.ObjectDefinition.NestedItem.ReferenceName != "BiologicalEntity" {
		t.Fatalf("expected 'BiologicalEntities' to be a List of BiologicalEntity but got %q", *biologicalEntitiesField.ObjectDefinition.NestedItem.ReferenceName)
	}

	entity, ok := resource.Models["BiologicalEntity"]
	if !ok {
		t.Fatalf("the Model `BiologicalEntity` was not found")
	}
	if entity.ParentTypeName != nil {
		t.Fatalf("entity.ParentTypeName should be nil but was %q", *entity.ParentTypeName)
	}
	if entity.TypeHintIn == nil {
		t.Fatal("entity.TypeHintIn should have a value but it doesn't")
	}
	if entity.TypeHintValue != nil {
		t.Fatalf("entity.TypeHintValue should be nil but was %q", *entity.TypeHintValue)
	}

	cat, ok := resource.Models["Cat"]
	if !ok {
		t.Fatalf("the Model `Cat` was not found")
	}
	if cat.ParentTypeName == nil {
		t.Fatal("cat.ParentTypeName should be 'BiologicalEntity' but was nil")
	}
	if *cat.ParentTypeName != "BiologicalEntity" {
		t.Fatalf("cat.ParentTypeName should be 'BiologicalEntity' but was %q", *cat.ParentTypeName)
	}
	if *cat.TypeHintIn != "TypeName" {
		t.Fatalf("cat.TypeHintIn should be 'TypeName' but got %q", *cat.TypeHintIn)
	}
	if cat.TypeHintValue == nil {
		t.Fatal("cat.TypeHintValue should have a value but it was nil")
	}
	if *cat.TypeHintValue != "cat" {
		t.Fatalf("cat.TypeHintValue should be 'cat' but got %q", *cat.TypeHintValue)
	}
	if len(cat.Fields) != 2 {
		t.Fatalf("cat should have 2 fields but got %d", len(cat.Fields))
	}

	human, ok := resource.Models["Human"]
	if !ok {
		t.Fatalf("the Model `Human` was not found")
	}
	if human.ParentTypeName == nil {
		t.Fatal("human.ParentTypeName should be 'BiologicalEntity' but was nil")
	}
	if *human.ParentTypeName != "BiologicalEntity" {
		t.Fatalf("human.ParentTypeName should be 'BiologicalEntity' but was %q", *human.ParentTypeName)
	}
	if *human.TypeHintIn != "TypeName" {
		t.Fatalf("human.TypeHintIn should be 'TypeName' but got %q", *human.TypeHintIn)
	}
	if human.TypeHintValue == nil {
		t.Fatal("human.TypeHintValue should have a value but it was nil")
	}
	if *human.TypeHintValue != "human" {
		t.Fatalf("human.TypeHintValue should be 'human' but got %q", *human.TypeHintValue)
	}
	if len(human.Fields) != 3 {
		t.Fatalf("human should have 2 fields but got %d", len(human.Fields))
	}
}

func TestParseDiscriminatorsWithinDiscriminators(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_discriminators_within_discriminators.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 0 {
		t.Fatalf("expected no constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 7 {
		t.Fatalf("expected 7 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if wrapper.ParentTypeName != nil {
		t.Fatalf("wrapper.ParentTypeName should be nil but was %q", *wrapper.ParentTypeName)
	}
	if wrapper.TypeHintIn != nil {
		t.Fatalf("wrapper.TypeHintIn should be nil but was %q", *wrapper.TypeHintIn)
	}
	if wrapper.TypeHintValue != nil {
		t.Fatalf("wrapper.TypeHintValue should be nil but was %q", *wrapper.TypeHintValue)
	}

	animal, ok := resource.Models["Animal"]
	if !ok {
		t.Fatalf("the Model `Animal` was not found")
	}
	if animal.ParentTypeName != nil {
		t.Fatalf("animal.ParentTypeName should be nil but was %q", *animal.ParentTypeName)
	}
	if animal.TypeHintIn == nil {
		t.Fatal("animal.TypeHintIn should have a value but it doesn't")
	}
	if *animal.TypeHintIn != "AnimalType" {
		t.Fatalf("toy.TypeHintIn should be 'AnimalType' but it was %q", *animal.TypeHintIn)
	}
	if animal.TypeHintValue != nil {
		t.Fatalf("animal.TypeHintValue should be nil but was %q", *animal.TypeHintValue)
	}

	cat, ok := resource.Models["Cat"]
	if !ok {
		t.Fatalf("the Model `Cat` was not found")
	}
	if cat.ParentTypeName == nil {
		t.Fatalf("cat.ParentTypeName should have a value but it doesn't")
	}
	if *cat.ParentTypeName != "Animal" {
		t.Fatalf("cat.ParentTypeName should be `Animal` but it was %q", *cat.ParentTypeName)
	}
	if cat.TypeHintIn == nil {
		t.Fatal("cat.TypeHintIn should have a value but it doesn't")
	}
	if *cat.TypeHintIn != "AnimalType" {
		t.Fatalf("cat.TypeHintIn should be `AnimalType` but it was %q", *cat.TypeHintIn)
	}
	if cat.TypeHintValue == nil {
		t.Fatalf("cat.TypeHintValue should have a value but it doesn't")
	}
	if *cat.TypeHintValue != "cat" {
		t.Fatalf("cat.TypeHintValue should be `cat` but it was %q", *cat.TypeHintValue)
	}
	if len(cat.Fields) != 3 {
		t.Fatalf("expected resource.Models['Cat'] to have 3 fields but got %d", len(cat.Fields))
	}

	dog, ok := resource.Models["Dog"]
	if !ok {
		t.Fatalf("the Model `Dog` was not found")
	}
	if dog.ParentTypeName == nil {
		t.Fatalf("dog.ParentTypeName should have a value but it doesn't")
	}
	if *dog.ParentTypeName != "Animal" {
		t.Fatalf("dog.ParentTypeName should be `Animal` but it was %q", *dog.ParentTypeName)
	}
	if dog.TypeHintIn == nil {
		t.Fatal("dog.TypeHintIn should have a value but it doesn't")
	}
	if *dog.TypeHintIn != "AnimalType" {
		t.Fatalf("dog.TypeHintIn should be `AnimalType` but it was %q", *dog.TypeHintIn)
	}
	if dog.TypeHintValue == nil {
		t.Fatalf("dog.TypeHintValue should have a value but it doesn't")
	}
	if *dog.TypeHintValue != "dog" {
		t.Fatalf("dog.TypeHintValue should be `dog` but it was %q", *dog.TypeHintValue)
	}
	if len(dog.Fields) != 3 {
		t.Fatalf("expected resource.Models['Dog'] to have 3 fields but got %d", len(dog.Fields))
	}

	toy, ok := resource.Models["Toy"]
	if !ok {
		t.Fatalf("the Model `Toy` was not found")
	}
	if toy.ParentTypeName != nil {
		t.Fatalf("toy.ParentTypeName should be nil but was %q", *toy.ParentTypeName)
	}
	if toy.TypeHintIn == nil {
		t.Fatal("toy.TypeHintIn should have a value but it doesn't")
	}
	if *toy.TypeHintIn != "ToyType" {
		t.Fatalf("toy.TypeHintIn should be 'ToyType' but it was %q", *toy.TypeHintIn)
	}
	if toy.TypeHintValue != nil {
		t.Fatalf("toy.TypeHintValue should be nil but was %q", *toy.TypeHintValue)
	}

	bone, ok := resource.Models["Bone"]
	if !ok {
		t.Fatalf("the Model `Bone` was not found")
	}
	if bone.ParentTypeName == nil {
		t.Fatalf("bone.ParentTypeName should have a value but it doesn't")
	}
	if *bone.ParentTypeName != "Toy" {
		t.Fatalf("bone.ParentTypeName should be `Toy` but it was %q", *bone.ParentTypeName)
	}
	if bone.TypeHintIn == nil {
		t.Fatal("bone.TypeHintIn should have a value but it doesn't")
	}
	if *bone.TypeHintIn != "ToyType" {
		t.Fatalf("bone.TypeHintIn should be `ToyType` but it was %q", *bone.TypeHintIn)
	}
	if bone.TypeHintValue == nil {
		t.Fatalf("bone.TypeHintValue should have a value but it doesn't")
	}
	if *bone.TypeHintValue != "bone" {
		t.Fatalf("bone.TypeHintValue should be `bone` but it was %q", *bone.TypeHintValue)
	}
	if len(bone.Fields) != 2 {
		t.Fatalf("expected resource.Models['Bone'] to have 2 fields but got %d", len(bone.Fields))
	}

	laserBeam, ok := resource.Models["LaserBeam"]
	if !ok {
		t.Fatalf("the Model `LazerBeam` was not found")
	}
	if laserBeam.ParentTypeName == nil {
		t.Fatalf("laserBeam.ParentTypeName should have a value but it doesn't")
	}
	if *laserBeam.ParentTypeName != "Toy" {
		t.Fatalf("laserBeam.ParentTypeName should be `Toy` but it was %q", *laserBeam.ParentTypeName)
	}
	if laserBeam.TypeHintIn == nil {
		t.Fatal("laserBeam.TypeHintIn should have a value but it doesn't")
	}
	if *laserBeam.TypeHintIn != "ToyType" {
		t.Fatalf("laserBeam.TypeHintIn should be `ToyType` but it was %q", *laserBeam.TypeHintIn)
	}
	if laserBeam.TypeHintValue == nil {
		t.Fatalf("laserBeam.TypeHintValue should have a value but it doesn't")
	}
	if *laserBeam.TypeHintValue != "laser-beam" {
		t.Fatalf("laserBeam.TypeHintValue should be `lazer-beam` but it was %q", *laserBeam.TypeHintValue)
	}
	if len(laserBeam.Fields) != 3 {
		t.Fatalf("expected resource.Models['LazerBeam'] to have 3 fields but got %d", len(laserBeam.Fields))
	}
}

func TestParseDiscriminatedParentTypeThatShouldntBe(t *testing.T) {
	// Some Swagger files define top level types with a Discriminator value which don't inherit
	// from anything. As such these aren't actually discriminated types but bad data - so we should
	// look to ensure these are parsed out as a regular non-discriminated type.
	result, err := ParseSwaggerFileForTesting(t, "model_discriminators_parent_that_shouldnt_be.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 0 {
		t.Fatalf("expected no constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 1 {
		t.Fatalf("expected 1 model but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	animal, ok := resource.Models["Animal"]
	if !ok {
		t.Fatalf("the Model `Animal` was not found")
	}
	if animal.ParentTypeName != nil {
		t.Fatalf("animal.ParentTypeName should be nil but got %q", *animal.ParentTypeName)
	}
	if animal.TypeHintIn != nil {
		t.Fatalf("animal.TypeHintIn should be nil but got %q", *animal.TypeHintIn)
	}
	if animal.TypeHintValue != nil {
		t.Fatalf("animal.TypeHintValue should be nil but got %q", *animal.TypeHintValue)
	}
}

func TestParseDiscriminatedChildTypeThatShouldntBe(t *testing.T) {
	// Some Swagger files define top level types with a Discriminator value which don't inherit
	// from anything. As such these aren't actually discriminated types but bad data - so we should
	// look to ensure these are parsed out as a regular non-discriminated type.
	result, err := ParseSwaggerFileForTesting(t, "model_discriminators_child_that_shouldnt_be.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 0 {
		t.Fatalf("expected no constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 1 {
		t.Fatalf("expected 1 model but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	dog, ok := resource.Models["Dog"]
	if !ok {
		t.Fatalf("the Model `Dog` was not found")
	}
	if dog.ParentTypeName != nil {
		t.Fatalf("dog.ParentTypeName should be nil but got %q", *dog.ParentTypeName)
	}
	if dog.TypeHintIn != nil {
		t.Fatalf("dog.TypeHintIn should be nil but got %q", *dog.TypeHintIn)
	}
	if dog.TypeHintValue != nil {
		t.Fatalf("dog.TypeHintValue should be nil but got %q", *dog.TypeHintValue)
	}
}

func TestParseDiscriminatedChildTypeWhereParentShouldBeUsed(t *testing.T) {
	// Some Swagger files contain Models with a reference to a Discriminated Type (e.g. an implementation
	// where a Parent should be used instead) - this asserts that we switch these out so that the Field
	// references the Parent rather than the Implementation.
	result, err := ParseSwaggerFileForTesting(t, "model_discriminators_child_used_as_parent.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 0 {
		t.Fatalf("expected no constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 4 {
		t.Fatalf("expected 4 model but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 1 {
		t.Fatalf("expected the Model `ExampleWrapper` to have 1 field but got %d", len(wrapper.Fields))
	}
	nested, ok := wrapper.Fields["Nested"]
	if !ok {
		t.Fatalf("expected the Model `ExampleWrapper` to have a field named Nested but it didn't")
	}
	if nested.ObjectDefinition == nil {
		t.Fatalf("expected the Field `Nested` within the Model `ExampleWrapper` to have an ObjectDefinition it didn't")
	}
	if nested.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the Field `Nested` within the Model `ExampleWrapper` to be a Reference but it wasn't")
	}
	if nested.ObjectDefinition.ReferenceName == nil {
		t.Fatalf("expected the Field `Nested` within the Model `ExampleWrapper` to be a Reference but it was nil")
	}
	// NOTE: this is the primary assertion here, since the Swagger defined "Dog" should be swapped out for "Animal"
	if *nested.ObjectDefinition.ReferenceName != "Animal" {
		t.Fatalf("expected the Field `Nested` within the Model `ExampleWrapper` to be a Reference to `Animal` but got %q", *nested.ObjectDefinition.ReferenceName)
	}

	animal, ok := resource.Models["Animal"]
	if !ok {
		t.Fatalf("the Model `Animal` was not found")
	}
	if animal.ParentTypeName != nil {
		t.Fatalf("animal.ParentTypeName should be nil but got %q", *animal.ParentTypeName)
	}
	if animal.TypeHintIn == nil {
		t.Fatalf("animal.TypeHintIn should have a value but it was nil")
	}
	if animal.TypeHintValue != nil {
		t.Fatalf("animal.TypeHintValue should be nil but got %q", *animal.TypeHintValue)
	}

	cat, ok := resource.Models["Cat"]
	if !ok {
		t.Fatalf("the Model `Cat` was not found")
	}
	if cat.ParentTypeName == nil {
		t.Fatalf("cat.ParentTypeName should have a value but it was nil")
	}
	if *cat.ParentTypeName != "Animal" {
		t.Fatalf("cat.ParentTypeName should be `Animal` but got %q", *cat.ParentTypeName)
	}
	if cat.TypeHintIn == nil {
		t.Fatalf("cat.TypeHintIn should have a value but it was nil")
	}
	if *cat.TypeHintIn != "AnimalType" {
		t.Fatalf("cat.TypeHintIn should be `AnimalType` but got %q", *cat.TypeHintIn)
	}
	if cat.TypeHintValue == nil {
		t.Fatalf("cat.TypeHintValue should have a value but it was nil")
	}
	if *cat.TypeHintValue != "cat" {
		t.Fatalf("cat.TypeHintValue should be `cat` but got %q", *cat.TypeHintValue)
	}

	dog, ok := resource.Models["Dog"]
	if !ok {
		t.Fatalf("the Model `Dog` was not found")
	}

	if dog.ParentTypeName == nil {
		t.Fatalf("dog.ParentTypeName should have a value but it was nil")
	}
	if *dog.ParentTypeName != "Animal" {
		t.Fatalf("dog.ParentTypeName should be `Animal` but got %q", *dog.ParentTypeName)
	}
	if dog.TypeHintIn == nil {
		t.Fatalf("dog.TypeHintIn should have a value but it was nil")
	}
	if *dog.TypeHintIn != "AnimalType" {
		t.Fatalf("dog.TypeHintIn should be `AnimalType` but got %q", *dog.TypeHintIn)
	}
	if dog.TypeHintValue == nil {
		t.Fatalf("dog.TypeHintValue should have a value but it was nil")
	}
	if *dog.TypeHintValue != "dog" {
		t.Fatalf("dog.TypeHintValue should be `dog` but got %q", *dog.TypeHintValue)
	}
}
