// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdPublicIPAddress{}

type commonIdPublicIPAddress struct{}

func (c commonIdPublicIPAddress) ID() sdkModels.ResourceID {
	name := "PublicIPAddress"
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
			sdkModels.NewStaticValueResourceIDSegment("publicIPAddresses", "publicIPAddresses"),
			sdkModels.NewUserSpecifiedResourceIDSegment("publicIPAddressesName", "publicIPAddressesName"),
		},
	}
}
