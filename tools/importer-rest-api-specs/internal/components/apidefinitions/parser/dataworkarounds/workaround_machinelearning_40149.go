// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundMachineLearning40149{}

// workaroundMachineLearning40149 works around the Swagger defining Identity as SystemAssignedAndUserAssigned
// when the API only supports SystemAssigned.
// Swagger Issue: https://github.com/Azure/azure-rest-api-specs/issues/40149
type workaroundMachineLearning40149 struct{}

func (workaroundMachineLearning40149) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "MachineLearningServices"
	// 2025-06-01 is currently used for Machine Learning RPs, 2025-09-01 is the latest stable. So patching both.
	apiVersionMatches := apiVersion.APIVersion == "2025-06-01" || apiVersion.APIVersion == "2025-09-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundMachineLearning40149) Name() string {
	return "MachineLearningServices / 40149"
}

func (workaroundMachineLearning40149) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["BatchEndpoint"]
	if !ok {
		return nil, errors.New("expected a resource named `BatchEndpoint` but didn't get one")
	}

	model, ok := resource.Models["BatchEndpointTrackedResource"]
	if !ok {
		return nil, errors.New("couldn't find model `BatchEndpointTrackedResource`")
	}

	identityField, ok := model.Fields["Identity"]
	if !ok {
		return nil, errors.New("couldn't find the field `Identity`")
	}

	identityField.ObjectDefinition.Type = sdkModels.SystemAssignedIdentitySDKObjectDefinitionType

	model.Fields["Identity"] = identityField
	resource.Models["BatchEndpointTrackedResource"] = model
	input.Resources["BatchEndpoint"] = resource

	return &input, nil
}
