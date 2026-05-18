// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundDataFactory39594{}

type workaroundDataFactory39594 struct{}

func (workaroundDataFactory39594) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "DataFactory" && apiVersion.APIVersion == "2018-06-01"
}

func (workaroundDataFactory39594) Name() string {
	return "DataFactory / 39594"
}

func (workaroundDataFactory39594) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["IntegrationRuntimes"]
	if !ok {
		return nil, errors.New("expected a resource named `IntegrationRuntimes` but didn't get one")
	}

	model, ok := resource.Models["ManagedIntegrationRuntimeStatusTypeProperties"]
	if !ok {
		return nil, errors.New("expected a model named `ManagedIntegrationRuntimeStatusTypeProperties` but didn't get one")
	}

	if _, ok := model.Fields["InteractiveQuery"]; ok {
		return nil, errors.New("found a field named `InteractiveQuery` but expected none, this workaround can be removed")
	}

	model.Fields["InteractiveQuery"] = sdkModels.SDKField{
		JsonName: "interactiveQuery",
		ObjectDefinition: sdkModels.SDKObjectDefinition{
			ReferenceName: pointer.To("InteractiveQueryProperties"),
			Type:          "Reference",
		},
		Optional: true,
	}

	return &input, nil
}
