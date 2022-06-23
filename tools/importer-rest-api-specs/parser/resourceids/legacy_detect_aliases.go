package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

func checkForAliasForUri(resourceId *models.ParsedResourceId) *string {
	for name, alias := range aliasedIds {
		if resourceId.Matches(alias) {
			return &name
		}
	}

	return nil
}

var aliasedIds = map[string]models.ParsedResourceId{
	"Subscription": {
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type:       models.StaticSegment,
				Name:       "subscriptions",
				FixedValue: toPtr("subscriptions"),
			},
			{
				Type: models.SubscriptionIdSegment,
				Name: "subscriptionId",
			},
		},
	},
	"ResourceGroup": {
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Type:       models.StaticSegment,
				Name:       "subscriptions",
				FixedValue: toPtr("subscriptions"),
			},
			{
				Type: models.SubscriptionIdSegment,
				Name: "subscriptionId",
			},
			{
				Type:       models.StaticSegment,
				Name:       "resourceGroups",
				FixedValue: toPtr("resourceGroups"),
			},
			{
				Type: models.ResourceGroupSegment,
				Name: "resourceGroupName",
			},
		},
	},
}
