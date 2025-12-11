// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformResourceTestsDefinition defines the Test Configurations for a Terraform Resource.
// Each Terraform Resource is backed by at a minimum a Basic and RequiresImport Test Configuration
// however may optionally have more tests including Complete and extra tests with multiple stages
// as defined in `OtherTests`.
type TerraformResourceTestsDefinition struct {
	// BasicConfiguration specifies the most basic/minimal Terraform Configuration required
	// to provision the associated Terraform Resource.
	BasicConfiguration TerraformTestDefinition `json:"basicConfiguration"`

	// RequiresImportConfiguration specifies the Terraform Configuration used to validate that
	// a Resource which already exists needs to be imported to be able to use it.
	// This should reuse and interpolate values for fields from BasicConfiguration, which is
	// used to provision a minimal resource we can rely on existing for this Test Configuration.
	RequiresImportConfiguration TerraformTestDefinition `json:"requiresImportConfiguration"`

	// CompleteConfiguration optionally specifies the Terraform Configuration used for the Complete
	// Test - which includes all possible fields that can be set for this Resource.
	// Note that this is optional because if a Terraform Resource contains only Required fields then
	// this test case would be superfluous (and covered by BasicConfiguration).
	CompleteConfiguration *TerraformTestDefinition `json:"completeConfiguration,omitempty"`

	// Generate specifies whether the Tests should be generated or not.
	// If this is set to `false` then these are assumed to exist (e.g. by hand) in the Terraform Provider.
	Generate bool `json:"generate"`

	// OtherTests optionally specifies a map of Test Name (key) to a slice of Test Configurations (value) which
	// are output as Acceptance Tests.
	OtherTests *map[string][]TerraformTestDefinition `json:"otherTests,omitempty"`

	// TemplateConfiguration optionally specifies a Terraform Configuration to use as a Template
	// for each of the other tests defined above, which includes any parent Terraform Data Sources
	// or Resources needed to provision the Terraform Resource being tested.
	TemplateConfiguration *TerraformTestDefinition `json:"templateConfiguration,omitempty"`
}
