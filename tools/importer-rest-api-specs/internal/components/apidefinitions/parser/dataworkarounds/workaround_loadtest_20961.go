// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundLoadTest20961{}

// workaroundLoadTest20961 works around the Patch Model having no type for the Tags field (which is parsed
// as an Object instead).
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/20961
type workaroundLoadTest20961 struct {
}

func (workaroundLoadTest20961) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "LoadTestService"
	apiVersionMatches := apiVersion.APIVersion == "2021-12-01-preview" || apiVersion.APIVersion == "2022-04-15-preview" || apiVersion.APIVersion == "2022-12-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundLoadTest20961) Name() string {
	return "LoadTest / 20961"
}

func (workaroundLoadTest20961) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["LoadTests"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource LoadTests")
	}
	model, ok := resource.Models["LoadTestResourceUpdate"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model LoadTestResourceUpdate")
	}
	field, ok := model.Fields["Tags"]
	if !ok {
		return nil, fmt.Errorf("couldn't find field Tags within model LoadTestResourceUpdate")
	}
	field.ObjectDefinition = sdkModels.SDKObjectDefinition{
		Type: sdkModels.TagsSDKObjectDefinitionType,
	}

	model.Fields["Tags"] = field
	resource.Models["LoadTestResourceUpdate"] = model
	input.Resources["LoadTests"] = resource
	return &input, nil
}
