// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = FieldIsNowOptional{}

// FieldIsNowOptional defines a change where an existing Field in an existing Model
// has become Optional.
type FieldIsNowOptional struct {
	// ServiceName specifies the name of the Service which contains this Field.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Field.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Field.
	ResourceName string

	// ModelName specifies the name of the Model which contains this Field.
	ModelName string

	// FieldName specifies the name of the Field which is now Optional.
	FieldName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (FieldIsNowOptional) IsBreaking() bool {
	// If the field has gone from Required -> Optional this will change the semantics
	// making this field a pointer in the Go SDK - meaning this will require code changes.
	return true
}
