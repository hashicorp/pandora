// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"encoding/json"
	"fmt"
)

// TerraformSchemaFieldValidationDefinition defines the type of Validation available for a TerraformSchemaField.
type TerraformSchemaFieldValidationDefinition interface {
	// fieldValidationType returns the type of TerraformSchemaFieldValidationType for this implementation.
	fieldValidationType() TerraformSchemaFieldValidationType
}

var terraformSchemaFieldValidationDefinitions = []TerraformSchemaFieldValidationDefinition{
	TerraformSchemaFieldValidationPossibleValuesDefinition{},
}

// unmarshalTerraformSchemaFieldValidationDefinitionImplementation provides a custom unmarshal function to deserialize the correct
// TerraformSchemaFieldValidationDefinition implementation based on the `type` field.
func unmarshalTerraformSchemaFieldValidationDefinitionImplementation(input []byte) (TerraformSchemaFieldValidationDefinition, error) {
	if input == nil {
		return nil, nil
	}

	var temp map[string]interface{}
	if err := json.Unmarshal(input, &temp); err != nil {
		return nil, fmt.Errorf("unmarshaling TerraformSchemaFieldValidationDefinition into map[string]interface: %+v", err)
	}

	value, ok := temp["type"].(string)
	if !ok {
		return nil, nil
	}

	for _, impl := range terraformSchemaFieldValidationDefinitions {
		if impl.fieldValidationType() == value {
			if err := json.Unmarshal(input, impl); err != nil {
				return nil, fmt.Errorf("unmarshaling %q: %+v", value, err)
			}
			return impl, nil
		}
	}

	return nil, fmt.Errorf("internal-error: missing implementation for TerraformSchemaFieldValidationDefinition %q", value)
}
