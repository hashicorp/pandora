// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"encoding/json"
	"fmt"
)

// TerraformFieldMappingDefinition defines how a given TerraformSchemaField within a TerraformSchemaModel
// should be mapped onto a SDKField within a SDKModel.
type TerraformFieldMappingDefinition interface {
	// mappingDefinitionType specifies the type of TerraformFieldMappingDefinitionType this TerraformFieldMappingType
	// represents.
	mappingDefinitionType() TerraformFieldMappingDefinitionType
}

// terraformFieldMappingTypes defines the list of supported TerraformFieldMappingTypes, used to enable
// the correct implementation to be unmarshalled based on the `type` field.
var terraformFieldMappingTypes = []TerraformFieldMappingDefinition{
	TerraformDirectAssignmentFieldMappingDefinition{},
	TerraformModelToModelFieldMappingDefinition{},
}

// unmarshalTerraformFieldMappingDefinitionImplementation provides a custom unmarshal function to deserialize the correct
// TerraformFieldMappingDefinition implementation based on the `type` field.
func unmarshalTerraformFieldMappingDefinitionImplementation(input []byte) (TerraformFieldMappingDefinition, error) {
	if input == nil {
		return nil, nil
	}

	var temp map[string]interface{}
	if err := json.Unmarshal(input, &temp); err != nil {
		return nil, fmt.Errorf("unmarshaling TerraformFieldMappingDefinition into map[string]interface: %+v", err)
	}

	value, ok := temp["type"].(string)
	if !ok {
		return nil, nil
	}

	for _, impl := range terraformFieldMappingTypes {
		if impl.mappingDefinitionType() == value {
			if err := json.Unmarshal(input, impl); err != nil {
				return nil, fmt.Errorf("unmarshaling %q: %+v", value, err)
			}
			return impl, nil
		}
	}

	return nil, fmt.Errorf("internal-error: missing implementation for TerraformFieldMappingDefinition %q", value)
}
