// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ResourceIdCommonIdAdded{}

// ResourceIdCommonIdAdded defines that a Resource ID which existed previously has
// been updated to be a Common ID.
type ResourceIdCommonIdAdded struct {
	// ServiceName specifies the name of the Service which contained this
	// Resource ID.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contained this
	// Resource ID.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contained this
	// Resource ID.
	ResourceName string

	// ResourceIdName specifies the name of the Resource ID which is now a Common ID.
	ResourceIdName string

	// CommonAliasName specifies the name of the Common Alias for this Resource ID.
	CommonAliasName string

	// ResourceIdValue specifies the value used for this Resource ID e.g. `/foo/{bar}`
	ResourceIdValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ResourceIdCommonIdAdded) IsBreaking() bool {
	// If a Resource ID is now a Common ID this is going to require code changes
	return true
}
