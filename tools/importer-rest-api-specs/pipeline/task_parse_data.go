// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/resources"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func (pipelineTask) parseDataForApiVersion(input discovery.ServiceInput, logger hclog.Logger) (*models.AzureApiDefinition, error) {
	logger.Trace("Parsing Swagger Files..")
	data, err := parseSwaggerFiles(input, logger.Named("Swagger"))
	if err != nil {
		err = fmt.Errorf("parsing Swagger files: %+v", err)
		logger.Info(fmt.Sprintf("❌ Service %q - Api Version %q", input.ServiceName, input.ApiVersion))
		logger.Error(fmt.Sprintf("     💥 Error: %+v", err))
		return nil, err
	}
	if data == nil {
		logger.Info(fmt.Sprintf("😵 Service %q / Api Version %q contains no resources, skipping.", input.ServiceName, input.ApiVersion))
		return nil, nil
	}

	if input.TerraformServiceDefinition != nil {
		logger.Trace("Identifying candidate Terraform Data Sources/Resources within the API Data..")
		data, err = identifyCandidateTerraformResources(data, *input.TerraformServiceDefinition, logger.Named("Terraform"))
		if err != nil {
			return nil, fmt.Errorf("identifying Terraform Candidates: %+v", err)
		}
	} else {
		logger.Trace("No Terraform Definitions defined for this Service, skipping identifying candidate Terraform Data Sources/Resources")
	}

	return data, nil
}

func parseSwaggerFiles(input discovery.ServiceInput, logger hclog.Logger) (*models.AzureApiDefinition, error) {
	parseResult, err := parser.LoadAndParseFiles(input.SwaggerDirectory, input.SwaggerFiles, input.ServiceName, input.ApiVersion, input.ResourceProviderToFilterTo, logger)
	if err != nil {
		return nil, fmt.Errorf("parsing files in %q: %+v", input.SwaggerDirectory, err)
	}

	return parseResult, nil
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

			terraformDetails, err := resources.FindCandidates(*apiResource, *definitionsForThisResource, k, logger)
			if err != nil {
				return nil, fmt.Errorf("finding candidate Terraform Data Sources/Resources: %+v", err)
			}
			v.Terraform = terraformDetails
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
