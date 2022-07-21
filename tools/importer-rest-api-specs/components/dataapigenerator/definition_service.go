package dataapigenerator

import (
	"fmt"
	"path"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

func (s Service) generateServiceDefinition(input parser.ParsedData) error {
	serviceDefinitionFilePath := path.Join(s.workingDirectoryForService, "ServiceDefinition.cs")
	s.logger.Debug(fmt.Sprintf("Generating Service Definition into %q..", serviceDefinitionFilePath))

	normalizedServiceName := parser.NormalizeName(s.data.ServiceName)
	code := codeForServiceDefinition(s.namespaceForService, normalizedServiceName, s.resourceProvider, s.terraformPackageName, input)
	if err := writeToFile(serviceDefinitionFilePath, code); err != nil {
		return fmt.Errorf("generating Service Definition into %q: %+v", serviceDefinitionFilePath, err)
	}

	// ServiceDefinition-GenerationSettings.cs is retained between regenerations, so we special-case it
	generationSettingsFilePath := path.Join(s.workingDirectoryForService, "ServiceDefinition-GenerationSettings.cs")
	exists, err := fileExistsAtPath(generationSettingsFilePath)
	if err != nil {
		return err
	}
	if *exists {
		s.logger.Debug(fmt.Sprintf("Service Definition Generation Settings exist at %q - skipping", generationSettingsFilePath))
		return nil
	}

	s.logger.Debug(fmt.Sprintf("Creating Service Definition Generation Settings at %q", generationSettingsFilePath))
	code = codeForServiceDefinitionGenerationSettings(s.namespaceForService, s.data.ServiceName)
	if err := writeToFile(generationSettingsFilePath, code); err != nil {
		return fmt.Errorf("generating Service Definition Generation Settings into %q: %+v", generationSettingsFilePath, err)
	}

	return nil
}
