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
		Constants: map[string]models.SDKConstant{
			"BotServiceChannelType": {
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"AcsChatChannel":          "AcsChatChannel",
					"AlexaChannel":            "AlexaChannel",
					"DirectLineChannel":       "DirectLineChannel",
					"DirectLineSpeechChannel": "DirectLineSpeechChannel",
					"EmailChannel":            "EmailChannel",
					"KikChannel":              "KikChannel",
					"FacebookChannel":         "FacebookChannel",
					"LineChannel":             "LineChannel",
					"M365Extensions":          "M365Extensions",
					"MsTeamsChannel":          "MsTeamsChannel",
					"Omnichannel":             "Omnichannel",
					"OutlookChannel":          "OutlookChannel",
					"SearchAssistant":         "SearchAssistant",
					"SkypeChannel":            "SkypeChannel",
					"SlackChannel":            "SlackChannel",
					"SmsChannel":              "SmsChannel",
					"TelegramChannel":         "TelegramChannel",
					"TelephonyChannel":        "TelephonyChannel",
					"WebChatChannel":          "WebChatChannel",
				},
			},
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
