package main

import (
	"fmt"
	"log"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/differ"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/generator"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

func importService(input RunInput, swaggerGitSha string, dataApiEndpoint *string, debug bool) error {
	var errWrap = func(err error) error {
		log.Printf("❌ Service %q - Api Version %q", input.ServiceName, input.ApiVersion)
		log.Printf("     💥 Error: %+v", err)
		return err
	}

	if debug {
		log.Printf("[STAGE] Parsing Swagger Files..")
	}
	data, err := parseSwaggerFiles(input, debug)
	if err != nil {
		return errWrap(fmt.Errorf("parsing Swagger files: %+v", err))
	}
	if data != nil && len(*data) == 0 {
		log.Printf("😵 Service %q / Api Version %q contains no resources, skipping.", input.ServiceName, input.ApiVersion)
		return nil
	}

	if justParse {
		log.Printf("✅ Service %q - Api Version %q - Parsed Fine but skipping generation", input.ServiceName, input.ApiVersion)
		return nil
	}

	if dataApiEndpoint != nil {
		if debug {
			log.Printf("[DEBUG] Retrieving Current Schema from Data API..")
		}

		differ := differ.NewDiffer(*dataApiEndpoint)
		_, err := differ.RetrieveExistingService(input.ServiceName, input.ApiVersion)
		if err != nil {
			return fmt.Errorf("retrieving data for existing Service %q / Version %q from Data API: %+v", input.ServiceName, input.ApiVersion, err)
		}

		// TODO: handle this

	} else {
		log.Printf("[DEBUG] Skipping retrieving current schema from Data API..")
	}

	if debug {
		log.Printf("[STAGE] Updating the Output Revision ID to %q", swaggerGitSha)
	}
	if err := generator.OutputRevisionId(input.OutputDirectory, input.RootNamespace, swaggerGitSha); err != nil {
		return fmt.Errorf("outputting the Revision Id: %+v", err)
	}

	if debug {
		log.Printf("[STAGE] Generating Swagger Definitions..")
	}
	if err := generateServiceDefinitions(*data, input.OutputDirectory, input.RootNamespace, input.ResourceProvider, debug); err != nil {
		return errWrap(fmt.Errorf("generating Service Definitions: %+v", err))
	}

	if debug {
		log.Printf("[STAGE] Generating API Definitions..")
	}
	if err := generateApiVersions(*data, input.OutputDirectory, input.RootNamespace, input.ResourceProvider, debug); err != nil {
		return errWrap(fmt.Errorf("generating API Versions: %+v", err))
	}

	log.Printf("✅ Service %q - Api Version %q", input.ServiceName, input.ApiVersion)
	return nil
}

func parseSwaggerFiles(input RunInput, debug bool) (*[]parser.ParsedData, error) {
	// TODO: shouldn't this be returning a single `parser.ParsedData` here?
	parseResult, err := parser.LoadAndParseFiles(input.SwaggerDirectory, input.SwaggerFiles, input.ServiceName, input.ApiVersion, debug)
	if err != nil {
		return nil, fmt.Errorf("parsing files in %q: %+v", input.SwaggerDirectory, err)
	}

	return parseResult, nil
}
