// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

// NOTE: this file exists temporarily to make the transition easier
// this defines types used /all over the place/ to enable the unit tests
// to be run whilst working through the refactor.
//
// Each item within this file will be marked as Deprecated - which should
// make it possible to detect usages of the old types fairly easily.

/*
Removed:
  * ApiOperationDetails (should be unused)
  * ResourceSummary (not widely used)
  * ServiceVersionDetails (not widely used)
  * FieldValidationDetails (no longer required)
  * FieldValidationType (no longer required)

Notes:
  * SDKConstant - no longer supports CaseInsensitive
  * SDKField - IsTypeHint is now ContainsDiscriminatedValue
  * SDKField - TypeHintIn is now FieldNameContainingDiscriminatedValue
  * SDKField - TypeHintValue is now DiscriminatedValue
*/

type ConstantDetails = SDKConstant
type ConstantType = SDKConstantType

type ApiOperation = SDKOperation
type ApiOperationOption = SDKOperationOption

// =============================
// ===== Object Definition =====
// =============================

type ApiObjectDefinition = SDKObjectDefinition

type ApiObjectDefinitionType = SDKObjectDefinitionType

const (
	BooleanApiObjectDefinitionType  = BooleanSDKObjectDefinitionType
	DateTimeApiObjectDefinitionType = DateTimeSDKObjectDefinitionType
	IntegerApiObjectDefinitionType  = IntegerSDKObjectDefinitionType
	FloatApiObjectDefinitionType    = FloatSDKObjectDefinitionType
	StringApiObjectDefinitionType   = StringSDKObjectDefinitionType
)

// Complex Types
const (
	CsvApiObjectDefinitionType        = CSVSDKObjectDefinitionType
	DictionaryApiObjectDefinitionType = DictionarySDKObjectDefinitionType
	ListApiObjectDefinitionType       = ListSDKObjectDefinitionType
	RawFileApiObjectDefinitionType    = RawFileSDKObjectDefinitionType
	RawObjectApiObjectDefinitionType  = RawObjectSDKObjectDefinitionType
	ReferenceApiObjectDefinitionType  = ReferenceSDKObjectDefinitionType
)

// Common Schema Types
const (
	EdgeZoneApiObjectDefinitionType = EdgeZoneSDKObjectDefinitionType

	LocationApiObjectDefinitionType                                = LocationSDKObjectDefinitionType
	SystemAssignedIdentityApiObjectDefinitionType                  = SystemAssignedIdentitySDKObjectDefinitionType
	SystemAndUserAssignedIdentityListApiObjectDefinitionType       = SystemAndUserAssignedIdentityListSDKObjectDefinitionType
	SystemAndUserAssignedIdentityMapApiObjectDefinitionType        = SystemAndUserAssignedIdentityMapSDKObjectDefinitionType
	LegacySystemAndUserAssignedIdentityListApiObjectDefinitionType = LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType
	LegacySystemAndUserAssignedIdentityMapApiObjectDefinitionType  = LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType
	SystemOrUserAssignedIdentityListApiObjectDefinitionType        = SystemOrUserAssignedIdentityListSDKObjectDefinitionType
	SystemOrUserAssignedIdentityMapApiObjectDefinitionType         = SystemOrUserAssignedIdentityMapSDKObjectDefinitionType
	UserAssignedIdentityListApiObjectDefinitionType                = UserAssignedIdentityListSDKObjectDefinitionType
	UserAssignedIdentityMapApiObjectDefinitionType                 = UserAssignedIdentityMapSDKObjectDefinitionType
	TagsApiObjectDefinitionType                                    = TagsSDKObjectDefinitionType
	SystemData                                                     = SystemDataSDKObjectDefinitionType
	ZoneApiObjectDefinitionType                                    = ZoneSDKObjectDefinitionType
	ZonesApiObjectDefinitionType                                   = ZonesSDKObjectDefinitionType
)

// ==============================
// ======== Resource IDs ========
// ==============================

type ResourceIdDefinition = ResourceID

const (
	ConstantSegment         = ConstantResourceIDSegmentType
	ResourceGroupSegment    = ResourceGroupResourceIDSegmentType
	ResourceProviderSegment = ResourceProviderResourceIDSegmentType
	ScopeSegment            = ScopeResourceIDSegmentType
	StaticSegment           = StaticResourceIDSegmentType
	SubscriptionIdSegment   = SubscriptionIDResourceIDSegmentType
	UserSpecifiedSegment    = UserSpecifiedResourceIDSegmentType
)

// =============================
// === SDK Fields and Models ===
// =============================

type ApiSchemaDetails = APIResource

type ModelDetails = SDKModel

type FieldDetails = SDKField

type DateFormat = SDKDateFormat

const (
	RFC3339     = RFC3339SDKDateFormat
	RFC3339Nano = RFC3339NanoSDKDateFormat
)
