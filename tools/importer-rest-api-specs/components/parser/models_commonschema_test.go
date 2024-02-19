package parser

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseModel_CommonSchema_Location(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "model_commonschema_location.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}

	resource, ok := result.Resources["Resource"]
	if !ok {
		t.Fatal("the Resource 'Resource' was not found")
	}

	model, ok := resource.Models["Model"]
	if !ok {
		t.Fatalf("the Model `Model` was not found")
	}

	field, ok := model.Fields["Location"]
	if !ok {
		t.Fatalf("example.Fields['Location'] was missing")
	}
	if *field.CustomFieldType != models.CustomFieldTypeLocation {
		t.Fatalf("expected example.Fields['Location'] to be a Location but got %q", string(*field.CustomFieldType))
	}
}
