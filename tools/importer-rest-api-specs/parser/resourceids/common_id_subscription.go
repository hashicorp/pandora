package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ commonIdMatcher = commonIdSubscriptionMatcher{}

type commonIdSubscriptionMatcher struct{}

func (id commonIdSubscriptionMatcher) id() models.ParsedResourceId {
	name := id.name()
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
		},
	}
}

func (id commonIdSubscriptionMatcher) isMatch(input models.ParsedResourceId) bool {
	var subscriptionId = id.id()
	return subscriptionId.Matches(input)
}

func (commonIdSubscriptionMatcher) name() string {
	return "Subscription"
}
