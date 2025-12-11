// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformSchemaModel defines a model used in the Terraform Schema for a Resource.
//
// The TerraformSchemaModel is output both the Typed Model (i.e. a Go struct for this
// Resource) and as the Terraform Schema (that is the `Arguments()` and `Attributes()`
// methods in the Typed SDK).
//
// A Resource will always have at least one TerraformSchemaModel, which represents
// the Terraform Schema for that Resource. However, Nested Items (such as Lists/Sets)
// will each have a TerraformSchemaModel - as such a complex Resource is likely to
// have multiple TerraformSchemaModels used to define the full Terraform Schema.
type TerraformSchemaModel struct {
	// Fields specifies the Fields which exist within this Terraform Model.
	Fields []TerraformSchemaField `json:"fields"`

	// Name specifies the name of this Terraform Model.
	Name string `json:"name"`
}
