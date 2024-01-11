package schema

import (
	"strings"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestTopLevelFieldsWithinResourceId_NoSegmentsShouldError(t *testing.T) {
	input := resourcemanager.ResourceIdDefinition{
		Segments: []resourcemanager.ResourceIdSegment{
			// intentionally none
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	inputTerraformDetails := resourcemanager.TerraformResourceDetails{
		DisplayName: "Nothing",
	}
	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, &inputTerraformDetails, hclog.New(hclog.DefaultOptions))
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
	input := resourcemanager.ResourceIdDefinition{
		Segments: []resourcemanager.ResourceIdSegment{
			{
				FixedValue: stringPointer("subscriptions"),
				Name:       "subscriptions",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				FixedValue: stringPointer("resourceGroups"),
				Name:       "resourceGroups",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	inputTerraformDetails := resourcemanager.TerraformResourceDetails{
		DisplayName: "Resource Group",
	}
	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, &inputTerraformDetails, hclog.New(hclog.DefaultOptions))
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
	input := resourcemanager.ResourceIdDefinition{
		Segments: []resourcemanager.ResourceIdSegment{
			{
				FixedValue: stringPointer("subscriptions"),
				Name:       "subscriptions",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				FixedValue: stringPointer("resourceGroups"),
				Name:       "resourceGroups",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
			{
				FixedValue: stringPointer("providers"),
				Name:       "providers",
				Type:       resourcemanager.StaticSegment,
			},
			{
				FixedValue: stringPointer("Microsoft.Compute"),
				Name:       "staticMicrosoftCompute",
				Type:       resourcemanager.ResourceProviderSegment,
			},
			{
				FixedValue: stringPointer("virtualMachines"),
				Name:       "virtualMachines",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "virtualMachineName",
				Type: resourcemanager.UserSpecifiedSegment,
			},
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	inputTerraformDetails := resourcemanager.TerraformResourceDetails{
		DisplayName: "Virtual Machine",
	}
	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, &inputTerraformDetails, hclog.New(hclog.DefaultOptions))
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
	input := resourcemanager.ResourceIdDefinition{
		Segments: []resourcemanager.ResourceIdSegment{
			{
				FixedValue: stringPointer("subscriptions"),
				Name:       "subscriptions",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				FixedValue: stringPointer("resourceGroups"),
				Name:       "resourceGroups",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
			{
				FixedValue: stringPointer("providers"),
				Name:       "providers",
				Type:       resourcemanager.StaticSegment,
			},
			{
				FixedValue: stringPointer("Microsoft.Compute"),
				Name:       "staticMicrosoftCompute",
				Type:       resourcemanager.ResourceProviderSegment,
			},
			{
				FixedValue: stringPointer("virtualMachines"),
				Name:       "virtualMachines",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "virtualMachineName",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				FixedValue: stringPointer("extensions"),
				Name:       "extensions",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "extensionsName",
				Type: resourcemanager.UserSpecifiedSegment,
			},
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	inputTerraformDetails := resourcemanager.TerraformResourceDetails{
		DisplayName: "Virtual Machine Extension",
	}
	actualFields, actualMappings, err := Builder{
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"VirtualMachineId": {
				CommonAlias: pointer.To("VirtualMachine"),
				Segments: []resourcemanager.ResourceIdSegment{
					{
						FixedValue: stringPointer("subscriptions"),
						Name:       "subscriptions",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "subscriptionId",
						Type: resourcemanager.SubscriptionIdSegment,
					},
					{
						FixedValue: stringPointer("resourceGroups"),
						Name:       "resourceGroups",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "resourceGroupName",
						Type: resourcemanager.ResourceGroupSegment,
					},
					{
						FixedValue: stringPointer("providers"),
						Name:       "providers",
						Type:       resourcemanager.StaticSegment,
					},
					{
						FixedValue: stringPointer("Microsoft.Compute"),
						Name:       "staticMicrosoftCompute",
						Type:       resourcemanager.ResourceProviderSegment,
					},
					{
						FixedValue: stringPointer("virtualMachines"),
						Name:       "virtualMachines",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "virtualMachineName",
						Type: resourcemanager.UserSpecifiedSegment,
					},
				},
			},
		},
	}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, &inputTerraformDetails, hclog.New(hclog.DefaultOptions))
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
	input := resourcemanager.ResourceIdDefinition{
		Segments: []resourcemanager.ResourceIdSegment{
			{
				FixedValue: stringPointer("subscriptions"),
				Name:       "subscriptions",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				FixedValue: stringPointer("resourceGroups"),
				Name:       "resourceGroups",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
			{
				FixedValue: stringPointer("providers"),
				Name:       "providers",
				Type:       resourcemanager.StaticSegment,
			},
			{
				FixedValue: stringPointer("Microsoft.ContainerService"),
				Name:       "staticMicrosoftContainerService",
				Type:       resourcemanager.ResourceProviderSegment,
			},
			{
				FixedValue: stringPointer("managedClusters"),
				Name:       "staticManagedClusters",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "managedClusterName",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				FixedValue: stringPointer("trustedAccessRoleBindings"),
				Name:       "trustedAccessRoleBindings",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "trustedAccessRoleBindingName",
				Type: resourcemanager.UserSpecifiedSegment,
			},
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	inputTerraformDetails := resourcemanager.TerraformResourceDetails{
		DisplayName: "Kubernetes Cluster Trusted Access Role Binding",
	}
	actualFields, actualMappings, err := Builder{
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"KubernetesClusterId": {
				CommonAlias: pointer.To("KubernetesCluster"),
				Id:          "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{managedClusterName}",
				Segments: []resourcemanager.ResourceIdSegment{
					{
						FixedValue: stringPointer("subscriptions"),
						Name:       "subscriptions",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "subscriptionId",
						Type: resourcemanager.SubscriptionIdSegment,
					},
					{
						FixedValue: stringPointer("resourceGroups"),
						Name:       "resourceGroups",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "resourceGroupName",
						Type: resourcemanager.ResourceGroupSegment,
					},
					{
						FixedValue: stringPointer("providers"),
						Name:       "providers",
						Type:       resourcemanager.StaticSegment,
					},
					{
						FixedValue: stringPointer("Microsoft.ContainerService"),
						Name:       "staticMicrosoftContainerService",
						Type:       resourcemanager.ResourceProviderSegment,
					},
					{
						FixedValue: stringPointer("managedClusters"),
						Name:       "staticManagedClusters",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "managedClusterName",
						Type: resourcemanager.UserSpecifiedSegment,
					},
				},
			},
		},
	}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, &inputTerraformDetails, hclog.New(hclog.DefaultOptions))
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

func TestTopLevelFieldsWithinResourceId_SchemaOverride(t *testing.T) {
	input := resourcemanager.ResourceIdDefinition{
		Segments: []resourcemanager.ResourceIdSegment{
			{
				FixedValue: stringPointer("subscriptions"),
				Name:       "subscriptions",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				FixedValue: stringPointer("resourceGroups"),
				Name:       "resourceGroups",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
			{
				FixedValue: stringPointer("providers"),
				Name:       "providers",
				Type:       resourcemanager.StaticSegment,
			},
			{
				FixedValue: stringPointer("Microsoft.Chaos"),
				Name:       "staticMicrosoftCompute",
				Type:       resourcemanager.ResourceProviderSegment,
			},
			{
				FixedValue: stringPointer("targets"),
				Name:       "staticTargets",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "targetName",
				Type: resourcemanager.UserSpecifiedSegment,
			},
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	inputTerraformDetails := resourcemanager.TerraformResourceDetails{
		DisplayName: "Chaos Studio Target",
		SchemaOverrides: &map[string]string{
			"name":  "target_type",
			"scope": "target_resource_id",
		},
	}
	actualFields, actualMappings, err := Builder{}.identifyTopLevelFieldsWithinResourceID(input, &inputMappings, &inputTerraformDetails, hclog.New(hclog.DefaultOptions))
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
