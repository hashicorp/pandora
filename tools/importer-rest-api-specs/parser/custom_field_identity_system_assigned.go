package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ customFieldMatcher = systemAssignedIdentityMatcher{}

type systemAssignedIdentityMatcher struct{}

func (systemAssignedIdentityMatcher) customFieldType() models.CustomFieldType {
	return models.CustomFieldTypeSystemAssignedIdentity
}

func (systemAssignedIdentityMatcher) isMatch(field models.FieldDetails, definition models.ObjectDefinition, known parseResult) bool {
	return false
}
