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
}
