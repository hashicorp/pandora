package dataapigeneratorjson

import (
	"encoding/json"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTerraformResourceTestDefinition(details resourcemanager.TerraformResourceDetails) ([]byte, error) {
	testConfig := models.TerraformResourceTestConfig{
		Basic:          prepareTerraformTestConfigForOutput(details.Tests.BasicConfiguration),
		RequiresImport: prepareTerraformTestConfigForOutput(details.Tests.RequiresImportConfiguration),
		CompleteConfig: conditionallyAddTestOutput(details.Tests.CompleteConfiguration),
		TemplateConfig: conditionallyAddTestOutput(details.Tests.TemplateConfiguration),
	}

	data, err := json.MarshalIndent(testConfig, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}

func conditionallyAddTestOutput(input *string) *string {
	if input != nil {
		val := prepareTerraformTestConfigForOutput(*input)
		return &val
	}

	return nil
}

func prepareTerraformTestConfigForOutput(input string) string {
	output := input
	output = strings.TrimSpace(output)
	output = strings.Replace(output, "\"", "'", -1)
	output = strings.TrimSpace(output)
	return output
}
