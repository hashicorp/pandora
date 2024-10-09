// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

var _ commonIdMatcher = commonIdVirtualMachineScaleSetNetworkInterface{}

type commonIdVirtualMachineScaleSetNetworkInterface struct{}

func (c commonIdVirtualMachineScaleSetNetworkInterface) ID() sdkModels.ResourceID {
	name := "VirtualMachineScaleSetNetworkInterface"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Compute"),
			sdkModels.NewStaticValueResourceIDSegment("virtualMachineScaleSets", "virtualMachineScaleSets"),
			sdkModels.NewUserSpecifiedResourceIDSegment("virtualMachineScaleSetName", "virtualMachineScaleSetName"),
			sdkModels.NewStaticValueResourceIDSegment("virtualMachines", "virtualMachines"),
			sdkModels.NewUserSpecifiedResourceIDSegment("virtualMachineIndex", "virtualMachineIndex"),
			sdkModels.NewStaticValueResourceIDSegment("networkInterfaces", "networkInterfaces"),
			sdkModels.NewUserSpecifiedResourceIDSegment("networkInterfaceName", "networkInterfaceName"),
		},
	}
}
