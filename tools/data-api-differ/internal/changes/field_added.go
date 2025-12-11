// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = FieldAdded{}

// FieldAdded defines information about a new Field.
type FieldAdded struct {
	// ServiceName specifies the name of the Service which contains this Field.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Field.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Field.
	ResourceName string

	// ModelName specifies the name of the Model which contains this Field.
	ModelName string

	// FieldName specifies the name of the Field which has been added.
	FieldName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (FieldAdded) IsBreaking() bool {
	return false
}
