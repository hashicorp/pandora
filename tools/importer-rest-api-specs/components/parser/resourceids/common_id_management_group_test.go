// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestCommonResourceID_ManagementGroup(t *testing.T) {
	valid := sdkModels.ResourceID{
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
			sdkModels.NewStaticValueResourceIDSegment("managementGroups", "managementGroups"),
			sdkModels.NewUserSpecifiedResourceIDSegment("groupId", "groupId"),
		},
	}
	invalid := sdkModels.ResourceID{
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
			sdkModels.NewStaticValueResourceIDSegment("managementGroups", "managementGroups"),
			sdkModels.NewUserSpecifiedResourceIDSegment("groupId", "groupId"),
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
				t.Fatalf("Expected `valid` to have the CommonIDAlias `ManagementGroup` but got nil")
			}
			if *actual.CommonIDAlias != "ManagementGroup" {
				t.Fatalf("Expected `valid` to have the CommonIDAlias `ManagementGroup` but got %q", *actual.CommonIDAlias)
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
