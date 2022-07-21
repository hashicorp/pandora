package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ commonIdMatcher = commonIdSubscriptionMatcher{}

type commonIdSubscriptionMatcher struct{}

func (commonIdSubscriptionMatcher) id() models.ParsedResourceId {
	name := "Subscription"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
		},
	}
}
