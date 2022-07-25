package main

import (
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

func main() {
	if err := run("http://localhost:5000"); err != nil {
		log.Printf("error: %+v", err)
		os.Exit(1)
		return
	}

	os.Exit(0)
}

func run(endpoint string) error {
	client := resourcemanager.NewClient(endpoint)

	services, err := services.GetResourceManagerServices(client)
	if err != nil {
		return err
	}

	for name, service := range services.Services {
		log.Printf(name)
		if service.Details.Generate {
			log.Printf("Should be generated!")
		}

		for versionNumber, versionDetails := range service.Versions {
			log.Printf(versionNumber)

			for name, id := range versionDetails.Details.Resources {
				log.Printf(" - %s - %s", name, id)
			}
			for resourceName, resourceDetails := range versionDetails.Resources {
				log.Printf("Operations for %q..", resourceName)

				for operationName, operationDetails := range resourceDetails.Operations.Operations {
					log.Printf(" - %s is a %s", operationName, operationDetails.Method)
				}
				log.Printf("  Constants:")
				for constantName, constantDetails := range resourceDetails.Schema.Constants {
					log.Printf("    - %q has %d values", constantName, len(constantDetails.Values))
				}

				log.Printf("  Models:")
				for modelName, modelDetails := range resourceDetails.Schema.Models {
					log.Printf("    - %q has %d fields", modelName, len(modelDetails.Fields))
				}
			}
		}
	}

	return nil
}
