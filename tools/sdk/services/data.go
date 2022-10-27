package services

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"sync"
)

// GetResourceManagerServices returns all of the Services supported by the Resource Manager endpoint
func GetResourceManagerServices(client resourcemanager.Client) (*ResourceManagerServices, error) {
	return GetResourceManagerServicesByName(client, nil)
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
	var wg sync.WaitGroup
	var lock sync.Mutex
	for name, service := range *services {
		if len(serviceNames) > 0 {
			if _, ok := serviceNames[name]; !ok {
				continue
			}
		}

		wg.Add(1)
		go func(name string, service resourcemanager.ServiceSummary) {
			defer wg.Done()
			serviceDetails, err := client.ServiceDetails().Get(service)
			if err != nil {
				return
			}

			terraformDetails, err := client.Terraform().Get(*serviceDetails)
			if err != nil {
				return
			}

			serviceVersions := make(map[string]ServiceVersion, 0)
			for versionNumber, versionDetails := range serviceDetails.Versions {
				versionInfo, err := client.ServiceVersion().Get(versionDetails)
				if err != nil {
					return
				}

				resources := make(map[string]Resource)
				for resourceName, resourceDetails := range versionInfo.Resources {
					operations, err := client.ApiOperations().Get(resourceDetails)
					if err != nil {
						return
					}

					schema, err := client.ApiSchema().Get(resourceDetails)
					if err != nil {
						return
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

			item := ResourceManagerService{
				Details:              service,
				TerraformPackageName: serviceDetails.TerraformPackageName,
				Terraform:            *terraformDetails,
				Versions:             serviceVersions,
			}
			lock.Lock()
			resourceManagerServices[name] = item
			lock.Unlock()
		}(name, service)
	}
	wg.Wait()

	return &ResourceManagerServices{
		Services: resourceManagerServices,
	}, nil
}
