package dataapigeneratorjson

import (
	dataApiModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mapTerraformResourceTestDefinition(input resourcemanager.TerraformResourceTestsDefinition) dataApiModels.TerraformResourceTestConfig {
	// TODO: looking at the data more and more, these probably want to become `*.hcl` files?
	// Perhaps `Resource-Test-{Basic|Complete}.hcl` and  `Resource-Test-{Other}{1|2|3}.hcl`?
	return dataApiModels.TerraformResourceTestConfig{
		BasicConfig:    input.BasicConfiguration,
		CompleteConfig: input.CompleteConfiguration,
		Generate:       input.Generate,
		OtherTests:     input.OtherTests,
		RequiresImport: input.RequiresImportConfiguration,
		TemplateConfig: input.TemplateConfiguration,
	}
}
