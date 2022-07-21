package commonschema

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser/internal"
)

type customFieldMatcher interface {
	// CustomFieldType is the Custom Field Type which should be used when this Matcher matches
	CustomFieldType() models.CustomFieldType

	// IsMatch returns whether the field and definition provided match this Custom Field Matcher
	// meaning that the types should be replaced with the CustomFieldType found in customFieldType
	IsMatch(field models.FieldDetails, definition models.ObjectDefinition, known internal.ParseResult) bool
}

var CustomFieldMatchers = []customFieldMatcher{
	edgeZoneFieldMatcher{},
	locationMatcher{},
	systemAssignedIdentityMatcher{},
	legacySystemAndUserAssignedIdentityListMatcher{},
	legacySystemAndUserAssignedIdentityMapMatcher{},
	systemAndUserAssignedIdentityListMatcher{},
	systemAndUserAssignedIdentityMapMatcher{},
	systemOrUserAssignedIdentityListMatcher{},
	systemOrUserAssignedIdentityMapMatcher{},
	tagsMatcher{},
	userAssignedIdentityListMatcher{},
	userAssignedIdentityMapMatcher{},
	systemDataMatcher{},
}
