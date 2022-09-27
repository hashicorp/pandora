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
