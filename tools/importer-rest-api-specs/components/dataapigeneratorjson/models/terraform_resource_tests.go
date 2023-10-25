package models

// TerraformResourceTestConfig describes the various test configurations that a Resource will be tested against
type TerraformResourceTestConfig struct {
	// Basic is the most basic hcl that only contains the minimum attributes needed to create this specific resource
	Basic string `json:"Basic"`

	// RequiresImport is the hcl that will be used to confirm a Resource is imported correctly
	RequiresImport string `json:"RequiresImport"`

	// CompleteConfig is the most complete hcl that contains all the attributes a Resource manages
	CompleteConfig *string `json:"CompleteConfig,omitempty"`

	// TemplateConfig is the hcl that contains the various resources needed to provision this specific resource
	TemplateConfig *string `json:"TemplateConfig,omitempty"`
}
