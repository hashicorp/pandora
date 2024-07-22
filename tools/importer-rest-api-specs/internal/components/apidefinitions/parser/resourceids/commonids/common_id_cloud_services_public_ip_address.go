// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdCloudServicesPublicIPAddress{}

type commonIdCloudServicesPublicIPAddress struct{}

func (c commonIdCloudServicesPublicIPAddress) ID() sdkModels.ResourceID {
	name := "CloudServicesPublicIPAddress"
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
			sdkModels.NewStaticValueResourceIDSegment("cloudServices", "cloudServices"),
			sdkModels.NewUserSpecifiedResourceIDSegment("cloudServiceName", "cloudServiceName"),
			sdkModels.NewStaticValueResourceIDSegment("roleInstances", "roleInstances"),
			sdkModels.NewUserSpecifiedResourceIDSegment("roleInstanceName", "roleInstanceName"),
			sdkModels.NewStaticValueResourceIDSegment("networkInterfaces", "networkInterfaces"),
			sdkModels.NewUserSpecifiedResourceIDSegment("networkInterfaceName", "networkInterfaceName"),
			sdkModels.NewStaticValueResourceIDSegment("ipConfigurations", "ipConfigurations"),
			sdkModels.NewUserSpecifiedResourceIDSegment("ipConfigurationName", "ipConfigurationName"),
			sdkModels.NewStaticValueResourceIDSegment("publicIPAddresses", "publicIPAddresses"),
			sdkModels.NewUserSpecifiedResourceIDSegment("publicIPAddressName", "publicIPAddressName"),
		},
	}
}
