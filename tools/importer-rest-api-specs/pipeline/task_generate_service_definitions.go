package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigenerator"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratoryaml"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/featureflags"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (pipelineTask) generateServiceDefinitions(serviceName string, runInput RunInput, rootNamespace, swaggerGitSha string, resourceProvider, terraformPackageName *string, apiVersions []models.AzureApiDefinition, logger hclog.Logger) error {
	logger.Debug("Generating Service Definition in C#..")
	s := dataapigenerator.NewForService(serviceName, runInput.OutputDirectoryCS, rootNamespace, swaggerGitSha, resourceProvider, terraformPackageName, logger)
	if err := s.GenerateForService(apiVersions); err != nil {
		return fmt.Errorf("generating service %q in C#: %+v", serviceName, err)
	}

	if featureflags.GenerateYamlDataAPI {
		logger.Debug("Generating Service Definition in YAML..")
		s := dataapigeneratoryaml.NewForService(serviceName, runInput.OutputDirectoryYaml, "resource-manager", swaggerGitSha, resourceProvider, terraformPackageName, logger)
		if err := s.GenerateForService(apiVersions); err != nil {
			return fmt.Errorf("generating service %q in YAML: %+v", serviceName, err)
		}
	}
	return nil
}
