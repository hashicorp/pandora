package dataworkarounds

import (
	"fmt"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundNginx26883{}

// workaroundNginx26883 works around an issue in Nginx where Nginx Configuration is defined as
// a user configurable value - but is a singleton and thus only supports a single value (`default`).
// Therefore, this is an operation on the Nginx Deployment, rather than being a separate resouce
// in its own right, and is created by the API by default - so
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/26883
type workaroundNginx26883 struct {
}

func (workaroundNginx26883) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "Nginx"
	apiVersionMatches := apiDefinition.ApiVersion == "2022-08-01" || apiDefinition.ApiVersion == "2023-04-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundNginx26883) Name() string {
	return "Nginx / 26883"
}

func (workaroundNginx26883) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["NginxConfiguration"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource NginxConfiguration")
	}

	// validate that the replacement Resource ID is present (which comes from the List operation)
	if _, ok := resource.ResourceIds["NginxDeploymentId"]; !ok {
		return nil, fmt.Errorf("couldn't find ResourceId `NginxDeploymentId` within API Resource `NginxConfiguration`")
	}
	// check the old ID is here (so the workaround is still valid)
	if _, ok := resource.ResourceIds["ConfigurationId"]; !ok {
		return nil, fmt.Errorf("couldn't find ResourceId `ConfigurationId` within API Resource `NginxConfiguration`")
	}

	operationNames := []string{
		"ConfigurationsCreateOrUpdate",
		"ConfigurationsDelete",
		"ConfigurationsGet",
	}
	for _, operationName := range operationNames {
		operation, ok := resource.Operations[operationName]
		if !ok {
			return nil, fmt.Errorf("couldn't find Operation %q", operationName)
		}
		operation.ResourceIdName = pointer.To("NginxDeploymentId")
		resource.Operations[operationName] = operation
	}
	delete(resource.ResourceIds, "ConfigurationId")

	apiDefinition.Resources["NginxConfiguration"] = resource
	return &apiDefinition, nil
}
