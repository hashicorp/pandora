package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

type commonIdMatcher interface {
	// isMatch determines whether the Resource ID provided matches this Common Resource ID
	isMatch(input models.ParsedResourceId) bool

	// name returns the name of this Common ID type
	name() string

	// id returns the Resource ID for this Common ID
	id() models.ParsedResourceId
}

var commonIdTypes = []commonIdMatcher{
	commonIdManagementGroupMatcher{},
	commonIdResourceGroupMatcher{},
	commonIdSubscriptionMatcher{},
	commonIdScopeMatcher{},
	commonIdUserAssignedIdentity{},
}

func switchOutCommonResourceIDsAsNeeded(input []models.ParsedResourceId) []models.ParsedResourceId {
	output := make([]models.ParsedResourceId, 0)

	for _, value := range input {
		for _, commonId := range commonIdTypes {
			if commonId.isMatch(value) {
				value = commonId.id()
				break
			}
		}

		output = append(output, value)
	}

	return output
}
