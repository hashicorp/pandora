package dataapigenerator

import (
	"fmt"
	"path"
)

func (s Service) generateTerraformDefinitions() error {
	containsTerraformResources := false
	for _, v := range s.data.Resources {
		if v.Terraform != nil {
			containsTerraformResources = len(v.Terraform.DataSources) > 0 || len(v.Terraform.Resources) > 0
		}
	}
	if !containsTerraformResources {
		// move along, nothing to see here.
		return nil
	}

	if err := recreateDirectory(s.workingDirectoryForTerraform, s.logger); err != nil {
		return fmt.Errorf("generating Terraform Definition for Namespace %q: %+v", s.namespaceForTerraform, err)
	}

	for resourceName, resource := range s.data.Resources {
		if resource.Terraform == nil {
			continue
		}

		// TODO: generate Data Sources
		//for name, details := range resource.Terraform.DataSources {
		//  fileName := path.Join(generationData.workingDirectoryForTerraform, fmt.Sprintf("%s-DataSource.cs", details.DataSourceName))
		//	if debug {
		//		s.logger.Trace(fmt.Sprintf("Generating Data Source into %q", fileName))
		//	}
		//
		//}

		for label, details := range resource.Terraform.Resources {
			fileName := path.Join(s.workingDirectoryForTerraform, fmt.Sprintf("%s-Resource.cs", details.ResourceName))
			s.logger.Trace(fmt.Sprintf("Generating Resource into %q", fileName))

			resourcePackageName := s.packageNameForResource(resourceName)
			code := codeForTerraformResourceDefinition(s.namespaceForTerraform, s.apiVersionPackageName, resourcePackageName, label, details)
			if err := writeToFile(fileName, code); err != nil {
				return fmt.Errorf("generating Terraform Resource Definition for %q: %+v", label, err)
			}
		}
	}

	return nil
}
