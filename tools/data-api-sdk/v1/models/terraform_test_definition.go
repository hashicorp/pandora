// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformTestDefinition defines the Terraform Configuration used for testing purposes.
type TerraformTestDefinition = string

// TODO: once the other tooling has been refactored to use this updated SDK we should look to change this
// from a type alias to a struct containing both the Test Configuration and any associated Variables.

//// TerraformTestDefinition defines a Test Configuration and any associated Terraform Variables required to use it.
//type TerraformTestDefinition struct {
//	// TestConfiguration specifies the Terraform Test Configuration for this Terraform Data Source/Resource.
//	TestConfiguration string `json:"testConfiguration"`
//
//	// Variables optionally specifies the values for any Variables used in TestConfiguration which need to be
//	// templated.
//	Variables *TerraformTestDataVariables `json:"variables"`
//}
//
//// TerraformTestDataVariables defines the Terraform Variables used within a TerraformTestDefinition.
//type TerraformTestDataVariables struct {
//	// PrimaryLocation specifies whether the Terraform Variable `primary_location` should be output and populated.
//	PrimaryLocation bool
//
//	// RandomInteger specifies whether the Terraform Variable `random_integer` should be output and populated.
//	RandomInteger   bool
//
//	// RandomString specifies whether the Terraform Variable `random_string` should be output and populated.
//	RandomString    bool
//}
