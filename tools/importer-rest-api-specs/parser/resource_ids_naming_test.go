package parser

import (
	"reflect"
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/featureflags"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser/resourceids"
)

var subscriptionResourceId = models.ParsedResourceId{
	Constants: map[string]models.ConstantDetails{},
	Segments: []models.ResourceIdSegment{
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Name: "subscriptionId",
			Type: models.SubscriptionIdSegment,
		},
	},
}
var resourceGroupResourceId = models.ParsedResourceId{
	Constants: map[string]models.ConstantDetails{},
	Segments: []models.ResourceIdSegment{
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Name: "subscriptionId",
			Type: models.SubscriptionIdSegment,
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("resourceGroups"),
			Name:       "staticResourceGroups",
		},
		{
			Name: "resourceGroupName",
			Type: models.ResourceGroupSegment,
		},
	},
}
var managementGroupResourceId = models.ParsedResourceId{
	Constants: map[string]models.ConstantDetails{},
	Segments: []models.ResourceIdSegment{
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       models.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.Management"),
			Name:       "Microsoft.Management",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("managementGroups"),
			Name:       "staticManagementGroups",
		},
		{
			Name: "name",
			Type: models.UserSpecifiedSegment,
		},
	},
}
var virtualMachineResourceId = models.ParsedResourceId{
	Constants: map[string]models.ConstantDetails{},
	Segments: []models.ResourceIdSegment{
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Name: "subscriptionId",
			Type: models.SubscriptionIdSegment,
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("resourceGroups"),
			Name:       "staticResourceGroups",
		},
		{
			Name: "resourceGroupName",
			Type: models.ResourceGroupSegment,
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       models.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.Compute"),
			Name:       "staticMicrosoftCompute",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("virtualMachines"),
			Name:       "staticVirtualMachines",
		},
		{
			Name: "virtualMachineName",
			Type: models.UserSpecifiedSegment,
		},
	},
}
var virtualMachineExtensionResourceId = models.ParsedResourceId{
	Constants: map[string]models.ConstantDetails{},
	Segments: []models.ResourceIdSegment{
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Name: "subscriptionId",
			Type: models.SubscriptionIdSegment,
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("resourceGroups"),
			Name:       "staticResourceGroups",
		},
		{
			Name: "resourceGroupName",
			Type: models.ResourceGroupSegment,
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       models.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.Compute"),
			Name:       "staticMicrosoftCompute",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("virtualMachines"),
			Name:       "staticVirtualMachines",
		},
		{
			Name: "virtualMachineName",
			Type: models.UserSpecifiedSegment,
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("extensions"),
			Name:       "staticExtensions",
		},
		{
			Name: "extensionName",
			Type: models.UserSpecifiedSegment,
		},
	},
}
var virtualNetworkExtensionResourceId = models.ParsedResourceId{
	Constants: map[string]models.ConstantDetails{},
	Segments: []models.ResourceIdSegment{
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Name: "subscriptionId",
			Type: models.SubscriptionIdSegment,
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("resourceGroups"),
			Name:       "staticResourceGroups",
		},
		{
			Name: "resourceGroupName",
			Type: models.ResourceGroupSegment,
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       models.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.Network"),
			Name:       "staticMicrosoftNetwork",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("extensions"),
			Name:       "staticExtensions",
		},
		{
			Name: "extensionName",
			Type: models.UserSpecifiedSegment,
		},
	},
}
var scopedMonitorResourceId = models.ParsedResourceId{
	Constants: map[string]models.ConstantDetails{},
	Segments: []models.ResourceIdSegment{
		{
			Type: models.ScopeSegment,
			Name: "scope",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       models.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.Monitor"),
			Name:       "staticMicrosoftMonitor",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("extensions"),
			Name:       "staticExtensions",
		},
		{
			Name: "extensionName",
			Type: models.UserSpecifiedSegment,
		},
	},
}
var signalRResourceId = models.ParsedResourceId{
	Constants: map[string]models.ConstantDetails{},
	Segments: []models.ResourceIdSegment{
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Name: "subscriptionId",
			Type: models.SubscriptionIdSegment,
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("resourceGroups"),
			Name:       "staticResourceGroups",
		},
		{
			Name: "resourceGroupName",
			Type: models.ResourceGroupSegment,
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       models.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.SignalRService"),
			Name:       "staticMicrosoftSignalRService",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("SignalR"),
			Name:       "staticSignalR",
		},
		{
			Name: "resourceName",
			Type: models.UserSpecifiedSegment,
		},
	},
}
var eventHubSkuResourceId = models.ParsedResourceId{
	Constants: map[string]models.ConstantDetails{},
	Segments: []models.ResourceIdSegment{
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Type: models.SubscriptionIdSegment,
			Name: "subscriptionId",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       models.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.EventHub"),
			Name:       "staticMicrosoftEventHub",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("sku"),
			Name:       "staticSku",
		},
		{
			Type:       models.UserSpecifiedSegment,
			FixedValue: strPtr("sku"),
			Name:       "sku",
		},
	},
}
var trafficManagerProfileResourceId = models.ParsedResourceId{
	Constants: map[string]models.ConstantDetails{
		"EndpointType": {
			FieldType: models.StringConstant,
			Values: map[string]string{
				"AzureEndpoints":    "azureEndpoints",
				"ExternalEndpoints": "externalEndpoints",
				"NestedEndpoints":   "nestedEndpoints",
			},
		},
	},
	Segments: []models.ResourceIdSegment{
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Type: models.SubscriptionIdSegment,
			Name: "subscriptionId",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("resourceGroups"),
			Name:       "staticResourceGroups",
		},
		{
			Type: models.ResourceGroupSegment,
			Name: "resourceGroupName",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       models.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.Network"),
			Name:       "microsoftNetwork",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("trafficManagerProfiles"),
			Name:       "staticTrafficManagerProfiles",
		},
		{
			Type:       models.UserSpecifiedSegment,
			FixedValue: strPtr("profileName"),
			Name:       "profileName",
		},
		{
			Type:              models.ConstantSegment,
			ConstantReference: strPtr("EndpointType"),
			Name:              "endpointType",
		},
		{
			Type:       models.UserSpecifiedSegment,
			FixedValue: strPtr("endpointName"),
			Name:       "endpointName",
		},
	},
}
var redisPatchSchedulesResourceId = models.ParsedResourceId{
	Constants: map[string]models.ConstantDetails{
		"Default": {
			FieldType: models.StringConstant,
			Values: map[string]string{
				"First": "first",
			},
		},
	},
	Segments: []models.ResourceIdSegment{
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Type: models.SubscriptionIdSegment,
			Name: "subscriptionId",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("resourceGroups"),
			Name:       "staticResourceGroups",
		},
		{
			Type: models.ResourceGroupSegment,
			Name: "resourceGroupName",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       models.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.Cache"),
			Name:       "staticMicrosoftCache",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("redis"),
			Name:       "staticRedis",
		},
		{
			Type:       models.UserSpecifiedSegment,
			FixedValue: strPtr("name"),
			Name:       "name",
		},
		{
			Type:       models.StaticSegment,
			FixedValue: strPtr("patchSchedules"),
			Name:       "staticPatchSchedules",
		},
		{
			Type:              models.ConstantSegment,
			ConstantReference: strPtr("default"),
			Name:              "default",
		},
	},
}

func TestResourceIDNamingEmpty(t *testing.T) {
	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(map[string]resourceids.ResourceUriMetadata{})
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if len(*actualNamesToIds) > 0 {
		t.Fatalf("expected there to be no namesToIds but got %+v", *actualNamesToIds)
	}

	if len(*actualUrisToNames) > 0 {
		t.Fatalf("expected there to be no urisToNames but got %+v", *actualUrisToNames)
	}
}

func TestResourceIDNamingSubscriptionId(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}": {
			ResourceIdName: nil,
			ResourceId:     &subscriptionResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"SubscriptionId": subscriptionResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}": "SubscriptionId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIDNamingSubscriptionIdAndSuffix(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}": {
			ResourceIdName: nil,
			ResourceId:     &subscriptionResourceId,
			UriSuffix:      nil,
		},
		"/subscriptions/{subscriptionId}/resourceGroups": {
			ResourceIdName: nil,
			ResourceId:     &subscriptionResourceId,
			UriSuffix:      strPtr("/resourceGroups"),
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"SubscriptionId": subscriptionResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}": "SubscriptionId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIDNamingResourceGroupId(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}": {
			ResourceIdName: nil,
			ResourceId:     &resourceGroupResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"ResourceGroupId": resourceGroupResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}": "ResourceGroupId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIDNamingResourceGroupIdAndSuffix(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}": {
			ResourceIdName: nil,
			ResourceId:     &resourceGroupResourceId,
			UriSuffix:      nil,
		},
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/restart": {
			ResourceIdName: nil,
			ResourceId:     &resourceGroupResourceId,
			UriSuffix:      strPtr("/restart"),
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"ResourceGroupId": resourceGroupResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}": "ResourceGroupId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIDNamingManagementGroupId(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/providers/Microsoft.Management/managementGroups/{name}": {
			ResourceIdName: nil,
			ResourceId:     &managementGroupResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"ManagementGroupId": managementGroupResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/providers/Microsoft.Management/managementGroups/{name}": "ManagementGroupId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIDNamingManagementGroupIdAndSuffix(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/providers/Microsoft.Management/managementGroups/{name}": {
			ResourceIdName: nil,
			ResourceId:     &managementGroupResourceId,
			UriSuffix:      nil,
		},
		"/providers/Microsoft.Management/managementGroups/{name}/restart": {
			ResourceIdName: nil,
			ResourceId:     &managementGroupResourceId,
			UriSuffix:      strPtr("/restart"),
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"ManagementGroupId": managementGroupResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/providers/Microsoft.Management/managementGroups/{name}": "ManagementGroupId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIDNamingEventHubSkuId(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/providers/Microsoft.EventHub/sku/{sku}": {
			ResourceIdName: nil,
			ResourceId:     &eventHubSkuResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"SkuId": eventHubSkuResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/providers/Microsoft.EventHub/sku/{sku}": "SkuId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIDNamingTopLevelScope(t *testing.T) {
	scopeResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type: models.ScopeSegment,
				Name: "scope",
			},
		},
	}

	input := map[string]resourceids.ResourceUriMetadata{
		"/{scope}": {
			ResourceIdName: nil,
			ResourceId:     &scopeResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"ScopeId": scopeResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/{scope}": "ScopeId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIDNamingContainingAConstant(t *testing.T) {
	dnsResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{
			"DnsRecordType": {
				FieldType: models.StringConstant,
				Values: map[string]string{
					"A":    "A",
					"AAAA": "AAAA",
				},
			},
		},
		Segments: []models.ResourceIdSegment{
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "subscriptions",
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "resourceGroups",
			},
			{
				Name: "resourceGroupName",
				Type: models.ResourceGroupSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "providers",
			},
			{
				Type:       models.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Network"),
				Name:       "Microsoft.Network",
			},
			{
				Type:              models.ConstantSegment,
				Name:              "recordType",
				ConstantReference: strPtr("DnsRecordType"),
			},
			{
				Name: "recordName",
				Type: models.UserSpecifiedSegment,
			},
		},
	}

	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/{recordType}/{recordName}": {
			ResourceIdName: nil,
			ResourceId:     &dnsResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"RecordTypeId": dnsResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/{recordType}/{recordName}": "RecordTypeId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIDNamingContainingAConstantAndSuffix(t *testing.T) {
	dnsResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{
			"DnsRecordType": {
				FieldType: models.StringConstant,
				Values: map[string]string{
					"A":    "A",
					"AAAA": "AAAA",
				},
			},
		},
		Segments: []models.ResourceIdSegment{
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "subscriptions",
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "resourceGroups",
			},
			{
				Name: "resourceGroupName",
				Type: models.ResourceGroupSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "providers",
			},
			{
				Type:       models.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Network"),
				Name:       "Microsoft.Network",
			},
			{
				Type:              models.ConstantSegment,
				Name:              "recordType",
				ConstantReference: strPtr("DnsRecordType"),
			},
			{
				Name: "recordName",
				Type: models.UserSpecifiedSegment,
			},
		},
	}

	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/{recordType}/{recordName}/forceUpdate": {
			ResourceIdName: nil,
			ResourceId:     &dnsResourceId,
			UriSuffix:      strPtr("/forceUpdate"),
		},
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/{recordType}/{recordName}": {
			ResourceIdName: nil,
			ResourceId:     &dnsResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"RecordTypeId": dnsResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/{recordType}/{recordName}": "RecordTypeId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIdNamingTopLevelResourceId(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}": {
			ResourceIdName: nil,
			ResourceId:     &virtualMachineResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"VirtualMachineId": virtualMachineResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}": "VirtualMachineId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIdNamingTopLevelAndNestedResourceId(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}": {
			ResourceIdName: nil,
			ResourceId:     &virtualMachineResourceId,
			UriSuffix:      nil,
		},
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}/extensions/{extensionName}": {
			ResourceIdName: nil,
			ResourceId:     &virtualMachineExtensionResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"VirtualMachineId": virtualMachineResourceId,
		"ExtensionId":      virtualMachineExtensionResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}":                            "VirtualMachineId",
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}/extensions/{extensionName}": "ExtensionId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIdNamingNestedResourceId(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}/extensions/{extensionName}": {
			ResourceIdName: nil,
			ResourceId:     &virtualMachineExtensionResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"ExtensionId": virtualMachineExtensionResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}/extensions/{extensionName}": "ExtensionId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIdNamingResourceUnderScope(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/{scope}/providers/Microsoft.Monitor/extensions/{extensionName}": {
			ResourceIdName: nil,
			ResourceId:     &scopedMonitorResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"ScopedExtensionId": scopedMonitorResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/{scope}/providers/Microsoft.Monitor/extensions/{extensionName}": "ScopedExtensionId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIdNamingConflictingTwoLevels(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/extensions/{extensionName}": {
			ResourceIdName: nil,
			ResourceId:     &virtualNetworkExtensionResourceId,
			UriSuffix:      nil,
		},
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}/extensions/{extensionName}": {
			ResourceIdName: nil,
			ResourceId:     &virtualMachineExtensionResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"VirtualMachineExtensionId": virtualMachineExtensionResourceId,
		"ExtensionId":               virtualNetworkExtensionResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}/extensions/{extensionName}": "VirtualMachineExtensionId",
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/extensions/{extensionName}":                                      "ExtensionId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be:\n\n%+v\nbut got:\n\n%+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be\n\n%+v\nbut got:\n\n%+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIdNamingConflictingMultipleLevels(t *testing.T) {
	workerPoolInstanceResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "subscriptions",
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "resourceGroups",
			},
			{
				Name: "resourceGroupName",
				Type: models.ResourceGroupSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "providers",
			},
			{
				Type:       models.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Web"),
				Name:       "Microsoft.Web",
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("hostingEnvironments"),
				Name:       "hostingEnvironments",
			},
			{
				Name: "name",
				Type: models.UserSpecifiedSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("workerPools"),
				Name:       "workerPools",
			},
			{
				Name: "workerPoolName",
				Type: models.UserSpecifiedSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("instances"),
				Name:       "instances",
			},
			{
				Name: "instance",
				Type: models.UserSpecifiedSegment,
			},
		},
	}
	multiRolePoolInstanceResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "subscriptions",
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "resourceGroups",
			},
			{
				Name: "resourceGroupName",
				Type: models.ResourceGroupSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "providers",
			},
			{
				Type:       models.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Web"),
				Name:       "Microsoft.Web",
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("hostingEnvironments"),
				Name:       "hostingEnvironments",
			},
			{
				Name: "name",
				Type: models.UserSpecifiedSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("multiRolePools"),
				Name:       "multiRolePools",
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("default"),
				Name:       "default",
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("instances"),
				Name:       "instances",
			},
			{
				Name: "instance",
				Type: models.UserSpecifiedSegment,
			},
		},
	}
	slotInstanceProcessModuleResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "subscriptions",
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "resourceGroups",
			},
			{
				Name: "resourceGroupName",
				Type: models.ResourceGroupSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "providers",
			},
			{
				Type:       models.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Web"),
				Name:       "Microsoft.Web",
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("sites"),
				Name:       "sites",
			},
			{
				Name: "name",
				Type: models.UserSpecifiedSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("slots"),
				Name:       "slots",
			},
			{
				Name: "slot",
				Type: models.UserSpecifiedSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("instances"),
				Name:       "instances",
			},
			{
				Name: "instanceId",
				Type: models.UserSpecifiedSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("processes"),
				Name:       "processes",
			},
			{
				Name: "processId",
				Type: models.UserSpecifiedSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("modules"),
				Name:       "modules",
			},
			{
				Name: "baseAddress",
				Type: models.UserSpecifiedSegment,
			},
		},
	}
	instanceProcessModuleResourceId := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "subscriptions",
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "resourceGroups",
			},
			{
				Name: "resourceGroupName",
				Type: models.ResourceGroupSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "providers",
			},
			{
				Type:       models.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Web"),
				Name:       "Microsoft.Web",
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("sites"),
				Name:       "sites",
			},
			{
				Name: "name",
				Type: models.UserSpecifiedSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("instances"),
				Name:       "instances",
			},
			{
				Name: "instanceId",
				Type: models.UserSpecifiedSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("processes"),
				Name:       "processes",
			},
			{
				Name: "processId",
				Type: models.UserSpecifiedSegment,
			},
			{
				Type:       models.StaticSegment,
				FixedValue: strPtr("modules"),
				Name:       "modules",
			},
			{
				Name: "baseAddress",
				Type: models.UserSpecifiedSegment,
			},
		},
	}

	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/workerPools/{workerPoolName}/instances/{instance}": {
			ResourceIdName: nil,
			ResourceId:     &workerPoolInstanceResourceId,
			UriSuffix:      nil,
		},
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/multiRolePools/default/instances/{instance}": {
			ResourceIdName: nil,
			ResourceId:     &multiRolePoolInstanceResourceId,
			UriSuffix:      nil,
		},
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}/modules/{baseAddress}": {
			ResourceIdName: nil,
			ResourceId:     &slotInstanceProcessModuleResourceId,
			UriSuffix:      nil,
		},
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/modules/{baseAddress}": {
			ResourceIdName: nil,
			ResourceId:     &instanceProcessModuleResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"WorkerPoolInstanceId": workerPoolInstanceResourceId,
		"InstanceId":           multiRolePoolInstanceResourceId,
		"ProcessModuleId":      slotInstanceProcessModuleResourceId,
		"ModuleId":             instanceProcessModuleResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/workerPools/{workerPoolName}/instances/{instance}":                 "WorkerPoolInstanceId",
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/multiRolePools/default/instances/{instance}":                       "InstanceId",
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}/modules/{baseAddress}": "ProcessModuleId",
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/modules/{baseAddress}":              "ModuleId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be:\n\n%+v\n\nbut got:\n%+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be:\n\n%+v\n\nbut got:\n%+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIdNamingSignalRId(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/SignalR/{resourceName}": {
			ResourceIdName: nil,
			ResourceId:     &signalRResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"SignalRId": signalRResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/SignalR/{resourceName}": "SignalRId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIdNamingTrafficManagerEndpoint(t *testing.T) {
	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}/{endpointType}/{endpointName}": {
			ResourceIdName: nil,
			ResourceId:     &trafficManagerProfileResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"EndpointTypeId": trafficManagerProfileResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}/{endpointType}/{endpointName}": "EndpointTypeId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func TestResourceIDNamingRedisDefaultId(t *testing.T) {
	if !featureflags.ShouldReservedKeywordsBeNormalized {
		t.Skipf("Skipping until the importer is refactored")
	}

	input := map[string]resourceids.ResourceUriMetadata{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/redis/{name}/patchSchedules/{default}": {
			ResourceIdName: nil,
			ResourceId:     &redisPatchSchedulesResourceId,
			UriSuffix:      nil,
		},
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
		"DefaultId": redisPatchSchedulesResourceId,
	}
	expectedUrisToNames := map[string]string{
		"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/redis/{name}/patchSchedules/{defaultName}": "DefaultId",
	}

	actualNamesToIds, actualUrisToNames, err := resourceids.LegacyDetermineNamesForResourceIds(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}

	if !reflect.DeepEqual(expectedUrisToNames, *actualUrisToNames) {
		t.Fatalf("expected urisToNames to be %+v but got %+v", expectedUrisToNames, *actualUrisToNames)
	}
}

func strPtr(in string) *string {
	return &in
}
