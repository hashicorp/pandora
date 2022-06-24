package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ commonIdMatcher = commonIdResourceGroupMatcher{}

type commonIdResourceGroupMatcher struct{}

func (commonIdResourceGroupMatcher) isMatch(input models.ParsedResourceId) bool {
	var resourceGroupId = models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name:       "subscriptions",
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
			{
				Name:       "resourceGroups",
				Type:       models.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
			},
			{
				Name: "resourceGroup",
				Type: models.ResourceGroupSegment,
			},
		},
	}
	return resourceGroupId.Matches(input)
}

func (commonIdResourceGroupMatcher) name() string {
	return "ResourceGroup"
}
