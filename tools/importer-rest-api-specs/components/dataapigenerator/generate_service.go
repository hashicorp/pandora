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
	if err := recreateDirectoryExcludingFiles(s.workingDirectoryForService, excludeList, s.debugLog); err != nil {
		return fmt.Errorf("recreating %q: %+v", s.workingDirectoryForService, err)
	}

	// finally let's output the new Service Definition
	if err := s.generateServiceDefinition(s.data); err != nil {
		return fmt.Errorf("generating Service Definition for Namespace %q: %+v", s.namespaceForService, err)
	}

	return nil
}
