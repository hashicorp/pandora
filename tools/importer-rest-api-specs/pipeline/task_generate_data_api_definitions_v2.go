package pipeline

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/featureflags"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (pipelineTask) generateApiDefinitionsV2(serviceName string, apiVersions []models.AzureApiDefinition, outputDirectory, swaggerGitSha string, resourceProvider, terraformPackageName *string, logger hclog.Logger) error {
	if !featureflags.GenerateV2APIDefinitions {
		return nil
	}

	// Generate each of the API Versions for this Service
	for _, apiVersion := range apiVersions {
		logger.Debug("Generating Data API Definition in JSON..")
		yamlGenerator := dataapigeneratorjson.NewForApiVersion(apiVersion.ServiceName, apiVersion.ApiVersion, outputDirectory, swaggerGitSha, resourceProvider, terraformPackageName, logger.Named("Data API Generator"))
		if err := yamlGenerator.GenerateForApiVersion(apiVersion); err != nil {
			err = fmt.Errorf("generating JSON Data API Definitions for Service %q / API Version %q: %+v", apiVersion.ServiceName, apiVersion.ApiVersion, err)
			logger.Info(fmt.Sprintf("❌ Service %q - Api Version %q", apiVersion.ServiceName, apiVersion.ApiVersion))
			logger.Error(fmt.Sprintf("     💥 Error: %+v", err))
			return err
		}
		logger.Info(fmt.Sprintf("✅ Service %q - Api Version %q in JSON", apiVersion.ServiceName, apiVersion.ApiVersion))

	}

	logger.Debug("Generating Service Definition in JSON..")
	s := dataapigeneratorjson.NewForService(serviceName, outputDirectory, swaggerGitSha, resourceProvider, terraformPackageName, logger)
	if err := s.GenerateForService(apiVersions); err != nil {
		return fmt.Errorf("generating service %q in JSON: %+v", serviceName, err)
	}

	return nil
}
