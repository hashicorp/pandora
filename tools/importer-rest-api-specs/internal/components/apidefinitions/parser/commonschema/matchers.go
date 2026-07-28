// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package commonschema

var Matchers = []Matcher{
	edgeZoneFieldMatcher{},
	locationMatcher{},
	legacySystemAndUserAssignedIdentityListMatcher{},
	legacySystemAndUserAssignedIdentityMapMatcher{},
	systemAndUserAssignedIdentityListMatcher{},
	systemAndUserAssignedIdentityMapMatcher{},
	systemAssignedIdentityMatcher{},
	systemDataMatcher{},
	systemOrUserAssignedIdentityListMatcher{},
	systemOrUserAssignedIdentityMapMatcher{},
	tagsMatcher{},
	userAssignedIdentityListMatcher{},
	userAssignedIdentityMapMatcher{},
	zoneFieldMatcher{},
	zonesFieldMatcher{},
}
