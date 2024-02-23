// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundDigitalTwins25120{}

// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/21520
type workaroundDigitalTwins25120 struct{}

func (workaroundDigitalTwins25120) IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool {
	// API Defines a Constant with the string values `"true"` and `"false`:
	// RecordPropertyAndItemRemovals           *RecordPropertyAndItemRemovals `json:"recordPropertyAndItemRemovals,omitempty"`
	// but the API returns a boolean:
	// "recordPropertyAndItemRemovals": false,
	return apiDefinition.ServiceName == "DigitalTwins" && apiDefinition.ApiVersion == "2023-01-31"
}

func (workaroundDigitalTwins25120) Name() string {
	return "DigitalTwins / 25120"
}

func (workaroundDigitalTwins25120) Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["TimeSeriesDatabaseConnections"]
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
	field.ObjectDefinition = &importerModels.ObjectDefinition{
		Type: importerModels.ObjectDefinitionBoolean,
	}
	model.Fields["RecordPropertyAndItemRemovals"] = field
	resource.Models["AzureDataExplorerConnectionProperties"] = model

	if _, ok := resource.Constants["RecordPropertyAndItemRemovals"]; !ok {
		return nil, fmt.Errorf("expected a Constant named `RecordPropertyAndItemRemovals`")
	}
	delete(resource.Constants, "RecordPropertyAndItemRemovals")

	apiDefinition.Resources["TimeSeriesDatabaseConnections"] = resource
	return &apiDefinition, nil
}
