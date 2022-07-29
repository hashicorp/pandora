package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForYAMLFrontMatter(input models.ResourceInput) string {
	return strings.TrimSpace(fmt.Sprintf(`
---
subcategory: "%[1]s"
layout: "%[2]s"
page_title: "%[5]s: %[2]s_%[3]s"
description: |-
  Manages an %[4]s.
---
`, "Connections", input.ProviderPrefix, input.ResourceLabel, input.Details.DisplayName, "Azure Resource Manager"))
}
