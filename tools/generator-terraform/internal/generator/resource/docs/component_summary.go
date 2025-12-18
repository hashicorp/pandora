// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func codeForSummary(input models.ResourceInput) (*string, error) {
	output := strings.TrimSpace(fmt.Sprintf(`
# %[1]s_%[2]s

%[3]s.
`, input.ProviderPrefix, input.ResourceLabel, input.Details.Documentation.Description))
	return &output, nil
}
