package main

import (
	"testing"

	"github.com/go-test/deep"
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
		{
			input: []map[string]string{
				{
					"path1": "id1",
				},
				{
					"path2": "id2",
				},
				{
					"path3": "id1",
				},
			},
			expected: map[string][]string{
				"id1": {
					"path1",
					"path3",
				},
				"id2": {
					"path2",
				},
			},
		},
		{
			input:    []map[string]string{},
			expected: map[string][]string{},
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)

		actual := reverseMap(v.input)

		if len(deep.Equal(actual, v.expected)) > 0 {
			t.Fatalf("Expected %s but got %s", v.expected, actual)
		}
	}
}
