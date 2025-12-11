// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformSchemaFieldValidationType defines the type of Validation used for a TerraformSchemaField.
type TerraformSchemaFieldValidationType = string

const (
	// PossibleValuesTerraformSchemaFieldValidationType specifies that one of a fixed set of possible values must
	// be specified for this field.
	// Example: [`Standard` and `Basic` SKUs] or [`1-5`]
	PossibleValuesTerraformSchemaFieldValidationType TerraformSchemaFieldValidationType = "PossibleValues"
)
