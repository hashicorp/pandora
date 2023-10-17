package pipeline

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigenerator"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (t pipelineTask) generateApiDefinitionsV1(input RunInput, serviceName string, apiVersions []models.AzureApiDefinition, rootNamespace, swaggerGitSha string, resourceProvider, terraformPackageName *string, logger hclog.Logger) error {
	for _, apiVersion := range apiVersions {
		versionLogger := logger.Named(fmt.Sprintf("Generator for Service %q / API Version %q", apiVersion.ServiceName, apiVersion.ApiVersion))

		versionLogger.Trace("Task: Generating Data API Definitions..")
		apiVersionGenerator := dataapigenerator.NewForApiVersion(apiVersion.ServiceName, apiVersion.ApiVersion, input.OutputDirectoryCS, rootNamespace, swaggerGitSha, resourceProvider, terraformPackageName, logger.Named("Data API Generator"))
		if err := apiVersionGenerator.GenerateForApiVersion(apiVersion); err != nil {
			err = fmt.Errorf("generating C# Data API Definitions for Service %q / API Version %q: %+v", apiVersion.ServiceName, apiVersion.ApiVersion, err)
			logger.Info(fmt.Sprintf("❌ Service %q - Api Version %q", apiVersion.ServiceName, apiVersion.ApiVersion))
			logger.Error(fmt.Sprintf("     💥 Error: %+v", err))
			return err
		}
		logger.Info(fmt.Sprintf("✅ Service %q - Api Version %q in C#", apiVersion.ServiceName, apiVersion.ApiVersion))
	}

	logger.Trace("Task: Generating Service Definitions (v1 / C#)..")
	s := dataapigenerator.NewForService(serviceName, input.OutputDirectoryCS, rootNamespace, swaggerGitSha, resourceProvider, terraformPackageName, logger)
	if err := s.GenerateForService(apiVersions); err != nil {
		return fmt.Errorf("generating API Definitions %q in C#: %+v", serviceName, err)
	}

	return nil
}
