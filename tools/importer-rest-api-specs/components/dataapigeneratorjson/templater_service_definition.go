package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"sort"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type ServiceDefinition struct {
	Name                 string   `json:"Name"`
	ResourceProvider     string   `json:"ResourceProvider,omitempty"`
	TerraformPackageName string   `json:"TerraformPackageName,omitempty"`
	TerraformResources   []string `json:"TerraformResources,omitempty"`
	Generate             bool     `json:"Generate"`
}

func codeForServiceDefinition(serviceName string, resourceProvider, terraformPackage *string, apiVersions []models.AzureApiDefinition) ([]byte, error) {
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
		Generate:             true,
	}

	data, err := json.MarshalIndent(serviceDefinition, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}
