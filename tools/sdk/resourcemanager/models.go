package resourcemanager

import "fmt"

type ApiObjectDefinition struct {
	NestedItem    *ApiObjectDefinition    `json:"nestedItem,omitempty"`
	ReferenceName *string                 `json:"referenceName,omitempty"`
	Type          ApiObjectDefinitionType `json:"type"`
}


func (od ApiObjectDefinition) String() string {
	v := fmt.Sprintf("%s", string(od.Type))
	if od.Type == ReferenceApiObjectDefinitionType {
		v = fmt.Sprintf("Reference[%s]", od.Type)
	}
	if od.NestedItem != nil {
		if od.Type == DictionaryApiObjectDefinitionType {
			v = fmt.Sprintf("Dictionary[%s]", od.NestedItem.String())
		}
		if od.Type == ListApiObjectDefinitionType {
			v = fmt.Sprintf("List[%s]", od.NestedItem.String())
		}
	}

	return v
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
)
