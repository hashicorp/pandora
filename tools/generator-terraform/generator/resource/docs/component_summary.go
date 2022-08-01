package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForSummary(input models.ResourceInput) (*string, error) {
	// TODO: we should probably return a summary/description from the API? That'd allow us to inject notes etc
	output := strings.TrimSpace(fmt.Sprintf(`
# %[1]s_%[2]s

Manages an %[3]s.
`, input.ProviderPrefix, input.ResourceLabel, input.Details.DisplayName))
	return &output, nil
}
