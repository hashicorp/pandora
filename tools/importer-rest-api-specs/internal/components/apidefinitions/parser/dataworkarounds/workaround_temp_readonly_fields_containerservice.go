package dataworkarounds

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundTempReadOnlyFieldsContainerService{}

type workaroundTempReadOnlyFieldsContainerService struct {
}

func (w workaroundTempReadOnlyFieldsContainerService) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "ContainerService" && apiVersion.APIVersion == "2022-09-02-preview"
}

func (w workaroundTempReadOnlyFieldsContainerService) Name() string {
	return "Temp - Mark readonly fields as readonly - ContainerService"
}

func (w workaroundTempReadOnlyFieldsContainerService) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	definition, err := markFieldAsComputed(input, "Fleets", "FleetHubProfile", "Fqdn")
	if err != nil {
		return nil, err
	}

	definition, err = markFieldAsComputed(*definition, "Fleets", "FleetHubProfile", "KubernetesVersion")
	if err != nil {
		return nil, err
	}

	return definition, nil
}
