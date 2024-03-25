// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"reflect"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var subscriptionResourceId = models.ResourceID{
	ConstantNames: []string{},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
	},
}
var resourceGroupResourceId = models.ResourceID{
	ConstantNames: []string{},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
		models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
		models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
		models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
	},
}
var managementGroupResourceId = models.ResourceID{
	ConstantNames: []string{},
	Segments: []models.ResourceIDSegment{
		models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		models.NewResourceProviderResourceIDSegment("staticMicrosoftManagement", "Microsoft.Management"),
		models.NewStaticValueResourceIDSegment("staticManagementGroups", "managementGroups"),
		models.NewUserSpecifiedResourceIDSegment("name", "name"),
	},
}
var virtualMachineResourceId = models.ResourceID{
	ConstantNames: []string{},
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
var virtualMachineExtensionResourceId = models.ResourceID{
	ConstantNames: []string{},
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
var virtualNetworkExtensionResourceId = models.ResourceID{
	ConstantNames: []string{},
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
var scopedMonitorResourceId = models.ResourceID{
	ConstantNames: []string{},
	Segments: []models.ResourceIDSegment{
		models.NewScopeResourceIDSegment("scope"),
		models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
		models.NewResourceProviderResourceIDSegment("staticMicrosoftMonitor", "Microsoft.Monitor"),
		models.NewStaticValueResourceIDSegment("staticExtensions", "extensions"),
		models.NewUserSpecifiedResourceIDSegment("extensionName", "extensionValue"),
	},
}
var signalRResourceId = models.ResourceID{
	ConstantNames: []string{},
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
var eventHubSkuResourceId = models.ResourceID{
	ConstantNames: []string{},
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
var trafficManagerProfileResourceId = models.ResourceID{
	ConstantNames: []string{
		"EndpointType",
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
var redisPatchSchedulesResourceId = models.ResourceID{
	ConstantNames: []string{
		"Default",
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
	actualNamesToIds, err := generateNamesForResourceIds([]models.ResourceID{}, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if len(*actualNamesToIds) > 0 {
		t.Fatalf("expected there to be no namesToIds but got %+v", *actualNamesToIds)
	}
}

func TestResourceIDNamingSubscriptionId(t *testing.T) {
	input := []models.ResourceID{
		subscriptionResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		// intentionally here twice
		subscriptionResourceId,
		subscriptionResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		resourceGroupResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		// intentionally in here twice
		resourceGroupResourceId,
		resourceGroupResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		managementGroupResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		// intentionally here twice
		managementGroupResourceId,
		managementGroupResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		eventHubSkuResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	scopeResourceId := models.ResourceID{
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewScopeResourceIDSegment("scope"),
		},
	}

	input := []models.ResourceID{
		scopeResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	dnsResourceId := models.ResourceID{
		ConstantNames: []string{
			"DnsRecordType",
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

	input := []models.ResourceID{
		dnsResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	dnsResourceId := models.ResourceID{
		ConstantNames: []string{
			"DnsRecordType",
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

	input := []models.ResourceID{
		// intentionally in here twice
		dnsResourceId,
		dnsResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		virtualMachineResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		virtualMachineResourceId,
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		scopedMonitorResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		virtualNetworkExtensionResourceId,
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		virtualNetworkExtensionResourceId,
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
		"VirtualMachineExtensionId": virtualMachineExtensionResourceId,
		"ExtensionId":               virtualNetworkExtensionResourceId,
	}
	uriToParsedOperation := map[string]ParsedOperation{
		helpers.DisplayValueForResourceID(virtualMachineExtensionResourceId): {
			ResourceId:     &virtualMachineExtensionResourceId,
			ResourceIdName: pointer.To("ExtensionId"),
		},
		helpers.DisplayValueForResourceID(virtualNetworkExtensionResourceId): {
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
		id := helpers.DisplayValueForResourceID(resourceID)
		got := uriToParsedOperation[id].ResourceIdName
		if got == nil || *got != wantIDName {
			t.Fatalf("expected ResourceIdName of virtualMachineResourceId to be: %s\nbut got:%s\n", wantIDName, *got)
		}
	}
}

func TestResourceIdNamingConflictingMultipleLevels(t *testing.T) {
	workerPoolInstanceResourceId := models.ResourceID{
		ConstantNames: []string{},
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
	multiRolePoolInstanceResourceId := models.ResourceID{
		ConstantNames: []string{},
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
	slotInstanceProcessModuleResourceId := models.ResourceID{
		ConstantNames: []string{},
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
	instanceProcessModuleResourceId := models.ResourceID{
		ConstantNames: []string{},
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

	input := []models.ResourceID{
		workerPoolInstanceResourceId,
		multiRolePoolInstanceResourceId,
		slotInstanceProcessModuleResourceId,
		instanceProcessModuleResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		signalRResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		trafficManagerProfileResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
	input := []models.ResourceID{
		redisPatchSchedulesResourceId,
	}
	expectedNamesToIds := map[string]models.ResourceID{
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
