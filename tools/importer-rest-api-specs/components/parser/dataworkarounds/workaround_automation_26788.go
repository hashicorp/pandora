package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundAutomation26788{}

// workaround for https://github.com/Azure/azure-rest-api-specs/pull/26788
// this is a workaround for the fact that the `CreateOrUpdate` operation for `Python3Package` is not marked as `LongRunning`
type workaroundAutomation26788 struct {
}

func (workaroundAutomation26788) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "Automation" && apiDefinition.ApiVersion == "2023-11-01"
}

func (workaroundAutomation26788) Name() string {
	return "Automation / 26788"
}

func (workaroundAutomation26788) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
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
