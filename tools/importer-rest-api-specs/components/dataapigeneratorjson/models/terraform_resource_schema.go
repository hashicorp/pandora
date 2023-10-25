package models

import "github.com/hashicorp/pandora/tools/sdk/resourcemanager"

// SchemaModel holds information about all the fields associated with a Terraform Resource
type SchemaModel struct {
	// Fields describes all the fields associated with a Terraform Resource
	Fields []SchemaField `json:"Fields"`
}

// SchemaField describes information about an attribute that will be mapped into the Terraform Schema of a resource
type SchemaField struct {
	// HclName specifies the snaked cased attribute name (e.g. resource_group_name)
	HclName string `json:"HclName"`

	// Documentation describes what this attribute is
	Documentation *string `json:"Documentation,omitempty"`

	// Required specifies whether this attribute is Required
	Required *bool `json:"Required,omitempty"`

	// Optional specifies whether this attribute is Optional
	Optional *bool `json:"Optional,omitempty"`

	// Computed specifies whether this attribute is Computed
	Computed *bool `json:"Computed,omitempty"`

	// ForceNew specifies whether a change in this attribute requires Terraform to recreate the resource
	ForceNew *bool `json:"ForceNew,omitempty"`

	// Name specifies the Display Name for this attribute
	Name string `json:"Name"`

	// Constants describes the specific values this attribute can be
	Constants *resourcemanager.ConstantDetails `json:"Constants,omitempty"`

	// ObjectDefinition describes additional information about the specific type of attribute this is
	// and any nested items associated with this attribute
	ObjectDefinition *ObjectDefinition `json:"ObjectDefinition,omitempty"`
}
