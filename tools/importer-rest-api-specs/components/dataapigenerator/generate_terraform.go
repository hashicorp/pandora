package dataapigenerator

import (
	"fmt"
	"path"
	"strings"

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

	if err := recreateDirectory(s.workingDirectoryForTerraform, s.logger); err != nil {
		return fmt.Errorf("generating Terraform Definition for Namespace %q: %+v", s.namespaceForTerraform, err)
	}

	for resourceName, resource := range apiVersion.Resources {
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

			// output the Schema for this Terraform Resource
			resourceSchemaFileName := path.Join(s.workingDirectoryForTerraform, fmt.Sprintf("%s-Resource-Schema.cs", details.ResourceName))
			resourceSchema, ok := details.SchemaModels[details.SchemaModelName]
			if !ok {
				return fmt.Errorf("the Schema Model %q was not found", details.SchemaModelName)
			}
			s.logger.Trace(fmt.Sprintf("Generating Resource Schema into %q", resourceSchemaFileName))
			resourceSchemaCode, err := codeForTerraformSchemaModelDefinition(s.namespaceForTerraform, details.SchemaModelName, resourceSchema, details, resource)
			if err != nil {
				return fmt.Errorf("generating Terraform Resource Schema for %s: %+v", label, err)
			}
			if err := writeToFile(resourceSchemaFileName, *resourceSchemaCode); err != nil {
				return fmt.Errorf("writing Terraform Resource Schema for %q: %+v", label, err)
			}

			// then output the other Schema types for this Terraform Resource
			for modelName, model := range details.SchemaModels {
				// this is output above
				if modelName == details.SchemaModelName {
					continue
				}

				nestedSchemaFileName := path.Join(s.workingDirectoryForTerraform, fmt.Sprintf("%s-Resource-Schema-%s.cs", details.ResourceName, strings.TrimPrefix(modelName, details.SchemaModelName)))
				s.logger.Trace(fmt.Sprintf("Generating Model Schema into %q", nestedSchemaFileName))
				nestedSchemaCode, err := codeForTerraformSchemaModelDefinition(s.namespaceForTerraform, modelName, model, details, resource)
				if err != nil {
					return fmt.Errorf("generating Terraform Resource Schema for Nested Schema %q: %+v", label, err)
				}
				if err := writeToFile(nestedSchemaFileName, *nestedSchemaCode); err != nil {
					return fmt.Errorf("writing Terraform Resource Schema for %q: %+v", label, err)
				}
			}

			// output the Mappings for this Terraform Resource
			resourceMappingsFileName := path.Join(s.workingDirectoryForTerraform, fmt.Sprintf("%s-Resource-Mappings.cs", details.ResourceName))
			s.logger.Trace(fmt.Sprintf("Generating Resource Mappings into %q", resourceMappingsFileName))
			resourceMappingsCode := codeForTerraformResourceMappings(s.namespaceForTerraform, details)
			if err := writeToFile(resourceMappingsFileName, resourceMappingsCode); err != nil {
				return fmt.Errorf("generating Terraform Resource Mappings for %q: %+v", label, err)
			}

			// output the Tests for this Terraform Resource
			resourceTestsFileName := path.Join(s.workingDirectoryForTerraform, fmt.Sprintf("%s-Resource-Tests.cs", details.ResourceName))
			s.logger.Trace(fmt.Sprintf("Generating Resource Tests into %q", resourceTestsFileName))
			resourceTestsCode := codeForTerraformResourceTestDefinition(s.namespaceForTerraform, details)
			if err := writeToFile(resourceTestsFileName, resourceTestsCode); err != nil {
				return fmt.Errorf("generating Terraform Resource Tests for %q: %+v", label, err)
			}
		}
	}

	return nil
}
