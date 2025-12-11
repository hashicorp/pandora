// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// SDKObjectDefinitionType defines the Type of Object Definition used in an SDKField.
// Possible values include Simple types (e.g. boolean/integer/float/string), References (to a
// Constant or Model), a Common Schema type (e.g. SystemAssignedIdentity) and a List or
// Dictionary of the previous values.
// Note that Lists (and Dictionaries) can be repeatedly nested (e.g. `List<List<List<string>>>`).
type SDKObjectDefinitionType string

// Simple Types
const (
	// BooleanSDKObjectDefinitionType specifies that this represents a Boolean value.
	// This will be output in the Go SDK as a `bool`.
	BooleanSDKObjectDefinitionType SDKObjectDefinitionType = "Boolean"

	// DateTimeSDKObjectDefinitionType specifies that this represents a DateTime value.
	// This will be output in the Go SDK as a `string` with Get and Set functions for
	// converting to/from a `time.Time` value.
	DateTimeSDKObjectDefinitionType SDKObjectDefinitionType = "DateTime"

	// FloatSDKObjectDefinitionType specifies that this represents a Float value.
	// This will be output in the Go SDK as a `float64`.
	FloatSDKObjectDefinitionType SDKObjectDefinitionType = "Float"

	// IntegerSDKObjectDefinitionType specifies that this represents an Integer value.
	// This will be output in the Go SDK as an `int64`.
	IntegerSDKObjectDefinitionType SDKObjectDefinitionType = "Integer"

	// StringSDKObjectDefinitionType specifies that this represents a String value.
	// This will be output in the Go SDK as a `string`.
	StringSDKObjectDefinitionType SDKObjectDefinitionType = "String"
)

// Complex Objects
const (
	// CSVSDKObjectDefinitionType specifies that this represents a CSV value.
	// This will be output in the Go SDK as a `string`.
	CSVSDKObjectDefinitionType SDKObjectDefinitionType = "Csv"

	// DictionarySDKObjectDefinitionType specifies that this represents a Dictionary value.
	// This will be output in the Go SDK as a `map[string]{TypeOfTheNestedObjectDefinition}`
	// Note that at this time we only support string keys.
	DictionarySDKObjectDefinitionType SDKObjectDefinitionType = "Dictionary"

	// ListSDKObjectDefinitionType specifies that this represents a List of values.
	// This will be output in the Go SDK as a `[]{TypeOfTheNestedObjectDefinition}`.
	ListSDKObjectDefinitionType SDKObjectDefinitionType = "List"

	// RawFileSDKObjectDefinitionType specifies that this represents a file-based payload.
	// This is _intentionally_ not named bytes to enable a `bytes` type to be added if required
	// in the future (for Data Plane operations).
	// This will be output in the Go SDK as a `[]byte`.
	RawFileSDKObjectDefinitionType SDKObjectDefinitionType = "RawFile"

	// RawObjectSDKObjectDefinitionType specifies that this represents any payload.
	// This will be output in the Go SDK as a `interface{}`.
	RawObjectSDKObjectDefinitionType SDKObjectDefinitionType = "RawObject"

	// ReferenceSDKObjectDefinitionType specifies that this represents a Constant or Model.
	// This will be output in the Go SDK as `{ReferenceName}`.
	ReferenceSDKObjectDefinitionType SDKObjectDefinitionType = "Reference"
)

// Common Schema Types
const (
	// EdgeZoneSDKObjectDefinitionType specifies that this represents an Edge Zone.
	// This will be output in the Go SDK as `edgezones.Model`.
	EdgeZoneSDKObjectDefinitionType SDKObjectDefinitionType = "EdgeZone"

	// LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType specifies that this represents one of the
	// Legacy Identity Types, where `SystemAssigned,UserAssigned` is the required value rather than the more
	// modern `SystemAssigned, UserAssigned` value.
	// This will be output in the Go SDK as `identity.LegacySystemAndUserAssignedList`.
	LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType SDKObjectDefinitionType = "LegacySystemAndUserAssignedIdentityList"

	// LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType specifies that this represents one of the
	// Legacy Identity Types, where `SystemAssigned,UserAssigned` is the required value rather than the more
	// modern `SystemAssigned, UserAssigned` value.
	// This will be output in the Go SDK as `identity.LegacySystemAndUserAssignedMap`.
	LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType SDKObjectDefinitionType = "LegacySystemAndUserAssignedIdentityMap"

	// LocationSDKObjectDefinitionType specifies that this represents an Azure Location/Region.
	// This will be output in the Go SDK as a `string`. // TODO: we should add a typealias for this
	LocationSDKObjectDefinitionType SDKObjectDefinitionType = "Location"

	// SystemAssignedIdentitySDKObjectDefinitionType specifies that this represents an Identity type which
	// only supports SystemAssigned identities.
	// This will be output in the Go SDK as `identity.SystemAssigned`.
	SystemAssignedIdentitySDKObjectDefinitionType SDKObjectDefinitionType = "SystemAssignedIdentity"

	// SystemAndUserAssignedIdentityListSDKObjectDefinitionType specifies that this represents an Identity type which
	// supports both SystemAssigned, User Assigned and both System and User Assigned identities with a List used for
	// the UserAssignedIdentityIDs.
	// This will be output in the Go SDK as `identity.SystemAssignedUserAssignedList`.
	SystemAndUserAssignedIdentityListSDKObjectDefinitionType SDKObjectDefinitionType = "SystemAndUserAssignedIdentityList"

	// SystemAndUserAssignedIdentityMapSDKObjectDefinitionType specifies that this represents an Identity type which
	// supports both SystemAssigned, User Assigned and both System and User Assigned identities with UserAssignedIdentityIDs
	// using a map[UserAssignedIdentityIDs]objects.
	// This will be output in the Go SDK as `identity.SystemAssignedUserAssignedMap`.
	SystemAndUserAssignedIdentityMapSDKObjectDefinitionType SDKObjectDefinitionType = "SystemAndUserAssignedIdentityMap"

	// SystemDataSDKObjectDefinitionType specifies that this represents the SystemData type - containing readonly
	// metadata about the resource.
	// This will be output in the Go SDK as `systemdata.SystemData`.
	SystemDataSDKObjectDefinitionType SDKObjectDefinitionType = "SystemData"

	// SystemOrUserAssignedIdentityListSDKObjectDefinitionType specifies that this represents an Identity type which
	// supports both SystemAssigned and User Assigned - but not both concurrently. The User Assigned Identities are
	// defined using a List of UserAssignedIdentityIDs.
	// This will be output in the Go SDK as `identity.SystemOrUserAssignedList`.
	SystemOrUserAssignedIdentityListSDKObjectDefinitionType SDKObjectDefinitionType = "SystemOrUserAssignedIdentityList"

	// SystemOrUserAssignedIdentityMapSDKObjectDefinitionType specifies that this represents an Identity type which
	// supports both SystemAssigned and User Assigned - but not both concurrently. The User Assigned Identities are
	// defined using a map[UserAssignedIdentityIDs]objects.
	// This will be output in the Go SDK as `identity.SystemOrUserAssignedMap`.
	SystemOrUserAssignedIdentityMapSDKObjectDefinitionType SDKObjectDefinitionType = "SystemOrUserAssignedIdentityMap"

	// TagsSDKObjectDefinitionType specifies that this represents a Dictionary of Tags.
	// This will be output in the Go SDK as `map[string]string`. // TODO: we should add a typealias for this
	TagsSDKObjectDefinitionType SDKObjectDefinitionType = "Tags"

	// UserAssignedIdentityListSDKObjectDefinitionType specifies that this represents an Identity type which
	// only supports UserAssigned identities - with a List used for the UserAssignedIdentityIDs.
	// This will be output in the Go SDK as `identity.UserAssignedList`.
	UserAssignedIdentityListSDKObjectDefinitionType SDKObjectDefinitionType = "UserAssignedIdentityList"

	// UserAssignedIdentityMapSDKObjectDefinitionType specifies that this represents an Identity type which
	// only supports UserAssigned identities - with UserAssignedIdentityIDs using a map[UserAssignedIdentityIDs]objects.
	// This will be output in the Go SDK as `identity.UserAssignedMap`.
	UserAssignedIdentityMapSDKObjectDefinitionType SDKObjectDefinitionType = "UserAssignedIdentityMap"

	// ZoneSDKObjectDefinitionType specifies that this represents a single Azure Availability Zone.
	// This will be output in the Go SDK as a `string`. // TODO: we should add a typealias for this
	ZoneSDKObjectDefinitionType SDKObjectDefinitionType = "Zone"

	// ZonesSDKObjectDefinitionType specifies that this represents a single Azure Availability Zone.
	// This will be output in the Go SDK as `zones.Schema`.
	ZonesSDKObjectDefinitionType SDKObjectDefinitionType = "Zones"
)
