package main

import (
	"fmt"
	"log"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigenerator"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/resources"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/differ"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
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
	if data == nil {
		log.Printf("😵 Service %q / Api Version %q contains no resources, skipping.", input.ServiceName, input.ApiVersion)
		return nil
	}

	if input.TerraformServiceDefinition != nil {
		data, err = identifyCandidateTerraformResources(data, *input.TerraformServiceDefinition)
		if err != nil {
			return fmt.Errorf("identifying Terraform Candidates: %+v", err)
		}
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
		existingApiDefinitions, err := differ.RetrieveExistingService(input.ServiceName, input.ApiVersion)
		if err != nil {
			return fmt.Errorf("retrieving data for existing Service %q / Version %q from Data API: %+v", input.ServiceName, input.ApiVersion, err)
		}

		if debug {
			log.Printf("[DEBUG] Applying Overrides from the Existing API Definitions to the Parsed Swagger Data..")
		}
		data, err = differ.ApplyFromExistingAPIDefinitions(*existingApiDefinitions, *data)
		if err != nil {
			return fmt.Errorf("applying Overrides from the existing API Definitions: %+v", err)
		}

		// TODO: Overrides for Terraform Resources too

		if debug {
			log.Printf("[DEBUG] Applied Overrides from the Existing API Definitions to the Parsed Swagger Data.")
		}
	} else {
		log.Printf("[DEBUG] Skipping retrieving current schema from Data API..")
	}

	if debug {
		log.Printf("[STAGE] Generating Data API Definitions..")
	}
	dataApiGenerator := dataapigenerator.Service{
		Data:                       *data,
		DebugLog:                   debug,
		OutputDirectory:            input.OutputDirectory,
		ResourceProvider:           input.ResourceProvider,
		RootNamespace:              input.RootNamespace,
		SwaggerGitSha:              swaggerGitSha,
		TerraformServiceDefinition: input.TerraformServiceDefinition,
	}
	if err := dataApiGenerator.Generate(); err != nil {
		err = fmt.Errorf("generating Data API Definitions for Service %q / API Version %q: %+v", input.ServiceName, input.ApiVersion, err)
		log.Printf("❌ Service %q - Api Version %q", input.ServiceName, input.ApiVersion)
		log.Printf("     💥 Error: %+v", err)
		return err
	}

	log.Printf("✅ Service %q - Api Version %q", input.ServiceName, input.ApiVersion)
	return nil
}

func identifyCandidateTerraformResources(input *parser.ParsedData, terraformServiceDefinition definitions.ServiceDefinition) (*parser.ParsedData, error) {
	if input == nil {
		return input, nil
	}

	parsedResources := make(map[string]models.AzureApiResource, 0)

	for k, v := range input.Resources {
		definitionsForThisResource := findResourceDefinitionsForResource(input.ApiVersion, k, terraformServiceDefinition)
		if definitionsForThisResource != nil {
			apiResource, err := transformer.ApiResourceFromModelResource(v)
			if err != nil {
				return nil, fmt.Errorf("mapping Resource %q from to an API Resource: %+v", k, err)
			}

			terraformDetails := resources.FindCandidates(*apiResource, *definitionsForThisResource, k)
			v.Terraform = &terraformDetails
		}

		parsedResources[k] = v
	}

	input.Resources = parsedResources

	return input, nil
}

func findResourceDefinitionsForResource(apiVersion, apiResource string, terraformServiceDefinitions definitions.ServiceDefinition) *map[string]definitions.ResourceDefinition {
	forApiVersion, ok := terraformServiceDefinitions.ApiVersions[apiVersion]
	if !ok {
		return nil
	}

	forResource, ok := forApiVersion.Packages[apiResource]
	if !ok {
		return nil
	}

	return &forResource.Definitions
}

func parseSwaggerFiles(input RunInput, debug bool) (*parser.ParsedData, error) {
	parseResult, err := parser.LoadAndParseFiles(input.SwaggerDirectory, input.SwaggerFiles, input.ServiceName, input.ApiVersion, debug)
	if err != nil {
		return nil, fmt.Errorf("parsing files in %q: %+v", input.SwaggerDirectory, err)
	}

	return parseResult, nil
}
