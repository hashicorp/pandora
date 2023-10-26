package models

// TerraformSchemaModel defines a model used in the Terraform Schema, which is used to output
// both a Struct and the Terraform Schema itself.
type TerraformSchemaModel struct {
	// Fields specifies the Fields which exist within this Terraform Model.
	Fields []TerraformSchemaField `json:"fields"`

	// Name specifies the name of this Terraform Model.
	Name string `json:"name"`
}
