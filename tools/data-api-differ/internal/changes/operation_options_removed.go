// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationOptionsRemoved{}

// OperationOptionsRemoved defines where an existing Operation no longer supports Options.
type OperationOptionsRemoved struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which no longer supports Options.
	OperationName string

	// OldValue specifies a slice of the old/existing Options for this Operation.
	OldValue map[string]string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationOptionsRemoved) IsBreaking() bool {
	// This will require code changes so is a breaking change
	return true
}
