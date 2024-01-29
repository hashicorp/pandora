// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"reflect"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var subscriptionResourceId = models.ParsedResourceId{
	Constants: map[string]resourcemanager.ConstantDetails{},
	Segments: []resourcemanager.ResourceIdSegment{
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Name: "subscriptionId",
			Type: resourcemanager.SubscriptionIdSegment,
		},
	},
}
var resourceGroupResourceId = models.ParsedResourceId{
	Constants: map[string]resourcemanager.ConstantDetails{},
	Segments: []resourcemanager.ResourceIdSegment{
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Name: "subscriptionId",
			Type: resourcemanager.SubscriptionIdSegment,
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("resourceGroups"),
			Name:       "staticResourceGroups",
		},
		{
			Name: "resourceGroupName",
			Type: resourcemanager.ResourceGroupSegment,
		},
	},
}
var managementGroupResourceId = models.ParsedResourceId{
	Constants: map[string]resourcemanager.ConstantDetails{},
	Segments: []resourcemanager.ResourceIdSegment{
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       resourcemanager.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.Management"),
			Name:       "Microsoft.Management",
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("managementGroups"),
			Name:       "staticManagementGroups",
		},
		{
			Name: "name",
			Type: resourcemanager.UserSpecifiedSegment,
		},
	},
}
var virtualMachineResourceId = models.ParsedResourceId{
	Constants: map[string]resourcemanager.ConstantDetails{},
	Segments: []resourcemanager.ResourceIdSegment{
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Name: "subscriptionId",
			Type: resourcemanager.SubscriptionIdSegment,
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("resourceGroups"),
			Name:       "staticResourceGroups",
		},
		{
			Name: "resourceGroupName",
			Type: resourcemanager.ResourceGroupSegment,
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       resourcemanager.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.Compute"),
			Name:       "staticMicrosoftCompute",
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("virtualMachines"),
			Name:       "staticVirtualMachines",
		},
		{
			Name: "virtualMachineName",
			Type: resourcemanager.UserSpecifiedSegment,
		},
	},
}
var virtualMachineExtensionResourceId = models.ParsedResourceId{
	Constants: map[string]resourcemanager.ConstantDetails{},
	Segments: []resourcemanager.ResourceIdSegment{
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Name: "subscriptionId",
			Type: resourcemanager.SubscriptionIdSegment,
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("resourceGroups"),
			Name:       "staticResourceGroups",
		},
		{
			Name: "resourceGroupName",
			Type: resourcemanager.ResourceGroupSegment,
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       resourcemanager.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.Compute"),
			Name:       "staticMicrosoftCompute",
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("virtualMachines"),
			Name:       "staticVirtualMachines",
		},
		{
			Name: "virtualMachineName",
			Type: resourcemanager.UserSpecifiedSegment,
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("extensions"),
			Name:       "staticExtensions",
		},
		{
			Name: "extensionName",
			Type: resourcemanager.UserSpecifiedSegment,
		},
	},
}
var virtualNetworkExtensionResourceId = models.ParsedResourceId{
	Constants: map[string]resourcemanager.ConstantDetails{},
	Segments: []resourcemanager.ResourceIdSegment{
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Name: "subscriptionId",
			Type: resourcemanager.SubscriptionIdSegment,
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("resourceGroups"),
			Name:       "staticResourceGroups",
		},
		{
			Name: "resourceGroupName",
			Type: resourcemanager.ResourceGroupSegment,
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       resourcemanager.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.Network"),
			Name:       "staticMicrosoftNetwork",
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("extensions"),
			Name:       "staticExtensions",
		},
		{
			Name: "extensionName",
			Type: resourcemanager.UserSpecifiedSegment,
		},
	},
}
var scopedMonitorResourceId = models.ParsedResourceId{
	Constants: map[string]resourcemanager.ConstantDetails{},
	Segments: []resourcemanager.ResourceIdSegment{
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
			FixedValue: strPtr("Microsoft.Monitor"),
			Name:       "staticMicrosoftMonitor",
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("extensions"),
			Name:       "staticExtensions",
		},
		{
			Name: "extensionName",
			Type: resourcemanager.UserSpecifiedSegment,
		},
	},
}
var signalRResourceId = models.ParsedResourceId{
	Constants: map[string]resourcemanager.ConstantDetails{},
	Segments: []resourcemanager.ResourceIdSegment{
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("subscriptions"),
			Name:       "staticSubscriptions",
		},
		{
			Name: "subscriptionId",
			Type: resourcemanager.SubscriptionIdSegment,
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("resourceGroups"),
			Name:       "staticResourceGroups",
		},
		{
			Name: "resourceGroupName",
			Type: resourcemanager.ResourceGroupSegment,
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       resourcemanager.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.SignalRService"),
			Name:       "staticMicrosoftSignalRService",
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("SignalR"),
			Name:       "staticSignalR",
		},
		{
			Name: "resourceName",
			Type: resourcemanager.UserSpecifiedSegment,
		},
	},
}
var eventHubSkuResourceId = models.ParsedResourceId{
	Constants: map[string]resourcemanager.ConstantDetails{},
	Segments: []resourcemanager.ResourceIdSegment{
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
			FixedValue: strPtr("providers"),
			Name:       "staticProviders",
		},
		{
			Type:       resourcemanager.ResourceProviderSegment,
			FixedValue: strPtr("Microsoft.EventHub"),
			Name:       "staticMicrosoftEventHub",
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("sku"),
			Name:       "staticSku",
		},
		{
			Type:       resourcemanager.UserSpecifiedSegment,
			FixedValue: strPtr("sku"),
			Name:       "sku",
		},
	},
}
var trafficManagerProfileResourceId = models.ParsedResourceId{
	Constants: map[string]resourcemanager.ConstantDetails{
		"EndpointType": {
			Type: resourcemanager.StringConstant,
			Values: map[string]string{
				"AzureEndpoints":    "azureEndpoints",
				"ExternalEndpoints": "externalEndpoints",
				"NestedEndpoints":   "nestedEndpoints",
			},
		},
	},
	Segments: []resourcemanager.ResourceIdSegment{
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
			FixedValue: strPtr("Microsoft.Network"),
			Name:       "microsoftNetwork",
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("trafficManagerProfiles"),
			Name:       "staticTrafficManagerProfiles",
		},
		{
			Type:       resourcemanager.UserSpecifiedSegment,
			FixedValue: strPtr("profileName"),
			Name:       "profileName",
		},
		{
			Type:              resourcemanager.ConstantSegment,
			ConstantReference: strPtr("EndpointType"),
			Name:              "endpointType",
		},
		{
			Type:       resourcemanager.UserSpecifiedSegment,
			FixedValue: strPtr("endpointName"),
			Name:       "endpointName",
		},
	},
}
var redisPatchSchedulesResourceId = models.ParsedResourceId{
	Constants: map[string]resourcemanager.ConstantDetails{
		"Default": {
			Type: resourcemanager.StringConstant,
			Values: map[string]string{
				"First": "first",
			},
		},
	},
	Segments: []resourcemanager.ResourceIdSegment{
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
			FixedValue: strPtr("Microsoft.Cache"),
			Name:       "staticMicrosoftCache",
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("redis"),
			Name:       "staticRedis",
		},
		{
			Type:       resourcemanager.UserSpecifiedSegment,
			FixedValue: strPtr("name"),
			Name:       "name",
		},
		{
			Type:       resourcemanager.StaticSegment,
			FixedValue: strPtr("patchSchedules"),
			Name:       "staticPatchSchedules",
		},
		{
			Type:              resourcemanager.ConstantSegment,
			ConstantReference: strPtr("default"),
			Name:              "default",
		},
	},
}

func TestResourceIDNamingEmpty(t *testing.T) {
	uriToParsedOperation := map[string]ParsedOperation{}
	actualNamesToIds, err := generateNamesForResourceIds([]models.ParsedResourceId{}, uriToParsedOperation)
	if err != nil {
		t.Fatalf("error: %+v", err)
		return
	}

	if len(*actualNamesToIds) > 0 {
		t.Fatalf("expected there to be no namesToIds but got %+v", *actualNamesToIds)
	}
}

func TestResourceIDNamingSubscriptionId(t *testing.T) {
	input := []models.ParsedResourceId{
		subscriptionResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		// intentionally here twice
		subscriptionResourceId,
		subscriptionResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		resourceGroupResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		// intentionally in here twice
		resourceGroupResourceId,
		resourceGroupResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		managementGroupResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		// intentionally here twice
		managementGroupResourceId,
		managementGroupResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		eventHubSkuResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	scopeResourceId := models.ParsedResourceId{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			{
				Type: resourcemanager.ScopeSegment,
				Name: "scope",
			},
		},
	}

	input := []models.ParsedResourceId{
		scopeResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	dnsResourceId := models.ParsedResourceId{
		Constants: map[string]resourcemanager.ConstantDetails{
			"DnsRecordType": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"A":    "A",
					"AAAA": "AAAA",
				},
			},
		},
		Segments: []resourcemanager.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "subscriptions",
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "resourceGroups",
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "providers",
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Network"),
				Name:       "Microsoft.Network",
			},
			{
				Type:              resourcemanager.ConstantSegment,
				Name:              "recordType",
				ConstantReference: strPtr("DnsRecordType"),
			},
			{
				Name: "recordName",
				Type: resourcemanager.UserSpecifiedSegment,
			},
		},
	}

	input := []models.ParsedResourceId{
		dnsResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	dnsResourceId := models.ParsedResourceId{
		Constants: map[string]resourcemanager.ConstantDetails{
			"DnsRecordType": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"A":    "A",
					"AAAA": "AAAA",
				},
			},
		},
		Segments: []resourcemanager.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "subscriptions",
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "resourceGroups",
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "providers",
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Network"),
				Name:       "Microsoft.Network",
			},
			{
				Type:              resourcemanager.ConstantSegment,
				Name:              "recordType",
				ConstantReference: strPtr("DnsRecordType"),
			},
			{
				Name: "recordName",
				Type: resourcemanager.UserSpecifiedSegment,
			},
		},
	}

	input := []models.ParsedResourceId{
		// intentionally in here twice
		dnsResourceId,
		dnsResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		virtualMachineResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		virtualMachineResourceId,
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		scopedMonitorResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		virtualNetworkExtensionResourceId,
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		virtualNetworkExtensionResourceId,
		virtualMachineExtensionResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	workerPoolInstanceResourceId := models.ParsedResourceId{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "subscriptions",
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "resourceGroups",
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "providers",
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Web"),
				Name:       "Microsoft.Web",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("hostingEnvironments"),
				Name:       "hostingEnvironments",
			},
			{
				Name: "name",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("workerPools"),
				Name:       "workerPools",
			},
			{
				Name: "workerPoolName",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("instances"),
				Name:       "instances",
			},
			{
				Name: "instance",
				Type: resourcemanager.UserSpecifiedSegment,
			},
		},
	}
	multiRolePoolInstanceResourceId := models.ParsedResourceId{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "subscriptions",
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "resourceGroups",
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "providers",
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Web"),
				Name:       "Microsoft.Web",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("hostingEnvironments"),
				Name:       "hostingEnvironments",
			},
			{
				Name: "name",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("multiRolePools"),
				Name:       "multiRolePools",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("default"),
				Name:       "default",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("instances"),
				Name:       "instances",
			},
			{
				Name: "instance",
				Type: resourcemanager.UserSpecifiedSegment,
			},
		},
	}
	slotInstanceProcessModuleResourceId := models.ParsedResourceId{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "subscriptions",
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "resourceGroups",
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "providers",
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Web"),
				Name:       "Microsoft.Web",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("sites"),
				Name:       "sites",
			},
			{
				Name: "name",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("slots"),
				Name:       "slots",
			},
			{
				Name: "slot",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("instances"),
				Name:       "instances",
			},
			{
				Name: "instanceId",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("processes"),
				Name:       "processes",
			},
			{
				Name: "processId",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("modules"),
				Name:       "modules",
			},
			{
				Name: "baseAddress",
				Type: resourcemanager.UserSpecifiedSegment,
			},
		},
	}
	instanceProcessModuleResourceId := models.ParsedResourceId{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("subscriptions"),
				Name:       "subscriptions",
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
				Name:       "resourceGroups",
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("providers"),
				Name:       "providers",
			},
			{
				Type:       resourcemanager.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Web"),
				Name:       "Microsoft.Web",
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("sites"),
				Name:       "sites",
			},
			{
				Name: "name",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("instances"),
				Name:       "instances",
			},
			{
				Name: "instanceId",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("processes"),
				Name:       "processes",
			},
			{
				Name: "processId",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				Type:       resourcemanager.StaticSegment,
				FixedValue: strPtr("modules"),
				Name:       "modules",
			},
			{
				Name: "baseAddress",
				Type: resourcemanager.UserSpecifiedSegment,
			},
		},
	}

	input := []models.ParsedResourceId{
		workerPoolInstanceResourceId,
		multiRolePoolInstanceResourceId,
		slotInstanceProcessModuleResourceId,
		instanceProcessModuleResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		signalRResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		trafficManagerProfileResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
	input := []models.ParsedResourceId{
		redisPatchSchedulesResourceId,
	}
	expectedNamesToIds := map[string]models.ParsedResourceId{
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
