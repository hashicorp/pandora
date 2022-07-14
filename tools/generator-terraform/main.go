package main

import (
	"flag"
	"fmt"
	"log"
	"os"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type GeneratorInput struct {
	apiServerEndpoint string
	outputDirectory   string
}

func main() {
	input := GeneratorInput{
		apiServerEndpoint: "",
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
	client := resourcemanager.NewClient(input.apiServerEndpoint)

	log.Printf("[DEBUG] Retrieving Services from Data API..")
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

			log.Printf("[DEBUG]   Version %q has %d Data Sources & %d Resources", versionNumber, len(versionDetails.Terraform.DataSources), len(versionDetails.Terraform.Resources))

			// TODO: generate the Terraform side of this
		}
	}

	return nil
}
