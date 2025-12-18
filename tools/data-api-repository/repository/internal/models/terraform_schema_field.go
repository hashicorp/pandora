// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformSchemaField describes information about an attribute that will be mapped into the Terraform Schema of a resource
type TerraformSchemaField struct {
	// Computed specifies whether this attribute is Computed
	Computed *bool `json:"computed,omitempty"`

	// Documentation describes what this attribute is
	Documentation *TerraformSchemaFieldDocumentation `json:"documentation,omitempty"`

	// ForceNew specifies whether a change in this attribute requires Terraform to recreate the resource
	ForceNew *bool `json:"forceNew,omitempty"`

	// HclName specifies the snaked cased attribute name (e.g. resource_group_name)
	HclName string `json:"hclName"`

	// Optional specifies whether this attribute is Optional
	Optional *bool `json:"optional,omitempty"`

	// Name specifies the Display Name for this attribute
	Name string `json:"name"`

	// ObjectDefinition describes additional information about the specific type of attribute this is
	// and any nested items associated with this attribute
	ObjectDefinition TerraformSchemaObjectDefinition `json:"objectDefinition"`

	// Required specifies whether this attribute is Required
	Required *bool `json:"required,omitempty"`

	// Validation defines what validation should be applied for this Terraform Schema Field.
	Validation *TerraformSchemaFieldValidationDefinition `json:"validation,omitempty"`
}
