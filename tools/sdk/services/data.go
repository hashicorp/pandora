package services

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// GetResourceManagerServices returns all of the Services supported by the Resource Manager endpoint
func GetResourceManagerServices(client resourcemanager.Client) (*ResourceManagerServices, error) {
	services, err := client.Services().Get()
	if err != nil {
		return nil, err
	}

	resourceManagerServices := make(map[string]ResourceManagerService, 0)
	for serviceName, service := range *services {
		versions, err := client.ServiceDetails().Get(service)
		if err != nil {
			return nil, err
		}

		serviceVersions := make(map[string]ServiceVersion, 0)
		for versionNumber, versionDetails := range versions.Versions {
			versionInfo, err := client.ServiceVersion().Get(versionDetails)
			if err != nil {
				return nil, err
			}

			terraformDetails, err := client.Terraform().Get(*versionInfo)
			if err != nil {
				return nil, fmt.Errorf("")
			}

			resources := make(map[string]Resource)
			for resourceName, resourceDetails := range versionInfo.Resources {
				operations, err := client.ApiOperations().Get(resourceDetails)
				if err != nil {
					return nil, err
				}

				schema, err := client.ApiSchema().Get(resourceDetails)
				if err != nil {
					return nil, err
				}

				resources[resourceName] = Resource{
					Operations: *operations,
					Schema:     *schema,
				}
			}

			serviceVersions[versionNumber] = ServiceVersion{
				Details:   *versionInfo,
				Resources: resources,
				Terraform: *terraformDetails,
			}
		}

		resourceManagerServices[serviceName] = ResourceManagerService{
			Details:              service,
			TerraformPackageName: versions.TerraformPackageName,
			Versions:             serviceVersions,
		}
	}
	return &ResourceManagerServices{
		Services: resourceManagerServices,
	}, nil
}
