// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationAdded{}

// OperationAdded defines an Operation which has been added to an existing API Resource.
type OperationAdded struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which has been added.
	OperationName string

	// Uri specifies the URI of the Operation which has been added.
	Uri string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationAdded) IsBreaking() bool {
	return false
}
