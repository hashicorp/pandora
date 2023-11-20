package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundAutomation26776{}

type workaroundAutomation26776 struct {
}

func (workaroundAutomation26776) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "Automation" && apiDefinition.ApiVersion == "2023-11-01"
}

func (workaroundAutomation26776) Name() string {
	return "Automation / 26776"
}

func (workaroundAutomation26776) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
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
