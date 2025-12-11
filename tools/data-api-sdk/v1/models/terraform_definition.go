// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformDefinition defines the available Terraform Data Sources and Resources
// available within this Service.
type TerraformDefinition struct {
	// Resources defines a map of Resource Label (key) to TerraformResourceDetails
	// containing information about the Terraform Resources defined within this Service.
	Resources map[string]TerraformResourceDefinition `json:"resources"`

	// TerraformPackageName specifies the name of the Terraform Package associated with this Service.
	TerraformPackageName string `json:"terraformPackageName"`
}
