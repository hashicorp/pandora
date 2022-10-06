package schema

import (
	"testing"

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
