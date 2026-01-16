// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformSchemaFieldDocumentationDefinition defines the documentation for a TerraformSchemaField.
type TerraformSchemaFieldDocumentationDefinition struct {
	// TODO: consider supporting 'examples' and 'notes' in the future

	// Markdown specifies the documentation for this field in the Markdown format.
	Markdown string `json:"markdown"`
}
