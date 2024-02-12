// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformSchemaFieldValidationPossibleValuesType defines the type of possible values for a TerraformSchemaField.
type TerraformSchemaFieldValidationPossibleValuesType string

const (
	// FloatTerraformSchemaFieldValidationPossibleValuesType specifies that the list of possible values contains
	// Float values.
	FloatTerraformSchemaFieldValidationPossibleValuesType TerraformSchemaFieldValidationPossibleValuesType = "Float"

	// IntegerTerraformSchemaFieldValidationPossibleValuesType specifies that the list of possible values contains
	// Integer values.
	IntegerTerraformSchemaFieldValidationPossibleValuesType TerraformSchemaFieldValidationPossibleValuesType = "Int"

	// StringTerraformSchemaFieldValidationPossibleValuesType specifies that the list of possible values contains
	// String values.
	StringTerraformSchemaFieldValidationPossibleValuesType TerraformSchemaFieldValidationPossibleValuesType = "String"
)
