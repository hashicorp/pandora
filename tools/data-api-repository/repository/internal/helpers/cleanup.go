// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import "strings"

func TrimNewLinesAround(input string) string {
	output := input
	for strings.HasPrefix(output, "\n") {
		output = strings.TrimPrefix(output, "\n")
	}
	for strings.HasSuffix(output, "\n") {
		output = strings.TrimSuffix(output, "\n")
	}
	return output
}
