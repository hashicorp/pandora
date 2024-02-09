// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

import "github.com/hashicorp/go-azure-helpers/lang/pointer"

// NewConstantResourceIDSegment returns a configured ResourceIDSegment which represents
// the value from a Constant. The user-provided value for this Resource ID Segment MUST
// represent one of the values specified in the Constant.
func NewConstantResourceIDSegment(name, constantReferenceName string) ResourceIDSegment {
	return ResourceIDSegment{
		ConstantReference: pointer.To(constantReferenceName),
		Name:              name,
		Type:              ConstantResourceIDSegmentType,
	}
}

// NewResourceGroupNameResourceIDSegment returns a configured ResourceIDSegment which represents
// the value of a Resource Group Name.
func NewResourceGroupNameResourceIDSegment(name string) ResourceIDSegment {
	return ResourceIDSegment{
		Name: name,
		Type: ResourceGroupResourceIDSegmentType,
	}
}

// NewResourceProviderResourceIDSegment returns a configured ResourceIDSegment which represents
// the value of an Azure Resource Provider.
func NewResourceProviderResourceIDSegment(name, resourceProviderName string) ResourceIDSegment {
	return ResourceIDSegment{
		FixedValue: pointer.To(resourceProviderName),
		Name:       name,
		Type:       ResourceProviderResourceIDSegmentType,
	}
}

// NewScopeResourceIDSegment returns a configured ResourceIDSegment which represents
// the value of an Azure Resource Scope.
func NewScopeResourceIDSegment(name string) ResourceIDSegment {
	return ResourceIDSegment{
		Name: name,
		Type: ScopeResourceIDSegmentType,
	}
}

// NewStaticValueResourceIDSegment returns a configured ResourceIDSegment which represents
// a fixed/static value.
func NewStaticValueResourceIDSegment(name, fixedValue string) ResourceIDSegment {
	return ResourceIDSegment{
		FixedValue: pointer.To(fixedValue),
		Name:       name,
		Type:       StaticResourceIDSegmentType,
	}
}

// NewSubscriptionIDResourceIDSegment returns a configured ResourceIDSegment which represents
// the value of a Subscription ID.
func NewSubscriptionIDResourceIDSegment(name string) ResourceIDSegment {
	return ResourceIDSegment{
		Name: name,
		Type: SubscriptionIDResourceIDSegmentType,
	}
}

// NewUserSpecifiedResourceIDSegment returns a configured ResourceIDSegment which represents
// a User Specified value.
func NewUserSpecifiedResourceIDSegment(name string) ResourceIDSegment {
	return ResourceIDSegment{
		Name: name,
		Type: UserSpecifiedResourceIDSegmentType,
	}
}
