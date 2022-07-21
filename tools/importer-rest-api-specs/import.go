package main

import (
	"fmt"

	parser2 "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigenerator"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/resources"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/differ"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func importService(input RunInput, swaggerGitSha string, dataApiEndpoint *string, logger hclog.Logger) error {
	logger.Trace("Parsing Swagger Files..")
	data, err := parseSwaggerFiles(input, logger.Named("Swagger"))
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
		logger.Trace("Identifying candidate Terraform Data Sources/Resources within the API Data..")
		data, err = identifyCandidateTerraformResources(data, *input.TerraformServiceDefinition, logger.Named("Terraform"))
		if err != nil {
			return fmt.Errorf("identifying Terraform Candidates: %+v", err)
		}
	} else {
		logger.Trace("No Terraform Definitions defined for this Service, skipping identifying candidate Terraform Data Sources/Resources")
	}

	if justParse {
		logger.Info(fmt.Sprintf("✅ Service %q - Api Version %q - Parsed Fine but skipping generation", input.ServiceName, input.ApiVersion))
		return nil
	}

	if dataApiEndpoint != nil {
		logger.Trace("Retrieving current Data and Schema from the Data API..")

		differ := differ.NewDiffer(*dataApiEndpoint, logger.Named("Data API Differ"))
		existingApiDefinitions, err := differ.RetrieveExistingService(input.ServiceName, input.ApiVersion)
		if err != nil {
			return fmt.Errorf("retrieving data for existing Service %q / Version %q from Data API: %+v", input.ServiceName, input.ApiVersion, err)
		}

		logger.Trace("Applying Overrides from the Existing API Definitions to the Parsed Swagger Data..")
		data, err = differ.ApplyFromExistingAPIDefinitions(*existingApiDefinitions, *data)
		if err != nil {
			return fmt.Errorf("applying Overrides from the existing API Definitions: %+v", err)
		}

		// TODO: Overrides for Terraform Resources too

		logger.Trace("Applied Overrides from the Existing API Definitions to the Parsed Swagger Data.")
	} else {
		logger.Trace("Skipping retrieving current schema from Data API..")
	}

	logger.Debug("Generating Data API Definitions..")
	var terraformPackageName *string
	if input.TerraformServiceDefinition != nil {
		terraformPackageName = &input.TerraformServiceDefinition.TerraformPackageName
	}
	dataApiGenerator := dataapigenerator.NewService(*data, outputDirectory, input.RootNamespace, swaggerGitSha, input.ResourceProvider, terraformPackageName, logger.Named("Data API Generator"))
	if err := dataApiGenerator.Generate(); err != nil {
		err = fmt.Errorf("generating Data API Definitions for Service %q / API Version %q: %+v", input.ServiceName, input.ApiVersion, err)
		logger.Info(fmt.Sprintf("❌ Service %q - Api Version %q", input.ServiceName, input.ApiVersion))
		logger.Error(fmt.Sprintf("     💥 Error: %+v", err))
		return err
	}

	logger.Info(fmt.Sprintf("✅ Service %q - Api Version %q", input.ServiceName, input.ApiVersion))
	return nil
}

func identifyCandidateTerraformResources(input *models.ParsedData, terraformServiceDefinition definitions.ServiceDefinition, logger hclog.Logger) (*models.ParsedData, error) {
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

func parseSwaggerFiles(input RunInput, logger hclog.Logger) (*models.ParsedData, error) {
	parseResult, err := parser2.LoadAndParseFiles(input.SwaggerDirectory, input.SwaggerFiles, input.ServiceName, input.ApiVersion, logger)
	if err != nil {
		return nil, fmt.Errorf("parsing files in %q: %+v", input.SwaggerDirectory, err)
	}

	return parseResult, nil
}
