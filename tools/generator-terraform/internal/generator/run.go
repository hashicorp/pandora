// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"sort"

	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/definitions"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
	resourceGenerator "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/resource"
	"github.com/hashicorp/pandora/tools/generator-terraform/internal/logging"
)

func RunLegacy(input v1.LoadAllDataResult, providerPrefix, outputDirectory string) error {
	serviceInputs := make(map[string]generatorModels.ServiceInput)
	for serviceName, serviceDetails := range input.Services {
		logging.Log.Debug(fmt.Sprintf("Service %q..", serviceName))
		if !serviceDetails.Generate {
			logging.Log.Debug(" .. is opted out of generation, skipping..")
			continue
		}

		if serviceDetails.TerraformDefinition == nil {
			logging.Log.Debug(fmt.Sprintf("TerraformDefinition is nil for Service %q", serviceName))
			continue
		}

		if len(serviceDetails.TerraformDefinition.Resources) == 0 {
			logging.Log.Debug(fmt.Sprintf(".. has no Terraform Resources, skipping.."))
			continue
		}

		// Build the intermediate models used by the Terraform Generator
		terraformResources, err := buildTerraformResourcesForService(serviceDetails.TerraformDefinition.Resources, serviceDetails, serviceName, providerPrefix, outputDirectory)
		if err != nil {
			return fmt.Errorf("building intermediate models: %+v", err)
		}

		// Then build each of the Terraform Resources
		for resourceLabel, resourceDefinition := range *terraformResources {
			if err := resourceGenerator.Resource(resourceDefinition); err != nil {
				return fmt.Errorf("generating definitions for Resource %q (Service %q / API Version %q): %+v", resourceLabel, serviceName, resourceDefinition.SdkApiVersion, err)
			}
		}

		resourceToApiVersion := make(map[string]string)
		categories := make(map[string]struct{})
		resourceNames := make([]string, 0)
		for _, resource := range serviceDetails.TerraformDefinition.Resources {
			categories[resource.Documentation.Category] = struct{}{}
			resourceNames = append(resourceNames, resource.ResourceName)
			resourceToApiVersion[resource.ResourceName] = resource.APIVersion
		}

		categoryNames := make([]string, 0)
		for k := range categories {
			categoryNames = append(categoryNames, k)
		}
		sort.Strings(categoryNames)
		sort.Strings(resourceNames)

		resourceToApiVersionSorted := make(map[string]string, 0)
		for _, resource := range resourceNames {
			resourceToApiVersionSorted[resource] = resourceToApiVersion[resource]
		}

		serviceInput := generatorModels.ServiceInput{
			CategoryNames:        categoryNames,
			ProviderPrefix:       providerPrefix,
			ResourceToApiVersion: resourceToApiVersionSorted,
			RootDirectory:        outputDirectory,
			SdkServiceName:       serviceName,
			ServiceDisplayName:   serviceName, // TODO: add to API?
			ServicePackageName:   serviceDetails.TerraformDefinition.TerraformPackageName,
		}
		serviceInputs[serviceName] = serviceInput
		if err := definitions.ForService(serviceInput); err != nil {
			return fmt.Errorf("generating definitions for Service %q: %+v", serviceName, err)
		}
	}

	servicesInput := generatorModels.ServicesInput{
		ProviderPrefix: providerPrefix,
		RootDirectory:  outputDirectory,
		Services:       serviceInputs,
	}
	if err := definitions.DefinitionForServices(servicesInput); err != nil {
		return fmt.Errorf("generating auto-client for services: %+v", err)
	}

	return nil
}

func buildTerraformResourcesForService(input map[string]models.TerraformResourceDefinition, service models.Service, serviceName, providerPrefix, outputDirectory string) (*map[string]generatorModels.ResourceInput, error) {
	output := make(map[string]generatorModels.ResourceInput)

	for resourceLabel, resourceDefinition := range input {
		if !resourceDefinition.Generate {
			logging.Log.Debug(fmt.Sprintf("Resource %q has generation disabled - skipping", resourceLabel))
			continue
		}

		versionDetails, ok := service.APIVersions[resourceDefinition.APIVersion]
		if !ok {
			return nil, fmt.Errorf("couldn't find API Version %q for Terraform Resource %q (Service %q)", resourceDefinition.APIVersion, resourceLabel, serviceName)
		}

		resource, ok := versionDetails.Resources[resourceDefinition.APIResource]
		if !ok {
			return nil, fmt.Errorf("couldn't find API Resource %q for Terraform Resource %q (API Version %q / Service %q)", resourceDefinition.APIResource, resourceLabel, resourceDefinition.APIVersion, serviceName)
		}

		logging.Log.Debug(fmt.Sprintf("Processing Resource %q..", resourceLabel))
		output[resourceLabel] = generatorModels.ResourceInput{
			// Provider related
			ProviderPrefix:     providerPrefix,
			RootDirectory:      outputDirectory,
			ServicePackageName: service.TerraformDefinition.TerraformPackageName,
			ServiceName:        serviceName,

			// Resource Related
			Details:          resourceDefinition,
			ResourceLabel:    resourceLabel,
			ResourceTypeName: resourceDefinition.ResourceName,

			// Sdk Related
			SdkApiVersion:   resourceDefinition.APIVersion,
			SdkResourceName: resourceDefinition.APIResource,
			SdkServiceName:  serviceName,

			// Data
			Constants:       resource.Constants,
			Models:          resource.Models,
			Operations:      resource.Operations,
			ResourceIds:     resource.ResourceIDs,
			SchemaModelName: resourceDefinition.SchemaModelName,
			SchemaModels:    resourceDefinition.SchemaModels,
		}
	}

	return &output, nil
}
