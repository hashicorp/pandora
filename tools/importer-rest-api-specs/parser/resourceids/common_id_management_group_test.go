package resourceids

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestCommonResourceID_ManagementGroup(t *testing.T) {
	valid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
			models.StaticResourceIDSegment("managementGroups", "managementGroups"),
			models.UserSpecifiedResourceIDSegment("groupId"),
		},
	}
	invalid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
			models.StaticResourceIDSegment("managementGroups", "managementGroups"),
			models.UserSpecifiedResourceIDSegment("groupId"),
			models.StaticResourceIDSegment("someResource", "someResource"),
			models.UserSpecifiedResourceIDSegment("resourceName"),
		},
	}
	input := []models.ParsedResourceId{
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
