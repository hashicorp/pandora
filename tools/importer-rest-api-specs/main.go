package main

import (
	"flag"
	"fmt"
	"log"
	"os"
	"strings"
	"sync"

	git "github.com/go-git/go-git/v5"
)

const (
	outputDirectory       = "../../data/"
	swaggerDirectory      = "../../swagger"
	resourceManagerConfig = "../../config/resource-manager.hcl"
	permissions           = os.FileMode(0755)

	// only useful for testing without outputting everything
	justParse = false
)

func main() {
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	var dataApiEndpointVar string
	justSegments := false

	f := flag.NewFlagSet("importer-rest-api-specs", flag.ExitOnError)
	f.StringVar(&dataApiEndpointVar, "data-api", "", "The Data API Endpoint (e.g. --data-api=http://localhost:5000")
	f.BoolVar(&justSegments, "just-segments", false, "Should only the Segments be output?")
	f.Parse(os.Args[1:])

	var dataApiEndpoint *string
	if dataApiEndpointVar == "" {
		log.Printf("[DEBUG] No Data API Endpoint is specified - using local-only mode")
		dataApiEndpoint = nil
	} else {
		log.Printf("[DEBUG] Using Data API Endpoint %q", dataApiEndpointVar)
		dataApiEndpoint = &dataApiEndpointVar
	}

	debug := strings.TrimSpace(os.Getenv("DEBUG")) != ""
	if err := run(swaggerDirectory, resourceManagerConfig, dataApiEndpoint, justSegments, debug); err != nil {
		log.Printf("Error: %+v", err)
		os.Exit(1)
		return
	}

	os.Exit(0)
}

func run(swaggerDirectory, configFilePath string, dataApiEndpoint *string, justSegments, debug bool) error {
	if justSegments {
		return parseAndOutputSegments(swaggerDirectory, debug)
	}

	return runImporter(configFilePath, dataApiEndpoint, debug)
}

func runImporter(configFilePath string, dataApiEndpoint *string, debug bool) error {
	input, err := GenerationData(configFilePath, swaggerDirectory, false)
	if err != nil {
		return fmt.Errorf("loading data: %+v", err)
	}

	swaggerGitSha, err := determineGitSha(swaggerDirectory)
	if err != nil {
		return fmt.Errorf("determining Git SHA at %q: %+v", swaggerDirectory, err)
	}

	var wg sync.WaitGroup
	for _, v := range *input {
		wg.Add(1)
		go func(v RunInput) {
			if err := importService(v, *swaggerGitSha, dataApiEndpoint, debug); err != nil {
				log.Printf("importing Service %q / Version %q: %+v", v.ServiceName, v.ApiVersion, err)
				wg.Done()
				return
			}

			wg.Done()
		}(v)
	}

	wg.Wait()
	return nil
}

func determineGitSha(repositoryPath string) (*string, error) {
	repo, err := git.PlainOpen(repositoryPath)
	if err != nil {
		return nil, err
	}

	ref, err := repo.Head()
	if err != nil {
		return nil, err
	}

	commit := ref.Hash().String()
	log.Printf("[DEBUG] Swagger Repository Commit SHA is %q", commit)
	return &commit, nil
}
