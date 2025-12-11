// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// Service defines a collection of APIVersion's which are all grouped/related
// to the same area.
// An example of this would be `Compute` which contains the APIVersion `2021-01-01`
// which in turn contains APIResource's for `ManagedDisks` and `VirtualMachines`.
type Service struct {
	// APIVersions specifies a map of API Version (key) to APIVersion (value)
	// which defines the available API Versions for this Service.
	APIVersions map[string]APIVersion

	// Generate specifies whether this Service should be generated or not.
	Generate bool `json:"generate"`

	// Name specifies the name of this Service.
	Name string

	// ResourceProvider optionally specifies the Azure Resource Provider
	// that this Service is related to.
	// Note that this only exists when the SourceDataType is ResourceManagerSourceDataType.
	// Also note that Resource Providers do NOT have to start with `Microsoft.`.
	ResourceProvider *string

	// TerraformDefinition optionally specifies the Terraform Data Sources and
	// Terraform Resources which are included as a part of this Service.
	TerraformDefinition *TerraformDefinition
}
