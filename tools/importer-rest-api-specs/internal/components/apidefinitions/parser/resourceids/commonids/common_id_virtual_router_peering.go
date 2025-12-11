// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonids

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

var _ commonIdMatcher = commonIdVirtualRouterPeering{}

type commonIdVirtualRouterPeering struct{}

func (c commonIdVirtualRouterPeering) ID() sdkModels.ResourceID {
	name := "VirtualRouterPeering"
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
			sdkModels.NewStaticValueResourceIDSegment("virtualRouters", "virtualRouters"),
			sdkModels.NewUserSpecifiedResourceIDSegment("virtualRouterName", "virtualRouterName"),
			sdkModels.NewStaticValueResourceIDSegment("peerings", "peerings"),
			sdkModels.NewUserSpecifiedResourceIDSegment("peeringName", "peeringName"),
		},
	}
}
