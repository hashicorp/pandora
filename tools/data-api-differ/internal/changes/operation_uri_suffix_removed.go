// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationUriSuffixRemoved{}

// OperationUriSuffixRemoved defines when an existing Operation no longer has a Uri Suffix.
type OperationUriSuffixRemoved struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation where the Uri Suffix has changed.
	OperationName string

	// OldValue specifies the old/existing Uri Suffix for this Operation which has been removed.
	OldValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationUriSuffixRemoved) IsBreaking() bool {
	// This would be operating on a different Resource, so is a breaking change.
	return true
}
