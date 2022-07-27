package services

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// GetResourceManagerServices returns all of the Services supported by the Resource Manager endpoint
func GetResourceManagerServices(client resourcemanager.Client) (*ResourceManagerServices, error) {
	services, err := client.Services().Get()
	if err != nil {
		return nil, err
	}

	resourceManagerServices := make(map[string]ResourceManagerService, 0)
	for name, service := range *services {
		serviceDetails, err := client.ServiceDetails().Get(service)
		if err != nil {
			return nil, err
		}

		terraformDetails, err := client.Terraform().Get(*serviceDetails)
		if err != nil {
			return nil, err
		}

		serviceVersions := make(map[string]ServiceVersion, 0)
		for versionNumber, versionDetails := range serviceDetails.Versions {
			versionInfo, err := client.ServiceVersion().Get(versionDetails)
			if err != nil {
				return nil, err
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
			}
		}

		resourceManagerServices[name] = ResourceManagerService{
			Details:              service,
			TerraformPackageName: serviceDetails.TerraformPackageName,
			Terraform:            *terraformDetails,
			Versions:             serviceVersions,
		}
	}
	return &ResourceManagerServices{
		Services: resourceManagerServices,
	}, nil
}

// GetResourceManagerServicesByName returns the specified Services from the Data API
func GetResourceManagerServicesByName(client resourcemanager.Client, servicesToLoad []string) (*ResourceManagerServices, error) {
	services, err := client.Services().Get()
	if err != nil {
		return nil, err
	}

	serviceNames := make(map[string]struct{})
	for _, serviceName := range servicesToLoad {
		serviceNames[serviceName] = struct{}{}
	}

	resourceManagerServices := make(map[string]ResourceManagerService, 0)
	for name, service := range *services {
		if _, ok := serviceNames[name]; !ok {
			continue
		}

		serviceDetails, err := client.ServiceDetails().Get(service)
		if err != nil {
			return nil, err
		}

		terraformDetails, err := client.Terraform().Get(*serviceDetails)
		if err != nil {
			return nil, err
		}

		serviceVersions := make(map[string]ServiceVersion, 0)
		for versionNumber, versionDetails := range serviceDetails.Versions {
			versionInfo, err := client.ServiceVersion().Get(versionDetails)
			if err != nil {
				return nil, err
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
			}
		}

		resourceManagerServices[name] = ResourceManagerService{
			Details:              service,
			TerraformPackageName: serviceDetails.TerraformPackageName,
			Terraform:            *terraformDetails,
			Versions:             serviceVersions,
		}
	}
	return &ResourceManagerServices{
		Services: resourceManagerServices,
	}, nil
}
