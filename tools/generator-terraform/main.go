package main

import (
	"flag"
	"fmt"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/datasource"
	"log"
	"os"
	"path/filepath"

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
	}

	return nil
}
