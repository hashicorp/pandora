// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationUriSuffixAdded{}

// OperationUriSuffixAdded defines when an existing Operation now has a Uri Suffix.
type OperationUriSuffixAdded struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation where the Uri Suffix has been added.
	OperationName string

	// NewValue specifies the new/updated Uri Suffix for this Operation.
	NewValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationUriSuffixAdded) IsBreaking() bool {
	// This would be operating on a different Resource, so is a breaking change.
	return true
}
