package generator

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestPluginSdkAttributes_CommonSchema_EdgeZone(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaFieldDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.EdgeZoneOptional()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.EdgeZoneOptionalForceNew()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.EdgeZoneComputed()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
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
		input    resourcemanager.TerraformSchemaFieldDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.SystemAssignedIdentityRequired()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.SystemAssignedIdentityRequiredForceNew()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.SystemAssignedIdentityOptional()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.SystemAssignedIdentityOptionalForceNew()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.SystemAssignedIdentityComputed()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
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
		input    resourcemanager.TerraformSchemaFieldDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.SystemAssignedUserAssignedIdentityRequired()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.SystemAssignedUserAssignedIdentityRequiredForceNew()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.SystemAssignedUserAssignedIdentityOptional()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.SystemAssignedUserAssignedIdentityOptionalForceNew()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.SystemAssignedUserAssignedIdentityComputed()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
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
		input    resourcemanager.TerraformSchemaFieldDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.SystemOrUserAssignedIdentityRequired()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.SystemOrUserAssignedIdentityRequiredForceNew()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.SystemOrUserAssignedIdentityOptional()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.SystemOrUserAssignedIdentityOptionalForceNew()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.SystemOrUserAssignedIdentityComputed()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
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
		input    resourcemanager.TerraformSchemaFieldDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.UserAssignedIdentityRequired()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.UserAssignedIdentityRequiredForceNew()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.UserAssignedIdentityOptional()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.UserAssignedIdentityOptionalForceNew()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.UserAssignedIdentityComputed()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
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
		input    resourcemanager.TerraformSchemaFieldDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.Location()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.LocationWithoutForceNew()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.LocationOptional()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
				},
				Computed: true,
				ForceNew: false,
				Optional: false,
				Required: false,
			},
			expected: "commonschema.LocationComputed()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeLocation,
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
		input    resourcemanager.TerraformSchemaFieldDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
				},
				Computed: false,
				ForceNew: false,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.ResourceGroupNameForDataSource()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
				},
				Computed: false,
				ForceNew: true,
				Optional: false,
				Required: true,
			},
			expected: "commonschema.ResourceGroupName()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.ResourceGroupNameOptional()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
				},
				Computed: true,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.ResourceGroupNameOptionalComputed()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
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
		input    resourcemanager.TerraformSchemaFieldDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeTags,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeTags,
				},
				Computed: false,
				ForceNew: false,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.Tags()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeTags,
				},
				Computed: false,
				ForceNew: true,
				Optional: true,
				Required: false,
			},
			expected: "commonschema.TagsForceNew()",
		},
		{
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeTags,
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
			input: resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeTags,
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
