package resourceids

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestCommonResourceID_ManagementGroup(t *testing.T) {
	valid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name:       "providers",
				Type:       models.StaticSegment,
				FixedValue: strPtr("providers"),
			},
			{
				Name:       "resourceProvider",
				Type:       models.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Management"),
			},
			{
				Name:       "managementGroups",
				Type:       models.StaticSegment,
				FixedValue: strPtr("managementGroups"),
			},
			{
				Name: "groupId",
				Type: models.UserSpecifiedSegment,
			},
		},
	}
	invalid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name:       "providers",
				Type:       models.StaticSegment,
				FixedValue: strPtr("providers"),
			},
			{
				Name:       "resourceProvider",
				Type:       models.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Management"),
			},
			{
				Name:       "managementGroups",
				Type:       models.StaticSegment,
				FixedValue: strPtr("managementGroups"),
			},
			{
				Name: "groupId",
				Type: models.UserSpecifiedSegment,
			},
			{
				Name:       "someResource",
				Type:       models.StaticSegment,
				FixedValue: strPtr("someResource"),
			},
			{
				Name: "resourceName",
				Type: models.UserSpecifiedSegment,
			},
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
				t.Fatalf("Expected `valid` to have the CommonAlias `ManagementGroup` but got nil")
			}
			if *actual.CommonAlias != "ManagementGroup" {
				t.Fatalf("Expected `valid` to have the CommonAlias `ManagementGroup` but got %q", *actual.CommonAlias)
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

func TestCommonResourceID_ResourceGroup(t *testing.T) {
	valid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name:       "subscriptions",
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
			{
				Name:       "resourceGroups",
				Type:       models.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
			},
			{
				Name: "resourceGroup",
				Type: models.ResourceGroupSegment,
			},
		},
	}
	invalid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{

			{
				Name:       "subscriptions",
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
			{
				Name:       "resourceGroups",
				Type:       models.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
			},
			{
				Name: "resourceGroup",
				Type: models.ResourceGroupSegment,
			},
			{
				Name:       "someResource",
				Type:       models.StaticSegment,
				FixedValue: strPtr("someResource"),
			},
			{
				Name: "resourceName",
				Type: models.UserSpecifiedSegment,
			},
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

func TestCommonResourceID_Scope(t *testing.T) {
	valid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name: "resourcePath",
				Type: models.ScopeSegment,
			},
		},
	}
	invalid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name: "scope",
				Type: models.ScopeSegment,
			},
			{
				Name:       "someResource",
				Type:       models.StaticSegment,
				FixedValue: strPtr("someResource"),
			},
			{
				Name: "resourceName",
				Type: models.UserSpecifiedSegment,
			},
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
				t.Fatalf("Expected `valid` to have the CommonAlias `Scope` but got nil")
			}
			if *actual.CommonAlias != "Scope" {
				t.Fatalf("Expected `valid` to have the CommonAlias `Scope` but got %q", *actual.CommonAlias)
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

func TestCommonResourceID_Subscription(t *testing.T) {
	valid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name:       "subscriptions",
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
		},
	}
	invalid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name:       "subscriptions",
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
			{
				Name:       "someResource",
				Type:       models.StaticSegment,
				FixedValue: strPtr("someResource"),
			},
			{
				Name: "resourceName",
				Type: models.UserSpecifiedSegment,
			},
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
				t.Fatalf("Expected `valid` to have the CommonAlias `Subscription` but got nil")
			}
			if *actual.CommonAlias != "Subscription" {
				t.Fatalf("Expected `valid` to have the CommonAlias `Subscription` but got %q", *actual.CommonAlias)
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

func TestCommonResourceID_UserAssignedIdentity(t *testing.T) {
	valid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name:       "subscriptions",
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
			{
				Name:       "resourceGroups",
				Type:       models.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
			},
			{
				Name: "resourceGroup",
				Type: models.ResourceGroupSegment,
			},
			{
				Name:       "providers",
				Type:       models.StaticSegment,
				FixedValue: strPtr("providers"),
			},
			{
				Name:       "resourceProvider",
				Type:       models.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.ManagedIdentity"),
			},
			{
				Name:       "userAssignedIdentities",
				Type:       models.StaticSegment,
				FixedValue: strPtr("userAssignedIdentities"),
			},
			{
				Name: "userIdentityName",
				Type: models.UserSpecifiedSegment,
			},
		},
	}
	invalid := models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name:       "subscriptions",
				Type:       models.StaticSegment,
				FixedValue: strPtr("subscriptions"),
			},
			{
				Name: "subscriptionId",
				Type: models.SubscriptionIdSegment,
			},
			{
				Name:       "resourceGroups",
				Type:       models.StaticSegment,
				FixedValue: strPtr("resourceGroups"),
			},
			{
				Name: "resourceGroup",
				Type: models.ResourceGroupSegment,
			},
			{
				Name:       "providers",
				Type:       models.StaticSegment,
				FixedValue: strPtr("providers"),
			},
			{
				Name:       "resourceProvider",
				Type:       models.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.ManagedIdentity"),
			},
			{
				Name:       "userAssignedIdentities",
				Type:       models.StaticSegment,
				FixedValue: strPtr("userAssignedIdentities"),
			},
			{
				Name: "userIdentityName",
				Type: models.UserSpecifiedSegment,
			},
			{
				Name:       "someResource",
				Type:       models.StaticSegment,
				FixedValue: strPtr("someResource"),
			},
			{
				Name: "resourceName",
				Type: models.UserSpecifiedSegment,
			},
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
				t.Fatalf("Expected `valid` to have the CommonAlias `UserAssignedIdentity` but got nil")
			}
			if *actual.CommonAlias != "UserAssignedIdentity" {
				t.Fatalf("Expected `valid` to have the CommonAlias `UserAssignedIdentity` but got %q", *actual.CommonAlias)
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
