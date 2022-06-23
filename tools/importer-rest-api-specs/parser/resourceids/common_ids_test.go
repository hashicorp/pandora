package resourceids

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/featureflags"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestCommonResourceID_ManagementGroup(t *testing.T) {
	if !featureflags.EnableCommonResourceIDs {
		t.Skip("Common Resource IDs are disabled")
	}

	input := map[string]models.ParsedResourceId{
		"Valid": {
			Constants: map[string]models.ConstantDetails{},
			Segments: []models.ResourceIdSegment{
				{
					Name:       "providers",
					Type:       models.StaticSegment,
					FixedValue: toPtr("providers"),
				},
				{
					Name:       "resourceProvider",
					Type:       models.ResourceProviderSegment,
					FixedValue: toPtr("resourceProvider"),
				},
				{
					Name:       "managementGroups",
					Type:       models.StaticSegment,
					FixedValue: toPtr("managementGroups"),
				},
				{
					Name: "groupId",
					Type: models.UserSpecifiedSegment,
				},
			},
		},
		"Invalid": {
			Constants: map[string]models.ConstantDetails{},
			Segments: []models.ResourceIdSegment{
				{
					Name:       "providers",
					Type:       models.StaticSegment,
					FixedValue: toPtr("providers"),
				},
				{
					Name:       "resourceProvider",
					Type:       models.ResourceProviderSegment,
					FixedValue: toPtr("resourceProvider"),
				},
				{
					Name:       "managementGroups",
					Type:       models.StaticSegment,
					FixedValue: toPtr("managementGroups"),
				},
				{
					Name: "groupId",
					Type: models.UserSpecifiedSegment,
				},
				{
					Name:       "someResource",
					Type:       models.StaticSegment,
					FixedValue: toPtr("someResource"),
				},
				{
					Name: "resourceName",
					Type: models.UserSpecifiedSegment,
				},
			},
		},
	}
	output := switchOutCommonResourceIDsAsNeeded(input)
	if output["Valid"].CommonAlias == nil {
		t.Fatalf("Expected `Valid` to have the CommonAlias `ManagementGroup` but got nil")
	}
	if *output["Valid"].CommonAlias != "ManagementGroup" {
		t.Fatalf("Expected `Valid` to have the CommonAlias `ManagementGroup` but got %q", *output["Valid"].CommonAlias)
	}
	if output["Invalid"].CommonAlias != nil {
		t.Fatalf("Expected `Invalid` to have no CommonAlias but got %q", *output["Invalid"].CommonAlias)
	}
}

func TestCommonResourceID_ResourceGroup(t *testing.T) {
	if !featureflags.EnableCommonResourceIDs {
		t.Skip("Common Resource IDs are disabled")
	}

	input := map[string]models.ParsedResourceId{
		"Valid": {
			Constants: map[string]models.ConstantDetails{},
			Segments: []models.ResourceIdSegment{
				{
					Name:       "subscriptions",
					Type:       models.StaticSegment,
					FixedValue: toPtr("subscriptions"),
				},
				{
					Name: "subscriptionId",
					Type: models.SubscriptionIdSegment,
				},
				{
					Name:       "resourceGroups",
					Type:       models.StaticSegment,
					FixedValue: toPtr("resourceGroups"),
				},
				{
					Name: "resourceGroup",
					Type: models.ResourceGroupSegment,
				},
			},
		},
		"Invalid": {
			Constants: map[string]models.ConstantDetails{},
			Segments: []models.ResourceIdSegment{

				{
					Name:       "subscriptions",
					Type:       models.StaticSegment,
					FixedValue: toPtr("subscriptions"),
				},
				{
					Name: "subscriptionId",
					Type: models.SubscriptionIdSegment,
				},
				{
					Name:       "resourceGroups",
					Type:       models.StaticSegment,
					FixedValue: toPtr("resourceGroups"),
				},
				{
					Name: "resourceGroup",
					Type: models.ResourceGroupSegment,
				},
				{
					Name:       "someResource",
					Type:       models.StaticSegment,
					FixedValue: toPtr("someResource"),
				},
				{
					Name: "resourceName",
					Type: models.UserSpecifiedSegment,
				},
			},
		},
	}
	output := switchOutCommonResourceIDsAsNeeded(input)
	if output["Valid"].CommonAlias == nil {
		t.Fatalf("Expected `Valid` to have the CommonAlias `ResourceGroup` but got nil")
	}
	if *output["Valid"].CommonAlias != "ResourceGroup" {
		t.Fatalf("Expected `Valid` to have the CommonAlias `ResourceGroup` but got %q", *output["Valid"].CommonAlias)
	}
	if output["Invalid"].CommonAlias != nil {
		t.Fatalf("Expected `Invalid` to have no CommonAlias but got %q", *output["Invalid"].CommonAlias)
	}
}

func TestCommonResourceID_Scope(t *testing.T) {
	if !featureflags.EnableCommonResourceIDs {
		t.Skip("Common Resource IDs are disabled")
	}

	input := map[string]models.ParsedResourceId{
		"Valid": {
			Constants: map[string]models.ConstantDetails{},
			Segments: []models.ResourceIdSegment{
				{
					Name: "resourcePath",
					Type: models.ScopeSegment,
				},
			},
		},
		"Invalid": {
			Constants: map[string]models.ConstantDetails{},
			Segments: []models.ResourceIdSegment{
				{
					Name: "scope",
					Type: models.ScopeSegment,
				},
				{
					Name:       "someResource",
					Type:       models.StaticSegment,
					FixedValue: toPtr("someResource"),
				},
				{
					Name: "resourceName",
					Type: models.UserSpecifiedSegment,
				},
			},
		},
	}
	output := switchOutCommonResourceIDsAsNeeded(input)
	if output["Valid"].CommonAlias == nil {
		t.Fatalf("Expected `Valid` to have the CommonAlias `Scope` but got nil")
	}
	if *output["Valid"].CommonAlias != "Scope" {
		t.Fatalf("Expected `Valid` to have the CommonAlias `Scope` but got %q", *output["Valid"].CommonAlias)
	}
	if output["Invalid"].CommonAlias != nil {
		t.Fatalf("Expected `Invalid` to have no CommonAlias but got %q", *output["Invalid"].CommonAlias)
	}
}

func TestCommonResourceID_Subscription(t *testing.T) {
	if !featureflags.EnableCommonResourceIDs {
		t.Skip("Common Resource IDs are disabled")
	}

	input := map[string]models.ParsedResourceId{
		"Valid": {
			Constants: map[string]models.ConstantDetails{},
			Segments: []models.ResourceIdSegment{
				{
					Name:       "subscriptions",
					Type:       models.StaticSegment,
					FixedValue: toPtr("subscriptions"),
				},
				{
					Name: "subscriptionId",
					Type: models.SubscriptionIdSegment,
				},
			},
		},
		"Invalid": {
			Constants: map[string]models.ConstantDetails{},
			Segments: []models.ResourceIdSegment{
				{
					Name:       "subscriptions",
					Type:       models.StaticSegment,
					FixedValue: toPtr("subscriptions"),
				},
				{
					Name: "subscriptionId",
					Type: models.SubscriptionIdSegment,
				},
				{
					Name:       "someResource",
					Type:       models.StaticSegment,
					FixedValue: toPtr("someResource"),
				},
				{
					Name: "resourceName",
					Type: models.UserSpecifiedSegment,
				},
			},
		},
	}
	output := switchOutCommonResourceIDsAsNeeded(input)
	if output["Valid"].CommonAlias == nil {
		t.Fatalf("Expected `Valid` to have the CommonAlias `Subscription` but got nil")
	}
	if *output["Valid"].CommonAlias != "Subscription" {
		t.Fatalf("Expected `Valid` to have the CommonAlias `Subscription` but got %q", *output["Valid"].CommonAlias)
	}
	if output["Invalid"].CommonAlias != nil {
		t.Fatalf("Expected `Invalid` to have no CommonAlias but got %q", *output["Invalid"].CommonAlias)
	}
}

func TestCommonResourceID_UserAssignedIdentity(t *testing.T) {
	if !featureflags.EnableCommonResourceIDs {
		t.Skip("Common Resource IDs are disabled")
	}

	input := map[string]models.ParsedResourceId{
		"Valid": {
			Constants: map[string]models.ConstantDetails{},
			Segments: []models.ResourceIdSegment{
				{
					Name:       "subscriptions",
					Type:       models.StaticSegment,
					FixedValue: toPtr("subscriptions"),
				},
				{
					Name: "subscriptionId",
					Type: models.SubscriptionIdSegment,
				},
				{
					Name:       "resourceGroups",
					Type:       models.StaticSegment,
					FixedValue: toPtr("resourceGroups"),
				},
				{
					Name: "resourceGroup",
					Type: models.ResourceGroupSegment,
				},
				{
					Name:       "providers",
					Type:       models.StaticSegment,
					FixedValue: toPtr("providers"),
				},
				{
					Name: "resourceProvider",
					Type: models.ResourceProviderSegment,
				},
				{
					Name:       "userAssignedIdentities",
					Type:       models.StaticSegment,
					FixedValue: toPtr("userAssignedIdentities"),
				},
				{
					Name: "userIdentityName",
					Type: models.UserSpecifiedSegment,
				},
			},
		},
		"Invalid": {
			Constants: map[string]models.ConstantDetails{},
			Segments: []models.ResourceIdSegment{

				{
					Name:       "subscriptions",
					Type:       models.StaticSegment,
					FixedValue: toPtr("subscriptions"),
				},
				{
					Name: "subscriptionId",
					Type: models.SubscriptionIdSegment,
				},
				{
					Name:       "resourceGroups",
					Type:       models.StaticSegment,
					FixedValue: toPtr("resourceGroups"),
				},
				{
					Name: "resourceGroup",
					Type: models.ResourceGroupSegment,
				},
				{
					Name:       "providers",
					Type:       models.StaticSegment,
					FixedValue: toPtr("providers"),
				},
				{
					Name: "resourceProvider",
					Type: models.ResourceProviderSegment,
				},
				{
					Name:       "userAssignedIdentities",
					Type:       models.StaticSegment,
					FixedValue: toPtr("userAssignedIdentities"),
				},
				{
					Name: "userIdentityName",
					Type: models.UserSpecifiedSegment,
				},
				{
					Name:       "someResource",
					Type:       models.StaticSegment,
					FixedValue: toPtr("someResource"),
				},
				{
					Name: "resourceName",
					Type: models.UserSpecifiedSegment,
				},
			},
		},
	}
	output := switchOutCommonResourceIDsAsNeeded(input)
	if output["Valid"].CommonAlias == nil {
		t.Fatalf("Expected `Valid` to have the CommonAlias `UserAssignedIdentity` but got nil")
	}
	if *output["Valid"].CommonAlias != "UserAssignedIdentity" {
		t.Fatalf("Expected `Valid` to have the CommonAlias `UserAssignedIdentity` but got %q", *output["Valid"].CommonAlias)
	}
	if output["Invalid"].CommonAlias != nil {
		t.Fatalf("Expected `Invalid` to have no CommonAlias but got %q", *output["Invalid"].CommonAlias)
	}
}
