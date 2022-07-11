package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ commonIdMatcher = commonIdResourceGroupMatcher{}

type commonIdResourceGroupMatcher struct{}

func (id commonIdResourceGroupMatcher) id() models.ParsedResourceId {
	name := id.name()
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroup"),
		},
	}
}

func (id commonIdResourceGroupMatcher) isMatch(input models.ParsedResourceId) bool {
	var resourceGroupId = id.id()
	return resourceGroupId.Matches(input)
}

func (commonIdResourceGroupMatcher) name() string {
	return "ResourceGroup"
}
