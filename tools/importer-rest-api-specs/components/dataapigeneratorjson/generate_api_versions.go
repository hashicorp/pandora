package dataapigeneratorjson

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateApiVersions(apiVersion models.AzureApiDefinition) error {
	if err := s.generateVersionDefinition(apiVersion); err != nil {
		return fmt.Errorf("generating Version Definition for API Version %q: %+v", apiVersion.ApiVersion, err)
	}

	for resourceName, resource := range apiVersion.Resources {
		s.logger.Trace(fmt.Sprintf("Generating Resource %q for API Version %q", resourceName, apiVersion.ApiVersion))
		outputDirectory := s.workingDirectoryForResource(resourceName)
		s.logger.Debug(fmt.Sprintf("Outputting API Resource %q to %q", resourceName, outputDirectory))
		logger := s.logger.Named(fmt.Sprintf("Service %q / API Version %q / Resource %q", s.serviceName, apiVersion.ApiVersion, resourceName))
		if err := s.generateResources(resourceName, resource, outputDirectory, logger); err != nil {
			return fmt.Errorf("generating Resource %q: %+v", resourceName, err)
		}
	}

	return nil
}
