package differ

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

func (d *Differ) RetrieveExistingService(serviceName, apiVersion string) (*[]parser.ParsedData, error) {
	services, err := d.client.Services().Get()
	if err != nil {
		return nil, fmt.Errorf("retrieving Services from Data API: %+v", err)
	}
	if services == nil {
		return nil, nil
	}

	var existingService *parser.ParsedData
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

			terraformDetails, err := d.client.Terraform().Get(*versionDetails)
			if err != nil {
				return nil, fmt.Errorf("retrieving Terraform Details for Service %q / Version %q: %+v", serviceName, apiVersion, err)
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

				mappedConstants, err := transformer.MapApiConstantsToConstantDetails(resourceSchema.Constants)
				if err != nil {
					return nil, fmt.Errorf("mapping Constants for Resource %q / Service %q / Version %q: %+v", resourceName, serviceName, apiVersion, err)
				}

				mappedModels, err := transformer.MapApiModelsToModelDetails(resourceSchema.Models)
				if err != nil {
					return nil, fmt.Errorf("mapping Models for Resource %q / Service %q / Version %q: %+v", resourceName, serviceName, apiVersion, err)
				}

				mappedOperations, err := transformer.MapApiOperationsToOperationDetails(resourceOperations.Operations)
				if err != nil {
					return nil, fmt.Errorf("mapping Operations for Resource %q / Service %q / Version %q: %+v", resourceName, serviceName, apiVersion, err)
				}

				mappedResourceIds, err := transformer.MapApiResourceIdDefinitionsToParsedResourceIds(resourceSchema.ResourceIds, *mappedConstants)
				if err != nil {
					return nil, fmt.Errorf("mapping Resource ID's for Resource %q / Service %q / Version %q: %+v", resourceName, serviceName, apiVersion, err)
				}

				resources[resourceName] = models.AzureApiResource{
					Constants:   *mappedConstants,
					Models:      *mappedModels,
					Operations:  *mappedOperations,
					ResourceIds: *mappedResourceIds,
					Terraform:   *terraformDetails,
				}
			}

			existingService = &parser.ParsedData{
				ServiceName: serviceName,
				ApiVersion:  version,
				Resources:   resources,
			}
		}
	}

	// TODO: map across the ResourceProvider and the TerraformPackageName

	// TODO: if the parser returns a single `parser.ParsedData` then this can too - but for now emulate the same result
	if existingService == nil {
		return nil, nil
	}
	out := []parser.ParsedData{
		*existingService,
	}
	return &out, nil
}
