package dataworkarounds

import (
	"errors"
	"fmt"

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
	resource, ok := input.Resources["Firewalls"]
	if !ok {
		return nil, errors.New("expected a resource named `Firewalls` but didn't get one")
	}

    models := []string{
        "FirewallResource",
        "FirewallResourceUpdate",
    }

    for _, modelName := range models {
        model, ok := resource.Models[modelName]
        if !ok {
            return nil, fmt.Errorf("couldn't find model `%s`", modelName)
        }

        identityField, ok := model.Fields["Identity"]
        if !ok {
            return nil, fmt.Errorf("couldn't find the field `Identity` within model `%s`", modelName)
        }

        identityField.ObjectDefinition.Type = sdkModels.UserAssignedIdentityMapSDKObjectDefinitionType
        identityField.ObjectDefinition.ReferenceName = nil

        model.Fields["Identity"] = identityField
        resource.Models[modelName] = model
    }

    input.Resources["Firewalls"] = resource

    return &input, nil
}
