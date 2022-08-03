package main

import (
	"flag"
	"fmt"
	"log"
	"os"
	"path/filepath"
	"sort"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/definitions"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/datasource"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	resourceGenerator "github.com/hashicorp/pandora/tools/generator-terraform/generator/resource"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type GeneratorInput struct {
	apiServerEndpoint string
	outputDirectory   string
	providerPrefix    string
}

// TODO: split into a pipeline, logging.

func main() {
	input := GeneratorInput{
		apiServerEndpoint: "",
		providerPrefix:    "azurerm",
		outputDirectory:   "",
	}

	f := flag.NewFlagSet("generator-terraform", flag.ExitOnError)
	f.StringVar(&input.apiServerEndpoint, "data-api", "http://localhost:5000", "-data-api=http://localhost:5000")
	f.StringVar(&input.outputDirectory, "output-dir", "", "-output-dir=../generated-tf-dev")
	if err := f.Parse(os.Args[1:]); err != nil {
		log.Fatalf("parsing arguments: %+v", err)
	}

	if input.outputDirectory == "" {
		homeDir, _ := os.UserHomeDir()
		input.outputDirectory = filepath.Join(homeDir, "/Desktop/generated-tf-dev")
	}

	if err := run(input); err != nil {
		log.Printf("error: %+v", err)
		os.Exit(1)
		return
	}

	os.Exit(0)
}

func run(input GeneratorInput) error {
	// ensure the output directory exists
	os.MkdirAll(input.outputDirectory, 0755)

	log.Printf("[DEBUG] Retrieving Services from Data API..")
	client := resourcemanager.NewClient(input.apiServerEndpoint)
	servicesToLoad := []string{
		"Compute",
		"Resources",
	}
	services, err := services.GetResourceManagerServicesByName(client, servicesToLoad)
	if err != nil {
		return fmt.Errorf("retrieving resource manager services: %+v", err)
	}

	serviceInputs := make(map[string]models.ServiceInput)
	for serviceName, service := range services.Services {
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
			dataSourceInput := models.DataSourceInput{
				ApiVersion:         details.ApiVersion,
				ProviderPrefix:     input.providerPrefix,
				ResourceLabel:      label,
				RootDirectory:      input.outputDirectory,
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
			resourceInput := models.ResourceInput{
				// Provider related
				ProviderPrefix:     input.providerPrefix,
				RootDirectory:      input.outputDirectory,
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

		// NOTE: intentional limitation, at this time we only support 1 API Version per Service
		apiVersion := ""
		categories := make(map[string]struct{})
		dataSourceNames := make([]string, 0)
		resourceNames := make([]string, 0)
		for _, dataSource := range service.Terraform.DataSources {
			// TODO: append categories and name - missing from API
			//dataSourceNames = append(dataSourceNames, dataSource.SingularDetails.ResourceName)

			if apiVersion == "" {
				apiVersion = dataSource.ApiVersion
				continue
			}

			if apiVersion != dataSource.ApiVersion {
				return fmt.Errorf("internal-error: multiple API versions detected for Service %q and %q", dataSource.ApiVersion, apiVersion)
			}
		}
		for _, resource := range service.Terraform.Resources {
			categories[resource.Documentation.Category] = struct{}{}
			resourceNames = append(resourceNames, resource.ResourceName)

			if apiVersion == "" {
				apiVersion = resource.ApiVersion
				continue
			}

			if apiVersion != resource.ApiVersion {
				return fmt.Errorf("internal-error: multiple API versions detected for Service %q and %q", resource.ApiVersion, apiVersion)
			}
		}

		categoryNames := make([]string, 0)
		for k := range categories {
			categoryNames = append(categoryNames, k)
		}
		sort.Strings(categoryNames)
		sort.Strings(dataSourceNames)
		sort.Strings(resourceNames)

		serviceInput := models.ServiceInput{
			ApiVersion:         apiVersion,
			CategoryNames:      categoryNames,
			DataSourceNames:    dataSourceNames,
			RootDirectory:      input.outputDirectory,
			ResourceNames:      resourceNames,
			SdkServiceName:     serviceName,
			ServiceDisplayName: serviceName, // TODO: add to API?
			ServicePackageName: *service.TerraformPackageName,
		}
		serviceInputs[serviceName] = serviceInput
		if err := definitions.ForService(serviceInput); err != nil {
			return fmt.Errorf("generating definitions for Service %q: %+v", serviceName, err)
		}
	}

	servicesInput := models.ServicesInput{
		ProviderPrefix: input.providerPrefix,
		RootDirectory:  input.outputDirectory,
		Services:       serviceInputs,
	}
	if err := definitions.DefinitionForServices(servicesInput); err != nil {
		return fmt.Errorf("generating auto-client for services: %+v", err)
	}

	return nil
}
