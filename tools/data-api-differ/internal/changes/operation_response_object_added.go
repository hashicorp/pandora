// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationResponseObjectAdded{}

// OperationResponseObjectAdded defines that a Response Object has been added to an existing Operation.
type OperationResponseObjectAdded struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which now has a Response Object.
	OperationName string

	// NewResponseObject specifies the new/updated value for the Response Object.
	NewResponseObject string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationResponseObjectAdded) IsBreaking() bool {
	// This will require code changes
	return true
}
