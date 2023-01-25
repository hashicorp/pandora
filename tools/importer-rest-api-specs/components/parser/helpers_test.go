package parser

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func ParseSwaggerFileForTesting(t *testing.T, file string) (*models.AzureApiDefinition, error) {
	parsed, err := load("testdata/", file, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	var resourceProvider *string = nil // we're not filtering to just this RP, so it's fine
	resourceIds, err := parsed.ParseResourceIds(resourceProvider)
	if err != nil {
		t.Fatalf("parsing Resource Ids: %+v", err)
	}

	out, err := parsed.parse("Example", "2020-01-01", resourceProvider, *resourceIds)
	if err != nil {
		t.Fatalf("parsing file %q: %+v", file, err)
	}

	return out, nil
}
