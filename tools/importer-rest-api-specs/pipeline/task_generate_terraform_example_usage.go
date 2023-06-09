package pipeline

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/examples"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (t pipelineTask) generateTerraformExampleUsage(data *models.AzureApiDefinition, providerPrefix string, logger hclog.Logger) (*models.AzureApiDefinition, error) {
	apiResources := make(map[string]models.AzureApiResource)
	for k, v := range data.Resources {
		if v.Terraform != nil {
			// TODO: support Data Sources

			tfResources := make(map[string]resourcemanager.TerraformResourceDetails)
			for resourceKey, resourceValue := range v.Terraform.Resources {
				example, err := examples.ResourceExampleFromTests(resourceValue.Tests)
				if err != nil {
					return nil, fmt.Errorf("building Example Usage from the Tests for Resource %q: %+v", resourceKey, err)
				}
				resourceValue.Documentation.ExampleUsageHcl = *example
				tfResources[resourceKey] = resourceValue
			}
			v.Terraform.Resources = tfResources
		}
		apiResources[k] = v
	}
	data.Resources = apiResources
	return data, nil
}
