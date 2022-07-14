package services

import "github.com/hashicorp/pandora/tools/sdk/resourcemanager"

type ResourceManagerServices struct {
	Services map[string]ResourceManagerService
}

type ResourceManagerService struct {
	Details              resourcemanager.ServiceSummary
	TerraformPackageName string
	Versions             map[string]ServiceVersion
}

type ServiceVersion struct {
	Details   resourcemanager.ServiceVersionDetails
	Resources map[string]Resource
	Terraform resourcemanager.TerraformDetails
}

type Resource struct {
	Operations resourcemanager.ApiOperationDetails
	Schema     resourcemanager.ApiSchemaDetails
}
