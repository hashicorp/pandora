// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformSchemaFieldDocumentation defines the model for a given Schema Field
type TerraformSchemaFieldDocumentation struct {
	// Markdown specifies the description for this field using Markdown.
	Markdown string `json:"markdown"`
}
