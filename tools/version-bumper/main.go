package main

import (
	"fmt"
	"log"
	"os"
	"path/filepath"

	"github.com/hashicorp/hcl/v2/hclsimple"
	"github.com/hashicorp/pandora/tools/sdk/config"
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
		var config config.Config
		err := hclsimple.DecodeFile(filePath, nil, &config)
		if err != nil {
			return fmt.Errorf("parsing: %+v", err)
		}

		if !onlyFormat {
			log.Printf("[DEBUG] Reticulating splines..")

			log.Printf("[DEBUG] Retrieving the list of Available Services..")
			availableServices, err := service.AvailableServices()
			if err != nil {
				return fmt.Errorf("retrieving a list of Available Services: %+v", err)
			}

			log.Printf("[DEBUG] Reconciling the list defined in the Config with the Available Services..")
			parsedConfig, err := reconcileWithAvailableServices(config, *availableServices)
			if err != nil {
				return fmt.Errorf("reconciling with available services: %+v", err)
			}
			config = *parsedConfig
		}

		log.Printf("[DEBUG] Writing new config..")
		if err := writeToFile(config, filePath); err != nil {
			return fmt.Errorf("writing updated config to file: %+v", err)
		}
		log.Printf("[DEBUG] Finished update of %q.", name)
	}

	return nil
}
