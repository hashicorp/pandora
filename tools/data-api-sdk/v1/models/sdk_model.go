// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

// SDKModel defines a Model used in an SDKOperation.
// A SDKModel should contain at least one field - unless it's a Discriminated Type
// when it may only contain fields from its parent.
type SDKModel struct {
	// DiscriminatedValue optionally specifies the Discriminated Value for this Discriminated Implementation.
	DiscriminatedValue *string `json:"typeHintValue,omitempty"` // TODO: update the json struct tag once everything is switched over

	// FieldNameContainingDiscriminatedValue optionally specifies the Name of the Field which
	// contains the Discriminated Value used to uniquely identify the Discriminated Implementation.
	FieldNameContainingDiscriminatedValue *string `json:"typeHintIn"` // TODO: update the json struct tag once everything is switched over

	// Fields specifies a map of key (FieldName) to value (SDKField) which describes
	// the Fields present within this SDKModel.
	// NOTE: the Field Name is a valid Identifier.
	Fields map[string]SDKField `json:"fields"`

	// IsParent specifies whether this model is a known parent model, typically for discriminated child models.
	IsParent bool

	// ParentTypeName optionally specifies the name of the Parent Type for this Model.
	// If a ParentTypeName is present then this SDKModel will be a Discriminated Implementation
	// meaning that a TypeHintIn and TypeHintValue must also be specified in order to uniquely
	// identify this SDKModel from the Parent Type.
	ParentTypeName *string `json:"parentTypeName"`
}

// IsDiscriminatedImplementation returns whether this SDKModel is a Discriminated Implementation.
// This means that this Model has both a Parent Type and a Discriminated Value.
func (m SDKModel) IsDiscriminatedImplementation() bool {
	return m.ParentTypeName != nil && m.DiscriminatedValue != nil
}

// IsDiscriminatedParentType returns whether this SDKModel is a Discriminated Parent Type.
// This means that this SDKModel will have associated Discriminated Implementations.
func (m SDKModel) IsDiscriminatedParentType() bool {
	return m.IsParent || (m.ParentTypeName == nil && m.FieldNameContainingDiscriminatedValue != nil)
}
