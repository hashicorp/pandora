// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"fmt"
	"strings"
)

func ConvertToSnakeCase(input string) string {
	// Special Cases for Acronyms that may run into adjacent words
	acronyms := []string{
		"DNS",
		"GPU",
		"IOPS",
		"IP",
		"OS",
		"SQL",
		"SSD",
		"VM",
	}
	for _, s := range acronyms {
		if strings.Contains(input, s) {
			input = strings.ReplaceAll(input, s, fmt.Sprintf("%s_", s))
		}
	}
	// Special-special case for HTTPS/HTTP...
	if strings.Contains(input, "HTTPS") {
		input = strings.ReplaceAll(input, "HTTPS", "HTTPS_")
	} else if strings.Contains(input, "HTTP") {
		input = strings.ReplaceAll(input, "HTTP", "HTTP_")
	}
	if strings.Contains(input, "HyperV") {
		input = strings.ReplaceAll(input, "HyperV", "HYPERV_")
	}

	input = strings.TrimSpace(input)
	n := strings.Builder{}
	for k, v := range []byte(input) {
		runeIsCap := v >= 'A' && v <= 'Z'
		if v == '_' {
			continue
		}
		if k+1 < len(input) {
			prevIsCap := k > 0 && input[k-1] >= 'A' && input[k-1] <= 'Z'
			if k > 0 && runeIsCap {
				if !prevIsCap {
					n.WriteByte('_')
				}
			}

			n.WriteByte(v)
			continue
		}
		n.WriteByte(v)
	}

	return strings.ToLower(n.String())
}

var schemaFieldNameOverrides = map[string]string{
	"etag": "etag",
	"ip":   "ip_address",
}
