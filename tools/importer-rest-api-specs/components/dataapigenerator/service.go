package dataapigenerator

import (
	"fmt"
	"path"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

	"github.com/hashicorp/go-hclog"
)

func NewForService(serviceName, outputDirectory, rootNamespace, swaggerGitSha string, resourceProvider, terraformPackageName *string, logger hclog.Logger) *Generator {
	normalisedServiceName := strings.ReplaceAll(serviceName, "-", "")
	serviceNamespace := fmt.Sprintf("%s.%s", rootNamespace, strings.Title(normalisedServiceName))
	serviceWorkingDirectory := path.Join(outputDirectory, rootNamespace, strings.Title(normalisedServiceName))
	terraformNamespace := fmt.Sprintf("%s.Terraform", serviceNamespace)
	terraformWorkingDirectory := path.Join(serviceWorkingDirectory, "Terraform")

	return &Generator{
		logger:                       logger,
		namespaceForService:          serviceNamespace,
		namespaceForTerraform:        terraformNamespace,
		outputDirectory:              outputDirectory,
		resourceProvider:             resourceProvider,
		rootNamespace:                rootNamespace,
		serviceName:                  serviceName,
		swaggerGitSha:                swaggerGitSha,
		terraformPackageName:         terraformPackageName,
		workingDirectoryForService:   serviceWorkingDirectory,
		workingDirectoryForTerraform: terraformWorkingDirectory,
	}
}

func NewForApiVersion(serviceName, apiVersion, outputDirectory, rootNamespace, swaggerGitSha string, resourceProvider, terraformPackageName *string, logger hclog.Logger) *Generator {
	service := NewForService(serviceName, outputDirectory, rootNamespace, swaggerGitSha, resourceProvider, terraformPackageName, logger)

	normalizedApiVersion := normalizeApiVersion(apiVersion)

	service.apiVersionPackageName = normalizedApiVersion
	service.namespaceForApiVersion = fmt.Sprintf("%s.%s", service.namespaceForService, normalizedApiVersion)
	service.workingDirectoryForApiVersion = path.Join(service.workingDirectoryForService, normalizedApiVersion)

	return service
}

func (s *Generator) GenerateForService(apiVersions []models.AzureApiDefinition) error {
	s.logger.Debug(fmt.Sprintf("[STAGE] Updating the Output Revision ID to %q", s.swaggerGitSha))
	if err := outputRevisionId(s.outputDirectory, s.rootNamespace, s.swaggerGitSha); err != nil {
		return fmt.Errorf("outputting the Revision Id: %+v", err)
	}

	s.logger.Debug(fmt.Sprintf("[STAGE] Generating the Service Definitions.."))
	if err := s.generateServiceDefinitions(apiVersions); err != nil {
		return fmt.Errorf("generating Service Definitions: %+v", err)
	}

	return nil
}

func (s *Generator) GenerateForApiVersion(apiVersion models.AzureApiDefinition) error {
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
