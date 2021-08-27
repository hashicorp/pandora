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
	if len(example.Fields) != 5 {
		t.Fatalf("expected example.Fields to have 5 fields but got %d", len(example.Fields))
	}

	name, ok := example.Fields["Name"]
	if !ok {
		t.Fatalf("example.Fields['Name'] was missing")
	}
	if name.ObjectDefinition == nil {
		t.Fatalf("example.Fields['Name'] had no ObjectDefinition")
	}
	if name.ObjectDefinition.Type != models.ObjectDefinitionString {
		t.Fatalf("expected example.Fields['Name'] to be a string but got %q", string(name.ObjectDefinition.Type))
	}
	if name.JsonName != "name" {
		t.Fatalf("expected example.Fields['Name'].JsonName to be 'name' but got %q", name.JsonName)
	}

	age, ok := example.Fields["Age"]
	if !ok {
		t.Fatalf("example.Fields['Age'] was missing")
	}
	if age.ObjectDefinition == nil {
		t.Fatalf("example.Fields['Age'] had no ObjectDefinition")
	}
	if age.ObjectDefinition.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected example.Fields['Age'] to be an integer but got %q", string(age.ObjectDefinition.Type))
	}
	if age.JsonName != "age" {
		t.Fatalf("expected example.Fields['Age'].JsonName to be 'age' but got %q", age.JsonName)
	}

	enabled, ok := example.Fields["Enabled"]
	if !ok {
		t.Fatalf("example.Fields['Enabled'] was missing")
	}
	if enabled.ObjectDefinition == nil {
		t.Fatalf("example.Fields['Enabled'] had no ObjectDefinition")
	}
	if enabled.ObjectDefinition.Type != models.ObjectDefinitionBoolean {
		t.Fatalf("expected example.Fields['Enabled'] to be a boolean but got %q", string(enabled.ObjectDefinition.Type))
	}
	if enabled.JsonName != "enabled" {
		t.Fatalf("expected example.Fields['Enabled'].JsonName to be 'enabled' but got %q", enabled.JsonName)
	}

	height, ok := example.Fields["Height"]
	if !ok {
		t.Fatalf("example.Fields['Height'] was missing")
	}
	if height.ObjectDefinition == nil {
		t.Fatalf("example.Fields['Height'] had no ObjectDefinition")
	}
	if height.ObjectDefinition.Type != models.ObjectDefinitionFloat {
		t.Fatalf("expected example.Fields['Height'] to be a float but got %q", string(height.ObjectDefinition.Type))
	}
	if height.JsonName != "height" {
		t.Fatalf("expected example.Fields['Height'].JsonName to be 'height' but got %q", height.JsonName)
	}

	tags, ok := example.Fields["Tags"]
	if !ok {
		t.Fatalf("example.Fields['Tags'] was missing")
	}
	if tags.CustomFieldType == nil {
		t.Fatalf("example.Fields['Tags'] had no CustomFieldType")
	}
	if *tags.CustomFieldType != models.CustomFieldTypeTags {
		t.Fatalf("expected example.Fields['Tags'] to be Tags but got %q", string(*tags.CustomFieldType))
	}
	if tags.ObjectDefinition != nil {
		t.Fatalf("example.Fields['Tags'] had an ObjectDefinition when it shouldn't")
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
	propField, ok := example.Fields["Properties"]
	if !ok {
		t.Fatalf("expected Example to have a field named Properties")
	}
	if propField.ObjectDefinition == nil {
		t.Fatalf("expected Example to be an ObjectDefinition but it wasn't")
	}
	if propField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected Example to be a Reference but it was %q", string(propField.ObjectDefinition.Type))
	}
	if *propField.ObjectDefinition.ReferenceName != "ExampleProperties" {
		t.Fatalf("expected Example to be a Reference to `ExampleProperties` but it was %q", *propField.ObjectDefinition.ReferenceName)
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
	if nickName.ObjectDefinition == nil {
		t.Fatalf("exampleProperties.Fields['Nickname'] was missing an ObjectDefinition")
	}
	if nickName.ObjectDefinition.Type != models.ObjectDefinitionString {
		t.Fatalf("expected exampleProperties.Fields['Nickname'] to be a string but got %q", string(nickName.ObjectDefinition.Type))
	}
	if nickName.JsonName != "nickname" {
		t.Fatalf("expected exampleProperties.Fields['Nickname'].JsonName to be 'name' but got %q", nickName.JsonName)
	}

	age, ok := exampleProperties.Fields["Age"]
	if !ok {
		t.Fatalf("exampleProperties.Fields['Age'] was missing")
	}
	if age.ObjectDefinition == nil {
		t.Fatalf("exampleProperties.Fields['Age'] was missing an ObjectDefinition")
	}
	if age.ObjectDefinition.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected exampleProperties.Fields['Age'] to be an integer but got %q", string(age.ObjectDefinition.Type))
	}
	if age.JsonName != "age" {
		t.Fatalf("expected exampleProperties.Fields['Age'].JsonName to be 'age' but got %q", age.JsonName)
	}

	enabled, ok := exampleProperties.Fields["Enabled"]
	if !ok {
		t.Fatalf("exampleProperties.Fields['Enabled'] was missing")
	}
	if enabled.ObjectDefinition == nil {
		t.Fatalf("exampleProperties.Fields['Enabled'] was missing an ObjectDefinition")
	}
	if enabled.ObjectDefinition.Type != models.ObjectDefinitionBoolean {
		t.Fatalf("expected exampleProperties.Fields['Enabled'] to be a boolean but got %q", string(enabled.ObjectDefinition.Type))
	}
	if enabled.JsonName != "enabled" {
		t.Fatalf("expected exampleProperties.Fields['Enabled'].JsonName to be 'enabled' but got %q", enabled.JsonName)
	}

	tags, ok := exampleProperties.Fields["Tags"]
	if !ok {
		t.Fatalf("exampleProperties.Fields['Tags'] was missing")
	}
	if tags.CustomFieldType == nil {
		t.Fatalf("exampleProperties.Fields['Tags'] was missing a CustomFieldType")
	}
	if *tags.CustomFieldType != models.CustomFieldTypeTags {
		t.Fatalf("expected exampleProperties.Fields['Tags'] to be Tags but got %q", string(*tags.CustomFieldType))
	}
	if tags.JsonName != "tags" {
		t.Fatalf("expected exampleProperties.Fields['Tags'].JsonName to be 'tags' but got %q", tags.JsonName)
	}
}

func TestParseModelSingleWithInlinedObject(t *testing.T) {
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
	if world.RequestObject != nil {
		t.Fatalf("expected no request object but got %+v", *world.RequestObject)
	}
	if world.ResponseObject == nil {
		t.Fatal("expected a response object but didn't get one")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the response object to be a reference but got %q", string(world.ResponseObject.Type))
	}
	if *world.ResponseObject.ReferenceName != "Example" {
		t.Fatalf("expected the response object to be 'Example' but got %q", *world.ResponseObject.ReferenceName)
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
	if thingField.ObjectDefinition == nil {
		t.Fatalf("expected ThingProps to have an ObjectDefinition")
	}
	if thingField.ObjectDefinition.Type != models.ObjectDefinitionList {
		t.Fatalf("expected ThingProps to be a List but got %q", string(thingField.ObjectDefinition.Type))
	}
	if thingField.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected ThingProps to be a List of References but got %q", string(thingField.ObjectDefinition.NestedItem.Type))
	}
	if thingField.ObjectDefinition.NestedItem.ReferenceName == nil {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was nil")
	}
	if *thingField.ObjectDefinition.NestedItem.ReferenceName != "ThingProperties" {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was %q", *thingField.ObjectDefinition.NestedItem.ReferenceName)
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
	if uaiField.CustomFieldType == nil {
		t.Fatalf("expected UserAssignedIdentities to be a CustomFieldType but it was nil")
	}
	if *uaiField.CustomFieldType != models.CustomFieldTypeUserAssignedIdentityMap {
		t.Fatalf("expected UserAssignedIdentities to be a CustomFieldTypeUserAssignedIdentityMap but it was %q", string(*uaiField.CustomFieldType))
	}
	if uaiField.ObjectDefinition != nil {
		t.Fatalf("expected UserAssignedIdentities to have no ObjectDefinition but got %+v", *uaiField.ObjectDefinition)
	}

	if _, ok := hello.Models["ThingPropertiesUserAssignedIdentities"]; ok {
		t.Fatalf("expected the model ThingPropertiesUserAssignedIdentities to be removed but it was present")
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
	if world.RequestObject != nil {
		t.Fatalf("expected no request object but got %+v", *world.RequestObject)
	}
	if world.ResponseObject == nil {
		t.Fatal("expected a response object but didn't get one")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the response object to be a reference but got %q", string(world.ResponseObject.Type))
	}
	if *world.ResponseObject.ReferenceName != "Example" {
		t.Fatalf("expected the response object to be 'Example' but got %q", *world.ResponseObject.ReferenceName)
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
	if thingField.ObjectDefinition == nil {
		t.Fatalf("expected ThingProps to be an ObjectDefinition but it wasn't")
	}
	if thingField.ObjectDefinition.Type != models.ObjectDefinitionList {
		t.Fatalf("expected ThingProps to be a List but got %q", string(thingField.ObjectDefinition.Type))
	}
	if thingField.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected ThingProps to be a List but got %q", string(thingField.ObjectDefinition.NestedItem.Type))
	}
	if thingField.ObjectDefinition.NestedItem.ReferenceName == nil {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was nil")
	}
	if *thingField.ObjectDefinition.NestedItem.ReferenceName != "ThingProperties" {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was %q", *thingField.ObjectDefinition.NestedItem.ReferenceName)
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
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to be a CustomFieldType but it wasn't")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to not have an ObjectDefinition but got %+v", identityField.ObjectDefinition)
	}
	if identityField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the model ThingProperties field Identity to be an Reference but it was %q", string(identityField.ObjectDefinition.Type))
	}
	if *identityField.ObjectDefinition.ReferenceName != "UserAssignedIdentityProperties" {
		t.Fatalf("expected the model ThingProperties field Identity's model reference to be `UserAssignedIdentityProperties` but it was %q", *identityField.ObjectDefinition.ReferenceName)
	}

	if _, hasModel := hello.Models["UserAssignedIdentityProperties"]; !hasModel {
		t.Fatalf("expected the model UserAssignedIdentityProperties to be present but it wasn't")
	}
}

func TestParseModelSingleWithReferenceToArray(t *testing.T) {
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
	if world.RequestObject != nil {
		t.Fatalf("expected no request object but got %+v", *world.RequestObject)
	}
	if world.ResponseObject == nil {
		t.Fatal("expected a response object but didn't get one")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the response object to be a reference but got %q", string(world.ResponseObject.Type))
	}
	if *world.ResponseObject.ReferenceName != "Example" {
		t.Fatalf("expected the response object to be 'Example' but got %q", *world.ResponseObject.ReferenceName)
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
	if petsField.ObjectDefinition.Type != models.ObjectDefinitionList {
		t.Fatalf("expected Pets to be a List but got %q", string(petsField.ObjectDefinition.Type))
	}
	if petsField.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected Pets to be a List of a Refernece but got a List of %q", string(petsField.ObjectDefinition.Type))
	}
	if *petsField.ObjectDefinition.NestedItem.ReferenceName != "Pet" {
		t.Fatalf("expected ThingProps to be a reference to Pet but it was %q", *petsField.ObjectDefinition.ReferenceName)
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
	if nameField.ObjectDefinition.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the model Pet field Name to be a String but it was %q", string(nameField.ObjectDefinition.Type))
	}
	if nameField.ObjectDefinition.ReferenceName != nil {
		t.Fatalf("expected the model Pet field Name to have no model reference but it was %q", *nameField.ObjectDefinition.ReferenceName)
	}
}

func TestParseModelSingleWithReferenceToConstant(t *testing.T) {
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
	if world.RequestObject != nil {
		t.Fatalf("expected no request object but got %+v", *world.RequestObject)
	}
	if world.ResponseObject == nil {
		t.Fatal("expected a response object but didn't get one")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the response object to be a reference but got %q", string(world.ResponseObject.Type))
	}
	if *world.ResponseObject.ReferenceName != "Example" {
		t.Fatalf("expected the response object to be 'Example' but got %q", *world.ResponseObject.ReferenceName)
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
	if thingField.ObjectDefinition.Type != models.ObjectDefinitionList {
		t.Fatalf("expected ThingProps to be a List but got %q", string(thingField.ObjectDefinition.Type))
	}
	if thingField.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected ThingProps to be a List of References but got a List of %q", string(thingField.ObjectDefinition.NestedItem.Type))
	}
	if thingField.ObjectDefinition.NestedItem.ReferenceName == nil {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was nil")
	}
	if *thingField.ObjectDefinition.NestedItem.ReferenceName != "ThingProperties" {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was %q", *thingField.ObjectDefinition.NestedItem.ReferenceName)
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
	if animalField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the model ThingProperties field Animal to be an Object but it was %q", string(animalField.ObjectDefinition.Type))
	}
	if *animalField.ObjectDefinition.ReferenceName != "AnimalType" {
		t.Fatalf("expected the model ThingProperties field Animal to have a reference of 'AnimalType' but it was %q", *animalField.ObjectDefinition.ReferenceName)
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
	if world.RequestObject != nil {
		t.Fatalf("expected no request object but got %+v", *world.RequestObject)
	}
	if world.ResponseObject == nil {
		t.Fatal("expected a response object but didn't get one")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the response object to be a reference but it was %q", string(world.ResponseObject.Type))
	}
	if *world.ResponseObject.ReferenceName != "Example" {
		t.Fatalf("expected the response object to be 'Example' but got %q", *world.ResponseObject.ReferenceName)
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
	if thingField.ObjectDefinition.Type != models.ObjectDefinitionList {
		t.Fatalf("expected ThingProps to be a List but got %q", string(thingField.ObjectDefinition.Type))
	}
	if thingField.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected ThingProps to be a List of References but got a List of %q", string(thingField.ObjectDefinition.Type))
	}
	if *thingField.ObjectDefinition.NestedItem.ReferenceName != "ThingProperties" {
		t.Fatalf("expected ThingProps to be a reference to ThingProperties but it was %q", *thingField.ObjectDefinition.NestedItem.ReferenceName)
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
	if fqdnField.ObjectDefinition.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the model ThingProperties field FullyQualifiedDomainName to be a String but it was %q", string(fqdnField.ObjectDefinition.Type))
	}
	if fqdnField.ObjectDefinition.ReferenceName != nil {
		t.Fatalf("expected the model ThingProperties field FullyQualifiedDomainName to have no model reference but it was %q", *fqdnField.ObjectDefinition.ReferenceName)
	}
}

func TestParseModelWithCircularReferences(t *testing.T) {
	t.Skipf("circular ref - look into later")

	parsed, err := Load("testdata/", "model_with_circular_reference.json", true)
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
		if name.ObjectDefinition.Type != models.ObjectDefinitionString {
			t.Fatalf("expected input.Fields['Name'] to be a string but got %q", string(name.ObjectDefinition.Type))
		}
		if name.JsonName != "name" {
			t.Fatalf("expected input.Fields['Name'].JsonName to be 'name' but got %q", name.JsonName)
		}

		age, ok := input.Fields["Age"]
		if !ok {
			t.Fatalf("input.Fields['Age'] was missing")
		}
		if age.ObjectDefinition.Type != models.ObjectDefinitionInteger {
			t.Fatalf("expected input.Fields['Age'] to be an integer but got %q", string(age.ObjectDefinition.Type))
		}
		if age.JsonName != "age" {
			t.Fatalf("expected input.Fields['Age'].JsonName to be 'age' but got %q", age.JsonName)
		}

		enabled, ok := input.Fields["Enabled"]
		if !ok {
			t.Fatalf("input.Fields['Enabled'] was missing")
		}
		if enabled.ObjectDefinition.Type != models.ObjectDefinitionBoolean {
			t.Fatalf("expected input.Fields['Enabled'] to be a boolean but got %q", string(enabled.ObjectDefinition.Type))
		}
		if enabled.JsonName != "enabled" {
			t.Fatalf("expected input.Fields['Enabled'].JsonName to be 'enabled' but got %q", enabled.JsonName)
		}

		tags, ok := input.Fields["Tags"]
		if !ok {
			t.Fatalf("input.Fields['Tags'] was missing")
		}
		if tags.ObjectDefinition != nil {
			t.Fatalf("expected input.Fields['Tags'] to have no ObjectDefinition but got %+v", *tags.ObjectDefinition)
		}
		if tags.CustomFieldType == nil {
			t.Fatalf("expected input.Fields['Tags'] to have a CustomFieldType but it was nil")
		}
		if *tags.CustomFieldType != models.CustomFieldTypeTags {
			t.Fatalf("expected input.Fields['Tags'].CustomFieldType to be Tags but got %q", string(*tags.CustomFieldType))
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
	if personName.ObjectDefinition.Type != models.ObjectDefinitionString {
		t.Fatalf("expected person.Fields['Name'] to be a string but got %q", string(personName.ObjectDefinition.Type))
	}
	if personName.JsonName != "name" {
		t.Fatalf("expected person.Fields['Name'].JsonName to be 'name' but got %q", personName.JsonName)
	}

	animals, ok := person.Fields["Animals"]
	if !ok {
		t.Fatalf("person.Fields['Animals'] was missing")
	}
	if animals.ObjectDefinition.Type != models.ObjectDefinitionList {
		t.Fatalf("expected person.Fields['Animals'] to be a List but got %q", string(animals.ObjectDefinition.Type))
	}
	if animals.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected person.Fields['Animals'] to be a List but got %q", string(animals.ObjectDefinition.NestedItem.Type))
	}
	if *animals.ObjectDefinition.NestedItem.ReferenceName != "Animal" {
		t.Fatalf("person.Fields['Animals'].ModelReference should be 'Animal' but was %q", *animals.ObjectDefinition.NestedItem.ReferenceName)
	}
	if animals.ObjectDefinition.NestedItem.Minimum != nil {
		t.Fatalf("expected person.Fields['Animals'].ObjectDefinition.NestedItem.Minimum to be nil but got %v", *animals.ObjectDefinition.NestedItem.Minimum)
	}
	if animals.ObjectDefinition.NestedItem.Maximum != nil {
		t.Fatalf("expected person.Fields['Animals'].ObjectDefinition.NestedItem.Maximum to be nil but got %v", *animals.ObjectDefinition.NestedItem.Maximum)
	}
	if animals.ObjectDefinition.NestedItem.UniqueItems == nil {
		t.Fatalf("expected person.Fields['Animals'].ObjectDefinition.NestedItem.UniqueItems to be false but got nil")
	}
	if *animals.ObjectDefinition.NestedItem.UniqueItems {
		t.Fatalf("expected person.Fields['Animals'].ObjectDefinition.NestedItem.UniqueItems to be false but got true")
	}
	if animals.JsonName != "animals" {
		t.Fatalf("expected person.Fields['Animals'].JsonName to be 'animals' but got %q", animals.JsonName)
	}

	plants, ok := person.Fields["Plants"]
	if !ok {
		t.Fatalf("person.Fields['Plants'] was missing")
	}
	if plants.ObjectDefinition.NestedItem.Maximum == nil {
		t.Fatalf("expected person.Fields['Plants'].ObjectDefinition.NestedItem.Maximum to be 10 but got nil")
	}
	if *plants.ObjectDefinition.NestedItem.Maximum != 10 {
		t.Fatalf("expected person.Fields['Plants'].ObjectDefinition.NestedItem.Maximum to be 10 but got %d", *plants.ObjectDefinition.NestedItem.Maximum)
	}
	if plants.ObjectDefinition.NestedItem.Minimum == nil {
		t.Fatalf("expected person.Fields['Plants'].ObjectDefinition.NestedItem.Minimum to be 1 but got nil")
	}
	if *plants.ObjectDefinition.NestedItem.Minimum != 1 {
		t.Fatalf("expected person.Fields['Plants'].ObjectDefinition.NestedItem.Minimum to be 1 but got %d", *plants.ObjectDefinition.NestedItem.Minimum)
	}
	if plants.ObjectDefinition.NestedItem.UniqueItems == nil {
		t.Fatalf("expected person.Fields['Plants'].ObjectDefinition.NestedItem.UniqueItems to be true but got nil")
	}
	if !*plants.ObjectDefinition.NestedItem.UniqueItems {
		t.Fatalf("expected person.Fields['Plants'].ObjectDefinition.NestedItem.UniqueItems to be true but got false")
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
	if animalName.ObjectDefinition.Type != models.ObjectDefinitionString {
		t.Fatalf("expected animalModel.Fields['Name'] to be a string but got %q", string(animalName.ObjectDefinition.Type))
	}
	if animalName.JsonName != "name" {
		t.Fatalf("expected animalModel.Fields['Name'].JsonName to be 'name' but got %q", animalName.JsonName)
	}
	if animalName.ObjectDefinition.Minimum != nil {
		t.Fatalf("expected person.Fields['Name'].ObjectDefinition.Minimum to be nil but got %v", *animalName.ObjectDefinition.Minimum)
	}
	if animalName.ObjectDefinition.Maximum != nil {
		t.Fatalf("expected person.Fields['Name'].ObjectDefinition.Maximum to be nil but got %v", *animalName.ObjectDefinition.Maximum)
	}
	if animalName.ObjectDefinition.UniqueItems != nil {
		t.Fatalf("expected person.Fields['Name'].ObjectDefinition.UniqueItems to be nil but got %v", *animalName.ObjectDefinition.UniqueItems)
	}

	animalAge, ok := animalModel.Fields["Age"]
	if !ok {
		t.Fatalf("animalModel.Fields['Age'] was missing")
	}
	if animalAge.ObjectDefinition.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected animalModel.Fields['Age'] to be a string but got %q", string(animalAge.ObjectDefinition.Type))
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
	if name.ObjectDefinition.Type != models.ObjectDefinitionString {
		t.Fatalf("expected example.Fields['Name'] to be a string but got %q", string(name.ObjectDefinition.Type))
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
	if age.ObjectDefinition.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected example.Fields['Age'] to be an integer but got %q", string(age.ObjectDefinition.Type))
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
	if enabled.ObjectDefinition.Type != models.ObjectDefinitionBoolean {
		t.Fatalf("expected example.Fields['Enabled'] to be a boolean but got %q", string(enabled.ObjectDefinition.Type))
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
	if height.ObjectDefinition.Type != models.ObjectDefinitionFloat {
		t.Fatalf("expected example.Fields['Height'] to be a float but got %q", string(height.ObjectDefinition.Type))
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
	if tags.ObjectDefinition != nil {
		t.Fatalf("expected example.Fields['Tags'] to have no ObjectDefinition but got %+v", *tags.ObjectDefinition)
	}
	if tags.CustomFieldType == nil {
		t.Fatalf("expected example.Fields['Tags'] to have a CustomFieldType but it was nil")
	}
	if *tags.CustomFieldType != models.CustomFieldTypeTags {
		t.Fatalf("expected example.Fields['Tags'] to be Tags but got %q", string(*tags.CustomFieldType))
	}
	if tags.JsonName != "tags" {
		t.Fatalf("expected example.Fields['Tags'].JsonName to be 'tags' but got %q", tags.JsonName)
	}
	if !tags.Required {
		t.Fatalf("expected example.Fields['Tags'].Required to be 'true'")
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
	if *field.CustomFieldType != models.CustomFieldTypeLocation {
		t.Fatalf("expected example.Fields['Location'] to be a Location but got %q", string(*field.CustomFieldType))
	}
}
