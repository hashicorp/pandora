package dataapigenerator

import (
	"fmt"
	"log"
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

	if err := recreateDirectory(s.generationData.WorkingDirectoryForTerraform, s.debugLog); err != nil {
		return fmt.Errorf("generating Terraform Definition for Namespace %q: %+v", s.generationData.NamespaceForTerraform, err)
	}

	for resourceName, resource := range s.data.Resources {
		if resource.Terraform == nil {
			continue
		}

		// TODO: generate Data Sources
		//for name, details := range resource.Terraform.DataSources {
		//  fileName := path.Join(generationData.WorkingDirectoryForTerraform, fmt.Sprintf("%s-DataSource.cs", details.DataSourceName))
		//	if debug {
		//		log.Printf("Generating Data Source into %q", fileName)
		//	}
		//
		//}

		for label, details := range resource.Terraform.Resources {
			fileName := path.Join(s.generationData.WorkingDirectoryForTerraform, fmt.Sprintf("%s-Resource.cs", details.ResourceName))
			if s.debugLog {
				log.Printf("Generating Resource into %q", fileName)
			}

			resourcePackageName := s.generationData.packageNameForResource(resourceName)
			code := codeForTerraformResourceDefinition(s.generationData.NamespaceForTerraform, s.generationData.ApiVersionPackageName, resourcePackageName, label, details)
			if err := writeToFile(fileName, code); err != nil {
				return fmt.Errorf("generating Terraform Resource Definition for %q: %+v", label, err)
			}
		}
	}

	return nil
}
