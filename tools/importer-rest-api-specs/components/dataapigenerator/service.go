package dataapigenerator

import (
	"fmt"
	"log"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

type Service struct {
	Data                       parser.ParsedData
	DebugLog                   bool
	OutputDirectory            string
	ResourceProvider           *string
	RootNamespace              string
	SwaggerGitSha              string
	TerraformServiceDefinition *definitions.ServiceDefinition

	terraformPackageName *string
}

func (s *Service) Generate() error {
	if s.DebugLog {
		log.Printf("[STAGE] Updating the Output Revision ID to %q", s.SwaggerGitSha)
	}
	if err := outputRevisionId(s.OutputDirectory, s.RootNamespace, s.SwaggerGitSha); err != nil {
		return fmt.Errorf("outputting the Revision Id: %+v", err)
	}

	if s.TerraformServiceDefinition != nil {
		s.terraformPackageName = &s.TerraformServiceDefinition.TerraformPackageName
	}
	if err := generateServiceDefinitions(s.Data, s.OutputDirectory, s.RootNamespace, s.ResourceProvider, s.terraformPackageName, s.DebugLog); err != nil {
		return fmt.Errorf("generating Service Definitions: %+v", err)
	}

	if s.DebugLog {
		log.Printf("[STAGE] Generating API Definitions..")
	}
	if err := generateApiVersions(s.Data, s.OutputDirectory, s.RootNamespace, s.ResourceProvider, s.terraformPackageName, s.DebugLog); err != nil {
		return fmt.Errorf("generating API Versions: %+v", err)
	}

	if s.terraformPackageName != nil {
		if s.DebugLog {
			log.Printf("[DEBUG] Generating Terraform Definitions")
		}

		if err := generateTerraformDefinitions(s.Data, s.OutputDirectory, s.RootNamespace, s.ResourceProvider, s.terraformPackageName, s.DebugLog); err != nil {
			return fmt.Errorf("generating Terraform Definitions: %+v", err)
		}
	} else {
		if s.DebugLog {
			log.Printf("[DEBUG] Skipping generating Terraform Definitions as service isn't defined")
		}
	}
	return nil
}
