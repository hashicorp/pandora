package resourcemanager

import (
	"fmt"
)

type ApiObjectDefinition struct {
	NestedItem    *ApiObjectDefinition    `json:"nestedItem,omitempty"`
	ReferenceName *string                 `json:"referenceName,omitempty"`
	Type          ApiObjectDefinitionType `json:"type"`
}

func (d ApiObjectDefinition) GolangTypeName(packageName *string) (*string, error) {
	// TODO: we should look to add unit tests for this method

	// NOTE: all of this validation should be done in the Importer and the API - this is purely sanity checking

	if d.Type == CsvApiObjectDefinitionType {
		if d.NestedItem == nil {
			return nil, fmt.Errorf("a csv type must have a nested item but didn't get one")
		}

		// TODO: determine how to handle these
		// for now treat CSV's as a string
		return toStringPointer("string")
	}

	if d.Type == DictionaryApiObjectDefinitionType {
		if d.NestedItem == nil {
			return nil, fmt.Errorf("a dictionary type must have a nested item but didn't get one")
		}

		innerType, err := d.NestedItem.GolangTypeName(packageName)
		if err != nil {
			return nil, fmt.Errorf("determining inner type for dictionary: %+v", err)
		}

		return toStringPointer(fmt.Sprintf("map[string]%s", *innerType))
	}

	if d.Type == ListApiObjectDefinitionType {
		if d.NestedItem == nil {
			return nil, fmt.Errorf("a list type must have a nested item but didn't get one")
		}

		innerType, err := d.NestedItem.GolangTypeName(packageName)
		if err != nil {
			return nil, fmt.Errorf("determining inner type for list: %+v", err)
		}

		return toStringPointer(fmt.Sprintf("[]%s", *innerType))
	}

	if d.Type == ReferenceApiObjectDefinitionType {
		if d.ReferenceName == nil {
			return nil, fmt.Errorf("missing Reference for a Reference ObjectDefinition")
		}

		out := *d.ReferenceName
		if packageName != nil {
			out = fmt.Sprintf("%s.%s", *packageName, out)
		}
		return toStringPointer(out)
	}

	switch d.Type {
	case BooleanApiObjectDefinitionType:
		return toStringPointer("bool")

	case DateTimeApiObjectDefinitionType:
		// intentional since we have cast methods one way or the other
		return toStringPointer("string")

	case FloatApiObjectDefinitionType:
		return toStringPointer("float64")

	case LocationApiObjectDefinitionType:
		return toStringPointer("string")

	case IntegerApiObjectDefinitionType:
		return toStringPointer("int64")

	case RawFileApiObjectDefinitionType:
		return toStringPointer("[]byte") // TODO: should this be a stream reader?

	case RawObjectApiObjectDefinitionType:
		return toStringPointer("interface{}")

	case StringApiObjectDefinitionType:
		return toStringPointer("string")

	case TagsApiObjectDefinitionType:
		return toStringPointer("map[string]string")

	// Custom Types
	case EdgeZoneApiObjectDefinitionType:
		return toStringPointer("edgezones.Model")

	case SystemAssignedIdentityApiObjectDefinitionType:
		return toStringPointer("identity.SystemAssigned")

	case UserAssignedIdentityListApiObjectDefinitionType:
		return toStringPointer("identity.UserAssignedList")

	case UserAssignedIdentityMapApiObjectDefinitionType:
		return toStringPointer("identity.UserAssignedMap")

	case LegacySystemAndUserAssignedIdentityListApiObjectDefinitionType:
		return toStringPointer("identity.LegacySystemAndUserAssignedList")

	case LegacySystemAndUserAssignedIdentityMapApiObjectDefinitionType:
		return toStringPointer("identity.LegacySystemAndUserAssignedMap")

	case SystemAndUserAssignedIdentityListApiObjectDefinitionType:
		return toStringPointer("identity.SystemAndUserAssignedList")

	case SystemAndUserAssignedIdentityMapApiObjectDefinitionType:
		return toStringPointer("identity.SystemAndUserAssignedMap")

	case SystemOrUserAssignedIdentityListApiObjectDefinitionType:
		return toStringPointer("identity.SystemOrUserAssignedList")

	case SystemOrUserAssignedIdentityMapApiObjectDefinitionType:
		return toStringPointer("identity.SystemOrUserAssignedMap")

	case SystemData:
		return toStringPointer("systemdata.SystemData")
	}

	return nil, fmt.Errorf("unimplemented object definition type %q", string(d.Type))
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

func toStringPointer(in string) (*string, error) {
	return &in, nil
}
