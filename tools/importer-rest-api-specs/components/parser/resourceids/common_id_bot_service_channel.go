// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdBotServiceChannel{}

type commonIdBotServiceChannel struct{}

func (commonIdBotServiceChannel) id() models.ResourceID {
	name := "BotServiceChannel"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{
			"BotServiceChannelType",
		},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			models.NewResourceProviderResourceIDSegment("staticMicrosoftBotService", "Microsoft.BotService"),
			models.NewStaticValueResourceIDSegment("staticBotServices", "botServices"),
			models.NewUserSpecifiedResourceIDSegment("botServiceName", "botServiceName"),
			models.NewStaticValueResourceIDSegment("staticChannels", "channels"),
			models.NewConstantResourceIDSegment("channelType", "BotServiceChannelType", "AcsChatChannel"),
		},
	}
}
