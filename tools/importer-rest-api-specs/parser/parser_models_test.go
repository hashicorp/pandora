package parser

import (
	"reflect"
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
	if len(example.Fields) != 5 {
		t.Fatalf("expected example.Fields to have 5 fields but got %d", len(example.Fields))
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

	height, ok := example.Fields["Height"]
	if !ok {
		t.Fatalf("example.Fields['Height'] was missing")
	}
	if height.Type != models.Float {
		t.Fatalf("expected example.Fields['Height'] to be a float but got %q", string(height.Type))
	}
	if height.JsonName != "height" {
		t.Fatalf("expected example.Fields['Height'].JsonName to be 'height' but got %q", height.JsonName)
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

func TestParseModelSingleWithInlinedObject(t *testing.T) {
	t.Skip("skipping temporarily since broken - see https://github.com/hashicorp/pandora/issues/109")

	parsed, err := Load("testdata/", "model_with_inlined_object.json", true)
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

	hello, ok := result.Resources["Hello"]
	if !ok {
		t.Fatalf("no resources were output with the tag Hello")
	}

	if len(hello.Constants) != 0 {
		t.Fatalf("expected no Constants but got %d", len(hello.Constants))
	}
	if len(hello.Models) != 3 {
		t.Fatalf("expected 3 Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GetWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name GetWorld")
	}
	if world.Method != "GET" {
		t.Fatalf("expected a GET operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObjectName != nil {
		t.Fatalf("expected no request object but got %q", *world.RequestObjectName)
	}
	if world.ResponseObjectName == nil {
		t.Fatal("expected a response object but didn't get one")
	}
	if *world.ResponseObjectName != "Example" {
		t.Fatalf("expected the response object to be 'Example' but got %q", *world.ResponseObjectName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/things" {
		t.Fatalf("expected world.UriSuffix to be `/things` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}

	exampleModel, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model called Example")
	}
	if len(exampleModel.Fields) != 2 {
		t.Fatalf("expected the model Example to have 2 fields but got %d", len(exampleModel.Fields))
	}
	thingField, ok := exampleModel.Fields["ThingProps"]
	if !ok {
		t.Fatalf("expected the model Example to have a field ThingProps")
	}
	if thingField.Type != models.List {
		t.Fatalf("expected ThingProps to be a List but got %q", string(thingField.Type))
	}
	if thingField.ModelReference == nil {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was nil")
	}
	if *thingField.ModelReference != "ThingProperties" {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was %q", *thingField.ModelReference)
	}

	thingModel, ok := hello.Models["ThingProperties"]
	if !ok {
		t.Fatalf("expected there to be a model called ThingProperties")
	}
	if len(thingModel.Fields) != 2 {
		t.Fatalf("expected ThingProperties to have 2 fields")
	}
	uaiField, ok := thingModel.Fields["UserAssignedIdentities"]
	if !ok {
		t.Fatalf("expected the model ThingProperties to have the field UserAssignedIdentities")
	}
	if uaiField.Type != models.Object {
		t.Fatalf("expected the model ThingProperties field UserAssignedIdentities to be an Object but it was %q", string(uaiField.Type))
	}
	if uaiField.ModelReference == nil {
		t.Fatalf("expected the model ThingProperties field UserAssignedIdentities to have a model reference but it was nil")
	}
	if *uaiField.ModelReference != "UserAssignedIdentities" {
		t.Fatalf("expected the model ThingProperties field UserAssignedIdentities model reference to be `UserAssignedIdentities` but it was %q", *uaiField.ModelReference)
	}

	uaiModel, ok := hello.Models["UserAssignedIdentities"]
	if !ok {
		t.Fatalf("expected there to be a model called UserAssignedIdentities")
	}
	if len(uaiModel.Fields) != 2 {
		t.Fatalf("expected the model UserAssignedIdentities to have 2 fields but got %d", len(uaiModel.Fields))
	}
	if _, ok := uaiModel.Fields["PrincipalId"]; !ok {
		t.Fatalf("expected the model UserAssignedIdentities to have a field 'PrincipalId' but it didn't")
	}
	if _, ok := uaiModel.Fields["ClientId"]; !ok {
		t.Fatalf("expected the model UserAssignedIdentities to have a field 'ClientId' but it didn't")
	}
}

func TestParseModelSingleWithReference(t *testing.T) {
	parsed, err := Load("testdata/", "model_single_with_reference.json", true)
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

	hello, ok := result.Resources["Hello"]
	if !ok {
		t.Fatalf("no resources were output with the tag Hello")
	}

	if len(hello.Constants) != 0 {
		t.Fatalf("expected no Constants but got %d", len(hello.Constants))
	}
	if len(hello.Models) != 3 {
		t.Fatalf("expected 3 Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GetWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name GetWorld")
	}
	if world.Method != "GET" {
		t.Fatalf("expected a GET operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObjectName != nil {
		t.Fatalf("expected no request object but got %q", *world.RequestObjectName)
	}
	if world.ResponseObjectName == nil {
		t.Fatal("expected a response object but didn't get one")
	}
	if *world.ResponseObjectName != "Example" {
		t.Fatalf("expected the response object to be 'Example' but got %q", *world.ResponseObjectName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/things" {
		t.Fatalf("expected world.UriSuffix to be `/things` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}

	exampleModel, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model called Example")
	}
	if len(exampleModel.Fields) != 2 {
		t.Fatalf("expected the model Example to have 2 fields but got %d", len(exampleModel.Fields))
	}
	thingField, ok := exampleModel.Fields["ThingProps"]
	if !ok {
		t.Fatalf("expected the model Example to have a field ThingProps")
	}
	if thingField.Type != models.List {
		t.Fatalf("expected ThingProps to be a List but got %q", string(thingField.Type))
	}
	if thingField.ModelReference == nil {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was nil")
	}
	if *thingField.ModelReference != "ThingProperties" {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was %q", *thingField.ModelReference)
	}

	thingModel, ok := hello.Models["ThingProperties"]
	if !ok {
		t.Fatalf("expected there to be a model called ThingProperties")
	}
	if len(thingModel.Fields) != 2 {
		t.Fatalf("expected ThingProperties to have 2 fields")
	}
	identityField, ok := thingModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected the model ThingProperties to have the field Identity")
	}
	if identityField.Type != models.Object {
		t.Fatalf("expected the model ThingProperties field Identity to be an Object but it was %q", string(identityField.Type))
	}
	if identityField.ModelReference == nil {
		t.Fatalf("expected the model ThingProperties field Identity to have a model reference but it was nil")
	}
	if *identityField.ModelReference != "UserAssignedIdentityProperties" {
		t.Fatalf("expected the model ThingProperties field Identity's model reference to be `UserAssignedIdentityProperties` but it was %q", *identityField.ModelReference)
	}

	uaiModel, ok := hello.Models["UserAssignedIdentityProperties"]
	if !ok {
		t.Fatalf("expected there to be a model called UserAssignedIdentityProperties")
	}
	if len(uaiModel.Fields) != 1 {
		t.Fatalf("expected the model UserAssignedIdentityProperties to have 1 field but got %d", len(uaiModel.Fields))
	}
}

func TestParseModelSingleWithReferenceToArray(t *testing.T) {
	t.Skip("Skipping until https://github.com/hashicorp/pandora/issues/99 is implemented")

	parsed, err := Load("testdata/", "model_single_with_reference_array.json", true)
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

	hello, ok := result.Resources["Hello"]
	if !ok {
		t.Fatalf("no resources were output with the tag Hello")
	}

	if len(hello.Constants) != 0 {
		t.Fatalf("expected no Constants but got %d", len(hello.Constants))
	}
	if len(hello.Models) != 2 {
		t.Fatalf("expected 2 Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GetWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name GetWorld")
	}
	if world.Method != "GET" {
		t.Fatalf("expected a GET operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObjectName != nil {
		t.Fatalf("expected no request object but got %q", *world.RequestObjectName)
	}
	if world.ResponseObjectName == nil {
		t.Fatal("expected a response object but didn't get one")
	}
	if *world.ResponseObjectName != "Example" {
		t.Fatalf("expected the response object to be 'Example' but got %q", *world.ResponseObjectName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/things" {
		t.Fatalf("expected world.UriSuffix to be `/things` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}

	exampleModel, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model called Example")
	}
	if len(exampleModel.Fields) != 2 {
		t.Fatalf("expected the model Example to have 2 fields but got %d", len(exampleModel.Fields))
	}
	petsField, ok := exampleModel.Fields["Pets"]
	if !ok {
		t.Fatalf("expected the model Example to have a field Pets")
	}
	if petsField.Type != models.List {
		t.Fatalf("expected Pets to be a List but got %q", string(petsField.Type))
	}
	if petsField.ModelReference == nil {
		t.Fatalf("expected Pets to be a reference to Pet but it was nil")
	}
	if *petsField.ModelReference != "Pet" {
		t.Fatalf("expected ThingProps to be a reference to Pet but it was %q", *petsField.ModelReference)
	}

	petModel, ok := hello.Models["Pet"]
	if !ok {
		t.Fatalf("expected there to be a model called Pet")
	}
	if len(petModel.Fields) != 1 {
		t.Fatalf("expected Pet to have 1 fields")
	}
	nameField, ok := petModel.Fields["Name"]
	if !ok {
		t.Fatalf("expected the model Pet to have the field Name")
	}
	if nameField.Type != models.String {
		t.Fatalf("expected the model Pet field Name to be a String but it was %q", string(nameField.Type))
	}
	if nameField.ModelReference != nil {
		t.Fatalf("expected the model Pet field Name to have no model reference but it was %q", *nameField.ModelReference)
	}
}

func TestParseModelSingleWithReferenceToConstant(t *testing.T) {
	t.Skip("Skipping until https://github.com/hashicorp/pandora/issues/99 is implemented")

	parsed, err := Load("testdata/", "model_single_with_reference_constant.json", true)
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

	hello, ok := result.Resources["Hello"]
	if !ok {
		t.Fatalf("no resources were output with the tag Hello")
	}

	if len(hello.Constants) != 1 {
		t.Fatalf("expected 1 Constant but got %d", len(hello.Constants))
	}
	if len(hello.Models) != 2 {
		t.Fatalf("expected 2 Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GetWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name GetWorld")
	}
	if world.Method != "GET" {
		t.Fatalf("expected a GET operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObjectName != nil {
		t.Fatalf("expected no request object but got %q", *world.RequestObjectName)
	}
	if world.ResponseObjectName == nil {
		t.Fatal("expected a response object but didn't get one")
	}
	if *world.ResponseObjectName != "Example" {
		t.Fatalf("expected the response object to be 'Example' but got %q", *world.ResponseObjectName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/things" {
		t.Fatalf("expected world.UriSuffix to be `/things` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}

	exampleModel, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model called Example")
	}
	if len(exampleModel.Fields) != 2 {
		t.Fatalf("expected the model Example to have 2 fields but got %d", len(exampleModel.Fields))
	}
	thingField, ok := exampleModel.Fields["ThingProps"]
	if !ok {
		t.Fatalf("expected the model Example to have a field ThingProps")
	}
	if thingField.Type != models.List {
		t.Fatalf("expected ThingProps to be a List but got %q", string(thingField.Type))
	}
	if thingField.ModelReference == nil {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was nil")
	}
	if *thingField.ModelReference != "ThingProperties" {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was %q", *thingField.ModelReference)
	}

	thingModel, ok := hello.Models["ThingProperties"]
	if !ok {
		t.Fatalf("expected there to be a model called ThingProperties")
	}
	if len(thingModel.Fields) != 2 {
		t.Fatalf("expected ThingProperties to have 2 fields")
	}
	animalField, ok := thingModel.Fields["Animal"]
	if !ok {
		t.Fatalf("expected the model ThingProperties to have the field Animal")
	}
	if animalField.Type != models.Object {
		t.Fatalf("expected the model ThingProperties field Animal to be an Object but it was %q", string(animalField.Type))
	}
	if *animalField.ConstantReference != "AnimalType" {
		t.Fatalf("expected the model ThingProperties field Animal to have a constant reference but it was %q", *animalField.ConstantReference)
	}
	if animalField.ModelReference != nil {
		t.Fatalf("expected the model ThingProperties field Animal to have no model reference but it was %q", *animalField.ModelReference)
	}

	animalConstant, ok := hello.Constants["AnimalType"]
	if !ok {
		t.Fatalf("expected there to be a constant called AnimalType")
	}
	if len(animalConstant.Values) != 2 {
		t.Fatalf("expected the constant AnimalType to have 2 values but got %d", len(animalConstant.Values))
	}
}

func TestParseModelSingleWithReferenceToString(t *testing.T) {
	t.Skip("Skipping until https://github.com/hashicorp/pandora/issues/99 is implemented")

	parsed, err := Load("testdata/", "model_single_with_reference_string.json", true)
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

	hello, ok := result.Resources["Hello"]
	if !ok {
		t.Fatalf("no resources were output with the tag Hello")
	}

	if len(hello.Constants) != 0 {
		t.Fatalf("expected no Constants but got %d", len(hello.Constants))
	}
	if len(hello.Models) != 2 {
		t.Fatalf("expected 2 Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GetWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name GetWorld")
	}
	if world.Method != "GET" {
		t.Fatalf("expected a GET operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObjectName != nil {
		t.Fatalf("expected no request object but got %q", *world.RequestObjectName)
	}
	if world.ResponseObjectName == nil {
		t.Fatal("expected a response object but didn't get one")
	}
	if *world.ResponseObjectName != "Example" {
		t.Fatalf("expected the response object to be 'Example' but got %q", *world.ResponseObjectName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/things" {
		t.Fatalf("expected world.UriSuffix to be `/things` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}

	exampleModel, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model called Example")
	}
	if len(exampleModel.Fields) != 2 {
		t.Fatalf("expected the model Example to have 2 fields but got %d", len(exampleModel.Fields))
	}
	thingField, ok := exampleModel.Fields["ThingProps"]
	if !ok {
		t.Fatalf("expected the model Example to have a field ThingProps")
	}
	if thingField.Type != models.List {
		t.Fatalf("expected ThingProps to be a List but got %q", string(thingField.Type))
	}
	if thingField.ModelReference == nil {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was nil")
	}
	if *thingField.ModelReference != "ThingProperties" {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was %q", *thingField.ModelReference)
	}

	thingModel, ok := hello.Models["ThingProperties"]
	if !ok {
		t.Fatalf("expected there to be a model called ThingProperties")
	}
	if len(thingModel.Fields) != 2 {
		t.Fatalf("expected ThingProperties to have 2 fields")
	}
	fqdnField, ok := thingModel.Fields["FullyQualifiedDomainName"]
	if !ok {
		t.Fatalf("expected the model ThingProperties to have the field FullyQualifiedDomainName")
	}
	if fqdnField.Type != models.String {
		t.Fatalf("expected the model ThingProperties field FullyQualifiedDomainName to be a String but it was %q", string(fqdnField.Type))
	}
	if fqdnField.ModelReference != nil {
		t.Fatalf("expected the model ThingProperties field FullyQualifiedDomainName to have no model reference but it was %q", *fqdnField.ModelReference)
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
	if len(person.Fields) != 3 {
		t.Fatalf("expected person.Fields to have 3 fields but got %d", len(person.Fields))
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
	if !ok {
		t.Fatalf("person.Fields['Animals'] was missing")
	}
	if animals.Type != models.List {
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
	if animals.ListElementMin != nil {
		t.Fatalf("expected person.Fields['Animals'].ListElementMin to be nil but got %v", *animals.ListElementMin)
	}
	if animals.ListElementMax != nil {
		t.Fatalf("expected person.Fields['Animals'].ListElementMax to be nil but got %v", *animals.ListElementMax)
	}
	if animals.ListElementUnique == nil || *animals.ListElementUnique {
		t.Fatalf("expected person.Fields['Animals'].ListElementUnique to be false but got %v", fieldValueOrNil(animals, "ListElementUnique"))
	}

	plants, ok := person.Fields["Plants"]
	if !ok {
		t.Fatalf("person.Fields['Plants'] was missing")
	}
	if plants.ListElementMin == nil || *plants.ListElementMin != 1 {
		t.Fatalf("expected person.Fields['Plants'].ListElementMin to be 1 but got %v", fieldValueOrNil(plants, "ListElementMin"))
	}
	if plants.ListElementMax == nil || *plants.ListElementMax != 10 {
		t.Fatalf("expected person.Fields['Plants'].ListElementMax to be 10 but got %v", fieldValueOrNil(plants, "ListElementMax"))
	}
	if plants.ListElementUnique == nil || !*plants.ListElementUnique {
		t.Fatalf("expected person.Fields['Plants'].ListElementUnique to be true but got %v", fieldValueOrNil(plants, "ListElementUnique"))
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
	if animalName.ListElementMin != nil {
		t.Fatalf("expected person.Fields['Name'].ListElementMin to be nil but got %v", *animalName.ListElementMin)
	}
	if animalName.ListElementMax != nil {
		t.Fatalf("expected person.Fields['Name'].ListElementMax to be nil but got %v", *animalName.ListElementMax)
	}
	if animalName.ListElementUnique != nil {
		t.Fatalf("expected person.Fields['Name'].ListElementUnique to be nil but got %v", *animalName.ListElementUnique)
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

func TestParseModelMultipleTopLevelInheritance(t *testing.T) {
	parsed, err := Load("testdata/", "model_multiple_inheritance.json", true)
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
	if len(example.Fields) != 5 {
		t.Fatalf("expected example.Fields to have 5 fields but got %d", len(example.Fields))
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
	if !name.Required {
		t.Fatalf("expected example.Fields['Name'].Required to be 'true'")
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
	if age.Required {
		t.Fatalf("expected example.Fields['Age'].Required to be 'false'")
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
	if !enabled.Required {
		t.Fatalf("expected example.Fields['Enabled'].Required to be 'true'")
	}

	height, ok := example.Fields["Height"]
	if !ok {
		t.Fatalf("example.Fields['Height'] was missing")
	}
	if height.Type != models.Float {
		t.Fatalf("expected example.Fields['Height'] to be a float but got %q", string(height.Type))
	}
	if height.JsonName != "height" {
		t.Fatalf("expected example.Fields['Height'].JsonName to be 'height' but got %q", height.JsonName)
	}
	if height.Required {
		t.Fatalf("expected example.Fields['Height'].Required to be 'false'")
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
	if !tags.Required {
		t.Fatalf("expected example.Fields['Tags'].Required to be 'true'")
	}
}

func TestParseModelAdditionalProperties(t *testing.T) {
	parsed, err := Load("testdata/", "model_additional_properties.json", true)
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

	resource, ok := result.Resources["Foo"]
	if !ok {
		t.Fatal("the Resource 'Foo' was not found")
	}

	// Check for model Foo and its fields
	foo, ok := resource.Models["Foo"]
	if !ok {
		t.Fatal("the Model `Foo` is was not found")
	}

	// Check for model Foo, field: DictOfStringInline
	dictOfStringInlineField, ok := foo.Fields["DictOfStringInline"]
	if !ok {
		t.Fatalf("the Foo.DictOfStringInline was nil")
	}
	if dictOfStringInlineField.Type != models.Dictionary {
		t.Fatalf("expect Foo.DictOfStringInline to be a dictionary, but got %q", string(dictOfStringInlineField.Type))
	}
	if dictOfStringInlineField.DictValueType == nil {
		t.Fatalf("expect value of Foo.DictOfStringInline to be string, but got nil")
	}
	if *dictOfStringInlineField.DictValueType != models.String {
		t.Fatalf("expect value of Foo.DictOfStringInline to be string, but got %q", string(*dictOfStringInlineField.DictValueType))
	}

	// Check for model Foo, field: DictOfObjectInline
	dictOfObjectInlineField, ok := foo.Fields["DictOfObjectInline"]
	if !ok {
		t.Fatalf("the Foo.DictOfObjectInline was nil")
	}
	if dictOfObjectInlineField.Type != models.Dictionary {
		t.Fatalf("expect Foo.DictOfObjectInline to be a dictionary, but got %q", string(dictOfObjectInlineField.Type))
	}
	if dictOfObjectInlineField.DictValueType == nil {
		t.Fatalf("expect value of Foo.DictOfObjectInline to be object, but got nil")
	}
	if *dictOfObjectInlineField.DictValueType != models.Object {
		t.Fatalf("expect value of Foo.DictOfObjectInline to be object, but got %q", string(*dictOfObjectInlineField.DictValueType))
	}
	if dictOfObjectInlineField.ModelReference == nil {
		t.Fatalf("Foo.DictOfObjectInline has no model reference")
	}
	// Check for the pulled out model for the Foo.DictOfObjectInline
	fooDictOfObjectInline, ok := resource.Models[*dictOfObjectInlineField.ModelReference]
	if !ok {
		t.Fatalf("FooDictOfObjectInline was not found")
	}
	fooDictOfObjectInlineP1, ok := fooDictOfObjectInline.Fields["P1"]
	if !ok {
		t.Fatalf("FooDictOfObjectInline.P1 was not found")
	}
	if fooDictOfObjectInlineP1.Type != models.String {
		t.Fatalf("expect FooDictOfObjectInline.P1 to be a string, but got %q", string(fooDictOfObjectInlineP1.Type))
	}

	// Check for model Foo, field: DictOfObjectRefInline
	dictOfObjectRefInline, ok := foo.Fields["DictOfObjectRefInline"]
	if !ok {
		t.Fatalf("the Foo.DictOfObjectRefInline was nil")
	}
	if dictOfObjectRefInline.Type != models.Dictionary {
		t.Fatalf("expect Foo.DictOfObjectRefInline to be a dictionary, but got %q", string(dictOfObjectRefInline.Type))
	}
	if dictOfObjectRefInline.DictValueType == nil {
		t.Fatalf("expect value of Foo.DictOfObjectRefInline to be object, but got nil")
	}
	if *dictOfObjectRefInline.DictValueType != models.Object {
		t.Fatalf("expect value of Foo.DictOfObjectRefInline to be object, but got %q", string(*dictOfObjectRefInline.DictValueType))
	}
	if dictOfObjectRefInline.ModelReference == nil {
		t.Fatalf("Foo.DictOfObjectRefInline has no model reference")
	}
	// Check of the pulled out model for the Foo.DictOfObjectRefInline
	// This is tested in later steps.

	// Check for model Foo, field: ObjectWithAdditionalPropertiesInline
	objectWithAdditionalPropertiesInline, ok := foo.Fields["ObjectWithAdditionalPropertiesInline"]
	if !ok {
		t.Fatalf("the Foo.ObjectWithAdditionalPropertiesInline was nil")
	}
	if objectWithAdditionalPropertiesInline.Type != models.Object {
		t.Fatalf("expect Foo.ObjectWithAdditionalPropertiesInline to be a object, but got %q", string(objectWithAdditionalPropertiesInline.Type))
	}
	if objectWithAdditionalPropertiesInline.ModelReference == nil {
		t.Fatalf("Foo.ObjectWithAdditionalPropertiesInline has no model reference")
	}
	// Check for the pulled out model for the Foo.ObjectWithAdditionalPropertiesInline
	fooObjectWithAdditionalPropertiesInline, ok := resource.Models["FooObjectWithAdditionalPropertiesInline"]
	if !ok {
		t.Fatalf("model FooObjectWithAdditionalPropertiesInline was not found")
	}
	if len(fooObjectWithAdditionalPropertiesInline.Fields) != 1 {
		t.Fatalf("expect FooObjectWithAdditionalPropertiesInline has one field, but got %d", len(fooObjectWithAdditionalPropertiesInline.Fields))
	}
	fooObjectWithAdditionalPropertiesInlineP1, ok := fooObjectWithAdditionalPropertiesInline.Fields["P1"]
	if !ok {
		t.Fatalf(`FooObjectWithAdditionalPropertiesInline.Fields["P1"] not found`)
	}
	if fooObjectWithAdditionalPropertiesInlineP1.Type != models.String {
		t.Fatalf(`expect FooObjectWithAdditionalPropertiesInline.Fields["P1"] to be a string, but got %q`, string(fooObjectWithAdditionalPropertiesInlineP1.Type))
	}
	if fooObjectWithAdditionalPropertiesInline.AdditionalProperties == nil {
		t.Fatalf("FooObjectWithAdditionalPropertiesInline.AdditionalProperties was nil")
	}
	fooObjectWithAdditionalPropertiesInlineAdditionalProperties := *fooObjectWithAdditionalPropertiesInline.AdditionalProperties
	if fooObjectWithAdditionalPropertiesInlineAdditionalProperties.Type != models.Dictionary {
		t.Fatalf("expect FooObjectWithAdditionalPropertiesInline.AdditionalProperties to be a dictionary, but got %q", string(fooObjectWithAdditionalPropertiesInlineAdditionalProperties.Type))
	}
	if fooObjectWithAdditionalPropertiesInlineAdditionalProperties.DictValueType == nil {
		t.Fatalf("expect value FooObjectWithAdditionalPropertiesInline.AdditionalProperties to be an object, but got nil")
	}
	if *fooObjectWithAdditionalPropertiesInlineAdditionalProperties.DictValueType != models.Object {
		t.Fatalf("expect value FooObjectWithAdditionalPropertiesInline.AdditionalProperties to be an object, but got %q", string(*fooObjectWithAdditionalPropertiesInlineAdditionalProperties.DictValueType))
	}
	// Check for the pulled out model for the value of Foo.ObjectWithAdditionalPropertiesInline.AdditionalProperties
	fooObjectWithAdditionalPropertiesInlineAdditionalPropertiesValue, ok := resource.Models["FooObjectWithAdditionalPropertiesInlineAdditionalProperties"]
	if !ok {
		t.Fatalf("model FooObjectWithAdditionalPropertiesInlineAdditionalProperties was not found")
	}
	if len(fooObjectWithAdditionalPropertiesInlineAdditionalPropertiesValue.Fields) != 1 {
		t.Fatalf("expect FooObjectWithAdditionalPropertiesInlineAdditionalProperties has one field, but got %d", len(fooObjectWithAdditionalPropertiesInlineAdditionalPropertiesValue.Fields))
	}
	fooObjectWithAdditionalPropertiesInlineAdditionalPropertiesValueP2, ok := fooObjectWithAdditionalPropertiesInlineAdditionalPropertiesValue.Fields["P2"]
	if !ok {
		t.Fatalf(`FooObjectWithAdditionalPropertiesInlineAdditionalProperties["P2"] not found`)
	}
	if fooObjectWithAdditionalPropertiesInlineAdditionalPropertiesValueP2.Type != models.String {
		t.Fatalf(`expect FooObjectWithAdditionalPropertiesInlineAdditionalProperties["P2"] to be a string, but got %q`,string(fooObjectWithAdditionalPropertiesInlineAdditionalPropertiesValueP2.Type))
	}

	// Check for absent models
	if _, ok := resource.Models["Absent"]; ok {
		t.Fatalf("the Model `Absent` is expected to be removed (as it has no fields), but it exists")
	}

	if _, ok := resource.Models["False"]; ok {
		t.Fatalf("the Model `False` is expected to be removed (as it has no fields), but it exists")
	}

	// Check for model DictOfAny
	dictOfAny, ok := resource.Models["DictOfAny"]
	if !ok {
		t.Fatalf("the Model `DictOfAny` was not found")
	}
	dictOfAnyField := dictOfAny.AdditionalProperties
	if dictOfAnyField == nil {
		t.Fatalf("dictOfAny.AdditionalProperties was nil")
	}
	if dictOfAnyField.Type != models.Dictionary {
		t.Fatalf("expected dictOfAny.AdditionalProperties to be a dict but got %q", string(dictOfAnyField.Type))
	}
	if dictOfAnyField.DictValueType == nil {
		t.Fatalf("expected value of dictOfAny.AdditionalProperties to be a object but got nil")
	}
	if *dictOfAnyField.DictValueType != models.Object {
		t.Fatalf("expected value of dictOfAny.AdditionalProperties to be a object but got %q", string(*dictOfAnyField.DictValueType))
	}

	// Check for model DictOfAny2
	dictOfAny2, ok := resource.Models["DictOfAny2"]
	if !ok {
		t.Fatalf("the Model `DictOfAny2` was not found")
	}
	dictOfAny2Field := dictOfAny2.AdditionalProperties
	if dictOfAnyField == nil {
		t.Fatalf("dictOfAny2.AdditionalProperties was nil")
	}
	if dictOfAny2Field.Type != models.Dictionary {
		t.Fatalf("expected dictOfAny2.AdditionalProperties to be a dict but got %q", string(dictOfAny2Field.Type))
	}
	if dictOfAny2Field.DictValueType == nil {
		t.Fatalf("expected value of dictOfAny2.AdditionalProperties to be a object but got nil")
	}
	if *dictOfAny2Field.DictValueType != models.Object {
		t.Fatalf("expected value of dictOfAny2.AdditionalProperties to be a object but got %q", string(*dictOfAny2Field.DictValueType))
	}

	// Check for model DictOfString
	dictOfString, ok := resource.Models["DictOfString"]
	if !ok {
		t.Fatalf("the Model `DictOfString` was not found")
	}
	dictOfStringField := dictOfString.AdditionalProperties
	if dictOfStringField == nil {
		t.Fatalf("dictOfString.AdditionalProperties was nil")
	}
	if dictOfStringField.Type != models.Dictionary {
		t.Fatalf("expected dictOfString.AdditionalProperties to be a dict but got %q", string(dictOfStringField.Type))
	}
	if dictOfStringField.DictValueType == nil {
		t.Fatalf("expected value of dictOfString.AdditionalProperties to be a string but got nil")
	}
	if *dictOfStringField.DictValueType != models.String {
		t.Fatalf("expected value of dictOfString.AdditionalProperties to be a string but got %q", string(*dictOfStringField.DictValueType))
	}

	// Check for model DictOfArrayOfString
	dictOfArrayOfString, ok := resource.Models["DictOfArrayOfString"]
	if !ok {
		t.Fatalf("the Model `DictOfArrayOfString` was not found")
	}
	dictOfArrayOfStringField := dictOfArrayOfString.AdditionalProperties
	if dictOfArrayOfStringField == nil {
		t.Fatalf("dictOfArrayOfString.AdditionalProperties was nil")
	}
	if dictOfArrayOfStringField.Type != models.Dictionary {
		t.Fatalf("expected dictOfArrayOfString.AdditionalProperties to be a dict but got %q", string(dictOfArrayOfStringField.Type))
	}
	if dictOfArrayOfStringField.DictValueType == nil {
		t.Fatalf("expected value of dictOfArrayOfString.AdditionalProperties to be an array but got nil")
	}
	if *dictOfArrayOfStringField.DictValueType != models.List {
		t.Fatalf("expected value of dictOfArrayOfString.AdditionalProperties to be an array but got %q", string(*dictOfArrayOfStringField.DictValueType))
	}
	if dictOfArrayOfStringField.ListElementType == nil {
		t.Fatalf("expected element of value of dictOfArrayOfString.AdditionalProperties to be string but got nil")
	}
	if *dictOfArrayOfStringField.ListElementType != models.String {
		t.Fatalf("expected element of value of dictOfArrayOfString.AdditionalProperties to be string but got %q", string(*dictOfArrayOfStringField.ListElementType))
	}

	// Check for model DictOfInlinedObject
	dictOfInlinedObject, ok := resource.Models["DictOfInlinedObject"]
	if !ok {
		t.Fatalf("the Model `DictOfInlinedObject` was not found")
	}
	dictOfInlinedObjectField := dictOfInlinedObject.AdditionalProperties
	if dictOfInlinedObjectField == nil {
		t.Fatalf("dictOfInlinedObject.AdditionalProperties was nil")
	}
	if dictOfInlinedObjectField.Type != models.Dictionary {
		t.Fatalf("expected dictOfInlinedObject.AdditionalProperties to be a dict but got %q", string(dictOfInlinedObjectField.Type))
	}
	if dictOfInlinedObjectField.DictValueType == nil {
		t.Fatalf("expected value of dictOfInlinedObject.AdditionalProperties to be a object but got nil")
	}
	if *dictOfInlinedObjectField.DictValueType != models.Object {
		t.Fatalf("expected value of dictOfInlinedObject.AdditionalProperties to be a object but got %q", string(*dictOfInlinedObjectField.DictValueType))
	}
	if dictOfInlinedObjectField.ModelReference == nil {
		t.Fatalf("expected dictOfInlinedObject.ModelReference to be non-nil")
	}
	if *dictOfInlinedObjectField.ModelReference != "DictOfInlinedObjectAdditionalProperties" {
		t.Fatalf("expected dictOfInlinedObject.ModelReference to be 'DictOfInlinedObjectAdditionalProperties' but got %q", *dictOfInlinedObjectField.ModelReference)
	}
	dictOfInlinedObjectAdditionalProperties, ok := resource.Models["DictOfInlinedObjectAdditionalProperties"]
	if !ok {
		t.Fatalf("the Model `DictOfInlinedObjectAdditionalProperties` was not found")
	}
	if len(dictOfInlinedObjectAdditionalProperties.Fields) != 1 {
		t.Fatalf("expected dictOfInlinedObjectAdditionalProperties.Fields to have 1 fields but got %d", len(dictOfInlinedObjectAdditionalProperties.Fields))
	}
	p1, ok := dictOfInlinedObjectAdditionalProperties.Fields["P1"]
	if !ok {
		t.Fatalf("dictOfInlinedObjectAdditionalProperties.Fields['P1'] was missing")
	}
	if p1.Type != models.String {
		t.Fatalf("expected dictOfInlinedObjectAdditionalProperties.Fields['P1'] to be a string but got %q", string(p1.Type))
	}

	// Check for model DictOfObjectRef
	dictOfObjectRef, ok := resource.Models["DictOfObjectRef"]
	if !ok {
		t.Fatalf("the Model `DictOfObjectRef` was not found")
	}
	dictOfObjectRefField := dictOfObjectRef.AdditionalProperties
	if dictOfObjectRefField == nil {
		t.Fatalf("dictOfObjectRef.AdditionalProperties was nil")
	}
	if dictOfObjectRefField.Type != models.Dictionary {
		t.Fatalf("expected dictOfObjectRef.AdditionalProperties to be a dict but got %q", string(dictOfObjectRefField.Type))
	}
	if dictOfObjectRefField.DictValueType == nil {
		t.Fatalf("expected value of dictOfObjectRef.AdditionalProperties to be a object but got nil")
	}
	if *dictOfObjectRefField.DictValueType != models.Object {
		t.Fatalf("expected value of dictOfObjectRef.AdditionalProperties to be a object but got %q", string(*dictOfObjectRefField.DictValueType))
	}
	if dictOfObjectRefField.ModelReference == nil {
		t.Fatalf("expected dictOfObjectRef.ModelReference to be non-nil")
	}
	if *dictOfObjectRefField.ModelReference != "Obj" {
		t.Fatalf("expected dictOfObjectRef.ModelReference to be 'Obj' but got %q", *dictOfObjectRefField.ModelReference)
	}
	obj, ok := resource.Models["Obj"]
	if !ok {
		t.Fatalf("the Model `Obj` was not found")
	}
	if len(obj.Fields) != 1 {
		t.Fatalf("expected obj.Fields to have 1 fields but got %d", len(obj.Fields))
	}
	p1, ok = obj.Fields["P1"]
	if !ok {
		t.Fatalf("obj.Fields['P1'] was missing")
	}
	if p1.Type != models.String {
		t.Fatalf("expected obj.Fields['P1'] to be a string but got %q", string(p1.Type))
	}
}

func fieldValueOrNil(obj interface{}, fieldName string) interface{} {
	v := reflect.ValueOf(obj)
	fv := v.FieldByName(fieldName)
	if fv.IsNil() {
		return nil
	}
	return fv.Elem().Interface()
}

func TestParseModelIdentities(t *testing.T) {
	parsed, err := Load("testdata/", "model_identities.json", true)
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

	resource, ok := result.Resources["Identity"]
	if !ok {
		t.Fatal("the Resource 'Identity' was not found")
	}

	identityCollection, ok := resource.Models["IdentityCollection"]
	if !ok {
		t.Fatalf("the Model `IdentityCollection` was not found")
	}

	sai, ok := identityCollection.Fields["SystemAssignedIdentity"]
	if !ok {
		t.Fatalf("example.Fields['SystemAssigndIdentity'] was missing")
	}
	if sai.Type != models.SystemAssignedIdentity {
		t.Fatalf("expected example.Fields['SystemAssigndIdentity'] to be a %q but got %q", string(models.SystemAssignedIdentity), string(sai.Type))
	}

	uaiList, ok := identityCollection.Fields["UserAssignedIdentityList"]
	if !ok {
		t.Fatalf("example.Fields['UserAssignedIdentityList'] was missing")
	}
	if uaiList.Type != models.UserAssignedIdentityList {
		t.Fatalf("expected example.Fields['UserAssignedIdentityList'] to be a %q but got %q", string(models.UserAssignedIdentityList), string(uaiList.Type))
	}

	uaiMap, ok := identityCollection.Fields["UserAssignedIdentityMap"]
	if !ok {
		t.Fatalf("example.Fields['UserAssignedIdentityMap'] was missing")
	}
	if uaiMap.Type != models.UserAssignedIdentityMap {
		t.Fatalf("expected example.Fields['UserAssignedIdentityMap'] to be a %q but got %q", string(models.UserAssignedIdentityMap), string(uaiMap.Type))
	}

	uaiMapInline, ok := identityCollection.Fields["UserAssignedIdentityMapInline"]
	if !ok {
		t.Fatalf("example.Fields['UserAssignedIdentityMapInline'] was missing")
	}
	if uaiMapInline.Type != models.UserAssignedIdentityMap {
		t.Fatalf("expected example.Fields['UserAssignedIdentityMapInline'] to be a %q but got %q", string(models.UserAssignedIdentityMap), string(uaiMapInline.Type))
	}

	sauaiList, ok := identityCollection.Fields["SystemAssignedUserAssignedIdentityList"]
	if !ok {
		t.Fatalf("example.Fields['SystemAssignedUserAssignedIdentityList'] was missing")
	}
	if sauaiList.Type != models.SystemUserAssignedIdentityList {
		t.Fatalf("expected example.Fields['SystemAssignedUserAssignedIdentityList'] to be a %q but got %q", string(models.SystemUserAssignedIdentityList), string(sauaiList.Type))
	}

	sauaiMap, ok := identityCollection.Fields["SystemAssignedUserAssignedIdentityMap"]
	if !ok {
		t.Fatalf("example.Fields['SystemAssignedUserAssignedIdentityMap'] was missing")
	}
	if sauaiMap.Type != models.SystemUserAssignedIdentityMap {
		t.Fatalf("expected example.Fields['SystemAssignedUserAssignedIdentityMap'] to be a %q but got %q", string(models.SystemUserAssignedIdentityMap), string(sauaiMap.Type))
	}

	sauaiMapInline, ok := identityCollection.Fields["SystemAssignedUserAssignedIdentityMapInline"]
	if !ok {
		t.Fatalf("example.Fields['SystemAssignedUserAssignedIdentityMapInline'] was missing")
	}
	if sauaiMapInline.Type != models.SystemUserAssignedIdentityMap {
		t.Fatalf("expected example.Fields['SystemAssignedUserAssignedIdentityMapInline'] to be a %q but got %q", string(models.SystemUserAssignedIdentityMap), string(sauaiMapInline.Type))
	}

	malformedIdentity, ok := identityCollection.Fields["MalformedIdentity"]
	if !ok {
		t.Fatalf("example.Fields['MalformedIdentity'] was missing")
	}
	if malformedIdentity.Type != models.Object {
		t.Fatalf("expected example.Fields['MalformedIdentity'] to be a %q but got %q", string(models.Object), string(malformedIdentity.Type))
	}
}

func TestParseModelWithLocation(t *testing.T) {
	parsed, err := Load("testdata/", "model_with_location.json", true)
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

	resource, ok := result.Resources["Resource"]
	if !ok {
		t.Fatal("the Resource 'Resource' was not found")
	}

	model, ok := resource.Models["Model"]
	if !ok {
		t.Fatalf("the Model `Model` was not found")
	}

	field, ok := model.Fields["Location"]
	if !ok {
		t.Fatalf("example.Fields['Location'] was missing")
	}
	if field.Type != models.Location {
		t.Fatalf("expected example.Fields['Location'] to be a %q but got %q", string(models.Location), string(field.Type))
	}
}
