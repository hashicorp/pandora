// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

var _ commonIdMatcher = commonIdVirtualWANP2SVPNGateway{}

type commonIdVirtualWANP2SVPNGateway struct{}

func (c commonIdVirtualWANP2SVPNGateway) ID() sdkModels.ResourceID {
	name := "VirtualWANP2SVPNGateway"
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
			sdkModels.NewStaticValueResourceIDSegment("p2sVpnGateways", "p2sVpnGateways"),
			sdkModels.NewUserSpecifiedResourceIDSegment("gatewayName", "gatewayName"),
		},
	}
}
