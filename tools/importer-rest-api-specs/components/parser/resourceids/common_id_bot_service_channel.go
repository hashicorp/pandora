package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdBotServiceChannel{}

type commonIdBotServiceChannel struct{}

func (commonIdBotServiceChannel) id() models.ParsedResourceId {
	name := "BotServiceChannel"
	return models.ParsedResourceId{
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
			models.StaticResourceIDSegment("staticSubscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("staticResourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
			models.StaticResourceIDSegment("staticProviders", "providers"),
			models.ResourceProviderResourceIDSegment("staticMicrosoftBotService", "Microsoft.BotService"),
			models.StaticResourceIDSegment("staticBotServices", "botServices"),
			models.UserSpecifiedResourceIDSegment("botServiceName"),
			models.StaticResourceIDSegment("staticChannels", "channels"),
			models.ConstantResourceIDSegment("channelType", "BotServiceChannelType"),
		},
	}
}
