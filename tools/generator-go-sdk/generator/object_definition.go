package generator

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func golangTypeNameForObjectDefinition(input resourcemanager.ApiObjectDefinition) (*string, error) {
	var out = func(in string) (*string, error) {
		return &in, nil
	}

	// NOTE: all of this validation should be done in the Importer and the API - this is purely sanity checking

	if input.Type == resourcemanager.CsvApiObjectDefinitionType {
		if input.NestedItem == nil {
			return nil, fmt.Errorf("a csv type must have a nested item but didn't get one")
		}

		// TODO: determine how to handle these
		// for now treat CSV's as a string
		return out("string")
	}

	if input.Type == resourcemanager.DictionaryApiObjectDefinitionType {
		if input.NestedItem == nil {
			return nil, fmt.Errorf("a dictionary type must have a nested item but didn't get one")
		}

		innerType, err := golangTypeNameForObjectDefinition(*input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("determining inner type for dictionary: %+v", err)
		}

		return out(fmt.Sprintf("map[string]%s", *innerType))
	}

	if input.Type == resourcemanager.ListApiObjectDefinitionType {
		if input.NestedItem == nil {
			return nil, fmt.Errorf("a list type must have a nested item but didn't get one")
		}

		innerType, err := golangTypeNameForObjectDefinition(*input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("determining inner type for list: %+v", err)
		}

		return out(fmt.Sprintf("[]%s", *innerType))
	}

	if input.Type == resourcemanager.ReferenceApiObjectDefinitionType {
		if input.ReferenceName == nil {
			return nil, fmt.Errorf("missing Reference for a Reference ObjectDefinition")
		}

		return out(*input.ReferenceName)
	}

	switch input.Type {
	case resourcemanager.BooleanApiObjectDefinitionType:
		return out("bool")

	case resourcemanager.DateTimeApiObjectDefinitionType:
		// intentional since we have cast methods one way or the other
		return out("string")

	case resourcemanager.FloatApiObjectDefinitionType:
		return out("float64")

	case resourcemanager.LocationApiObjectDefinitionType:
		return out("string")

	case resourcemanager.IntegerApiObjectDefinitionType:
		return out("int64")

	case resourcemanager.RawFileApiObjectDefinitionType:
		return out("[]byte") // TODO: should this be a stream reader?

	case resourcemanager.RawObjectApiObjectDefinitionType:
		return out("interface{}")

	case resourcemanager.StringApiObjectDefinitionType:
		return out("string")

	case resourcemanager.TagsApiObjectDefinitionType:
		return out("map[string]string")

		// Custom Types
	case resourcemanager.SystemAssignedIdentityApiObjectDefinitionType:
		return out("identity.SystemAssignedIdentity")

	case resourcemanager.UserAssignedIdentityListApiObjectDefinitionType:
		return out("identity.UserAssignedIdentityList")

	case resourcemanager.UserAssignedIdentityMapApiObjectDefinitionType:
		return out("identity.UserAssignedIdentityMap")

	case resourcemanager.SystemUserAssignedIdentityListApiObjectDefinitionType:
		return out("identity.SystemUserAssignedIdentityList")

	case resourcemanager.SystemUserAssignedIdentityMapApiObjectDefinitionType:
		return out("identity.SystemUserAssignedIdentityMap")
	}

	return nil, fmt.Errorf("unimplemented object definition type %q", string(input.Type))
}
