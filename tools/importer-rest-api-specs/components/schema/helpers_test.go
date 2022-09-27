package schema

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func checkDirectAssignmentMappingExistsBetween(t *testing.T, mappings []resourcemanager.FieldMappingDefinition, schemaModelName, schemaFieldPath, sdkModelName, sdkFieldPath string) {
	found := false
	for _, item := range mappings {
		if item.From.SchemaModelName != schemaModelName || item.From.SchemaFieldPath != schemaFieldPath {
			continue
		}
		if item.To.SdkModelName != sdkModelName || item.To.SdkFieldPath != sdkFieldPath {
			continue
		}

		if item.Type != resourcemanager.DirectAssignmentMappingDefinitionType {
			t.Fatalf("expected a DirectAssignment Mapping but got %q", string(item.Type))
		}

		found = true
		break
	}
	if !found {
		t.Fatalf("expected there to be a DirectAssignment Mapping from Schema Model %q Path %q to SDK Model %q Path %q but there wasn't", schemaModelName, schemaFieldPath, sdkModelName, sdkFieldPath)
	}
}

func checkModelToModelMappingExistsBetween(t *testing.T, mappings []resourcemanager.FieldMappingDefinition, schemaModelName string, schemaFieldPath string, sdkModelName string) {
	found := false
	for _, item := range mappings {
		if item.From.SchemaModelName != schemaModelName || item.From.SchemaFieldPath != schemaFieldPath {
			continue
		}
		if item.To.SdkModelName != sdkModelName {
			continue
		}

		if item.Type != resourcemanager.ModelToModelMappingDefinitionType {
			t.Fatalf("expected a ModelToModel Mapping but got %q", string(item.Type))
		}

		found = true
		break
	}
	if !found {
		t.Fatalf("expected there to be a ModelToModel Mapping from Schema Model %q Path %q to SDK Model %q but there wasn't", schemaModelName, schemaFieldPath, sdkModelName)
	}
}
