// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"strings"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func TestTopLevelFieldsWithinResourceId_NoSegmentsShouldError(t *testing.T) {
	input := sdkModels.ResourceID{
		Segments: []sdkModels.ResourceIDSegment{
			// intentionally none
		},
	}
	inputMappings := sdkModels.TerraformMappingDefinition{
		Fields:     []sdkModels.TerraformFieldMappingDefinition{},
		ResourceID: []sdkModels.TerraformResourceIDMappingDefinition{},
	}

	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Nothing", definitions.ResourceDefinition{})
	if err == nil {
		t.Fatalf("expected an error but didn't get one")
	}
	if actualFields != nil {
		t.Fatalf("expected actualFields to be nil when an error is returned but got %+v", actualFields)
	}
	if actualMappings != nil {
		t.Fatalf("expected actualMappings to be nil when an error is returned but got %+v", actualMappings)
	}
}

func TestTopLevelFieldsWithinResourceId_ResourceGroup(t *testing.T) {
	input := sdkModels.ResourceID{
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		},
	}
	inputMappings := sdkModels.TerraformMappingDefinition{
		Fields:     []sdkModels.TerraformFieldMappingDefinition{},
		ResourceID: []sdkModels.TerraformResourceIDMappingDefinition{},
	}

	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Resource Group", definitions.ResourceDefinition{})
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(actualFields) != 1 {
		t.Fatalf("expected actualFields to contain 1 item but got %d", len(actualFields))
	}
	name, ok := (actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != sdkModels.ResourceGroupTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected Name to be a Resource Group Field but got %q", string(name.ObjectDefinition.Type))
	}
	if name.Documentation.Markdown != "Specifies the name of this Resource Group." {
		t.Fatalf("expected the description for `Name` to be `Specifies the name of this Resource Group.` but got %q", name.Documentation.Markdown)
	}

	// then check the mappings
	if actualMappings == nil {
		t.Fatalf("expected actualMappings to be non-nil but was nil")
	}
	if len(actualMappings.Fields) > 0 {
		t.Fatalf("expected no Fields mappings but got %d", len(actualMappings.Fields))
	}
	if len(actualMappings.ResourceID) != 1 {
		t.Fatalf("expected there to be 1 ResourceId mapping but got %d", len(actualMappings.ResourceID))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "Name", "resourceGroupName", false)
}

func TestTopLevelFieldsWithinResourceId_VirtualMachine(t *testing.T) {
	input := sdkModels.ResourceID{
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftCompute", "Microsoft.Compute"),
			sdkModels.NewStaticValueResourceIDSegment("virtualMachines", "virtualMachines"),
			sdkModels.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachineName"),
		},
	}
	inputMappings := sdkModels.TerraformMappingDefinition{
		Fields:     []sdkModels.TerraformFieldMappingDefinition{},
		ResourceID: []sdkModels.TerraformResourceIDMappingDefinition{},
	}

	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Virtual Machine", definitions.ResourceDefinition{})
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(actualFields) != 2 {
		t.Fatalf("expected actualFields to contain 2 items but got %d", len(actualFields))
	}
	resourceGroupName, ok := (actualFields)["ResourceGroupName"]
	if !ok {
		t.Fatalf("expected there to be a field called `ResourceGroupName` but there wasn't")
	}
	if !resourceGroupName.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !resourceGroupName.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if resourceGroupName.ObjectDefinition.Type != sdkModels.ResourceGroupTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected ResourceGroupName to be a Resource Group Field but got %q", string(resourceGroupName.ObjectDefinition.Type))
	}
	if resourceGroupName.Documentation.Markdown != "Specifies the name of the Resource Group within which this Virtual Machine should exist." {
		t.Fatalf("expected the description for `ResourceGroupName` to be `Specifies the name of the Resource Group within which this Virtual Machine should exist.` but got %q", resourceGroupName.Documentation.Markdown)
	}

	name, ok := (actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != sdkModels.StringTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected Name to be a String Field but got %q", string(name.ObjectDefinition.Type))
	}
	if name.Documentation.Markdown != "Specifies the name of this Virtual Machine." {
		t.Fatalf("expected the description for `Name` to be `Specifies the name of this Virtual Machine.` but got %q", name.Documentation.Markdown)
	}

	// then check the mappings
	if actualMappings == nil {
		t.Fatalf("expected actualMappings to be non-nil but was nil")
	}
	if len(actualMappings.Fields) > 0 {
		t.Fatalf("expected no field mappings but got %d", len(actualMappings.Fields))
	}
	if len(actualMappings.ResourceID) != 2 {
		t.Fatalf("expected there to be 2 ResourceId mappings but got %d", len(actualMappings.ResourceID))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "ResourceGroupName", "resourceGroupName", false)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "Name", "virtualMachineName", false)
}

func TestTopLevelFieldsWithinResourceId_VirtualMachineExtension(t *testing.T) {
	input := sdkModels.ResourceID{
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftCompute", "Microsoft.Compute"),
			sdkModels.NewStaticValueResourceIDSegment("virtualMachines", "virtualMachines"),
			sdkModels.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachineName"),
			sdkModels.NewStaticValueResourceIDSegment("extensions", "extensions"),
			sdkModels.NewUserSpecifiedResourceIDSegment("extensionsName", "extensionsName"),
		},
	}
	inputMappings := sdkModels.TerraformMappingDefinition{
		Fields:     []sdkModels.TerraformFieldMappingDefinition{},
		ResourceID: []sdkModels.TerraformResourceIDMappingDefinition{},
	}
	apiResource := sdkModels.APIResource{
		ResourceIDs: map[string]sdkModels.ResourceID{
			"VirtualMachineId": {
				CommonIDAlias: pointer.To("VirtualMachine"),
				Segments: []sdkModels.ResourceIDSegment{
					sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
					sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
					sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftCompute", "Microsoft.Compute"),
					sdkModels.NewStaticValueResourceIDSegment("virtualMachines", "virtualMachines"),
					sdkModels.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachineName"),
				},
			},
		},
	}
	builder := NewBuilder(apiResource)
	actualFields, actualMappings, err := builder.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Virtual Machine Extension", definitions.ResourceDefinition{})
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(actualFields) != 2 {
		t.Fatalf("expected actualFields to contain 2 items but got %d", len(actualFields))
	}

	_, ok := (actualFields)["ResourceGroupName"]
	if ok {
		t.Fatalf("expected the field `ResourceGroupName` be absent")
	}

	virtualMachineId, ok := (actualFields)["VirtualMachineId"]
	if !ok {
		t.Fatalf("expected there to be a field called `VirtualMachineId` but there wasn't")
	}
	if !virtualMachineId.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !virtualMachineId.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if virtualMachineId.ObjectDefinition.Type != sdkModels.StringTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected VirtualMachineName to be a String Field but got %q", string(virtualMachineId.ObjectDefinition.Type))
	}
	if virtualMachineId.Documentation.Markdown != "Specifies the Virtual Machine Id within which this Virtual Machine Extension should exist." {
		t.Fatalf("expected the description for `VirtualMachineId` to be `Specifies the Virtual Machine Id within which this Virtual Machine Extension should exist.` but got %q", virtualMachineId.Documentation.Markdown)
	}

	name, ok := (actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != sdkModels.StringTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected Name to be a String Field but got %q", string(name.ObjectDefinition.Type))
	}
	if name.Documentation.Markdown != "Specifies the name of this Virtual Machine Extension." {
		t.Fatalf("expected the description for `Name` to be `Specifies the name of this Virtual Machine Extension.` but got %q", name.Documentation.Markdown)
	}

	// then check the mappings
	if actualMappings == nil {
		t.Fatalf("expected actualMappings to be non-nil but was nil")
	}
	if len(actualMappings.Fields) > 0 {
		t.Fatalf("expected no field mappings but got %d", len(actualMappings.Fields))
	}
	if len(actualMappings.ResourceID) != 3 {
		t.Fatalf("expected there to be 3 ResourceId mappings but got %d", len(actualMappings.ResourceID))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "VirtualMachineId", "resourceGroupName", true)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "VirtualMachineId", "virtualMachineName", true)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "Name", "extensionsName", false)
}

func TestTopLevelFieldsWithinResourceId_KubernetesTrustedAccessRoleBinding(t *testing.T) {
	input := sdkModels.ResourceID{
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftContainerService", "Microsoft.ContainerService"),
			sdkModels.NewStaticValueResourceIDSegment("staticManagedClusters", "managedClusters"),
			sdkModels.NewUserSpecifiedResourceIDSegment("managedClusterName", "managedClusterName"),
			sdkModels.NewStaticValueResourceIDSegment("trustedAccessRoleBindings", "trustedAccessRoleBindings"),
			sdkModels.NewUserSpecifiedResourceIDSegment("trustedAccessRoleBindingName", "trustedAccessRoleBindingName"),
		},
	}
	inputMappings := sdkModels.TerraformMappingDefinition{
		Fields:     []sdkModels.TerraformFieldMappingDefinition{},
		ResourceID: []sdkModels.TerraformResourceIDMappingDefinition{},
	}
	apiResource := sdkModels.APIResource{
		ResourceIDs: map[string]sdkModels.ResourceID{
			"KubernetesClusterId": {
				CommonIDAlias: pointer.To("KubernetesCluster"),
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{managedClusterName}",
				Segments: []sdkModels.ResourceIDSegment{
					sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
					sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
					sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftContainerService", "Microsoft.ContainerService"),
					sdkModels.NewStaticValueResourceIDSegment("staticManagedClusters", "managedClusters"),
					sdkModels.NewUserSpecifiedResourceIDSegment("managedClusterName", "managedClusterName"),
				},
			},
		},
	}
	builder := NewBuilder(apiResource)
	actualFields, actualMappings, err := builder.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Kubernetes Cluster Trusted Access Role Binding", definitions.ResourceDefinition{})
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(actualFields) != 2 {
		t.Fatalf("expected actualFields to contain 2 items but got %d", len(actualFields))
	}
	_, ok := (actualFields)["ResourceGroupName"]
	if ok {
		t.Fatalf("expected the field `ResourceGroupName` be absent")
	}
	kubernetesClusterId, ok := (actualFields)["KubernetesClusterId"]
	if !ok {
		t.Fatalf("expected there to be a field called `KubernetesClusterId`")
	}
	if !kubernetesClusterId.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !kubernetesClusterId.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if kubernetesClusterId.ObjectDefinition.Type != sdkModels.StringTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected KubernetesClusterId to be a String Field but got %q", string(kubernetesClusterId.ObjectDefinition.Type))
	}
	if kubernetesClusterId.Documentation.Markdown != "Specifies the Kubernetes Cluster Id within which this Kubernetes Cluster Trusted Access Role Binding should exist." {
		t.Fatalf("expected the description for `KubernetesClusterId` to be `Specifies the Kubernetes Cluster Id within which this Kubernetes Cluster Trusted Access Role Binding should exist.` but got %q", kubernetesClusterId.Documentation.Markdown)
	}

	name, ok := (actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != sdkModels.StringTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected Name to be a String Field but got %q", string(name.ObjectDefinition.Type))
	}
	if name.Documentation.Markdown != "Specifies the name of this Kubernetes Cluster Trusted Access Role Binding." {
		t.Fatalf("expected the description for `Name` to be `Specifies the name of this Kubernetes Cluster Trusted Access Role Binding.` but got %q", name.Documentation.Markdown)
	}

	// then check the mappings
	if actualMappings == nil {
		t.Fatalf("expected actualMappings to be non-nil but was nil")
	}
	if len(actualMappings.Fields) > 0 {
		t.Fatalf("expected no field mappings but got %d", len(actualMappings.Fields))
	}
	if len(actualMappings.ResourceID) != 3 {
		t.Fatalf("expected there to be 3 ResourceId mappings but got %d", len(actualMappings.ResourceID))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "KubernetesClusterId", "resourceGroupName", true)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "KubernetesClusterId", "managedClusterName", true)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "Name", "trustedAccessRoleBindingName", false)
}

func TestTopLevelFieldsWithinResourceId_ParentIdSchemaOverride(t *testing.T) {
	input := sdkModels.ResourceID{
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftContainerService", "Microsoft.ContainerService"),
			sdkModels.NewStaticValueResourceIDSegment("staticManagedClusters", "managedClusters"),
			sdkModels.NewUserSpecifiedResourceIDSegment("managedClusterName", "managedClusterName"),
			sdkModels.NewStaticValueResourceIDSegment("trustedAccessRoleBindings", "trustedAccessRoleBindings"),
			sdkModels.NewUserSpecifiedResourceIDSegment("trustedAccessRoleBindingName", "trustedAccessRoleBindingName"),
		},
	}
	inputMappings := sdkModels.TerraformMappingDefinition{
		Fields:     []sdkModels.TerraformFieldMappingDefinition{},
		ResourceID: []sdkModels.TerraformResourceIDMappingDefinition{},
	}
	resourceDefinition := definitions.ResourceDefinition{
		Overrides: &[]definitions.Override{
			{
				Name:        "kubernetes_cluster_id",
				UpdatedName: pointer.To("renamed_cluster_id"),
			},
		},
	}

	apiResource := sdkModels.APIResource{
		ResourceIDs: map[string]sdkModels.ResourceID{
			"KubernetesClusterId": {
				CommonIDAlias: pointer.To("KubernetesCluster"),
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{managedClusterName}",
				Segments: []sdkModels.ResourceIDSegment{
					sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
					sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
					sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftContainerService", "Microsoft.ContainerService"),
					sdkModels.NewStaticValueResourceIDSegment("staticManagedClusters", "managedClusters"),
					sdkModels.NewUserSpecifiedResourceIDSegment("managedClusterName", "managedClusterName"),
				},
			},
		},
	}
	builder := NewBuilder(apiResource)
	actualFields, actualMappings, err := builder.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Kubernetes Cluster Trusted Access Role Binding", resourceDefinition)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(actualFields) != 2 {
		t.Fatalf("expected actualFields to contain 2 items but got %d", len(actualFields))
	}
	_, ok := (actualFields)["ResourceGroupName"]
	if ok {
		t.Fatalf("expected the field `ResourceGroupName` be absent")
	}
	kubernetesClusterId, ok := (actualFields)["RenamedClusterId"]
	if !ok {
		t.Fatalf("expected there to be a field called `RenamedClusterId`")
	}
	if !kubernetesClusterId.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !kubernetesClusterId.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if kubernetesClusterId.ObjectDefinition.Type != sdkModels.StringTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected KubernetesClusterId to be a String Field but got %q", string(kubernetesClusterId.ObjectDefinition.Type))
	}
	if kubernetesClusterId.Documentation.Markdown != "Specifies the Renamed Cluster Id within which this Kubernetes Cluster Trusted Access Role Binding should exist." {
		t.Fatalf("expected the description for `RenamedClusterId` to be `Specifies the Renamed Cluster Id within which this Kubernetes Cluster Trusted Access Role Binding should exist.` but got %q", kubernetesClusterId.Documentation.Markdown)
	}

	name, ok := (actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != sdkModels.StringTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected Name to be a String Field but got %q", string(name.ObjectDefinition.Type))
	}
	if name.Documentation.Markdown != "Specifies the name of this Kubernetes Cluster Trusted Access Role Binding." {
		t.Fatalf("expected the description for `Name` to be `Specifies the name of this Kubernetes Cluster Trusted Access Role Binding.` but got %q", name.Documentation.Markdown)
	}

	// then check the mappings
	if actualMappings == nil {
		t.Fatalf("expected actualMappings to be non-nil but was nil")
	}
	if len(actualMappings.Fields) > 0 {
		t.Fatalf("expected no field mappings but got %d", len(actualMappings.Fields))
	}
	if len(actualMappings.ResourceID) != 3 {
		t.Fatalf("expected there to be 3 ResourceId mappings but got %d", len(actualMappings.ResourceID))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "RenamedClusterId", "resourceGroupName", true)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "RenamedClusterId", "managedClusterName", true)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "Name", "trustedAccessRoleBindingName", false)
}

func TestTopLevelFieldsWithinResourceId_SchemaOverride(t *testing.T) {
	input := sdkModels.ResourceID{
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftChaos", "Microsoft.Chaos"),
			sdkModels.NewStaticValueResourceIDSegment("targets", "targets"),
			sdkModels.NewUserSpecifiedResourceIDSegment("targetName", "targetName"),
		},
	}
	inputMappings := sdkModels.TerraformMappingDefinition{
		Fields:     []sdkModels.TerraformFieldMappingDefinition{},
		ResourceID: []sdkModels.TerraformResourceIDMappingDefinition{},
	}
	resourceDefinition := definitions.ResourceDefinition{
		Overrides: &[]definitions.Override{
			{
				Name:        "name",
				UpdatedName: pointer.To("target_type"),
			},
			{
				Name:        "scope",
				UpdatedName: pointer.To("target_resource_id"),
			},
		},
	}

	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Chaos Studio Target", resourceDefinition)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(actualFields) != 2 {
		t.Fatalf("expected actualFields to contain 2 items but got %d", len(actualFields))
	}
	resourceGroupName, ok := (actualFields)["ResourceGroupName"]
	if !ok {
		t.Fatalf("expected there to be a field called `ResourceGroupName` but there wasn't")
	}
	if !resourceGroupName.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !resourceGroupName.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if resourceGroupName.ObjectDefinition.Type != sdkModels.ResourceGroupTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected ResourceGroupName to be a Resource Group Field but got %q", string(resourceGroupName.ObjectDefinition.Type))
	}
	if resourceGroupName.Documentation.Markdown != "Specifies the name of the Resource Group within which this Chaos Studio Target should exist." {
		t.Fatalf("expected the description for `ResourceGroupName` to be `Specifies the name of the Resource Group within which this Chaos Studio Target should exist.` but got %q", resourceGroupName.Documentation.Markdown)
	}

	targetType, ok := (actualFields)["TargetType"]
	if !ok {
		t.Fatalf("expected there to be a field called `TargetType` but there wasn't")
	}
	if !targetType.Required {
		t.Fatalf("expected the field TargetType to be Required but it wasn't")
	}
	if !targetType.ForceNew {
		t.Fatalf("expected the field TargetType to be ForceNew but it wasn't")
	}
	if targetType.ObjectDefinition.Type != sdkModels.StringTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected TargetType to be a String Field but got %q", string(targetType.ObjectDefinition.Type))
	}
	if targetType.Documentation.Markdown != "Specifies the Target Type of this Chaos Studio Target." {
		t.Fatalf("expected the description for `TargetType` to be `Specifies the Target Type of this Chaos Studio Target.` but got %q", targetType.Documentation.Markdown)
	}

	// then check the mappings
	if actualMappings == nil {
		t.Fatalf("expected actualMappings to be non-nil but was nil")
	}
	if len(actualMappings.Fields) > 0 {
		t.Fatalf("expected no field mappings but got %d", len(actualMappings.Fields))
	}
	if len(actualMappings.ResourceID) != 2 {
		t.Fatalf("expected there to be 2 ResourceId mappings but got %d", len(actualMappings.ResourceID))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "ResourceGroupName", "resourceGroupName", false)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "TargetType", "targetName", false)
}

func TestTopLevelFieldsWithinResourceId_DocumentationOverride(t *testing.T) {
	input := sdkModels.ResourceID{
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftChaos", "Microsoft.Chaos"),
			sdkModels.NewStaticValueResourceIDSegment("targets", "targets"),
			sdkModels.NewUserSpecifiedResourceIDSegment("targetName", "targetName"),
		},
	}
	inputMappings := sdkModels.TerraformMappingDefinition{
		Fields:     []sdkModels.TerraformFieldMappingDefinition{},
		ResourceID: []sdkModels.TerraformResourceIDMappingDefinition{},
	}
	resourceDefinition := definitions.ResourceDefinition{
		Overrides: &[]definitions.Override{
			{
				Name:        "name",
				UpdatedName: pointer.To("target_type"),
				Description: pointer.To("Specifies the Target Type of a Chaos Studio Target. Plus some additional useful information here."),
			},
			{
				Name:        "scope",
				UpdatedName: pointer.To("target_resource_id"),
			},
		},
	}

	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Chaos Studio Target", resourceDefinition)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(actualFields) != 2 {
		t.Fatalf("expected actualFields to contain 2 items but got %d", len(actualFields))
	}
	resourceGroupName, ok := (actualFields)["ResourceGroupName"]
	if !ok {
		t.Fatalf("expected there to be a field called `ResourceGroupName` but there wasn't")
	}
	if !resourceGroupName.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !resourceGroupName.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if resourceGroupName.ObjectDefinition.Type != sdkModels.ResourceGroupTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected ResourceGroupName to be a Resource Group Field but got %q", string(resourceGroupName.ObjectDefinition.Type))
	}
	if resourceGroupName.Documentation.Markdown != "Specifies the name of the Resource Group within which this Chaos Studio Target should exist." {
		t.Fatalf("expected the description for `ResourceGroupName` to be `Specifies the name of the Resource Group within which this Chaos Studio Target should exist.` but got %q", resourceGroupName.Documentation.Markdown)
	}

	targetType, ok := (actualFields)["TargetType"]
	if !ok {
		t.Fatalf("expected there to be a field called `TargetType` but there wasn't")
	}
	if !targetType.Required {
		t.Fatalf("expected the field TargetType to be Required but it wasn't")
	}
	if !targetType.ForceNew {
		t.Fatalf("expected the field TargetType to be ForceNew but it wasn't")
	}
	if targetType.ObjectDefinition.Type != sdkModels.StringTerraformSchemaObjectDefinitionType {
		t.Fatalf("expected TargetType to be a String Field but got %q", string(targetType.ObjectDefinition.Type))
	}
	if targetType.Documentation.Markdown != "Specifies the Target Type of a Chaos Studio Target. Plus some additional useful information here." {
		t.Fatalf("expected the description for `TargetType` to be `Specifies the Target Type of a Chaos Studio Target. Plus some additional useful information here.` but got %q", targetType.Documentation.Markdown)
	}

	// then check the mappings
	if actualMappings == nil {
		t.Fatalf("expected actualMappings to be non-nil but was nil")
	}
	if len(actualMappings.Fields) > 0 {
		t.Fatalf("expected no field mappings but got %d", len(actualMappings.Fields))
	}
	if len(actualMappings.ResourceID) != 2 {
		t.Fatalf("expected there to be 2 ResourceId mappings but got %d", len(actualMappings.ResourceID))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "ResourceGroupName", "resourceGroupName", false)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "TargetType", "targetName", false)
}

func checkResourceIdMappingExistsBetween(t *testing.T, mappings []sdkModels.TerraformResourceIDMappingDefinition, schemaFieldName, segmentName string, parent bool) {
	found := false
	for _, item := range mappings {
		if strings.EqualFold(item.TerraformSchemaFieldName, schemaFieldName) && strings.EqualFold(item.SegmentName, segmentName) && item.ParsedFromParentID == parent {
			found = true
			break
		}
	}
	if !found {
		t.Fatalf("expected there to be a Resource ID Mapping from Schema Field %q to Segment Name %q but there wasn't", schemaFieldName, segmentName)
	}
}
