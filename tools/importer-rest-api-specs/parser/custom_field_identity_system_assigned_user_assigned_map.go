package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ customFieldMatcher = systemAssignedUserAssignedIdentityMapMatcher{}

type systemAssignedUserAssignedIdentityMapMatcher struct{}

func (systemAssignedUserAssignedIdentityMapMatcher) customFieldType() models.CustomFieldType {
	return models.CustomFieldTypeSystemAssignedUserAssignedIdentityMap
}

func (systemAssignedUserAssignedIdentityMapMatcher) isMatch(field models.FieldDetails, definition models.ObjectDefinition, known parseResult) bool {
	return false
}
