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
			{
				Name:       "subscriptions",
				Type:       models.StaticSegment,
				FixedValue: toPtr("subscriptions"),
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
		},
	}
	return subscriptionId.Matches(input)
}

func (commonIdSubscriptionMatcher) name() string {
	return "Subscription"
}
