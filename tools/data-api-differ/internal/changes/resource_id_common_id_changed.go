// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ResourceIdCommonIdChanged{}

// ResourceIdCommonIdChanged defines that an existing Resource ID that previously used a Common ID now
// references a different Common ID - this would happen when a Common ID gets renamed.
type ResourceIdCommonIdChanged struct {
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

	// NewCommonAliasName specifies the new/updated value for the Common Alias associated with this Resource ID.
	NewCommonAliasName string

	// OldCommonAliasName specifies the old/existing value for the Common Alias associated with this Resource ID.
	OldCommonAliasName string

	// OldValue specifies the old/existing value for this Resource ID.
	OldValue string

	// NewValue specifies the new/updated value for this Resource ID.
	NewValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ResourceIdCommonIdChanged) IsBreaking() bool {
	// This is going to require code changes
	return true
}
