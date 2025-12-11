// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationResourceIdChanged{}

// OperationResourceIdChanged defines when the Resource Id for an Operation has changed value.
//
// This is different to OperationResourceIdRenamed because in this instance the underlying
// Resource ID Value (i.e. URI) has changed (i.e. a new Resource) - rather than being renamed.
type OperationResourceIdChanged struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which has a new/updated Resource Id Name.
	OperationName string

	// OldResourceIdName specifies the old/existing value for the Resource ID Name.
	OldResourceIdName string

	// OldValue specifies the old/existing value for this Resource ID.
	OldValue string

	// NewResourceIdName specifies the new/updated value for the Resource ID Name.
	NewResourceIdName string

	// NewValue specifies the new/updated value for this Resource ID.
	NewValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationResourceIdChanged) IsBreaking() bool {
	// If the ResourceId used by this Operation has changed this would require code changes.
	return true
}
