// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdAvailabilitySet{}

type commonIdAvailabilitySet struct{}

func (c commonIdAvailabilitySet) ID() sdkModels.ResourceID {
	name := "AvailabilitySet"
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
			sdkModels.NewStaticValueResourceIDSegment("availabilitySets", "availabilitySets"),
			sdkModels.NewUserSpecifiedResourceIDSegment("availabilitySetName", "availabilitySetName"),
		},
	}
}
