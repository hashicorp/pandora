// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundBatch21291{}

// workaroundBatch21291 works around the StorageAccountId property being marked as Required which means it isn't
// nullable/removable like it was with the Azure Track1 SDK.
// The Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/21291
type workaroundBatch21291 struct {
}

func (workaroundBatch21291) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "Batch"
	apiVersionMatches := apiVersion.APIVersion == "2022-01-01" || apiVersion.APIVersion == "2022-10-01" || apiVersion.APIVersion == "2023-05-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundBatch21291) Name() string {
	return "Batch / 21291"
}

func (workaroundBatch21291) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["BatchAccount"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource BatchAccount")
	}
	model, ok := resource.Models["AutoStorageBaseProperties"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model AutoStorageBaseProperties")
	}
	field, ok := model.Fields["StorageAccountId"]
	if !ok {
		return nil, fmt.Errorf("couldn't find the field StorageAccountId within model AutoStorageProperties")
	}
	field.Required = false

	model.Fields["StorageAccountId"] = field
	resource.Models["AutoStorageBaseProperties"] = model
	input.Resources["BatchAccount"] = resource
	return &input, nil
}
