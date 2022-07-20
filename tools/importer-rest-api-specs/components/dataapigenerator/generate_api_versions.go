package dataapigenerator

import (
	"fmt"
	"log"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

func generateApiVersions(input parser.ParsedData, workingDirectory, rootNamespace string, resourceProvider, terraformPackageName *string, debug bool) error {
	data := generationDataForServiceAndApiVersion(input.ServiceName, input.ApiVersion, workingDirectory, rootNamespace, resourceProvider, terraformPackageName)
	generator := newPackageDefinitionGenerator(data, debug)

	if err := generator.generateVersionDefinition(input.Resources, data.WorkingDirectoryForApiVersion); err != nil {
		return fmt.Errorf("generating Version Definition for Namespace %q: %+v", data.NamespaceForApiVersion, err)
	}

	for resourceName, resource := range input.Resources {
		if debug {
			log.Printf("Generating Resource at %q", resourceName)
		}
		outputDirectory := data.workingDirectoryForResource(resourceName)
		namespace := data.namespaceForResource(resourceName)
		if err := generator.generateResources(resourceName, namespace, resource, outputDirectory); err != nil {
			return fmt.Errorf("generating Resource %q (Namespace %q): %+v", resourceName, namespace, err)
		}
	}

	return nil
}
