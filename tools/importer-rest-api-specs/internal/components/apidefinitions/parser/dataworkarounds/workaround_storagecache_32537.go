// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// workaroundStorageCache32537 is a workaround to convert the `percentComplete` field to a float
// which is what the API returns and results in an unmarshaling error in the SDK when trying to
// read the response body - this can be removed when PR https://github.com/Azure/azure-rest-api-specs/pull/32537
// has been merged
type workaroundStorageCache32537 struct {
}

func (w workaroundStorageCache32537) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "StorageCache" && apiVersion.APIVersion == "2023-05-01"
}

func (w workaroundStorageCache32537) Name() string {
	return "StorageCache / 32537"
}

func (w workaroundStorageCache32537) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["AmlFilesystems"]
	if !ok {
		return nil, fmt.Errorf(`expected to find the API Resource "AmlFilesystems" but didn't`)
	}

	model, ok := resource.Models["AmlFilesystemArchiveStatus"]
	if !ok {
		return nil, fmt.Errorf(`expected the API resource "AmlFilesystems" to contain Model "AmlFilesystemArchiveStatus" but it didn't`)
	}

	field, ok := model.Fields["PercentComplete"]
	if !ok {
		return nil, fmt.Errorf(`expected the Model "AmlFilesystemArchiveStatus" to contain the field "PercentComplete" but it didn't'`)
	}

	field.ObjectDefinition = sdkModels.SDKObjectDefinition{
		Type: sdkModels.FloatSDKObjectDefinitionType,
	}

	model.Fields["PercentComplete"] = field
	resource.Models["AmlFilesystemArchiveStatus"] = model
	input.Resources["AmlFilesystems"] = resource

	return &input, nil
}
