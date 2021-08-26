package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ customFieldMatcher = userAssignedIdentityMapMatcher{}

type userAssignedIdentityMapMatcher struct{}

func (userAssignedIdentityMapMatcher) customFieldType() models.CustomFieldType {
	return models.CustomFieldTypeUserAssignedIdentityMap
}

func (userAssignedIdentityMapMatcher) isMatch(field models.FieldDetails, definition models.ObjectDefinition, known parseResult) bool {
	return false
}
