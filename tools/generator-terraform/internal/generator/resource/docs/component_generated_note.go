// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func codeForGeneratedNote(_ models.ResourceInput) (*string, error) {
	output := strings.TrimSpace(fmt.Sprintf(`
<!-- Note: This documentation is generated. Any manual changes will be overwritten -->
`))
	return &output, nil
}
