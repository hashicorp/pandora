package models

// TerraformMappingDefinition defines a Mappings between a Terraform Resource and
// the Models used within the SDK.
// In the future this'll also be used for defining the mappings between a Terraform
// Data Source and the Models - hence this not being specific to a Data Source.
type TerraformMappingDefinition struct {
	// DirectAssignmentMappings defines information for this Mapping when Type is set to DirectAssignment.
	DirectAssignmentMappings *[]TerraformDirectAssignmentMappings `json:"directAssignmentFieldMappings,omitempty"`

	/// ModelToModelMappings is a list of the Model to Model Mappings
	ModelToModelMappings *[]TerraformModelToModelMappings `json:"modelToModelFieldMappings,omitempty"`

	// ResourceIdMapping is a list of Resource ID Mappings, defining how a top-level Schema Field
	// gets mapped to/from a Resource ID Segment.
	ResourceIdMapping *[]TerraformResourceIdMapping `json:"resourceIdMapping,omitempty"`
}

type TerraformResourceIdMapping struct {
	// ParsedFromParentId specifies whether the field in SchemaFieldName is a parent resource.
	ParsedFromParentId bool `json:"parsedFromParentId"`

	// SchemaFieldName is the name of the (top-level) Schema Field which the Segment
	// named in SegmentName should be mapped to/from.
	SchemaFieldName string `json:"schemaFieldName"`

	// SegmentName is the name of the ResourceId Segment which should be mapped to/from
	// the Schema Field defined in SchemaFieldName.
	SegmentName string `json:"segmentName"`
}

type TerraformDirectAssignmentMappings struct {
	// SchemaModelName specifies the name of the Schema Model used for this DirectAssignment Mapping.
	SchemaModelName string `json:"schemaModelName"`

	// SchemaFieldName specifies the name of the Field within the TerraformSchemaModel
	SchemaFieldPath string `json:"schemaFieldPath"`

	// SdkModelName specifies the name of the Sdk Model used for this DirectAssignment Mapping.
	SdkModelName string `json:"sdkModelName"`

	// SdkFieldName specifies the name of the Field within the Sdk Model
	SdkFieldPath string `json:"sdkFieldPath"`
}

type TerraformModelToModelMappings struct {
	// SchemaModelName specifies the name of the Schema Model used for this ModelToModel Mapping.
	SchemaModelName string `json:"schemaModelName"`

	// SdkFieldName specifies the name of the Field within the Sdk Model
	SdkFieldName string `json:"sdkFieldName"`

	// SdkModelName specifies the name of the Sdk Model used for this ModelToModel Mapping.
	SdkModelName string `json:"sdkModelName"`
}
