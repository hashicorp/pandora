// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationOptionsAdded{}

// OperationOptionsAdded defines where an existing Operation now supports Options.
type OperationOptionsAdded struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which has had Options added.
	OperationName string

	// NewValue specifies a slice of the new/updated Options for this Operation.
	NewValue map[string]string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationOptionsAdded) IsBreaking() bool {
	// This will require code changes so is a breaking change
	return true
}
