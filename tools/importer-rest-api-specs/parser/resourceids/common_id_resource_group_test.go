package resourceids

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestCommonResourceID_ResourceGroup(t *testing.T) {
	valid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroup"),
		},
	}
	invalid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroup"),
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
		if actual.NormalizedResourceId() == valid.NormalizedResourceId() {
			if actual.CommonAlias == nil {
				t.Fatalf("Expected `valid` to have the CommonAlias `ResourceGroup` but got nil")
			}
			if *actual.CommonAlias != "ResourceGroup" {
				t.Fatalf("Expected `valid` to have the CommonAlias `ResourceGroup` but got %q", *actual.CommonAlias)
			}

			continue
		}

		if actual.NormalizedResourceId() == invalid.NormalizedResourceId() {
			if actual.CommonAlias != nil {
				t.Fatalf("Expected `invalid` to have no CommonAlias but got %q", *actual.CommonAlias)
			}
			continue
		}

		t.Fatalf("unexpected Resource ID %q", actual.NormalizedResourceId())
	}
}
