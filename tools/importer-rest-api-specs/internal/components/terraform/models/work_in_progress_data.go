// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

type WorkInProgressData struct {
	// ProviderPrefix is the prefix used for Terraform Resources used within the Provider, which is
	// prepended onto the Resource Type to create the full Resource Type.
	// Example: `azurerm`, with the Resource Type `resource_group` creates `azurerm_resource_group`.
	ProviderPrefix string

	// Resources is a map of the WorkInProgressResources that are being built-up by this package.
	Resources map[string]WorkInProgressResource
}

// TerraformResources returns the Terraform Resources from the (completed) work-in-progress data
func (d WorkInProgressData) TerraformResources() map[string]sdkModels.TerraformResourceDefinition {
	output := make(map[string]sdkModels.TerraformResourceDefinition)
	for key, item := range d.Resources {
		output[key] = item.Resource
	}
	return output
}
