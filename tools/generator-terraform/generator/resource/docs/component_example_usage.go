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
resource "%[1]s_%[2]s" "example" {
  // TODO: example usage
}
'''
`, input.ProviderPrefix, input.ResourceLabel))
	output := strings.ReplaceAll(code, "'", "`")
	return &output, nil
}
