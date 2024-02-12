// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"fmt"
)

// NOTE: the methods within this file are deprecated but remain in place
// temporarily to allow tools to continue to compile whilst the refactor
// is partially complete.
//
// Each item within this file will be marked as Deprecated - which should
// make it possible to detect usages of the old types fairly easily.

// Deprecated: use `helpers.GolangTypeForSDKObjectDefinition` instead.
func (d ApiObjectDefinition) GolangTypeName(packageName *string) (*string, error) {
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

	case ZoneApiObjectDefinitionType:
		// TODO: should we expose a custom wrapper type for single Zone?
		return toStringPointer("string")

	case ZonesApiObjectDefinitionType:
		return toStringPointer("zones.Schema")
	}

	return nil, fmt.Errorf("unimplemented object definition type %q", string(d.Type))
}

func (d SDKObjectDefinition) String() string {
	// TODO: determine if this should be removed

	if d.Type == DictionarySDKObjectDefinitionType {
		return fmt.Sprintf("Dictionary[string, %s]", *d.NestedItem)
	}

	if d.Type == ListSDKObjectDefinitionType {
		return fmt.Sprintf("List[%s]", *d.NestedItem)
	}

	if d.Type == ReferenceSDKObjectDefinitionType {
		return fmt.Sprintf("Reference %q", *d.ReferenceName)
	}

	return string(d.Type)
}

func toStringPointer(in string) (*string, error) {
	return &in, nil
}
