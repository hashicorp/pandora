package models

// TerraformResourceDefinition describes a Resource with information specific to Terraform
type TerraformResourceDefinition struct {
	// Category specifies the Category under which this Resource should appear in the documentation.
	Category string `json:"category"`

	// CreateMethod defines the Create Method associated with this Resource.
	CreateMethod TerraformMethodDefinition `json:"createMethod"`

	// DeleteMethod defines the Delete Method associated with this Resource.
	DeleteMethod TerraformMethodDefinition `json:"deleteMethod"`

	// Description is the description which should be used for this Resource.
	Description string `json:"description"`

	// DisplayName specifies the human-readable name for this Resource, used in the Documentation. (e.g. Load Test)
	DisplayName string `json:"displayName"`

	// ExampleUsage is the Example Usage snippet for this Resource which can be used in the documentation.
	ExampleUsage string `json:"exampleUsage"`

	// GenerateIdValidationFunction specifies whether an ID Validation Function should be generated
	// for this Resource.
	GenerateIdValidationFunction bool `json:"generateIdValidationFunction"`

	/// GenerateModel specifies whether the Typed Model(s) should be output for this Resource.
	GenerateModel bool `json:"generateModel"`

	/// GenerateSchema specifies whether the Schema should be generated for this Resource.
	GenerateSchema bool `json:"generateSchema"`

	// Label is the Terraform Resource Label which should be used for this Resource
	// **without** the Provider Prefix (e.g. `resource_group` rather than `azurerm_resource_group`).
	Label string `json:"label"`

	// ReadMethod defines the Read Method associated with this Resource.
	ReadMethod TerraformMethodDefinition `json:"readMethod"`

	// ResourceIdName specifies the name of the Resource ID type used for this Resource.
	ResourceIdName string `json:"resourceIdName"`

	// UpdateMethod defines the Update Method associated with this Resource.
	UpdateMethod *TerraformMethodDefinition `json:"updateMethod,omitempty"`
}

type TerraformMethodDefinition struct {
	// Generate determines whether this TerraformMethodDefinition is generated or not
	Generate bool `json:"generate"`

	// Name specifies what SDK method that will be called (e.g.Delete)
	Name string `json:"name"`

	// TimeoutInMinutes specifies how long in minutes that the method should run before timing out
	TimeoutInMinutes int `json:"timeoutInMinutes"`
}
