package definitions

type Config struct {
	// Services is a map of ServiceName : ServiceDefinition
	Services map[string]ServiceDefinition
}

type ServiceDefinition struct {
	// APIVersions is a map of ApiVersion : ApiVersionDefinition
	ApiVersions map[string]ApiVersionDefinition

	// TerraformPackageName is the name of the associated Service Package within Terraform
	TerraformPackageName string
}

type ApiVersionDefinition struct {
	// Packages is a map of ResourceName : PackageDefinition
	Packages map[string]PackageDefinition
}

type PackageDefinition struct {
	// Definitions is a map of ResourceType : ResourceDefinition
	Definitions map[string]ResourceDefinition
}

type ResourceDefinition struct {
	// ID is the Resource ID which defines this Resource
	ID string

	// Name is the human-friendly/marketing name for this Resource
	Name string

	// WebsiteSubcategory is the name of the subcategory which this Resource should appear under on the website
	WebsiteSubcategory string

	// Description is the description for this Resource
	Description string

	// TestData contains specific values for the tests of this resource
	TestData ResourceTestDataDefinition
}

type ResourceTestDataDefinition struct {
	// BasicVariables contains key value pairs of field to test value for different variable types
	BasicVariables VariablesDefinition

	// CompleteVariables contains key value pairs of field to test value for different variable types
	CompleteVariables VariablesDefinition
}

type VariablesDefinition struct {
	Bools    map[string]bool
	Integers map[string]int64
	Lists    map[string][]string
	Strings  map[string]string
}
