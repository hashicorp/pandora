package pipeline

import (
	"fmt"
	"path"
	"sort"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func runImporter(input RunInput, generationData []discovery.ServiceInput, swaggerGitSha string) error {
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

		serviceDirectory := path.Join(input.OutputDirectory, serviceName)
		logger.Debug("recreating the working directory at %q for Service %q", serviceDirectory, serviceName)
		if err := dataapigeneratorjson.RecreateDirectory(serviceDirectory, logger); err != nil {
			fmt.Errorf("recreating directory %q for service %q", serviceDirectory, serviceName)
		}

		if err := runImportForService(input, serviceName, serviceDetails, logger, swaggerGitSha); err != nil {
			return fmt.Errorf("parsing data for Service %q: %+v", serviceName, err)
		}
	}

	return nil
}

func runImportForService(input RunInput, serviceName string, apiVersionsForService []discovery.ServiceInput, logger hclog.Logger, swaggerGitSha string) error {
	task := pipelineTask{}
	apiVersions := make([]models.AzureApiDefinition, 0)
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
		dataForApiVersion := &models.AzureApiDefinition{
			ServiceName: serviceName,
			ApiVersion:  apiVersion,
			Resources:   map[string]models.AzureApiResource{},
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

		resourceBuildInfo := make(map[string]models.ResourceBuildInfo)

		if api[0].TerraformServiceDefinition != nil {
			for _, versionDetails := range api[0].TerraformServiceDefinition.ApiVersions {
				for _, pkgDetails := range versionDetails.Packages {
					for resource, resourceDetails := range pkgDetails.Definitions {
						if resourceDetails.Overrides != nil {
							overrides := make([]models.Override, 0)
							for _, o := range *resourceDetails.Overrides {
								overrides = append(overrides, models.Override{
									Name:        o.Name,
									UpdatedName: o.UpdatedName,
									Description: o.Description,
								})
							}
							resourceBuildInfo[resource] = models.ResourceBuildInfo{
								Overrides: overrides,
							}
						}
					}
				}
			}
		}

		versionLogger.Trace("generating Terraform Details")
		var err error
		dataForApiVersion, err = task.generateTerraformDetails(dataForApiVersion, &resourceBuildInfo, versionLogger.Named("TerraformDetails"))
		if err != nil {
			return fmt.Errorf(fmt.Sprintf("generating Terraform Details for Service %q / Version %q: %+v", serviceName, apiVersion, err))
		}

		versionLogger.Trace("generating Terraform Tests")
		dataForApiVersion, err = task.generateTerraformTests(dataForApiVersion, input.ProviderPrefix, versionLogger.Named("TerraformTests"))
		if err != nil {
			return fmt.Errorf(fmt.Sprintf("generating Terraform Tests for Service %q / Version %q: %+v", serviceName, apiVersion, err))
		}

		versionLogger.Trace("Generating Example Usage from the Terraform Tests")
		dataForApiVersion, err = task.generateTerraformExampleUsage(dataForApiVersion, input.ProviderPrefix, versionLogger.Named("TerraformExampleUsage"))
		if err != nil {
			return fmt.Errorf(fmt.Sprintf("generating Terraform Example Usage for Service %q / Version %q: %+v", serviceName, apiVersion, err))
		}

		apiVersions = append(apiVersions, *dataForApiVersion)
	}

	// Now that we have the populated data, let's go ahead and output that..
	logger.Trace("Task: Generating Service Definitions (v2 / JSON)..")
	if err := task.generateApiDefinitionsV2(serviceName, apiVersions, input.OutputDirectory, swaggerGitSha, resourceProvider, terraformPackageName, logger.Named("V2 API Definitions Generator")); err != nil {
		return fmt.Errorf("generating the Service Definitions for V2 (JSON): %+v", err)
	}

	logger.Trace("Task: Outputting the Meta Data for this Revision..")
	if err := task.outputMetaData(input, swaggerGitSha); err != nil {
		return fmt.Errorf("outputting the Meta Data for this Revision: %+v", err)
	}

	return nil
}
