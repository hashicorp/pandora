package schema

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func checkDirectAssignmentMappingExistsBetween(t *testing.T, mappings []resourcemanager.FieldMappingDefinition, schemaModelName, schemaFieldPath, sdkModelName, sdkFieldPath string) {
	found := false
	for _, item := range mappings {
		if item.Type != resourcemanager.DirectAssignmentMappingDefinitionType {
			t.Fatalf("expected a DirectAssignment Mapping but got %q", string(item.Type))
		}

		if item.DirectAssignment.SchemaModelName != schemaModelName || item.DirectAssignment.SchemaFieldPath != schemaFieldPath {
			continue
		}
		if item.DirectAssignment.SdkModelName != sdkModelName || item.DirectAssignment.SdkFieldPath != sdkFieldPath {
			continue
		}

		found = true
		break
	}
	if !found {
		t.Fatalf("expected there to be a DirectAssignment Mapping from Schema Model %q Path %q to SDK Model %q Path %q but there wasn't", schemaModelName, schemaFieldPath, sdkModelName, sdkFieldPath)
	}
}

func TestExtractDescription(t *testing.T) {
	testData := map[string]string{
		// input : expected
		"": "",
		"The id of the app associated with the identity. ":                             "The ID of the app associated with the Identity.",
		"The id of the service principal object associated with the created identity.": "The ID of the Service Principal object associated with the created Identity.",
		"The id of the tenant which the identity belongs to.":                          "The ID of the Tenant which the Identity belongs to.",
	}
	for input, expected := range testData {
		t.Logf("Testing input %q", input)
		actual := extractDescription(input)
		if expected != actual {
			t.Fatalf("expected %q but got %q", expected, actual)
		}
	}
}

func TestUpdateField_ApplySchemaOverrides(t *testing.T) {
	testData := []struct {
		fieldInput string
		overrides  []models.Override
		expected   *string
	}{
		{
			fieldInput: "name",
			overrides: []models.Override{
				{
					Name:        "name",
					UpdatedName: pointer.To("target_resource_id"),
				},
			},
			expected: stringPointer("TargetResourceId"),
		},
		{
			fieldInput: "ThreeCoffeesADay",
			overrides: []models.Override{
				{
					Name:        "name",
					UpdatedName: pointer.To("target_resource_id"),
				},
			},
			expected: nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.fieldInput)

		actual, _ := applySchemaOverrides(v.fieldInput, v.overrides)

		if actual == nil {
			if v.expected == nil {
				continue
			}
			t.Fatalf("expected a result but didn't get one")
		}
		if v.expected == nil {
			t.Fatalf("expected no result but got %s", *actual)
		}
		if *actual != *v.expected {
			t.Fatalf("Expected %s but got %s", *v.expected, *actual)
		}
	}
}
