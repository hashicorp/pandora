package pipeline

import (
	"fmt"
	"log"
	"os"
	"sync"

	"github.com/go-git/go-git/v5"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigenerator"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/differ"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/resources"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func Run(input RunInput) error {
	if input.JustOutputSegments {
		return parseAndOutputSegments(input)
	}

	return runImporter(input)
}

func runImporter(input RunInput) error {
	resources, err := definitions.LoadFromDirectory(input.TerraformDefinitionsPath)
	if err != nil {
		return fmt.Errorf("loading terraform definitions from %q: %+v", input.TerraformDefinitionsPath, err)
	}

	generationData, err := GenerationData(input, *resources)
	if err != nil {
		return fmt.Errorf("loading data: %+v", err)
	}

	swaggerGitSha, err := determineGitSha(input.SwaggerDirectory, input.Logger)
	if err != nil {
		return fmt.Errorf("determining Git SHA at %q: %+v", input.SwaggerDirectory, err)
	}

	var wg sync.WaitGroup
	for _, v := range *generationData {
		wg.Add(1)
		go func(v ServiceInput) {
			if err := importService(v, *swaggerGitSha, input.DataApiEndpoint, input.JustParseData, input.Logger.Named(fmt.Sprintf("Importer Service %q / API Version %q", v.ServiceName, v.ApiVersion))); err != nil {
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

func importService(input ServiceInput, swaggerGitSha string, dataApiEndpoint *string, justParse bool, logger hclog.Logger) error {
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
	dataApiGenerator := dataapigenerator.NewService(*data, input.OutputDirectory, input.RootNamespace, swaggerGitSha, input.ResourceProvider, terraformPackageName, logger.Named("Data API Generator"))
	if err := dataApiGenerator.Generate(); err != nil {
		err = fmt.Errorf("generating Data API Definitions for Service %q / API Version %q: %+v", input.ServiceName, input.ApiVersion, err)
		logger.Info(fmt.Sprintf("❌ Service %q - Api Version %q", input.ServiceName, input.ApiVersion))
		logger.Error(fmt.Sprintf("     💥 Error: %+v", err))
		return err
	}

	logger.Info(fmt.Sprintf("✅ Service %q - Api Version %q", input.ServiceName, input.ApiVersion))
	return nil
}

func identifyCandidateTerraformResources(input *models.AzureApiDefinition, terraformServiceDefinition definitions.ServiceDefinition, logger hclog.Logger) (*models.AzureApiDefinition, error) {
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

func parseSwaggerFiles(input ServiceInput, logger hclog.Logger) (*models.AzureApiDefinition, error) {
	parseResult, err := parser.LoadAndParseFiles(input.SwaggerDirectory, input.SwaggerFiles, input.ServiceName, input.ApiVersion, logger)
	if err != nil {
		return nil, fmt.Errorf("parsing files in %q: %+v", input.SwaggerDirectory, err)
	}

	return parseResult, nil
}
