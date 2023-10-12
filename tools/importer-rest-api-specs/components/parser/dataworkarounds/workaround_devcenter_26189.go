package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// This workaround fixes an issue in DevCenter where the field `DevCenterUri` is not
// marked as ReadOnly, meaning that it's surfaced as an Optional field rather than
// being Computed.
//
// PR: https://github.com/Azure/azure-rest-api-specs/pull/26189
// Additional: https://github.com/hashicorp/pandora/pull/2675#issuecomment-1759115231

var _ workaround = workaroundDevCenter26189{}

type workaroundDevCenter26189 struct {
}

func (workaroundDevCenter26189) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "DevCenter" && apiDefinition.ApiVersion == "2022-04-01"
}

func (workaroundDevCenter26189) Name() string {
	return "DevCenter / 26189"
}

func (workaroundDevCenter26189) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["DevCenters"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `DevCenters` but didn't get one")
	}

	model, ok := resource.Models["DevCenterProperties"]
	if !ok {
		return nil, fmt.Errorf("expected a Model named `DevCenterProperties` but didn't get one")
	}
	field, ok := model.Fields["DevCenterUri"]
	if !ok {
		return nil, fmt.Errorf("expected a Field named `DevCenterUri` but didn't get one")
	}
	field.ReadOnly = true

	model.Fields["DevCenterUri"] = field
	resource.Models["DevCenterProperties"] = model
	apiDefinition.Resources["DevCenters"] = resource
	return &apiDefinition, nil
}
