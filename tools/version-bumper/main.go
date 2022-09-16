package main

import (
	"fmt"
	"log"
	"os"
	"path/filepath"
	"regexp"

	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

const onlyFormat = true
const onlyUpdateExistingServices = true

func main() {
	directory := "../../config"

	if err := run(directory); err != nil {
		log.Printf("ERROR: %+v", err)
		os.Exit(1)
		return
	}

	os.Exit(0)
}

func run(directory string) error {
	servicesToUpdate := map[string]ServiceLocator{
		// TODO: active-directory / data-plane in time
		"resource-manager": ResourceManagerService{
			swaggerDirectory: "../../swagger",
		},
	}
	for name, service := range servicesToUpdate {
		log.Printf("[DEBUG] Starting update of %q..", name)
		filePath := filepath.Join(directory, fmt.Sprintf("%s.hcl", name))

		log.Printf("[DEBUG] Decoding config at %q..", filePath)
		config, err := services.LoadFromFile(filePath)
		if err != nil {
			return err
		}

		if !onlyFormat {
			log.Printf("[DEBUG] Reticulating splines..")

			log.Printf("[DEBUG] Retrieving the list of Available Services..")
			availableServices, err := service.AvailableServices()
			if err != nil {
				return fmt.Errorf("retrieving a list of Available Services: %+v", err)
			}

			log.Printf("[DEBUG] Reconciling the list defined in the Config with the Available Services..")
			parsedConfig, err := reconcileWithAvailableServices(*config, *availableServices)
			if err != nil {
				return fmt.Errorf("reconciling with available services: %+v", err)
			}
			config = parsedConfig
		}

		log.Printf("[DEBUG] Validating config..")
		nameRegex, err := regexp.Compile("^[A-Z]{1}[A-Za-z0-9_]{1,}$")
		if err != nil {
			return fmt.Errorf("compiling regex: %+v", err)
		}
		for _, service := range config.Services {
			if !nameRegex.MatchString(service.Name) {
				return fmt.Errorf("name wasn't valid for %q - must contain only alphanumeric characters and underscores", service.Name)
			}
		}

		log.Printf("[DEBUG] Writing new config..")
		if err := writeToFile(*config, filePath); err != nil {
			return fmt.Errorf("writing updated config to file: %+v", err)
		}
		log.Printf("[DEBUG] Finished update of %q.", name)
	}

	return nil
}
