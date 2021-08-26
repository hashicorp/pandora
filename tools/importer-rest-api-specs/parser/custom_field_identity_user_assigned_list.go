package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ customFieldMatcher = userAssignedIdentityListMatcher{}

type userAssignedIdentityListMatcher struct{}

func (userAssignedIdentityListMatcher) customFieldType() models.CustomFieldType {
	return models.CustomFieldTypeUserAssignedIdentityList
}

func (userAssignedIdentityListMatcher) isMatch(field models.FieldDetails, definition models.ObjectDefinition, known parseResult) bool {
	return false
}
