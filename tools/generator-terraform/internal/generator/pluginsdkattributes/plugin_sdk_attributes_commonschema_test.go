// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pluginsdkattributes

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestPluginSdkAttributes_CommonSchema_EdgeZone(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.EdgeZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			// no instances of required
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.EdgeZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			// no instances of required/forcenew
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.EdgeZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.EdgeZoneOptional()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.EdgeZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.EdgeZoneOptionalForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.EdgeZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.EdgeZoneComputed()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.EdgeZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			// can't have optional & computed
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.EdgeZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			// can't have optional & computed & forcenew
			expected: "",
		},
	}
	for i, testCase := range testData {
		actual, err := codeForPluginSdkCommonSchemaAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		if *actual != testCase.expected {
			t.Fatalf("expected %q but got %q", testCase.expected, *actual)
		}
	}
}

func TestPluginSdkAttributes_CommonSchema_IdentitySystemAssigned(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.SystemAssignedIdentityRequired()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.SystemAssignedIdentityRequiredForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.SystemAssignedIdentityOptional()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.SystemAssignedIdentityOptionalForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.SystemAssignedIdentityComputed()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			// can't be Optional & Computed
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			// can't be Optional & ForceNew & Computed
			expected: "",
		},
	}
	for i, testCase := range testData {
		actual, err := codeForPluginSdkCommonSchemaAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		if *actual != testCase.expected {
			t.Fatalf("expected %q but got %q", testCase.expected, *actual)
		}
	}
}

func TestPluginSdkAttributes_CommonSchema_IdentitySystemAndUserAssigned(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.SystemAssignedUserAssignedIdentityRequired()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.SystemAssignedUserAssignedIdentityRequiredForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.SystemAssignedUserAssignedIdentityOptional()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.SystemAssignedUserAssignedIdentityOptionalForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.SystemAssignedUserAssignedIdentityComputed()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			// can't be Optional & Computed
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			// can't be Optional & ForceNew & Computed
			expected: "",
		},
	}
	for i, testCase := range testData {
		actual, err := codeForPluginSdkCommonSchemaAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		if *actual != testCase.expected {
			t.Fatalf("expected %q but got %q", testCase.expected, *actual)
		}
	}
}

func TestPluginSdkAttributes_CommonSchema_IdentitySystemOrUserAssigned(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.SystemOrUserAssignedIdentityRequired()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.SystemOrUserAssignedIdentityRequiredForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.SystemOrUserAssignedIdentityOptional()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.SystemOrUserAssignedIdentityOptionalForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.SystemOrUserAssignedIdentityComputed()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			// can't be Optional & Computed
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			// can't be Optional & ForceNew & Computed
			expected: "",
		},
	}
	for i, testCase := range testData {
		actual, err := codeForPluginSdkCommonSchemaAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		if *actual != testCase.expected {
			t.Fatalf("expected %q but got %q", testCase.expected, *actual)
		}
	}
}

func TestPluginSdkAttributes_CommonSchema_IdentityUserAssigned(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.UserAssignedIdentityRequired()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.UserAssignedIdentityRequiredForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.UserAssignedIdentityOptional()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.UserAssignedIdentityOptionalForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.UserAssignedIdentityComputed()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			// can't be Optional & Computed
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			// can't be Optional & ForceNew & Computed
			expected: "",
		},
	}
	for i, testCase := range testData {
		actual, err := codeForPluginSdkCommonSchemaAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		if *actual != testCase.expected {
			t.Fatalf("expected %q but got %q", testCase.expected, *actual)
		}
	}
}

func TestPluginSdkAttributes_CommonSchema_Location(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.LocationTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.Location()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.LocationTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.LocationWithoutForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.LocationTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.LocationOptional()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.LocationTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			// should error since this doesn't currently exist in go-azure-helpers/commonschema
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.LocationTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.LocationComputed()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.LocationTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: true,
				Optional: false,
				Required: false,
			},
			// ForceNew & Computed aren't supported
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.LocationTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			// Optional & Computed aren't supported (should be Optional only)
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.LocationTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			// Required & Computed aren't supported (should be Required only)
			expected: "",
		},
	}
	for i, testCase := range testData {
		actual, err := codeForPluginSdkCommonSchemaAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		if *actual != testCase.expected {
			t.Fatalf("expected %q but got %q", testCase.expected, *actual)
		}
	}
}

func TestPluginSdkAttributes_CommonSchema_ResourceGroup(t *testing.T) {
	// TODO: the CommonSchema methods want normalizing here
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ResourceGroupTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.ResourceGroupNameForDataSource()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ResourceGroupTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.ResourceGroupName()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ResourceGroupTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.ResourceGroupNameOptional()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ResourceGroupTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			// TODO: implement Optional & ForceNew (w/o Computed)
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ResourceGroupTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.ResourceGroupNameOptionalComputed()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ResourceGroupTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			// .. not supported?!
			expected: "",
		},
	}
	for i, testCase := range testData {
		actual, err := codeForPluginSdkCommonSchemaAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		if *actual != testCase.expected {
			t.Fatalf("expected %q but got %q", testCase.expected, *actual)
		}
	}
}

func TestPluginSdkAttributes_CommonSchema_Tags(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.TagsTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			// we have no instances of this AFAIK so we should raise an error
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.TagsTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.Tags()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.TagsTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.TagsForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.TagsTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			// Tags should be Optional only and not Optional & Computed
			expected: "",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.TagsTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.TagsDataSource()",
		},
	}
	for i, testCase := range testData {
		actual, err := codeForPluginSdkCommonSchemaAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		if *actual != testCase.expected {
			t.Fatalf("expected %q but got %q", testCase.expected, *actual)
		}
	}
}

func TestPluginSdkAttributes_CommonSchema_ZoneSingle(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.ZoneSingleRequired()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.ZoneSingleRequiredForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.ZoneSingleOptional()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.ZoneSingleOptionalForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.ZoneSingleComputed()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ZoneTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			// not supported
			expected: "",
		},
	}
	for i, testCase := range testData {
		actual, err := codeForPluginSdkCommonSchemaAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		if *actual != testCase.expected {
			t.Fatalf("expected %q but got %q", testCase.expected, *actual)
		}
	}
}

func TestPluginSdkAttributes_CommonSchema_ZonesMultiple(t *testing.T) {
	testData := []struct {
		input    models.TerraformSchemaField
		expected string
	}{
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ZonesTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.ZonesMultipleRequired()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ZonesTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.ZonesMultipleRequiredForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ZonesTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.ZonesMultipleOptional()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ZonesTerraformSchemaObjectDefinitionType,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.ZonesMultipleOptionalForceNew()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ZonesTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.ZonesMultipleComputed()",
		},
		{
			input: models.TerraformSchemaField{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ZonesTerraformSchemaObjectDefinitionType,
				},
				Computed: true,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			// not supported
			expected: "",
		},
	}
	for i, testCase := range testData {
		actual, err := codeForPluginSdkCommonSchemaAttribute(testCase.input)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		if testCase.expected == "" {
			t.Fatalf("expected an error but didn't get one for index %d", i)
		}
		if *actual != testCase.expected {
			t.Fatalf("expected %q but got %q", testCase.expected, *actual)
		}
	}
}
