// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestCommonResourceID_ResourceGroup(t *testing.T) {
	valid := models.ResourceID{
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
		},
	}
	invalid := models.ResourceID{
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("someResource", "someResource"),
			models.NewUserSpecifiedResourceIDSegment("resourceName", "resourceName"),
		},
	}
	input := []models.ResourceID{
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
	input := []models.ResourceID{
		{
			ConstantNames: []string{},
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
				models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
				models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
				models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			},
		},
		{
			ConstantNames: []string{},
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
				models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
				models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
				models.NewResourceGroupNameResourceIDSegment("sourceResourceGroupName"),
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
