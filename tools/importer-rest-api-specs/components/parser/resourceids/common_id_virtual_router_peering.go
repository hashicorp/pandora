// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdVirtualRouterPeering{}

type commonIdVirtualRouterPeering struct{}

func (c commonIdVirtualRouterPeering) id() models.ResourceID {
	name := "VirtualRouterPeering"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Network"),
			models.NewStaticValueResourceIDSegment("virtualRouters", "virtualRouters"),
			models.NewUserSpecifiedResourceIDSegment("virtualRouterName", "virtualRouterName"),
			models.NewStaticValueResourceIDSegment("peerings", "peerings"),
			models.NewUserSpecifiedResourceIDSegment("peeringName", "peeringName"),
		},
	}
}
