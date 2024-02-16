package parser

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// NewConstantResourceIDSegment returns a configured ResourceIDSegment which represents
// the value from a Constant. The user-provided value for this Resource ID Segment MUST
// represent one of the values specified in the Constant.
func NewConstantResourceIDSegment(name, constantReferenceName, exampleValue string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		ConstantReference: pointer.To(constantReferenceName),
		ExampleValue:      exampleValue,
		Name:              name,
		Type:              resourcemanager.ConstantSegment,
	}
}

// NewResourceGroupNameResourceIDSegment returns a configured ResourceIDSegment which represents
// the value of a Resource Group Name.
func NewResourceGroupNameResourceIDSegment(name string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		ExampleValue: "example-resources",
		Name:         name,
		Type:         resourcemanager.ResourceGroupSegment,
	}
}

// NewResourceProviderResourceIDSegment returns a configured ResourceIDSegment which represents
// the value of an Azure Resource Provider.
func NewResourceProviderResourceIDSegment(name, resourceProviderName string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		ExampleValue: resourceProviderName,
		FixedValue:   pointer.To(resourceProviderName),
		Name:         name,
		Type:         resourcemanager.ResourceProviderSegment,
	}
}

// NewScopeResourceIDSegment returns a configured ResourceIDSegment which represents
// the value of an Azure Resource Scope.
func NewScopeResourceIDSegment(name string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		ExampleValue: "/subscriptions/11112222-3333-4444-555566667777/resourceGroups/example-resources",
		Name:         name,
		Type:         resourcemanager.ScopeSegment,
	}
}

// NewStaticValueResourceIDSegment returns a configured ResourceIDSegment which represents
// a fixed/static value.
func NewStaticValueResourceIDSegment(name, fixedValue string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		ExampleValue: fixedValue,
		FixedValue:   pointer.To(fixedValue),
		Name:         name,
		Type:         resourcemanager.StaticSegment,
	}
}

// NewSubscriptionIDResourceIDSegment returns a configured ResourceIDSegment which represents
// the value of a Subscription ID.
func NewSubscriptionIDResourceIDSegment(name string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		ExampleValue: "11112222-3333-4444-555566667777",
		Name:         name,
		Type:         resourcemanager.SubscriptionIdSegment,
	}
}

// NewUserSpecifiedResourceIDSegment returns a configured ResourceIDSegment which represents
// a User Specified value.
func NewUserSpecifiedResourceIDSegment(name, exampleValue string) resourcemanager.ResourceIdSegment {
	return resourcemanager.ResourceIdSegment{
		ExampleValue: exampleValue,
		Name:         name,
		Type:         resourcemanager.UserSpecifiedSegment,
	}
}
