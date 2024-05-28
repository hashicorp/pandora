// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform"
	terraformModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func runImporter(input RunInput, generationData []discovery.ServiceInput, swaggerGitSha string) error {
	sourceDataType := models.ResourceManagerSourceDataType
	sourceDataOrigin := models.AzureRestAPISpecsSourceDataOrigin
	repo := repository.NewRepository(input.OutputDirectory, logging.Log)

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
			SourceDataType:   sourceDataType,
		}
		if err := repo.RemoveService(removeServiceOpts); err != nil {
			return fmt.Errorf("removing existing API Definitions for Service %q: %+v", serviceName, err)
		}

		logger := input.Logger.Named(fmt.Sprintf("Importer for Service %q", serviceName))
		if err := runImportForService(input, serviceName, serviceDetails, sourceDataType, sourceDataOrigin, logger, swaggerGitSha, repo); err != nil {
			return fmt.Errorf("parsing data for Service %q: %+v", serviceName, err)
		}
	}

	return nil
}

func runImportForService(input RunInput, serviceName string, apiVersionsForService []discovery.ServiceInput, sourceDataType models.SourceDataType, sourceDataOrigin models.SourceDataOrigin, logger hclog.Logger, swaggerGitSha string, repo repository.Repository) error {
	task := pipelineTask{}
	var resourceProvider *string
	var terraformPackageName *string

	consolidatedApiVersions := make(map[string][]discovery.ServiceInput)

	// scan for fragmented API - e.g. Compute 2021-07-01
	for _, v := range apiVersionsForService {
		if _, ok := consolidatedApiVersions[v.ApiVersion]; !ok {
			consolidatedApiVersions[v.ApiVersion] = []discovery.ServiceInput{v}
		} else {
			consolidatedApiVersions[v.ApiVersion] = append(consolidatedApiVersions[v.ApiVersion], v)
		}
	}

	// Pull out any overrides for the Terraform Resources from all API Versions
	// Since a since Terraform Resource can only come from a single API Version - these are going to be
	// unique so a map for all Terraform Resources across all API Versions for a single Service is fine.
	resourceBuildInfo := make(map[string]terraformModels.ResourceBuildInfo)
	for _, apiData := range consolidatedApiVersions {
		for _, data := range apiData {
			if resourceProvider == nil && data.ResourceProvider != nil {
				rpName := *data.ResourceProvider
				resourceProvider = &rpName
			}

			if data.TerraformServiceDefinition == nil {
				continue
			}

			// populate the service information based on this api version
			if terraformPackageName == nil && data.TerraformServiceDefinition != nil {
				packageName := data.TerraformServiceDefinition.TerraformPackageName
				terraformPackageName = &packageName
			}

			for _, versionDetails := range data.TerraformServiceDefinition.ApiVersions {
				for _, pkgDetails := range versionDetails.Packages {
					for resource, resourceDetails := range pkgDetails.Definitions {
						if resourceDetails.Overrides != nil {
							overrides := make([]terraformModels.Override, 0)
							for _, o := range *resourceDetails.Overrides {
								overrides = append(overrides, terraformModels.Override{
									Name:        o.Name,
									UpdatedName: o.UpdatedName,
									Description: o.Description,
								})
							}
							resourceBuildInfo[resource] = terraformModels.ResourceBuildInfo{
								Overrides: overrides,
							}
						}
					}
				}
			}
		}
	}

	// Populate all the data for this API Version..
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

	// Now that we've got all the API Versions, build up the Terraform Resources
	// NOTE: in the near future this will be refactored to be for a Service, this is a stepping-stone refactor
	// in that direction - as that requires more significant refactoring to the `terraform` package.
	dataForApiVersionsWithTerraformDetails := make([]importerModels.AzureApiDefinition, 0)
	for _, apiVersion := range dataForApiVersions {
		dataForApiVersion, err := terraform.PopulateForResources(apiVersion, resourceBuildInfo, input.ProviderPrefix, logging.Log)
		if err != nil {
			return fmt.Errorf("populating Terraform Details for Service %q / Version %q: %+v", serviceName, apiVersion.ApiVersion, err)
		}
		dataForApiVersionsWithTerraformDetails = append(dataForApiVersionsWithTerraformDetails, *dataForApiVersion)
	}

	// temporary glue to enable refactoring this tool piece-by-piece
	logger.Info("Transforming to the Data API SDK types..")
	service, err := transformer.MapInternalTypesToDataAPISDKTypes(dataForApiVersionsWithTerraformDetails, resourceProvider, terraformPackageName, logger)
	if err != nil {
		return fmt.Errorf("transforming the internal types to the Data API SDK types: %+v", err)
	}

	// Now that we have the populated data, let's go ahead and output that..
	logger.Info(fmt.Sprintf("Persisting API Definitions for Service %s..", serviceName))

	opts := repository.SaveServiceOptions{
		ResourceProvider: resourceProvider,
		Service:          *service,
		ServiceName:      serviceName,
		SourceCommitSHA:  pointer.To(swaggerGitSha),
		SourceDataOrigin: sourceDataOrigin,
		SourceDataType:   sourceDataType,
	}
	if err = repo.SaveService(opts); err != nil {
		return fmt.Errorf("persisting Data API Definitions for Service %q: %+v", serviceName, err)
	}

	return nil
}
