// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = FieldRemoved{}

// FieldRemoved defines information about a Field which has been removed.
type FieldRemoved struct {
	// ServiceName specifies the name of the Service which contained this Field.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contained this Field.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contained this Field.
	ResourceName string

	// ModelName specifies the name of the Model which contained this Field.
	ModelName string

	// FieldName specifies the name of the Field which has been removed.
	FieldName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (FieldRemoved) IsBreaking() bool {
	return true
}
