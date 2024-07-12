// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdExpressRouteCircuitPeering{}

type commonIdExpressRouteCircuitPeering struct{}

func (c commonIdExpressRouteCircuitPeering) ID() sdkModels.ResourceID {
	name := "ExpressRouteCircuitPeering"
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
			sdkModels.NewStaticValueResourceIDSegment("expressRouteCircuits", "expressRouteCircuits"),
			sdkModels.NewUserSpecifiedResourceIDSegment("circuitName", "circuitName"),
			sdkModels.NewStaticValueResourceIDSegment("peerings", "peerings"),
			sdkModels.NewUserSpecifiedResourceIDSegment("peeringName", "peeringName"),
		},
	}
}
