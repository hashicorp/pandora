package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundAutomation25434{}

type workaroundAutomation25434 struct {
}

func (workaroundAutomation25434) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "Automation" && apiDefinition.ApiVersion == "2022-08-08"
}

func (workaroundAutomation25434) Name() string {
	return "Automation / 25434"
}

func (workaroundAutomation25434) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["Python3Package"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Python3Package`")
	}
	operation, ok := resource.Operations["CreateOrUpdate"]
	if !ok {
		return nil, fmt.Errorf("expected an Operation named `CreateOrUpdate` for `Python3Package`")
	}

	operation.LongRunning = true
	resource.Operations["CreateOrUpdate"] = operation
	apiDefinition.Resources["Python3Package"] = resource

	return &apiDefinition, nil
}
