package parser

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseModelWithADictionaryOfIntegers(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_integers.json")
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
		t.Fatalf("expected the model Example to have 2 field but got %d", len(exampleModel.Fields))
	}
	if _, ok := exampleModel.Fields["Name"]; !ok {
		t.Fatalf("expected there to be a field called Name")
	}
	mapField, ok := exampleModel.Fields["MapField"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if mapField.CustomFieldType != nil {
		t.Fatalf("expected the field MapField to not have a CustomFieldType but got %q", string(*mapField.CustomFieldType))
	}
	if mapField.ObjectDefinition == nil {
		t.Fatalf("expected the field MapField to have an ObjectDefinition but it was nil")
	}
	if mapField.ObjectDefinition.Type != models.ObjectDefinitionDictionary {
		t.Fatalf("expected the field MapField to be a Dictionary but got %q", string(mapField.ObjectDefinition.Type))
	}
	if mapField.ObjectDefinition.NestedItem == nil {
		t.Fatalf("expected the field MapField to have a NestedItem but it was nil")
	}
	if mapField.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected the field MapField to have a NestedItem of an Integer but got %q", string(mapField.ObjectDefinition.NestedItem.Type))
	}
}

func TestParseModelWithADictionaryOfIntegersInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_integers_inlined.json")
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
		t.Fatalf("expected the model Example to have 2 field but got %d", len(exampleModel.Fields))
	}
	if _, ok := exampleModel.Fields["Name"]; !ok {
		t.Fatalf("expected there to be a field called Name")
	}
	mapField, ok := exampleModel.Fields["MapField"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if mapField.CustomFieldType != nil {
		t.Fatalf("expected the field MapField to not have a CustomFieldType but got %q", string(*mapField.CustomFieldType))
	}
	if mapField.ObjectDefinition == nil {
		t.Fatalf("expected the field MapField to have an ObjectDefinition but it was nil")
	}
	if mapField.ObjectDefinition.Type != models.ObjectDefinitionDictionary {
		t.Fatalf("expected the field MapField to be a Dictionary but got %q", string(mapField.ObjectDefinition.Type))
	}
	if mapField.ObjectDefinition.NestedItem == nil {
		t.Fatalf("expected the field MapField to have a NestedItem but it was nil")
	}
	if mapField.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected the field MapField to have a NestedItem of an Integer but got %q", string(mapField.ObjectDefinition.NestedItem.Type))
	}
}

func TestParseModelWithADictionaryOfAnObject(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_object.json")
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
		t.Fatalf("expected the model Example to have 2 field but got %d", len(exampleModel.Fields))
	}
	if _, ok := exampleModel.Fields["Name"]; !ok {
		t.Fatalf("expected there to be a field called Name")
	}
	mapField, ok := exampleModel.Fields["MapField"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if mapField.CustomFieldType != nil {
		t.Fatalf("expected the field MapField to not have a CustomFieldType but got %q", string(*mapField.CustomFieldType))
	}
	if mapField.ObjectDefinition == nil {
		t.Fatalf("expected the field MapField to have an ObjectDefinition but it was nil")
	}
	if mapField.ObjectDefinition.Type != models.ObjectDefinitionDictionary {
		t.Fatalf("expected the field MapField to be a Dictionary but got %q", string(mapField.ObjectDefinition.Type))
	}
	if mapField.ObjectDefinition.NestedItem == nil {
		t.Fatalf("expected the field MapField to have a NestedItem but it was nil")
	}
	if mapField.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the field MapField to have a NestedItem of an Reference but got %q", string(mapField.ObjectDefinition.NestedItem.Type))
	}
	if mapField.ObjectDefinition.NestedItem.ReferenceName == nil {
		t.Fatalf("expected the field MapField to have a NestedItem Reference of `MapFieldProperties` but it was nil")
	}
	if *mapField.ObjectDefinition.NestedItem.ReferenceName != "MapFieldProperties" {
		t.Fatalf("expected the field MapField to have a NestedItem Reference of `MapFieldProperties` but got %q", *mapField.ObjectDefinition.NestedItem.ReferenceName)
	}

	fieldProperties, ok := hello.Models["MapFieldProperties"]
	if !ok {
		t.Fatalf("expected there to be a model called MapFieldProperties")
	}
	if len(fieldProperties.Fields) != 4 {
		t.Fatalf("expected the model MapFieldProperties to have 4 fields but got %d", len(fieldProperties.Fields))
	}
}

func TestParseModelWithADictionaryOfAnObjectInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_object_inlined.json")
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
		t.Fatalf("expected the model Example to have 2 field but got %d", len(exampleModel.Fields))
	}
	if _, ok := exampleModel.Fields["Name"]; !ok {
		t.Fatalf("expected there to be a field called Name")
	}
	mapField, ok := exampleModel.Fields["MapField"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if mapField.CustomFieldType != nil {
		t.Fatalf("expected the field MapField to not have a CustomFieldType but got %q", string(*mapField.CustomFieldType))
	}
	if mapField.ObjectDefinition == nil {
		t.Fatalf("expected the field MapField to have an ObjectDefinition but it was nil")
	}
	if mapField.ObjectDefinition.Type != models.ObjectDefinitionDictionary {
		t.Fatalf("expected the field MapField to be a Dictionary but got %q", string(mapField.ObjectDefinition.Type))
	}
	if mapField.ObjectDefinition.NestedItem == nil {
		t.Fatalf("expected the field MapField to have a NestedItem but it was nil")
	}
	if mapField.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the field MapField to have a NestedItem of an Reference but got %q", string(mapField.ObjectDefinition.NestedItem.Type))
	}
	if mapField.ObjectDefinition.NestedItem.ReferenceName == nil {
		t.Fatalf("expected the field MapField to have a NestedItem Reference of `MapFieldProperties` but it was nil")
	}
	if *mapField.ObjectDefinition.NestedItem.ReferenceName != "MapFieldProperties" {
		t.Fatalf("expected the field MapField to have a NestedItem Reference of `MapFieldProperties` but got %q", *mapField.ObjectDefinition.NestedItem.ReferenceName)
	}

	fieldProperties, ok := hello.Models["MapFieldProperties"]
	if !ok {
		t.Fatalf("expected there to be a model called MapFieldProperties")
	}
	if len(fieldProperties.Fields) != 4 {
		t.Fatalf("expected the model MapFieldProperties to have 4 fields but got %d", len(fieldProperties.Fields))
	}
}

func TestParseModelWithADictionaryOfString(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_string.json")
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
		t.Fatalf("expected the model Example to have 2 field but got %d", len(exampleModel.Fields))
	}
	if _, ok := exampleModel.Fields["Name"]; !ok {
		t.Fatalf("expected there to be a field called Name")
	}
	mapField, ok := exampleModel.Fields["MapField"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if mapField.CustomFieldType != nil {
		t.Fatalf("expected the field MapField to not have a CustomFieldType but got %q", string(*mapField.CustomFieldType))
	}
	if mapField.ObjectDefinition == nil {
		t.Fatalf("expected the field MapField to have an ObjectDefinition but it was nil")
	}
	if mapField.ObjectDefinition.Type != models.ObjectDefinitionDictionary {
		t.Fatalf("expected the field MapField to be a Dictionary but got %q", string(mapField.ObjectDefinition.Type))
	}
	if mapField.ObjectDefinition.NestedItem == nil {
		t.Fatalf("expected the field MapField to have a NestedItem but it was nil")
	}
	if mapField.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the field MapField to have a NestedItem of an String but got %q", string(mapField.ObjectDefinition.NestedItem.Type))
	}
}

func TestParseModelWithADictionaryOfStringInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_dictionary_of_string_inlined.json")
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
		t.Fatalf("expected the model Example to have 2 field but got %d", len(exampleModel.Fields))
	}
	if _, ok := exampleModel.Fields["Name"]; !ok {
		t.Fatalf("expected there to be a field called Name")
	}
	mapField, ok := exampleModel.Fields["MapField"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if mapField.CustomFieldType != nil {
		t.Fatalf("expected the field MapField to not have a CustomFieldType but got %q", string(*mapField.CustomFieldType))
	}
	if mapField.ObjectDefinition == nil {
		t.Fatalf("expected the field MapField to have an ObjectDefinition but it was nil")
	}
	if mapField.ObjectDefinition.Type != models.ObjectDefinitionDictionary {
		t.Fatalf("expected the field MapField to be a Dictionary but got %q", string(mapField.ObjectDefinition.Type))
	}
	if mapField.ObjectDefinition.NestedItem == nil {
		t.Fatalf("expected the field MapField to have a NestedItem but it was nil")
	}
	if mapField.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the field MapField to have a NestedItem of an String but got %q", string(mapField.ObjectDefinition.NestedItem.Type))
	}
}
