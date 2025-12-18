// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationResponseObjectRemoved{}

// OperationResponseObjectRemoved defines that a Response Object has been removed from an existing Operation.
type OperationResponseObjectRemoved struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which no longer has a Response Object.
	OperationName string

	// OldResponseObject specifies the old/existing value for the Response Object.
	OldResponseObject string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationResponseObjectRemoved) IsBreaking() bool {
	// This will require code changes
	return true
}
