// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundAutomation25108{}

type workaroundAutomation25108 struct {
}

func (workaroundAutomation25108) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "Automation"
	apiVersionMatches := apiVersion.APIVersion == "2022-08-08" || apiVersion.APIVersion == "2023-11-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundAutomation25108) Name() string {
	return "Automation / 25108"
}

func (workaroundAutomation25108) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["ListAllHybridRunbookWorkerGroupInAutomationAccount"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `ListAllHybridRunbookWorkerGroupInAutomationAccount`")
	}
	operation, ok := resource.Operations["HybridRunbookWorkerGroupDelete"]
	if !ok {
		return nil, fmt.Errorf("expected an Operation named `HybridRunbookWorkerGroupDelete`")
	}

	otherResource, ok := input.Resources["HybridRunbookWorkerGroup"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `HybridRunbookWorkerGroup`")
	}
	if _, hasExisting := otherResource.Operations["Delete"]; hasExisting {
		return nil, fmt.Errorf("an existing `Delete` operation exists for `HybridRunbookWorkerGroup`")
	}
	otherResource.Operations["Delete"] = operation

	input.Resources["HybridRunbookWorkerGroup"] = otherResource
	delete(input.Resources, "ListAllHybridRunbookWorkerGroupInAutomationAccount")

	return &input, nil
}
