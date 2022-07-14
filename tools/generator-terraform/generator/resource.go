package generator

import (
	"fmt"
	"os"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ResourceInput struct {
	// Details contains information about the Terraform Resource which should be generated.
	Details resourcemanager.TerraformResourceDetails

	// ProviderPrefix is the prefix used for the Terraform Provider (e.g. `azurerm`).
	ProviderPrefix string

	// ResourceIds is a map of key (ResourceIdName) to value (ResourceIdDefinition) for the specified SdkResourceName
	ResourceIds map[string]resourcemanager.ResourceIdDefinition

	// ResourceLabel is the label used for this resource without the provider prefix (e.g. `resource_group`).
	ResourceLabel string

	// ResourceTypeName is the name of the Resource Type, used as the name of the struct.
	ResourceTypeName string

	// RootDirectory is the path to the directory where generated files should be output.
	RootDirectory string

	// ServicePackageName is the name of the Service Package within the Terraform Provider repository.
	ServicePackageName string

	// SdkApiVersion is the API Version within the SdkServiceName which should be used.
	SdkApiVersion string

	// SdkResourceName is the name of the `resource` within the ApiVersion for this Service
	SdkResourceName string

	// SdkServiceName is the name of the `service` within `github.com/hashicorp/go-azure-sdk` which should be used.
	SdkServiceName string
}

func Resource(input ResourceInput) error {
	// ensure the service directory exists
	serviceDirectory := fmt.Sprintf("%s/internal/services/%s", input.RootDirectory, input.ServicePackageName)
	os.MkdirAll(serviceDirectory, 0755)

	// TODO: generating Tests and Docs

	filePath := fmt.Sprintf("%s/%s_resource.gen.go", serviceDirectory, input.ResourceLabel)
	// remove the file if it already exists
	os.Remove(filePath)

	components := []string{
		// NOTE: the ordering is important, components can opt in/out of generation
		packageDefinitionForResource(input),
		importsForResource(input),
		copyrightLinesForResource(input),
		definitionForResource(input),

		// then the functions
		idValidationFunctionForResource(input),
		typeFuncForResource(input),
		// TODO: Create
		// TODO: Delete
		// TODO: Mappings
		// TODO: Read
		// TODO: Schema
		// TODO: Typed Model & Model func.
		// TODO: Update
	}
	writeToPath(filePath, strings.Join(components, "\n"))
	return nil
}
