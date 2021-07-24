package main

import (
	"fmt"
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/generator-go-sdk/generator"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type GeneratorInput struct {
	apiServerEndpoint string
	outputDirectory   string
	settings          generator.Settings
}

func main() {
	homeDir, _ := os.UserHomeDir()
	input := GeneratorInput{
		apiServerEndpoint: "http://localhost:5000",
		outputDirectory:   homeDir + "/Desktop/generated-sdk-dev",
		settings: generator.Settings{
			Transport: generator.AutoRest,
		},
	}
	if err := run(input); err != nil {
		log.Printf("error: %+v", err)
		os.Exit(1)
		return
	}

	os.Exit(0)
}

func run(input GeneratorInput) error {
	client := resourcemanager.NewClient(input.apiServerEndpoint)
	services, err := services.GetResourceManagerServices(client)
	if err != nil {
		return fmt.Errorf("retrieving resource manager services: %+v", err)
	}

	generatorService := generator.NewServiceGenerator(input.settings)
	for serviceName, service := range services.Services {
		log.Printf("[DEBUG] Service %q..", serviceName)
		if !service.Details.Generate {
			log.Printf("[DEBUG] .. is opted out of generation, skipping..")
			continue
		}

		for versionNumber, versionDetails := range service.Versions {
			log.Printf("[DEBUG]   Version %q", versionNumber)
			for resourceName, resourceDetails := range versionDetails.Resources {
				log.Printf("[DEBUG]      Resource %q..", resourceName)
				generatorData := generator.ServiceGeneratorInput{
					ServiceName:     serviceName,
					ServiceDetails:  service,
					VersionName:     versionNumber,
					VersionDetails:  versionDetails,
					ResourceName:    resourceName,
					ResourceDetails: resourceDetails,
					OutputDirectory: input.outputDirectory,
				}
				log.Printf("[DEBUG] Generating Service %q / Version %q / Resource %q..", serviceName, versionNumber, resourceName)
				if err := generatorService.Generate(generatorData); err != nil {
					return fmt.Errorf("generating Service %q / Version %q / Resource %q: %+v", serviceName, versionNumber, resourceName, err)
				}
				log.Printf("[DEBUG] Generated Service %q / Version %q / Resource %q..", serviceName, versionNumber, resourceName)
			}
		}
	}

	return nil
}
