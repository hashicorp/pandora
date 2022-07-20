package dataapigenerator

import (
	"fmt"
	"log"
	"path"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

func NewService(data parser.ParsedData, outputDirectory, rootNamespace, swaggerGitSha string, resourceProvider, terraformPackageName *string, debugLog bool) *Service {
	normalisedServiceName := strings.ReplaceAll(data.ServiceName, "-", "")
	serviceNamespace := fmt.Sprintf("%s.%s", rootNamespace, strings.Title(normalisedServiceName))
	serviceWorkingDirectory := path.Join(outputDirectory, rootNamespace, strings.Title(normalisedServiceName))
	terraformNamespace := fmt.Sprintf("%s.Terraform", serviceNamespace)
	terraformWorkingDirectory := path.Join(serviceWorkingDirectory, "Terraform")
	normalizedApiVersion := normalizeApiVersion(data.ApiVersion)

	return &Service{
		data:                 data,
		debugLog:             debugLog,
		outputDirectory:      outputDirectory,
		resourceProvider:     resourceProvider,
		rootNamespace:        rootNamespace,
		swaggerGitSha:        swaggerGitSha,
		terraformPackageName: terraformPackageName,

		// TODO: make these private
		ApiVersionPackageName:         normalizedApiVersion,
		ResourceProvider:              resourceProvider,
		TerraformPackageName:          terraformPackageName,
		NamespaceForApiVersion:        fmt.Sprintf("%s.%s", serviceNamespace, normalizedApiVersion),
		NamespaceForService:           serviceNamespace,
		NamespaceForTerraform:         terraformNamespace,
		WorkingDirectoryForService:    serviceWorkingDirectory,
		WorkingDirectoryForTerraform:  terraformWorkingDirectory,
		WorkingDirectoryForApiVersion: path.Join(serviceWorkingDirectory, normalizedApiVersion),
	}
}

func (s *Service) Generate() error {
	if s.debugLog {
		log.Printf("[STAGE] Updating the Output Revision ID to %q", s.swaggerGitSha)
	}
	if err := outputRevisionId(s.outputDirectory, s.rootNamespace, s.swaggerGitSha); err != nil {
		return fmt.Errorf("outputting the Revision Id: %+v", err)
	}

	if err := s.generateServiceDefinitions(); err != nil {
		return fmt.Errorf("generating Service Definitions: %+v", err)
	}

	if s.debugLog {
		log.Printf("[STAGE] Generating API Definitions..")
	}
	if err := s.generateApiVersions(); err != nil {
		return fmt.Errorf("generating API Versions: %+v", err)
	}

	if s.terraformPackageName != nil {
		if s.debugLog {
			log.Printf("[DEBUG] Generating Terraform Definitions")
		}

		if err := s.generateTerraformDefinitions(); err != nil {
			return fmt.Errorf("generating Terraform Definitions: %+v", err)
		}
	} else {
		if s.debugLog {
			log.Printf("[DEBUG] Skipping generating Terraform Definitions as service isn't defined")
		}
	}
	return nil
}
