package cmd

import (
	"flag"
	"fmt"
	"log"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/resources"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/schema"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
	"github.com/mitchellh/cli"
)

var _ cli.Command = SchemaCommand{}

func NewSchemaCommand() func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return SchemaCommand{}, nil
	}
}

type SchemaCommand struct {
}

func (s SchemaCommand) Help() string {
	return "specify -services=Compute,Resource to limit to just that or don't for everything, you do you."
}

func (s SchemaCommand) Run(args []string) int {
	var serviceNamesRaw string

	f := flag.NewFlagSet("importer-rest-api-specs", flag.ExitOnError)
	f.StringVar(&serviceNamesRaw, "services", "", "A list of comma separated Service named from the Data API to import")
	f.Parse(args)

	var serviceNames []string
	if serviceNamesRaw != "" {
		serviceNames = strings.Split(serviceNamesRaw, ",")
	}

	if err := run(Input{
		apiServerEndpoint: "http://localhost:5000",
		configDirectory:   "../../config/resources/",
		providerPrefix:    "azurerm",
		services:          serviceNames,
	}); err != nil {
		log.Printf("error: %+v", err)
		return 1
	}

	return 0
}

func (s SchemaCommand) Synopsis() string {
	return "Specify -services=Compute,Resource to limit to just that or don't for everything, you do you."
}

type Input struct {
	apiServerEndpoint string
	providerPrefix    string
	configDirectory   string
	services          []string
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
	var resourceManagerServices *services.ResourceManagerServices
	if len(input.services) > 0 {
		logger.Info(fmt.Sprintf("Loading only the Services %q", strings.Join(input.services, ", ")))
		resourceManagerServices, err = services.GetResourceManagerServicesByName(client, input.services)
	} else {
		logger.Info("Loading all services.. this may take a while..")
		resourceManagerServices, err = services.GetResourceManagerServices(client)
	}

	if err != nil {
		return fmt.Errorf("retrieving resource manager services: %+v", err)
	}

	for serviceName, serviceDetails := range resourceManagerServices.Services {
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
				candidates, err := resources.FindCandidates(apiResourceDetails, terraformDefinitionsForResource.Definitions, apiResource, logger)
				if err != nil {
					return fmt.Errorf("finding Candidates: %+v", err)
				}
				builder := schema.NewBuilder(apiResourceDetails.Schema.Constants, apiResourceDetails.Schema.Models, apiResourceDetails.Operations.Operations, apiResourceDetails.Schema.ResourceIds)

				for dataSourceName, dataSource := range candidates.DataSources {
					// TODO: stuff n things
					logger.Trace(fmt.Sprintf("Found Data Source %q: %+v", dataSourceName, dataSource))
				}

				for resourceName, resource := range candidates.Resources {
					logger.Trace(fmt.Sprintf("Found Resource %q..", resourceName))
					schemaDefinition, mappings, err := builder.Build(resource, logger.Named(fmt.Sprintf("Resource %q", resourceName)))
					if err != nil {
						return fmt.Errorf("processing schema for candidate %s: %+v", resourceName, err)
					}

					logger.Trace(fmt.Sprintf("Models for %q..", resourceName))

					for modelName, modelDetails := range *schemaDefinition {
						logger.Trace(fmt.Sprintf("Model %q", modelName))
						for fieldName, fieldDetails := range modelDetails.Fields {
							logger.Trace(fmt.Sprintf("Field %q: %+v", fieldName, fieldDetails))
						}
					}

					log.Printf(`Mappings:
	* %d Resource ID Mappings
	* %d Field Mappings
`, len(mappings.ResourceId), len(mappings.Fields))
				}
			}
		}
	}
	return nil
}
