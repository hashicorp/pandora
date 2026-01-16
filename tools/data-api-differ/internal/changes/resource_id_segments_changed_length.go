// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ResourceIdSegmentsChangedLength{}

// ResourceIdSegmentsChangedLength defines when an existing Resource ID has an entirely different set
// of Resource ID Segments - because the Length of the Resource ID Segments differs between the older
// and updated Resource ID.
type ResourceIdSegmentsChangedLength struct {
	// ServiceName specifies the name of the Service which contains this Resource ID.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Resource ID.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Resource ID.
	ResourceName string

	// ResourceIdName specifies the name of the Resource ID which contains the Segments that has changed.
	ResourceIdName string

	// OldValue specifies the old/existing value for this Resource ID.
	OldValue []string

	// NewValue specifies the new/updated value for this Resource ID.
	NewValue []string

	// StaticIdentifiersInNewValue specifies a unique, sorted list of Static Identifiers (such as Resource
	// Provider Name and any Static Values) present within the new/updated value for this Resource ID Segment.
	StaticIdentifiersInNewValue []string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ResourceIdSegmentsChangedLength) IsBreaking() bool {
	// If an existing Resource ID has added/removed a Segment this is a breaking change
	// which requires additional investigation/understanding.
	return true
}
