package pipeline

import (
	"fmt"
	"regexp"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/hcl/v2"
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
				example, err := convertBasicTestToUsableExample(resourceValue.Tests)
				if err != nil {
					return nil, err
				}
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

func convertBasicTestToUsableExample(tests resourcemanager.TerraformResourceTestsDefinition) (string, error) {
	example := tests.BasicConfiguration
	if tests.TemplateConfiguration != nil {
		example = *tests.TemplateConfiguration + example
	}
	example = switchOutTestSpecificValues(example)
	var err error
	example, err = switchOutLocalsUsage(example)
	if err != nil {
		return "", err
	}

	example = strings.TrimSpace(string(hclwrite.Format([]byte(example))))
	return example, nil
}

func switchOutLocalsUsage(input string) (string, error) {
	output := input
	re := regexp.MustCompile("[-][$][{](.*)[}]")
	output = re.ReplaceAllLiteralString(output, "")

	// Replacing any interpolation placeholder (from HCL tempalte locals) to be able to parse the HCL
	re = regexp.MustCompile(`%(\[\d\])?[dq]`)
	output = re.ReplaceAllLiteralString(output, `""`)

	testVariables := map[string]string{
		// TODO: add more
		"random_integer":   "21",
		"primary_location": `"West Europe"`,
	}
	for variable, replacement := range testVariables {
		output = strings.ReplaceAll(output, fmt.Sprintf("${local.%s}", variable), replacement)
		output = strings.ReplaceAll(output, fmt.Sprintf("local.%s", variable), replacement)
	}

	f, diags := hclwrite.ParseConfig([]byte(output), "", hcl.InitialPos)
	if diags.HasErrors() {
		return "", fmt.Errorf(diags.Error())
	}
	if blk := f.Body().FirstMatchingBlock("locals", nil); blk != nil {
		f.Body().RemoveBlock(blk)
	}
	output = string(f.Bytes())

	output = strings.TrimSpace(string(hclwrite.Format([]byte(output))))
	return output, nil
}

func switchOutTestSpecificValues(input string) string {
	output := input

	output = strings.ReplaceAll(output, "acctest", "example")
	output = strings.ReplaceAll(output, "acc", "example")
	output = strings.ReplaceAll(output, "test", "example")

	// azurerm_load_test is a special-case, which gets replaced with `azurerm_load_example`, so let's fix that
	output = strings.ReplaceAll(output, "azurerm_load_example", "azurerm_load_test")

	return output
}
