package dataworkarounds

import (
	"errors"
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundManagedDevopsPools40905{}

// workaroundManagedDevopsPools40905 works around the wrong identity type.
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/40495
type workaroundManagedDevopsPools40905 struct{}

func (workaroundManagedDevopsPools40905) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "DevOpsInfrastructure" && apiVersion.APIVersion == "2025-01-21"
}

func (workaroundManagedDevopsPools40905) Name() string {
	return "ManagedDevopsPools / 40905"
}

func (workaroundManagedDevopsPools40905) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Pools"]
	if !ok {
		return nil, errors.New("expected a resource named `Pools` but didn't get one")
	}

	models := []string{
        "Pool",
        "PoolUpdate",
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

	input.Resources["Pools"] = resource

	return &input, nil
}
