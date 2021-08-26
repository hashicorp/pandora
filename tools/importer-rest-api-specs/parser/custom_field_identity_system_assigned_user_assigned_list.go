package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ customFieldMatcher = systemAssignedUserAssignedIdentityListMatcher{}

type systemAssignedUserAssignedIdentityListMatcher struct{}

func (systemAssignedUserAssignedIdentityListMatcher) customFieldType() models.CustomFieldType {
	return models.CustomFieldTypeSystemAssignedUserAssignedIdentityList
}

func (systemAssignedUserAssignedIdentityListMatcher) isMatch(field models.FieldDetails, definition models.ObjectDefinition, known parseResult) bool {
	return false
}
