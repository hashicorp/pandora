// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"reflect"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var subscriptionResourceId = importerModels.ParsedResourceId{
	Constants: map[string]models.SDKConstant{},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
	},
}
var resourceGroupResourceId = importerModels.ParsedResourceId{
	Constants: map[string]models.SDKConstant{},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
	},
}
var managementGroupResourceId = importerModels.ParsedResourceId{
	Constants: map[string]models.SDKConstant{},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		models.NewResourceProviderResourceIDSegment("staticMicrosoftManagement", "Microsoft.Management"),
		models.NewStaticValueResourceIDSegment("staticManagementGroups", "managementGroups"),
		models.NewUserSpecifiedResourceIDSegment("name", "name"),
	},
}
var virtualMachineResourceId = importerModels.ParsedResourceId{
	Constants: map[string]models.SDKConstant{},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		models.NewResourceProviderResourceIDSegment("staticMicrosoftCompute", "Microsoft.Compute"),
		models.NewStaticValueResourceIDSegment("staticVirtualMachines", "virtualMachines"),
		models.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachineValue"),
	},
}
var virtualMachineExtensionResourceId = importerModels.ParsedResourceId{
	Constants: map[string]models.SDKConstant{},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		models.NewResourceProviderResourceIDSegment("staticMicrosoftCompute", "Microsoft.Compute"),
		models.NewStaticValueResourceIDSegment("staticVirtualMachines", "virtualMachines"),
		models.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachineValue"),
		models.NewStaticValueResourceIDSegment("staticExtensions", "extensions"),
		models.NewUserSpecifiedResourceIDSegment("extensionName", "extensionValue"),
	},
}
var virtualNetworkExtensionResourceId = importerModels.ParsedResourceId{
	Constants: map[string]models.SDKConstant{},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		models.NewResourceProviderResourceIDSegment("staticMicrosoftNetwork", "Microsoft.Network"),
		models.NewStaticValueResourceIDSegment("staticExtensions", "extensions"),
		models.NewUserSpecifiedResourceIDSegment("extensionName", "extensionValue"),
	},
}
var scopedMonitorResourceId = importerModels.ParsedResourceId{
	Constants: map[string]models.SDKConstant{},
	Segments: []models.ResourceIDSegment{
		models.NewScopeResourceIDSegment("scope"),
		models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		models.NewResourceProviderResourceIDSegment("staticMicrosoftMonitor", "Microsoft.Monitor"),
		models.NewStaticValueResourceIDSegment("staticExtensions", "extensions"),
		models.NewUserSpecifiedResourceIDSegment("extensionName", "extensionValue"),
	},
}
var signalRResourceId = importerModels.ParsedResourceId{
	Constants: map[string]models.SDKConstant{},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		models.NewResourceProviderResourceIDSegment("staticMicrosoftSignalRService", "Microsoft.SignalRService"),
		models.NewStaticValueResourceIDSegment("staticSignalR", "SignalR"),
		models.NewUserSpecifiedResourceIDSegment("resourceName", "resourceValue"),
	},
}
var eventHubSkuResourceId = importerModels.ParsedResourceId{
	Constants: map[string]models.SDKConstant{},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		models.NewResourceProviderResourceIDSegment("staticMicrosoftEventHub", "Microsoft.EventHub"),
		models.NewStaticValueResourceIDSegment("staticSku", "sku"),
		models.NewUserSpecifiedResourceIDSegment("sku", "sku"),
	},
}
var trafficManagerProfileResourceId = importerModels.ParsedResourceId{
	Constants: map[string]models.SDKConstant{
		"EndpointType": {
			Type: models.StringSDKConstantType,
			Values: map[string]string{
				"AzureEndpoints":    "azureEndpoints",
				"ExternalEndpoints": "externalEndpoints",
				"NestedEndpoints":   "nestedEndpoints",
			},
		},
	},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		models.NewResourceProviderResourceIDSegment("staticMicrosoftNetwork", "Microsoft.Network"),
		models.NewStaticValueResourceIDSegment("staticTrafficManagerProfiles", "trafficManagerProfiles"),
		models.NewUserSpecifiedResourceIDSegment("profileName", "profileValue"),
		models.NewConstantResourceIDSegment("endpointType", "EndpointType", "nestedEndpoints"),
		models.NewUserSpecifiedResourceIDSegment("endpointName", "endpointValue"),
	},
}
var redisPatchSchedulesResourceId = importerModels.ParsedResourceId{
	Constants: map[string]models.SDKConstant{
		"Default": {
			Type: models.StringSDKConstantType,
			Values: map[string]string{
				"First": "first",
			},
		},
	},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		models.NewResourceProviderResourceIDSegment("staticMicrosoftCache", "Microsoft.Cache"),
		models.NewStaticValueResourceIDSegment("staticRedis", "redis"),
		models.NewUserSpecifiedResourceIDSegment("name", "name"),
		models.NewStaticValueResourceIDSegment("staticPatchSchedules", "patchSchedules"),
		models.NewConstantResourceIDSegment("default", "Default", "first"),
	},
}

func TestResourceIDNamingEmpty(t *testing.T) {
	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds([]importerModels.ParsedResourceId{}, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if len(*actualNamesToIds) > 0 {
		t.Fatalf("expected there to be no namesToIds but got %+v", *actualNamesToIds)
	}
}

func TestResourceIDNamingSubscriptionId(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		subscriptionResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"SubscriptionId": subscriptionResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIDNamingSubscriptionIdAndSuffix(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		// intentionally here twice
		subscriptionResourceId,
		subscriptionResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"SubscriptionId": subscriptionResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIDNamingResourceGroupId(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		resourceGroupResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"ResourceGroupId": resourceGroupResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIDNamingResourceGroupIdAndSuffix(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		// intentionally in here twice
		resourceGroupResourceId,
		resourceGroupResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"ResourceGroupId": resourceGroupResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIDNamingManagementGroupId(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		managementGroupResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"ManagementGroupId": managementGroupResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIDNamingManagementGroupIdAndSuffix(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		// intentionally here twice
		managementGroupResourceId,
		managementGroupResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"ManagementGroupId": managementGroupResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIDNamingEventHubSkuId(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		eventHubSkuResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"SkuId": eventHubSkuResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIDNamingTopLevelScope(t *testing.T) {
	scopeResourceId := importerModels.ParsedResourceId{
		Constants: map[string]models.SDKConstant{},
		Segments: []models.ResourceIDSegment{
			models.NewScopeResourceIDSegment("scope"),
		},
	}

	input := []importerModels.ParsedResourceId{
		scopeResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"ScopeId": scopeResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIDNamingContainingAConstant(t *testing.T) {
	dnsResourceId := importerModels.ParsedResourceId{
		Constants: map[string]models.SDKConstant{
			"DnsRecordType": {
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"A":    "A",
					"AAAA": "AAAA",
				},
			},
		},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftNetwork", "Microsoft.Network"),
			models.NewConstantResourceIDSegment("recordType", "DnsRecordType", "A"),
			models.NewUserSpecifiedResourceIDSegment("recordName", "recordValue"),
		},
	}

	input := []importerModels.ParsedResourceId{
		dnsResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"RecordTypeId": dnsResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIDNamingContainingAConstantAndSuffix(t *testing.T) {
	dnsResourceId := importerModels.ParsedResourceId{
		Constants: map[string]models.SDKConstant{
			"DnsRecordType": {
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"A":    "A",
					"AAAA": "AAAA",
				},
			},
		},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftNetwork", "Microsoft.Network"),
			models.NewConstantResourceIDSegment("recordType", "DnsRecordType", "AAAA"),
			models.NewUserSpecifiedResourceIDSegment("recordName", "recordValue"),
		},
	}

	input := []importerModels.ParsedResourceId{
		// intentionally in here twice
		dnsResourceId,
		dnsResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"RecordTypeId": dnsResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIdNamingTopLevelResourceId(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		virtualMachineResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"VirtualMachineId": virtualMachineResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIdNamingTopLevelAndNestedResourceId(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		virtualMachineResourceId,
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"VirtualMachineId": virtualMachineResourceId,
		"ExtensionId":      virtualMachineExtensionResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIdNamingNestedResourceId(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"ExtensionId": virtualMachineExtensionResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIdNamingResourceUnderScope(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		scopedMonitorResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"ScopedExtensionId": scopedMonitorResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIdNamingConflictingTwoLevels(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		virtualNetworkExtensionResourceId,
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"VirtualMachineExtensionId": virtualMachineExtensionResourceId,
		"ExtensionId":               virtualNetworkExtensionResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be:\n\n%+v\nbut got:\n\n%+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIdNamingConflictingWithUpdatingOperation(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		virtualNetworkExtensionResourceId,
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"VirtualMachineExtensionId": virtualMachineExtensionResourceId,
		"ExtensionId":               virtualNetworkExtensionResourceId,
	}
	uriToParsedOperation := map[string]ParsedOperation{
		virtualMachineExtensionResourceId.ID(): {
			ResourceId:     &virtualMachineExtensionResourceId,
			ResourceIdName: pointer.To("ExtensionId"),
		},
		virtualNetworkExtensionResourceId.ID(): {
			ResourceId:     &virtualNetworkExtensionResourceId,
			ResourceIdName: pointer.To("ExtensionId"),
		},
	}

	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be:\n\n%+v\nbut got:\n\n%+v", expectedNamesToIds, *actualNamesToIds)
	}

	for wantIDName, resourceID := range expectedNamesToIds {
		got := uriToParsedOperation[resourceID.ID()].ResourceIdName
		if got == nil || *got != wantIDName {
			t.Fatalf("expected ResourceIdName of virtualMachineResourceId to be: %s\nbut got:%s\n", wantIDName, *got)
		}
	}
}

func TestResourceIdNamingConflictingMultipleLevels(t *testing.T) {
	workerPoolInstanceResourceId := importerModels.ParsedResourceId{
		Constants: map[string]models.SDKConstant{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftWeb", "Microsoft.Web"),
			models.NewStaticValueResourceIDSegment("hostingEnvironments", "hostingEnvironments"),
			models.NewUserSpecifiedResourceIDSegment("name", "name"),
			models.NewStaticValueResourceIDSegment("staticWorkerPools", "workerPools"),
			models.NewUserSpecifiedResourceIDSegment("workerPoolName", "workerPoolValue"),
			models.NewStaticValueResourceIDSegment("instances", "instances"),
			models.NewUserSpecifiedResourceIDSegment("instance", "instanceValue"),
		},
	}
	multiRolePoolInstanceResourceId := importerModels.ParsedResourceId{
		Constants: map[string]models.SDKConstant{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftWeb", "Microsoft.Web"),
			models.NewStaticValueResourceIDSegment("hostingEnvironments", "hostingEnvironments"),
			models.NewUserSpecifiedResourceIDSegment("name", "name"),
			models.NewStaticValueResourceIDSegment("multiRolePools", "multiRolePools"),
			models.NewStaticValueResourceIDSegment("default", "default"),
			models.NewStaticValueResourceIDSegment("instances", "instances"),
			models.NewUserSpecifiedResourceIDSegment("instance", "instance"),
		},
	}
	slotInstanceProcessModuleResourceId := importerModels.ParsedResourceId{
		Constants: map[string]models.SDKConstant{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftWeb", "Microsoft.Web"),
			models.NewStaticValueResourceIDSegment("sites", "sites"),
			models.NewUserSpecifiedResourceIDSegment("name", "name"),
			models.NewStaticValueResourceIDSegment("slots", "slots"),
			models.NewUserSpecifiedResourceIDSegment("slot", "slot"),
			models.NewStaticValueResourceIDSegment("instances", "instances"),
			models.NewUserSpecifiedResourceIDSegment("instanceId", "instanceId"),
			models.NewStaticValueResourceIDSegment("processes", "processes"),
			models.NewUserSpecifiedResourceIDSegment("processId", "processId"),
			models.NewStaticValueResourceIDSegment("modules", "modules"),
			models.NewUserSpecifiedResourceIDSegment("baseAddress", "baseAddress"),
		},
	}
	instanceProcessModuleResourceId := importerModels.ParsedResourceId{
		Constants: map[string]models.SDKConstant{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftWeb", "Microsoft.Web"),
			models.NewStaticValueResourceIDSegment("sites", "sites"),
			models.NewUserSpecifiedResourceIDSegment("name", "name"),
			models.NewStaticValueResourceIDSegment("instances", "instances"),
			models.NewUserSpecifiedResourceIDSegment("instanceId", "instanceId"),
			models.NewStaticValueResourceIDSegment("processes", "processes"),
			models.NewUserSpecifiedResourceIDSegment("processId", "processId"),
			models.NewStaticValueResourceIDSegment("modules", "modules"),
			models.NewUserSpecifiedResourceIDSegment("baseAddress", "baseAddress"),
		},
	}

	input := []importerModels.ParsedResourceId{
		workerPoolInstanceResourceId,
		multiRolePoolInstanceResourceId,
		slotInstanceProcessModuleResourceId,
		instanceProcessModuleResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"WorkerPoolInstanceId": workerPoolInstanceResourceId,
		"InstanceId":           multiRolePoolInstanceResourceId,
		"ProcessModuleId":      slotInstanceProcessModuleResourceId,
		"ModuleId":             instanceProcessModuleResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be:\n\n%+v\n\nbut got:\n%+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIdNamingSignalRId(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		signalRResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"SignalRId": signalRResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIdNamingTrafficManagerEndpoint(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		trafficManagerProfileResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"EndpointTypeId": trafficManagerProfileResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}

func TestResourceIDNamingRedisDefaultId(t *testing.T) {
	input := []importerModels.ParsedResourceId{
		redisPatchSchedulesResourceId,
	}
	expectedNamesToIds := map[string]importerModels.ParsedResourceId{
		"DefaultId": redisPatchSchedulesResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, *actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, *actualNamesToIds)
	}
}
