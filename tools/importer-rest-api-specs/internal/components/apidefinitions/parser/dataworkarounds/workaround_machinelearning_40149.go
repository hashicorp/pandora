// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundMachineLearning40149{}

// workaroundMachineLearning40149 works around the Swagger defining Identity as SystemAssignedAndUserAssigned
// when the API only supports SystemAssigned.
// Swagger Issue: https://github.com/Azure/azure-rest-api-specs/issues/40149
type workaroundMachineLearning40149 struct{}

func (workaroundMachineLearning40149) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "MachineLearningServices"
}

func (workaroundMachineLearning40149) Name() string {
	return "MachineLearningServices / 40149"
}

func (workaroundMachineLearning40149) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	// Old API versions (< 2025-12-01) follow the Swagger definition. New API versions(>= 2025-12-01) follow the OpenAPI definition.
	// The workaround is applicable for both new and old API versions, but the resource and model names are different between them.
	resourceName := "BatchEndpoints"
	modelName := "BatchEndpoint"

	if input.APIVersion < "2025-12-01" {
		resourceName = "BatchEndpoint"
		modelName = "BatchEndpointTrackedResource"
	}

	resource, ok := input.Resources[resourceName]
	if !ok {
		return nil, fmt.Errorf("expected a resource named %q but didn't get one", resourceName)
	}

	model, ok := resource.Models[modelName]
	if !ok {
		return nil, fmt.Errorf("couldn't find model %q", modelName)
	}

	identityField, ok := model.Fields["Identity"]
	if !ok {
		return nil, errors.New("couldn't find the field `Identity`")
	}

	identityField.ObjectDefinition.Type = sdkModels.SystemAssignedIdentitySDKObjectDefinitionType

	model.Fields["Identity"] = identityField
	resource.Models[modelName] = model
	input.Resources[resourceName] = resource

	return &input, nil
}
