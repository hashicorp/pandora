// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package constants

import "testing"

func TestRenameMultiplesOfZero(t *testing.T) {
	testData := []struct {
		input    string
		expected string
	}{
		{
			input:    "OneZero",
			expected: "OneZero",
		},
		{
			input:    "TwoZeroZero",
			expected: "TwoHundred",
		},
		{
			input:    "ThreeZeroZeroZero",
			expected: "ThreeThousand",
		},
		{
			input:    "FourZeroZeroZeroZero",
			expected: "FourZeroThousand",
		},
		{
			input:    "SixZeroZeroZeroZeroZero",
			expected: "SixHundredThousand",
		},
		{
			input:    "SevenZeroZeroZeroZeroZeroZero",
			expected: "SevenMillion",
		},
		{
			input:    "EightNine",
			expected: "EightNine",
		},
		{
			input:    "ZeroZeroOne",
			expected: "ZeroZeroOne",
		},
		{
			input:    "OneZeroOne",
			expected: "OneZeroOne",
		},
		{
			input:    "",
			expected: "",
		},
		{
			input:    "symb0ls&numb3r5",
			expected: "symb0ls&numb3r5",
		},
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %s", v.input)

		actual := renameMultiplesOfZero(v.input)
		if actual != v.expected {
			t.Fatalf("Expected %s but got %s", v.expected, actual)
		}
	}
}
