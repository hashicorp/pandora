package pipeline

import (
	"fmt"
	"regexp"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/hcl/v2/hclwrite"
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
				example := convertBasicTestToUsableExample(resourceValue.Tests)
				resourceValue.Documentation.ExampleUsageHcl = example
				tfResources[resourceKey] = resourceValue
			}
			v.Terraform.Resources = tfResources
		}
		apiResources[k] = v
	}
	data.Resources = apiResources
	return data, nil
}

func convertBasicTestToUsableExample(tests resourcemanager.TerraformResourceTestsDefinition) string {
	// TODO add the template config once it's filled with the prerequisite resources
	example := strings.Replace(tests.BasicConfiguration, "test", "example", -1)
	example = strings.Replace(example, "acc", "", -1)
	re := regexp.MustCompile("[-][$][{](.*)[}]")
	example = re.ReplaceAllLiteralString(example, "")

	testVariables := map[string]string{
		// TODO: add more
		"random_integer":   "21",
		"primary_location": "West Europe",
	}
	for variable, replacement := range testVariables {
		example = strings.ReplaceAll(example, fmt.Sprintf("${local.%s}", variable), replacement)
		example = strings.ReplaceAll(example, fmt.Sprintf("local.%s", variable), replacement)
	}

	example = strings.TrimSpace(string(hclwrite.Format([]byte(example))))
	return example
}
