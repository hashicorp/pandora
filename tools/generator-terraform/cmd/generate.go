package cmd

import (
	"flag"
	"fmt"
	"log"
	"os"
	"path/filepath"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/datasource"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/definitions"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	resourceGenerator "github.com/hashicorp/pandora/tools/generator-terraform/generator/resource"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
	"github.com/mitchellh/cli"
)

var _ cli.Command = &GenerateCommand{}

func NewGenerateCommand() func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &GenerateCommand{}, nil
	}
}

type GenerateCommand struct {
	providerPrefix    string
	outputDirectory   string
	apiServerEndpoint string
	serviceNamesRaw   string
}

func (*GenerateCommand) Help() string {
	return strings.ReplaceAll(`Generates the Terraform Data Sources & Resources using the Data from the Data API

Flags:

* '--data-api=https://example.com'
  Specifies the path to the Data API.
* '--output-dir=../generated-tf-dev'
  Specifies the path where the generated files should be output
`, "'", "`")
}

func (i *GenerateCommand) Run(args []string) int {
	f := flag.NewFlagSet("generator-terraform", flag.ExitOnError)
	f.StringVar(&i.apiServerEndpoint, "data-api", "http://localhost:5000", "-data-api=http://localhost:5000")
	f.StringVar(&i.outputDirectory, "output-dir", "", "-output-dir=../generated-tf-dev")
	f.StringVar(&i.serviceNamesRaw, "services", "", "A list of comma separated Service named from the Data API to import")
	if err := f.Parse(args); err != nil {
		log.Fatalf("parsing arguments: %+v", err)
	}

	if i.outputDirectory == "" {
		homeDir, _ := os.UserHomeDir()
		i.outputDirectory = filepath.Join(homeDir, "/Desktop/generated-tf-dev")
	}

	if err := i.run(); err != nil {
		log.Printf("error: %+v", err)
		return 1
	}

	return 0
}

func (i *GenerateCommand) run() error {
	// ensure the output directory exists
	os.MkdirAll(i.outputDirectory, 0755)

	log.Printf("[DEBUG] Retrieving Services from Data API..")
	client := resourcemanager.NewClient(i.apiServerEndpoint)
	var loadedServices services.ResourceManagerServices
	servicesToLoad := strings.Split(i.serviceNamesRaw, ",")
	if i.serviceNamesRaw != "" && len(servicesToLoad) > 0 {
		log.Printf("[DEBUG] Loading the Services %q..", strings.Join(servicesToLoad, " / "))
		services, err := services.GetResourceManagerServicesByName(client, servicesToLoad)
		if err != nil {
			return fmt.Errorf("retrieving resource manager services: %+v", err)
		}
		loadedServices = *services
	} else {
		log.Printf("[DEBUG] Loading All Services..")
		services, err := services.GetResourceManagerServices(client)
		if err != nil {
			return fmt.Errorf("retrieving resource manager services: %+v", err)
		}
		loadedServices = *services
	}

	serviceInputs := make(map[string]models.ServiceInput)
	for serviceName, service := range loadedServices.Services {
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
				ProviderPrefix:     i.providerPrefix,
				ResourceLabel:      label,
				RootDirectory:      i.outputDirectory,
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
				ProviderPrefix:     i.providerPrefix,
				RootDirectory:      i.outputDirectory,
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
			ProviderPrefix:     i.providerPrefix,
			RootDirectory:      i.outputDirectory,
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
		ProviderPrefix: i.providerPrefix,
		RootDirectory:  i.outputDirectory,
		Services:       serviceInputs,
	}
	if err := definitions.DefinitionForServices(servicesInput); err != nil {
		return fmt.Errorf("generating auto-client for services: %+v", err)
	}

	return nil
}

func (*GenerateCommand) Synopsis() string {
	return "Generates the Terraform Data Sources & Resources"
}
