package dataapigenerator

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (g PandoraDefinitionGenerator) GenerateTerraformResourceDefinition(fileName, terraformNamespace, apiVersion, apiResource, resourceLabel string, details resourcemanager.TerraformResourceDetails) error {
	code := codeForTerraformResourceDefinition(terraformNamespace, apiVersion, apiResource, resourceLabel, details)
	return writeToFile(fileName, code)
}
