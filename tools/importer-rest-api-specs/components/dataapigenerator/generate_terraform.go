package dataapigenerator

import (
	"fmt"
	"log"
	"path"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func generateTerraformDefinitions(input parser.ParsedData, workingDirectory, rootNamespace string, resourceProvider, terraformPackageName *string, debug bool) error {
	containsTerraformResources := false
	for _, v := range input.Resources {
		if v.Terraform != nil {
			containsTerraformResources = len(v.Terraform.DataSources) > 0 || len(v.Terraform.Resources) > 0
		}
	}
	if !containsTerraformResources {
		// move along, nothing to see here.
		return nil
	}

	data := generationDataForServiceAndApiVersion(input.ServiceName, input.ApiVersion, workingDirectory, rootNamespace, resourceProvider, terraformPackageName)
	generator := newPackageDefinitionGenerator(data, debug)

	if err := recreateDirectory(data.WorkingDirectoryForTerraform, debug); err != nil {
		return fmt.Errorf("generating Terraform Definition for Namespace %q: %+v", data.NamespaceForTerraform, err)
	}

	for resourceName, resource := range input.Resources {
		if resource.Terraform == nil {
			continue
		}

		// TODO: generate Data Sources
		//for name, details := range resource.Terraform.DataSources {
		//  fileName := path.Join(data.WorkingDirectoryForTerraform, fmt.Sprintf("%s-DataSource.cs", details.DataSourceName))
		//	if debug {
		//		log.Printf("Generating Data Source into %q", fileName)
		//	}
		//
		//}

		for label, details := range resource.Terraform.Resources {
			fileName := path.Join(data.WorkingDirectoryForTerraform, fmt.Sprintf("%s-Resource.cs", details.ResourceName))
			if debug {
				log.Printf("Generating Resource into %q", fileName)
			}

			if err := generator.generateTerraformResourceDefinition(fileName, data.NamespaceForTerraform, data.ApiVersionPackageName, data.packageNameForResource(resourceName), label, details); err != nil {
				return fmt.Errorf("generating Terraform Resource Definition for %q: %+v", label, err)
			}
		}
	}

	return nil
}

func (g PandoraDefinitionGenerator) generateTerraformResourceDefinition(fileName, terraformNamespace, apiVersion, apiResource, resourceLabel string, details resourcemanager.TerraformResourceDetails) error {
	code := codeForTerraformResourceDefinition(terraformNamespace, apiVersion, apiResource, resourceLabel, details)
	return writeToFile(fileName, code)
}
