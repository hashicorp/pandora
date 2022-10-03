package main

import (
	"flag"
	"fmt"
	"log"
	"os"
	"path"
	"path/filepath"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-go-sdk/generator"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type GeneratorInput struct {
	apiServerEndpoint string
	outputDirectory   string
	serviceNamesRaw   string
	settings          generator.Settings
}

func main() {
	input := GeneratorInput{
		settings: generator.Settings{
			Transport: generator.AutoRest,
		},
	}

	f := flag.NewFlagSet("generator-go-sdk", flag.ExitOnError)
	f.StringVar(&input.apiServerEndpoint, "data-api", "http://localhost:5000", "-data-api=http://localhost:5000")
	f.StringVar(&input.outputDirectory, "output-dir", "", "-output-dir=../generated-sdk-dev")
	f.StringVar(&input.serviceNamesRaw, "services", "", "A list of comma separated Service named from the Data API to import")
	if err := f.Parse(os.Args[1:]); err != nil {
		log.Fatalf("parsing arguments: %+v", err)
	}

	if input.outputDirectory == "" {
		homeDir, _ := os.UserHomeDir()
		input.outputDirectory = filepath.Join(homeDir, "/Desktop/generated-sdk-dev")
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

	// resource manager items should be output into the folder ./resource-manager
	input.outputDirectory = path.Join(input.outputDirectory, "resource-manager")

	var loadedServices services.ResourceManagerServices
	servicesToLoad := strings.Split(input.serviceNamesRaw, ",")
	if input.serviceNamesRaw != "" && len(servicesToLoad) > 0 {
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
	generatorService := generator.NewServiceGenerator(input.settings)
	for serviceName, service := range loadedServices.Services {
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
					Source:          versionDetails.Details.Source,
				}
				log.Printf("[DEBUG] Generating Service %q / Version %q / Resource %q..", serviceName, versionNumber, resourceName)
				if err := generatorService.Generate(generatorData); err != nil {
					return fmt.Errorf("generating Service %q / Version %q / Resource %q: %+v", serviceName, versionNumber, resourceName, err)
				}
				log.Printf("[DEBUG] Generated Service %q / Version %q / Resource %q..", serviceName, versionNumber, resourceName)
			}

			// then output the Meta Client
			generatorData := generator.VersionInput{
				OutputDirectory: input.outputDirectory,
				ServiceName:     serviceName,
				VersionName:     versionNumber,
				Resources:       versionDetails.Resources,
				Source:          versionDetails.Details.Source,
			}
			log.Printf("[DEBUG] Generating Service %q / Version %q..", serviceName, versionNumber)
			if err := generatorService.GenerateForVersion(generatorData); err != nil {
				return fmt.Errorf("generating Service %q / Version %q: %+v", serviceName, versionNumber, err)
			}
			log.Printf("[DEBUG] Generated Service %q / Version %q..", serviceName, versionNumber)
		}
	}

	return nil
}
