package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ commonIdMatcher = commonIdSubscriptionMatcher{}

type commonIdSubscriptionMatcher struct{}

func (commonIdSubscriptionMatcher) isMatch(input models.ParsedResourceId) bool {
	var subscriptionId = models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
		},
	}
	return subscriptionId.Matches(input)
}

func (commonIdSubscriptionMatcher) name() string {
	return "Subscription"
}
