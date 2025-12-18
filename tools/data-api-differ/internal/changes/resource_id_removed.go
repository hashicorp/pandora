// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ResourceIdRemoved{}

// ResourceIdRemoved defines information about a Resource ID that has been removed.
type ResourceIdRemoved struct {
	// ServiceName specifies the name of the Service which contained this
	// Resource ID.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contained this
	// Resource ID.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contained this
	// Resource ID.
	ResourceName string

	// ResourceIdName specifies the name of the Resource ID which has been removed.
	ResourceIdName string

	// ResourceIdValue specifies the value used for this Resource ID e.g. `/foo/{bar}`
	ResourceIdValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ResourceIdRemoved) IsBreaking() bool {
	return true
}
