// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

var _ commonIdMatcher = commonIdVirtualHubBGPConnection{}

type commonIdVirtualHubBGPConnection struct{}

func (c commonIdVirtualHubBGPConnection) ID() sdkModels.ResourceID {
	name := "VirtualHubBGPConnection"
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
			sdkModels.NewStaticValueResourceIDSegment("virtualHubs", "virtualHubs"),
			sdkModels.NewUserSpecifiedResourceIDSegment("hubName", "hubName"),
			sdkModels.NewStaticValueResourceIDSegment("bgpConnections", "bgpConnections"),
			sdkModels.NewUserSpecifiedResourceIDSegment("connectionName", "connectionName"),
		},
	}
}
