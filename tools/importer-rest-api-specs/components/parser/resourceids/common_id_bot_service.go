// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdBotService{}

type commonIdBotService struct{}

func (commonIdBotService) id() sdkModels.ResourceID {
	name := "BotService"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftBotService", "Microsoft.BotService"),
			sdkModels.NewStaticValueResourceIDSegment("staticBotServices", "botServices"),
			sdkModels.NewUserSpecifiedResourceIDSegment("botServiceName", "botServiceName"),
		},
	}
}
