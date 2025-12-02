package dataworkarounds

import (
	"errors"
	"net/http"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundFluidRelayTODO{}

type workaroundFluidRelayTODO struct{}

func (workaroundFluidRelayTODO) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "FluidRelay" && apiVersion.APIVersion == "2022-06-01"
}

func (workaroundFluidRelayTODO) Name() string {
	return "FluidRelay / TODO"
}

func (workaroundFluidRelayTODO) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["FluidRelayServers"]
	if !ok {
		return &input, errors.New("couldn't find API Resource FluidRelayServers")
	}

	operation, ok := resource.Operations["Delete"]
	if !ok {
		return &input, errors.New("couldn't find API Operation Delete")
	}

	operation.ExpectedStatusCodes = append(operation.ExpectedStatusCodes, http.StatusAccepted)
	// operation.LongRunning = true

	resource.Operations["Delete"] = operation

	input.Resources["FluidRelayServers"] = resource
	return &input, nil
}
