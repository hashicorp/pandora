// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// ServiceDefinition is used to define a Service (such as `Compute`) within which
// API Versions (which have API Resources) and Terraform Definitions may exist.
type ServiceDefinition struct {
	// Name is the Display name for this ServiceDefinition which should be usable as
	// an identifier, typically in TitleCase (for example `KubernetesConfiguration`).
	Name string `json:"name"`

	// ResourceProvider specifies the Resource Provider within Azure Resource Manager
	// that this Service Definition is related to, which will only exist for Services
	// within Azure Resource Manager. This should be in TitleCase.
	// Example: `Microsoft.Compute`
	ResourceProvider *string `json:"resourceProvider,omitempty"`

	// TerraformPackageName is the name of the Service Package within
	// the Terraform Provider associated with this service.
	TerraformPackageName *string `json:"terraformPackageName,omitempty"`

	// Generate specifies whether this ServiceDefinition should be generated whilst
	// the majority of the time this is set to true, there are cases where the data
	// wants to be imported but not yet generated (e.g. issues).
	Generate bool `json:"generate"`

	// Terraform specifies any Terraform related configuration options for this ServiceDefinition
	Terraform *TerraformServiceDefinition `json:"terraform,omitempty"`
}

// TerraformServiceDefinition defines the Terraform related configuration for a ServiceDefinition.
type TerraformServiceDefinition struct {
	// ServicePackageName is the name of the Service Package within the Terraform Provider
	// where the Terraform Resources should be output.
	// Example: `compute`.
	ServicePackageName string `json:"servicePackageName"`

	// Resources is a list of the Terraform Resources available within this ServiceDefinition.
	Resources []string `json:"resources"`
}
