package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigenerator"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (pipelineTask) generateServiceDefinitions(serviceName, outputDirectory, rootNamespace, swaggerGitSha string, resourceProvider, terraformPackageName *string, apiVersions []models.AzureApiDefinition, logger hclog.Logger) error {
	s := dataapigenerator.NewForService(serviceName, outputDirectory, rootNamespace, swaggerGitSha, resourceProvider, terraformPackageName, logger)

	if err := s.GenerateForService(apiVersions); err != nil {
		return fmt.Errorf("generating service %q: %+v", serviceName, err)
	}

	return nil
}
