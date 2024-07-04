// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestCommonResourceID_UserAssignedIdentity(t *testing.T) {
	valid := sdkModels.ResourceID{
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.ManagedIdentity"),
			sdkModels.NewStaticValueResourceIDSegment("userAssignedIdentities", "userAssignedIdentities"),
			sdkModels.NewUserSpecifiedResourceIDSegment("userAssignedIdentityName", "userAssignedIdentityName"),
		},
	}
	invalid := sdkModels.ResourceID{
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.ManagedIdentity"),
			sdkModels.NewStaticValueResourceIDSegment("userAssignedIdentities", "userAssignedIdentities"),
			sdkModels.NewUserSpecifiedResourceIDSegment("userAssignedIdentityName", "userAssignedIdentityName"),
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
				t.Fatalf("Expected `valid` to have the CommonIDAlias `UserAssignedIdentity` but got nil")
			}
			if *actual.CommonIDAlias != "UserAssignedIdentity" {
				t.Fatalf("Expected `valid` to have the CommonIDAlias `UserAssignedIdentity` but got %q", *actual.CommonIDAlias)
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
