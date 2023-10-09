package dataapigeneratorjson

type ObjectDefinitionType string

const (
	BooleanObjectDefinitionType    ObjectDefinitionType = "Boolean"
	CsvObjectDefinitionType        ObjectDefinitionType = "Csv"
	DateTimeObjectDefinitionType   ObjectDefinitionType = "DateTime"
	DictionaryObjectDefinitionType ObjectDefinitionType = "Dictionary"
	IntegerObjectDefinitionType    ObjectDefinitionType = "Integer"
	FloatObjectDefinitionType      ObjectDefinitionType = "Float"
	ListObjectDefinitionType       ObjectDefinitionType = "List"
	RawFileObjectDefinitionType    ObjectDefinitionType = "RawFile"
	RawObjectObjectDefinitionType  ObjectDefinitionType = "RawObject"
	ReferenceObjectDefinitionType  ObjectDefinitionType = "Reference"
	StringObjectDefinitionType     ObjectDefinitionType = "String"

	// Custom Types
	EdgeZoneObjectDefinitionType                                ObjectDefinitionType = "EdgeZone"
	LocationObjectDefinitionType                                ObjectDefinitionType = "Location"
	SystemAssignedIdentityObjectDefinitionType                  ObjectDefinitionType = "SystemAssignedIdentity"
	SystemAndUserAssignedIdentityListObjectDefinitionType       ObjectDefinitionType = "SystemAndUserAssignedIdentityList"
	SystemAndUserAssignedIdentityMapObjectDefinitionType        ObjectDefinitionType = "SystemAndUserAssignedIdentityMap"
	LegacySystemAndUserAssignedIdentityListObjectDefinitionType ObjectDefinitionType = "LegacySystemAndUserAssignedIdentityList"
	LegacySystemAndUserAssignedIdentityMapObjectDefinitionType  ObjectDefinitionType = "LegacySystemAndUserAssignedIdentityMap"
	SystemOrUserAssignedIdentityListObjectDefinitionType        ObjectDefinitionType = "SystemOrUserAssignedIdentityList"
	SystemOrUserAssignedIdentityMapObjectDefinitionType         ObjectDefinitionType = "SystemOrUserAssignedIdentityMap"
	UserAssignedIdentityListObjectDefinitionType                ObjectDefinitionType = "UserAssignedIdentityList"
	UserAssignedIdentityMapObjectDefinitionType                 ObjectDefinitionType = "UserAssignedIdentityMap"
	TagsObjectDefinitionType                                    ObjectDefinitionType = "Tags"
	SystemData                                                  ObjectDefinitionType = "SystemData"
	ZoneObjectDefinitionType                                    ObjectDefinitionType = "Zone"
	ZonesObjectDefinitionType                                   ObjectDefinitionType = "Zones"
)
