// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var fieldObjectDefinitionsToGolangTypes = map[models.TerraformSchemaObjectDefinitionType]string{
	models.BooleanTerraformSchemaObjectDefinitionType: "bool",
	// whilst DateTime could be output as *time.Time the Go SDK outputs
	// this as a String with Get/Set methods to allow exposing this value
	// either as a raw string or by formatting the value, so we expect
	// a string here rather than a *time.Time
	models.DateTimeTerraformSchemaObjectDefinitionType: "string",
	models.FloatTerraformSchemaObjectDefinitionType:    "float64",
	models.IntegerTerraformSchemaObjectDefinitionType:  "int64",
	models.StringTerraformSchemaObjectDefinitionType:   "string",

	// Common Types
	models.EdgeZoneTerraformSchemaObjectDefinitionType:                      "string",
	models.LocationTerraformSchemaObjectDefinitionType:                      "string",
	models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType:        "[]identity.ModelSystemAssigned",
	models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType: "[]identity.ModelSystemAssignedUserAssigned",
	models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType:  "[]identity.ModelSystemAssignedUserAssigned",
	models.UserAssignedIdentityTerraformSchemaObjectDefinitionType:          "[]identity.ModelUserAssigned",
	models.ResourceGroupTerraformSchemaObjectDefinitionType:                 "string",
	models.TagsTerraformSchemaObjectDefinitionType:                          "map[string]interface{}",
	models.ZoneTerraformSchemaObjectDefinitionType:                          "string",
	models.ZonesTerraformSchemaObjectDefinitionType:                         "[]string",
}

var constantTypesToGolangTypes = map[models.SDKConstantType]string{
	models.IntegerSDKConstantType: "int64",
	models.FloatSDKConstantType:   "float64",
	models.StringSDKConstantType:  "string",
}

func GolangFieldTypeFromObjectFieldDefinition(input models.TerraformSchemaObjectDefinition) (*string, error) {
	goTypeName, ok := fieldObjectDefinitionsToGolangTypes[input.Type]
	if ok {
		return &goTypeName, nil
	}

	if input.Type == models.DictionaryTerraformSchemaObjectDefinitionType {
		if input.NestedObject == nil {
			return nil, fmt.Errorf("dictionary type had no nested object")
		}

		nestedObjectType, err := GolangFieldTypeFromObjectFieldDefinition(*input.NestedObject)
		if err != nil {
			return nil, fmt.Errorf("retrieving golang field type for dictionary nested item: %+v", err)
		}

		output := fmt.Sprintf("map[string]%s", *nestedObjectType)
		return &output, nil
	}

	if input.Type == models.ReferenceTerraformSchemaObjectDefinitionType {
		if input.ReferenceName == nil {
			return nil, fmt.Errorf("reference type had no reference")
		}

		output := fmt.Sprintf("[]%s", *input.ReferenceName)
		return &output, nil
	}

	if input.Type == models.ListTerraformSchemaObjectDefinitionType {
		if input.NestedObject == nil {
			return nil, fmt.Errorf("list type had no nested object")
		}

		nestedObjectType, err := GolangFieldTypeFromObjectFieldDefinition(*input.NestedObject)
		if err != nil {
			return nil, fmt.Errorf("retrieving golang field type for list nested item: %+v", err)
		}

		output := fmt.Sprintf("[]%s", *nestedObjectType)
		if nestedObjectTypeIsSlicedByDefault(input.NestedObject.Type) {
			// both References and the Identity items are already output as slices, so no need to double-slice this
			output = *nestedObjectType
		}
		return &output, nil
	}

	if input.Type == models.SetTerraformSchemaObjectDefinitionType {
		if input.NestedObject == nil {
			return nil, fmt.Errorf("set type had no nested object")
		}

		nestedObjectType, err := GolangFieldTypeFromObjectFieldDefinition(*input.NestedObject)
		if err != nil {
			return nil, fmt.Errorf("retrieving golang field type for list nested item: %+v", err)
		}
		output := fmt.Sprintf("[]%s", *nestedObjectType)
		if nestedObjectTypeIsSlicedByDefault(input.NestedObject.Type) {
			// references are already output as slices, so no need to double-slice this
			output = *nestedObjectType
		}
		return &output, nil
	}

	return nil, fmt.Errorf("internal-error: unimplement field object definition mapping: %q", string(input.Type))
}

func nestedObjectTypeIsSlicedByDefault(input models.TerraformSchemaObjectDefinitionType) bool {
	types := map[models.TerraformSchemaObjectDefinitionType]struct{}{
		models.ReferenceTerraformSchemaObjectDefinitionType:                     {},
		models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType:        {},
		models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType: {},
		models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType:  {},
		models.UserAssignedIdentityTerraformSchemaObjectDefinitionType:          {},
	}
	_, ok := types[input]
	return ok
}

func GolangFieldTypeFromConstantType(input models.SDKConstantType) (*string, error) {
	if v, ok := constantTypesToGolangTypes[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("internal-error: missing mapping for constant type %q", string(input))
}
