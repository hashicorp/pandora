package dataworkarounds

import (
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
	resourceName, ok := map[string]string{
		"2025-05-23": "Firewalls",
		"2025-10-08": "FirewallResources",
	}[input.APIVersion]
	if !ok {
		return nil, fmt.Errorf("unexpected API Version %q", input.APIVersion)
	}

	resource, ok := input.Resources[resourceName]
	if !ok {
		return nil, fmt.Errorf("expected a resource named `%s` but didn't get one", resourceName)
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

	input.Resources[resourceName] = resource

	return &input, nil
}
