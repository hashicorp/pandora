package parser

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseModelSingleTopLevel(t *testing.T) {
	parsed, err := Load("testdata/", "model_single.json", true)
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
		t.Fatalf("expected 0 constants but got %d", len(resource.Constants))
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

	example, ok := resource.Models["Example"]
	if !ok {
		t.Fatalf("the Model `Example` was not found")
	}
	if len(example.Fields) != 4 {
		t.Fatalf("expected example.Fields to have 4 fields but got %d", len(example.Fields))
	}

	name, ok := example.Fields["Name"]
	if !ok {
		t.Fatalf("example.Fields['Name'] was missing")
	}
	if name.Type != models.String {
		t.Fatalf("expected example.Fields['Name'] to be a string but got %q", string(name.Type))
	}
	if name.JsonName != "name" {
		t.Fatalf("expected example.Fields['Name'].JsonName to be 'name' but got %q", name.JsonName)
	}

	age, ok := example.Fields["Age"]
	if !ok {
		t.Fatalf("example.Fields['Age'] was missing")
	}
	if age.Type != models.Integer {
		t.Fatalf("expected example.Fields['Age'] to be an integer but got %q", string(age.Type))
	}
	if age.JsonName != "age" {
		t.Fatalf("expected example.Fields['Age'].JsonName to be 'age' but got %q", age.JsonName)
	}

	enabled, ok := example.Fields["Enabled"]
	if !ok {
		t.Fatalf("example.Fields['Enabled'] was missing")
	}
	if enabled.Type != models.Boolean {
		t.Fatalf("expected example.Fields['Enabled'] to be a boolean but got %q", string(enabled.Type))
	}
	if enabled.JsonName != "enabled" {
		t.Fatalf("expected example.Fields['Enabled'].JsonName to be 'enabled' but got %q", enabled.JsonName)
	}

	tags, ok := example.Fields["Tags"]
	if !ok {
		t.Fatalf("example.Fields['Tags'] was missing")
	}
	if tags.Type != models.Tags {
		t.Fatalf("expected example.Fields['Tags'] to be Tags but got %q", string(tags.Type))
	}
	if tags.JsonName != "tags" {
		t.Fatalf("expected example.Fields['Tags'].JsonName to be 'tags' but got %q", tags.JsonName)
	}
}

func TestParseModelSingleTopLevelWithInlinedModel(t *testing.T) {
	parsed, err := Load("testdata/", "model_single_with_inlined_model.json", true)
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
		t.Fatalf("expected 0 constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	example, ok := resource.Models["Example"]
	if !ok {
		t.Fatalf("the Model `Example` was not found")
	}
	if len(example.Fields) != 2 {
		t.Fatalf("expected example.Fields to have 2 fields but got %d", len(example.Fields))
	}

	exampleProperties, ok := resource.Models["ExampleProperties"]
	if !ok {
		t.Fatalf("the Model `ExampleProperties` was not found")
	}
	if len(exampleProperties.Fields) != 4 {
		t.Fatalf("expected exampleProperties.Fields to have 4 fields but got %d", len(example.Fields))
	}

	nickName, ok := exampleProperties.Fields["Nickname"]
	if !ok {
		t.Fatalf("exampleProperties.Fields['Nickname'] was missing")
	}
	if nickName.Type != models.String {
		t.Fatalf("expected exampleProperties.Fields['Nickname'] to be a string but got %q", string(nickName.Type))
	}
	if nickName.JsonName != "nickname" {
		t.Fatalf("expected exampleProperties.Fields['Nickname'].JsonName to be 'name' but got %q", nickName.JsonName)
	}

	age, ok := exampleProperties.Fields["Age"]
	if !ok {
		t.Fatalf("exampleProperties.Fields['Age'] was missing")
	}
	if age.Type != models.Integer {
		t.Fatalf("expected exampleProperties.Fields['Age'] to be an integer but got %q", string(age.Type))
	}
	if age.JsonName != "age" {
		t.Fatalf("expected exampleProperties.Fields['Age'].JsonName to be 'age' but got %q", age.JsonName)
	}

	enabled, ok := exampleProperties.Fields["Enabled"]
	if !ok {
		t.Fatalf("exampleProperties.Fields['Enabled'] was missing")
	}
	if enabled.Type != models.Boolean {
		t.Fatalf("expected exampleProperties.Fields['Enabled'] to be a boolean but got %q", string(enabled.Type))
	}
	if enabled.JsonName != "enabled" {
		t.Fatalf("expected exampleProperties.Fields['Enabled'].JsonName to be 'enabled' but got %q", enabled.JsonName)
	}

	tags, ok := exampleProperties.Fields["Tags"]
	if !ok {
		t.Fatalf("exampleProperties.Fields['Tags'] was missing")
	}
	if tags.Type != models.Tags {
		t.Fatalf("expected exampleProperties.Fields['Tags'] to be Tags but got %q", string(tags.Type))
	}
	if tags.JsonName != "tags" {
		t.Fatalf("expected exampleProperties.Fields['Tags'].JsonName to be 'tags' but got %q", tags.JsonName)
	}
}

func TestParseModelMultipleTopLevel(t *testing.T) {
	parsed, err := Load("testdata/", "model_multiple.json", true)
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
		t.Fatalf("expected 0 constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 2 {
		t.Fatalf("expected 2 operations but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	var validateModel = func(t *testing.T, input models.ModelDetails) {
		if len(input.Fields) != 4 {
			t.Fatalf("expected input.Fields to have 4 fields but got %d", len(input.Fields))
		}

		name, ok := input.Fields["Name"]
		if !ok {
			t.Fatalf("input.Fields['Name'] was missing")
		}
		if name.Type != models.String {
			t.Fatalf("expected input.Fields['Name'] to be a string but got %q", string(name.Type))
		}
		if name.JsonName != "name" {
			t.Fatalf("expected input.Fields['Name'].JsonName to be 'name' but got %q", name.JsonName)
		}

		age, ok := input.Fields["Age"]
		if !ok {
			t.Fatalf("input.Fields['Age'] was missing")
		}
		if age.Type != models.Integer {
			t.Fatalf("expected input.Fields['Age'] to be an integer but got %q", string(age.Type))
		}
		if age.JsonName != "age" {
			t.Fatalf("expected input.Fields['Age'].JsonName to be 'age' but got %q", age.JsonName)
		}

		enabled, ok := input.Fields["Enabled"]
		if !ok {
			t.Fatalf("input.Fields['Enabled'] was missing")
		}
		if enabled.Type != models.Boolean {
			t.Fatalf("expected input.Fields['Enabled'] to be a boolean but got %q", string(enabled.Type))
		}
		if enabled.JsonName != "enabled" {
			t.Fatalf("expected input.Fields['Enabled'].JsonName to be 'enabled' but got %q", enabled.JsonName)
		}

		tags, ok := input.Fields["Tags"]
		if !ok {
			t.Fatalf("input.Fields['Tags'] was missing")
		}
		if tags.Type != models.Tags {
			t.Fatalf("expected input.Fields['Tags'] to be Tags but got %q", string(tags.Type))
		}
		if tags.JsonName != "tags" {
			t.Fatalf("expected input.Fields['Tags'].JsonName to be 'tags' but got %q", tags.JsonName)
		}
	}

	t.Log("Testing GetExample..")
	getExample, ok := resource.Models["GetExample"]
	if !ok {
		t.Fatalf("the Model `GetExample` was not found")
	}
	validateModel(t, getExample)

	t.Log("Testing PutExample..")
	putExample, ok := resource.Models["PutExample"]
	if !ok {
		t.Fatalf("the Model `PutExample` was not found")
	}
	validateModel(t, putExample)
}

func TestParseModelMultipleTopLevelWithList(t *testing.T) {
	parsed, err := Load("testdata/", "model_multiple_list.json", true)
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
		t.Fatalf("expected 0 constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	person, ok := resource.Models["Person"]
	if !ok {
		t.Fatalf("the Model `Person` was not found")
	}
	if len(person.Fields) != 2 {
		t.Fatalf("expected person.Fields to have 2 fields but got %d", len(person.Fields))
	}

	personName, ok := person.Fields["Name"]
	if !ok {
		t.Fatalf("person.Fields['Name'] was missing")
	}
	if personName.Type != models.String {
		t.Fatalf("expected person.Fields['Name'] to be a string but got %q", string(personName.Type))
	}
	if personName.JsonName != "name" {
		t.Fatalf("expected person.Fields['Name'].JsonName to be 'name' but got %q", personName.JsonName)
	}
	animals, ok := person.Fields["Animals"]
	if animals.Type != models.String {
		t.Fatalf("expected person.Fields['Animals'] to be a List but got %q", string(animals.Type))
	}
	if animals.ModelReference == nil {
		t.Fatalf("person.Fields['Animals'].ModelReference was nil")
	}
	if *animals.ModelReference != "Animal" {
		t.Fatalf("person.Fields['Animals'].ModelReference should be 'Animal' but was %q", *animals.ModelReference)
	}
	if animals.JsonName != "animals" {
		t.Fatalf("expected person.Fields['Animals'].JsonName to be 'animals' but got %q", animals.JsonName)
	}

	animalModel, ok := resource.Models["Animal"]
	if !ok {
		t.Fatal("expected resource.Models['Animal'] was not found")
	}
	if len(animalModel.Fields) != 2 {
		t.Fatalf("expected resource.Models['Animal'].Fields to have 2 items but got %d", len(animalModel.Fields))
	}

	animalName, ok := animalModel.Fields["Name"]
	if !ok {
		t.Fatalf("animalModel.Fields['Name'] was missing")
	}
	if animalName.Type != models.String {
		t.Fatalf("expected animalModel.Fields['Name'] to be a string but got %q", string(animalName.Type))
	}
	if animalName.JsonName != "name" {
		t.Fatalf("expected animalModel.Fields['Name'].JsonName to be 'name' but got %q", animalName.JsonName)
	}

	animalAge, ok := animalModel.Fields["Age"]
	if !ok {
		t.Fatalf("animalModel.Fields['Age'] was missing")
	}
	if animalAge.Type != models.Integer {
		t.Fatalf("expected animalModel.Fields['Age'] to be a string but got %q", string(animalAge.Type))
	}
	if animalAge.JsonName != "age" {
		t.Fatalf("expected animalModel.Fields['Age'].JsonName to be 'age' but got %q", animalAge.JsonName)
	}
}
