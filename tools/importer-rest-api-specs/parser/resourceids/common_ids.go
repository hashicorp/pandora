package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

type commonIdMatcher interface {
	// isMatch determines whether the Resource ID provided matches this Common Resource ID
	isMatch(input models.ParsedResourceId) bool

	// name returns the name of this Common ID type
	name() string
}

var commonIdTypes = []commonIdMatcher{
	commonIdManagementGroupMatcher{},
	commonIdResourceGroupMatcher{},
	commonIdSubscriptionMatcher{},
	commonIdScopeMatcher{},
	commonIdUserAssignedIdentity{},
}
