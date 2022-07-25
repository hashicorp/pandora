package main

import (
	"fmt"
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/schema-playground/schema"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/resources"

	"github.com/hashicorp/pandora/tools/sdk/config/definitions"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type Input struct {
	apiServerEndpoint string
	providerPrefix    string
	configDirectory   string
}

func main() {
	if err := run(Input{
		apiServerEndpoint: "http://localhost:5000",
		configDirectory:   "../../config/resources/",
		providerPrefix:    "azurerm",
	}); err != nil {
		log.Printf("error: %+v", err)
		os.Exit(1)
		return
	}

	os.Exit(0)
}

func run(input Input) error {
	logger := hclog.New(hclog.DefaultOptions)

	client := resourcemanager.NewClient(input.apiServerEndpoint)

	logger.Trace("Loading Config..")
	terraformDefinitions, err := definitions.LoadFromDirectory(input.configDirectory)
	if err != nil {
		return fmt.Errorf("loading configs from %q: %+v", input.configDirectory, err)
	}

	logger.Trace("Retrieving Services from Data API..")
	services, err := services.GetResourceManagerServices(client)
	if err != nil {
		return fmt.Errorf("retrieving resource manager services: %+v", err)
	}

	for serviceName, serviceDetails := range services.Services {
		terraformDefinitionsForService, ok := terraformDefinitions.Services[serviceName]
		if !ok {
			logger.Trace(fmt.Sprintf("No Terraform Definitions for Service %q - skipping", serviceName))
			continue
		}

		for apiVersion, versionDetails := range serviceDetails.Versions {
			logger = logger.Named(fmt.Sprintf("Service %q / API Version %q", serviceName, apiVersion))
			terraformDefinitionsForVersion, ok := terraformDefinitionsForService.ApiVersions[apiVersion]
			if !ok {
				logger.Trace(fmt.Sprintf("No Terraform Definitions for Service %q / API Version %q - skipping", serviceName, apiVersion))
				continue
			}

			for apiResource, apiResourceDetails := range versionDetails.Resources {
				terraformDefinitionsForResource, ok := terraformDefinitionsForVersion.Packages[apiResource]
				if !ok {
					logger.Trace(fmt.Sprintf("No Terraform Definitions for Service %q / API Version %q / Resource %q - skipping", serviceName, apiVersion, apiResource))
					continue
				}

				logger.Trace("Finding Candidates from Services returned from the Data API..")
				candidates := resources.FindCandidates(apiResourceDetails, terraformDefinitionsForResource.Definitions, apiResource, logger)
				builder := schema.NewBuilder(apiResourceDetails.Schema.Constants, apiResourceDetails.Schema.Models, apiResourceDetails.Operations.Operations, apiResourceDetails.Schema.ResourceIds)

				for dataSourceName, dataSource := range candidates.DataSources {
					// TODO: stuff n things
					logger.Trace(fmt.Sprintf("Found Data Source %q: %+v", dataSourceName, dataSource))
				}

				for resourceName, resource := range candidates.Resources {
					logger.Trace(fmt.Sprintf("Found Resource %q..", resourceName))
					schemaDefinition, err := builder.Build(resource, logger.Named(fmt.Sprintf("Resource %q", resourceName)))
					if err != nil {
						return fmt.Errorf("processing schema for candidate %s: %+v", resourceName, err)
					}

					logger.Trace(fmt.Sprintf("Schema for %q", resourceName))
					for fieldName, fieldDetails := range schemaDefinition.Fields {
						logger.Trace(fmt.Sprintf("Field %q: %+v", fieldName, fieldDetails))
					}
				}
			}
		}
	}

	return nil
}
