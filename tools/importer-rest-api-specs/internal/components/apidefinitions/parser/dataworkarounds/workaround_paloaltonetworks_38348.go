package dataworkarounds

import (
	"errors"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundPaloAltoNetworks38348{}

type workaroundPaloAltoNetworks38348 struct{}

func (workaroundPaloAltoNetworks38348) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "PaloAltoNetworks" && apiVersion.APIVersion == "2025-05-23"
}

func (workaroundPaloAltoNetworks38348) Name() string {
	return "PaloAltoNetworks / 38348"
}

func (workaroundPaloAltoNetworks38348) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["PaloAltoNetworks"]
	if !ok {
		return nil, errors.New("expected a resource named `PaloAltoNetworks` but didn't get one")
	}

	model, ok := resource.Models["PaloAltoNetworks"]
	if !ok {
		return nil, errors.New("couldn't find model `PaloAltoNetworks`")
	}

	identityField, ok := model.Fields["Identity"]
	if !ok {
		return nil, errors.New("couldn't find the field `Identity`")
	}

	identityField.ObjectDefinition.Type = sdkModels.UserAssignedIdentityMapSDKObjectDefinitionType
	identityField.ObjectDefinition.ReferenceName = nil

	model.Fields["Identity"] = identityField
	resource.Models["PaloAltoNetworks"] = model
	input.Resources["PaloAltoNetworks"] = resource

	return &input, nil
}
