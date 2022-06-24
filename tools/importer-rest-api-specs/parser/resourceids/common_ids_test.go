package resourceids

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestCommonResourceID_ManagementGroup(t *testing.T) {
	input := map[string]models.ParsedResourceId{
		"Valid": {
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
					FixedValue: strPtr("resourceProvider"),
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
		},
		"Invalid": {
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
					FixedValue: strPtr("resourceProvider"),
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
	input := map[string]models.ParsedResourceId{
		"Valid": {
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
		},
		"Invalid": {
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
					FixedValue: strPtr("someResource"),
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
	input := map[string]models.ParsedResourceId{
		"Valid": {
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
		},
		"Invalid": {
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
	input := map[string]models.ParsedResourceId{
		"Valid": {
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
					Name: "resourceProvider",
					Type: models.ResourceProviderSegment,
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
		},
		"Invalid": {
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
					Name: "resourceProvider",
					Type: models.ResourceProviderSegment,
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

func TestCommonResourceID_EndToEnd(t *testing.T) {
	t.Fatalf("NOOOO")
}
