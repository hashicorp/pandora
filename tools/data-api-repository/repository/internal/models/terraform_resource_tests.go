// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformResourceTestConfig describes the various test configurations that a Resource will be tested against
type TerraformResourceTestConfig struct {
	// BasicConfig specifies the Terraform Configuration used for the Basic test
	// which sets the bare minimum number of fields required to provision this resource.
	// This is to ensure the happy path.
	BasicConfig string `json:"basicConfig"`

	// CompleteConfig specifies the Terraform Configuration used for the Complete test
	// which should set all the possible attributes for the current Terraform Resource.
	// A Complete test is optional, for example where it only contains a subset of fields.
	CompleteConfig *string `json:"completeConfig,omitempty"`

	// Generate specifies whether the Acceptance Tests should be generated or not.
	Generate bool `json:"generate"`

	// OtherTests is a map of key (TestName) to value (a slice of Test Configurations) which
	// should be output as Acceptance Tests.
	OtherTests map[string][]string `json:"otherTests"`

	// RequiresImport specifies the Terraform Configuration used for the RequiresImport test
	// This test typically provisions the Basic test and then tries to provision the exact
	// same resource to ensure that we don't unintentionally adopt an existing resource during
	// creation.
	RequiresImport string `json:"requiresImport"`

	// TemplateConfig specifies any Terraform Data Sources, Resources and Variables which are needed
	// by all Tests - more granular dependencies (such as a dependency needed in one test configuration)
	// should be defined within individual tests.
	TemplateConfig *string `json:"templateConfig,omitempty"`
}
