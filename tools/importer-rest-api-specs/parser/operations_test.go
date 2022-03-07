package parser

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseOperationsEmpty(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_empty.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 0 {
		t.Fatalf("expected no resources but got %d", len(result.Resources))
	}
}

func TestParseOperationSingleWithTag(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_with_tag.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected no Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["HeadWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name HeadWorld")
	}
	if world.Method != "HEAD" {
		t.Fatalf("expected a HEAD operation but got %q", world.Method)
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
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
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
}

func TestParseOperationSingleWithTagAndResourceId(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_with_tag_resource_id.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected no Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 1 {
		t.Fatalf("expected 1 ResourceId but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["HeadWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name HeadWorld")
	}
	if world.Method != "HEAD" {
		t.Fatalf("expected a HEAD operation but got %q", world.Method)
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
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
	}
	if world.ResourceIdName == nil {
		t.Fatal("expected a ResourceId but was nil")
	}
	if *world.ResourceIdName != "ThingId" {
		t.Fatalf("expected world.ResourceIdName to be 'Thing' but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix != nil {
		t.Fatalf("expected world.UriSuffix to be nil but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleWithTagAndResourceIdSuffix(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_with_tag_resource_id_suffix.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected no Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 1 {
		t.Fatalf("expected 1 ResourceId but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["HeadWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name HeadWorld")
	}
	if world.Method != "HEAD" {
		t.Fatalf("expected a HEAD operation but got %q", world.Method)
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
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
	}
	if world.ResourceIdName == nil {
		t.Fatal("expected a ResourceId but was nil")
	}
	if *world.ResourceIdName != "ThingId" {
		t.Fatalf("expected world.RessourceIdName to be 'Thing' but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/restart" {
		t.Fatalf("expected world.UriSuffix to be `/restart` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleWithRequestObject(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_with_request_object.json")
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

	world, ok := hello.Operations["PutWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name PutWorld")
	}
	if world.Method != "PUT" {
		t.Fatalf("expected a PUT operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObject == nil {
		t.Fatal("expected a request object but was nil")
	}
	if world.RequestObject.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the request object to be a reference but got %q", string(world.RequestObject.Type))
	}
	if *world.RequestObject.ReferenceName != "Example" {
		t.Fatalf("expected the request object to be 'Example' but got %q", *world.RequestObject.ReferenceName)
	}
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
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
	if len(exampleModel.Fields) != 1 {
		t.Fatalf("expected the model Example to have 1 field but got %d", len(exampleModel.Fields))
	}
}

func TestParseOperationSingleWithRequestObjectInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_with_request_object_inlined.json")
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

	world, ok := hello.Operations["PutWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name PutWorld")
	}
	if world.Method != "PUT" {
		t.Fatalf("expected a PUT operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObject == nil {
		t.Fatal("expected a request object but was nil")
	}
	if world.RequestObject.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the request object to be a reference but got %q", string(world.RequestObject.Type))
	}
	if *world.RequestObject.ReferenceName != "Example" {
		t.Fatalf("expected the request object to be 'Example' but got %q", *world.RequestObject.ReferenceName)
	}
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
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
	if len(exampleModel.Fields) != 1 {
		t.Fatalf("expected the model Example to have 1 field but got %d", len(exampleModel.Fields))
	}
}

func TestParseOperationSingleWithResponseObject(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_with_response_object.json")
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
	if len(exampleModel.Fields) != 1 {
		t.Fatalf("expected the model Example to have 1 field but got %d", len(exampleModel.Fields))
	}
}

func TestParseOperationSingleWithResponseObjectInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_with_response_object_inlined.json")
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
	if len(exampleModel.Fields) != 1 {
		t.Fatalf("expected the model Example to have 1 field but got %d", len(exampleModel.Fields))
	}
}

func TestParseOperationSingleWithResponseObjectInlinedList(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_with_response_object_inlined_list.json")
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
	if world.ResponseObject.Type != models.ObjectDefinitionList {
		t.Fatalf("expected the response object to be a List but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object reference to be nil but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResponseObject.NestedItem == nil {
		t.Fatal("expected the response object to have a nested item but it didn't")
	}
	if world.ResponseObject.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the response objects nested item to be a reference but got %q", string(world.ResponseObject.NestedItem.Type))
	}
	if *world.ResponseObject.NestedItem.ReferenceName != "Example" {
		t.Fatalf("expected the response objects nested item reference to be 'Example' but got %q", *world.ResponseObject.NestedItem.ReferenceName)
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
	if len(exampleModel.Fields) != 1 {
		t.Fatalf("expected the model Example to have 1 field but got %d", len(exampleModel.Fields))
	}
}

func TestParseOperationSingleRequestingWithABool(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_bool.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["PutWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name PutWorld")
	}
	if world.Method != "PUT" {
		t.Fatalf("expected a PUT operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObject == nil {
		t.Fatal("expected a request object but was nil")
	}
	if world.RequestObject.Type != models.ObjectDefinitionBoolean {
		t.Fatalf("expected the request object to be a boolean but got %q", string(world.RequestObject.Type))
	}
	if world.RequestObject.ReferenceName != nil {
		t.Fatalf("expected the request object to be null but got %q", *world.RequestObject.ReferenceName)
	}
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
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
}

func TestParseOperationSingleRequestingWithAInteger(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_int.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["PutWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name PutWorld")
	}
	if world.Method != "PUT" {
		t.Fatalf("expected a PUT operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObject == nil {
		t.Fatal("expected a request object but was nil")
	}
	if world.RequestObject.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected the request object to be a integer but got %q", string(world.RequestObject.Type))
	}
	if world.RequestObject.ReferenceName != nil {
		t.Fatalf("expected the request object to be null but got %q", *world.RequestObject.ReferenceName)
	}
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
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
}

func TestParseOperationSingleRequestingWithADictionaryOfStrings(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_dictionary_of_strings.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["PutWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name PutWorld")
	}
	if world.Method != "PUT" {
		t.Fatalf("expected a PUT operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObject == nil {
		t.Fatal("expected a request object but was nil")
	}
	if world.RequestObject.Type != models.ObjectDefinitionDictionary {
		t.Fatalf("expected the request object to be a dictionary but got %q", string(world.RequestObject.Type))
	}
	if world.RequestObject.ReferenceName != nil {
		t.Fatalf("expected the request object to be null but got %q", *world.RequestObject.ReferenceName)
	}
	if world.RequestObject.NestedItem == nil {
		t.Fatalf("expected the request objects nested item to have a value but didn't get one")
	}
	if world.RequestObject.NestedItem.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the request objects nested item to be a string but got %q", string(world.RequestObject.NestedItem.Type))
	}
	if world.RequestObject.NestedItem.ReferenceName != nil {
		t.Fatalf("expected the request objects nested item reference to be nil but got %q", *world.RequestObject.NestedItem.ReferenceName)
	}
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
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
}

func TestParseOperationSingleRequestingWithAListOfStrings(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_list_of_strings.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["PutWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name PutWorld")
	}
	if world.Method != "PUT" {
		t.Fatalf("expected a PUT operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObject == nil {
		t.Fatal("expected a request object but was nil")
	}
	if world.RequestObject.Type != models.ObjectDefinitionList {
		t.Fatalf("expected the request object to be a list but got %q", string(world.RequestObject.Type))
	}
	if world.RequestObject.ReferenceName != nil {
		t.Fatalf("expected the request object to be null but got %q", *world.RequestObject.ReferenceName)
	}
	if world.RequestObject.NestedItem == nil {
		t.Fatalf("expected the request objects nested item to have a value but didn't get one")
	}
	if world.RequestObject.NestedItem.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the request objects nested item to be a string but got %q", string(world.RequestObject.NestedItem.Type))
	}
	if world.RequestObject.NestedItem.ReferenceName != nil {
		t.Fatalf("expected the request objects nested item reference to be nil but got %q", *world.RequestObject.NestedItem.ReferenceName)
	}
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
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
}

// Models are already tested above

func TestParseOperationSingleRequestingWithAString(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_requesting_with_a_string.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["PutWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name PutWorld")
	}
	if world.Method != "PUT" {
		t.Fatalf("expected a PUT operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObject == nil {
		t.Fatal("expected a request object but was nil")
	}
	if world.RequestObject.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the request object to be a string but got %q", string(world.RequestObject.Type))
	}
	if world.RequestObject.ReferenceName != nil {
		t.Fatalf("expected the request object to be null but got %q", *world.RequestObject.ReferenceName)
	}
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
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
}

func TestParseOperationSingleReturningABool(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_bool.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GimmeABoolean"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeABoolean")
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionBoolean {
		t.Fatalf("expected the response object to be a bool but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningAFloat(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_float.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GimmeAFloat"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeAFloat")
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionFloat {
		t.Fatalf("expected the response object to be a float but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningAFile(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_file.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GimmeAFile"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeAFile")
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionRawFile {
		t.Fatalf("expected the response object to be a RawFile but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningAnInteger(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_an_integer.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GimmeAnInteger"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeAnInteger")
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected the response object to be a int but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningAString(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_string.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GimmeAString"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeAString")
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the response object to be a string but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningAnErrorStatusCode(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_an_error_status_code.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GimmeAString"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeAString")
	}
	if world.Method != "GET" {
		t.Fatalf("expected a GET operation but got %q", world.Method)
	}
	// the 401 should be ignored
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the response object to be a string but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningATopLevelRawObject(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_top_level_raw_object.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	operation, ok := hello.Operations["RawObjectToMeToYou"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeAString")
	}
	if operation.Method != "GET" {
		t.Fatalf("expected a GET operation but got %q", operation.Method)
	}
	if len(operation.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(operation.ExpectedStatusCodes))
	}
	if operation.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", operation.ExpectedStatusCodes[0])
	}
	if operation.RequestObject == nil {
		t.Fatalf("expected a request object but got none")
	}
	if operation.RequestObject.Type != models.ObjectDefinitionRawObject {
		t.Fatalf("expected the request object to be a RawObject but got %q", string(operation.RequestObject.Type))
	}
	if operation.RequestObject.ReferenceName != nil {
		t.Fatalf("expected the request object to have no reference but got %q", *operation.RequestObject.ReferenceName)
	}
	if operation.ResponseObject == nil {
		t.Fatalf("expected a response object but got none")
	}
	if operation.ResponseObject.Type != models.ObjectDefinitionRawObject {
		t.Fatalf("expected the response object to be a RawObject but got %q", string(operation.ResponseObject.Type))
	}
	if operation.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *operation.ResponseObject.ReferenceName)
	}
	if operation.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *operation.ResourceIdName)
	}
	if operation.UriSuffix == nil {
		t.Fatal("expected operation.UriSuffix to have a value")
	}
	if *operation.UriSuffix != "/worlds" {
		t.Fatalf("expected operation.UriSuffix to be `/worlds` but got %q", *operation.UriSuffix)
	}
	if operation.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningADictionaryOfAModel(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_dictionary_of_model.json")
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
		t.Fatalf("expected 1 Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GimmeADictionaryOfAModel"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeADictionaryOfAModel")
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionDictionary {
		t.Fatalf("expected the response object to be a dictionary but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResponseObject.NestedItem == nil {
		t.Fatalf("expected the response objects nested item to have a valid but it didn't")
	}
	if world.ResponseObject.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the response objects nested item to be a referenc but got %q", string(world.ResponseObject.NestedItem.Type))
	}
	if world.ResponseObject.NestedItem.ReferenceName == nil {
		t.Fatalf("expected the response objects nested item to have a reference but got nothing")
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningADictionaryOfStrings(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_dictionary_of_strings.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GimmeADictionaryOfStrings"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeADictionaryOfStrings")
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionDictionary {
		t.Fatalf("expected the response object to be a dictionary but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResponseObject.NestedItem == nil {
		t.Fatalf("expected the response objects nested item to have a valid but it didn't")
	}
	if world.ResponseObject.NestedItem.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the response objects nested item to be a string but got %q", string(world.ResponseObject.NestedItem.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response objects nested item to have no reference but got %q", *world.ResponseObject.NestedItem.ReferenceName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningAListOfIntegers(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_ints.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GimmeAListOfIntegers"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeAListOfIntegers")
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionList {
		t.Fatalf("expected the response object to be a list but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResponseObject.NestedItem == nil {
		t.Fatalf("expected the response objects nested item to have a valid but it didn't")
	}
	if world.ResponseObject.NestedItem.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected the response objects nested item to be an integer but got %q", string(world.ResponseObject.NestedItem.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response objects nested item to have no reference but got %q", *world.ResponseObject.NestedItem.ReferenceName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningAListOfAModel(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_model.json")
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

	world, ok := hello.Operations["GimmeAListOfModel"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeAListOfModel")
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionList {
		t.Fatalf("expected the response object to be a list but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResponseObject.NestedItem == nil {
		t.Fatalf("expected the response objects nested item to have a valid but it didn't")
	}
	if world.ResponseObject.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the response objects nested item to be a reference but got %q", string(world.ResponseObject.NestedItem.Type))
	}
	if world.ResponseObject.NestedItem.ReferenceName == nil {
		t.Fatalf("expected the response objects nested item to have a reference but it didn't have one")
	}
	if *world.ResponseObject.NestedItem.ReferenceName != "Person" {
		t.Fatalf("expected the response objects nested item reference to be `Person` but it was %q", *world.ResponseObject.NestedItem.ReferenceName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningAListOfStrings(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_strings.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GimmeAListOfStrings"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeAListOfStrings")
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionList {
		t.Fatalf("expected the response object to be a list but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResponseObject.NestedItem == nil {
		t.Fatalf("expected the response objects nested item to have a valid but it didn't")
	}
	if world.ResponseObject.NestedItem.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the response objects nested item to be a string but got %q", string(world.ResponseObject.NestedItem.Type))
	}
	if world.ResponseObject.NestedItem.ReferenceName != nil {
		t.Fatalf("expected the response objects nested item to have no reference but got %q", *world.ResponseObject.NestedItem.ReferenceName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningAListOfListOfAModel(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_list_of_model.json")
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

	world, ok := hello.Operations["GimmeAListOfListOfAModel"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeAListOfListOfAModel")
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionList {
		t.Fatalf("expected the response object to be a list but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResponseObject.NestedItem == nil {
		t.Fatalf("expected the response objects nested item to have a valid but it didn't")
	}
	if world.ResponseObject.NestedItem.Type != models.ObjectDefinitionList {
		t.Fatalf("expected the response objects nested item to be a list but got %q", string(world.ResponseObject.NestedItem.Type))
	}
	if world.ResponseObject.NestedItem.ReferenceName != nil {
		t.Fatalf("expected the response objects nested item to have no reference but got %q", *world.ResponseObject.NestedItem.ReferenceName)
	}
	if world.ResponseObject.NestedItem.NestedItem == nil {
		t.Fatalf("expected the response objects nested items nested item to have a valid but it didn't")
	}
	if world.ResponseObject.NestedItem.NestedItem.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the response objects nested item to be a reference but got %q", string(world.ResponseObject.NestedItem.NestedItem.Type))
	}
	if world.ResponseObject.NestedItem.NestedItem.ReferenceName == nil {
		t.Fatalf("expected the response objects nested items nested item to have a reference but didn't get one")
	}
	if *world.ResponseObject.NestedItem.NestedItem.ReferenceName != "Person" {
		t.Fatalf("expected the response objects nested item reference to be `Person` but it was %q", *world.ResponseObject.NestedItem.NestedItem.ReferenceName)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleReturningAListOfListOfStrings(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_returning_a_list_of_list_of_strings.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["GimmeAListOfListOfStrings"]
	if !ok {
		t.Fatalf("no resources were output with the name GimmeAListOfStrings")
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
		t.Fatalf("expected a response object but got none")
	}
	if world.ResponseObject.Type != models.ObjectDefinitionList {
		t.Fatalf("expected the response object to be a list but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.ResponseObject.NestedItem == nil {
		t.Fatalf("expected the response objects nested item to have a valid but it didn't")
	}
	if world.ResponseObject.NestedItem.Type != models.ObjectDefinitionList {
		t.Fatalf("expected the response objects nested item to be a list but got %q", string(world.ResponseObject.NestedItem.Type))
	}
	if world.ResponseObject.NestedItem.ReferenceName != nil {
		t.Fatalf("expected the response objects nested item to have no reference but got %q", *world.ResponseObject.NestedItem.ReferenceName)
	}
	if world.ResponseObject.NestedItem.NestedItem == nil {
		t.Fatalf("expected the response objects nested items nested item to have a valid but it didn't")
	}
	if world.ResponseObject.NestedItem.NestedItem.ReferenceName != nil {
		t.Fatalf("expected the response objects nested items nested item to have no reference but got %q", *world.ResponseObject.NestedItem.NestedItem.ReferenceName)
	}
	if world.ResponseObject.NestedItem.NestedItem.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the response objects nested item to be a string but got %q", string(world.ResponseObject.NestedItem.NestedItem.Type))
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds/favourite" {
		t.Fatalf("expected world.UriSuffix to be `/worlds/favourite` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleWithList(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_list.json")
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

	world, ok := hello.Operations["ListWorlds"]
	if !ok {
		t.Fatalf("no resources were output with the name ListWorlds")
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
	if *world.ResponseObject.ReferenceName != "World" {
		t.Fatalf("expected the response object to be 'World' but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.FieldContainingPaginationDetails == nil {
		t.Fatalf("expected there to be pagination details but there weren't")
	}
	if *world.FieldContainingPaginationDetails != "nextLink" {
		t.Fatalf("expected the field containing pagination details to be 'nextLink' but got %q", *world.FieldContainingPaginationDetails)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds" {
		t.Fatalf("expected world.UriSuffix to be `/worlds` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
	if len(world.Options) > 0 {
		t.Fatalf("expected no options (since skipToken isn't directly configurable) but got %d options", len(world.Options))
	}

	worldModel, ok := hello.Models["World"]
	if !ok {
		t.Fatalf("expected there to be a model called World")
	}
	if len(worldModel.Fields) != 1 {
		t.Fatalf("expected the model World to have 1 field but got %d", len(worldModel.Fields))
	}
}

func TestParseOperationSingleWithListWhichIsNotAList(t *testing.T) {
	// all List operations should have an `x-ms-pageable` attribute, but some don't due to bad data
	// as such this checks we can duck-type it out
	result, err := ParseSwaggerFileForTesting(t, "operations_single_list_which_is_not_a_list.json")
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

	world, ok := hello.Operations["ListWorlds"]
	if !ok {
		t.Fatalf("no resources were output with the name ListWorlds")
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
	if *world.ResponseObject.ReferenceName != "World" {
		t.Fatalf("expected the response object to be 'World' but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.FieldContainingPaginationDetails != nil {
		t.Fatalf("expected there to be no pagination details (since this isn't actually a list) but got %q", *world.FieldContainingPaginationDetails)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds" {
		t.Fatalf("expected world.UriSuffix to be `/worlds` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
	if len(world.Options) > 0 {
		t.Fatalf("expected no options (since skipToken isn't directly configurable) but got %d options", len(world.Options))
	}

	worldModel, ok := hello.Models["World"]
	if !ok {
		t.Fatalf("expected there to be a model called World")
	}
	if len(worldModel.Fields) != 1 {
		t.Fatalf("expected the model World to have 1 field but got %d", len(worldModel.Fields))
	}
}

func TestParseOperationSingleWithListReturningAListOfStrings(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_list_of_strings.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected No Model but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["ListWorlds"]
	if !ok {
		t.Fatalf("no resources were output with the name ListWorlds")
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
	if world.ResponseObject.Type != models.ObjectDefinitionString {
		t.Fatalf("expected the response object to be a string but got %q", string(world.ResponseObject.Type))
	}
	if world.ResponseObject.ReferenceName != nil {
		t.Fatalf("expected the response object to have no reference but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.FieldContainingPaginationDetails == nil {
		t.Fatalf("expected there to be pagination details but there weren't")
	}
	if *world.FieldContainingPaginationDetails != "nextLink" {
		t.Fatalf("expected the field containing pagination details to be 'nextLink' but got %q", *world.FieldContainingPaginationDetails)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds" {
		t.Fatalf("expected world.UriSuffix to be `/worlds` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
	if len(world.Options) > 0 {
		t.Fatalf("expected no options (since skipToken isn't directly configurable) but got %d options", len(world.Options))
	}
}

func TestParseOperationSingleWithListWithoutPageable(t *testing.T) {
	// all List operations should have an `x-ms-pageable` attribute, but some don't due to bad data
	// as such this checks we can duck-type it out
	result, err := ParseSwaggerFileForTesting(t, "operations_single_list_without_pageable.json")
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

	world, ok := hello.Operations["ListWorlds"]
	if !ok {
		t.Fatalf("no resources were output with the name ListWorlds")
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
	if *world.ResponseObject.ReferenceName != "World" {
		t.Fatalf("expected the response object to be 'World' but got %q", *world.ResponseObject.ReferenceName)
	}
	if world.FieldContainingPaginationDetails == nil {
		t.Fatalf("expected there to be pagination details but there weren't")
	}
	if *world.FieldContainingPaginationDetails != "nextLink" {
		t.Fatalf("expected the field containing pagination details to be 'nextLink' but got %q", *world.FieldContainingPaginationDetails)
	}
	if world.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix == nil {
		t.Fatal("expected world.UriSuffix to have a value")
	}
	if *world.UriSuffix != "/worlds" {
		t.Fatalf("expected world.UriSuffix to be `/worlds` but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
	if len(world.Options) > 0 {
		t.Fatalf("expected no options (since skipToken isn't directly configurable) but got %d options", len(world.Options))
	}

	worldModel, ok := hello.Models["World"]
	if !ok {
		t.Fatalf("expected there to be a model called World")
	}
	if len(worldModel.Fields) != 1 {
		t.Fatalf("expected the model World to have 1 field but got %d", len(worldModel.Fields))
	}
}

func TestParseOperationSingleWithLongRunningOperation(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_long_running.json")
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

	world, ok := hello.Operations["PutWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name PutWorld")
	}
	if world.Method != "PUT" {
		t.Fatalf("expected a PUT operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObject == nil {
		t.Fatal("expected a request object but didn't get one")
	}
	if world.RequestObject.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the request object to be a reference but got %q", string(world.RequestObject.Type))
	}
	if *world.RequestObject.ReferenceName != "Example" {
		t.Fatalf("expected the request object to be 'Example' but got %q", *world.RequestObject.ReferenceName)
	}
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
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
	if !world.LongRunning {
		t.Fatal("expected a long running operation but it wasn't")
	}

	exampleModel, ok := hello.Models["Example"]
	if !ok {
		t.Fatalf("expected there to be a model called Example")
	}
	if len(exampleModel.Fields) != 1 {
		t.Fatalf("expected the model Example to have 1 field but got %d", len(exampleModel.Fields))
	}
}

func TestParseOperationSingleWithRequestAndResponseObject(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_with_request_and_response_object.json")
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

	world, ok := hello.Operations["PutWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name PutWorld")
	}
	if world.Method != "PUT" {
		t.Fatalf("expected a PUT operation but got %q", world.Method)
	}
	if len(world.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(world.ExpectedStatusCodes))
	}
	if world.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", world.ExpectedStatusCodes[0])
	}
	if world.RequestObject == nil {
		t.Fatal("expected a request object but didn't get one")
	}
	if world.RequestObject.Type != models.ObjectDefinitionReference {
		t.Fatalf("expected the request object to be a reference but got %q", string(world.RequestObject.Type))
	}
	if *world.RequestObject.ReferenceName != "Example" {
		t.Fatalf("expected the request object to be 'Example' but got %q", *world.RequestObject.ReferenceName)
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
	if len(exampleModel.Fields) != 1 {
		t.Fatalf("expected the model Example to have 1 field but got %d", len(exampleModel.Fields))
	}
}

func TestParseOperationSingleWithMultipleTags(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_multiple_tags.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 2 {
		t.Fatalf("expected 2 resources but got %d", len(result.Resources))
	}

	hello, ok := result.Resources["Hello"]
	if !ok {
		t.Fatalf("no resources were output with the tag Hello")
	}

	if len(hello.Constants) != 0 {
		t.Fatalf("expected no Constants but got %d", len(hello.Constants))
	}
	if len(hello.Models) != 0 {
		t.Fatalf("expected no Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	things, ok := hello.Operations["HeadThings"]
	if !ok {
		t.Fatalf("no resources were output with the name HeadThings")
	}
	if things.Method != "HEAD" {
		t.Fatalf("expected a HEAD operation but got %q", things.Method)
	}
	if len(things.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(things.ExpectedStatusCodes))
	}
	if things.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", things.ExpectedStatusCodes[0])
	}
	if things.RequestObject != nil {
		t.Fatalf("expected no request object but got %+v", *things.RequestObject)
	}
	if things.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *things.ResponseObject)
	}
	if things.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *things.ResourceIdName)
	}
	if things.UriSuffix == nil {
		t.Fatal("expected things.UriSuffix to have a value")
	}
	if *things.UriSuffix != "/things" {
		t.Fatalf("expected things.UriSuffix to be `/things` but got %q", *things.UriSuffix)
	}
	if things.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}

	// then validate it in Other too
	other, ok := result.Resources["Other"]
	if !ok {
		t.Fatalf("no resources were output with the tag Other")
	}

	if len(hello.Constants) != 0 {
		t.Fatalf("expected no Constants but got %d", len(hello.Constants))
	}
	if len(hello.Models) != 0 {
		t.Fatalf("expected no Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	// whilst the operation name should be `HeadThings`, since this is another Tag
	// it's intentionally prefixed for when things cross boundaries (to avoid conflicts)
	things, ok = other.Operations["HelloHeadThings"]
	if !ok {
		t.Fatalf("no resources were output with the name HelloHeadThings")
	}
	if things.Method != "HEAD" {
		t.Fatalf("expected a HEAD operation but got %q", things.Method)
	}
	if len(things.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(things.ExpectedStatusCodes))
	}
	if things.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", things.ExpectedStatusCodes[0])
	}
	if things.RequestObject != nil {
		t.Fatalf("expected no request object but got %+v", *things.RequestObject)
	}
	if things.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *things.ResponseObject)
	}
	if things.ResourceIdName != nil {
		t.Fatalf("expected no ResourceId but got %q", *things.ResourceIdName)
	}
	if things.UriSuffix == nil {
		t.Fatal("expected things.UriSuffix to have a value")
	}
	if *things.UriSuffix != "/things" {
		t.Fatalf("expected things.UriSuffix to be `/things` but got %q", *things.UriSuffix)
	}
	if things.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleWithNoTag(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_with_no_tag.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	// since there's no tags, the Client name is used (in this case, 'Example')
	example, ok := result.Resources["Example"]
	if !ok {
		t.Fatalf("no resources were output with the tag Example")
	}

	if len(example.Constants) != 0 {
		t.Fatalf("expected no Constants but got %d", len(example.Constants))
	}
	if len(example.Models) != 0 {
		t.Fatalf("expected no Models but got %d", len(example.Models))
	}
	if len(example.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(example.Operations))
	}
	if len(example.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(example.ResourceIds))
	}

	// since the prefix doesn't match the Tag (since no tag) this gets a combined name
	world, ok := example.Operations["HelloHeadWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name HelloHeadWorld")
	}
	if world.Method != "HEAD" {
		t.Fatalf("expected a HEAD operation but got %q", world.Method)
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
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
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
}

func TestParseOperationSingleWithHeaderOptions(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_with_header_options.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected no Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["HeadWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name HeadWorld")
	}
	if world.Method != "HEAD" {
		t.Fatalf("expected a HEAD operation but got %q", world.Method)
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
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
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

	if len(world.Options) != 6 {
		t.Fatalf("expected HeadWorld to have 6 options but got %d", len(world.Options))
	}

	boolOption, ok := world.Options["BoolValue"]
	if !ok {
		t.Fatalf("expected HeadWorld Options to contain 'BoolValue' but didn't get it")
	}
	if boolOption.ObjectDefinition.Type != models.ObjectDefinitionBoolean {
		t.Fatalf("expected HeadWorld Option 'BoolValue' to be a Boolean but got %q", string(boolOption.ObjectDefinition.Type))
	}
	if boolOption.QueryStringName != nil {
		t.Fatalf("expected HeadWorld Option 'BoolValue's QueryStringName to be nil but got %q", *boolOption.QueryStringName)
	}
	if boolOption.HeaderName == nil {
		t.Fatalf("expected HeadWorld Option 'BoolValue's QueryStringName to be `boolValue` but was nil")
	}
	if boolOption.HeaderName != nil && *boolOption.HeaderName != "boolValue" {
		t.Fatalf("expected HeadWorld Option 'BoolValue's HeaderName to be `boolValue` but got %q", *boolOption.HeaderName)
	}

	csvOfDoubleValueOption, ok := world.Options["CsvOfDoubleValue"]
	if !ok {
		t.Fatalf("expected HeadWorld Options to contain 'CsvOfDoubleValue' but didn't get it")
	}
	if csvOfDoubleValueOption.ObjectDefinition.Type != models.ObjectDefinitionCsv {
		t.Fatalf("expected HeadWorld Option 'CsvOfDoubleValue' to be a Csv but got %q", string(csvOfDoubleValueOption.ObjectDefinition.Type))
	}
	if csvOfDoubleValueOption.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionFloat {
		t.Fatalf("expected HeadWorld Option 'CsvOfDoubleValue's Nested Type to be a Float but got %q", string(csvOfDoubleValueOption.ObjectDefinition.NestedItem.Type))
	}
	if csvOfDoubleValueOption.QueryStringName != nil {
		t.Fatalf("expected HeadWorld Option 'CsvOfDoubleValue's QueryStringName to be nil but got %q", *csvOfDoubleValueOption.QueryStringName)
	}
	if csvOfDoubleValueOption.HeaderName == nil {
		t.Fatalf("expected HeadWorld Option 'CsvOfDoubleValue's HeaderName to be `csvOfDoubleValue` but was nil")
	}
	if csvOfDoubleValueOption.HeaderName != nil && *csvOfDoubleValueOption.HeaderName != "csvOfDoubleValue" {
		t.Fatalf("expected HeadWorld Option 'CsvOfDoubleValue's HeaderName to be `csvOfDoubleValue` but got %q", *csvOfDoubleValueOption.HeaderName)
	}

	csvOfStringOption, ok := world.Options["CsvOfStringValue"]
	if !ok {
		t.Fatalf("expected HeadWorld Options to contain 'CsvOfStringValue' but didn't get it")
	}
	if csvOfStringOption.ObjectDefinition.Type != models.ObjectDefinitionCsv {
		t.Fatalf("expected HeadWorld Option 'CsvOfStringValue' to be a Csv but got %q", string(csvOfStringOption.ObjectDefinition.Type))
	}
	if csvOfStringOption.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionString {
		t.Fatalf("expected HeadWorld Option 'CsvOfStringValue's Nested Type to be a String but got %q", string(csvOfStringOption.ObjectDefinition.NestedItem.Type))
	}
	if csvOfStringOption.QueryStringName != nil {
		t.Fatalf("expected HeadWorld Option 'CsvOfStringValue's QueryStringName to be nil but got %q", *csvOfStringOption.QueryStringName)
	}
	if csvOfStringOption.HeaderName == nil {
		t.Fatalf("expected HeadWorld Option 'CsvOfStringValue's HeaderName to be `csvOfStringValue` but was nil")
	}
	if csvOfStringOption.HeaderName != nil && *csvOfStringOption.HeaderName != "csvOfStringValue" {
		t.Fatalf("expected HeadWorld Option 'CsvOfStringValue's HeaderName to be `csvOfStringValue` but got %q", *csvOfStringOption.HeaderName)
	}

	doubleOption, ok := world.Options["DoubleValue"]
	if !ok {
		t.Fatalf("expected HeadWorld Options to contain 'DoubleValue' but didn't get it")
	}
	if doubleOption.ObjectDefinition.Type != models.ObjectDefinitionFloat {
		t.Fatalf("expected HeadWorld Option 'DoubleValue' to be a Float but got %q", string(doubleOption.ObjectDefinition.Type))
	}
	if doubleOption.QueryStringName != nil {
		t.Fatalf("expected HeadWorld Option 'DoubleValue's QueryStringName to be nil but got %q", *doubleOption.QueryStringName)
	}
	if doubleOption.HeaderName == nil {
		t.Fatalf("expected HeadWorld Option 'DoubleValue's HeaderName to be `doubleValue` but was nil")
	}
	if doubleOption.HeaderName != nil && *doubleOption.HeaderName != "doubleValue" {
		t.Fatalf("expected HeadWorld Option 'DoubleValue's HeaderName to be `doubleValue` but got %q", *doubleOption.HeaderName)
	}

	intOption, ok := world.Options["IntValue"]
	if !ok {
		t.Fatalf("expected HeadWorld Options to contain 'IntValue' but didn't get it")
	}
	if intOption.ObjectDefinition.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected HeadWorld Option 'IntValue' to be a Integer but got %q", string(intOption.ObjectDefinition.Type))
	}
	if intOption.QueryStringName != nil {
		t.Fatalf("expected HeadWorld Option 'IntValue's QueryStringName to be nil but got %q", *intOption.QueryStringName)
	}
	if intOption.HeaderName == nil {
		t.Fatalf("expected HeadWorld Option 'IntValue's HeaderName to be `intValue` but was nil")
	}
	if intOption.HeaderName != nil && *intOption.HeaderName != "intValue" {
		t.Fatalf("expected HeadWorld Option 'IntValue's HeaderName to be `intValue` but got %q", *intOption.HeaderName)
	}

	stringOption, ok := world.Options["StringValue"]
	if !ok {
		t.Fatalf("expected HeadWorld Options to contain 'StringValue' but didn't get it")
	}
	if stringOption.ObjectDefinition.Type != models.ObjectDefinitionString {
		t.Fatalf("expected HeadWorld Option 'StringValue' to be a String but got %q", string(stringOption.ObjectDefinition.Type))
	}
	if stringOption.QueryStringName != nil {
		t.Fatalf("expected HeadWorld Option 'StringValue's QueryStringName to be nil but got %q", *stringOption.QueryStringName)
	}
	if stringOption.HeaderName == nil {
		t.Fatalf("expected HeadWorld Option 'StringValue's HeaderName to be `stringValue` but was nil")
	}
	if stringOption.HeaderName != nil && *stringOption.HeaderName != "stringValue" {
		t.Fatalf("expected HeadWorld Option 'StringValue's HeaderName to be `stringValue` but got %q", *stringOption.HeaderName)
	}
}

func TestParseOperationSingleWithQueryStringOptions(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_with_querystring_options.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected no Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 1 {
		t.Fatalf("expected 1 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 0 {
		t.Fatalf("expected no ResourceIds but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["HeadWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name HeadWorld")
	}
	if world.Method != "HEAD" {
		t.Fatalf("expected a HEAD operation but got %q", world.Method)
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
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
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

	if len(world.Options) != 6 {
		t.Fatalf("expected HeadWorld to have 6 options but got %d", len(world.Options))
	}

	boolOption, ok := world.Options["BoolValue"]
	if !ok {
		t.Fatalf("expected HeadWorld Options to contain 'BoolValue' but didn't get it")
	}
	if boolOption.ObjectDefinition.Type != models.ObjectDefinitionBoolean {
		t.Fatalf("expected HeadWorld Option 'BoolValue' to be a Boolean but got %q", string(boolOption.ObjectDefinition.Type))
	}
	if boolOption.HeaderName != nil {
		t.Fatalf("expected HeadWorld Option 'BoolValue's HeaderName to be nil but got %q", *boolOption.HeaderName)
	}
	if boolOption.QueryStringName == nil {
		t.Fatalf("expected HeadWorld Option 'BoolValue's QueryStringName to be `boolValue` but was nil")
	}
	if boolOption.QueryStringName != nil && *boolOption.QueryStringName != "boolValue" {
		t.Fatalf("expected HeadWorld Option 'BoolValue's QueryStringName to be `boolValue` but got %q", *boolOption.QueryStringName)
	}

	csvOfDoubleValueOption, ok := world.Options["CsvOfDoubleValue"]
	if !ok {
		t.Fatalf("expected HeadWorld Options to contain 'CsvOfDoubleValue' but didn't get it")
	}
	if csvOfDoubleValueOption.ObjectDefinition.Type != models.ObjectDefinitionCsv {
		t.Fatalf("expected HeadWorld Option 'CsvOfDoubleValue' to be a Csv but got %q", string(csvOfDoubleValueOption.ObjectDefinition.Type))
	}
	if csvOfDoubleValueOption.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionFloat {
		t.Fatalf("expected HeadWorld Option 'CsvOfDoubleValue's Nested Type to be a Float but got %q", string(csvOfDoubleValueOption.ObjectDefinition.NestedItem.Type))
	}
	if csvOfDoubleValueOption.HeaderName != nil {
		t.Fatalf("expected HeadWorld Option 'CsvOfDoubleValue's HeaderName to be nil but got %q", *csvOfDoubleValueOption.HeaderName)
	}
	if csvOfDoubleValueOption.QueryStringName == nil {
		t.Fatalf("expected HeadWorld Option 'CsvOfDoubleValue's QueryStringName to be `csvOfDoubleValue` but was nil")
	}
	if csvOfDoubleValueOption.QueryStringName != nil && *csvOfDoubleValueOption.QueryStringName != "csvOfDoubleValue" {
		t.Fatalf("expected HeadWorld Option 'CsvOfDoubleValue's QueryStringName to be `csvOfDoubleValue` but got %q", *csvOfDoubleValueOption.QueryStringName)
	}

	csvOfStringOption, ok := world.Options["CsvOfStringValue"]
	if !ok {
		t.Fatalf("expected HeadWorld Options to contain 'CsvOfStringValue' but didn't get it")
	}
	if csvOfStringOption.ObjectDefinition.Type != models.ObjectDefinitionCsv {
		t.Fatalf("expected HeadWorld Option 'CsvOfStringValue' to be a Csv but got %q", string(csvOfStringOption.ObjectDefinition.Type))
	}
	if csvOfStringOption.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionString {
		t.Fatalf("expected HeadWorld Option 'CsvOfStringValue's Nested Type to be a String but got %q", string(csvOfStringOption.ObjectDefinition.NestedItem.Type))
	}
	if csvOfStringOption.HeaderName != nil {
		t.Fatalf("expected HeadWorld Option 'CsvOfStringValue's HeaderName to be nil but got %q", *csvOfStringOption.HeaderName)
	}
	if csvOfStringOption.QueryStringName == nil {
		t.Fatalf("expected HeadWorld Option 'CsvOfStringValue's QueryStringName to be `csvOfStringValue` but was nil")
	}
	if csvOfStringOption.QueryStringName != nil && *csvOfStringOption.QueryStringName != "csvOfStringValue" {
		t.Fatalf("expected HeadWorld Option 'CsvOfStringValue's QueryStringName to be `csvOfStringValue` but got %q", *csvOfStringOption.QueryStringName)
	}

	doubleOption, ok := world.Options["DoubleValue"]
	if !ok {
		t.Fatalf("expected HeadWorld Options to contain 'DoubleValue' but didn't get it")
	}
	if doubleOption.ObjectDefinition.Type != models.ObjectDefinitionFloat {
		t.Fatalf("expected HeadWorld Option 'DoubleValue' to be a Float but got %q", string(doubleOption.ObjectDefinition.Type))
	}
	if doubleOption.HeaderName != nil {
		t.Fatalf("expected HeadWorld Option 'DoubleValue's HeaderName to be nil but got %q", *doubleOption.HeaderName)
	}
	if doubleOption.QueryStringName == nil {
		t.Fatalf("expected HeadWorld Option 'DoubleValue's QueryStringName to be `doubleValue` but was nil")
	}
	if doubleOption.QueryStringName != nil && *doubleOption.QueryStringName != "doubleValue" {
		t.Fatalf("expected HeadWorld Option 'DoubleValue's QueryStringName to be `doubleValue` but got %q", *doubleOption.QueryStringName)
	}

	intOption, ok := world.Options["IntValue"]
	if !ok {
		t.Fatalf("expected HeadWorld Options to contain 'IntValue' but didn't get it")
	}
	if intOption.ObjectDefinition.Type != models.ObjectDefinitionInteger {
		t.Fatalf("expected HeadWorld Option 'IntValue' to be a Integer but got %q", string(intOption.ObjectDefinition.Type))
	}
	if intOption.HeaderName != nil {
		t.Fatalf("expected HeadWorld Option 'IntValue's HeaderName to be nil but got %q", *intOption.HeaderName)
	}
	if intOption.QueryStringName == nil {
		t.Fatalf("expected HeadWorld Option 'IntValue's QueryStringName to be `intValue` but was nil")
	}
	if intOption.QueryStringName != nil && *intOption.QueryStringName != "intValue" {
		t.Fatalf("expected HeadWorld Option 'IntValue's QueryStringName to be `intValue` but got %q", *intOption.QueryStringName)
	}

	stringOption, ok := world.Options["StringValue"]
	if !ok {
		t.Fatalf("expected HeadWorld Options to contain 'StringValue' but didn't get it")
	}
	if stringOption.ObjectDefinition.Type != models.ObjectDefinitionString {
		t.Fatalf("expected HeadWorld Option 'StringValue' to be a String but got %q", string(stringOption.ObjectDefinition.Type))
	}
	if stringOption.HeaderName != nil {
		t.Fatalf("expected HeadWorld Option 'StringValue's HeaderName to be nil but got %q", *stringOption.HeaderName)
	}
	if stringOption.QueryStringName == nil {
		t.Fatalf("expected HeadWorld Option 'StringValue's QueryStringName to be `stringValue` but was nil")
	}
	if stringOption.QueryStringName != nil && *stringOption.QueryStringName != "stringValue" {
		t.Fatalf("expected HeadWorld Option 'StringValue's QueryStringName to be `stringValue` but got %q", *stringOption.QueryStringName)
	}
}

func TestParseOperationMultipleBasedOnTheSameResourceId(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_multiple_same_resource_id.json")
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
	if len(hello.Models) != 0 {
		t.Fatalf("expected no Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 2 {
		t.Fatalf("expected 2 Operations but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 1 {
		t.Fatalf("expected 1 ResourceId but got %d", len(hello.ResourceIds))
	}

	world, ok := hello.Operations["HeadWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name HeadWorld")
	}
	if world.Method != "HEAD" {
		t.Fatalf("expected a HEAD operation but got %q", world.Method)
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
	if world.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *world.ResponseObject)
	}
	if world.ResourceIdName == nil {
		t.Fatal("expected a ResourceId but was nil")
	}
	if *world.ResourceIdName != "ThingId" {
		t.Fatalf("expected world.ResourceIdName to be 'Thing' but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix != nil {
		t.Fatalf("expected world.UriSuffix to be nil but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}

	restart, ok := hello.Operations["RestartWorld"]
	if !ok {
		t.Fatalf("no resources were output with the name RestartWorld")
	}
	if restart.Method != "HEAD" {
		t.Fatalf("expected a HEAD operation but got %q", restart.Method)
	}
	if len(restart.ExpectedStatusCodes) != 1 {
		t.Fatalf("expected 1 status code but got %d", len(restart.ExpectedStatusCodes))
	}
	if restart.ExpectedStatusCodes[0] != 200 {
		t.Fatalf("expected the status code to be 200 but got %d", restart.ExpectedStatusCodes[0])
	}
	if restart.RequestObject != nil {
		t.Fatalf("expected no request object but got %+v", *restart.RequestObject)
	}
	if restart.ResponseObject != nil {
		t.Fatalf("expected no response object but got %+v", *restart.ResponseObject)
	}
	if restart.ResourceIdName == nil {
		t.Fatal("expected a ResourceId but was nil")
	}
	if *restart.ResourceIdName != "ThingId" {
		t.Fatalf("expected restart.RessourceIdName to be 'Thing' but got %q", *restart.ResourceIdName)
	}
	if restart.UriSuffix == nil {
		t.Fatal("expected restart.UriSuffix to have a value but it was nil")
	}
	if *restart.UriSuffix != "/restart" {
		t.Fatalf("expected restart.UriSuffix to be `/restart` but got %q", *restart.UriSuffix)
	}
	if restart.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}
