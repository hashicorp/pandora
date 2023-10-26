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

	// Remove the existing directory if it exists - whilst creating this directory all the time might seem
	// problematic, it won't be tracked in Git if it contains no files, so this should be fine.
	if err := recreateDirectory(s.workingDirectoryForTerraform, s.logger); err != nil {
		return fmt.Errorf("recreating the Terraform Directory at %q: %+v", s.workingDirectoryForTerraform, err)
	}

	if !containsTerraformResources {
		// move along, nothing to see here.
		return nil
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
