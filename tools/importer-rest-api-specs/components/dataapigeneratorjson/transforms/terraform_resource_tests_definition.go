package transforms

import (
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func MapTerraformResourceTestDefinitionToRepository(input resourcemanager.TerraformResourceTestsDefinition) dataapimodels.TerraformResourceTestConfig {
	return dataapimodels.TerraformResourceTestConfig{
		BasicConfig:    input.BasicConfiguration,
		CompleteConfig: input.CompleteConfiguration,
		Generate:       input.Generate,
		OtherTests:     input.OtherTests,
		RequiresImport: input.RequiresImportConfiguration,
		TemplateConfig: input.TemplateConfiguration,
	}
}
