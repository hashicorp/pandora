// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdSubnet{}

type commonIdSubnet struct{}

func (c commonIdSubnet) id() models.ResourceID {
	name := "Subnet"
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
			models.NewStaticValueResourceIDSegment("virtualNetworks", "virtualNetworks"),
			models.NewUserSpecifiedResourceIDSegment("virtualNetworkName", "virtualNetworkName"),
			models.NewStaticValueResourceIDSegment("subnets", "subnets"),
			models.NewUserSpecifiedResourceIDSegment("subnetName", "subnetName"),
		},
	}
}
