// Copyright IBM Corp. 2021, 2025
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

	if value == DirectAssignmentTerraformFieldMappingDefinitionType {
		var instance TerraformDirectAssignmentFieldMappingDefinition
		if err := json.Unmarshal(input, &instance); err != nil {
			return nil, fmt.Errorf("unmarshaling %q: %+v", value, err)
		}
		return instance, nil
	}
	if value == ModelToModelTerraformFieldMappingDefinitionType {
		var instance TerraformModelToModelFieldMappingDefinition
		if err := json.Unmarshal(input, &instance); err != nil {
			return nil, fmt.Errorf("unmarshaling %q: %+v", value, err)
		}
		return instance, nil
	}

	return nil, fmt.Errorf("internal-error: missing implementation for TerraformFieldMappingDefinition %q", value)
}
