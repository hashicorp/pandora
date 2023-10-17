package dataapigeneratorjson

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateServiceDefinitions(apiVersions []models.AzureApiDefinition) error {
	s.logger.Debug(fmt.Sprintf("Processing Service %q..", s.serviceName))

	if err := s.generateServiceDefinition(apiVersions); err != nil {
		return fmt.Errorf("generating Service Definition for Service %q: %+v", s.serviceName, err)
	}

	return nil
}
