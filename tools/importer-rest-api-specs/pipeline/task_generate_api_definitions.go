package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigenerator"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratoryaml"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/featureflags"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (pipelineTask) generateApiDefinitions(input discovery.ServiceInput, data models.AzureApiDefinition, swaggerGitSha string, logger hclog.Logger) error {
	var terraformPackageName *string
	if input.TerraformServiceDefinition != nil {
		terraformPackageName = &input.TerraformServiceDefinition.TerraformPackageName
	}

	logger.Debug("Generating Data API Definitions in C#..")
	cSGenerator := dataapigenerator.NewForApiVersion(data.ServiceName, data.ApiVersion, input.OutputDirectoryCS, input.RootNamespace, swaggerGitSha, input.ResourceProvider, terraformPackageName, logger.Named("Data API Generator"))
	if err := cSGenerator.GenerateForApiVersion(data); err != nil {
		err = fmt.Errorf("generating C# Data API Definitions for Service %q / API Version %q: %+v", data.ServiceName, data.ApiVersion, err)
		logger.Info(fmt.Sprintf("❌ Service %q - Api Version %q", data.ServiceName, data.ApiVersion))
		logger.Error(fmt.Sprintf("     💥 Error: %+v", err))
		return err
	}
	logger.Info(fmt.Sprintf("✅ Service %q - Api Version %q in C#", data.ServiceName, data.ApiVersion))

	if featureflags.GenerateYamlDataAPI {
		logger.Debug("Generating Data API Definition in YAML..")
		yamlGenerator := dataapigeneratoryaml.NewForApiVersion(data.ServiceName, data.ApiVersion, input.OutputDirectoryYaml, "resource-manager", swaggerGitSha, input.ResourceProvider, terraformPackageName, logger.Named("Data API Generator"))
		if err := yamlGenerator.GenerateForApiVersion(data); err != nil {
			err = fmt.Errorf("generating YAML Data API Definitions for Service %q / API Version %q: %+v", data.ServiceName, data.ApiVersion, err)
			logger.Info(fmt.Sprintf("❌ Service %q - Api Version %q", data.ServiceName, data.ApiVersion))
			logger.Error(fmt.Sprintf("     💥 Error: %+v", err))
			return err
		}
		logger.Info(fmt.Sprintf("✅ Service %q - Api Version %q in YAML", data.ServiceName, data.ApiVersion))
	}

	return nil
}
