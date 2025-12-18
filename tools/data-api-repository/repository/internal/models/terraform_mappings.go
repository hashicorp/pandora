// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformMappingDefinition defines a Mappings between a Terraform Resource and
// the Models used within the SDK.
// In the future this'll also be used for defining the mappings between a Terraform
// Data Source and the Models - hence this not specific to a Resource.
type TerraformMappingDefinition struct {
	// FieldMappings defines the mappings between Fields within a TerraformSchemaModel
	// and the Fields within an SDK Model.
	//
	// These allow the values to be mapped onto each other - either via (direct)
	// assignment (e.g. `foo = bar`) or using some form of transformation process
	// (e.g. `foo = map(bar)`).
	FieldMappings *[]TerraformFieldMappingDefinition `json:"fieldMappings,omitempty"`

	// ModelToModelMappings is a list of the Model to Model Mappings
	//
	// These are used to generate the Mapping functions between a TerraformSchemaModel
	// and a Model used in the SDK.
	ModelToModelMappings *[]TerraformModelToModelMappingDefinition `json:"modelToModelMappings,omitempty"`

	// ResourceIdMappings is a list of the Resource ID Mappings
	//
	// These define the mappings between a field within the top-level TerraformSchemaModel
	// for a Resource and a given Resource ID Segment name.
	ResourceIdMappings *[]TerraformResourceIdMappingDefinition `json:"resourceIdMappings,omitempty"`
}

// TerraformFieldMappingDefinition defines the Mapping between a Field in the Terraform Schema
// and a Field within an SDK Model.
type TerraformFieldMappingDefinition struct {
	// Type specifies the TerraformFieldMappingDefinitionType that is used for this field, such as
	// DirectAssignmentTerraformFieldMappingDefinitionType
	Type TerraformFieldMappingDefinitionType `json:"type"`

	// DirectAssignment specifies the mapping information when Type is set to
	// DirectAssignmentTerraformFieldMappingDefinitionType.
	DirectAssignment *TerraformFieldMappingDirectAssignmentDefinition `json:"directAssignment,omitempty"`

	// ModelToModel specifies the mapping information when Type is set to
	// ModelToModelTerraformFieldMappingDefinitionType.
	ModelToModel *TerraformFieldMappingModelToModelDefinition `json:"modelToModel,omitempty"`

	// Manual contains additional metadata when Type is set to ManualTerraformFieldMappingDefinitionType.
	Manual *TerraformFieldManualMappingDefinition `json:"manual,omitempty"`
}

// TerraformFieldMappingDefinitionType is used to indicate the type of Mapping Definition being expected
type TerraformFieldMappingDefinitionType string

const (
	// DirectAssignmentTerraformFieldMappingDefinitionType specifies that this mapping defines a Direct Assignment
	// between a given Field within the Terraform Schema Model and a given Field in an SDK Model.
	DirectAssignmentTerraformFieldMappingDefinitionType TerraformFieldMappingDefinitionType = "DirectAssignment"

	// ModelToModelTerraformFieldMappingDefinitionType specifies that this mapping defines a ModelToModel mapping
	// where the specified Schema Model should be mapped onto the given Field within a SDK Model - which relies
	// on a TerraformModelToModelMappingDefinition existing to define the mapping between the Schema Model and
	// the SDK Model.
	ModelToModelTerraformFieldMappingDefinitionType TerraformFieldMappingDefinitionType = "ModelToModel"

	// ManualTerraformFieldMappingDefinitionType specifies that this mapping must be done manually.
	// Whilst this isn't currently used, it's piped through to allow an escape-hatch for atypical
	// scenarios requiring custom transformations.
	ManualTerraformFieldMappingDefinitionType TerraformFieldMappingDefinitionType = "Manual"

	// TODO: support for other types of mappings e.g. BooleanEquals, BooleanInvert
)

// TerraformFieldMappingDirectAssignmentDefinition is used to define a mapping from a given Schema Field
// identified by SchemaModelName and SchemaFieldPath and the SDK Model identified by SdkModelName and
// SdkFieldPath.
//
// A Direct Assignment specifies that these values should be mapped between each other, using whatever
// transformation is necessary (for example, if one is a pointer and the other isn't, the Terraform
// generator must account for that during output).
type TerraformFieldMappingDirectAssignmentDefinition struct {
	// SchemaModelName specifies the name of the SchemaModel where this value should be mapped from.
	SchemaModelName string `json:"schemaModelName"`

	// SchemaFieldPath specifies the path to the field within SchemaModelName (e.g. `Foo` or `Foo.Bar`)
	// which this should be mapped from.
	SchemaFieldPath string `json:"schemaFieldPath"`

	// SdkModelName specifies the name of the SdkModel where this value should be mapped onto.
	SdkModelName string `json:"sdkModelName"`

	// SdkFieldPath specifies the Path to the Field within the SdkModel where the Schema Field
	// should be mapped onto.
	SdkFieldPath string `json:"sdkFieldPath"`
}

// TerraformFieldMappingModelToModelDefinition is used to define the mapping between a Schema Model
// and a given SDK Field (within an SDK Model) - indicating that mapping functions should be
// generated between these types.
type TerraformFieldMappingModelToModelDefinition struct {
	// SchemaModelName specifies the name of the SchemaModel where this value should be mapped from.
	SchemaModelName string `json:"schemaModelName"`

	// SdkModelName specifies the name of the SdkModel where this value should be mapped onto.
	SdkModelName string `json:"sdkModelName"`

	// SdkFieldName specifies the Name of the Field within the SdkModel where the Schema Field
	// should be mapped onto.
	SdkFieldName string `json:"sdkFieldName"`
}

// TerraformFieldManualMappingDefinition is used to define that this field must be manually
// mapped - which relies on the method defined in MethodName existing in the Provider.
type TerraformFieldManualMappingDefinition struct {
	// MethodName specifies the name of the Manual mapping method used to map between the Schema and SDK Types
	MethodName string `json:"methodName"`
}

// TerraformModelToModelMappingDefinition is used to define that the Schema Model named in
// SchemaModelName should be transformed to and from the Sdk Model named in SdkModelName.
type TerraformModelToModelMappingDefinition struct {
	// SchemaModelName specifies the name of the Schema Model that there's Mappings for.
	SchemaModelName string `json:"schemaModelName"`

	// SdkModelName specifies the name of the Sdk Model that there's Mappings for.
	SdkModelName string `json:"sdkModelName"`
}

// TerraformResourceIdMappingDefinition is used to define the mappings between the Resource ID
// segments and the (main) Terraform Schema Model for this resource.
type TerraformResourceIdMappingDefinition struct {
	// ParsedFromParentId specifies whether the field specified in SchemaFieldName is from
	// the Parent Resource ID rather than the current Resource ID.
	ParsedFromParentId bool `json:"parsedFromParentId"`

	// SchemaFieldName specifies the name of the (root-level) Schema Field which the Segment
	// named in SegmentName should be mapped to/from.
	SchemaFieldName string `json:"schemaFieldName"`

	// SegmentName specifies the name of the ResourceId Segment which should be mapped
	// to/from the Schema Field specified in SchemaFieldName.
	SegmentName string `json:"segmentName"`
}
