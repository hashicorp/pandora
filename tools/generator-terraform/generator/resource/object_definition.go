package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: tests covering this

var fieldObjectDefinitionsToGolangTypes = map[resourcemanager.TerraformSchemaFieldType]string{
	resourcemanager.TerraformSchemaFieldTypeBoolean: "bool",
	// NOTE: we intentionally don't output helper funcs for this, since the SDK exposes DateTime's as strings
	resourcemanager.TerraformSchemaFieldTypeDateTime: "string",
	resourcemanager.TerraformSchemaFieldTypeFloat:    "float64",
	resourcemanager.TerraformSchemaFieldTypeInteger:  "int64",
	resourcemanager.TerraformSchemaFieldTypeString:   "string",

	resourcemanager.TerraformSchemaFieldTypeLocation: "string",
	resourcemanager.TerraformSchemaFieldTypeTags:     "map[string]interface{}",

	/*
		TODO: support for Custom Types

			TerraformSchemaFieldTypeEdgeZone                      TerraformSchemaFieldType = "EdgeZone"
			TerraformSchemaFieldTypeIdentitySystemAssigned        TerraformSchemaFieldType = "IdentitySystemAssigned"
			TerraformSchemaFieldTypeIdentitySystemAndUserAssigned TerraformSchemaFieldType = "IdentitySystemAndUserAssigned"
			TerraformSchemaFieldTypeIdentitySystemOrUserAssigned  TerraformSchemaFieldType = "IdentitySystemOrUserAssigned"
			TerraformSchemaFieldTypeIdentityUserAssigned          TerraformSchemaFieldType = "IdentityUserAssigned"
			TerraformSchemaFieldTypeLocation                      TerraformSchemaFieldType = "Location"
			TerraformSchemaFieldTypeResourceGroup                 TerraformSchemaFieldType = "ResourceGroup"
			TerraformSchemaFieldTypeTags                          TerraformSchemaFieldType = "Tags"
			TerraformSchemaFieldTypeZone                          TerraformSchemaFieldType = "Zone"
			TerraformSchemaFieldTypeZones                         TerraformSchemaFieldType = "Zones"
	*/
}

func golangFieldTypeFromObjectFieldDefinition(input resourcemanager.TerraformSchemaFieldObjectDefinition) (*string, error) {
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

		nestedObjectType, err := golangFieldTypeFromObjectFieldDefinition(*input.NestedObject)
		if err != nil {
			return nil, fmt.Errorf("retrieving golang field type for list nested item: %+v", err)
		}
		output := fmt.Sprintf("[]%s", *nestedObjectType)
		return &output, nil
	}

	if input.Type == resourcemanager.TerraformSchemaFieldTypeSet {
		if input.NestedObject == nil {
			return nil, fmt.Errorf("set type had no nested object")
		}

		nestedObjectType, err := golangFieldTypeFromObjectFieldDefinition(*input.NestedObject)
		if err != nil {
			return nil, fmt.Errorf("retrieving golang field type for list nested item: %+v", err)
		}
		output := fmt.Sprintf("[]%s", *nestedObjectType)
		return &output, nil
	}

	return nil, fmt.Errorf("internal-error: unimplement field object definition mapping: %q", string(input.Type))
}
