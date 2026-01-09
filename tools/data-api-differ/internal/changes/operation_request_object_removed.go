// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationRequestObjectRemoved{}

// OperationRequestObjectRemoved defines that a Request Object has been removed from an existing Operation.
type OperationRequestObjectRemoved struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which no longer has a Request Object.
	OperationName string

	// OldRequestObject specifies the old/existing value for the Request Object.
	OldRequestObject string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationRequestObjectRemoved) IsBreaking() bool {
	// This will require code changes
	return true
}
