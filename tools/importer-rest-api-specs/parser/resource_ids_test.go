package parser

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/featureflags"
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseResourceIdBasic(t *testing.T) {
	parsed, err := Load("testdata/", "resource_ids_basic.json", true)
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

	hello, ok := result.Resources["Example"]
	if !ok {
		t.Fatalf("no resources were output with the tag Example")
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

	// first check the ResourceId looks good
	expectedValue := "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SomeResourceProvider/servers/{serverName}"
	actualValue, ok := hello.ResourceIds["ServerId"]
	if !ok {
		t.Fatalf("expected a ResourceId named ServerId but didn't get one")
	}
	// TODO: update this to be the output type we expect
	if actualValue != expectedValue {
		t.Fatalf("expected the ServerId ResourceId to match %q but got %q", expectedValue, actualValue)
	}

	// then check it's exposed in the operation itself
	operation, ok := hello.Operations["Test"]
	if !ok {
		t.Fatalf("expected there to be an Operation named Test but didn't get one")
	}
	if operation.ResourceIdName == nil {
		t.Fatalf("expected the ResourceIdName for the Operation Test to have a value but didn't get one")
	}
	if *operation.ResourceIdName != "ServerId" {
		t.Fatalf("expected the ResourceIdName for the Operation Test to be ServerId but got %q", *operation.ResourceIdName)
	}
	if operation.UriSuffix != nil {
		t.Fatalf("expected the UriSuffix for the Operation Test to have no value but got %q", *operation.UriSuffix)
	}
}

func TestParseResourceIdContainingAConstant(t *testing.T) {
	parsed, err := Load("testdata/", "resource_ids_containing_constant.json", true)
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

	hello, ok := result.Resources["Example"]
	if !ok {
		t.Fatalf("no resources were output with the tag Example")
	}

	if len(hello.Constants) != 1 {
		t.Fatalf("expected 1 Constant but got %d", len(hello.Constants))
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

	// first check the ResourceId looks good
	expectedValue := "/planets/{planetName}"
	actualValue, ok := hello.ResourceIds["PlanetId"]
	if !ok {
		t.Fatalf("expected a ResourceId named PlanetId but didn't get one")
	}
	// TODO: update this to be the output type we expect
	if actualValue != expectedValue {
		t.Fatalf("expected the PlanetId ResourceId to match %q but got %q", expectedValue, actualValue)
	}

	constant, ok := hello.Constants["Planet"]
	if !ok {
		t.Fatalf("expected there to be a Constant named Planet")
	}
	if constant.FieldType != models.StringConstant {
		t.Fatalf("expected the Constant Planet to be a String but got %q", string(constant.FieldType))
	}
	if len(constant.Values) != 4 {
		t.Fatalf("expected there to be 4 values for Planets but got %d", len(constant.Values))
	}

	// then check it's exposed in the operation itself
	operation, ok := hello.Operations["OperationContainingAConstant"]
	if !ok {
		t.Fatalf("expected there to be an Operation named OperationContainingAConstant but didn't get one")
	}
	if operation.ResourceIdName == nil {
		t.Fatalf("expected the ResourceIdName for the Operation OperationContainingAConstant to have a value but didn't get one")
	}
	if *operation.ResourceIdName != "PlanetId" {
		t.Fatalf("expected the ResourceIdName for the Operation OperationContainingAConstant to be PlanetId but got %q", *operation.ResourceIdName)
	}
	if operation.UriSuffix != nil {
		t.Fatalf("expected the UriSuffix for the Operation OperationContainingAConstant to have no value but got %q", *operation.UriSuffix)
	}
}

func TestParseResourceIdContainingAScope(t *testing.T) {
	if !featureflags.ParseResourcesContainingScopes {
		t.Skipf("Scopes are disabled via the Feature FLag - so this test will fail - skipping temporarily")
	}

	parsed, err := Load("testdata/", "resource_ids_containing_scope.json", true)
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

	hello, ok := result.Resources["Example"]
	if !ok {
		t.Fatalf("no resources were output with the tag Example")
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

	// first check the ResourceId looks good
	expectedValue := "/{scope}/providers/Microsoft.FooBar/virtualMachines/{virtualMachineName}" // NOTE: this has to have a leading slash to be valid in Swagger
	actualValue, ok := hello.ResourceIds["ScopedVirtualMachineId"]
	if !ok {
		t.Fatalf("expected a ResourceId named ScopedVirtualMachineId but didn't get one")
	}
	// TODO: update this to be the output type we expect
	if actualValue != expectedValue {
		t.Fatalf("expected the ScopedVirtualMachineId ResourceId to match %q but got %q", expectedValue, actualValue)
	}

	// then check it's exposed in the operation itself
	operation, ok := hello.Operations["OperationContainingAScope"]
	if !ok {
		t.Fatalf("expected there to be an Operation named OperationContainingAScope but didn't get one")
	}
	if operation.ResourceIdName == nil {
		t.Fatalf("expected the ResourceIdName for the Operation OperationContainingAScope to have a value but didn't get one")
	}
	if *operation.ResourceIdName != "ScopedVirtualMachineId" {
		t.Fatalf("expected the ResourceIdName for the Operation OperationContainingAScope to be ScopedVirtualMachineId but got %q", *operation.ResourceIdName)
	}
	if operation.UriSuffix != nil {
		t.Fatalf("expected the UriSuffix for the Operation OperationContainingAScope to have no value but got %q", *operation.UriSuffix)
	}
}

func TestParseResourceIdWithJustUriSuffix(t *testing.T) {
	parsed, err := Load("testdata/", "resource_ids_with_just_suffix.json", true)
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

	operation, ok := example.Operations["JustSuffix"]
	if !ok {
		t.Fatalf("expected there to be an Operation named JustSuffix but didn't get one")
	}
	if operation.ResourceIdName != nil {
		t.Fatalf("expected the Operation JustSuffix to have no ResourceIdName but got %q", *operation.ResourceIdName)
	}
	if operation.UriSuffix == nil {
		t.Fatalf("expected the Operation JustSuffix to have a UriSuffix but didn't get one")
	}
	expectedSuffix := "/restart"
	if *operation.UriSuffix != expectedSuffix {
		t.Fatalf("expected the Operation JustSuffix to be %q but got %q", expectedSuffix, *operation.UriSuffix)
	}
}

func TestParseResourceIdWithResourceIdAndUriSuffix(t *testing.T) {
	parsed, err := Load("testdata/", "resource_ids_with_suffix.json", true)
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

	hello, ok := result.Resources["Example"]
	if !ok {
		t.Fatalf("no resources were output with the tag Example")
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

	// first check the ResourceId looks good
	expectedValue := "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SomeResourceProvider/servers/{serverName}"
	actualValue, ok := hello.ResourceIds["ServerId"]
	if !ok {
		t.Fatalf("expected a ResourceId named ServerId but didn't get one")
	}
	// TODO: update this to be the output type we expect
	if actualValue != expectedValue {
		t.Fatalf("expected the ServerId ResourceId to match %q but got %q", expectedValue, actualValue)
	}

	// then check it's exposed in the operation itself
	operation, ok := hello.Operations["Test"]
	if !ok {
		t.Fatalf("expected there to be an Operation named Test but didn't get one")
	}
	if operation.ResourceIdName == nil {
		t.Fatalf("expected the ResourceIdName for the Operation Test to have a value but didn't get one")
	}
	if *operation.ResourceIdName != "ServerId" {
		t.Fatalf("expected the ResourceIdName for the Operation Test to have a value but didn't get one")
	}
	if operation.UriSuffix == nil {
		t.Fatalf("expected the UriSuffix for the Operation Test to have a value but didn't get one")
	}
	expectedSuffix := "/someOperation"
	if *operation.UriSuffix != expectedSuffix {
		t.Fatalf("expected the UriSuffix for the Operation Test to be %q but got %q", expectedSuffix, *operation.UriSuffix)
	}
}

func TestParseResourceIdWithResourceIdAndUriSuffixForMultipleUris(t *testing.T) {
	parsed, err := Load("testdata/", "resource_ids_with_suffix_multiple_uris.json", true)
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

	hello, ok := result.Resources["Example"]
	if !ok {
		t.Fatalf("no resources were output with the tag Example")
	}

	if len(hello.Constants) != 0 {
		t.Fatalf("expected no Constants but got %d", len(hello.Constants))
	}
	if len(hello.Models) != 0 {
		t.Fatalf("expected no Models but got %d", len(hello.Models))
	}
	if len(hello.Operations) != 3 {
		t.Fatalf("expected 3 Operations but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 1 {
		t.Fatalf("expected 1 ResourceId but got %d", len(hello.ResourceIds))
	}

	// first check the ResourceId looks good
	expectedValue := "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SomeResourceProvider/servers/{serverName}"
	actualValue, ok := hello.ResourceIds["ServerId"]
	if !ok {
		t.Fatalf("expected a ResourceId named ServerId but didn't get one")
	}
	// TODO: update this to be the output type we expect
	if actualValue != expectedValue {
		t.Fatalf("expected the ServerId ResourceId to match %q but got %q", expectedValue, actualValue)
	}

	// then check it's exposed in each of the operations itself
	operation, ok := hello.Operations["TopLevel"]
	if !ok {
		t.Fatalf("expected there to be an Operation named TopLevel but didn't get one")
	}
	if operation.ResourceIdName == nil {
		t.Fatalf("expected the ResourceIdName for the Operation TopLevel to have a value but didn't get one")
	}
	if *operation.ResourceIdName != "ServerId" {
		t.Fatalf("expected the ResourceIdName for the Operation TopLevel to have a value but didn't get one")
	}
	if operation.UriSuffix != nil {
		t.Fatalf("expected the UriSuffix for the Operation TopLevel to have no value got %q", *operation.UriSuffix)
	}

	// nested operation 'Test'
	operation, ok = hello.Operations["Test"]
	if !ok {
		t.Fatalf("expected there to be an Operation named Test but didn't get one")
	}
	if operation.ResourceIdName == nil {
		t.Fatalf("expected the ResourceIdName for the Operation Test to have a value but didn't get one")
	}
	if *operation.ResourceIdName != "ServerId" {
		t.Fatalf("expected the ResourceIdName for the Operation Test to have a value but didn't get one")
	}
	if operation.UriSuffix == nil {
		t.Fatalf("expected the UriSuffix for the Operation Test to have a value but didn't get one")
	}
	expectedSuffix := "/someOperation"
	if *operation.UriSuffix != expectedSuffix {
		t.Fatalf("expected the UriSuffix for the Operation Test to be %q but got %q", expectedSuffix, *operation.UriSuffix)
	}

	// nested operation 'Restart'
	operation, ok = hello.Operations["Restart"]
	if !ok {
		t.Fatalf("expected there to be an Operation named Restart but didn't get one")
	}
	if operation.ResourceIdName == nil {
		t.Fatalf("expected the ResourceIdName for the Operation Restart to have a value but didn't get one")
	}
	if *operation.ResourceIdName != "ServerId" {
		t.Fatalf("expected the ResourceIdName for the Operation Restart to have a value but didn't get one")
	}
	if operation.UriSuffix == nil {
		t.Fatalf("expected the UriSuffix for the Operation Restart to have a value but didn't get one")
	}
	expectedSuffix = "/restart"
	if *operation.UriSuffix != expectedSuffix {
		t.Fatalf("expected the UriSuffix for the Operation Restart to be %q but got %q", expectedSuffix, *operation.UriSuffix)
	}
}
