// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundAutomation25435{}

// workaround for https://github.com/Azure/azure-rest-api-specs/pull/25435
// this is a workaround for the fact that the `CreateOrUpdate` operation for `Python3Package` is not marked as `LongRunning`
type workaroundAutomation25435 struct {
}

func (workaroundAutomation25435) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "Automation"
	apiVersionMatches := apiVersion.APIVersion == "2022-08-08" || apiVersion.APIVersion == "2023-11-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundAutomation25435) Name() string {
	return "Automation / 25434"
}

func (workaroundAutomation25435) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Python3Package"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Python3Package`")
	}
	operation, ok := resource.Operations["CreateOrUpdate"]
	if !ok {
		return nil, fmt.Errorf("expected an Operation named `CreateOrUpdate` for `Python3Package`")
	}

	operation.LongRunning = true
	resource.Operations["CreateOrUpdate"] = operation
	input.Resources["Python3Package"] = resource

	return &input, nil
}
