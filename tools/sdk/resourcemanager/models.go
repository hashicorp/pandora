package resourcemanager

import (
	"fmt"
)

type ApiObjectDefinition struct {
	NestedItem    *ApiObjectDefinition    `json:"nestedItem,omitempty"`
	ReferenceName *string                 `json:"referenceName,omitempty"`
	Type          ApiObjectDefinitionType `json:"type"`
}

func (d ApiObjectDefinition) String() string {
	if d.Type == DictionaryApiObjectDefinitionType {
		return fmt.Sprintf("Dictionary[string, %s]", *d.NestedItem)
	}

	if d.Type == ListApiObjectDefinitionType {
		return fmt.Sprintf("List[%s]", *d.NestedItem)
	}

	if d.Type == ReferenceApiObjectDefinitionType {
		return fmt.Sprintf("Reference %q", *d.ReferenceName)
	}

	return string(d.Type)
}

type ApiObjectDefinitionType string

const (
	BooleanApiObjectDefinitionType    ApiObjectDefinitionType = "Boolean"
	CsvApiObjectDefinitionType        ApiObjectDefinitionType = "Csv"
	DateTimeApiObjectDefinitionType   ApiObjectDefinitionType = "DateTime"
	DictionaryApiObjectDefinitionType ApiObjectDefinitionType = "Dictionary"
	IntegerApiObjectDefinitionType    ApiObjectDefinitionType = "Integer"
	FloatApiObjectDefinitionType      ApiObjectDefinitionType = "Float"
	ListApiObjectDefinitionType       ApiObjectDefinitionType = "List"
	RawFileApiObjectDefinitionType    ApiObjectDefinitionType = "RawFile"
	RawObjectApiObjectDefinitionType  ApiObjectDefinitionType = "RawObject"
	ReferenceApiObjectDefinitionType  ApiObjectDefinitionType = "Reference"
	StringApiObjectDefinitionType     ApiObjectDefinitionType = "String"

	// Custom Types
	EdgeZoneApiObjectDefinitionType                                ApiObjectDefinitionType = "EdgeZone"
	LocationApiObjectDefinitionType                                ApiObjectDefinitionType = "Location"
	SystemAssignedIdentityApiObjectDefinitionType                  ApiObjectDefinitionType = "SystemAssignedIdentity"
	SystemAndUserAssignedIdentityListApiObjectDefinitionType       ApiObjectDefinitionType = "SystemAndUserAssignedIdentityList"
	SystemAndUserAssignedIdentityMapApiObjectDefinitionType        ApiObjectDefinitionType = "SystemAndUserAssignedIdentityMap"
	LegacySystemAndUserAssignedIdentityListApiObjectDefinitionType ApiObjectDefinitionType = "LegacySystemAndUserAssignedIdentityList"
	LegacySystemAndUserAssignedIdentityMapApiObjectDefinitionType  ApiObjectDefinitionType = "LegacySystemAndUserAssignedIdentityMap"
	SystemOrUserAssignedIdentityListApiObjectDefinitionType        ApiObjectDefinitionType = "SystemOrUserAssignedIdentityList"
	SystemOrUserAssignedIdentityMapApiObjectDefinitionType         ApiObjectDefinitionType = "SystemOrUserAssignedIdentityMap"
	UserAssignedIdentityListApiObjectDefinitionType                ApiObjectDefinitionType = "UserAssignedIdentityList"
	UserAssignedIdentityMapApiObjectDefinitionType                 ApiObjectDefinitionType = "UserAssignedIdentityMap"
	TagsApiObjectDefinitionType                                    ApiObjectDefinitionType = "Tags"
	SystemData                                                     ApiObjectDefinitionType = "SystemData"
)
