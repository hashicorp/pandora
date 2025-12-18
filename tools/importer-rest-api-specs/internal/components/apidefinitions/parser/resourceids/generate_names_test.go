// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"reflect"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var subscriptionResourceId = sdkModels.ResourceID{
	ConstantNames: []string{},
	Segments: []sdkModels.ResourceIDSegment{
		sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
	},
}
var resourceGroupResourceId = sdkModels.ResourceID{
	ConstantNames: []string{},
	Segments: []sdkModels.ResourceIDSegment{
		sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
	},
}
var managementGroupResourceId = sdkModels.ResourceID{
	ConstantNames: []string{},
	Segments: []sdkModels.ResourceIDSegment{
		sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftManagement", "Microsoft.Management"),
		sdkModels.NewStaticValueResourceIDSegment("staticManagementGroups", "managementGroups"),
		sdkModels.NewUserSpecifiedResourceIDSegment("name", "name"),
	},
}
var virtualMachineResourceId = sdkModels.ResourceID{
	ConstantNames: []string{},
	Segments: []sdkModels.ResourceIDSegment{
		sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftCompute", "Microsoft.Compute"),
		sdkModels.NewStaticValueResourceIDSegment("staticVirtualMachines", "virtualMachines"),
		sdkModels.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachineValue"),
	},
}
var virtualMachineExtensionResourceId = sdkModels.ResourceID{
	ConstantNames: []string{},
	Segments: []sdkModels.ResourceIDSegment{
		sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftCompute", "Microsoft.Compute"),
		sdkModels.NewStaticValueResourceIDSegment("staticVirtualMachines", "virtualMachines"),
		sdkModels.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachineValue"),
		sdkModels.NewStaticValueResourceIDSegment("staticExtensions", "extensions"),
		sdkModels.NewUserSpecifiedResourceIDSegment("extensionName", "extensionValue"),
	},
}
var virtualNetworkExtensionResourceId = sdkModels.ResourceID{
	ConstantNames: []string{},
	Segments: []sdkModels.ResourceIDSegment{
		sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftNetwork", "Microsoft.Network"),
		sdkModels.NewStaticValueResourceIDSegment("staticExtensions", "extensions"),
		sdkModels.NewUserSpecifiedResourceIDSegment("extensionName", "extensionValue"),
	},
}
var scopedMonitorResourceId = sdkModels.ResourceID{
	ConstantNames: []string{},
	Segments: []sdkModels.ResourceIDSegment{
		sdkModels.NewScopeResourceIDSegment("scope"),
		sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftMonitor", "Microsoft.Monitor"),
		sdkModels.NewStaticValueResourceIDSegment("staticExtensions", "extensions"),
		sdkModels.NewUserSpecifiedResourceIDSegment("extensionName", "extensionValue"),
	},
}
var signalRResourceId = sdkModels.ResourceID{
	ConstantNames: []string{},
	Segments: []sdkModels.ResourceIDSegment{
		sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftSignalRService", "Microsoft.SignalRService"),
		sdkModels.NewStaticValueResourceIDSegment("staticSignalR", "SignalR"),
		sdkModels.NewUserSpecifiedResourceIDSegment("resourceName", "resourceValue"),
	},
}
var eventHubSkuResourceId = sdkModels.ResourceID{
	ConstantNames: []string{},
	Segments: []sdkModels.ResourceIDSegment{
		sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftEventHub", "Microsoft.EventHub"),
		sdkModels.NewStaticValueResourceIDSegment("staticSku", "sku"),
		sdkModels.NewUserSpecifiedResourceIDSegment("sku", "sku"),
	},
}
var trafficManagerProfileResourceId = sdkModels.ResourceID{
	ConstantNames: []string{
		"EndpointType",
	},
	Segments: []sdkModels.ResourceIDSegment{
		sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftNetwork", "Microsoft.Network"),
		sdkModels.NewStaticValueResourceIDSegment("staticTrafficManagerProfiles", "trafficManagerProfiles"),
		sdkModels.NewUserSpecifiedResourceIDSegment("profileName", "profileValue"),
		sdkModels.NewConstantResourceIDSegment("endpointType", "EndpointType", "nestedEndpoints"),
		sdkModels.NewUserSpecifiedResourceIDSegment("endpointName", "endpointValue"),
	},
}
var redisPatchSchedulesResourceId = sdkModels.ResourceID{
	ConstantNames: []string{
		"Default",
	},
	Segments: []sdkModels.ResourceIDSegment{
		sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftCache", "Microsoft.Cache"),
		sdkModels.NewStaticValueResourceIDSegment("staticRedis", "redis"),
		sdkModels.NewUserSpecifiedResourceIDSegment("name", "name"),
		sdkModels.NewStaticValueResourceIDSegment("staticPatchSchedules", "patchSchedules"),
		sdkModels.NewConstantResourceIDSegment("default", "Default", "first"),
	},
}

func TestResourceIDNamingEmpty(t *testing.T) {
	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds([]sdkModels.ResourceID{}, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if len(actualNamesToIds) > 0 {
		t.Fatalf("expected there to be no namesToIds but got %+v", actualNamesToIds)
	}
}

func TestResourceIDNamingSubscriptionId(t *testing.T) {
	input := []sdkModels.ResourceID{
		subscriptionResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"SubscriptionId": subscriptionResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIDNamingSubscriptionIdAndSuffix(t *testing.T) {
	input := []sdkModels.ResourceID{
		// intentionally here twice
		subscriptionResourceId,
		subscriptionResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"SubscriptionId": subscriptionResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIDNamingResourceGroupId(t *testing.T) {
	input := []sdkModels.ResourceID{
		resourceGroupResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"ResourceGroupId": resourceGroupResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIDNamingResourceGroupIdAndSuffix(t *testing.T) {
	input := []sdkModels.ResourceID{
		// intentionally in here twice
		resourceGroupResourceId,
		resourceGroupResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"ResourceGroupId": resourceGroupResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIDNamingManagementGroupId(t *testing.T) {
	input := []sdkModels.ResourceID{
		managementGroupResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"ManagementGroupId": managementGroupResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIDNamingManagementGroupIdAndSuffix(t *testing.T) {
	input := []sdkModels.ResourceID{
		// intentionally here twice
		managementGroupResourceId,
		managementGroupResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"ManagementGroupId": managementGroupResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIDNamingEventHubSkuId(t *testing.T) {
	input := []sdkModels.ResourceID{
		eventHubSkuResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"SkuId": eventHubSkuResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIDNamingTopLevelScope(t *testing.T) {
	scopeResourceId := sdkModels.ResourceID{
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewScopeResourceIDSegment("scope"),
		},
	}

	input := []sdkModels.ResourceID{
		scopeResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"ScopeId": scopeResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIDNamingContainingAConstant(t *testing.T) {
	dnsResourceId := sdkModels.ResourceID{
		ConstantNames: []string{
			"DnsRecordType",
		},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftNetwork", "Microsoft.Network"),
			sdkModels.NewConstantResourceIDSegment("recordType", "DnsRecordType", "A"),
			sdkModels.NewUserSpecifiedResourceIDSegment("recordName", "recordValue"),
		},
	}

	input := []sdkModels.ResourceID{
		dnsResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"RecordTypeId": dnsResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIDNamingContainingAConstantAndSuffix(t *testing.T) {
	dnsResourceId := sdkModels.ResourceID{
		ConstantNames: []string{
			"DnsRecordType",
		},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftNetwork", "Microsoft.Network"),
			sdkModels.NewConstantResourceIDSegment("recordType", "DnsRecordType", "AAAA"),
			sdkModels.NewUserSpecifiedResourceIDSegment("recordName", "recordValue"),
		},
	}

	input := []sdkModels.ResourceID{
		// intentionally in here twice
		dnsResourceId,
		dnsResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"RecordTypeId": dnsResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIdNamingTopLevelResourceId(t *testing.T) {
	input := []sdkModels.ResourceID{
		virtualMachineResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"VirtualMachineId": virtualMachineResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIdNamingTopLevelAndNestedResourceId(t *testing.T) {
	input := []sdkModels.ResourceID{
		virtualMachineResourceId,
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"VirtualMachineId": virtualMachineResourceId,
		"ExtensionId":      virtualMachineExtensionResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIdNamingNestedResourceId(t *testing.T) {
	input := []sdkModels.ResourceID{
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"ExtensionId": virtualMachineExtensionResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIdNamingResourceUnderScope(t *testing.T) {
	input := []sdkModels.ResourceID{
		scopedMonitorResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"ScopedExtensionId": scopedMonitorResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIdNamingConflictingTwoLevels(t *testing.T) {
	input := []sdkModels.ResourceID{
		virtualNetworkExtensionResourceId,
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"VirtualMachineExtensionId": virtualMachineExtensionResourceId,
		"ExtensionId":               virtualNetworkExtensionResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be:\n\n%+v\nbut got:\n\n%+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIdNamingConflictingWithUpdatingOperation(t *testing.T) {
	input := []sdkModels.ResourceID{
		virtualNetworkExtensionResourceId,
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"VirtualMachineExtensionId": virtualMachineExtensionResourceId,
		"ExtensionId":               virtualNetworkExtensionResourceId,
	}
	uriToParsedOperation := map[string]ParsedOperation{
		sdkHelpers.DisplayValueForResourceID(virtualMachineExtensionResourceId): {
			ResourceId:     &virtualMachineExtensionResourceId,
			ResourceIdName: pointer.To("ExtensionId"),
		},
		sdkHelpers.DisplayValueForResourceID(virtualNetworkExtensionResourceId): {
			ResourceId:     &virtualNetworkExtensionResourceId,
			ResourceIdName: pointer.To("ExtensionId"),
		},
	}

	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be:\n\n%+v\nbut got:\n\n%+v", expectedNamesToIds, actualNamesToIds)
	}

	for wantIDName, resourceID := range expectedNamesToIds {
		id := sdkHelpers.DisplayValueForResourceID(resourceID)
		got := uriToParsedOperation[id].ResourceIdName
		if got == nil || *got != wantIDName {
			t.Fatalf("expected ResourceIdName of virtualMachineResourceId to be: %s\nbut got:%s\n", wantIDName, *got)
		}
	}
}

func TestResourceIdNamingConflictingMultipleLevels(t *testing.T) {
	workerPoolInstanceResourceId := sdkModels.ResourceID{
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftWeb", "Microsoft.Web"),
			sdkModels.NewStaticValueResourceIDSegment("hostingEnvironments", "hostingEnvironments"),
			sdkModels.NewUserSpecifiedResourceIDSegment("name", "name"),
			sdkModels.NewStaticValueResourceIDSegment("staticWorkerPools", "workerPools"),
			sdkModels.NewUserSpecifiedResourceIDSegment("workerPoolName", "workerPoolValue"),
			sdkModels.NewStaticValueResourceIDSegment("instances", "instances"),
			sdkModels.NewUserSpecifiedResourceIDSegment("instance", "instanceValue"),
		},
	}
	multiRolePoolInstanceResourceId := sdkModels.ResourceID{
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftWeb", "Microsoft.Web"),
			sdkModels.NewStaticValueResourceIDSegment("hostingEnvironments", "hostingEnvironments"),
			sdkModels.NewUserSpecifiedResourceIDSegment("name", "name"),
			sdkModels.NewStaticValueResourceIDSegment("multiRolePools", "multiRolePools"),
			sdkModels.NewStaticValueResourceIDSegment("default", "default"),
			sdkModels.NewStaticValueResourceIDSegment("instances", "instances"),
			sdkModels.NewUserSpecifiedResourceIDSegment("instance", "instance"),
		},
	}
	slotInstanceProcessModuleResourceId := sdkModels.ResourceID{
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftWeb", "Microsoft.Web"),
			sdkModels.NewStaticValueResourceIDSegment("sites", "sites"),
			sdkModels.NewUserSpecifiedResourceIDSegment("name", "name"),
			sdkModels.NewStaticValueResourceIDSegment("slots", "slots"),
			sdkModels.NewUserSpecifiedResourceIDSegment("slot", "slot"),
			sdkModels.NewStaticValueResourceIDSegment("instances", "instances"),
			sdkModels.NewUserSpecifiedResourceIDSegment("instanceId", "instanceId"),
			sdkModels.NewStaticValueResourceIDSegment("processes", "processes"),
			sdkModels.NewUserSpecifiedResourceIDSegment("processId", "processId"),
			sdkModels.NewStaticValueResourceIDSegment("modules", "modules"),
			sdkModels.NewUserSpecifiedResourceIDSegment("baseAddress", "baseAddress"),
		},
	}
	instanceProcessModuleResourceId := sdkModels.ResourceID{
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftWeb", "Microsoft.Web"),
			sdkModels.NewStaticValueResourceIDSegment("sites", "sites"),
			sdkModels.NewUserSpecifiedResourceIDSegment("name", "name"),
			sdkModels.NewStaticValueResourceIDSegment("instances", "instances"),
			sdkModels.NewUserSpecifiedResourceIDSegment("instanceId", "instanceId"),
			sdkModels.NewStaticValueResourceIDSegment("processes", "processes"),
			sdkModels.NewUserSpecifiedResourceIDSegment("processId", "processId"),
			sdkModels.NewStaticValueResourceIDSegment("modules", "modules"),
			sdkModels.NewUserSpecifiedResourceIDSegment("baseAddress", "baseAddress"),
		},
	}

	input := []sdkModels.ResourceID{
		workerPoolInstanceResourceId,
		multiRolePoolInstanceResourceId,
		slotInstanceProcessModuleResourceId,
		instanceProcessModuleResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
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

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be:\n\n%+v\n\nbut got:\n%+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIdNamingSignalRId(t *testing.T) {
	input := []sdkModels.ResourceID{
		signalRResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"SignalRId": signalRResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIdNamingTrafficManagerEndpoint(t *testing.T) {
	input := []sdkModels.ResourceID{
		trafficManagerProfileResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"EndpointTypeId": trafficManagerProfileResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}

func TestResourceIDNamingRedisDefaultId(t *testing.T) {
	input := []sdkModels.ResourceID{
		redisPatchSchedulesResourceId,
	}
	expectedNamesToIds := map[string]sdkModels.ResourceID{
		"DefaultId": redisPatchSchedulesResourceId,
	}

	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds(input, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if !reflect.DeepEqual(expectedNamesToIds, actualNamesToIds) {
		t.Fatalf("expected namesToIds to be %+v but got %+v", expectedNamesToIds, actualNamesToIds)
	}
}
