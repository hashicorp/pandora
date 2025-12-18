// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ResourceIdSegmentChangedValue{}

// ResourceIdSegmentChangedValue defines where an existing Resource ID Segment changes its value.
// For example there's an updated Name for the Segment, or where the Segment Type changes from a
// String -> Constant.
type ResourceIdSegmentChangedValue struct {
	// ServiceName specifies the name of the Service which contains this Resource ID.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Resource ID.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Resource ID.
	ResourceName string

	// ResourceIdName specifies the name of the Resource ID which contains the Segment that has changed.
	ResourceIdName string

	// SegmentIndex specifies the index of this Resource ID Segment which has changed.
	SegmentIndex int

	// OldValue specifies the old/existing value for this Resource ID Segment.
	OldValue string

	// NewValue specifies the new/updated value for this Resource ID Segment.
	NewValue string

	// StaticIdentifierInNewValue specifies any static identifier present in the updated Resource ID Segment.
	StaticIdentifierInNewValue *string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (r ResourceIdSegmentChangedValue) IsBreaking() bool {
	return true
}
