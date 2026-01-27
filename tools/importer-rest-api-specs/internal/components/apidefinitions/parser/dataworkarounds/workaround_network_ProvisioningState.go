// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundNetworkProvisioningState{}

// The swagger for network contains 2 enum definitions for `ProvisioningState` in most API versions.
// Since we do not use this in the provider, we are normalising it to the broader list of values.
type workaroundNetworkProvisioningState struct {
}

func (workaroundNetworkProvisioningState) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Network"
}

func (workaroundNetworkProvisioningState) Name() string {
	return "Network / 29303"
}

func (workaroundNetworkProvisioningState) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	affectedTags := []string{
		"NetworkManagerActiveConfigurations",
		"NetworkManagerActiveConnectivityConfigurations",
		"NetworkManagerEffectiveConnectivityConfiguration",
		"NetworkManagerEffectiveSecurityAdminRules",
	}

	normalisedProvisioningState := map[string]string{
		"Canceled":  "Canceled",
		"Creating":  "Creating",
		"Deleting":  "Deleting",
		"Failed":    "Failed",
		"Succeeded": "Succeeded",
		"Updating":  "Updating",
	}

	for _, v := range affectedTags {
		r := input.Resources[v]
		c := r.Constants["ProvisioningState"]
		c.Values = normalisedProvisioningState
		r.Constants["ProvisioningState"] = c
		input.Resources[v] = r
	}

	return &input, nil
}
