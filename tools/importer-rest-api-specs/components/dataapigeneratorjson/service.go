package dataapigeneratorjson

import (
	"fmt"
	"path"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func NewForService(serviceName, outputDirectory string, resourceProvider, terraformPackageName *string, logger hclog.Logger) *Generator {
	normalisedServiceName := strings.ReplaceAll(serviceName, "-", "")
	serviceWorkingDirectory := path.Join(outputDirectory, strings.Title(normalisedServiceName))
	terraformWorkingDirectory := path.Join(serviceWorkingDirectory, "Terraform")
	terraformTestsWorkingDirectory := path.Join(terraformWorkingDirectory, "Tests")

	return &Generator{
		logger:                            logger,
		outputDirectory:                   outputDirectory,
		resourceProvider:                  resourceProvider,
		serviceName:                       serviceName,
		terraformPackageName:              terraformPackageName,
		workingDirectoryForService:        serviceWorkingDirectory,
		workingDirectoryForTerraform:      terraformWorkingDirectory,
		workingDirectoryForTerraformTests: terraformTestsWorkingDirectory,
	}
}

func NewForApiVersion(serviceName, apiVersion, outputDirectory string, resourceProvider, terraformPackageName *string, logger hclog.Logger) *Generator {
	service := NewForService(serviceName, outputDirectory, resourceProvider, terraformPackageName, logger)

	service.workingDirectoryForApiVersion = path.Join(service.workingDirectoryForService, apiVersion)
	return service
}

func (s Generator) GenerateForService(apiVersions []models.AzureApiDefinition) error {
	s.logger.Debug(fmt.Sprintf("[STAGE] Generating the Service Definitions.."))
	if err := s.generateServiceDefinitions(apiVersions); err != nil {
		return fmt.Errorf("generating Service Definitions: %+v", err)
	}

	return nil
}

func (s Generator) GenerateForApiVersion(apiVersion models.AzureApiDefinition) error {
	s.logger.Debug("[STAGE] Generating API Definitions..")
	if err := s.generateApiVersions(apiVersion); err != nil {
		return fmt.Errorf("generating API Versions: %+v", err)
	}

	if s.terraformPackageName != nil {
		s.logger.Debug("Generating Terraform Definitions")

		if err := s.generateTerraformDefinitions(apiVersion); err != nil {
			return fmt.Errorf("generating Terraform Definitions: %+v", err)
		}
	} else {
		s.logger.Debug("Skipping generating Terraform Definitions as service isn't defined")
	}
	return nil
}
