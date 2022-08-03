package definitions

import (
	"fmt"
	"strings"
)

func namespaceForApiVersion(input string) string {
	return fmt.Sprintf("v%s", strings.ReplaceAll(input, "-", "_"))
}
