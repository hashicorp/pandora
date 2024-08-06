// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

// ResourceId defines the ID for a given Azure Resource which comprises one or more Segments.
type ResourceId struct {
	// Name specifies the Name of this ResourceId, for example `VirtualMachine`.
	Name string `json:"name"`

	// CommonAlias specifies the Name of the CommonId (from `hashicorp/go-azure-sdk`) that
	// this ResourceId represents.
	CommonAlias *string `json:"commonAlias,omitempty"`

	// Id specifies an example of the templated value for this Resource ID
	// for example `/subscriptions/{subscriptionId}` which can be used in documentation, such as
	// during `terraform import` examples.
	Id string `json:"id"` // TODO: does this want renaming to `ExampleValue` to be clearer?

	// Segments specifies the ordered list of ResourceIdSegments which comprise this ResourceId.
	// Typically, these comprise Static and UserSpecified Segment Types.
	Segments []ResourceIdSegment `json:"segments"`
}

type ResourceIdSegment struct {
	// ConstantName specifies the name of the Constant used for this ResourceIdSegment when
	// Type is set to ConstantResourceIdSegmentType.
	ConstantName *string `json:"constantName,omitempty"`

	// Name specifies the name for this ResourceId segment, which should be both unique and
	// type safe and unique - as this is used as both the name of a Field.
	Name string `json:"name"`

	// Type specifies what kind of ResourceIdSegment this is, for example a User Specified or
	// Static value.
	Type ResourceIdSegmentType `json:"type"`

	// Value specifies the fixed/required value for this ResourceIdSegment when Type is
	// set to ResourceProvider, Static.
	Value *string `json:"value,omitempty"`
}

type ResourceIdSegmentType string

const (
	// ConstantResourceIdSegmentType specifies that this Segment is a Constant
	ConstantResourceIdSegmentType ResourceIdSegmentType = "Constant"

	// ResourceGroupResourceIdSegmentType specifies that this Segment is a Resource Group name
	ResourceGroupResourceIdSegmentType ResourceIdSegmentType = "ResourceGroup"

	// ResourceProviderResourceIdSegmentType specifies that this Segment is a Resource Provider
	ResourceProviderResourceIdSegmentType ResourceIdSegmentType = "ResourceProvider"

	// ScopeResourceIdSegmentType specifies that this Segment is a Scope
	ScopeResourceIdSegmentType ResourceIdSegmentType = "Scope"

	// StaticResourceIdSegmentType specifies that this Segment is a Static/Fixed Value
	StaticResourceIdSegmentType ResourceIdSegmentType = "Static"

	// SubscriptionIdResourceIdSegmentType specifies that this Segment is a Subscription ID
	SubscriptionIdResourceIdSegmentType ResourceIdSegmentType = "SubscriptionId"

	// UserSpecifiedResourceIdSegmentType specifies that this Segment is User-Specifiable
	UserSpecifiedResourceIdSegmentType ResourceIdSegmentType = "UserSpecified"
)
