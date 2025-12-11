// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdDedicatedHost{}

type commonIdDedicatedHost struct{}

func (c commonIdDedicatedHost) ID() sdkModels.ResourceID {
	name := "DedicatedHost"
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
			sdkModels.NewStaticValueResourceIDSegment("hostGroups", "hostGroups"),
			sdkModels.NewUserSpecifiedResourceIDSegment("hostGroupName", "hostGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("hosts", "hosts"),
			sdkModels.NewUserSpecifiedResourceIDSegment("hostName", "hostName"),
		},
	}
}
