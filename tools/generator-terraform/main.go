package main

import (
	"flag"
	"fmt"
	"log"
	"os"
	"path/filepath"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator"

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
	services, err := services.GetResourceManagerServices(client)
	if err != nil {
		return fmt.Errorf("retrieving resource manager services: %+v", err)
	}

	for serviceName, service := range services.Services {
		log.Printf("[DEBUG] Service %q..", serviceName)
		if !service.Details.Generate {
			log.Printf("[DEBUG] .. is opted out of generation, skipping..")
			continue
		}

		for versionNumber, versionDetails := range service.Versions {
			if len(versionDetails.Terraform.DataSources) == 0 && len(versionDetails.Terraform.Resources) == 0 {
				log.Printf("[DEBUG] .. has no Data Sources/Resources, skipping..")
				continue
			}

			for label, _ := range versionDetails.Terraform.DataSources {
				// TODO: conditional generation

				log.Printf("[DEBUG] Processing Data Source %q..", label)
				dataSourceInput := generator.DataSourceInput{
					ProviderPrefix:     input.providerPrefix,
					ResourceLabel:      label,
					RootDirectory:      input.outputDirectory,
					ServicePackageName: "example", // TODO: needs to be returned from the API
				}
				if err := generator.DataSource(dataSourceInput); err != nil {
					return fmt.Errorf("generating for Data Source %q (Service %q / API Version %q): %+v", label, serviceName, versionNumber, err)
				}
			}

			for label, details := range versionDetails.Terraform.Resources {
				if !details.Generate {
					log.Printf("[DEBUG] Resource %q has generation disabled - skipping", label)
					continue
				}

				resource, ok := versionDetails.Resources[details.Resource]
				if !ok {
					return fmt.Errorf("couldn't find API Resource %q for Terraform Resource %q (API Version %q / Service %q)", details.Resource, label, versionNumber, serviceName)
				}

				log.Printf("[DEBUG] Processing Resource %q..", label)
				resourceInput := generator.ResourceInput{
					// Provider related
					ProviderPrefix:     input.providerPrefix,
					RootDirectory:      input.outputDirectory,
					ServicePackageName: service.TerraformPackageName,

					// Resource Related
					Details:          details,
					ResourceLabel:    label,
					ResourceTypeName: details.ResourceName,

					// Sdk Related
					SdkApiVersion:   versionNumber,
					SdkResourceName: strings.ToLower(details.Resource),
					SdkServiceName:  strings.ToLower(serviceName),

					// Data
					ResourceIds: resource.Schema.ResourceIds,
				}
				if err := generator.Resource(resourceInput); err != nil {
					return fmt.Errorf("generating for Resource %q (Service %q / API Version %q): %+v", label, serviceName, versionNumber, err)
				}
			}
		}
	}

	return nil
}
