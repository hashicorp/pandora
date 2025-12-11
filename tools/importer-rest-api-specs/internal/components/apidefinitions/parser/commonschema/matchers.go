// Copyright IBM Corp. 2021, 2025
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
