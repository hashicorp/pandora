package parser

import (
	"fmt"
	"reflect"
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestParseResourceIdBasic(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "resource_ids_basic.json")
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
	expectedResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "staticSubscriptions",
			},
			{
				Type: resourcemanager.SubscriptionIdSegment,
				Name: "subscriptionId",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "staticResourceGroups",
			},
			{
				Type: resourcemanager.ResourceGroupSegment,
				Name: "resourceGroupName",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "staticProviders",
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.SomeResourceProvider"),
				Name:       "staticMicrosoftSomeResourceProvider",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("servers"),
				Name:       "staticServers",
			},
			{
				Type: resourcemanager.UserSpecifiedSegment,
				Name: "serverName",
			},
		},
	}
	actualValue, ok := hello.ResourceIds["ServerId"]
	if !ok {
		t.Fatalf("expected a ResourceId named ServerId but didn't get one")
	}
	if actualValue.String() != expectedValue {
		t.Fatalf("expected the ServerId ResourceId to match %q but got %q", expectedValue, actualValue.String())
	}
	if err := validateResourceId(actualValue, expectedValue, expectedResourceId); err != nil {
		t.Fatalf(err.Error())
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
	result, err := ParseSwaggerFileForTesting(t, "resource_ids_containing_constant.json")
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
	expectedResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{
			"Planet": {
				FieldType: models.StringConstant,
				Values: map[string]string{
					"Earth":   "Earth",
					"Jupiter": "Jupiter",
					"Mars":    "Mars",
					"Saturn":  "Saturn",
				},
			},
		},
		Segments: []models.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("planets"),
				Name:       "staticPlanets",
			},
			{
				Type:              resourcemanager.ConstantSegment,
				ConstantReference: strPtr("Planet"),
				Name:              "planetName",
			},
		},
	}
	expectedValue := "/planets/{planetName}"
	actualValue, ok := hello.ResourceIds["PlanetId"]
	if !ok {
		t.Fatalf("expected a ResourceId named PlanetId but didn't get one")
	}
	if actualValue.String() != expectedValue {
		t.Fatalf("expected the PlanetId ResourceId to match %q but got %q", expectedValue, actualValue)
	}
	if err := validateResourceId(actualValue, expectedValue, expectedResourceId); err != nil {
		t.Fatalf(err.Error())
	}

	if _, ok := actualValue.Constants["Planet"]; !ok {
		t.Fatalf("expected the ResourceId to have an embedded constant named Planet but didn't get one")
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
	result, err := ParseSwaggerFileForTesting(t, "resource_ids_containing_scope.json")
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
	expectedResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type: resourcemanager.ScopeSegment,
				Name: "scope",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "staticProviders",
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.FooBar"),
				Name:       "staticMicrosoftFooBar",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("virtualMachines"),
				Name:       "staticVirtualMachines",
			},
			{
				Type: resourcemanager.UserSpecifiedSegment,
				Name: "virtualMachineName",
			},
		},
	}
	expectedValue := "/{scope}/providers/Microsoft.FooBar/virtualMachines/{virtualMachineName}" // NOTE: this has to have a leading slash to be valid in Swagger
	actualValue, ok := hello.ResourceIds["ScopedVirtualMachineId"]
	if !ok {
		t.Fatalf("expected a ResourceId named ScopedVirtualMachineId but didn't get one")
	}
	if actualValue.String() != expectedValue {
		t.Fatalf("expected the ScopedVirtualMachineId ResourceId to match %q but got %q", expectedValue, actualValue)
	}
	if err := validateResourceId(actualValue, expectedValue, expectedResourceId); err != nil {
		t.Fatalf(err.Error())
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
	result, err := ParseSwaggerFileForTesting(t, "resource_ids_with_just_suffix.json")
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
	result, err := ParseSwaggerFileForTesting(t, "resource_ids_with_suffix.json")
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
	expectedResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "staticSubscriptions",
			},
			{
				Type: resourcemanager.SubscriptionIdSegment,
				Name: "subscriptionId",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "staticResourceGroups",
			},
			{
				Type: resourcemanager.ResourceGroupSegment,
				Name: "resourceGroupName",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "staticProviders",
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.SomeResourceProvider"),
				Name:       "staticMicrosoftSomeResourceProvider",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("servers"),
				Name:       "staticServers",
			},
			{
				Type: resourcemanager.UserSpecifiedSegment,
				Name: "serverName",
			},
		},
	}
	expectedValue := "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SomeResourceProvider/servers/{serverName}"
	actualValue, ok := hello.ResourceIds["ServerId"]
	if !ok {
		t.Fatalf("expected a ResourceId named ServerId but didn't get one")
	}
	if actualValue.String() != expectedValue {
		t.Fatalf("expected the ServerId ResourceId to match %q but got %q", expectedValue, actualValue)
	}
	if err := validateResourceId(actualValue, expectedValue, expectedResourceId); err != nil {
		t.Fatalf(err.Error())
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
	result, err := ParseSwaggerFileForTesting(t, "resource_ids_with_suffix_multiple_uris.json")
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
	expectedResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "staticSubscriptions",
			},
			{
				Type: resourcemanager.SubscriptionIdSegment,
				Name: "subscriptionId",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "staticResourceGroups",
			},
			{
				Type: resourcemanager.ResourceGroupSegment,
				Name: "resourceGroupName",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "staticProviders",
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.SomeResourceProvider"),
				Name:       "staticMicrosoftSomeResourceProvider",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("servers"),
				Name:       "staticServers",
			},
			{
				Type: resourcemanager.UserSpecifiedSegment,
				Name: "serverName",
			},
		},
	}
	expectedValue := "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SomeResourceProvider/servers/{serverName}"
	actualValue, ok := hello.ResourceIds["ServerId"]
	if !ok {
		t.Fatalf("expected a ResourceId named ServerId but didn't get one")
	}
	if actualValue.String() != expectedValue {
		t.Fatalf("expected the ServerId ResourceId to match %q but got %q", expectedValue, actualValue)
	}
	if err := validateResourceId(actualValue, expectedValue, expectedResourceId); err != nil {
		t.Fatalf(err.Error())
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

func TestParseResourceIdContainingResourceProviderShouldGetTitleCased(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "resource_ids_lowercased_resource_provider.json")
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
	expectedResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "staticSubscriptions",
			},
			{
				Type: resourcemanager.SubscriptionIdSegment,
				Name: "subscriptionId",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "staticResourceGroups",
			},
			{
				Type: resourcemanager.ResourceGroupSegment,
				Name: "resourceGroupName",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "staticProviders",
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.SomeResourceProvider"),
				Name:       "staticMicrosoftSomeResourceProvider",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("servers"),
				Name:       "staticServers",
			},
			{
				Type: resourcemanager.UserSpecifiedSegment,
				Name: "serverName",
			},
		},
	}
	actualValue, ok := hello.ResourceIds["ServerId"]
	if !ok {
		t.Fatalf("expected a ResourceId named ServerId but didn't get one")
	}
	if actualValue.String() != expectedValue {
		t.Fatalf("expected the ServerId ResourceId to match %q but got %q", expectedValue, actualValue.String())
	}
	if err := validateResourceId(actualValue, expectedValue, expectedResourceId); err != nil {
		t.Fatalf(err.Error())
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

func TestParseResourceIdContainingTheSameResourceIdWithDifferentSegments(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "resource_ids_same_id_different_segment_casing.json")
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
	if len(hello.Operations) != 2 {
		t.Fatalf("expected 2 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 1 {
		t.Fatalf("expected 1 ResourceId but got %d", len(hello.ResourceIds))
	}

	// first check the Server ResourceId looks good
	expectedValue := "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SomeResourceProvider/virtualMachines/{machineName}"
	expectedResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "staticSubscriptions",
			},
			{
				Type: resourcemanager.SubscriptionIdSegment,
				Name: "subscriptionId",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "staticResourceGroups",
			},
			{
				Type: resourcemanager.ResourceGroupSegment,
				Name: "resourceGroupName",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "staticProviders",
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.SomeResourceProvider"),
				Name:       "staticMicrosoftSomeResourceProvider",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("virtualMachines"),
				Name:       "staticVirtualMachines",
			},
			{
				Type: resourcemanager.UserSpecifiedSegment,
				Name: "machineName",
			},
		},
	}
	actualValue, ok := hello.ResourceIds["VirtualMachineId"]
	if !ok {
		t.Fatalf("expected a ResourceId named ServerId but didn't get one")
	}
	if actualValue.String() != expectedValue {
		t.Fatalf("expected the VirtualMachineId ResourceId to match %q but got %q", expectedValue, actualValue.String())
	}
	if err := validateResourceId(actualValue, expectedValue, expectedResourceId); err != nil {
		t.Fatalf(err.Error())
	}

	// then check it's exposed in the operation itself
	operation, ok := hello.Operations["Test"]
	if !ok {
		t.Fatalf("expected there to be an Operation named Test but didn't get one")
	}
	if operation.ResourceIdName == nil {
		t.Fatalf("expected the ResourceIdName for the Operation Test to have a value but didn't get one")
	}
	if *operation.ResourceIdName != "VirtualMachineId" {
		t.Fatalf("expected the ResourceIdName for the Operation Test to be VirtualMachineId but got %q", *operation.ResourceIdName)
	}
	if operation.UriSuffix != nil {
		t.Fatalf("expected the UriSuffix for the Operation Test to have no value but got %q", *operation.UriSuffix)
	}

	// then check it's exposed in the Restart operation itself
	restartOperation, ok := hello.Operations["Restart"]
	if !ok {
		t.Fatalf("expected there to be an Operation named Restart but didn't get one")
	}
	if restartOperation.ResourceIdName == nil {
		t.Fatalf("expected the ResourceIdName for the Operation Restart to have a value but didn't get one")
	}
	if *restartOperation.ResourceIdName != "VirtualMachineId" {
		t.Fatalf("expected the ResourceIdName for the Operation Restart to be VirtualMachineId but got %q", *restartOperation.ResourceIdName)
	}
	if restartOperation.UriSuffix == nil {
		t.Fatalf("expected the UriSuffix for the Operation Restart to have a value but got nil")
	}
	if *restartOperation.UriSuffix != "/restart" {
		t.Fatalf("expected the UriSuffix for the Operation Restart to have be `/restart` but got %q", *restartOperation.UriSuffix)
	}
}

func TestParseResourceIdContainingTheSegmentsNamedTheSame(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "resource_ids_multiple_segments_same_name.json")
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

	// first check the Billing Period ResourceId looks good
	expectedValue := "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}"
	expectedResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				Name:       "staticProviders",
				FixedValue: strPtr("providers"),
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				Name:       "staticMicrosoftManagement",
				FixedValue: strPtr("Microsoft.Management"),
			},
			{
				Type:       resourcemanager.StaticSegment,
				Name:       "staticManagementGroups",
				FixedValue: strPtr("managementGroups"),
			},
			{
				Type: resourcemanager.UserSpecifiedSegment,
				Name: "managementGroupId",
			},
			{
				Type:       resourcemanager.StaticSegment,
				Name:       "staticProviders2",
				FixedValue: strPtr("providers"),
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				Name:       "staticMicrosoftBilling",
				FixedValue: strPtr("Microsoft.Billing"),
			},
			{
				Type:       resourcemanager.StaticSegment,
				Name:       "staticBillingPeriods",
				FixedValue: strPtr("billingPeriods"),
			},
			{
				Type: resourcemanager.UserSpecifiedSegment,
				Name: "billingPeriodName",
			},
		},
	}
	actualValue, ok := hello.ResourceIds["BillingPeriodId"]
	if !ok {
		t.Fatalf("expected a ResourceId named BillingPeriodId but didn't get one")
	}
	if actualValue.String() != expectedValue {
		t.Fatalf("expected the BillingPeriodId ResourceId to match %q but got %q", expectedValue, actualValue.String())
	}
	if err := validateResourceId(actualValue, expectedValue, expectedResourceId); err != nil {
		t.Fatalf(err.Error())
	}

	// then check it's exposed in the operation itself
	operation, ok := hello.Operations["Test"]
	if !ok {
		t.Fatalf("expected there to be an Operation named Test but didn't get one")
	}
	if operation.ResourceIdName == nil {
		t.Fatalf("expected the ResourceIdName for the Operation Test to have a value but didn't get one")
	}
	if *operation.ResourceIdName != "BillingPeriodId" {
		t.Fatalf("expected the ResourceIdName for the Operation Test to be VirtualMachineId but got %q", *operation.ResourceIdName)
	}
	if operation.UriSuffix == nil {
		t.Fatalf("expected the UriSuffix for the Operation Test to have a value but didn't get one")
	}
	if *operation.UriSuffix != "/Microsoft.Consumption/aggregatedCost" {
		t.Fatalf("expected the UriSuffix for the Operation Test to have be '/Microsoft.Consumption/aggregatedCost' but got %q", *operation.UriSuffix)
	}
}

func TestParseResourceIdsCommon(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "resource_ids_common.json")
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
	if len(hello.Operations) != 5 {
		t.Fatalf("expected 5 Operation but got %d", len(hello.Operations))
	}
	if len(hello.ResourceIds) != 5 {
		t.Fatalf("expected 5 ResourceIds but got %d", len(hello.ResourceIds))
	}

	var checkId = func(t *testing.T, key string) {
		idName := fmt.Sprintf("%sId", key)
		id, found := hello.ResourceIds[idName]
		if !found {
			t.Fatalf("expected there to be a ResourceId named `%s` but didn't find one", idName)
		}
		if id.CommonAlias == nil {
			t.Fatalf("expected the ResourceId `%s` to have a CommonAlias but it was nil", idName)
		}
		if *id.CommonAlias != key {
			t.Fatalf("expected the ResourceId `%s` to have a CommonAlias of `%s` but it was %q", idName, key, *id.CommonAlias)
		}
	}
	checkId(t, "ManagementGroup")
	checkId(t, "ResourceGroup")
	checkId(t, "Scope")
	checkId(t, "Subscription")
	checkId(t, "UserAssignedIdentity")
}

func validateResourceId(actualValue models.ParsedResourceId, expectedString string, expected models.ParsedResourceId) error {
	if actualValue.String() != expectedString {
		return fmt.Errorf("expected the ResourceId to be %q but got %q", expectedString, actualValue.String())
	}

	if len(actualValue.Segments) != len(expected.Segments) {
		return fmt.Errorf("expected the ResourceId to have %d segments but got %d", len(expected.Segments), len(actualValue.Segments))
	}
	for i, expectedSegment := range expected.Segments {
		actualSegment := actualValue.Segments[i]

		if expectedSegment.Type != actualSegment.Type {
			return fmt.Errorf("expected the Segment at index %d to have the Type %q but got %q", i, string(expectedSegment.Type), string(actualSegment.Type))
		}

		if expectedSegment.Name != actualSegment.Name {
			return fmt.Errorf("expected the Segment at index %d to have the Name %q but got %q", i, expectedSegment.Name, actualSegment.Name)
		}

		if expectedSegment.ConstantReference != nil || actualSegment.ConstantReference != nil {
			if expectedSegment.ConstantReference == nil {
				return fmt.Errorf("expected the Segment at index %d to not have a ConstantReference but got %q", i, *actualSegment.ConstantReference)
			}
			if actualSegment.ConstantReference == nil {
				return fmt.Errorf("expected the Segment at index %d to have a ConstantReference but didn't get one", i)
			}

			if *expectedSegment.ConstantReference != *actualSegment.ConstantReference {
				return fmt.Errorf("expected the Segment at index %d's ConstantReference to be %q but got %q", i, *expectedSegment.ConstantReference, *actualSegment.ConstantReference)
			}
		}

		if expectedSegment.FixedValue != nil || actualSegment.FixedValue != nil {
			if expectedSegment.FixedValue == nil {
				return fmt.Errorf("expected the Segment at index %d to not have a FixedValue but got %q", i, *actualSegment.FixedValue)
			}
			if actualSegment.FixedValue == nil {
				return fmt.Errorf("expected the Segment at index %d to have a FixedValue but didn't get one", i)
			}

			if *expectedSegment.FixedValue != *actualSegment.FixedValue {
				return fmt.Errorf("expected the Segment at index %d's FixedValue to be %q but got %q", i, *expectedSegment.FixedValue, *actualSegment.FixedValue)
			}
		}
	}

	if len(actualValue.Constants) != len(expected.Constants) {
		return fmt.Errorf("expected there to be %d constants but got %d", len(expected.Constants), len(actualValue.Constants))
	}
	for k, expectedConstant := range expected.Constants {
		actualConstant, ok := actualValue.Constants[k]
		if !ok {
			return fmt.Errorf("actual didn't contain the constant %q", k)
		}

		if !reflect.DeepEqual(expectedConstant, actualConstant) {
			return fmt.Errorf("Constant %q didn't match - expected:\n\n%+v\n\nActual:\n\n%+v", k, expectedConstant, actualConstant)
		}
	}

	return nil
}
