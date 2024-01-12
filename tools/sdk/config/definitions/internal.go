package definitions

type definition struct {
	Services []serviceDefinition `hcl:"service,block"`
}

type serviceDefinition struct {
	// Name is the name of this Service (e.g. `Compute`).
	Name string `hcl:"name,label"`

	// ApiVersions is a slice of Api Versions which should be processed.
	ApiVersions []apiVersionDefinition `hcl:"api,block"`

	// TerraformPackageName is the name of the associated Service Package within Terraform
	TerraformPackageName string `hcl:"terraform_package"`
}

type apiVersionDefinition struct {
	// Version is the API Version (e.g. `2020-02-01`).
	Version string `hcl:"version,label"`

	// Packages is a slice of the Resources within this API Version to process.
	Packages []packageDefinition `hcl:"package,block"`
}

type packageDefinition struct {
	// Name is the name of the Resource within this API Version
	// (e.g. `VirtualMachines` inside of API Version `2020-02-01` in the `Compute` service).
	Name string `hcl:"name,label"`

	// Definitions is a slice of the Definitions to process.
	Definitions []resourceDefinition `hcl:"definition,block"`
}

type resourceDefinition struct {
	// ResourceType is the type of this resource, without the provider suffix
	// for example `resource_group` for `azurerm_resource_group`.
	ResourceType string `hcl:"resource_type,label"`

	// DisplayName is the human-friendly display name for this resource, generally
	// the Resource Type with spaces, but sometimes a different marketing name.
	DisplayName string `hcl:"display_name"`

	// Id is the Resource ID which defines this resource
	Id string `hcl:"id"`

	// WebsiteSubcategory is the name of the subcategory which this Resource should appear under on the website
	WebsiteSubcategory string `hcl:"website_subcategory"`

	// Description is the description for this Resource
	Description string `hcl:"description"`

	// TestData contains specific values for the tests of this resource
	TestData []resourceTestDataDefinition `hcl:"test_data,block"`

	// Overrides contains a mapping of properties that require renames or custom descriptions, for now
	Overrides *map[string]override `hcl:"overrides"`
}

type override struct {
	// Name defines an override for the Name for this field
	Name *string `hcl:"name,omitempty"`

	// Description defines a custom description for this field.
	// If unspecified a description will be determined based on the field name.
	Description *string `hcl:"description,omitempty"`
}

type resourceTestDataDefinition struct {
	// BasicVariables contains key value pairs of field to test value for the basic test
	BasicVariables []variablesDefinition `hcl:"basic_variables,block"`

	// CompleteVariables contains key value pairs of field to test value for the complete test
	CompleteVariables []variablesDefinition `hcl:"complete_variables,block"`
}

type variablesDefinition struct {
	Bools    *map[string]bool     `hcl:"bools"`
	Integers *map[string]int64    `hcl:"integers"`
	Lists    *map[string][]string `hcl:"lists"`
	Strings  *map[string]string   `hcl:"strings"`
}
