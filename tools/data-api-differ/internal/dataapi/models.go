package dataapi

import "github.com/hashicorp/pandora/tools/sdk/resourcemanager"

type Data struct {
	ResourceManagerServices map[string]ServiceData
}

type ServiceData struct {
	// ApiVersions is a map of the ApiVersion (key) to apiVersionData (value)
	ApiVersions map[string]ApiVersionData

	// Generate specifies whether this should be generated
	Generate bool

	// ResourceProvider is the Resource Provider this service represents
	ResourceProvider *string

	// TerraformPackageName is the name of the Service Package within
	// the Terraform Provider associated with this service.
	TerraformPackageName *string

	// TODO: support for Terraform Resources in the future
}

type ApiVersionData struct {
	Generate  bool
	Preview   bool
	Resources map[string]ApiResourceData
	Source    resourcemanager.ApiDefinitionsSource
}

type ApiResourceData struct {
	Constants   map[string]resourcemanager.ConstantDetails
	Models      map[string]resourcemanager.ModelDetails
	ResourceIds map[string]resourcemanager.ResourceIdDefinition
	Operations  map[string]resourcemanager.ApiOperation
}
