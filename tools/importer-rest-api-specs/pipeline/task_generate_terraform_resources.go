package pipeline

import (
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (pipelineTask) generateTerraformDetails(input discovery.ServiceInput, data *models.AzureApiDefinition, logger hclog.Logger) (*resourcemanager.TerraformDetails, error) {
	// TODO: iterate over each of the TF resources that we have in input.TerraformServiceDefinition
	// call the Schema package build that up and the other stuff..
	return &resourcemanager.TerraformDetails{}, nil
}
