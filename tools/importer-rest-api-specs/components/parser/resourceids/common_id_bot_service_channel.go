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
		Constants:   map[string]resourcemanager.ConstantDetails{},
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
