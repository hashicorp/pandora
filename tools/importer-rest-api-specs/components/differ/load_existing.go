package differ

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (d *Differ) RetrieveExistingService(serviceName, apiVersion string) (*models.AzureApiDefinition, error) {
	services, err := d.client.Services().Get()
	if err != nil {
		return nil, fmt.Errorf("retrieving Services from Data API: %+v", err)
	}
	if services == nil {
		return nil, nil
	}

	var existingService *models.AzureApiDefinition
	for name, service := range *services {
		if !strings.EqualFold(name, serviceName) {
			continue
		}

		serviceDetails, err := d.client.ServiceDetails().Get(service)
		if err != nil {
			return nil, fmt.Errorf("retrieving Service Details for %q: %+v", serviceName, err)
		}
		if serviceDetails == nil {
			return nil, nil
		}

		terraformDetails, err := d.client.Terraform().Get(*serviceDetails)
		if err != nil {
			return nil, fmt.Errorf("retrieving Terraform Details for Service %q: %+v", serviceName, err)
		}

		for version, versionSummary := range serviceDetails.Versions {
			if !strings.EqualFold(version, apiVersion) {
				continue
			}

			versionDetails, err := d.client.ServiceVersion().Get(versionSummary)
			if err != nil {
				return nil, fmt.Errorf("retrieving Details for Service %q Version %q: %+v", serviceName, apiVersion, err)
			}
			if versionDetails == nil {
				continue
			}

			resources := make(map[string]models.AzureApiResource)

			for resourceName, resourceSummary := range versionDetails.Resources {
				resourceOperations, err := d.client.ApiOperations().Get(resourceSummary)
				if err != nil {
					return nil, fmt.Errorf("retrieving API Operations for Service %q Version %q Resource %q: %+v", serviceName, apiVersion, resourceName, err)
				}
				if resourceOperations == nil {
					continue
				}

				resourceSchema, err := d.client.ApiSchema().Get(resourceSummary)
				if err != nil {
					return nil, fmt.Errorf("retrieving API Schema for Service %q Version %q Resource %q: %+v", serviceName, apiVersion, resourceName, err)
				}
				if resourceSchema == nil {
					continue
				}

				mappedModels, err := transformer.MapApiModelsToModelDetails(resourceSchema.Models)
				if err != nil {
					return nil, fmt.Errorf("mapping Models for Resource %q / Service %q / Version %q: %+v", resourceName, serviceName, apiVersion, err)
				}

				mappedOperations, err := transformer.MapApiOperationsToOperationDetails(resourceOperations.Operations)
				if err != nil {
					return nil, fmt.Errorf("mapping Operations for Resource %q / Service %q / Version %q: %+v", resourceName, serviceName, apiVersion, err)
				}

				mappedResourceIds, err := transformer.MapApiResourceIdDefinitionsToParsedResourceIds(resourceSchema.ResourceIds, resourceSchema.Constants)
				if err != nil {
					return nil, fmt.Errorf("mapping Resource ID's for Resource %q / Service %q / Version %q: %+v", resourceName, serviceName, apiVersion, err)
				}

				filteredTerraform := filterTerraformDataToApiVersionAndResource(terraformDetails, apiVersion, resourceName)

				resources[resourceName] = models.AzureApiResource{
					Constants:   resourceSchema.Constants,
					Models:      *mappedModels,
					Operations:  *mappedOperations,
					ResourceIds: *mappedResourceIds,
					Terraform:   filteredTerraform,
				}
			}

			existingService = &models.AzureApiDefinition{
				ServiceName: serviceName,
				ApiVersion:  version,
				Resources:   resources,
			}
		}
	}

	// TODO: map across the ResourceProvider and the TerraformPackageName

	// TODO: if the parser returns a single `parser.ParsedData` then this can too - but for now emulate the same result
	return existingService, nil
}

func filterTerraformDataToApiVersionAndResource(input *resourcemanager.TerraformDetails, apiVersion string, resourceName string) *resourcemanager.TerraformDetails {
	if input == nil {
		return nil
	}

	out := resourcemanager.TerraformDetails{
		DataSources: map[string]resourcemanager.TerraformDataSourceDetails{},
		Resources:   map[string]resourcemanager.TerraformResourceDetails{},
	}
	//for k, v := range input.DataSources {
	//	if v.ApiVersion == apiVersion && v.Resource == resourceName {
	//		out.DataSources[k] = v
	//	}
	//}

	for k, v := range input.Resources {
		if v.ApiVersion == apiVersion && v.Resource == resourceName {
			out.Resources[k] = v
		}
	}

	return &out
}
