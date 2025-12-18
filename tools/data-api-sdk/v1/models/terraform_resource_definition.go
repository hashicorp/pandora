// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformResourceDefinition defines a Terraform Resource that is either fully or partially generated.
type TerraformResourceDefinition struct {
	// APIResource specifies the name of the APIResource within this APIVersion/Service where the
	// SDK that this Terraform Resource will use.
	APIResource string `json:"resource"` // TODO: update the json struct tag once everything is updated

	// APIVersion specifies the API Version that should be used for this Terraform Resource.
	APIVersion string `json:"apiVersion"`

	// CreateMethod specifies the configuration for the Create method of the generated Terraform Resource.
	// This includes whether this should be generated, the SDKMethod to use and the default timeout.
	CreateMethod TerraformMethodDefinition `json:"createMethod"`

	// DeleteMethod specifies the configuration for the Delete method of the generated Terraform Resource.
	// This includes whether this should be generated, the SDKMethod to use and the default timeout.
	DeleteMethod TerraformMethodDefinition `json:"deleteMethod"`

	// Documentation specifies metadata that's used to generate the Documentation for this Terraform Resource.
	Documentation TerraformDocumentationDefinition `json:"documentation"`

	// DisplayName specifies the human-readable/marketing name for this Terraform Resource.
	// Note that any abbreviations (such as `VM`) should be spelled out - e.g. `Virtual Machine` rather than `VM`.
	DisplayName string `json:"displayName"`

	// Generate specifies whether this Terraform Resource should be generated or not.
	Generate bool `json:"generate"`

	// GenerateModel specifies whether the Terraform Schema Model(s) should be generated for this
	// Terraform Resource.
	// If this is set to `false` then this must be specified in the Provider by hand.
	GenerateModel bool `json:"generateModel"`

	// GenerateIDValidation specifies whether the Resource ID Validation function should be generated
	// for this Resource - which is used during Terraform Import.
	// If this is set to `false` then this must be specified in the Provider by hand.
	GenerateIDValidation bool `json:"generateIdValidation"`

	// GenerateSchema specifies whether the Terraform Schema should be generated for this Terraform Resource.
	// If this is set to `false` then this must be specified in the Provider by hand.
	GenerateSchema bool `json:"generateSchema"`

	// Mappings specifies the Terraform Mappings for this Terraform Resource.
	// These define how SDKField's within SDKModel's are mapped onto TerraformSchemaField's within the associated
	// TerraformSchemaModel's for this Terraform Resource.
	Mappings TerraformMappingDefinition `json:"mappings"`

	// ReadMethod specifies the configuration for the Read method of the generated Terraform Resource.
	// This includes whether this should be generated, the SDKMethod to use and the default timeout.
	ReadMethod TerraformMethodDefinition `json:"readMethod"`

	// ResourceIDName specifies the name of the Resource ID used for this Terraform Resource.
	ResourceIDName string `json:"resourceIdName"`

	// ResourceLabel specifies the label for this Resource, without any Provider Prefix.
	// Example: `resource_group` (to form `azurerm_resource_group`).
	ResourceLabel string `json:"resourceLabel"`

	// ResourceName specifies the name of this Resource.
	// The Resource Name is an Identifier.
	ResourceName string `json:"resourceName"`

	// SchemaModelName specifies the name of the Terraform Schema Model for this Terraform Resource
	SchemaModelName string `json:"schemaModelName"`

	// SchemaModels specifies a map of Schema Model Name (key) to TerraformSchemaModel (value) which
	// defines the Terraform Schema Models used in this Terraform Resource. This contains both the
	// top-level Schema Model (referenced in SchemaModelName) and any nested Schema Models.
	SchemaModels map[string]TerraformSchemaModel `json:"schemaModels"`

	// Tests specifies the Terraform Configurations used to test this Terraform Resource.
	Tests TerraformResourceTestsDefinition `json:"tests"`

	// UpdateMethod optionally specifies the configuration for the Update method of the generated Terraform
	// Resource.
	// This includes whether this should be generated, the SDKMethod to use and the default timeout.
	// Note that not all Terraform Resources support update - which is signified by this field being nil.
	UpdateMethod *TerraformMethodDefinition `json:"updateMethod,omitempty"`
}
