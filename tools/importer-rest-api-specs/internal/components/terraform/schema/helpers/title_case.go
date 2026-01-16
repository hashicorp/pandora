// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"unicode"
)

func ConvertFromSnakeToTitleCase(input string) string {
	output := make([]rune, 0)

	for k, v := range input {
		if v == '_' {
			continue
		}
		if k == 0 || (k > 0 && input[k-1] == '_') {
			output = append(output, unicode.ToUpper(v))
			continue
		}
		output = append(output, v)
	}

	return string(output)
}
