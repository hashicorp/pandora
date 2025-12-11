// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func codeForExampleUsage(input models.ResourceInput) (*string, error) {
	code := strings.TrimSpace(fmt.Sprintf(`
## Example Usage

'''hcl
%[1]s
'''
`, input.Details.Documentation.ExampleUsageHCL))
	output := strings.ReplaceAll(code, "'", "`")
	return &output, nil
}
