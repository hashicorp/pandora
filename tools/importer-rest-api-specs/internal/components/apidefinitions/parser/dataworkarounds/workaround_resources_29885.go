package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundResources29885{}

// workaroundResources29885 converts the `PrivateEndpointConnections` property from a string to an interface - this can be removed once
// https://github.com/Azure/azure-rest-api-specs/issues/29885 has been fixed
type workaroundResources29885 struct{}

func (workaroundResources29885) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Resources" && apiVersion.APIVersion == "2020-05-01"
}

func (workaroundResources29885) Name() string {
	return "Resources / 29885"
}

func (workaroundResources29885) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["ResourceManagementPrivateLink"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `ResourceManagementPrivateLink` but didn't get one")
	}

	model, ok := resource.Models["ResourceManagementPrivateLinkEndpointConnections"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model `ResourceManagementPrivateLinkEndpointConnections`")
	}

	field, ok := model.Fields["PrivateEndpointConnections"]
	if !ok {
		return nil, fmt.Errorf("couldn't find the field `PrivateEndpointConnections` in model `ResourceManagementPrivateLinkEndpointConnections`")
	}
	if field.ObjectDefinition.NestedItem != nil {
		field.ObjectDefinition.NestedItem.Type = sdkModels.RawObjectSDKObjectDefinitionType
	}

	model.Fields["PrivateEndpointConnections"] = field
	resource.Models["ResourceManagementPrivateLinkEndpointConnections"] = model
	input.Resources["ResourceManagementPrivateLink"] = resource

	return &input, nil
}
