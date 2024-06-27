// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func runImporter(input RunInput, generationData []discovery.ServiceInput, swaggerGitSha string) error {
	sourceDataType := sdkModels.ResourceManagerSourceDataType
	sourceDataOrigin := sdkModels.AzureRestAPISpecsSourceDataOrigin
	repo, err := repository.NewRepository(input.OutputDirectory, sourceDataType, nil, logging.Log)
	if err != nil {
		return fmt.Errorf("building repository: %+v", err)
	}

	// Clear any existing data
	input.Logger.Info(fmt.Sprintf("Purging all existing Source Data for Source Data Type %q / Source Data Origin %q..", sourceDataType, sourceDataOrigin))
	if err := repo.PurgeExistingData(sourceDataOrigin); err != nil {
		return fmt.Errorf("purging the existing Source Data for the Source Data Type %q / Source Data Origin %q: %+v", sourceDataType, sourceDataOrigin, err)
	}

	// group the API Versions by Service
	dataByServices := make(map[string][]discovery.ServiceInput)
	for _, v := range generationData {
		existing, ok := dataByServices[v.ServiceName]
		if !ok {
			existing = append(existing, v)
			dataByServices[v.ServiceName] = existing
			continue
		} else {
			existing = append(existing, v)
			dataByServices[v.ServiceName] = existing
			continue
		}
	}

	// sort these so it's easier for parsing/tracing
	serviceNames := make([]string, 0)
	for serviceName := range dataByServices {
		serviceNames = append(serviceNames, serviceName)
	}
	sort.Strings(serviceNames)

	// then parse/process the data for each of the API Versions for each service
	for _, serviceName := range serviceNames {
		serviceDetails := dataByServices[serviceName]

		logging.Log.Debug(fmt.Sprintf("Removing any existing API Definitions for the Service %q", serviceName))
		removeServiceOpts := repository.RemoveServiceOptions{
			ServiceName:      serviceName,
			SourceDataOrigin: sourceDataOrigin,
		}
		if err := repo.RemoveService(removeServiceOpts); err != nil {
			return fmt.Errorf("removing existing API Definitions for Service %q: %+v", serviceName, err)
		}

		logger := input.Logger.Named(fmt.Sprintf("Importer for Service %q", serviceName))
		if err := runImportForService(input, serviceName, serviceDetails, sourceDataOrigin, logger, swaggerGitSha, repo); err != nil {
			return fmt.Errorf("parsing data for Service %q: %+v", serviceName, err)
		}
	}

	return nil
}

func runImportForService(input RunInput, serviceName string, apiVersionsForService []discovery.ServiceInput, sourceDataOrigin sdkModels.SourceDataOrigin, logger hclog.Logger, swaggerGitSha string, repo repository.Repository) error {
	task := pipelineTask{}
	var resourceProvider *string
	var terraformPackageName *string

	consolidatedApiVersions := make(map[string][]discovery.ServiceInput)
	terraformResourceDefinitions := make(map[string]definitions.ResourceDefinition)

	// scan for fragmented API - e.g. Compute 2021-07-01
	for _, v := range apiVersionsForService {
		if _, ok := consolidatedApiVersions[v.ApiVersion]; !ok {
			consolidatedApiVersions[v.ApiVersion] = []discovery.ServiceInput{v}
		} else {
			consolidatedApiVersions[v.ApiVersion] = append(consolidatedApiVersions[v.ApiVersion], v)
		}

		if v.TerraformServiceDefinition != nil {
			for _, apiVersionDefinition := range v.TerraformServiceDefinition.ApiVersions {
				for _, apiResourceDetails := range apiVersionDefinition.Packages {
					for resourceLabel, resourceDefinition := range apiResourceDetails.Definitions {
						if _, existing := terraformResourceDefinitions[resourceLabel]; existing {
							return fmt.Errorf("a duplicate Terraform Resource Definition exists for %q", resourceLabel)
						}
						terraformResourceDefinitions[resourceLabel] = resourceDefinition
					}
				}

			}
		}
		//v.TerraformServiceDefinition.ApiVersions[v.ApiVersion] =
	}

	// Populate all of the data for this API Version..
	dataForApiVersions := make([]importerModels.AzureApiDefinition, 0)
	for apiVersion, api := range consolidatedApiVersions {
		versionLogger := logger.Named(fmt.Sprintf("Importer for API Version %q", apiVersion))

		versionLogger.Trace("Task: Parsing Data..")
		dataForApiVersion := &importerModels.AzureApiDefinition{
			ServiceName: serviceName,
			ApiVersion:  apiVersion,
			Resources:   map[string]importerModels.AzureApiResource{},
		}
		for _, v := range api {
			tempDataForApiVersion, err := task.parseDataForApiVersion(v, versionLogger)
			if err != nil {
				return fmt.Errorf("parsing data for Service %q / Version %q: %+v", v.ServiceName, v.ApiVersion, err)
			}
			if tempDataForApiVersion == nil {
				continue
			}
			for name, resource := range tempDataForApiVersion.Resources {
				dataForApiVersion.Resources[name] = resource
			}
		}

		dataForApiVersions = append(dataForApiVersions, *dataForApiVersion)
	}

	// temporary glue to enable refactoring this tool piece-by-piece
	logger.Info("Transforming to the Data API SDK types..")
	service, err := transformer.MapInternalTypesToDataAPISDKTypes(serviceName, dataForApiVersions, resourceProvider, terraformPackageName, logger)
	if err != nil {
		return fmt.Errorf("transforming the internal types to the Data API SDK types: %+v", err)
	}

	// Now that we've got all of the API Versions, build up the Terraform Resources
	logging.Log.Info(fmt.Sprintf("Building Terraform Resources for the Service %q..", service.Name))
	service, err = terraform.BuildForService(*service, terraformResourceDefinitions, input.ProviderPrefix)
	if err != nil {
		return fmt.Errorf("building the Terraform Details: %+v", err)
	}

	// Now that we have the populated data, let's go ahead and output that..
	logger.Info(fmt.Sprintf("Persisting API Definitions for Service %s..", serviceName))
	opts := repository.SaveServiceOptions{
		SourceCommitSHA:  pointer.To(swaggerGitSha),
		ResourceProvider: resourceProvider,
		Service:          *service,
		ServiceName:      serviceName,
		SourceDataOrigin: sourceDataOrigin,
	}
	if err := repo.SaveService(opts); err != nil {
		return fmt.Errorf("persisting Data API Definitions for Service %q: %+v", serviceName, err)
	}

	return nil
}
