// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestCommonResourceID_ResourceGroup(t *testing.T) {
	valid := sdkModels.ResourceID{
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		},
	}
	invalid := sdkModels.ResourceID{
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("someResource", "someResource"),
			sdkModels.NewUserSpecifiedResourceIDSegment("resourceName", "resourceName"),
		},
	}
	input := []sdkModels.ResourceID{
		valid,
		invalid,
	}
	output := switchOutCommonResourceIDsAsNeeded(input)
	for _, actual := range output {
		if normalizedResourceId(actual.Segments) == normalizedResourceId(valid.Segments) {
			if actual.CommonIDAlias == nil {
				t.Fatalf("Expected `valid` to have the CommonIDAlias `ResourceGroup` but got nil")
			}
			if *actual.CommonIDAlias != "ResourceGroup" {
				t.Fatalf("Expected `valid` to have the CommonIDAlias `ResourceGroup` but got %q", *actual.CommonIDAlias)
			}

			continue
		}

		if normalizedResourceId(actual.Segments) == normalizedResourceId(invalid.Segments) {
			if actual.CommonIDAlias != nil {
				t.Fatalf("Expected `invalid` to have no CommonIDAlias but got %q", *actual.CommonIDAlias)
			}
			continue
		}

		t.Fatalf("unexpected Resource ID %q", normalizedResourceId(actual.Segments))
	}
}

func TestCommonResourceID_ResourceGroupIncorrectSegment(t *testing.T) {
	input := []sdkModels.ResourceID{
		{
			ConstantNames: []string{},
			Segments: []sdkModels.ResourceIDSegment{
				sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
				sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
				sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
				sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			},
		},
		{
			ConstantNames: []string{},
			Segments: []sdkModels.ResourceIDSegment{
				sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
				sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
				sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
				sdkModels.NewResourceGroupNameResourceIDSegment("sourceResourceGroupName"),
			},
		},
	}
	output := switchOutCommonResourceIDsAsNeeded(input)
	for i, actual := range output {
		t.Logf("testing %d", i)
		if actual.CommonIDAlias == nil || *actual.CommonIDAlias != "ResourceGroup" {
			t.Fatalf("expected item %d to be detected as a ResourceGroup but it wasn't", i)
		}
	}
}
