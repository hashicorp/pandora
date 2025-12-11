// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformFieldMappingDefinitionType specifies a type of mapping for a TerraformSchemaField.
// The specifics of the type of mapping change based on the implementation - but map a
// TerraformSchemaField to/from a SDKField in some manner.
type TerraformFieldMappingDefinitionType = string

const (
	// DirectAssignmentTerraformFieldMappingDefinitionType specifies a DirectAssignment mapping.
	// This represents a literal direct assignment (e.g. `sdkmodel.SomeField = schemamodel.SomeField`).
	DirectAssignmentTerraformFieldMappingDefinitionType TerraformFieldMappingDefinitionType = "DirectAssignment"

	// ModelToModelTerraformFieldMappingDefinitionType specifies a ModelToModel mapping for a TerraformSchemaField.
	// This represents an SDKField needs to be mapped to/from a TerraformSchemaModel.
	ModelToModelTerraformFieldMappingDefinitionType TerraformFieldMappingDefinitionType = "ModelToModel"

	// TODO: support for other mapping types (e.g. BooleanEquals, BooleanInvert) in the future
)
