// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"strings"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestTopLevelFieldsWithinResourceId_NoSegmentsShouldError(t *testing.T) {
	input := models.ResourceID{
		Segments: []models.ResourceIDSegment{
			// intentionally none
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}

	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Nothing", &importerModels.ResourceBuildInfo{}, hclog.New(hclog.DefaultOptions))
	if err == nil {
		t.Fatalf("expected an error but didn't get one")
	}
	if actualFields != nil {
		t.Fatalf("expected actualFields to be nil when an error is returned but got %+v", *actualFields)
	}
	if actualMappings != nil {
		t.Fatalf("expected actualMappings to be nil when an error is returned but got %+v", *actualMappings)
	}
}

func TestTopLevelFieldsWithinResourceId_ResourceGroup(t *testing.T) {
	input := models.ResourceID{
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}

	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Resource Group", &importerModels.ResourceBuildInfo{}, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(*actualFields) != 1 {
		t.Fatalf("expected actualFields to contain 1 item but got %d", len(*actualFields))
	}
	name, ok := (*actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeResourceGroup {
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
	if len(actualMappings.ResourceId) != 1 {
		t.Fatalf("expected there to be 1 ResourceId mapping but got %d", len(actualMappings.ResourceId))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "Name", "resourceGroupName", false)
}

func TestTopLevelFieldsWithinResourceId_VirtualMachine(t *testing.T) {
	input := models.ResourceID{
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftCompute", "Microsoft.Compute"),
			models.NewStaticValueResourceIDSegment("virtualMachines", "virtualMachines"),
			models.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachineName"),
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}

	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Virtual Machine", &importerModels.ResourceBuildInfo{}, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(*actualFields) != 2 {
		t.Fatalf("expected actualFields to contain 2 items but got %d", len(*actualFields))
	}
	resourceGroupName, ok := (*actualFields)["ResourceGroupName"]
	if !ok {
		t.Fatalf("expected there to be a field called `ResourceGroupName` but there wasn't")
	}
	if !resourceGroupName.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !resourceGroupName.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if resourceGroupName.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeResourceGroup {
		t.Fatalf("expected ResourceGroupName to be a Resource Group Field but got %q", string(resourceGroupName.ObjectDefinition.Type))
	}
	if resourceGroupName.Documentation.Markdown != "Specifies the name of the Resource Group within which this Virtual Machine should exist." {
		t.Fatalf("expected the description for `ResourceGroupName` to be `Specifies the name of the Resource Group within which this Virtual Machine should exist.` but got %q", resourceGroupName.Documentation.Markdown)
	}

	name, ok := (*actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
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
	if len(actualMappings.ResourceId) != 2 {
		t.Fatalf("expected there to be 2 ResourceId mappings but got %d", len(actualMappings.ResourceId))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "ResourceGroupName", "resourceGroupName", false)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "Name", "virtualMachineName", false)
}

func TestTopLevelFieldsWithinResourceId_VirtualMachineExtension(t *testing.T) {
	input := models.ResourceID{
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftCompute", "Microsoft.Compute"),
			models.NewStaticValueResourceIDSegment("virtualMachines", "virtualMachines"),
			models.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachineName"),
			models.NewStaticValueResourceIDSegment("extensions", "extensions"),
			models.NewUserSpecifiedResourceIDSegment("extensionsName", "extensionsName"),
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	apiResource := models.APIResource{
		ResourceIDs: map[string]models.ResourceID{
			"VirtualMachineId": {
				CommonIDAlias: pointer.To("VirtualMachine"),
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
					models.NewStaticValueResourceIDSegment("providers", "providers"),
					models.NewResourceProviderResourceIDSegment("staticMicrosoftCompute", "Microsoft.Compute"),
					models.NewStaticValueResourceIDSegment("virtualMachines", "virtualMachines"),
					models.NewUserSpecifiedResourceIDSegment("virtualMachineName", "virtualMachineName"),
				},
			},
		},
	}
	builder := NewBuilder(apiResource)
	actualFields, actualMappings, err := builder.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Virtual Machine Extension", &importerModels.ResourceBuildInfo{}, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(*actualFields) != 2 {
		t.Fatalf("expected actualFields to contain 2 items but got %d", len(*actualFields))
	}

	_, ok := (*actualFields)["ResourceGroupName"]
	if ok {
		t.Fatalf("expected the field `ResourceGroupName` be absent")
	}

	virtualMachineId, ok := (*actualFields)["VirtualMachineId"]
	if !ok {
		t.Fatalf("expected there to be a field called `VirtualMachineId` but there wasn't")
	}
	if !virtualMachineId.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !virtualMachineId.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if virtualMachineId.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Fatalf("expected VirtualMachineName to be a String Field but got %q", string(virtualMachineId.ObjectDefinition.Type))
	}
	if virtualMachineId.Documentation.Markdown != "Specifies the Virtual Machine Id within which this Virtual Machine Extension should exist." {
		t.Fatalf("expected the description for `VirtualMachineId` to be `Specifies the Virtual Machine Id within which this Virtual Machine Extension should exist.` but got %q", virtualMachineId.Documentation.Markdown)
	}

	name, ok := (*actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
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
	if len(actualMappings.ResourceId) != 3 {
		t.Fatalf("expected there to be 3 ResourceId mappings but got %d", len(actualMappings.ResourceId))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "VirtualMachineId", "resourceGroupName", true)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "VirtualMachineId", "virtualMachineName", true)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "Name", "extensionsName", false)
}

func TestTopLevelFieldsWithinResourceId_KubernetesTrustedAccessRoleBinding(t *testing.T) {
	input := models.ResourceID{
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftContainerService", "Microsoft.ContainerService"),
			models.NewStaticValueResourceIDSegment("staticManagedClusters", "managedClusters"),
			models.NewUserSpecifiedResourceIDSegment("managedClusterName", "managedClusterName"),
			models.NewStaticValueResourceIDSegment("trustedAccessRoleBindings", "trustedAccessRoleBindings"),
			models.NewUserSpecifiedResourceIDSegment("trustedAccessRoleBindingName", "trustedAccessRoleBindingName"),
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	apiResource := models.APIResource{
		ResourceIDs: map[string]models.ResourceID{
			"KubernetesClusterId": {
				CommonIDAlias: pointer.To("KubernetesCluster"),
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{managedClusterName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
					models.NewStaticValueResourceIDSegment("providers", "providers"),
					models.NewResourceProviderResourceIDSegment("staticMicrosoftContainerService", "Microsoft.ContainerService"),
					models.NewStaticValueResourceIDSegment("staticManagedClusters", "managedClusters"),
					models.NewUserSpecifiedResourceIDSegment("managedClusterName", "managedClusterName"),
				},
			},
		},
	}
	builder := NewBuilder(apiResource)
	actualFields, actualMappings, err := builder.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Kubernetes Cluster Trusted Access Role Binding", &importerModels.ResourceBuildInfo{}, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(*actualFields) != 2 {
		t.Fatalf("expected actualFields to contain 2 items but got %d", len(*actualFields))
	}
	_, ok := (*actualFields)["ResourceGroupName"]
	if ok {
		t.Fatalf("expected the field `ResourceGroupName` be absent")
	}
	kubernetesClusterId, ok := (*actualFields)["KubernetesClusterId"]
	if !ok {
		t.Fatalf("expected there to be a field called `KubernetesClusterId`")
	}
	if !kubernetesClusterId.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !kubernetesClusterId.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if kubernetesClusterId.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Fatalf("expected KubernetesClusterId to be a String Field but got %q", string(kubernetesClusterId.ObjectDefinition.Type))
	}
	if kubernetesClusterId.Documentation.Markdown != "Specifies the Kubernetes Cluster Id within which this Kubernetes Cluster Trusted Access Role Binding should exist." {
		t.Fatalf("expected the description for `KubernetesClusterId` to be `Specifies the Kubernetes Cluster Id within which this Kubernetes Cluster Trusted Access Role Binding should exist.` but got %q", kubernetesClusterId.Documentation.Markdown)
	}

	name, ok := (*actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
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
	if len(actualMappings.ResourceId) != 3 {
		t.Fatalf("expected there to be 3 ResourceId mappings but got %d", len(actualMappings.ResourceId))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "KubernetesClusterId", "resourceGroupName", true)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "KubernetesClusterId", "managedClusterName", true)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "Name", "trustedAccessRoleBindingName", false)
}

func TestTopLevelFieldsWithinResourceId_ParentIdSchemaOverride(t *testing.T) {
	input := models.ResourceID{
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftContainerService", "Microsoft.ContainerService"),
			models.NewStaticValueResourceIDSegment("staticManagedClusters", "managedClusters"),
			models.NewUserSpecifiedResourceIDSegment("managedClusterName", "managedClusterName"),
			models.NewStaticValueResourceIDSegment("trustedAccessRoleBindings", "trustedAccessRoleBindings"),
			models.NewUserSpecifiedResourceIDSegment("trustedAccessRoleBindingName", "trustedAccessRoleBindingName"),
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	inputResourceBuildInfo := importerModels.ResourceBuildInfo{
		Overrides: []importerModels.Override{
			{
				Name:        "kubernetes_cluster_id",
				UpdatedName: pointer.To("renamed_cluster_id"),
			},
		},
	}

	apiResource := models.APIResource{
		ResourceIDs: map[string]models.ResourceID{
			"KubernetesClusterId": {
				CommonIDAlias: pointer.To("KubernetesCluster"),
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{managedClusterName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
					models.NewStaticValueResourceIDSegment("providers", "providers"),
					models.NewResourceProviderResourceIDSegment("staticMicrosoftContainerService", "Microsoft.ContainerService"),
					models.NewStaticValueResourceIDSegment("staticManagedClusters", "managedClusters"),
					models.NewUserSpecifiedResourceIDSegment("managedClusterName", "managedClusterName"),
				},
			},
		},
	}
	builder := NewBuilder(apiResource)
	actualFields, actualMappings, err := builder.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Kubernetes Cluster Trusted Access Role Binding", &inputResourceBuildInfo, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(*actualFields) != 2 {
		t.Fatalf("expected actualFields to contain 2 items but got %d", len(*actualFields))
	}
	_, ok := (*actualFields)["ResourceGroupName"]
	if ok {
		t.Fatalf("expected the field `ResourceGroupName` be absent")
	}
	kubernetesClusterId, ok := (*actualFields)["RenamedClusterId"]
	if !ok {
		t.Fatalf("expected there to be a field called `RenamedClusterId`")
	}
	if !kubernetesClusterId.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !kubernetesClusterId.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if kubernetesClusterId.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Fatalf("expected KubernetesClusterId to be a String Field but got %q", string(kubernetesClusterId.ObjectDefinition.Type))
	}
	if kubernetesClusterId.Documentation.Markdown != "Specifies the Renamed Cluster Id within which this Kubernetes Cluster Trusted Access Role Binding should exist." {
		t.Fatalf("expected the description for `RenamedClusterId` to be `Specifies the Renamed Cluster Id within which this Kubernetes Cluster Trusted Access Role Binding should exist.` but got %q", kubernetesClusterId.Documentation.Markdown)
	}

	name, ok := (*actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
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
	if len(actualMappings.ResourceId) != 3 {
		t.Fatalf("expected there to be 3 ResourceId mappings but got %d", len(actualMappings.ResourceId))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "RenamedClusterId", "resourceGroupName", true)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "RenamedClusterId", "managedClusterName", true)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "Name", "trustedAccessRoleBindingName", false)
}

func TestTopLevelFieldsWithinResourceId_SchemaOverride(t *testing.T) {
	input := models.ResourceID{
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftChaos", "Microsoft.Chaos"),
			models.NewStaticValueResourceIDSegment("targets", "targets"),
			models.NewUserSpecifiedResourceIDSegment("targetName", "targetName"),
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	inputResourceBuildInfo := importerModels.ResourceBuildInfo{
		Overrides: []importerModels.Override{
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

	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Chaos Studio Target", &inputResourceBuildInfo, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(*actualFields) != 2 {
		t.Fatalf("expected actualFields to contain 2 items but got %d", len(*actualFields))
	}
	resourceGroupName, ok := (*actualFields)["ResourceGroupName"]
	if !ok {
		t.Fatalf("expected there to be a field called `ResourceGroupName` but there wasn't")
	}
	if !resourceGroupName.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !resourceGroupName.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if resourceGroupName.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeResourceGroup {
		t.Fatalf("expected ResourceGroupName to be a Resource Group Field but got %q", string(resourceGroupName.ObjectDefinition.Type))
	}
	if resourceGroupName.Documentation.Markdown != "Specifies the name of the Resource Group within which this Chaos Studio Target should exist." {
		t.Fatalf("expected the description for `ResourceGroupName` to be `Specifies the name of the Resource Group within which this Chaos Studio Target should exist.` but got %q", resourceGroupName.Documentation.Markdown)
	}

	targetType, ok := (*actualFields)["TargetType"]
	if !ok {
		t.Fatalf("expected there to be a field called `TargetType` but there wasn't")
	}
	if !targetType.Required {
		t.Fatalf("expected the field TargetType to be Required but it wasn't")
	}
	if !targetType.ForceNew {
		t.Fatalf("expected the field TargetType to be ForceNew but it wasn't")
	}
	if targetType.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
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
	if len(actualMappings.ResourceId) != 2 {
		t.Fatalf("expected there to be 2 ResourceId mappings but got %d", len(actualMappings.ResourceId))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "ResourceGroupName", "resourceGroupName", false)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "TargetType", "targetName", false)
}

func TestTopLevelFieldsWithinResourceId_DocumentationOverride(t *testing.T) {
	input := models.ResourceID{
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftChaos", "Microsoft.Chaos"),
			models.NewStaticValueResourceIDSegment("targets", "targets"),
			models.NewUserSpecifiedResourceIDSegment("targetName", "targetName"),
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	inputResourceBuildInfo := importerModels.ResourceBuildInfo{
		Overrides: []importerModels.Override{
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

	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, "Chaos Studio Target", &inputResourceBuildInfo, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(*actualFields) != 2 {
		t.Fatalf("expected actualFields to contain 2 items but got %d", len(*actualFields))
	}
	resourceGroupName, ok := (*actualFields)["ResourceGroupName"]
	if !ok {
		t.Fatalf("expected there to be a field called `ResourceGroupName` but there wasn't")
	}
	if !resourceGroupName.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !resourceGroupName.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if resourceGroupName.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeResourceGroup {
		t.Fatalf("expected ResourceGroupName to be a Resource Group Field but got %q", string(resourceGroupName.ObjectDefinition.Type))
	}
	if resourceGroupName.Documentation.Markdown != "Specifies the name of the Resource Group within which this Chaos Studio Target should exist." {
		t.Fatalf("expected the description for `ResourceGroupName` to be `Specifies the name of the Resource Group within which this Chaos Studio Target should exist.` but got %q", resourceGroupName.Documentation.Markdown)
	}

	targetType, ok := (*actualFields)["TargetType"]
	if !ok {
		t.Fatalf("expected there to be a field called `TargetType` but there wasn't")
	}
	if !targetType.Required {
		t.Fatalf("expected the field TargetType to be Required but it wasn't")
	}
	if !targetType.ForceNew {
		t.Fatalf("expected the field TargetType to be ForceNew but it wasn't")
	}
	if targetType.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
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
	if len(actualMappings.ResourceId) != 2 {
		t.Fatalf("expected there to be 2 ResourceId mappings but got %d", len(actualMappings.ResourceId))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "ResourceGroupName", "resourceGroupName", false)
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "TargetType", "targetName", false)
}

func checkResourceIdMappingExistsBetween(t *testing.T, mappings []resourcemanager.ResourceIdMappingDefinition, schemaFieldName, segmentName string, parent bool) {
	found := false
	for _, item := range mappings {
		if strings.EqualFold(item.SchemaFieldName, schemaFieldName) && strings.EqualFold(item.SegmentName, segmentName) && item.ParsedFromParentID == parent {
			found = true
			break
		}
	}
	if !found {
		t.Fatalf("expected there to be a Resource ID Mapping from Schema Field %q to Segment Name %q but there wasn't", schemaFieldName, segmentName)
	}
}
