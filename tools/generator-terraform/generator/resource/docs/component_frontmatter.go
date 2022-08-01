package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForYAMLFrontMatter(input models.ResourceInput) (*string, error) {
	output := strings.TrimSpace(fmt.Sprintf(`
---
subcategory: "%[1]s"
layout: "%[2]s"
page_title: "Azure Resource Manager: %[2]s_%[3]s"
description: |-
  %[4]s.
---
`, input.Details.Documentation.Category, input.ProviderPrefix, input.ResourceLabel, input.Details.Documentation.Description))
	return &output, nil
}
