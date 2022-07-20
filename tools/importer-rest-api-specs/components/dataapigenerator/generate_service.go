package dataapigenerator

import (
	"fmt"
	"log"
)

func (s Service) generateServiceDefinitions() error {
	if s.debugLog {
		log.Printf("[DEBUG] Processing Service %q..", s.data.ServiceName)
	}

	excludeList := []string{
		// TODO: presumably we can remove this once https://github.com/hashicorp/pandora/issues/403
		// is resolved
		"ServiceDefinition-GenerationSetting.cs",
	}
	if err := recreateDirectoryExcludingFiles(s.generationData.WorkingDirectoryForService, excludeList, s.debugLog); err != nil {
		return fmt.Errorf("recreating %q: %+v", s.generationData.WorkingDirectoryForService, err)
	}

	// finally let's output the new Service Definition
	generator := newPackageDefinitionGenerator(s.generationData, s.debugLog)
	if err := generator.generateServiceDefinition(s.data); err != nil {
		return fmt.Errorf("generating Service Definition for Namespace %q: %+v", s.generationData.NamespaceForService, err)
	}

	return nil
}
