package parser

import "testing"

func TestParseConstantsStringsTopLevel(t *testing.T) {
	parsed, err := Load("testdata/", "constants_strings.json", true)
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
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
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
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	animal, ok := resource.Models["Animal"]
	if !ok {
		t.Fatalf("the Model `Animal` was not found")
	}
	if len(animal.Fields) != 1 {
		t.Fatalf("expected animal.Fields to have 1 field but got %d", len(animal.Fields))
	}
	animalTypeField, ok := animal.Fields["animalType"]
	if !ok {
		t.Fatal("animal.Fields['animalType'] did not exist")
	}
	if animalTypeField.ConstantReference == nil {
		t.Fatal("animal.Fields['animalType'] had a nil ConstantReference")
	}
	if *animalTypeField.ConstantReference != "AnimalType" {
		t.Fatalf("animal.Fields['animalType'] should be 'AnimalType' but was %q", *animalTypeField.ConstantReference)
	}

	animalType, ok := resource.Constants["AnimalType"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] was not found")
	}
	if len(animalType.Values) != 3 {
		t.Fatalf("expected resource.Constants['AnimalType'] to have 3 values but got %d", len(animalType.Values))
	}
	v, ok := animalType.Values["Cat"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Cat'")
	}
	if v != "cat" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Cat'] to be 'cat' but got %q", v)
	}
	v, ok = animalType.Values["Dog"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Dog'")
	}
	if v != "dog" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Dog'] to be 'dog' but got %q", v)
	}
	v, ok = animalType.Values["Panda"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Panda'")
	}
	if v != "panda" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Panda'] to be 'panda' but got %q", v)
	}
}
