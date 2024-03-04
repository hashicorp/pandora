// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"os"
	"path"
	"sort"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform"
	terraformModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func runImporter(input RunInput, generationData []discovery.ServiceInput, swaggerGitSha string) error {
	sourceDataType := models.ResourceManagerSourceDataType
	sourceDataOrigin := models.AzureRestAPISpecsSourceDataOrigin

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
		logger := input.Logger.Named(fmt.Sprintf("Importer for Service %q", serviceName))

		serviceDirectory := path.Join(input.OutputDirectory, string(sourceDataType), serviceName)
		logger.Debug("recreating the working directory at %q for Service %q", serviceDirectory, serviceName)
		if err := recreateDirectory(serviceDirectory, logger); err != nil {
			return fmt.Errorf("recreating directory %q for service %q", serviceDirectory, serviceName)
		}

		if err := runImportForService(input, serviceName, serviceDetails, sourceDataType, sourceDataOrigin, logger, swaggerGitSha); err != nil {
			return fmt.Errorf("parsing data for Service %q: %+v", serviceName, err)
		}
	}

	return nil
}

func runImportForService(input RunInput, serviceName string, apiVersionsForService []discovery.ServiceInput, sourceDataType models.SourceDataType, sourceDataOrigin models.SourceDataOrigin, logger hclog.Logger, swaggerGitSha string) error {
	task := pipelineTask{}
	apiVersions := make([]importerModels.AzureApiDefinition, 0)
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

	// Populate all of the data for this API Version..
	for apiVersion, api := range consolidatedApiVersions {
		versionLogger := logger.Named(fmt.Sprintf("Importer for API Version %q", apiVersion))
		// populate the service information based on this api version
		if resourceProvider == nil && api[0].ResourceProvider != nil {
			rpName := *api[0].ResourceProvider
			resourceProvider = &rpName
		}
		if terraformPackageName == nil && api[0].TerraformServiceDefinition != nil {
			packageName := api[0].TerraformServiceDefinition.TerraformPackageName
			terraformPackageName = &packageName
		}

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

		resourceBuildInfo := make(map[string]terraformModels.ResourceBuildInfo)

		if api[0].TerraformServiceDefinition != nil {
			for _, versionDetails := range api[0].TerraformServiceDefinition.ApiVersions {
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

		versionLogger.Trace("generating Terraform Details")
		dataForApiVersion, err := terraform.PopulateForResources(dataForApiVersion, resourceBuildInfo, input.ProviderPrefix, versionLogger)
		if err != nil {
			return fmt.Errorf("populating Terraform Details for Service %q / Version %q: %+v", serviceName, apiVersion, err)
		}

		apiVersions = append(apiVersions, *dataForApiVersion)
	}

	// temporary glue to enable refactoring this tool piece-by-piece
	logger.Info("Transforming to the Data API SDK types..")
	service, err := transformer.MapInternalTypesToDataAPISDKTypes(apiVersions, resourceProvider, terraformPackageName, logger)
	if err != nil {
		return fmt.Errorf("transforming the internal types to the Data API SDK types: %+v", err)
	}

	// Now that we have the populated data, let's go ahead and output that..
	logger.Info(fmt.Sprintf("Persisting API Definitions for Service %s..", serviceName))

	repo := dataapigeneratorjson.NewRepository(input.OutputDirectory)
	opts := dataapigeneratorjson.SaveServiceOptions{
		AzureRestAPISpecsGitSHA: pointer.To(swaggerGitSha),
		ResourceProvider:        resourceProvider,
		Service:                 *service,
		ServiceName:             serviceName,
		SourceDataOrigin:        sourceDataOrigin,
		SourceDataType:          sourceDataType,
	}
	if err := repo.SaveService(opts); err != nil {
		return fmt.Errorf("persisting Data API Definitions for Service %q: %+v", serviceName, err)
	}

	return nil
}

func recreateDirectory(directory string, logger hclog.Logger) error {
	logger.Trace(fmt.Sprintf("Deleting any existing directory at %q..", directory))
	if err := os.RemoveAll(directory); err != nil {
		return fmt.Errorf("removing any existing directory at %q: %+v", directory, err)
	}
	logger.Trace(fmt.Sprintf("(Re)Creating the directory at %q..", directory))
	if err := os.MkdirAll(directory, os.FileMode(0755)); err != nil {
		return fmt.Errorf("creating directory %q: %+v", directory, err)
	}
	logger.Trace(fmt.Sprintf("Created Directory at %q", directory))
	return nil
}
