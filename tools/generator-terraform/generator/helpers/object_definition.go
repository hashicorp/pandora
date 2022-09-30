package helpers

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var fieldObjectDefinitionsToGolangTypes = map[resourcemanager.TerraformSchemaFieldType]string{
	resourcemanager.TerraformSchemaFieldTypeBoolean: "bool",
	// whilst DateTime could be output as *time.Time the Go SDK outputs
	// this as a String with Get/Set methods to allow exposing this value
	// either as a raw string or by formatting the value, so we expect
	// a string here rather than a *time.Time
	resourcemanager.TerraformSchemaFieldTypeDateTime: "string",
	resourcemanager.TerraformSchemaFieldTypeFloat:    "float64",
	resourcemanager.TerraformSchemaFieldTypeInteger:  "int64",
	resourcemanager.TerraformSchemaFieldTypeString:   "string",

	// Common Types
	resourcemanager.TerraformSchemaFieldTypeEdgeZone:                      "string",
	resourcemanager.TerraformSchemaFieldTypeLocation:                      "string",
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned:        "identity.ModelSystemAssigned",
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: "identity.ModelSystemAssignedUserAssigned",
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned:  "identity.ModelSystemAssignedUserAssigned",
	resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned:          "identity.ModelUserAssigned",
	resourcemanager.TerraformSchemaFieldTypeResourceGroup:                 "string",
	resourcemanager.TerraformSchemaFieldTypeTags:                          "map[string]interface{}",
	resourcemanager.TerraformSchemaFieldTypeZone:                          "string",
	resourcemanager.TerraformSchemaFieldTypeZones:                         "[]string",
}

var constantTypesToGolangTypes = map[resourcemanager.ConstantType]string{
	resourcemanager.IntegerConstant: "int64",
	resourcemanager.FloatConstant:   "float64",
	resourcemanager.StringConstant:  "string",
}

func GolangFieldTypeFromObjectFieldDefinition(input resourcemanager.TerraformSchemaFieldObjectDefinition) (*string, error) {
	goTypeName, ok := fieldObjectDefinitionsToGolangTypes[input.Type]
	if ok {
		return &goTypeName, nil
	}

	if input.Type == resourcemanager.TerraformSchemaFieldTypeReference {
		if input.ReferenceName == nil {
			return nil, fmt.Errorf("reference type had no reference")
		}

		// TODO: confirm these should be output as an array
		output := fmt.Sprintf("[]%s", *input.ReferenceName)
		return &output, nil
	}

	if input.Type == resourcemanager.TerraformSchemaFieldTypeList {
		if input.NestedObject == nil {
			return nil, fmt.Errorf("list type had no nested object")
		}

		nestedObjectType, err := GolangFieldTypeFromObjectFieldDefinition(*input.NestedObject)
		if err != nil {
			return nil, fmt.Errorf("retrieving golang field type for list nested item: %+v", err)
		}

		output := fmt.Sprintf("[]%s", *nestedObjectType)
		if input.NestedObject.Type == resourcemanager.TerraformSchemaFieldTypeReference {
			// references are already output as slices, so no need to double-slice this
			output = *nestedObjectType
		}
		return &output, nil
	}

	if input.Type == resourcemanager.TerraformSchemaFieldTypeSet {
		if input.NestedObject == nil {
			return nil, fmt.Errorf("set type had no nested object")
		}

		nestedObjectType, err := GolangFieldTypeFromObjectFieldDefinition(*input.NestedObject)
		if err != nil {
			return nil, fmt.Errorf("retrieving golang field type for list nested item: %+v", err)
		}
		output := fmt.Sprintf("[]%s", *nestedObjectType)
		if input.NestedObject.Type == resourcemanager.TerraformSchemaFieldTypeReference {
			// references are already output as slices, so no need to double-slice this
			output = *nestedObjectType
		}
		return &output, nil
	}

	return nil, fmt.Errorf("internal-error: unimplement field object definition mapping: %q", string(input.Type))
}

func GolangFieldTypeFromConstantType(input resourcemanager.ConstantType) (*string, error) {
	if v, ok := constantTypesToGolangTypes[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("internal-error: missing mapping for constant type %q", string(input))
}
