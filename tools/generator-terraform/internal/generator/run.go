package generator

import (
	"fmt"
	"log"
	"sort"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/datasource"
	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/definitions"
	models2 "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
	resourceGenerator "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/resource"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

func RunLegacy(input services.ResourceManagerServices, providerPrefix, outputDirectory string) error {
	serviceInputs := make(map[string]models2.ServiceInput)
	for serviceName, service := range input.Services {
		log.Printf("[DEBUG] Service %q..", serviceName)
		if !service.Details.Generate {
			log.Printf("[DEBUG] .. is opted out of generation, skipping..")
			continue
		}

		if service.TerraformPackageName == nil {
			log.Printf("[INFO] TerraformPackageName is nil for Service %q", serviceName)
			continue
		}

		if len(service.Terraform.DataSources) == 0 && len(service.Terraform.Resources) == 0 {
			log.Printf("[DEBUG] .. has no Data Sources/Resources, skipping..")
			continue
		}

		for label, details := range service.Terraform.DataSources {
			if !details.Generate {
				log.Printf("[DEBUG] Data Source %q has generation disabled - skipping", label)
				continue
			}

			log.Printf("[DEBUG] Processing Data Source %q..", label)
			dataSourceInput := models2.DataSourceInput{
				ApiVersion:         details.ApiVersion,
				ProviderPrefix:     providerPrefix,
				ResourceLabel:      label,
				RootDirectory:      outputDirectory,
				ServicePackageName: *service.TerraformPackageName,
			}
			if err := datasource.DataSource(dataSourceInput); err != nil {
				return fmt.Errorf("generating for Data Source %q (Service %q / API Version %q): %+v", label, serviceName, details.ApiVersion, err)
			}
		}

		for label, details := range service.Terraform.Resources {
			if !details.Generate {
				log.Printf("[DEBUG] Resource %q has generation disabled - skipping", label)
				continue
			}

			versionDetails, ok := service.Versions[details.ApiVersion]
			if !ok {
				return fmt.Errorf("couldn't find API Version %q for Terraform Resource %q (Service %q)", details.ApiVersion, label, serviceName)
			}

			resource, ok := versionDetails.Resources[details.Resource]
			if !ok {
				return fmt.Errorf("couldn't find API Resource %q for Terraform Resource %q (API Version %q / Service %q)", details.Resource, label, details.ApiVersion, serviceName)
			}

			log.Printf("[DEBUG] Processing Resource %q..", label)
			resourceInput := models2.ResourceInput{
				// Provider related
				ProviderPrefix:     providerPrefix,
				RootDirectory:      outputDirectory,
				ServicePackageName: *service.TerraformPackageName,
				ServiceName:        serviceName,

				// Resource Related
				Details:          details,
				ResourceLabel:    label,
				ResourceTypeName: details.ResourceName,

				// Sdk Related
				SdkApiVersion:   details.ApiVersion,
				SdkResourceName: details.Resource,
				SdkServiceName:  serviceName,

				// Data
				Constants:       resource.Schema.Constants,
				Models:          resource.Schema.Models,
				Operations:      resource.Operations.Operations,
				ResourceIds:     resource.Schema.ResourceIds,
				SchemaModelName: details.SchemaModelName,
				SchemaModels:    details.SchemaModels,
			}
			if err := resourceGenerator.Resource(resourceInput); err != nil {
				return fmt.Errorf("generating for Resource %q (Service %q / API Version %q): %+v", label, serviceName, details.ApiVersion, err)
			}
		}

		resourceToApiVersion := make(map[string]string)
		categories := make(map[string]struct{})
		dataSourceNames := make([]string, 0)
		resourceNames := make([]string, 0)
		for _, resource := range service.Terraform.Resources {
			categories[resource.Documentation.Category] = struct{}{}
			resourceNames = append(resourceNames, resource.ResourceName)
			resourceToApiVersion[resource.ResourceName] = resource.ApiVersion
		}

		categoryNames := make([]string, 0)
		for k := range categories {
			categoryNames = append(categoryNames, k)
		}
		sort.Strings(categoryNames)
		sort.Strings(dataSourceNames)
		sort.Strings(resourceNames)

		resourceToApiVersionSorted := make(map[string]string, 0)
		for _, resource := range resourceNames {
			resourceToApiVersionSorted[resource] = resourceToApiVersion[resource]
		}

		serviceInput := models2.ServiceInput{
			CategoryNames:        categoryNames,
			DataSourceNames:      dataSourceNames,
			ProviderPrefix:       providerPrefix,
			ResourceToApiVersion: resourceToApiVersionSorted,
			RootDirectory:        outputDirectory,
			SdkServiceName:       serviceName,
			ServiceDisplayName:   serviceName, // TODO: add to API?
			ServicePackageName:   *service.TerraformPackageName,
		}
		serviceInputs[serviceName] = serviceInput
		if err := definitions.ForService(serviceInput); err != nil {
			return fmt.Errorf("generating definitions for Service %q: %+v", serviceName, err)
		}
	}

	servicesInput := models2.ServicesInput{
		ProviderPrefix: providerPrefix,
		RootDirectory:  outputDirectory,
		Services:       serviceInputs,
	}
	if err := definitions.DefinitionForServices(servicesInput); err != nil {
		return fmt.Errorf("generating auto-client for services: %+v", err)
	}

	return nil
}
