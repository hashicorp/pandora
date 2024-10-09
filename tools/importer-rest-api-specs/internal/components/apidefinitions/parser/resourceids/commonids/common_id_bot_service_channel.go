// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdBotServiceChannel{}

type commonIdBotServiceChannel struct{}

func (commonIdBotServiceChannel) ID() sdkModels.ResourceID {
	name := "BotServiceChannel"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{
			"BotServiceChannelType",
		},
		Constants: map[string]sdkModels.SDKConstant{
			"BotServiceChannelType": {
				Type: sdkModels.StringSDKConstantType,
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
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("staticSubscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("staticResourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("staticProviders", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("staticMicrosoftBotService", "Microsoft.BotService"),
			sdkModels.NewStaticValueResourceIDSegment("staticBotServices", "botServices"),
			sdkModels.NewUserSpecifiedResourceIDSegment("botServiceName", "botServiceName"),
			sdkModels.NewStaticValueResourceIDSegment("staticChannels", "channels"),
			sdkModels.NewConstantResourceIDSegment("channelType", "BotServiceChannelType", "AcsChatChannel"),
		},
	}
}
