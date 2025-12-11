// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func codeForYAMLFrontMatter(input models.ResourceInput) (*string, error) {
	// NOTE: we're intentionally not reusing the Description here since it can be multi-line and invalid
	// for the YAML description. Whilst this definitely isn't perfect grammatically (`a` vs `an`), since
	// this is only used for the website description it should be fine.

	// TODO: thread through `Provider Display Name` (Azure Resource Manager) as a variable
	frontMatterDescription := fmt.Sprintf("Manages a %s.", input.Details.DisplayName)
	output := strings.TrimSpace(fmt.Sprintf(`
---
subcategory: "%[1]s"
layout: "%[2]s"
page_title: "Azure Resource Manager: %[2]s_%[3]s"
description: |-
  %[4]s
--- 
`, input.Details.Documentation.Category, input.ProviderPrefix, input.ResourceLabel, frontMatterDescription))
	return &output, nil
}
