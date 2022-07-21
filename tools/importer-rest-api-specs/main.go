package main

import (
	"flag"
	"log"
	"os"
	"strings"
	"time"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/pipeline"

	"github.com/hashicorp/go-hclog"
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
	input := pipeline.RunInput{
		SwaggerDirectory:         swaggerDirectory,
		ConfigFilePath:           resourceManagerConfig,
		TerraformDefinitionsPath: terraformDefinitionsPath,
		DataApiEndpoint:          dataApiEndpoint,
		JustOutputSegments:       justSegments,
		JustParseData:            justParse,
		OutputDirectory:          outputDirectory,
		Logger:                   logger,
	}
	if err := pipeline.Run(input); err != nil {
		log.Printf("Error: %+v", err)
		os.Exit(1)
		return
	}

	os.Exit(0)
}
