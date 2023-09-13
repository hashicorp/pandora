package dataapigeneratoryaml

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateServiceDefinitions(apiVersions []models.AzureApiDefinition) error {
	s.logger.Debug(fmt.Sprintf("Processing Service %q..", s.serviceName))

	// finally let's output the new Service Definition
	if err := s.generateServiceDefinition(apiVersions); err != nil {
		return fmt.Errorf("generating Service Definition for Namespace %q: %+v", s.namespaceForService, err)
	}

	return nil
}
