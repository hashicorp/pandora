package resourceids

import (
	"testing"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestParseResourceIDFromOperation_ConstantSingle(t *testing.T) {
	// Resource IDs containing a constant with a single value aren't really constants, so there's
	// no point in outputting them as such - instead they get transformed into static values
	// as such whilst this provides a (single) Constant value we expect that this is a static value.

	param := spec.PathParam("planetName").WithEnum("Earth")
	param.AddExtension("x-ms-enum", map[string]interface{}{
		"name": "NameOfPlanet",
	})
	swagger := spec.NewOperation("Example_Operation").AddParam(param)
	uri := "/planets/{planetName}"

	parser := NewParser(hclog.NewNullLogger(), nil)
	resourceId, err := parser.parseResourceIdFromOperation(uri, swagger)
	if err != nil {
		t.Fatalf("parsing Resource ID from %q: %+v", uri, err)
	}

	if resourceId.uriSuffix == nil {
		t.Fatalf("expected there to be a uriSuffix but didn't get one")
	}
	if *resourceId.uriSuffix != "/planets/Earth" {
		t.Fatalf("expected uriSuffix to be `/planets/Earth` but got %q", *resourceId.uriSuffix)
	}
	if len(resourceId.constants) != 0 {
		t.Fatalf("expected 0 constants but got %d", len(resourceId.constants))
	}
	if resourceId.segments != nil {
		t.Fatalf("expected segments to be nil but got %d segments", len(*resourceId.segments))
	}
}

func TestParseResourceIDFromOperation_ConstantMultiple(t *testing.T) {
	param := spec.PathParam("planetName").WithEnum("Earth", "Mars")
	param.AddExtension("x-ms-enum", map[string]interface{}{
		"name": "NameOfPlanet",
	})
	swagger := spec.NewOperation("Example_Operation").AddParam(param)
	uri := "/planets/{planetName}"

	parser := NewParser(hclog.NewNullLogger(), nil)
	resourceId, err := parser.parseResourceIdFromOperation(uri, swagger)
	if err != nil {
		t.Fatalf("parsing Resource ID from %q: %+v", uri, err)
	}

	if resourceId.uriSuffix != nil {
		t.Fatalf("expected no uriSuffix but got %q", *resourceId.uriSuffix)
	}
	if len(resourceId.constants) != 1 {
		t.Fatalf("expected 1 constants but got %d", len(resourceId.constants))
	}
	if resourceId.segments == nil {
		t.Fatalf("expected 2 segments but got 0")
	}
	expectedSegments := []resourcemanager.ResourceIdSegment{
		models.StaticResourceIDSegment("planets", "planets"),
		models.ConstantResourceIDSegment("planetName", "NameOfPlanet"),
	}
	validateSegmentsMatch(t, *resourceId.segments, expectedSegments)

	constant, found := resourceId.constants["NameOfPlanet"]
	if !found {
		t.Fatalf("expected a constant named NameOfPlanet but didn't get one")
	}
	if len(constant.Values) != 2 {
		t.Fatalf("expected the constant NameOfPlanet to have 2 values but got %d", len(constant.Values))
	}
	if _, ok := constant.Values["Earth"]; !ok {
		t.Fatalf("expected the constant NameOfPlanet to have a value named Earth but didn't get one")
	}
	if _, ok := constant.Values["Mars"]; !ok {
		t.Fatalf("expected the constant NameOfPlanet to have a value named Mars but didn't get one")
	}
}

func TestParseResourceIDFromOperation_InvalidSegmentDefaultGetsTransformed(t *testing.T) {
	// `default` is a language keyword in both C# and Go - so we need to ensure it's
	// not output directly, but should be transformed into `defaultName` so that it's
	// output as a variable rather than a language keyword (see #935)
	swagger := spec.NewOperation("Example_Operation")
	uri := "/defaults/{default}"

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
	expectedSegments := []resourcemanager.ResourceIdSegment{
		models.StaticResourceIDSegment("defaults", "defaults"),
		models.UserSpecifiedResourceIDSegment("defaultName"),
	}
	validateSegmentsMatch(t, *resourceId.segments, expectedSegments)

	// since the validateSegmentsMatch ignores the names of the UserSpecifiedSegments and that's
	// our concern here, we'll explicitly check this matches what we expect too
	secondSegment := (*resourceId.segments)[1]
	if secondSegment.Name != "defaultName" {
		t.Fatalf("expected the second segment to have the name `defaultName` but got %q", secondSegment.Name)
	}
}

func TestParseResourceIDFromOperation_InvalidSegmentDefaultAsStaticValueGetsLeft(t *testing.T) {
	// whilst `default` is a language keyword, since this is a static segment it shouldn't be
	// transformed - which this test is explicitly checking
	swagger := spec.NewOperation("Example_Operation")
	uri := "/default"

	parser := NewParser(hclog.NewNullLogger(), nil)
	resourceId, err := parser.parseResourceIdFromOperation(uri, swagger)
	if err != nil {
		t.Fatalf("parsing Resource ID from %q: %+v", uri, err)
	}

	if resourceId.uriSuffix == nil {
		t.Fatalf("expected a uriSuffix but got nil")
	}
	if *resourceId.uriSuffix != "/default" {
		t.Fatalf("expected the uriSuffix to be `/default` but got %q", *resourceId.uriSuffix)
	}
	if len(resourceId.constants) != 0 {
		t.Fatalf("expected 0 constants but got %d", len(resourceId.constants))
	}
	if resourceId.segments != nil {
		t.Fatalf("expected 0 segments but got %d", len(*resourceId.segments))
	}
}

func TestParseResourceIDFromOperation_InvalidSegmentTypeGetsTransformed(t *testing.T) {
	// `type` is a language keyword in both C# and Go - so we need to ensure it's
	// not output directly, but should be transformed into `typeName` so that it's
	// output as a variable rather than a language keyword (see #935)
	swagger := spec.NewOperation("Example_Operation")
	uri := "/things/{type}"

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
	expectedSegments := []resourcemanager.ResourceIdSegment{
		models.StaticResourceIDSegment("things", "things"),
		models.UserSpecifiedResourceIDSegment("typeName"),
	}
	validateSegmentsMatch(t, *resourceId.segments, expectedSegments)

	// since the validateSegmentsMatch ignores the names of the UserSpecifiedSegments and that's
	// our concern here, we'll explicitly check this matches what we expect too
	secondSegment := (*resourceId.segments)[1]
	if secondSegment.Name != "typeName" {
		t.Fatalf("expected the second segment to have the name `typeName` but got %q", secondSegment.Name)
	}
}

func TestParseResourceIDFromOperation_ManagementGroupId(t *testing.T) {
	swagger := spec.NewOperation("Example_Operation")
	uri := "/providers/Microsoft.Management/managementGroups/{groupId}"

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
	expectedSegments := []resourcemanager.ResourceIdSegment{
		models.StaticResourceIDSegment("providers", "providers"),
		models.ResourceProviderResourceIDSegment("resourceProviders", "Microsoft.Management"),
		models.StaticResourceIDSegment("managementGroups", "managementGroups"),
		models.UserSpecifiedResourceIDSegment("groupId"),
	}
	validateSegmentsMatch(t, *resourceId.segments, expectedSegments)
}

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
	expectedSegments := []resourcemanager.ResourceIdSegment{
		models.StaticResourceIDSegment("providers", "providers"),
		models.SubscriptionIDResourceIDSegment("subscriptionId"),
		models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
		models.ResourceGroupResourceIDSegment("resourceGroupName"),
	}
	validateSegmentsMatch(t, *resourceId.segments, expectedSegments)
}

func TestParseResourceIDFromOperation_Scope(t *testing.T) {
	swagger := spec.NewOperation("Example_Operation")
	uri := "/{resourceId}"

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
		t.Fatalf("expected 1 segments but got 0")
	}
	expectedSegments := []resourcemanager.ResourceIdSegment{
		models.ScopeResourceIDSegment("resourceId"),
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
	expectedSegments := []resourcemanager.ResourceIdSegment{
		models.StaticResourceIDSegment("providers", "providers"),
		models.SubscriptionIDResourceIDSegment("subscriptionId"),
	}
	validateSegmentsMatch(t, *resourceId.segments, expectedSegments)
}

func TestParseResourceIDFromOperation_UriSuffixOnly(t *testing.T) {
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

func TestParseResourceIDFromOperation_UserAssignedIdentityId(t *testing.T) {
	swagger := spec.NewOperation("Example_Operation")
	uri := "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{resourceName}"

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
		t.Fatalf("expected 8 segments but got 0")
	}
	expectedSegments := []resourcemanager.ResourceIdSegment{
		models.StaticResourceIDSegment("subscriptions", "subscriptions"),
		models.SubscriptionIDResourceIDSegment("subscriptionId"),
		models.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
		models.ResourceGroupResourceIDSegment("resourceGroupName"),
		models.StaticResourceIDSegment("providers", "providers"),
		models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.ManagedIdentity"),
		models.StaticResourceIDSegment("userAssignedIdentities", "userAssignedIdentities"),
		models.UserSpecifiedResourceIDSegment("resourceName"),
	}
	validateSegmentsMatch(t, *resourceId.segments, expectedSegments)
}

func validateSegmentsMatch(t *testing.T, actual []resourcemanager.ResourceIdSegment, expected []resourcemanager.ResourceIdSegment) {
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
