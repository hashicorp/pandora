// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformSchemaFieldValidationDefinition defines the Validation for a Schema Field within
// the Terraform Schema.
type TerraformSchemaFieldValidationDefinition struct {
	// Type specifies the type of validation used for this field
	Type TerraformSchemaFieldValidationType `json:"type"`

	// PossibleValues describes the list of Possible Values allowed for this field.
	PossibleValues *TerraformSchemaValidationPossibleValuesDefinition `json:"possibleValues,omitempty"`
}

type TerraformSchemaValidationPossibleValuesDefinition struct {
	// Type specifies the Type of the Values field, for easier parsing.
	Type TerraformSchemaValidationPossibleValuesType `json:"type"`

	// Values is the list of possible values allowed for this field, which can either be
	// a []int64, []float64 or []string depending on the value of `Type`.
	Values []interface{} `json:"values"`
}

type TerraformSchemaValidationPossibleValuesType string

const (
	FloatTerraformSchemaValidationPossibleValuesType   TerraformSchemaValidationPossibleValuesType = "Float"
	IntegerTerraformSchemaValidationPossibleValuesType TerraformSchemaValidationPossibleValuesType = "Integer"
	StringTerraformSchemaValidationPossibleValuesType  TerraformSchemaValidationPossibleValuesType = "String"
)

// TerraformSchemaFieldValidationType specifies the Type of validation used for this Field
// within the Terraform Schema.
type TerraformSchemaFieldValidationType string

const (
	// PossibleValuesTerraformSchemaValidationType specifies that there's a fixed set of possible values
	// allowed for this field.
	PossibleValuesTerraformSchemaValidationType TerraformSchemaFieldValidationType = "PossibleValues"

	// TODO: we should implement `PossibleValuesFromConstant` and potentially others (NoEmptyValues/Ranges)
	// in the future
)
