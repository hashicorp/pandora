package cleanup

import "testing"

func TestNormalizeReservedKeywords(t *testing.T) {
	testData := []struct {
		input    string
		expected string
	}{
		{
			input:    "default",
			expected: "defaultName",
		},
		{
			input:    "type",
			expected: "typeName",
		},
		{
			input:    "interface",
			expected: "interfaceName",
		},
		{
			input:    "chubbyPandas",
			expected: "chubbyPandas",
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)

		actual := NormalizeReservedKeywords(v.input)
		if actual != v.expected {
			t.Fatalf("Expected %s but got %s", v.expected, actual)
		}
	}
}

func TestNormalizeSegmentName(t *testing.T) {
	testData := []struct {
		input    string
		expected string
	}{
		{
			input:    "searches",
			expected: "Search",
		},
		{
			input:    "batches",
			expected: "Batch",
		},
		{
			input:    "classes",
			expected: "Class",
		},
		{
			input:    "prefixes",
			expected: "Prefix",
		},
		{
			input:    "databases",
			expected: "Database",
		},
		{
			input:    "services",
			expected: "Service",
		},
		{
			input:    "accounts",
			expected: "Account",
		},
		{
			input:    "studios",
			expected: "Studio",
		},
		{
			input:    "caches",
			expected: "Cache",
		},
		{
			input:    "identities",
			expected: "Identity",
		},
		{
			input:    "series",
			expected: "Series",
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)

		actual := NormalizeSegmentName(v.input)
		if actual != v.expected {
			t.Fatalf("Expected %s but got %s", v.expected, actual)
		}
	}
}
