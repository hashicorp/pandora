// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundNewRelic29256{}

// workaroundNewRelic29256 works around the Swagger defining Identity as SystemAssignedAndUserAssigned
// when the API only supports SystemAssigned.
// Swagger Issue: https://github.com/Azure/azure-rest-api-specs/issues/29256
type workaroundNewRelic29256 struct {
}

func (workaroundNewRelic29256) IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "NewRelic"
	apiVersionMatches := apiDefinition.ApiVersion == "2022-07-01" || apiDefinition.ApiVersion == "2024-03-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundNewRelic29256) Name() string {
	return "NewRelic / 29256"
}

func (workaroundNewRelic29256) Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error) {
	// NewRelicMonitorResource,NewRelicMonitorResourceUpdate
	resource, ok := apiDefinition.Resources["Monitors"]
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

	apiDefinition.Resources["Monitors"] = resource
	return &apiDefinition, nil
}
