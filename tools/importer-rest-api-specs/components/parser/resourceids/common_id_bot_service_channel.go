// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdBotServiceChannel{}

type commonIdBotServiceChannel struct{}

func (commonIdBotServiceChannel) id() importerModels.ParsedResourceId {
	name := "BotServiceChannel"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants: map[string]resourcemanager.ConstantDetails{
			"BotServiceChannelType": {
				CaseInsensitive: false,
				Type:            resourcemanager.StringConstant,
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
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("staticSubscriptions", "subscriptions"),
			importerModels.SubscriptionIDResourceIDSegment("subscriptionId"),
			importerModels.StaticResourceIDSegment("staticResourceGroups", "resourceGroups"),
			importerModels.ResourceGroupResourceIDSegment("resourceGroupName"),
			importerModels.StaticResourceIDSegment("staticProviders", "providers"),
			importerModels.ResourceProviderResourceIDSegment("staticMicrosoftBotService", "Microsoft.BotService"),
			importerModels.StaticResourceIDSegment("staticBotServices", "botServices"),
			importerModels.UserSpecifiedResourceIDSegment("botServiceName"),
			importerModels.StaticResourceIDSegment("staticChannels", "channels"),
			importerModels.ConstantResourceIDSegment("channelType", "BotServiceChannelType"),
		},
	}
}
