// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationPaginationFieldChanged{}

// OperationPaginationFieldChanged defines where an existing Operation has an updated value for the
// Pagination Field.
type OperationPaginationFieldChanged struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation where the Pagination Field has changed.
	OperationName string

	// OldValue specifies the old/existing value for the Pagination Field for this operation.
	OldValue string

	// NewValue specifies the new/updated value for the Pagination Field for this operation.
	NewValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationPaginationFieldChanged) IsBreaking() bool {
	// This is going to cause a breakage - either to the existing code (as used today, which would be
	// a regression) - or in the updated code - and will require manual investigation.
	return true
}
