package resourceids

import (
	"testing"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseResourceIDFromOperation_ResourceGroupId(t *testing.T) {
	swagger := spec.NewOperation("Example_Operation")
	uri := "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}"

	parser := NewParser(hclog.NewNullLogger(), nil)
	resourceId, err := parser.parseResourceIdFromOperation(uri, swagger)
	if err != nil {
		t.Fatalf("parsing Resource ID from %q: %+v", uri, err)
	}

	if resourceId.uriSuffix != nil {
		t.Fatalf("expected no uriSuffix but got %q", *resourceId.uriSuffix)
	}
	if len(resourceId.constants) != 0 {
		t.Fatalf("expected 0 constants but got %d", len(resourceId.constants))
	}
	if resourceId.segments == nil {
		t.Fatalf("expected 4 segments but got 0")
	}
	expectedSegments := []models.ResourceIdSegment{
		models.StaticResourceIDSegment("providers", "providers"),
		models.SubscriptionIDResourceIDSegment("subscriptionId"),
		models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
		models.ResourceGroupResourceIDSegment("resourceGroupName"),
	}
	validateSegmentsMatch(t, *resourceId.segments, expectedSegments)
}

func TestParseResourceIDFromOperation_SubscriptionId(t *testing.T) {
	swagger := spec.NewOperation("Example_Operation")
	uri := "/subscriptions/{subscriptionId}"

	parser := NewParser(hclog.NewNullLogger(), nil)
	resourceId, err := parser.parseResourceIdFromOperation(uri, swagger)
	if err != nil {
		t.Fatalf("parsing Resource ID from %q: %+v", uri, err)
	}

	if resourceId.uriSuffix != nil {
		t.Fatalf("expected no uriSuffix but got %q", *resourceId.uriSuffix)
	}
	if len(resourceId.constants) != 0 {
		t.Fatalf("expected 0 constants but got %d", len(resourceId.constants))
	}
	if resourceId.segments == nil {
		t.Fatalf("expected 2 segments but got 0")
	}
	expectedSegments := []models.ResourceIdSegment{
		models.StaticResourceIDSegment("providers", "providers"),
		models.SubscriptionIDResourceIDSegment("subscriptionId"),
	}
	validateSegmentsMatch(t, *resourceId.segments, expectedSegments)
}

func TestParseResourceIDFromOperation_UriSuffix(t *testing.T) {
	swagger := spec.NewOperation("Example_Operation")
	uri := "/someUri"

	parser := NewParser(hclog.NewNullLogger(), nil)
	resourceId, err := parser.parseResourceIdFromOperation(uri, swagger)
	if err != nil {
		t.Fatalf("parsing Resource ID from %q: %+v", uri, err)
	}

	if resourceId.uriSuffix == nil {
		t.Fatalf("expected a uriSuffix of %q but got nil", uri)
	}
	if *resourceId.uriSuffix != uri {
		t.Fatalf("expected a uriSuffix of %q but got %q", uri, *resourceId.uriSuffix)
	}
}

func validateSegmentsMatch(t *testing.T, actual []models.ResourceIdSegment, expected []models.ResourceIdSegment) {
	if len(actual) != len(expected) {
		t.Fatalf("expected there to be %d segments but got %d", len(expected), len(actual))
	}
	for i, expectedSegment := range expected {
		actualSegment := actual[i]
		if expectedSegment.Type != actualSegment.Type {
			t.Fatalf("expected segment %d to be Type %q but got %q", i, string(expectedSegment.Type), string(actualSegment.Type))
		}
	}
}
