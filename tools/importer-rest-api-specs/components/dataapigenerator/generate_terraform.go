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
			// output the Terraform Resource Definition
			resourceFileName := path.Join(s.workingDirectoryForTerraform, fmt.Sprintf("%s-Resource.cs", details.ResourceName))
			s.logger.Trace(fmt.Sprintf("Generating Resource into %q", resourceFileName))
			resourcePackageName := s.packageNameForResource(resourceName)
			resourceDefinitionCode := codeForTerraformResourceDefinition(s.namespaceForTerraform, s.apiVersionPackageName, resourcePackageName, label, details)
			if err := writeToFile(resourceFileName, resourceDefinitionCode); err != nil {
				return fmt.Errorf("generating Terraform Resource Definition for %q: %+v", label, err)
			}

			// TODO: output Mappings

			// output the Schema for this Terraform Resource
			resourceSchemaFileName := path.Join(s.workingDirectoryForTerraform, fmt.Sprintf("%s-Resource-Schema.cs", details.ResourceName))
			s.logger.Trace(fmt.Sprintf("Generating Resource Schema into %q", resourceSchemaFileName))
			resourceSchemaCode := codeForTerraformSchemaDefinition(s.namespaceForTerraform, details)
			if err := writeToFile(resourceSchemaFileName, resourceSchemaCode); err != nil {
				return fmt.Errorf("generating Terraform Resource Schema for %q: %+v", label, err)
			}

			// output the Tests for this Terraform Resource
			resourceTestsFileName := path.Join(s.workingDirectoryForTerraform, fmt.Sprintf("%s-Resource-Tests.cs", details.ResourceName))
			s.logger.Trace(fmt.Sprintf("Generating Resource Schema into %q", resourceTestsFileName))
			resourceTestsCode := codeForTerraformResourceTestDefinition(s.namespaceForTerraform, details)
			if err := writeToFile(resourceTestsFileName, resourceTestsCode); err != nil {
				return fmt.Errorf("generating Terraform Resource Tests for %q: %+v", label, err)
			}
		}
	}

	return nil
}
