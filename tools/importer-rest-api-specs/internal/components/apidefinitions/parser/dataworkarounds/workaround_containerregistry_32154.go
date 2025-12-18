// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundContainerRegistry32154{}

// workaroundContainerRegistry32154 works around the Swagger defining Identity as SystemAssignedAndUserAssigned
// when the API only supports SystemAssigned.
// Swagger Issue: https://github.com/Azure/azure-rest-api-specs/issues/32154
type workaroundContainerRegistry32154 struct {
}

func (workaroundContainerRegistry32154) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "ContainerRegistry" && apiVersion.APIVersion == "2023-07-01"
}

func (workaroundContainerRegistry32154) Name() string {
	return "ContainerRegistry / 32154"
}

func (workaroundContainerRegistry32154) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["CredentialSets"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource `CredentialSets`")
	}

	modelsToPatch := []string{
		"CredentialSet",
		"CredentialSetUpdateParameters",
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

	input.Resources["CredentialSets"] = resource
	return &input, nil
}
