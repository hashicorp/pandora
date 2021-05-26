package main

import (
	"fmt"
	"log"
	"os"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/generator"
)

func generateApiVersions(data []parsedData, workingDirectory, rootNamespace string, debug bool) error {
	for _, item := range data {
		// TODO: also generate the ServiceDefinition for this Service

		data := generator.GenerationDataForService(item.ServiceName, item.ApiVersion, workingDirectory, rootNamespace)
		generator := generator.NewPackageDefinitionGenerator(data, debug)

		os.MkdirAll(data.WorkingDirectoryForApiVersion, permissions)
		if err := generator.GenerateVersionDefinitionAndRecreateDirectory(item.Resources, data.WorkingDirectoryForApiVersion, permissions); err != nil {
			return fmt.Errorf("generating Version Definition for Namespace %q: %+v", data.NamespaceForApiVersion, err)
		}

		for resourceName, resource := range item.Resources {
			if debug {
				log.Printf("Generating Resource at %q", resourceName)
			}
			outputDirectory := data.WorkingDirectoryForResource(resourceName)
			os.MkdirAll(outputDirectory, permissions)
			// TODO - Need to delete api path here if it already exists.
			namespace := data.NamespaceForResource(resourceName)
			if err := generator.GenerateResources(resourceName, namespace, resource, outputDirectory); err != nil {
				return fmt.Errorf("generating Resource %q (Namespace %q): %+v", resourceName, namespace, err)
			}
		}
	}

	return nil
}
