// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformMethodDefinition defines how the configuration for a particular Terraform Method
// such as Create, Read, Update or Delete within a Terraform Data Source/Resource.
type TerraformMethodDefinition struct {
	// Generate specifies whether the function should be generated for this Method for the
	// Terraform Data Source/Resource in question.
	Generate bool `json:"generate"`

	// SDKOperationName specifies the name of the SDKOperation which should be invoked as
	// a part of this Terraform Method, to (for example) Create the Terraform Resource.
	SDKOperationName string `json:"methodName"` // TODO: update the json struct tag once everything is refactored

	// TimeoutInMinutes specifies the Terraform Timeout for this Method for the Terraform
	// Data Source/Resource (in minutes).
	TimeoutInMinutes int `json:"timeoutInMinutes"`
}
