package dataapigenerator

import (
	"fmt"
	"log"
	"path"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

func (g PandoraDefinitionGenerator) generateServiceDefinition(input parser.ParsedData) error {
	serviceDefinitionFilePath := path.Join(g.data.WorkingDirectoryForService, "ServiceDefinition.cs")
	if g.debugLog {
		log.Printf("[DEBUG] Generating Service Definition into %q..", serviceDefinitionFilePath)
	}

	normalizedServiceName := cleanup.NormalizeName(g.data.ServiceName)
	code := codeForServiceDefinition(g.data.NamespaceForService, normalizedServiceName, g.data.ResourceProvider, g.data.TerraformPackageName, input)
	if err := writeToFile(serviceDefinitionFilePath, code); err != nil {
		return fmt.Errorf("generating Service Definition into %q: %+v", serviceDefinitionFilePath, err)
	}

	// ServiceDefinition-GenerationSettings.cs is retained between regenerations, so we special-case it
	generationSettingsFilePath := path.Join(g.data.WorkingDirectoryForService, "ServiceDefinition-GenerationSettings.cs")
	exists, err := fileExistsAtPath(generationSettingsFilePath)
	if err != nil {
		return err
	}
	if *exists {
		if g.debugLog {
			log.Printf("[DEBUG] Service Definition Generation Settings exist at %q - skipping", generationSettingsFilePath)
		}
		return nil
	}

	if g.debugLog {
		log.Printf("[DEBUG] Creating Service Definition Generation Settings at %q", generationSettingsFilePath)
	}
	code = codeForServiceDefinitionGenerationSettings(g.data.NamespaceForService, g.data.ServiceName)
	if err := writeToFile(generationSettingsFilePath, code); err != nil {
		return fmt.Errorf("generating Service Definition Generation Settings into %q: %+v", generationSettingsFilePath, err)
	}

	return nil
}
