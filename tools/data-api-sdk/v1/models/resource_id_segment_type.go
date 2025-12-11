// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// ResourceIDSegmentType defines a Type of ResourceIDSegment.
type ResourceIDSegmentType string

const (
	// ConstantResourceIDSegmentType specifies that the ResourceIDSegment is related to a Constant.
	ConstantResourceIDSegmentType ResourceIDSegmentType = "Constant"

	// ResourceGroupResourceIDSegmentType specifies that the ResourceIDSegment is the name of a Resource Group.
	ResourceGroupResourceIDSegmentType ResourceIDSegmentType = "ResourceGroup"

	// ResourceProviderResourceIDSegmentType specifies that the ResourceIDSegment is the name of a Resource Provider.
	ResourceProviderResourceIDSegmentType ResourceIDSegmentType = "ResourceProvider"

	// ScopeResourceIDSegmentType specifies that the ResourceIDSegment is a Scope (URI Path).
	ScopeResourceIDSegmentType ResourceIDSegmentType = "Scope"

	// StaticResourceIDSegmentType specifies that the ResourceIDSegment is a fixed/static value.
	StaticResourceIDSegmentType ResourceIDSegmentType = "Static"

	// SubscriptionIDResourceIDSegmentType specifies that the ResourceIDSegment is an Azure Subscription ID.
	SubscriptionIDResourceIDSegmentType ResourceIDSegmentType = "SubscriptionId"

	// UserSpecifiedResourceIDSegmentType specifies that the ResourceIDSegment is a User-Specified/Provided value.
	// Typically (but importantly not always) these represent the Name components for a given Resource.
	UserSpecifiedResourceIDSegmentType ResourceIDSegmentType = "UserSpecified"
)
