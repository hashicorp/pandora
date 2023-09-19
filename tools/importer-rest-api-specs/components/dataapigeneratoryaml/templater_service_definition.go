package dataapigeneratoryaml

import (
	"fmt"
	"sort"

	"github.com/go-yaml/yaml"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type ServiceDefinition struct {
	Name                 string   `yaml:"Name"`
	ResourceProvider     string   `yaml:"ResourceProvider,omitempty"`
	TerraformPackageName string   `yaml:"TerraformPackageName,omitempty"`
	TerraformResources   []string `yaml:"TerraformResources,omitempty"`
}

func codeForServiceDefinition(namespace, serviceName string, resourceProvider, terraformPackage *string, apiVersions []models.AzureApiDefinition) ([]byte, error) {
	rp := ""
	if resourceProvider != nil {
		rp = *resourceProvider
	}

	terraformPackageName := ""
	if terraformPackage != nil {
		terraformPackageName = *terraformPackage
	}

	terraformResources := make([]string, 0)
	for _, apiVersion := range apiVersions {
		for _, resource := range apiVersion.Resources {
			if resource.Terraform == nil {
				continue
			}

			for _, v := range resource.Terraform.Resources {
				terraformResources = append(terraformResources, fmt.Sprintf("new Terraform.%sResource(),", v.ResourceName))
			}
		}
	}
	sort.Strings(terraformResources)

	serviceDefinition := ServiceDefinition{
		Name:                 serviceName,
		ResourceProvider:     rp,
		TerraformPackageName: terraformPackageName,
		TerraformResources:   terraformResources,
	}

	data, err := yaml.Marshal(serviceDefinition)
	if err != nil {
		return nil, err
	}

	return data, nil
}

func codeForServiceDefinitionGenerationSettings() ([]byte, error) {
	generate := map[string]bool{
		"Generate": true,
	}

	data, err := yaml.Marshal(&generate)
	if err != nil {
		return nil, err
	}

	return data, nil
}
