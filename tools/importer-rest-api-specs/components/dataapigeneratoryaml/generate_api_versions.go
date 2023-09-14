package dataapigeneratoryaml

import (
	"fmt"
	"log"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateApiVersions(apiVersion models.AzureApiDefinition) error {
	if err := s.generateVersionDefinition(apiVersion); err != nil {
		return fmt.Errorf("generating Version Definition for Namespace %q: %+v", s.namespaceForApiVersion, err)
	}
	
	for resourceName, resource := range apiVersion.Resources {
		s.logger.Trace(fmt.Sprintf("Generating Resource %q for API Version %q", resourceName, s.namespaceForApiVersion))
		outputDirectory := s.workingDirectoryForResource(resourceName)
		resourceMetadata := s.resourceDetails(resourceName)
		s.logger("%s, %s", outputDirectory, resourceMetadata)
		if err := s.generateResources(resourceName, resourceMetadata, resource, outputDirectory); err != nil {
			return fmt.Errorf("generating Resource %q for %s: %+v", resourceName, resourceMetadata, err)
		}
	}

	return nil
}
