package models

import "github.com/hashicorp/pandora/tools/sdk/resourcemanager"

// TerraformSchemaModel holds information about all the fields associated with a Terraform Resource
type TerraformSchemaModel struct {
	// Fields describes all the fields associated with a Terraform Resource
	Fields []TerraformSchemaField `json:"fields"`
}

// TerraformSchemaField describes information about an attribute that will be mapped into the Terraform Schema of a resource
type TerraformSchemaField struct {
	// Constants describes the specific values this attribute can be
	Constants *resourcemanager.ConstantDetails `json:"constants,omitempty"` // TODO: this wants to get moved into the Validation object

	// Computed specifies whether this attribute is Computed
	Computed *bool `json:"computed,omitempty"`

	// Documentation describes what this attribute is
	Documentation *string `json:"documentation,omitempty"`

	// ForceNew specifies whether a change in this attribute requires Terraform to recreate the resource
	ForceNew *bool `json:"forceNew,omitempty"`

	// HclName specifies the snaked cased attribute name (e.g. resource_group_name)
	HclName string `json:"hclName"`

	// Optional specifies whether this attribute is Optional
	Optional *bool `json:"optional,omitempty"`

	// Name specifies the Display Name for this attribute
	Name string `json:"name"`

	// Required specifies whether this attribute is Required
	Required *bool `json:"required,omitempty"`

	// ObjectDefinition describes additional information about the specific type of attribute this is
	// and any nested items associated with this attribute
	ObjectDefinition *ObjectDefinition `json:"objectDefinition,omitempty"` // TODO: this wants

	// TODO: missing validation object
}
