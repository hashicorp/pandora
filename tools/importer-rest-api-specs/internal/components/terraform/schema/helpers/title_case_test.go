// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import "testing"

func TestConvertFromSnakeToTitleCase(t *testing.T) {
	t.Parallel()
	testData := []struct {
		input    string
		expected string
	}{
		{
			input:    "oh_lawd_he_coming",
			expected: "OhLawdHeComing",
		},
		{
			input:    "dns_name",
			expected: "DnsName",
		},
		{
			input:    "ThisIsAlreadyTitleCased",
			expected: "ThisIsAlreadyTitleCased",
		},
		{
			input:    "1_2_3_4",
			expected: "1234",
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)
		actual := ConvertFromSnakeToTitleCase(v.input)
		if actual != v.expected {
			t.Fatalf("Expected %s but got %s", v.expected, actual)
		}
	}
}
