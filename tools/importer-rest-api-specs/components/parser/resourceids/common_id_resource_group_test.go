package resourceids

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestCommonResourceID_ResourceGroup(t *testing.T) {
	valid := models.ParsedResourceId{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
		},
	}
	invalid := models.ParsedResourceId{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			models.StaticResourceIDSegment("subscriptions", "subscriptions"),
			models.SubscriptionIDResourceIDSegment("subscriptionId"),
			models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			models.ResourceGroupResourceIDSegment("resourceGroupName"),
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
				t.Fatalf("Expected `valid` to have the CommonAlias `ResourceGroup` but got nil")
			}
			if *actual.CommonAlias != "ResourceGroup" {
				t.Fatalf("Expected `valid` to have the CommonAlias `ResourceGroup` but got %q", *actual.CommonAlias)
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

func TestCommonResourceID_ResourceGroupIncorrectSegment(t *testing.T) {
	input := []models.ParsedResourceId{
		{
			Constants: map[string]resourcemanager.ConstantDetails{},
			Segments: []resourcemanager.ResourceIdSegment{
				models.StaticResourceIDSegment("subscriptions", "subscriptions"),
				models.SubscriptionIDResourceIDSegment("subscriptionId"),
				models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
				models.ResourceGroupResourceIDSegment("resourceGroupName"),
			},
		},
		{
			Constants: map[string]resourcemanager.ConstantDetails{},
			Segments: []resourcemanager.ResourceIdSegment{
				models.StaticResourceIDSegment("subscriptions", "subscriptions"),
				models.SubscriptionIDResourceIDSegment("subscriptionId"),
				models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
				models.ResourceGroupResourceIDSegment("sourceResourceGroupName"),
			},
		},
	}
	output := switchOutCommonResourceIDsAsNeeded(input)
	for i, actual := range output {
		t.Logf("testing %d", i)
		if actual.CommonAlias == nil || *actual.CommonAlias != "ResourceGroup" {
			t.Fatalf("expected item %d to be detected as a ResourceGroup but it wasn't", i)
		}
	}
}
