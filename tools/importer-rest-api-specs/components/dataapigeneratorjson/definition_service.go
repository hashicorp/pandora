package dataapigeneratorjson

import (
	"fmt"
	"path"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateServiceDefinition(apiVersions []models.AzureApiDefinition) error {
	serviceDefinitionFilePath := path.Join(s.workingDirectoryForService, "ServiceDefinition.json")
	s.logger.Debug(fmt.Sprintf("Generating Service Definition into %q..", serviceDefinitionFilePath))

	code, err := codeForServiceDefinition(s.serviceName, s.resourceProvider, s.terraformPackageName, apiVersions)
	if err != nil {
		return fmt.Errorf("marshaling Service Definition: %+v", err)
	}
	if err := writeJsonToFile(serviceDefinitionFilePath, code); err != nil {
		return fmt.Errorf("generating Service Definition into %q: %+v", serviceDefinitionFilePath, err)
	}

	return nil
}
