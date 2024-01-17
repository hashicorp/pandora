package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (pipelineTask) generateApiDefinitionsV2(serviceName string, apiVersions []models.AzureApiDefinition, outputDirectory, swaggerGitSha string, resourceProvider, terraformPackageName *string, logger hclog.Logger) error {
	// TODO: we should recreate the folder for this service

	// Generate each of the API Versions for this Service
	for _, apiVersion := range apiVersions {
		logger.Debug("Generating Data API Definition..")
		apiVersionGenerator := dataapigeneratorjson.NewForApiVersion(apiVersion.ServiceName, apiVersion.ApiVersion, outputDirectory, resourceProvider, terraformPackageName, logger.Named("Data API Generator"))
		if err := apiVersionGenerator.GenerateForApiVersion(apiVersion); err != nil {
			err = fmt.Errorf("generating JSON Data API Definitions for Service %q / API Version %q: %+v", apiVersion.ServiceName, apiVersion.ApiVersion, err)
			logger.Info(fmt.Sprintf("❌ Service %q - Api Version %q", apiVersion.ServiceName, apiVersion.ApiVersion))
			logger.Error(fmt.Sprintf("     💥 Error: %+v", err))
			return err
		}
		logger.Info(fmt.Sprintf("✅ Service %q - Api Version %q", apiVersion.ServiceName, apiVersion.ApiVersion))

	}

	logger.Debug("Generating Service Definition..")
	serviceGenerator := dataapigeneratorjson.NewForService(serviceName, outputDirectory, resourceProvider, terraformPackageName, logger)
	if err := serviceGenerator.GenerateForService(apiVersions); err != nil {
		return fmt.Errorf("generating service %q: %+v", serviceName, err)
	}

	return nil
}
