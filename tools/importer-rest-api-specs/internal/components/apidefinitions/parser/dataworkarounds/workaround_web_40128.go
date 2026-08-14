// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundWeb40128{}

type workaroundWeb40128 struct{}

func (workaroundWeb40128) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	if serviceName != "Web" {
		return false
	}

	switch apiVersion.APIVersion {
	case "2023-01-01", "2023-12-01", "2024-11-01", "2025-05-01":
		return true
	}

	return false
}

func (workaroundWeb40128) Name() string {
	return "Web / 40128"
}

func (workaroundWeb40128) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["WebApps"]
	if !ok {
		return nil, errors.New("expected a resource named `WebApps` but didn't get one")
	}

	model, ok := resource.Models["AzureStorageInfoValue"]
	if !ok {
		return nil, errors.New("expected a model named `AzureStorageInfoValue` but didn't get one")
	}

	if _, ok := model.Fields["Endpoint"]; ok {
		return nil, errors.New("found a field named `Endpoint` but expected none, this workaround can be removed")
	}

	model.Fields["Endpoint"] = sdkModels.SDKField{
		JsonName: "endpoint",
		ObjectDefinition: sdkModels.SDKObjectDefinition{
			Type: sdkModels.StringSDKObjectDefinitionType,
		},
		Optional: true,
	}
	resource.Models["AzureStorageInfoValue"] = model
	input.Resources["WebApps"] = resource

	return &input, nil
}
