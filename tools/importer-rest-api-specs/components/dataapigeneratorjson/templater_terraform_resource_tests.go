package dataapigeneratorjson

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	dataApiModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mapTerraformResourceTestDefinition(input resourcemanager.TerraformResourceTestsDefinition) dataApiModels.TerraformResourceTestConfig {
	testConfig := dataApiModels.TerraformResourceTestConfig{
		BasicConfig:    input.BasicConfiguration,
		CompleteConfig: input.CompleteConfiguration,
		Generate:       input.Generate,
		RequiresImport: input.RequiresImportConfiguration,
		TemplateConfig: input.TemplateConfiguration,
	}
	if len(input.OtherTests) > 0 {
		testConfig.OtherTests = pointer.To(input.OtherTests)
	}
	return testConfig
}
