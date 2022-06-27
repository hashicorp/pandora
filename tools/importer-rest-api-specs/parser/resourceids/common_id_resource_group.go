package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ commonIdMatcher = commonIdResourceGroupMatcher{}

type commonIdResourceGroupMatcher struct{}

func (commonIdResourceGroupMatcher) isMatch(input models.ParsedResourceId) bool {
	var resourceGroupId = models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroup"),
		},
	}
	return resourceGroupId.Matches(input)
}

func (commonIdResourceGroupMatcher) name() string {
	return "ResourceGroup"
}
