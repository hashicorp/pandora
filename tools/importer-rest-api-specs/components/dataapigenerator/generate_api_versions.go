package dataapigenerator

import (
	"fmt"
	"log"
)

func (s Service) generateApiVersions() error {
	if err := s.generateVersionDefinition(); err != nil {
		return fmt.Errorf("generating Version Definition for Namespace %q: %+v", s.NamespaceForApiVersion, err)
	}

	for resourceName, resource := range s.data.Resources {
		if s.debugLog {
			log.Printf("Generating Resource at %q", resourceName)
		}
		outputDirectory := s.workingDirectoryForResource(resourceName)
		namespace := s.namespaceForResource(resourceName)
		if err := s.generateResources(resourceName, namespace, resource, outputDirectory); err != nil {
			return fmt.Errorf("generating Resource %q (Namespace %q): %+v", resourceName, namespace, err)
		}
	}

	return nil
}
