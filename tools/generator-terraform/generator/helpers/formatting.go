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
