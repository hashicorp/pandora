package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ commonIdMatcher = commonIdUserAssignedIdentity{}

type commonIdUserAssignedIdentity struct{}

func (commonIdUserAssignedIdentity) isMatch(input models.ParsedResourceId) bool {
	var userAssignedIdentityId = models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroup"),
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.ManagedIdentity"),
			models.StaticResourceIDSegment("userAssignedIdentities", "userAssignedIdentities"),
			models.UserSpecifiedResourceIDSegment("resourceName"),
		},
	}
	return userAssignedIdentityId.Matches(input)
}

func (commonIdUserAssignedIdentity) name() string {
	return "UserAssignedIdentity"
}
