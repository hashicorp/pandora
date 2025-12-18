// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationResourceIdRenamed{}

// OperationResourceIdRenamed defines when the Resource Id for an Operation has been renamed.
//
// This is different to OperationResourceIdChanged because the Resource ID is semantically
// the same - therefore we're targeting the same Resource - but this is an internal-only change
// thus whilst this IS a breaking change (to the code) it's not a breaking change in the API.
type OperationResourceIdRenamed struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which has a new/updated Resource Id Name.
	OperationName string

	// NewResourceIdName specifies the new/updated value for the Resource Id Name.
	NewResourceIdName string

	// OldResourceIdName specifies the old/existing value for the Resource Id Name.
	OldResourceIdName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationResourceIdRenamed) IsBreaking() bool {
	// If the Resource Id Name has been renamed (but is the same value under the hood) then this
	// will require code changes to fix.
	return true
}
