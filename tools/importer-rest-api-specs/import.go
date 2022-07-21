package main

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigenerator"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/resources"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/differ"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func importService(input RunInput, swaggerGitSha string, dataApiEndpoint *string, logger hclog.Logger) error {
	logger.Debug("[STAGE] Parsing Swagger Files..")
	data, err := parseSwaggerFiles(input, logger)
	if err != nil {
		err = fmt.Errorf("parsing Swagger files: %+v", err)
		logger.Info(fmt.Sprintf("❌ Service %q - Api Version %q", input.ServiceName, input.ApiVersion))
		logger.Error("     💥 Error: %+v", err)
		return err
	}
	if data == nil {
		logger.Info(fmt.Sprintf("😵 Service %q / Api Version %q contains no resources, skipping.", input.ServiceName, input.ApiVersion))
		return nil
	}

	if input.TerraformServiceDefinition != nil {
		data, err = identifyCandidateTerraformResources(data, *input.TerraformServiceDefinition, logger)
		if err != nil {
			return fmt.Errorf("identifying Terraform Candidates: %+v", err)
		}
	}

	if justParse {
		logger.Info(fmt.Sprintf("✅ Service %q - Api Version %q - Parsed Fine but skipping generation", input.ServiceName, input.ApiVersion))
		return nil
	}

	if dataApiEndpoint != nil {
		logger.Debug("Retrieving Current Schema from Data API..")

		differ := differ.NewDiffer(*dataApiEndpoint)
		existingApiDefinitions, err := differ.RetrieveExistingService(input.ServiceName, input.ApiVersion)
		if err != nil {
			return fmt.Errorf("retrieving data for existing Service %q / Version %q from Data API: %+v", input.ServiceName, input.ApiVersion, err)
		}

		logger.Debug("Applying Overrides from the Existing API Definitions to the Parsed Swagger Data..")
		data, err = differ.ApplyFromExistingAPIDefinitions(*existingApiDefinitions, *data)
		if err != nil {
			return fmt.Errorf("applying Overrides from the existing API Definitions: %+v", err)
		}

		// TODO: Overrides for Terraform Resources too

		logger.Debug("Applied Overrides from the Existing API Definitions to the Parsed Swagger Data.")
	} else {
		logger.Debug("Skipping retrieving current schema from Data API..")
	}

	logger.Debug("Generating Data API Definitions..")
	var terraformPackageName *string
	if input.TerraformServiceDefinition != nil {
		terraformPackageName = &input.TerraformServiceDefinition.TerraformPackageName
	}
	dataApiGenerator := dataapigenerator.NewService(*data, outputDirectory, input.RootNamespace, swaggerGitSha, input.ResourceProvider, terraformPackageName, logger)
	if err := dataApiGenerator.Generate(); err != nil {
		err = fmt.Errorf("generating Data API Definitions for Service %q / API Version %q: %+v", input.ServiceName, input.ApiVersion, err)
		logger.Info(fmt.Sprintf("❌ Service %q - Api Version %q", input.ServiceName, input.ApiVersion))
		logger.Error(fmt.Sprintf("     💥 Error: %+v", err))
		return err
	}

	logger.Info(fmt.Sprintf("✅ Service %q - Api Version %q", input.ServiceName, input.ApiVersion))
	return nil
}

func identifyCandidateTerraformResources(input *parser.ParsedData, terraformServiceDefinition definitions.ServiceDefinition, logger hclog.Logger) (*parser.ParsedData, error) {
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

			terraformDetails := resources.FindCandidates(*apiResource, *definitionsForThisResource, k, logger)
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

func parseSwaggerFiles(input RunInput, logger hclog.Logger) (*parser.ParsedData, error) {
	parseResult, err := parser.LoadAndParseFiles(input.SwaggerDirectory, input.SwaggerFiles, input.ServiceName, input.ApiVersion, logger)
	if err != nil {
		return nil, fmt.Errorf("parsing files in %q: %+v", input.SwaggerDirectory, err)
	}

	return parseResult, nil
}
