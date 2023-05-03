package discovery

import "github.com/hashicorp/pandora/tools/sdk/config/definitions"

type ServiceInput struct {
	// RootNamespace is the root namespace which should be used as a prefix for each Service/API Version etc.
	// (e.g. `Pandora.Definitions.ResourceManager`).
	RootNamespace string

	// ServiceName is the name of the Service (e.g. `Compute`).
	ServiceName string

	// ApiVersion is the version of the API (e.g. `2020-10-01`).
	ApiVersion string

	// OutputDirectory is the directory where the generated files should be output.
	OutputDirectory string

	// ResourceProvider is the ResourceProvider associated with this Service (for example `Microsoft.Compute`)
	// parsed from the Resource ID.
	ResourceProvider *string

	// ResourceProviderToFilterTo allows filtering the operations for the given Service/API Version to only
	// operations contained within this Resource Provider. Whilst the majority of the time this can be left
	// unset, some Services such as Network include operations from different Resource Providers which can
	// cause issues - as such this field can be conditionally set to remove unrelated operations.
	ResourceProviderToFilterTo *string

	// SwaggerDirectory is the path to the directory containing the Swagger/OpenAPI files for this Service/API Version.
	SwaggerDirectory string

	// SwaggerFiles is a list of the Swagger/OpenAPI files for this Service/API Version.
	SwaggerFiles []string

	// TerraformServiceDefinition defines the Terraform related details for this Service, used for Terraform
	// related processing/generation.
	TerraformServiceDefinition *definitions.ServiceDefinition
}

// ResourceManagerServiceInput provides a Resource Manager specific wrapper around a ServiceInput
type ResourceManagerServiceInput struct {
	ServiceName                string
	ApiVersion                 string
	OutputDirectory            string
	ResourceProvider           *string
	ResourceProviderToFilterTo *string
	SwaggerDirectory           string
	SwaggerFiles               []string
	TerraformServiceDefinition *definitions.ServiceDefinition
}

func (rmi ResourceManagerServiceInput) ToRunInput() ServiceInput {
	return ServiceInput{
		RootNamespace:              "Pandora.Definitions.ResourceManager",
		ServiceName:                rmi.ServiceName,
		ApiVersion:                 rmi.ApiVersion,
		ResourceProvider:           rmi.ResourceProvider,
		ResourceProviderToFilterTo: rmi.ResourceProviderToFilterTo,
		OutputDirectory:            rmi.OutputDirectory,
		SwaggerDirectory:           rmi.SwaggerDirectory,
		SwaggerFiles:               rmi.SwaggerFiles,
		TerraformServiceDefinition: rmi.TerraformServiceDefinition,
	}
}
