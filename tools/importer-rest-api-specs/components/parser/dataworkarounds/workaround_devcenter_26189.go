package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// This workaround fixes an issue in DevCenter where the field `DevCenterUri` is not
// marked as ReadOnly, meaning that it's surfaced as an Optional field rather than
// being Computed.
//
// This also makes `DevCenterId` required for the `Projects` resource since otherwise
// it defaults on the API side, which is likely to cause user confusion, making this
// required makes it explicit what's being deployed.
//
// PR: https://github.com/Azure/azure-rest-api-specs/pull/26189
// Additional: https://github.com/hashicorp/pandora/pull/2675#issuecomment-1759115231

var _ workaround = workaroundDevCenter26189{}

type workaroundDevCenter26189 struct {
}

func (workaroundDevCenter26189) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "DevCenter" && apiDefinition.ApiVersion == "2023-04-01"
}

func (workaroundDevCenter26189) Name() string {
	return "DevCenter / 26189"
}

func (workaroundDevCenter26189) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	// First we need to patch the DevCenters issue (marking DevCenterUri as required)
	devCentersResource, ok := apiDefinition.Resources["DevCenters"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `DevCenters` but didn't get one")
	}

	devCenterModel, ok := devCentersResource.Models["DevCenterProperties"]
	if !ok {
		return nil, fmt.Errorf("expected a Model named `DevCenterProperties` but didn't get one")
	}
	devCenterField, ok := devCenterModel.Fields["DevCenterUri"]
	if !ok {
		return nil, fmt.Errorf("expected a Field named `DevCenterUri` but didn't get one")
	}
	devCenterField.ReadOnly = true

	devCenterModel.Fields["DevCenterUri"] = devCenterField
	devCentersResource.Models["DevCenterProperties"] = devCenterModel
	apiDefinition.Resources["DevCenters"] = devCentersResource

	// Next we need to do the same thing for Projects to make the `DevCenterId` field Required
	// and make `DevCenterUri` computed
	projectsResource, ok := apiDefinition.Resources["Projects"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Projects` but didn't get one")
	}
	projectModel, ok := projectsResource.Models["ProjectProperties"]
	if !ok {
		return nil, fmt.Errorf("expected a Model named `ProjectProperties` but didn't get one")
	}
	projectDevCenterIdField, ok := projectModel.Fields["DevCenterId"]
	if !ok {
		return nil, fmt.Errorf("expected a Field named `DevCenterId` but didn't get one")
	}
	projectDevCenterIdField.Required = true
	projectModel.Fields["DevCenterId"] = projectDevCenterIdField

	projectDevCenterUriField, ok := projectModel.Fields["DevCenterUri"]
	if !ok {
		return nil, fmt.Errorf("expected a Field named `DevCenterUri` but didn't get one")
	}
	projectDevCenterUriField.ReadOnly = true
	projectModel.Fields["DevCenterUri"] = projectDevCenterUriField

	projectsResource.Models["ProjectProperties"] = projectModel
	apiDefinition.Resources["Projects"] = projectsResource

	return &apiDefinition, nil
}
