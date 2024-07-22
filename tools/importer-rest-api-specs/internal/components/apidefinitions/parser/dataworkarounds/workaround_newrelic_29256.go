// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundNewRelic29256{}

// workaroundNewRelic29256 works around the Swagger defining Identity as SystemAssignedAndUserAssigned
// when the API only supports SystemAssigned.
// Swagger Issue: https://github.com/Azure/azure-rest-api-specs/issues/29256
type workaroundNewRelic29256 struct {
}

func (workaroundNewRelic29256) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "NewRelic"
	apiVersionMatches := apiVersion.APIVersion == "2022-07-01" || apiVersion.APIVersion == "2024-03-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundNewRelic29256) Name() string {
	return "NewRelic / 29256"
}

func (workaroundNewRelic29256) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	// NewRelicMonitorResource,NewRelicMonitorResourceUpdate
	resource, ok := input.Resources["Monitors"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource `Monitors`")
	}

	modelsToPatch := []string{
		"NewRelicMonitorResource",
		"NewRelicMonitorResourceUpdate",
	}

	for _, modelName := range modelsToPatch {
		model, ok := resource.Models[modelName]
		if !ok {
			return nil, fmt.Errorf("couldn't find Model `%s`", modelName)
		}
		field, ok := model.Fields["Identity"]
		if !ok {
			return nil, fmt.Errorf("expected the Model `%s` to have a field `Identity` but it didn't exist", modelName)
		}
		field.ObjectDefinition = sdkModels.SDKObjectDefinition{
			Type: sdkModels.SystemAssignedIdentitySDKObjectDefinitionType,
		}
		model.Fields["Identity"] = field
		resource.Models[modelName] = model
	}

	input.Resources["Monitors"] = resource
	return &input, nil
}
