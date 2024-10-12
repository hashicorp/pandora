// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundDigitalTwins25120{}

// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/21520
type workaroundDigitalTwins25120 struct{}

func (workaroundDigitalTwins25120) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	// API Defines a Constant with the string values `"true"` and `"false`:
	// RecordPropertyAndItemRemovals           *RecordPropertyAndItemRemovals `json:"recordPropertyAndItemRemovals,omitempty"`
	// but the API returns a boolean:
	// "recordPropertyAndItemRemovals": false,
	return serviceName == "DigitalTwins" && apiVersion.APIVersion == "2023-01-31"
}

func (workaroundDigitalTwins25120) Name() string {
	return "DigitalTwins / 25120"
}

func (workaroundDigitalTwins25120) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["TimeSeriesDatabaseConnections"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `TimeSeriesDatabaseConnections`")
	}

	model, ok := resource.Models["AzureDataExplorerConnectionProperties"]
	if !ok {
		return nil, fmt.Errorf("expected a Model named `AzureDataExplorerConnectionProperties`")
	}
	field, ok := model.Fields["RecordPropertyAndItemRemovals"]
	if !ok {
		return nil, fmt.Errorf("expected a Field named `RecordPropertyAndItemRemovals`")
	}
	field.ObjectDefinition = sdkModels.SDKObjectDefinition{
		Type: sdkModels.BooleanSDKObjectDefinitionType,
	}
	model.Fields["RecordPropertyAndItemRemovals"] = field
	resource.Models["AzureDataExplorerConnectionProperties"] = model

	if _, ok := resource.Constants["RecordPropertyAndItemRemovals"]; !ok {
		return nil, fmt.Errorf("expected a Constant named `RecordPropertyAndItemRemovals`")
	}
	delete(resource.Constants, "RecordPropertyAndItemRemovals")

	input.Resources["TimeSeriesDatabaseConnections"] = resource
	return &input, nil
}
