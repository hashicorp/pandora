// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// ResourceIDSegment defines a Segment within a ResourceID.
// Each ResourceIDSegment comprises a unique Name and a Type which describes
// the expected shape of the Resource ID Segment.
type ResourceIDSegment struct {
	// ConstantReference specifies the name of the SDKConstant used within this ResourceIDSegment.
	// This is only specified when Type is set to ConstantResourceIDSegmentType - and when it is
	// the parsed value MUST be one of the associated Values for the SDK Constant.
	ConstantReference *string `json:"constantReference,omitempty"`

	// ExampleValue provides an example of a valid value for this ResourceIDSegment.
	// This is intended to be used in both documentation and error messages and as such
	// should be both a good example and as short/clear as reasonably possible.
	ExampleValue string `json:"exampleValue"`

	// FixedValue specifies the Fixed, Static (Exact) Value this ResourceIDSegment must contain
	// when Type is set to ResourceProviderResourceIDSegmentType or StaticResourceIDSegmentType.
	FixedValue *string `json:"fixedValue,omitempty"`

	// Type specifies the Type of ResourceIDSegment this is - in most cases these are either
	// a Static Value represented by StaticResourceIDSegmentType or a User-Specified value
	// represented by UserSpecifiedResourceIDSegmentType.
	Type ResourceIDSegmentType `json:"type"`

	// Name specifies a unique name for this ResourceIDSegment.
	// This is primarily used as a unique key for the dictionary returned when a Resource ID is
	// parsed - however it's also used in a few error messages and thus should aim to be
	// user-friendly (albeit these are auto-generated).
	Name string `json:"name"`
}
