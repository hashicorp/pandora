// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = FieldJsonNameChanged{}

// FieldJsonNameChanged defines when the JsonName for an existing Field within an existing Model
// changes - indicating this field represents a different field in the API Request/Response.
type FieldJsonNameChanged struct {
	// ServiceName specifies the name of the Service which contains this Field.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Field.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Field.
	ResourceName string

	// ModelName specifies the name of the Model which contains this Field.
	ModelName string

	// FieldName specifies the name of the Field which has an updated JsonName.
	FieldName string

	// OldValue specifies the old/existing JsonName for this Field.
	OldValue string

	// NewValue specifies the new/updated JsonName for this Field.
	NewValue string
}

func (FieldJsonNameChanged) IsBreaking() bool {
	// If the JSON Name for this field has changed in the API then this is a breaking change
	// since existing (or perhaps new) callers will be unable to marshal the existing result.
	// As such this requires additional investigation.
	return true
}
