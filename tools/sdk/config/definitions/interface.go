// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package definitions

type Config struct {
	// Services is a map of ServiceName : ServiceDefinition
	Services map[string]ServiceDefinition
}

type ServiceDefinition struct {
	// APIVersions is a map of ApiVersion : ApiVersionDefinition
	ApiVersions map[string]ApiVersionDefinition

	// TerraformPackageName is the name of the associated Service Package within Terraform
	TerraformPackageName string
}

type ApiVersionDefinition struct {
	// Packages is a map of ResourceName : PackageDefinition
	Packages map[string]PackageDefinition
}

type PackageDefinition struct {
	// Definitions is a map of ResourceType : ResourceDefinition
	Definitions map[string]ResourceDefinition
}

type ResourceDefinition struct {
	// TODO: this wants moving elsewhere and documenting, but for simplicity for now:
	ServiceName   string
	APIVersion    string
	APIResource   string
	ResourceLabel string

	// ID is the Resource ID which defines this Resource
	ID string

	// Name is the human-friendly/marketing name for this Resource
	Name string

	// GenerateCreate specifies whether the create method should be generated or not
	GenerateCreate bool

	// GenerateDelete specifies whether the Delete method should be generated or not
	GenerateDelete bool

	// GenerateRead specifies whether the read method should be generated or not
	GenerateRead bool

	// GenerateUpdate specifies whether the update method should be generated or not
	GenerateUpdate bool

	// WebsiteSubcategory is the name of the subcategory which this Resource should appear under on the website
	WebsiteSubcategory string

	// Description is the description for this Resource
	Description string

	// TestData contains specific values for the tests of this resource
	TestData ResourceTestDataDefinition

	// Overrides contains a mapping of properties that require renames or custom descriptions, for now
	Overrides *[]Override
}

type Override struct {
	// Name specifies the field for which the overrides will be applied to
	Name string

	// UpdatedName defines the updated name the field should be renamed to
	UpdatedName *string

	// Description defines a custom description for this field.
	// If unspecified a description will be determined based on the field name.
	Description *string
}

type ResourceTestDataDefinition struct {
	// BasicVariables contains key value pairs of field to test value for different variable types
	BasicVariables VariablesDefinition

	// CompleteVariables contains key value pairs of field to test value for different variable types
	CompleteVariables VariablesDefinition
}

type VariablesDefinition struct {
	Bools    map[string]bool
	Integers map[string]int64
	Lists    map[string][]string
	Strings  map[string]string
}
