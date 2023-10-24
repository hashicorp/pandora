package models

// NOTE: these types are intentionally undocumented atm, these'll be added in a follow-up PR

type ObjectDefinition struct {
	Type ObjectDefinitionType `json:"type"`

	ReferenceName *string `json:"referenceName"` // NOTE: we could split this into ConstantName and ModelName in time, but not today.

	NestedItem *ObjectDefinition `json:"nestedItem,omitempty"`

	// NOTE: these 3 fields were previously located against the Field but instead should be located against the Object Definition
	// as such we'll need to update the Data API to account for this
	MaxItems   *int        `json:"maxItems,omitempty"`
	MinItems   *int        `json:"minItems,omitempty"`
	DateFormat *DateFormat `json:"dateFormat,omitempty"`
}

type ObjectDefinitionType string

const (
	// BooleanObjectDefinitionType is used to signify that this type is a simple Boolean.
	BooleanObjectDefinitionType   ObjectDefinitionType = "Boolean"
	DateTimeObjectDefinitionType  ObjectDefinitionType = "DateTime"
	IntegerObjectDefinitionType   ObjectDefinitionType = "Integer"
	FloatObjectDefinitionType     ObjectDefinitionType = "Float"
	RawFileObjectDefinitionType   ObjectDefinitionType = "RawFile"
	RawObjectObjectDefinitionType ObjectDefinitionType = "RawObject"
	ReferenceObjectDefinitionType ObjectDefinitionType = "Reference"
	StringObjectDefinitionType    ObjectDefinitionType = "String"

	CsvObjectDefinitionType        ObjectDefinitionType = "Csv"
	DictionaryObjectDefinitionType ObjectDefinitionType = "Dictionary"
	ListObjectDefinitionType       ObjectDefinitionType = "List"

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
