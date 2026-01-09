// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformSchemaModel defines a Model used within the Terraform Schema for a Terraform Data Source/Resource.
type TerraformSchemaModel struct {
	// Fields specifies a map of Field Name (key) to TerraformSchemaField (value) representing
	// the Fields available within this Schema Model.
	// The Field Name is an Identifier.
	Fields map[string]TerraformSchemaField `json:"fields"`
}
