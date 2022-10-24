package parser

import "testing"

func TestParsingOperationsUsingTheSameSwaggerTagInDifferentCasings(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "operations_single_tag_different_casing.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Hello"]
	if !ok {
		t.Fatal("the Resource 'Hello' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 0 {
		t.Fatalf("expected 0 constants but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 1 {
		t.Fatalf("expected 1 model but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 4 {
		t.Fatalf("expected 4 Operations but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 0 {
		t.Fatalf("expected 0 Resource IDs but got %d", len(resource.ResourceIds))
	}
	expectedOperations := []string{
		"First",
		"PutBar",
		"PutFoo",
		"Second",
	}
	for _, expected := range expectedOperations {
		if _, ok := resource.Operations[expected]; !ok {
			t.Fatalf("expected there to be an operation named %q but didn't get one", expected)
		}
	}
}
