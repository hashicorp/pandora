// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestCommonResourceID_ManagementGroup(t *testing.T) {
	valid := models.ResourceID{
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
			models.NewStaticValueResourceIDSegment("managementGroups", "managementGroups"),
			models.NewUserSpecifiedResourceIDSegment("groupId", "groupId"),
		},
	}
	invalid := models.ResourceID{
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
			models.NewStaticValueResourceIDSegment("managementGroups", "managementGroups"),
			models.NewUserSpecifiedResourceIDSegment("groupId", "groupId"),
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
