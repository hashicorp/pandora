// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"encoding/json"
	"fmt"
)

var _ json.Marshaler = &TerraformSchemaFieldValidationPossibleValuesDefinition{}
var _ TerraformSchemaFieldValidationDefinition = TerraformSchemaFieldValidationPossibleValuesDefinition{}

// TerraformSchemaFieldValidationPossibleValuesDefinition defines a list of Possible Values for a TerraformSchemaField.
type TerraformSchemaFieldValidationPossibleValuesDefinition struct {
	// TODO: remove this inner object once the SDK Refactor is complete since we're now using Discriminators directly.
	PossibleValues *TerraformSchemaFieldValidationPossibleValuesDefinitionImpl `json:"possibleValues"`
}

type TerraformSchemaFieldValidationPossibleValuesDefinitionImpl struct {
	// NOTE: this temporary struct exists until the SDK refactor is complete, at which point it can be inlined within the parent
	Type TerraformSchemaFieldValidationPossibleValuesType `json:"type"`

	// Values is the list of possible values allowed for this field, which can either be
	// a []int64, []float64 or []string depending on the value of `Type`.
	Values []any `json:"values"`
}

// fieldValidationType returns the type of TerraformSchemaFieldValidationType for this implementation.
func (TerraformSchemaFieldValidationPossibleValuesDefinition) fieldValidationType() TerraformSchemaFieldValidationType {
	return PossibleValuesTerraformSchemaFieldValidationType
}

func (d TerraformSchemaFieldValidationPossibleValuesDefinition) MarshalJSON() ([]byte, error) {
	type wrapper TerraformSchemaFieldValidationPossibleValuesDefinition
	wrapped := wrapper(d)
	encoded, err := json.Marshal(wrapped)
	if err != nil {
		return nil, fmt.Errorf("marshaling TerraformSchemaFieldValidationPossibleValuesDefinition: %+v", err)
	}

	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling TerraformSchemaFieldValidationPossibleValuesDefinition: %+v", err)
	}
	decoded["type"] = d.fieldValidationType()

	encoded, err = json.Marshal(decoded)
	if err != nil {
		return nil, fmt.Errorf("re-marshaling TerraformSchemaFieldValidationPossibleValuesDefinition: %+v", err)
	}

	return encoded, nil
}
