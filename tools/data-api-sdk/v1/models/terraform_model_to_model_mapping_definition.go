// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformModelToModelMappingDefinition defines XXX.
// This is used to output both the `map{TerraformSchemaModelName}To{SDKModelName}` and
// `map{SDKModelName}To{TerraformSchemaModelName}` functions.
type TerraformModelToModelMappingDefinition struct {
	// SDKModelName specifies the name of the SDKModel which should be mapped to/from the
	// TerraformSchemaModel named in TerraformSchemaModelName.
	SDKModelName string `json:"sdkModelName"`

	// TerraformSchemaModelName specifies the name of the TerraformSchemaModel which should
	// be mapped to/from the SDKModel named in SDKModelName.
	TerraformSchemaModelName string `json:"schemaModelName"`
}
