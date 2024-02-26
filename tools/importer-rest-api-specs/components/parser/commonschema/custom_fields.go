// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type customFieldMatcher interface {
	// IsMatch returns whether the field and definition provided match this Custom Field Matcher
	// meaning that the types should be replaced with the CustomFieldType found in customFieldType
	IsMatch(field importerModels.FieldDetails, definition models.SDKObjectDefinition, known internal.ParseResult) bool

	// ReplacementObjectDefinition returns the replacement SDKObjectDefinition which should be used
	// in place of the parsed SDKObjectDefinition for this SDKField.
	ReplacementObjectDefinition() models.SDKObjectDefinition
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
