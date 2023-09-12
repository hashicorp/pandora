package dataapigeneratoryaml

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateApiVersions(apiVersion models.AzureApiDefinition) error {
	if err := s.generateVersionDefinition(apiVersion); err != nil {
		return fmt.Errorf("generating Version Definition for Namespace %q: %+v", s.namespaceForApiVersion, err)
	}

	// TODO uncomment below and work through the remaining templates
	//	for resourceName, _ := range apiVersion.Resources {
	//		s.logger.Trace(fmt.Sprintf("Generating Resource %q for API Version %q", resourceName, s.namespaceForApiVersion))
	//		outputDirectory := s.workingDirectoryForResource(resourceName)
	//		namespace := s.namespaceForResource(resourceName)
	//		log.Printf("%s, %s", outputDirectory, namespace)
	//		if err := s.generateResources(resourceName, namespace, resource, outputDirectory); err != nil {
	//			return fmt.Errorf("generating Resource %q (Namespace %q): %+v", resourceName, namespace, err)
	//		}
	//	}

	return nil
}
