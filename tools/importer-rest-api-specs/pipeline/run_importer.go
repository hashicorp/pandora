package pipeline

import (
	"fmt"
	"sort"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigenerator"
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
		serviceDirectory := fmt.Sprintf("%s%s/%s", input.OutputDirectory, "Pandora.Definitions.ResourceManager", serviceName)
		logger.Debug("recreating directory %q for Service %q", serviceDirectory, serviceName)
		if err := dataapigenerator.RecreateDirectory(serviceDirectory, logger); err != nil {
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
	rootNamespace := ""
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
	for apiVersion, api := range consolidatedApiVersions {
		versionLogger := logger.Named(fmt.Sprintf("Importer for API Version %q", apiVersion))
		// populate the service information based on this api version
		if rootNamespace == "" {
			rootNamespace = api[0].RootNamespace
		}
		if rootNamespace != "" && rootNamespace != api[0].RootNamespace {
			// TODO: this is possible, just requires refactoring this.
			return fmt.Errorf("different root namespaces were found for different api versions for the same service - previously found %q but got %q", rootNamespace, api[0].RootNamespace)
		}
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

		versionLogger.Trace("generating Terraform Details")
		var err error
		dataForApiVersion, err = task.generateTerraformDetails(dataForApiVersion, versionLogger.Named("TerraformDetails"))
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

		versionLogger.Trace("Task: Applying Overrides from Existing Data..")
		dataForApiVersion, err = task.applyOverridesFromExistingData(*dataForApiVersion, input.DataApiEndpoint, versionLogger)
		if err != nil {
			return fmt.Errorf("applying overrides for existing data for Service %q / Version %q: %+v", serviceName, apiVersion, err)
		}

		versionLogger.Trace("Task: Generating Data API Definitions..")
		if err := task.generateApiDefinitions(api[0], *dataForApiVersion, swaggerGitSha, versionLogger); err != nil {
			return fmt.Errorf("generating API Definitions for Service %q / Version %q: %+v", serviceName, apiVersion, err)
		}

		apiVersions = append(apiVersions, *dataForApiVersion)

	}

	logger.Trace("Task: Generating Service Definitions..")
	if err := task.generateServiceDefinitions(serviceName, input.OutputDirectory, rootNamespace, swaggerGitSha, resourceProvider, terraformPackageName, apiVersions, logger.Named("Service Definitions")); err != nil {
		return fmt.Errorf("generating Service Definitions for %q: %+v", serviceName, err)
	}

	return nil
}
