package dataapigeneratorjson

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateTerraformDefinitions(apiVersion models.AzureApiDefinition) error {
	containsTerraformResources := false
	for _, v := range apiVersion.Resources {
		if v.Terraform != nil {
			containsTerraformResources = len(v.Terraform.DataSources) > 0 || len(v.Terraform.Resources) > 0
		}
	}

	if !containsTerraformResources {
		// move along, nothing to see here.
		return nil
	}

	// Since Terraform resources are against a _Service_ not an API version - we should ensure the directory exists
	// rather than recreating it
	// TODO: move the Terraform generation up to the Service level, so that we can recreate this folder safely
	// This being here is a remnant from Resources being pinned to one API version
	if err := ensureDirectoryExists(s.workingDirectoryForTerraform, s.logger); err != nil {
		return fmt.Errorf("ensuring the Terraform Directory at %q exists: %+v", s.workingDirectoryForTerraform, err)
	}
	if err := ensureDirectoryExists(s.workingDirectoryForTerraformTests, s.logger); err != nil {
		return fmt.Errorf("ensuring the Terraform Tests Directory at %q exists: %+v", s.workingDirectoryForTerraformTests, err)
	}

	for resourceName, resource := range apiVersion.Resources {
		if resource.Terraform == nil {
			continue
		}

		s.logger.Debug(fmt.Sprintf("Processing API Resource %q..", resourceName))

		// TODO: generate Data Sources
		//s.logger.Trace("Processing Terraform Data Sources..")
		//for name, details := range resource.Terraform.DataSources {
		//  fileName := path.Join(generationData.workingDirectoryForTerraform, fmt.Sprintf("%s-DataSource.json", details.DataSourceName))
		//	if debug {
		//		s.logger.Trace(fmt.Sprintf("Generating Data Source into %q", fileName))
		//	}
		//
		//}

		s.logger.Trace("Processing Terraform Resources..")
		for label, details := range resource.Terraform.Resources {
			s.logger.Trace(fmt.Sprintf("Generating the Terraform Resource Definition for %q..", label))
			if err := s.generateTerraformResourceDefinition(label, details); err != nil {
				return fmt.Errorf("generating Terraform Resource Definition for %q: %+v", label, err)
			}
			s.logger.Trace(fmt.Sprintf("Generated the Terraform Resource Definition for %q.", label))
		}
	}

	return nil
}
