package processors

import "testing"

func TestProcessField_RemoveIsPrefix(t *testing.T) {
	testData := []struct {
		input         string
		metadataInput FieldMetadata
		expected      *string
	}{
		{
			input:         "IsDefault",
			metadataInput: FieldMetadata{},
			expected:      stringPointer("Default"),
		},
		{
			input:         "Default",
			metadataInput: FieldMetadata{},
			expected:      nil,
		},
		{
			input:         "Isolate",
			metadataInput: FieldMetadata{},
			expected:      nil,
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)

		actual, _ := fieldNameRemoveIsPrefix{}.ProcessField(v.input, v.metadataInput)

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
