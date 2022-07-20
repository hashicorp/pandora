package dataapigenerator

import (
	"fmt"
	"log"
)

func (s Service) generateApiVersions() error {
	generator := newPackageDefinitionGenerator(s.generationData, s.debugLog)

	if err := generator.generateVersionDefinition(s.data.Resources, s.generationData.WorkingDirectoryForApiVersion); err != nil {
		return fmt.Errorf("generating Version Definition for Namespace %q: %+v", s.generationData.NamespaceForApiVersion, err)
	}

	for resourceName, resource := range s.data.Resources {
		if s.debugLog {
			log.Printf("Generating Resource at %q", resourceName)
		}
		outputDirectory := s.generationData.workingDirectoryForResource(resourceName)
		namespace := s.generationData.namespaceForResource(resourceName)
		if err := generator.generateResources(resourceName, namespace, resource, outputDirectory); err != nil {
			return fmt.Errorf("generating Resource %q (Namespace %q): %+v", resourceName, namespace, err)
		}
	}

	return nil
}
