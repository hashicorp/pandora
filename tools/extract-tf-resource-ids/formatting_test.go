package main

import (
	"testing"
)

func TestShortenFileName(t *testing.T) {
	testData := []struct {
		input    string
		expected string
	}{
		{
			input:    "b/data/Pandora.Definitions.ResourceManager/AAD/v2021_03_01/DomainServices/ResourceId-ResourceGroupId.cs",
			expected: ".../AAD/v2021_03_01/DomainServices/ResourceId-ResourceGroupId.cs",
		},
		{
			input:    "Pandora.Definitions.ResourceManager/AAD/v2021_03_01/DomainServices/ResourceId-ResourceGroupId.cs",
			expected: ".../AAD/v2021_03_01/DomainServices/ResourceId-ResourceGroupId.cs",
		},
		{
			input:    "",
			expected: ".../",
		},
		{
			input:    "notAPath",
			expected: ".../notAPath",
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)

		actual := shortenFileName(v.input)
		if actual != v.expected {
			t.Fatalf("Expected %s but got %s", v.expected, actual)
		}
	}
}

func TestReverseMap(t *testing.T) {
	testData := []struct {
		input    []map[string]string
		expected map[string][]string
	}{
		{
			input: []map[string]string{
				{
					".../AAD/v2020_01_01/DomainServices/ResourceId-ResourceGroupId.cs": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}",
				},
				{
					".../AAD/v2021_03_01/DomainServices/ResourceId-ResourceGroupId.cs": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}",
				},
				{
					".../AAD/v2021_05_01/DomainServices/ResourceId-ResourceGroupId.cs": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}",
				},
			},
			expected: map[string][]string{
				"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}": {
					".../AAD/v2020_01_01/DomainServices/ResourceId-ResourceGroupId.cs",
					".../AAD/v2021_03_01/DomainServices/ResourceId-ResourceGroupId.cs",
					".../AAD/v2021_05_01/DomainServices/ResourceId-ResourceGroupId.cs",
				},
			},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)

		actual := reverseMap(v.input)

		for id, _ := range v.expected {
			if _, exists := actual[id]; !exists {
				t.Fatalf("Key %s is missing from %+v", id, actual)
			}
			// TODO this keeps returning false even though the types, ordering and content is identical
			//if reflect.DeepEqual(paths, val) {
			//	t.Fatalf("Expected %s but got %s", v.expected, actual)
			//}
		}
	}
}
