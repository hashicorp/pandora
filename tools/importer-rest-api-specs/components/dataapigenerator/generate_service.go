package dataapigenerator

import (
	"fmt"
	"log"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

func generateServiceDefinitions(input parser.ParsedData, workingDirectory, rootNamespace string, resourceProvider, terraformPackageName *string, debug bool) error {
	if debug {
		log.Printf("[DEBUG] Processing Service %q..", input.ServiceName)
	}
	data := generationDataForService(input.ServiceName, workingDirectory, rootNamespace, resourceProvider, terraformPackageName)

	excludeList := []string{
		// TODO: presumably we can remove this once https://github.com/hashicorp/pandora/issues/403
		// is resolved
		"ServiceDefinition-GenerationSetting.cs",
	}
	if err := recreateDirectoryExcludingFiles(data.WorkingDirectoryForService, excludeList, debug); err != nil {
		return fmt.Errorf("recreating %q: %+v", data.WorkingDirectoryForService, err)
	}

	// finally let's output the new Service Definition
	generator := newPackageDefinitionGenerator(data, debug)
	if err := generator.generateServiceDefinition(input); err != nil {
		return fmt.Errorf("generating Service Definition for Namespace %q: %+v", data.NamespaceForService, err)
	}

	return nil
}
