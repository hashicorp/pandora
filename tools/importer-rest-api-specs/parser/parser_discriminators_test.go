package parser

import "testing"

func TestParseDiscriminatorsTopLevel(t *testing.T) {
	parsed, err := Load("testdata/", "discriminators_simple.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if *cat.TypeHintIn != "animalType" {
		t.Fatalf("cat.TypeHintIn should be `animalType` but it was %q", *cat.TypeHintIn)
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
	if *dog.TypeHintIn != "animalType" {
		t.Fatalf("dog.TypeHintIn should be `animalType` but it was %q", *dog.TypeHintIn)
	}
	if dog.TypeHintValue == nil {
		t.Fatalf("dog.TypeHintValue should have a value but it doesn't")
	}
	if *dog.TypeHintValue != "dog" {
		t.Fatalf("dog.TypeHintValue should be `dog` but it was %q", *dog.TypeHintValue)
	}
}
