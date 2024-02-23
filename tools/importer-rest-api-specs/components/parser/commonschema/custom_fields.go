// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type customFieldMatcher interface {
	// CustomFieldType is the Custom Field Type which should be used when this Matcher matches
	CustomFieldType() importerModels.CustomFieldType

	// IsMatch returns whether the field and definition provided match this Custom Field Matcher
	// meaning that the types should be replaced with the CustomFieldType found in customFieldType
	IsMatch(field importerModels.FieldDetails, definition importerModels.ObjectDefinition, known internal.ParseResult) bool
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
	zoneFieldMatcher{},
	zonesFieldMatcher{},
}
