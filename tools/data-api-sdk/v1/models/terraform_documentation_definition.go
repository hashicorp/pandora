// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformDocumentationDefinition defines the core set of documentation related properties
// for a Terraform Data Source/Resource.
type TerraformDocumentationDefinition struct {
	// Category specifies the Website Category for this Terraform Data Source/Resource.
	// This allows related Terraform Data Sources and Resources to be grouped together
	// in the Terraform Registry.
	Category string `json:"category"`

	// Description specifies a friendly, human-readable summary for this Terraform Data
	// Source/Resource. This will be output in the documentation and should be both concise
	// yet clear.
	Description string `json:"description"`

	// ExampleUsageHCL specifies the HCL used in the `Example Usage` component within the
	// documentation for this Terraform Data Source/Resource.
	// This should be a minimal Terraform Configuration, containing only Required properties
	// of how to use this Terraform Data Source/Resource.
	ExampleUsageHCL string `json:"exampleUsageHcl"`
}
