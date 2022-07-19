package main

import (
	"fmt"
	"log"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/resources"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/differ"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/generator"
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
	if data != nil && len(*data) == 0 {
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
		log.Printf("[STAGE] Updating the Output Revision ID to %q", swaggerGitSha)
	}
	if err := generator.OutputRevisionId(input.OutputDirectory, input.RootNamespace, swaggerGitSha); err != nil {
		return fmt.Errorf("outputting the Revision Id: %+v", err)
	}

	if debug {
		log.Printf("[STAGE] Generating Swagger Definitions..")
	}
	var terraformPackageName *string
	if input.TerraformServiceDefinition != nil {
		terraformPackageName = &input.TerraformServiceDefinition.TerraformPackageName
	}

	if err := generateServiceDefinitions(*data, input.OutputDirectory, input.RootNamespace, input.ResourceProvider, terraformPackageName, debug); err != nil {
		return errWrap(fmt.Errorf("generating Service Definitions: %+v", err))
	}

	if debug {
		log.Printf("[STAGE] Generating API Definitions..")
	}
	if err := generateApiVersions(*data, input.OutputDirectory, input.RootNamespace, input.ResourceProvider, terraformPackageName, debug); err != nil {
		return errWrap(fmt.Errorf("generating API Versions: %+v", err))
	}

	log.Printf("✅ Service %q - Api Version %q", input.ServiceName, input.ApiVersion)
	return nil
}

func identifyCandidateTerraformResources(input *[]parser.ParsedData, terraformServiceDefinition definitions.ServiceDefinition) (*[]parser.ParsedData, error) {
	if input == nil {
		return input, nil
	}

	out := make([]parser.ParsedData, 0)

	for _, item := range *input {
		parsedResources := make(map[string]models.AzureApiResource, 0)

		for k, v := range item.Resources {
			definitionsForThisResource := findResourceDefinitionsForResource(item.ApiVersion, k, terraformServiceDefinition)
			if definitionsForThisResource != nil {
				apiResource, err := transformer.ApiResourceFromModelResource(v)
				if err != nil {
					return nil, fmt.Errorf("mapping Resource %q from to an API Resource: %+v", k, err)
				}

				v.Terraform = resources.FindCandidates(*apiResource, *definitionsForThisResource, k)
			}

			parsedResources[k] = v
		}

		item.Resources = parsedResources
		out = append(out, item)
	}

	return &out, nil
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

func parseSwaggerFiles(input RunInput, debug bool) (*[]parser.ParsedData, error) {
	// TODO: shouldn't this be returning a single `parser.ParsedData` here?
	parseResult, err := parser.LoadAndParseFiles(input.SwaggerDirectory, input.SwaggerFiles, input.ServiceName, input.ApiVersion, debug)
	if err != nil {
		return nil, fmt.Errorf("parsing files in %q: %+v", input.SwaggerDirectory, err)
	}

	return parseResult, nil
}
