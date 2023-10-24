package models

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

// ObjectDefinition specifies additional information about a specific Object and any associated nested Objects
type ObjectDefinition struct {
	// ObjectDefinitionType defines what kind of ObjectDefinition this is, such as a Reference, String or List
	Type ObjectDefinitionType `json:"type"`

	// NOTE: we could split this into ConstantName and ModelName in time, but not today.
	// ReferenceName is the name of the Constant or Model that this is a reference to
	ReferenceName *string `json:"referenceName"`

	// NestedItem is a nested ObjectDefinition when Type is a Dictionary or List
	NestedItem *ObjectDefinition `json:"nestedItem,omitempty"`

	// NOTE: these 3 fields were previously located against the Field but instead should be located against the Object Definition
	// as such we'll need to update the Data API to account for this

	// MaxItems specifies the maximum number of items a CSV/Dictionary/List can have, this field is only relevant for the Terraform Schema
	MaxItems *int `json:"maxItems,omitempty"`

	// MinItems specifies the minimum number of items a CSV/Dictionary/List can have, this field is only relevant for the Terraform Schema
	MinItems *int `json:"minItems,omitempty"`

	// DateFormat specifies the format a date field should have, this field is only relevant for the Terraform Schema
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

func ObjectDefinitionFromSchemaFieldFromImporterRestApiSpecs(input *models.ObjectDefinition) *ObjectDefinition {
	if input == nil {
		return nil
	}

	objectDefinition := ObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          ObjectDefinitionType(input.Type),
		NestedItem:    ObjectDefinitionFromSchemaFieldFromImporterRestApiSpecs(input.NestedItem),
	}

	return &objectDefinition
}
