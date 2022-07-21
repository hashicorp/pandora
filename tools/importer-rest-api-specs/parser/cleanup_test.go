package parser

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
