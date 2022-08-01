package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForExampleUsage(input models.ResourceInput) (*string, error) {
	code := strings.TrimSpace(fmt.Sprintf(`
## Example Usage

'''hcl
%[1]s
'''
`, strings.TrimSpace(input.Details.Documentation.ExampleUsageHcl)))
	output := strings.ReplaceAll(code, "'", "`")
	return &output, nil
}
