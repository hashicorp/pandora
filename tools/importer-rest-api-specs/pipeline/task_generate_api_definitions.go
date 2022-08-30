package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigenerator"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (pipelineTask) generateApiDefinitions(input discovery.ServiceInput, data models.AzureApiDefinition, swaggerGitSha string, logger hclog.Logger) error {
	logger.Debug("Generating Data API Definitions..")
	var terraformPackageName *string
	if input.TerraformServiceDefinition != nil {
		terraformPackageName = &input.TerraformServiceDefinition.TerraformPackageName
	}
	dataApiGenerator := dataapigenerator.NewForApiVersion(data.ServiceName, data.ApiVersion, input.OutputDirectory, input.RootNamespace, swaggerGitSha, input.ResourceProvider, terraformPackageName, logger.Named("Data API Generator"))
	if err := dataApiGenerator.GenerateForApiVersion(data); err != nil {
		err = fmt.Errorf("generating Data API Definitions for Service %q / API Version %q: %+v", data.ServiceName, data.ApiVersion, err)
		logger.Info(fmt.Sprintf("❌ Service %q - Api Version %q", data.ServiceName, data.ApiVersion))
		logger.Error(fmt.Sprintf("     💥 Error: %+v", err))
		return err
	}

	logger.Info(fmt.Sprintf("✅ Service %q - Api Version %q", data.ServiceName, data.ApiVersion))
	return nil
}
