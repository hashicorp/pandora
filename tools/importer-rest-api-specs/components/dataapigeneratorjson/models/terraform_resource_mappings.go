package models

type ResourceMapping struct {
	// ResourceIdMapping is a list of Resource ID Mappings, defining how a top-level Schema Field
	// gets mapped to/from a Resource ID Segment.
	ResourceIdMapping *[]ResourceIdMapping `json:"ResourceIdMapping,omitempty"`

	// DirectAssignmentMappings defines information for this Mapping when Type is set to DirectAssignment.
	DirectAssignmentMappings *[]DirectAssignmentMappings `json:"DirectAssignmentFieldMappings,omitempty"`

	/// ModelToModelMappings is a list of the Model to Model Mappings
	ModelToModelMappings *[]ModelToModelMappings `json:"ModelToModelFieldMappings,omitempty"`
}

type ResourceIdMapping struct {
	// SchemaFieldName is the name of the (top-level) Schema Field which the Segment
	// named in SegmentName should be mapped to/from.
	SchemaFieldName string `json:"SchemaFieldName"`

	// SegmentName is the name of the ResourceId Segment which should be mapped to/from
	// the Schema Field defined in SchemaFieldName.
	SegmentName string `json:"SegmentName"`

	// ParsedFromParentID specifies whether the field in SchemaFieldName is a parent resource.
	ParsedFromParentID bool `json:"ParsedFromParentID"`
}

type DirectAssignmentMappings struct {
	// SchemaModelName specifies the name of the Schema Model used for this DirectAssignment Mapping.
	SchemaModelName string `json:"SchemaModelName"`

	// SchemaFieldName specifies the name of the Field within the SchemaModel
	SchemaFieldPath string `json:"SchemaFieldPath"`

	// SdkModelName specifies the name of the Sdk Model used for this DirectAssignment Mapping.
	SdkModelName string `json:"SdkModelName"`

	// SdkFieldName specifies the name of the Field within the Sdk Model
	SdkFieldPath string `json:"SdkFieldPath"`
}

type ModelToModelMappings struct {
	// SchemaModelName specifies the name of the Schema Model used for this ModelToModel Mapping.
	SchemaModelName string `json:"SchemaModelName"`

	// SdkModelName specifies the name of the Sdk Model used for this ModelToModel Mapping.
	SdkModelName string `json:"SdkModelName"`

	// SdkFieldName specifies the name of the Field within the Sdk Model
	SdkFieldName string `json:"SdkFieldName"`
}
