package dataworkarounds

import (
	"errors"
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundPaloAltoNetworks38348{}

type workaroundPaloAltoNetworks38348 struct{}

func (workaroundPaloAltoNetworks38348) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "PaloAltoNetworks" && (apiVersion.APIVersion == "2025-05-23" || apiVersion.APIVersion == "2025-10-08")
}

func (workaroundPaloAltoNetworks38348) Name() string {
	return "PaloAltoNetworks / 38348"
}

func (workaroundPaloAltoNetworks38348) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	// The resource (tag) name differs between API Versions - in `2025-05-23` it's `Firewalls`
	// whereas in `2025-10-08` it's `FirewallResources`.
	resourceName := ""
	for _, candidate := range []string{"Firewalls", "FirewallResources"} {
		if _, ok := input.Resources[candidate]; ok {
			resourceName = candidate
			break
		}
	}
	if resourceName == "" {
		return nil, errors.New("expected a resource named `Firewalls` or `FirewallResources` but didn't get one")
	}

	resource := input.Resources[resourceName]

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

	input.Resources[resourceName] = resource

	return &input, nil
}
