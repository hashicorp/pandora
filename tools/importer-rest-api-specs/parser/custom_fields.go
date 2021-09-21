package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

type customFieldMatcher interface {
	// customFieldType is the Custom Field Type which should be used when this Matcher matches
	customFieldType() models.CustomFieldType

	// isMatch returns whether the field and definition provided match this Custom Field Matcher
	// meaning that the types should be replaced with the CustomFieldType found in customFieldType
	isMatch(field models.FieldDetails, definition models.ObjectDefinition, known parseResult) bool
}

var customFieldMatchers = []customFieldMatcher{
	locationMatcher{},
	systemAssignedIdentityMatcher{},
	systemAssignedUserAssignedIdentityListMatcher{},
	systemAssignedUserAssignedIdentityMapMatcher{},
	tagsMatcher{},
	userAssignedIdentityListMatcher{},
	userAssignedIdentityMapMatcher{},
}
