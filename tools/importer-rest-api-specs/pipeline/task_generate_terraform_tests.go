package pipeline

import (
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (t pipelineTask) generateTerraformTests(v discovery.ServiceInput, details resourcemanager.TerraformDetails, named hclog.Logger) (*resourcemanager.TerraformDetails, error) {
	// TODO: @mbfrahry: go through and add the tests to each of the existing resources in details.Resources["blag"].Tests
	return &details, nil
}
