package cleanup

import "testing"

func TestPluralisingWords(t *testing.T) {
	testData := []struct {
		input    string
		expected string
	}{
		{
			input:    "identity",
			expected: "identities",
		},
		{
			input:    "series",
			expected: "series",
		},
		{
			input:    "database",
			expected: "databases",
		},
		{
			input:    "Redis",
			expected: "Redis",
		},
		{
			input:    "redis",
			expected: "redis",
		},
		{
			input:    "resourceGroup",
			expected: "resourceGroups",
		},
		{
			input:    "Cache",
			expected: "Caches",
		},
		{
			input:    "cache",
			expected: "caches",
		},
		{
			input:    "ServiceLinker",
			expected: "ServiceLinker",
		},
		{
			input:    "key",
			expected: "keys",
		},
		{
			input:    "autoscaleAPI",
			expected: "autoscaleAPIs",
		},
		{
			input:    "API",
			expected: "APIs",
		},
	}

	for _, v := range testData {

		actual := GetPlural(v.input)
		t.Logf("[DEBUG] Testing %s, got %s", v.input, actual)
		if actual != v.expected {
			t.Fatalf("Expected %s but got %s", v.expected, actual)
		}
	}
}

func TestSingularisingWords(t *testing.T) {
	testData := []struct {
		input    string
		expected string
	}{
		{
			input:    "identities",
			expected: "identity",
		},
		{
			input:    "series",
			expected: "series",
		},
		{
			input:    "databases",
			expected: "database",
		},
		{
			input:    "Redis",
			expected: "Redis",
		},
		{
			input:    "redis",
			expected: "redis",
		},
		{
			input:    "resourceGroups",
			expected: "resourceGroup",
		},
		{
			input:    "Caches",
			expected: "Cache",
		},
		{
			input:    "caches",
			expected: "cache",
		},
		{
			input:    "Cache",
			expected: "Cache",
		},
		{
			input:    "ServiceLinker",
			expected: "ServiceLinker",
		},
		{
			input:    "APIs",
			expected: "API",
		},
		{
			input:    "AutoscaleAPIs",
			expected: "AutoscaleAPI",
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)

		actual := GetSingular(v.input)
		if actual != v.expected {
			t.Fatalf("Expected %s but got %s", v.expected, actual)
		}
	}
}
