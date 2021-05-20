package parser

import "testing"

func TestParseOperationsEmpty(t *testing.T) {
	parsed, err := Load("testdata/", "operations_empty.json", true)
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
	if len(result.Resources) != 0 {
		t.Fatalf("expected no resources but got %d", len(result.Resources))
	}
}

func TestParseOperationSingleWithTag(t *testing.T) {
	parsed, err := Load("testdata/", "operations_single_with_tag.json", true)
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
	if world.RequestObjectName != nil {
		t.Fatalf("expected no request object but got %q", *world.RequestObjectName)
	}
	if world.ResponseObjectName != nil {
		t.Fatalf("expected no response object but got %q", *world.ResponseObjectName)
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
	parsed, err := Load("testdata/", "operations_single_with_tag_resource_id.json", true)
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
	if world.RequestObjectName != nil {
		t.Fatalf("expected no request object but got %q", *world.RequestObjectName)
	}
	if world.ResponseObjectName != nil {
		t.Fatalf("expected no response object but got %q", *world.ResponseObjectName)
	}
	if world.ResourceIdName == nil {
		t.Fatal("expected a ResourceId but was nil")
	}
	if *world.ResourceIdName != "ThingId" {
		t.Fatalf("expected world.RessourceIdName to be 'Thing' but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix != nil {
		t.Fatalf("expected world.UriSuffix to be nil but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}
}

func TestParseOperationSingleWithTagAndResourceIdSuffix(t *testing.T) {
	parsed, err := Load("testdata/", "operations_single_with_tag_resource_id_suffix.json", true)
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
	if world.RequestObjectName != nil {
		t.Fatalf("expected no request object but got %q", *world.RequestObjectName)
	}
	if world.ResponseObjectName != nil {
		t.Fatalf("expected no response object but got %q", *world.ResponseObjectName)
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
	parsed, err := Load("testdata/", "operations_single_with_request_object.json", true)
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
	if world.RequestObjectName == nil {
		t.Fatal("expected a request object but was nil")
	}
	if *world.RequestObjectName != "Example" {
		t.Fatalf("expected the request object to be 'Example' but got %q", *world.RequestObjectName)
	}
	if world.ResponseObjectName != nil {
		t.Fatalf("expected no response object but got %q", *world.ResponseObjectName)
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
	parsed, err := Load("testdata/", "operations_single_with_response_object.json", true)
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
	if len(exampleModel.Fields) != 1 {
		t.Fatalf("expected the model Example to have 1 field but got %d", len(exampleModel.Fields))
	}
}

func TestParseOperationSingleWithLongRunningOperation(t *testing.T) {
	parsed, err := Load("testdata/", "operations_single_long_running.json", true)
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
	if world.RequestObjectName == nil {
		t.Fatal("expected a request object but didn't get one")
	}
	if *world.RequestObjectName != "Example" {
		t.Fatalf("expected the request object to be 'Example' but got %q", *world.RequestObjectName)
	}
	if world.ResponseObjectName != nil {
		t.Fatalf("expected no response object but got %q", *world.ResponseObjectName)
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
	parsed, err := Load("testdata/", "operations_single_with_request_and_response_object.json", true)
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
	if world.RequestObjectName == nil {
		t.Fatal("expected a request object but didn't get one")
	}
	if *world.RequestObjectName != "Example" {
		t.Fatalf("expected the request object to be 'Example' but got %q", *world.RequestObjectName)
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
	if len(exampleModel.Fields) != 1 {
		t.Fatalf("expected the model Example to have 1 field but got %d", len(exampleModel.Fields))
	}
}

func TestParseOperationSingleWithMultipleTags(t *testing.T) {
	// TODO: a placeholder for now
	t.Fail()
}

func TestParseOperationSingleWithNoTag(t *testing.T) {
	// TODO: a placeholder for now
	t.Fail()
}

func TestParseOperationMultipleBasedOnTheSameResourceId(t *testing.T) {
	parsed, err := Load("testdata/", "operations_multiple_same_resource_id.json", true)
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
	if world.RequestObjectName != nil {
		t.Fatalf("expected no request object but got %q", *world.RequestObjectName)
	}
	if world.ResponseObjectName != nil {
		t.Fatalf("expected no response object but got %q", *world.ResponseObjectName)
	}
	if world.ResourceIdName == nil {
		t.Fatal("expected a ResourceId but was nil")
	}
	if *world.ResourceIdName != "ThingId" {
		t.Fatalf("expected world.RessourceIdName to be 'Thing' but got %q", *world.ResourceIdName)
	}
	if world.UriSuffix != nil {
		t.Fatalf("expected world.UriSuffix to be nil but got %q", *world.UriSuffix)
	}
	if world.LongRunning {
		t.Fatal("expected a non-long running operation but it was long running")
	}

	restart, ok := hello.Operations["HeadRestart"]
	if !ok {
		t.Fatalf("no resources were output with the name HeadRestart")
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
	if restart.RequestObjectName != nil {
		t.Fatalf("expected no request object but got %q", *restart.RequestObjectName)
	}
	if restart.ResponseObjectName != nil {
		t.Fatalf("expected no response object but got %q", *restart.ResponseObjectName)
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
