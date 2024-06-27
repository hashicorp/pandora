package terraform

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/examples"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/identification"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/schema"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/testing"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func BuildForService(input sdkModels.Service, terraformConfig map[string]definitions.ResourceDefinition, providerPrefix string) (*sdkModels.Service, error) {
	if input.TerraformDefinition == nil {
		logging.Debugf("No Terraform Definition exists for the Service %q - skipping", input.Name)
		return &input, nil
	}

	logging.Infof("Identifying the Terraform objects for the Service %q..", input.Name)
	data, err := identification.WithinService(providerPrefix, input, terraformConfig)
	if err != nil {
		return nil, fmt.Errorf("identifying the Terraform objects for the Service %q: %+v", input.Name, err)
	}

	logging.Infof("Building the Terraform Schema/Documentation..")
	data, err = schema.Build(*data)
	if err != nil {
		return nil, fmt.Errorf("building the Terraform Schema/Documentation: %+v", err)
	}

	logging.Debugf("Building the Terraform Tests..")
	data, err = testing.Build(*data)
	if err != nil {
		return nil, fmt.Errorf("building the Terraform Tests: %+v", err)
	}

	logging.Debugf("Building the Example Usage..")
	data, err = examples.Build(*data)
	if err != nil {
		return nil, fmt.Errorf("building the Terraform Example Usage: %+v", err)
	}

	logging.Tracef("Exporting the completed Terraform Resources..")
	input.TerraformDefinition.Resources = data.TerraformResources()

	return &input, nil
}
