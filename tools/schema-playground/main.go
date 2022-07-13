package main

import (
	"fmt"
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/sdk/config/definitions"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type Input struct {
	apiServerEndpoint string
	providerPrefix    string
	configDirectory   string
}

func main() {
	if err := run(Input{
		apiServerEndpoint: "http://localhost:5000",
		configDirectory:   "../../config/resources/",
		providerPrefix:    "azurerm",
	}); err != nil {
		log.Printf("error: %+v", err)
		os.Exit(1)
		return
	}

	os.Exit(0)
}

func run(input Input) error {
	client := resourcemanager.NewClient(input.apiServerEndpoint)

	log.Printf("[DEBUG] Loading Config..")
	config, err := definitions.LoadFromDirectory(input.configDirectory)
	if err != nil {
		return fmt.Errorf("loading configs from %q: %+v", input.configDirectory, err)
	}

	log.Printf("[DEBUG] Retrieving Services from Data API..")
	services, err := services.GetResourceManagerServices(client)
	if err != nil {
		return fmt.Errorf("retrieving resource manager services: %+v", err)
	}

	log.Printf("[DEBUG] Finding Candidates from Services returned from the Data API..")
	candidates, err := findCandidates(*services)
	if err != nil {
		return fmt.Errorf("finding candidates for services: %+v", err)
	}

	log.Printf("[DEBUG] Processing Candidates..")
	for _, candidate := range *candidates {
		resourceDefinition := resourceDefinitionsForCandidate(*config, candidate)
		if resourceDefinition == nil {
			continue
		}

		log.Printf("[DEBUG] Processing %s..", candidate)
		if err := processSchemaForCandidate(candidate, *resourceDefinition); err != nil {
			return fmt.Errorf("processing schema for candidate %s: %+v", err)
		}
	}

	return nil
}

func resourceDefinitionsForCandidate(config definitions.Config, input CandidatesForService) *map[string]definitions.ResourceDefinition {
	service, ok := config.Services[input.ServiceName]
	if !ok {
		return nil
	}

	version, ok := service.ApiVersions[input.ApiVersion]
	if !ok {
		return nil
	}

	resource, ok := version.Packages[input.ResourceName]
	if !ok {
		return nil
	}

	return &resource.Definitions
}
