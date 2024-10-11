// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package normalize

import "testing"

func TestCleanName(t *testing.T) {
	testCases := map[string]string{
		"CloudPc":   "CloudPC",
		"Ref":       "Ref",
		"Reference": "Reference",
	}

	for input, expected := range testCases {
		result := CleanName(input)
		if result != expected {
			t.Errorf("CleanName(%q): got %q, expected %q", input, result, expected)
		}
	}
}
