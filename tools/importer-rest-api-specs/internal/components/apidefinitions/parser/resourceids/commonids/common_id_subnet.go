// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdSubnet{}

type commonIdSubnet struct{}

func (c commonIdSubnet) ID() sdkModels.ResourceID {
	name := "Subnet"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Network"),
			sdkModels.NewStaticValueResourceIDSegment("virtualNetworks", "virtualNetworks"),
			sdkModels.NewUserSpecifiedResourceIDSegment("virtualNetworkName", "virtualNetworkName"),
			sdkModels.NewStaticValueResourceIDSegment("subnets", "subnets"),
			sdkModels.NewUserSpecifiedResourceIDSegment("subnetName", "subnetName"),
		},
	}
}
