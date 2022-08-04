package schema

import "testing"

func TestUpdateNameForField_Is(t *testing.T) {
	testData := []struct {
		input    string
		expected *string
	}{
		{
			input:    "is_default",
			expected: stringPointer("default"),
		},
		{
			input:    "default",
			expected: nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)

		actual := fieldNameIs{}.updatedNameForField(v.input)

		if actual == nil {
			if v.expected == nil {
				continue
			}
			t.Fatalf("expected a result but didn't get one")
		}
		if v.expected == nil {
			t.Fatalf("expected no result but got %s", *actual)
		}
		if *actual != *v.expected {
			t.Fatalf("Expected %s but got %s", *v.expected, *actual)
		}
	}
}
