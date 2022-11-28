package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundContainerService21394{}

// workaroundContainerService21394 works around the `DnsPrefix` field being required but being marked as Optional
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/21394
type workaroundContainerService21394 struct{}

func (workaroundContainerService21394) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "ContainerService" && apiDefinition.ApiVersion == "2022-09-02-preview"
}

func (workaroundContainerService21394) Name() string {
	return "ContainerService / 21394"
}

func (workaroundContainerService21394) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["Fleets"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource Fleets")
	}
	model, ok := resource.Models["FleetHubProfile"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model FleetHubProfile")
	}
	field, ok := model.Fields["DnsPrefix"]
	if !ok {
		return nil, fmt.Errorf("couldn't find field DnsPrefix within model FleetHubProfile")
	}
	field.Required = true

	model.Fields["DnsPrefix"] = field
	resource.Models["FleetHubProfile"] = model
	apiDefinition.Resources["Fleets"] = resource
	return &apiDefinition, nil
}
