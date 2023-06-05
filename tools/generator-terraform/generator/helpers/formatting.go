package helpers

import (
	"fmt"
	"strings"
)

func NamespaceForApiVersion(input string) string {
	output := fmt.Sprintf("v%s", strings.ReplaceAll(input, "-", ""))

	if strings.HasSuffix(output, "preview") {
		output = strings.Replace(output, "preview", "Preview", 1)
	}
	return output
}
