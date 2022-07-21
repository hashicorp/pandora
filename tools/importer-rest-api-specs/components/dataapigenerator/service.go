package dataapigenerator

import (
	"fmt"
	"path"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser"

	"github.com/hashicorp/go-hclog"
)

func NewService(data parser.ParsedData, outputDirectory, rootNamespace, swaggerGitSha string, resourceProvider, terraformPackageName *string, logger hclog.Logger) *Service {
	normalisedServiceName := strings.ReplaceAll(data.ServiceName, "-", "")
	serviceNamespace := fmt.Sprintf("%s.%s", rootNamespace, strings.Title(normalisedServiceName))
	serviceWorkingDirectory := path.Join(outputDirectory, rootNamespace, strings.Title(normalisedServiceName))
	terraformNamespace := fmt.Sprintf("%s.Terraform", serviceNamespace)
	terraformWorkingDirectory := path.Join(serviceWorkingDirectory, "Terraform")
	normalizedApiVersion := normalizeApiVersion(data.ApiVersion)

	return &Service{
		apiVersionPackageName:         normalizedApiVersion,
		data:                          data,
		logger:                        logger,
		namespaceForApiVersion:        fmt.Sprintf("%s.%s", serviceNamespace, normalizedApiVersion),
		namespaceForService:           serviceNamespace,
		namespaceForTerraform:         terraformNamespace,
		outputDirectory:               outputDirectory,
		resourceProvider:              resourceProvider,
		rootNamespace:                 rootNamespace,
		swaggerGitSha:                 swaggerGitSha,
		terraformPackageName:          terraformPackageName,
		workingDirectoryForService:    serviceWorkingDirectory,
		workingDirectoryForTerraform:  terraformWorkingDirectory,
		workingDirectoryForApiVersion: path.Join(serviceWorkingDirectory, normalizedApiVersion),
	}
}

func (s *Service) Generate() error {
	s.logger.Debug(fmt.Sprintf("[STAGE] Updating the Output Revision ID to %q", s.swaggerGitSha))
	if err := outputRevisionId(s.outputDirectory, s.rootNamespace, s.swaggerGitSha); err != nil {
		return fmt.Errorf("outputting the Revision Id: %+v", err)
	}

	if err := s.generateServiceDefinitions(); err != nil {
		return fmt.Errorf("generating Service Definitions: %+v", err)
	}

	s.logger.Debug("[STAGE] Generating API Definitions..")
	if err := s.generateApiVersions(); err != nil {
		return fmt.Errorf("generating API Versions: %+v", err)
	}

	if s.terraformPackageName != nil {
		s.logger.Debug("Generating Terraform Definitions")

		if err := s.generateTerraformDefinitions(); err != nil {
			return fmt.Errorf("generating Terraform Definitions: %+v", err)
		}
	} else {
		s.logger.Debug("Skipping generating Terraform Definitions as service isn't defined")
	}
	return nil
}
