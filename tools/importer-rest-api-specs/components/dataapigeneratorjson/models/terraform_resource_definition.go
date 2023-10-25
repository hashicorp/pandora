package models

// ResourceDefinition describes a Resource with information specific to Terraform
type ResourceDefinition struct {
	// DisplayName specifies the human-readable name for this Resource, used in the Documentation. (e.g. Load Test)
	DisplayName string `json:"DisplayName"`

	// ResourceIdName specifies the name of the Resource ID type used for this Resource.
	ResourceIdName string `json:"Id"`

	// Label is the Terraform Resource Label which should be used for this Resource
	// **without** the Provider Prefix (e.g. `resource_group` rather than `azurerm_resource_group`).
	Label string `json:"Label"`

	// Category specifies the Category under which this Resource should appear in the documentation.
	Category string `json:"Category"`

	// Description is the description which should be used for this Resource.
	Description string `json:"Description"`

	// ExampleUsage is the Example Usage snippet for this Resource which can be used in the documentation.
	ExampleUsage string `json:"ExampleUsage"`

	// GenerateIDValidationFunction specifies whether an ID Validation Function should be generated
	// for this Resource.
	GenerateIDValidationFunction bool `json:"GenerateIDValidationFunction"`

	/// GenerateModel specifies whether the Typed Model(s) should be output for this Resource.
	GenerateModel bool `json:"GenerateModel"`

	/// GenerateSchema specifies whether the Schema should be generated for this Resource.
	GenerateSchema bool `json:"GenerateSchema"`

	// CreateMethod defines the Create Method associated with this Resource.
	CreateMethod Method `json:"CreateMethod"`

	// DeleteMethod defines the Delete Method associated with this Resource.
	DeleteMethod Method `json:"DeleteMethod"`

	// ReadMethod defines the Read Method associated with this Resource.
	ReadMethod Method `json:"ReadMethod"`

	// UpdateMethod defines the Update Method associated with this Resource.
	UpdateMethod *Method `json:"UpdateMethod,omitempty"`
}

type Method struct {
	// Generate determines whether this Method is generated or not
	Generate bool `json:"Generate"`

	// Name specifies what SDK method that will be called (e.g.Delete)
	Name string `json:"Name"`

	// TimeoutInMinutes specifies how long in minutes that the method should run before timing out
	TimeoutInMinutes int `json:"TimeoutInMinutes"`
}
