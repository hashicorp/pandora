// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"testing"

	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestCommonResourceID_ManagementGroup(t *testing.T) {
	valid := importerModels.ParsedResourceId{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("providers", "providers"),
			importerModels.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
			importerModels.StaticResourceIDSegment("managementGroups", "managementGroups"),
			importerModels.UserSpecifiedResourceIDSegment("groupId"),
		},
	}
	invalid := importerModels.ParsedResourceId{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("providers", "providers"),
			importerModels.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
			importerModels.StaticResourceIDSegment("managementGroups", "managementGroups"),
			importerModels.UserSpecifiedResourceIDSegment("groupId"),
			importerModels.StaticResourceIDSegment("someResource", "someResource"),
			importerModels.UserSpecifiedResourceIDSegment("resourceName"),
		},
	}
	input := []importerModels.ParsedResourceId{
		valid,
		invalid,
	}
	output := switchOutCommonResourceIDsAsNeeded(input)
	for _, actual := range output {
		if normalizedResourceId(actual.Segments) == normalizedResourceId(valid.Segments) {
			if actual.CommonAlias == nil {
				t.Fatalf("Expected `valid` to have the CommonAlias `ManagementGroup` but got nil")
			}
			if *actual.CommonAlias != "ManagementGroup" {
				t.Fatalf("Expected `valid` to have the CommonAlias `ManagementGroup` but got %q", *actual.CommonAlias)
			}

			continue
		}

		if normalizedResourceId(actual.Segments) == normalizedResourceId(invalid.Segments) {
			if actual.CommonAlias != nil {
				t.Fatalf("Expected `invalid` to have no CommonAlias but got %q", *actual.CommonAlias)
			}
			continue
		}

		t.Fatalf("unexpected Resource ID %q", normalizedResourceId(actual.Segments))
	}
}
