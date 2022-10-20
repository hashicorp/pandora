package parser

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseModelSingleTopLevel(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_single.json")
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
	if len(example.Fields) != 6 {
		t.Fatalf("expected example.Fields to have 6 fields but got %d", len(example.Fields))
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
	if name.Description != "the name of this thing" {
		t.Fatalf("expected example.Fields['Name'].Description to be 'the name of this thing' but got %q", name.Description)
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
	if age.Description != "the age of this thing" {
		t.Fatalf("expected example.Fields['Age'].Description to be 'the age of this thing' but got %q", age.Description)
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
	if enabled.Description != "true or false" {
		t.Fatalf("expected example.Fields['Enabled'].Description to be 'true or false' but got %q", enabled.Description)
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
	if height.Description != "the height of this in cm" {
		t.Fatalf("expected example.Fields['Height'].Description to be 'the height of this in cm' but got %q", height.Description)
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
	if tags.Description != "a key value pair" {
		t.Fatalf("expected example.Fields['Tags'].Description to be 'a key value pair' but got %q", tags.Description)
	}

	value, ok := example.Fields["Value"]
	if !ok {
		t.Fatalf("example.Fields['Value'] was missing")
	}
	if value.ObjectDefinition == nil {
		t.Fatalf("example.Fields['Value'] had no ObjectDefinition")
	}
	if value.ObjectDefinition.Type != models.ObjectDefinitionRawObject {
		t.Fatalf("expected example.Fields['Value'] to be RawObject but got %q", string(value.ObjectDefinition.Type))
	}
	if value.JsonName != "value" {
		t.Fatalf("expected example.Fields['Value'].JsonName to be 'value' but got %q", value.JsonName)
	}
	if value.Description != "Example value. May be a primitive value, or an object." {
		t.Fatalf("expected example.Fields['Value'].Description to be 'Example value. May be a primitive value, or an object.' but got %q", value.Description)
	}
}

func TestParseModelSingleTopLevelWithInlinedModel(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_single_with_inlined_model.json")
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
	if len(exampleProperties.Fields) != 5 {
		t.Fatalf("expected exampleProperties.Fields to have 5 fields but got %d", len(example.Fields))
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

	value, ok := exampleProperties.Fields["Value"]
	if !ok {
		t.Fatalf("exampleProperties.Fields['Value'] was missing")
	}
	if value.ObjectDefinition == nil {
		t.Fatalf("exampleProperties.Fields['Value'] had no ObjectDefinition")
	}
	if value.ObjectDefinition.Type != models.ObjectDefinitionRawObject {
		t.Fatalf("expected exampleProperties.Fields['Value'] to be RawObject but got %q", string(value.ObjectDefinition.Type))
	}
	if value.JsonName != "value" {
		t.Fatalf("expected exampleProperties.Fields['Value'].JsonName to be 'value' but got %q", value.JsonName)
	}
}

func TestParseModelSingleWithInlinedObject(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_with_inlined_object.json")
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
}

func TestParseModelSingleWithNumberPrefixedField(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_with_number_prefixed_field.json")
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
	if len(hello.Models) != 1 {
		t.Fatalf("expected 1 Model but got %d", len(hello.Models))
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
	fiveZeroPercentDone, ok := exampleModel.Fields["Five0PercentDone"]
	if !ok {
		t.Fatalf("expected the model Example to have a field Five0PercentDone")
	}
	if fiveZeroPercentDone.JsonName != "50PercentDone" {
		t.Fatalf("expected the field `FiveZeroPercentDone` within model `Example` to have a jsonName of `50PercentDone` but got %q", fiveZeroPercentDone.JsonName)
	}
}

func TestParseModelSingleInheritingFromObjectWithNoExtraFields(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_inheriting_from_other_model_no_new_fields.json")
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
	if len(hello.Models) != 1 {
		t.Fatalf("expected 1 Model but got %d", len(hello.Models))
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
	if *world.ResponseObject.ReferenceName != "FirstObject" {
		t.Fatalf("expected the response object to be 'FirstObject' but got %q", *world.ResponseObject.ReferenceName)
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

	// whilst the response model references SecondObject, it's only inheriting from FirstObject, so it'll be switched out
	firstObject, ok := hello.Models["FirstObject"]
	if !ok {
		t.Fatalf("expected there to be a model called FirstObject")
	}
	if len(firstObject.Fields) != 1 {
		t.Fatalf("expected the model SecondObject to have 1 field but got %d", len(firstObject.Fields))
	}
	if _, ok := firstObject.Fields["Name"]; !ok {
		t.Fatalf("expected the model SecondObject to have a field named `Name` but didn't get one")
	}
}

func TestParseModelSingleInheritingFromObjectWithNoExtraFieldsInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_inheriting_from_other_model_no_new_fields_inlined.json")
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
		t.Fatalf("expected 2 Model but got %d", len(hello.Models))
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
	if *world.ResponseObject.ReferenceName != "FirstObject" {
		t.Fatalf("expected the response object to be 'FirstObject' but got %q", *world.ResponseObject.ReferenceName)
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

	firstObject, ok := hello.Models["FirstObject"]
	if !ok {
		t.Fatalf("expected there to be a Model named FirstObject but didn't get one")
	}
	if len(firstObject.Fields) != 2 {
		t.Fatalf("expected the model FirstObject to have 2 fields but got %d", len(firstObject.Fields))
	}
	endpointsField, ok := firstObject.Fields["Endpoints"]
	if !ok {
		t.Fatal("expected the model FirstObject to have a field `Endpoints` but it didn't exist")
	}
	if endpointsField.ObjectDefinition == nil || endpointsField.ObjectDefinition.ReferenceName == nil {
		t.Fatal("expected the model FirstObject to be a reference but didn't get one")
	}
	if *endpointsField.ObjectDefinition.ReferenceName != "SecondObject" {
		t.Fatalf("expected the model FirstObject to be a reference to SecondObject but got %q", *endpointsField.ObjectDefinition.ReferenceName)
	}

	secondObject, ok := hello.Models["SecondObject"]
	if !ok {
		t.Fatalf("expected there to be a model called SecondObject")
	}
	if len(secondObject.Fields) != 1 {
		t.Fatalf("expected the model SecondObject to have 1 field but got %d", len(secondObject.Fields))
	}
	if _, ok := secondObject.Fields["Name"]; !ok {
		t.Fatalf("expected the model SecondObject to have a field named `Name` but didn't get one")
	}
}

func TestParseModelSingleWithDateTimeNoType(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_single_datetime_no_type.json")
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
	if len(example.Fields) != 1 {
		t.Fatalf("expected example.Fields to have 1 field but got %d", len(example.Fields))
	}

	name, ok := example.Fields["SomeDateValue"]
	if !ok {
		t.Fatalf("example.Fields['SomeDateValue'] was missing")
	}
	if name.ObjectDefinition == nil {
		t.Fatalf("example.Fields['SomeDateValue'] had no ObjectDefinition")
	}
	if name.ObjectDefinition.Type != models.ObjectDefinitionDateTime {
		t.Fatalf("expected example.Fields['SomeDateValue'] to be a DateTime but got %q", string(name.ObjectDefinition.Type))
	}
	if name.JsonName != "someDateValue" {
		t.Fatalf("expected example.Fields['SomeDateValue'].JsonName to be 'someDateValue' but got %q", name.JsonName)
	}
}

func TestParseModelSingleWithReference(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_single_with_reference.json")
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
}

func TestParseModelSingleWithReferenceToArray(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_single_with_reference_array.json")
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
	result, err := ParseSwaggerFileForTesting(t, "model_single_with_reference_constant.json")
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
	result, err := ParseSwaggerFileForTesting(t, "model_single_with_reference_string.json")
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

func TestParseModelSingleContainingAllOfToTypeObject(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_containing_allof_object_type.json")
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
	if len(hello.Models) != 1 {
		t.Fatalf("expected 1 Model but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	example, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model named Example")
	}
	if len(example.Fields) != 2 {
		t.Fatalf("expected the model Example to have 2 fields but got %d", len(example.Fields))
	}
}

func TestParseModelSingleContainingAllOfToTypeObjectWithProperties(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_containing_allof_object_type_with_properties.json")
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
	if len(hello.Models) != 1 {
		t.Fatalf("expected 1 Model but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	example, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model named Example")
	}
	if len(example.Fields) != 2 {
		t.Fatalf("expected the model Example to have 2 fields but got %d", len(example.Fields))
	}
}

func TestParseModelSingleContainingAllOfWithinProperties(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_containing_allof_within_properties.json")
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
		t.Fatalf("expected 2 Model but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	example, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model named Example")
	}
	if len(example.Fields) != 2 {
		t.Fatalf("expected the model Example to have 2 fields but got %d", len(example.Fields))
	}

	props, ok := hello.Models["ExampleProperties"]
	if !ok {
		t.Fatalf("expected there to be a model named ExampleProperties")
	}
	if len(props.Fields) != 3 {
		t.Fatalf("expected the model ExampleProperties to have 3 fields but got %d", len(props.Fields))
	}
}

func TestParseModelWithCircularReferences(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_with_circular_reference.json")
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

func TestParseModelInlinedWithNoName(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_inlined_with_no_name.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Example"]
	if !ok {
		t.Fatal("the Resource 'Example' was not found")
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
	if len(resource.ResourceIds) != 0 {
		t.Fatalf("expected no Resource IDs but got %d", len(resource.ResourceIds))
	}

	test, ok := resource.Operations["Test"]
	if !ok {
		t.Fatalf("the operation Test was not found")
	}
	if test.ResponseObject == nil {
		t.Fatalf("the operation Test had no response object")
	}
	if *test.ResponseObject.ReferenceName != "Container" {
		t.Fatalf("expected the operation Test to have Response Model of `Container` but got %q", *test.ResponseObject.ReferenceName)
	}

	container, ok := resource.Models["Container"]
	if !ok {
		t.Fatalf("the model Container was not found")
	}
	field, ok := container.Fields["Planets"]
	if !ok {
		t.Fatalf("the field Planets was not found within the model Container")
	}
	if field.ObjectDefinition.Type != models.ObjectDefinitionList {
		t.Fatalf("the field Planets within the model Container should be a List but got %q", string(field.ObjectDefinition.Type))
	}
	if field.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("the field Planets within the model Container should be a List of a Reference but got %q", string(field.ObjectDefinition.NestedItem.Type))
	}
	if *field.ObjectDefinition.NestedItem.ReferenceName != "ContainerPlanetsInlined" {
		t.Fatalf("the field Planets within the model Container should be a List of a Reference to ContainerPlanetsInlined but got %q", *field.ObjectDefinition.NestedItem.ReferenceName)
	}

	containerPlanet, ok := resource.Models["ContainerPlanetsInlined"]
	if !ok {
		t.Fatalf("the model ContainerPlanetsInlined was not found")
	}
	if len(containerPlanet.Fields) != 1 {
		t.Fatalf("expected the model ContainerPlanetsInlined to have 1 field but got %d", len(containerPlanet.Fields))
	}
}

func TestParseModelMultipleTopLevel(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_multiple.json")
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
	result, err := ParseSwaggerFileForTesting(t, "model_multiple_list.json")
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
	result, err := ParseSwaggerFileForTesting(t, "model_multiple_inheritance.json")
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
	result, err := ParseSwaggerFileForTesting(t, "model_with_location.json")
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
