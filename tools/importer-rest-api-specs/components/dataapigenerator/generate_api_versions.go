package dataapigenerator

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateApiVersions(apiVersion models.AzureApiDefinition) error {
	if err := s.generateVersionDefinition(apiVersion); err != nil {
		return fmt.Errorf("generating Version Definition for Namespace %q: %+v", s.namespaceForApiVersion, err)
	}

	for resourceName, resource := range apiVersion.Resources {
		s.logger.Trace(fmt.Sprintf("Generating Resource %q for API Version %q", resourceName, s.namespaceForApiVersion))
		outputDirectory := s.workingDirectoryForResource(resourceName)
		namespace := s.namespaceForResource(resourceName)
		if err := s.generateResources(resourceName, namespace, resource, outputDirectory); err != nil {
			return fmt.Errorf("generating Resource %q (Namespace %q): %+v", resourceName, namespace, err)
		}
	}

	return nil
}
