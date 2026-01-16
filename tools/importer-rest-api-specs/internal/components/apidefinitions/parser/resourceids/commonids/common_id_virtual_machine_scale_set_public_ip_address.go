// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonids

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

var _ commonIdMatcher = commonIdVirtualMachineScaleSetPublicIPAddress{}

type commonIdVirtualMachineScaleSetPublicIPAddress struct{}

func (c commonIdVirtualMachineScaleSetPublicIPAddress) ID() sdkModels.ResourceID {
	name := "VirtualMachineScaleSetPublicIPAddress"
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
			sdkModels.NewStaticValueResourceIDSegment("ipConfigurations", "ipConfigurations"),
			sdkModels.NewUserSpecifiedResourceIDSegment("ipConfigurationName", "ipConfigurationName"),
			sdkModels.NewStaticValueResourceIDSegment("publicIPAddresses", "publicIPAddresses"),
			sdkModels.NewUserSpecifiedResourceIDSegment("publicIpAddressName", "publicIpAddressName"),
		},
	}

}
