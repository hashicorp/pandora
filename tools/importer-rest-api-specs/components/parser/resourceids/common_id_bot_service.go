package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdBotService{}

type commonIdBotService struct{}

func (commonIdBotService) id() models.ParsedResourceId {
	name := "BotService"
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
		},
	}
}
