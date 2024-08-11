// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

// ObjectDefinition specifies additional information about a specific Object and any associated nested Objects
type ObjectDefinition struct {
	// ObjectDefinitionType defines what kind of ObjectDefinition this is, such as a Reference, String or List
	Type ObjectDefinitionType `json:"type"`

	// Nullable specifies that this type should be unset by sending `null` as the JSON value.
	Nullable bool `json:"nullable"`

	// ReferenceName is the name of the Constant or Model that this is a reference to
	ReferenceName *string `json:"referenceName"`

	// ReferenceNameIsCommonType indicates whether ReferenceName refers to a common type (true) or a type that is local to the service (false)
	ReferenceNameIsCommonType *bool `json:"referenceNameIsCommonType"`

	// NestedItem is a nested ObjectDefinition when Type is a Dictionary or List
	// NOTE: that it's possible to have deeply-nested ObjectDefinitions, e.g. a List of a List of a Dictionary[String (key, fixed as a string) : Integer (value)
	NestedItem *ObjectDefinition `json:"nestedItem,omitempty"`

	// NOTE: these 3 fields were previously located against the Field but instead should be located against the Object Definition
	// as such we'll need to update the Data API to account for this

	// MaxItems specifies the maximum number of items a CSV/Dictionary/List can have, this field is only relevant for the Terraform Schema
	MaxItems *int `json:"maxItems,omitempty"`

	// MinItems specifies the minimum number of items a CSV/Dictionary/List can have, this field is only relevant for the Terraform Schema
	MinItems *int `json:"minItems,omitempty"`

	// DateFormat specifies the format a date field should have, which allows us to generate helper methods (Get and Set) for this date format
	DateFormat *DateFormat `json:"dateFormat,omitempty"`
}

type ObjectDefinitionType string

const (
	// BooleanObjectDefinitionType signifies that this type is a simple Boolean.
	BooleanObjectDefinitionType ObjectDefinitionType = "Boolean"

	// DateTimeObjectDefinitionType signifies that this field contains a DateTime value.
	DateTimeObjectDefinitionType ObjectDefinitionType = "DateTime"

	// IntegerObjectDefinitionType signifies that this field contains an Integer.
	IntegerObjectDefinitionType ObjectDefinitionType = "Integer"

	// FloatObjectDefinitionType signifies that this field contains a Float.
	FloatObjectDefinitionType ObjectDefinitionType = "Float"

	// RawFileObjectDefinitionType signifies that this field contains a byte value e.g. []byte.
	RawFileObjectDefinitionType ObjectDefinitionType = "RawFile"

	// RawObjectObjectDefinitionType signifies that this field contains an interface value e.g. interface{}.
	RawObjectObjectDefinitionType ObjectDefinitionType = "RawObject"

	// ReferenceObjectDefinitionType signifies that this field points to a Constant or a Model.
	ReferenceObjectDefinitionType ObjectDefinitionType = "Reference"

	// StringObjectDefinitionType signifies that this field contains a String.
	StringObjectDefinitionType ObjectDefinitionType = "String"

	// CsvObjectDefinitionType signifies that this field contains a CSV of simple types e.g. String, Integer, Float.
	CsvObjectDefinitionType ObjectDefinitionType = "Csv"

	// DictionaryObjectDefinitionType signifies that this field contains a Dictionary, the
	// Key for a Dictionary is always a String - the Value Type is defined as Nested Object Definition.
	DictionaryObjectDefinitionType ObjectDefinitionType = "Dictionary"

	// ListObjectDefinitionType signifies that this field contains a List, the List's Value Type is defined as a Nested Object Definition.
	ListObjectDefinitionType ObjectDefinitionType = "List"

	EdgeZoneObjectDefinitionType                                ObjectDefinitionType = "EdgeZone"
	LocationObjectDefinitionType                                ObjectDefinitionType = "Location"
	TagsObjectDefinitionType                                    ObjectDefinitionType = "Tags"
	SystemAssignedIdentityObjectDefinitionType                  ObjectDefinitionType = "SystemAssignedIdentity"
	SystemAndUserAssignedIdentityListObjectDefinitionType       ObjectDefinitionType = "SystemAndUserAssignedIdentityList"
	SystemAndUserAssignedIdentityMapObjectDefinitionType        ObjectDefinitionType = "SystemAndUserAssignedIdentityMap"
	LegacySystemAndUserAssignedIdentityListObjectDefinitionType ObjectDefinitionType = "LegacySystemAndUserAssignedIdentityList"
	LegacySystemAndUserAssignedIdentityMapObjectDefinitionType  ObjectDefinitionType = "LegacySystemAndUserAssignedIdentityMap"
	SystemOrUserAssignedIdentityListObjectDefinitionType        ObjectDefinitionType = "SystemOrUserAssignedIdentityList"
	SystemOrUserAssignedIdentityMapObjectDefinitionType         ObjectDefinitionType = "SystemOrUserAssignedIdentityMap"
	UserAssignedIdentityListObjectDefinitionType                ObjectDefinitionType = "UserAssignedIdentityList"
	UserAssignedIdentityMapObjectDefinitionType                 ObjectDefinitionType = "UserAssignedIdentityMap"
	SystemDataObjectDefinitionType                              ObjectDefinitionType = "SystemData"
	ZoneObjectDefinitionType                                    ObjectDefinitionType = "Zone"
	ZonesObjectDefinitionType                                   ObjectDefinitionType = "Zones"
)

type DateFormat string

const (
	RFC3339DateFormat DateFormat = "RFC3339"
	// TODO: others in the future https://github.com/hashicorp/pandora/issues/8 e.g.
	// RFC3339NanoDateFormat DateFormat = "RFC3339Nano"
)
