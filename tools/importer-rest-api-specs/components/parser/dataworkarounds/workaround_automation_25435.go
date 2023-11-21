package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundAutomation25435{}

// workaround for https://github.com/Azure/azure-rest-api-specs/pull/25435
// this is a workaround for the fact that the `CreateOrUpdate` operation for `Python3Package` is not marked as `LongRunning`
type workaroundAutomation25435 struct {
}

func (workaroundAutomation25435) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "Automation"
	apiVersionMatches := apiDefinition.ApiVersion == "2022-08-08" || apiDefinition.ApiVersion == "2023-11-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundAutomation25435) Name() string {
	return "Automation / 25434"
}

func (workaroundAutomation25435) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
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
