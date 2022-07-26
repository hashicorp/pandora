package generator

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: EdgeZone, Identity, Resource Group, Single Zone, Plural Zones etc

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
