// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundContainerService21394{}

// workaroundContainerService21394 works around the `DnsPrefix` field being required but being marked as Optional
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/21394
type workaroundContainerService21394 struct{}

func (workaroundContainerService21394) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "ContainerService" && apiVersion.APIVersion == "2022-09-02-preview"
}

func (workaroundContainerService21394) Name() string {
	return "ContainerService / 21394"
}

func (workaroundContainerService21394) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Fleets"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource Fleets")
	}
	model, ok := resource.Models["FleetHubProfile"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model FleetHubProfile")
	}
	field, ok := model.Fields["DnsPrefix"]
	if !ok {
		return nil, fmt.Errorf("couldn't find field DnsPrefix within model FleetHubProfile")
	}
	field.Required = true
	field.Optional = false
	field.ReadOnly = false

	model.Fields["DnsPrefix"] = field
	resource.Models["FleetHubProfile"] = model
	input.Resources["Fleets"] = resource
	return &input, nil
}
