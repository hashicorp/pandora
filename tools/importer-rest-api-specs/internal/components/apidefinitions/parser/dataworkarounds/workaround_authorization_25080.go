// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundAuthorization25080{}

type workaroundAuthorization25080 struct {
}

func (workaroundAuthorization25080) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Authorization" && apiVersion.APIVersion == "2020-10-01"
}

func (workaroundAuthorization25080) Name() string {
	return "Authorization / 25080"
}

func (workaroundAuthorization25080) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["RoleManagementPolicies"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `RoleManagementPolicies` but didn't get one")
	}
	operation, ok := resource.Operations["ListForScope"]
	if !ok {
		return nil, fmt.Errorf("expected an Operation named `ListForScope` but didn't get one")
	}
	operation.Options["Filter"] = sdkModels.SDKOperationOption{
		ObjectDefinition: sdkModels.SDKOperationOptionObjectDefinition{
			Type: sdkModels.StringSDKOperationOptionObjectDefinitionType,
		},
		QueryStringName: pointer.To("$filter"),
		Required:        false,
	}
	resource.Operations["ListForScope"] = operation
	input.Resources["RoleManagementPolicies"] = resource
	return &input, nil
}
