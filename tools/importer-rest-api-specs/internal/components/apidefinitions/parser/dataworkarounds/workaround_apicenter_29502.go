// Copyright IBM Corp. 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundApiCenter29502{}

// workaroundApiCenter29502 adds the SKU required by the Services PUT operation but missing from the specification.
// Swagger Issue: https://github.com/Azure/azure-rest-api-specs/issues/29502
type workaroundApiCenter29502 struct{}

func (workaroundApiCenter29502) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "ApiCenter" && apiVersion.APIVersion == "2024-03-01"
}

func (workaroundApiCenter29502) Name() string {
	return "ApiCenter / 29502"
}

func (workaroundApiCenter29502) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Services"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Services` but didn't get one")
	}

	model, ok := resource.Models["Service"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model `Service`")
	}

	if _, ok := model.Fields["Sku"]; ok {
		return nil, fmt.Errorf("expected a field named `Sku` to be missing from `Service`, but it was present, this workaround can be removed")
	}
	if _, ok := resource.Models["Sku"]; ok {
		return nil, fmt.Errorf("expected a Model named `Sku` to be missing, but it was present, this workaround needs to be reviewed")
	}

	resource.Models["Sku"] = sdkModels.SDKModel{
		Fields: map[string]sdkModels.SDKField{
			"Name": {
				JsonName: "name",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Required: true,
			},
		},
	}

	model.Fields["Sku"] = sdkModels.SDKField{
		JsonName: "sku",
		ObjectDefinition: sdkModels.SDKObjectDefinition{
			Type:          sdkModels.ReferenceSDKObjectDefinitionType,
			ReferenceName: pointer.To("Sku"),
		},
		Required: true,
	}
	resource.Models["Service"] = model
	input.Resources["Services"] = resource

	return &input, nil
}
