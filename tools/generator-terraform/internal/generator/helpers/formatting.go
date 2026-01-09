// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"fmt"
	"strings"
)

func NamespaceForApiVersion(input string) string {
	output := fmt.Sprintf("v%s", strings.ReplaceAll(input, "-", ""))

	if strings.HasSuffix(output, "beta") {
		output = strings.Replace(output, "beta", "Beta", 1)
	}
	if strings.HasSuffix(output, "privatepreview") {
		output = strings.Replace(output, "privatepreview", "PrivatePreview", 1)
	}
	if strings.HasSuffix(output, "publicpreview") {
		output = strings.Replace(output, "publicpreview", "PublicPreview", 1)
	}
	if strings.HasSuffix(output, "preview") {
		output = strings.Replace(output, "preview", "Preview", 1)
	}
	return output
}

func CamelCasedName(input string) string {
	firstLetter := strings.ToLower(string(input[0]))
	return firstLetter + input[1:]
}
