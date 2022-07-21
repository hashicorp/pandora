package main

import (
	"flag"
	"fmt"
	"log"
	"os"
	"strings"
	"sync"
	"time"

	"github.com/go-git/go-git/v5"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

const (
	outputDirectory          = "../../data/"
	swaggerDirectory         = "../../swagger"
	resourceManagerConfig    = "../../config/resource-manager.hcl"
	terraformDefinitionsPath = "../../config/resources/"

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

	logger := hclog.New(&hclog.LoggerOptions{
		Level:  hclog.DefaultLevel,
		Output: hclog.DefaultOutput,
		TimeFn: time.Now,
	})
	if strings.TrimSpace(os.Getenv("DEBUG")) != "" {
		logger.SetLevel(hclog.Trace)
	}
	if err := run(swaggerDirectory, resourceManagerConfig, terraformDefinitionsPath, dataApiEndpoint, justSegments, logger); err != nil {
		log.Printf("Error: %+v", err)
		os.Exit(1)
		return
	}

	os.Exit(0)
}

func run(swaggerDirectory, configFilePath, terraformDefinitionsPath string, dataApiEndpoint *string, justSegments bool, logger hclog.Logger) error {
	if justSegments {
		return parseAndOutputSegments(swaggerDirectory, logger)
	}

	return runImporter(configFilePath, terraformDefinitionsPath, dataApiEndpoint, logger)
}

func runImporter(configFilePath, terraformDefinitionsPath string, dataApiEndpoint *string, logger hclog.Logger) error {
	resources, err := definitions.LoadFromDirectory(terraformDefinitionsPath)
	if err != nil {
		return fmt.Errorf("loading terraform definitions from %q: %+v", terraformDefinitionsPath, err)
	}

	input, err := GenerationData(configFilePath, swaggerDirectory, *resources, logger)
	if err != nil {
		return fmt.Errorf("loading data: %+v", err)
	}

	swaggerGitSha, err := determineGitSha(swaggerDirectory, logger)
	if err != nil {
		return fmt.Errorf("determining Git SHA at %q: %+v", swaggerDirectory, err)
	}

	var wg sync.WaitGroup
	for _, v := range *input {
		wg.Add(1)
		go func(v RunInput) {
			if err := importService(v, *swaggerGitSha, dataApiEndpoint, logger); err != nil {
				log.Printf("importing Service %q / Version %q: %+v", v.ServiceName, v.ApiVersion, err)
				wg.Done()
				os.Exit(1)
				return
			}

			wg.Done()
		}(v)
	}

	wg.Wait()
	return nil
}

func determineGitSha(repositoryPath string, logger hclog.Logger) (*string, error) {
	repo, err := git.PlainOpen(repositoryPath)
	if err != nil {
		return nil, err
	}

	ref, err := repo.Head()
	if err != nil {
		return nil, err
	}

	commit := ref.Hash().String()
	logger.Debug(fmt.Sprintf("Swagger Repository Commit SHA is %q", commit))
	return &commit, nil
}
