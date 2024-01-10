package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundAutomation25108{}

type workaroundAutomation25108 struct {
}

func (workaroundAutomation25108) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "Automation"
	apiVersionMatches := apiDefinition.ApiVersion == "2022-08-08" || apiDefinition.ApiVersion == "2023-11-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundAutomation25108) Name() string {
	return "Automation / 25108"
}

func (workaroundAutomation25108) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["ListAllHybridRunbookWorkerGroupInAutomationAccount"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `ListAllHybridRunbookWorkerGroupInAutomationAccount`")
	}
	operation, ok := resource.Operations["HybridRunbookWorkerGroupDelete"]
	if !ok {
		return nil, fmt.Errorf("expected an Operation named `HybridRunbookWorkerGroupDelete`")
	}

	otherResource, ok := apiDefinition.Resources["HybridRunbookWorkerGroup"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `HybridRunbookWorkerGroup`")
	}
	if _, hasExisting := otherResource.Operations["Delete"]; hasExisting {
		return nil, fmt.Errorf("an existing `Delete` operation exists for `HybridRunbookWorkerGroup`")
	}
	otherResource.Operations["Delete"] = operation

	apiDefinition.Resources["HybridRunbookWorkerGroup"] = otherResource
	delete(apiDefinition.Resources, "ListAllHybridRunbookWorkerGroupInAutomationAccount")

	return &apiDefinition, nil
}
