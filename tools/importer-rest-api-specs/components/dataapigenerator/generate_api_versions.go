package dataapigenerator

import (
	"fmt"
)

func (s Service) generateApiVersions() error {
	if err := s.generateVersionDefinition(); err != nil {
		return fmt.Errorf("generating Version Definition for Namespace %q: %+v", s.namespaceForApiVersion, err)
	}

	for resourceName, resource := range s.data.Resources {
		s.logger.Trace(fmt.Sprintf("Generating Resource %q for API Version %q", resourceName, s.namespaceForApiVersion))
		outputDirectory := s.workingDirectoryForResource(resourceName)
		namespace := s.namespaceForResource(resourceName)
		if err := s.generateResources(resourceName, namespace, resource, outputDirectory); err != nil {
			return fmt.Errorf("generating Resource %q (Namespace %q): %+v", resourceName, namespace, err)
		}
	}

	return nil
}
