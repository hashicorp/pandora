// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationResourceIdRemoved{}

// OperationResourceIdRemoved defines that an existing Operation no longer requires a Resource ID.
type OperationResourceIdRemoved struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which now has a Resource Id Name.
	OperationName string

	// OldResourceIdName specifies the old/existing value for the Resource Id Name.
	OldResourceIdName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationResourceIdRemoved) IsBreaking() bool {
	// If a Resource ID is removed from an Operation then this will be a breaking change.
	return true
}
