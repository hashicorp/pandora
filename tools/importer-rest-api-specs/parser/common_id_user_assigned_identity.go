package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ commonIdMatcher = commonIdUserAssignedIdentity{}

type commonIdUserAssignedIdentity struct{}

func (commonIdUserAssignedIdentity) isMatch(input models.ParsedResourceId) bool {
	var userAssignedIdentityId = models.ParsedResourceId{
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
			{
				Name:       "resourceGroups",
				Type:       models.StaticSegment,
				FixedValue: toPtr("resourceGroups"),
			},
			{
				Name: "resourceGroup",
				Type: models.ResourceGroupSegment,
			},
			{
				Name:       "providers",
				Type:       models.StaticSegment,
				FixedValue: toPtr("providers"),
			},
			{
				Name: "resourceProvider",
				Type: models.ResourceProviderSegment,
			},
			{
				Name:       "userAssignedIdentities",
				Type:       models.StaticSegment,
				FixedValue: toPtr("userAssignedIdentities"),
			},
			{
				Name: "resourceName",
				Type: models.UserSpecifiedSegment,
			},
		},
	}
	return userAssignedIdentityId.Matches(input)
}

func (commonIdUserAssignedIdentity) name() string {
	return "UserAssignedIdentity"
}
