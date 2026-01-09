// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformResourceIDMappingDefinition defines how a TerraformSchemaField should be mapped to/from a ResourceIDSegment.
// This allows mapping fields which only exist within the ResourceID (such as a ResourceGroupName) to be retrieved
// from and stored within the top-level TerraformSchemaModel for a Terraform Resource.
type TerraformResourceIDMappingDefinition struct {
	// ParsedFromParentID specifies whether the TerraformSchemaField named in TerraformSchemaFieldName
	// comes from the Parent Resources ResourceID rather than the ResourceID for the current Terraform Resource.
	ParsedFromParentID bool `json:"parsedFromParentId"`

	// SegmentName specifies the Name of the ResourceIDSegment within the ResourceID where the
	// TerraformSchemaField named in TerraformSchemaFieldName should be mapped to/from.
	SegmentName string `json:"segmentName"`

	// TerraformSchemaFieldName specifies the Name of the TerraformSchemaField within the top-level
	// TerraformSchemaModel where the ResourceIDSegment named in SegmentName should be mapped to/from.
	TerraformSchemaFieldName string `json:"schemaFieldName"` // TODO: update the json struct tag name once refactored?
}
