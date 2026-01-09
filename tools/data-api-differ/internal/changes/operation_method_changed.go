// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationMethodChanged{}

// OperationMethodChanged defines when the HTTP Method used for an existing Operation changes.
type OperationMethodChanged struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which has an updated HTTP Method.
	OperationName string

	// OldValue specifies the old/existing HTTP Method for this Operation.
	OldValue string

	// NewValue specifies the new/updated HTTP Method for this Operation.
	NewValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationMethodChanged) IsBreaking() bool {
	// If the HTTP Method for the Operation has changed this is an entirely different Operation
	// and this is a breaking change.
	return true
}
