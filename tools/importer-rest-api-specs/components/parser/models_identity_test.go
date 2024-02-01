package parser

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// TODO: one of each which doesn't match to confirm the negative case

func TestModelsWithASystemAssignedIdentity(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_system_assigned.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemAssignedIdentity {
		t.Fatalf("expected the field Identity to have a CustomFieldType of SystemAssignedIdentity")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemAssignedIdentityInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_system_assigned_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemAssignedIdentity {
		t.Fatalf("expected the field Identity to have a CustomFieldType of SystemAssignedIdentity")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithALegacySystemAndUserAssignedListIdentity(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_legacy_system_and_user_assigned_list.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeLegacySystemAndUserAssignedIdentityList {
		t.Fatalf("expected the field Identity to have a CustomFieldType of LegacySystemAndUserAssignedIdentityList")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithALegacySystemAndUserAssignedListIdentityInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_legacy_system_and_user_assigned_list_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeLegacySystemAndUserAssignedIdentityList {
		t.Fatalf("expected the field Identity to have a CustomFieldType of LegacySystemAndUserAssignedIdentityList")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithALegacySystemAndUserAssignedMapIdentity(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_legacy_system_and_user_assigned_map.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of LegacySystemAndUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithALegacySystemAndUserAssignedMapIdentityExtraFields(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having extra fields
	// in the user assigned identity block (#1066) - for example an extra `appId`
	result, err := ParseSwaggerFileForTesting(t, "model_legacy_system_and_user_assigned_map_extrafields.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of CustomFieldTypeLegacySystemAndUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithALegacySystemAndUserAssignedMapIdentityExtraFieldsInlined(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having extra fields
	// in the user assigned identity block (#1066) - for example an extra `appId`
	result, err := ParseSwaggerFileForTesting(t, "model_legacy_system_and_user_assigned_map_extrafields_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of CustomFieldTypeLegacySystemAndUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithALegacySystemAndUserAssignedMapIdentityInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_legacy_system_and_user_assigned_map_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of LegacySystemAndUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithALegacySystemAndUserAssignedMapIdentityGenericDictionary(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_legacy_system_and_user_assigned_map_generic_dictionary.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of LegacySystemAndUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithALegacySystemAndUserAssignedMapIdentityGenericDictionaryInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_legacy_system_and_user_assigned_map_generic_dictionary_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of LegacySystemAndUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemAndUserAssignedListIdentity(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_system_and_user_assigned_list.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemAndUserAssignedIdentityList {
		t.Fatalf("expected the field Identity to have a CustomFieldType of SystemAndUserAssignedIdentityList")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemAndUserAssignedListIdentityInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_system_and_user_assigned_list_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemAndUserAssignedIdentityList {
		t.Fatalf("expected the field Identity to have a CustomFieldType of SystemAndUserAssignedIdentityList")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemAndUserAssignedMapIdentity(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_system_and_user_assigned_map.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemAndUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of SystemAndUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemAndUserAssignedMapIdentityExtraFields(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having extra fields
	// in the user assigned identity block (#1066) - for example an extra `appId`
	result, err := ParseSwaggerFileForTesting(t, "model_system_and_user_assigned_map_extrafields.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemAndUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of CustomFieldTypeSystemAndUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemAndUserAssignedMapIdentityExtraFieldsInlined(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having extra fields
	// in the user assigned identity block (#1066) - for example an extra `appId`
	result, err := ParseSwaggerFileForTesting(t, "model_system_and_user_assigned_map_extrafields_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemAndUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of CustomFieldTypeSystemAndUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemAndUserAssignedMapIdentityInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_system_and_user_assigned_map_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemAndUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of SystemAndUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemOrUserAssignedListIdentity(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_system_or_user_assigned_list.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemOrUserAssignedIdentityList {
		t.Fatalf("expected the field Identity to have a CustomFieldType of SystemOrUserAssignedIdentityList")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemOrUserAssignedListIdentityInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_system_or_user_assigned_list_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemOrUserAssignedIdentityList {
		t.Fatalf("expected the field Identity to have a CustomFieldType of SystemOrUserAssignedIdentityList")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemOrUserAssignedMapIdentity(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_system_or_user_assigned_map.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemOrUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of SystemOrUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemOrUserAssignedMapIdentityExtraFields(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having extra fields
	// in the user assigned identity block (#1066) - for example an extra `appId`
	result, err := ParseSwaggerFileForTesting(t, "model_system_or_user_assigned_map_extrafields.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemOrUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of CustomFieldTypeSystemOrUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemOrUserAssignedMapIdentityExtraFieldsInlined(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having extra fields
	// in the user assigned identity block (#1066) - for example an extra `appId`
	result, err := ParseSwaggerFileForTesting(t, "model_system_or_user_assigned_map_extrafields_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemOrUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of CustomFieldTypeSystemOrUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemOrUserAssignedMapIdentityInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_system_or_user_assigned_map_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemOrUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of SystemOrUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithASystemOrUserAssignedMapIdentityWithDelegatedResources(t *testing.T) {
	// this handles the scenario of a System Assigned & User Assigned model having a DelegatedResources block
	result, err := ParseSwaggerFileForTesting(t, "model_system_or_user_assigned_map_with_delegated_resources.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeSystemOrUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of SystemOrUserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithAUserAssignedListIdentity(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_user_assigned_list.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeUserAssignedIdentityList {
		t.Fatalf("expected the field Identity to have a CustomFieldType of UserAssignedIdentityList")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithAUserAssignedListIdentityInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_user_assigned_list_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeUserAssignedIdentityList {
		t.Fatalf("expected the field Identity to have a CustomFieldType of UserAssignedIdentityList")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithAUserAssignedMapIdentity(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_user_assigned_map.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of UserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithAUserAssignedMapIdentityInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_user_assigned_map_inlined.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of UserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithAUserAssignedMapIdentityWithTenantId(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_user_assigned_map_with_tenant_id.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of UserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithAUserAssignedMapIdentityWithPrincipalId(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_user_assigned_map_with_principal_id.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType == nil {
		t.Fatalf("expected the field Identity to have a CustomFieldType")
	}
	if *identityField.CustomFieldType != models.CustomFieldTypeUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to have a CustomFieldType of UserAssignedIdentityMap")
	}
	if identityField.ObjectDefinition != nil {
		t.Fatalf("expected the field Identity to have no ObjectDefinition")
	}
}

func TestModelsWithAUserAssignedMapIdentityWithAdditionalFields(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_user_assigned_map_with_additional_field.json")
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
	identityField, ok := exampleModel.Fields["Identity"]
	if !ok {
		t.Fatalf("expected there to be a field called Identity")
	}
	if identityField.CustomFieldType != nil && *identityField.CustomFieldType == models.CustomFieldTypeUserAssignedIdentityMap {
		t.Fatalf("expected the field Identity to not have a CustomFieldType of UserAssignedIdentityMap")
	}
}
