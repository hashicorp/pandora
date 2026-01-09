// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationResourceIdAdded{}

// OperationResourceIdAdded defines when a Resource Id is added to an existing Operation.
type OperationResourceIdAdded struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which now has a Resource Id Name.
	OperationName string

	// NewResourceIdName specifies the new/updated value for the Resource Id Name.
	NewResourceIdName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationResourceIdAdded) IsBreaking() bool {
	return true
}
