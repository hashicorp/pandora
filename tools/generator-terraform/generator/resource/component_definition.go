// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func definitionForResource(input models.ResourceInput) (*string, error) {
	lines := []string{
		fmt.Sprintf("var _ sdk.Resource = %[1]sResource{}", input.ResourceTypeName),
	}
	if input.Details.UpdateMethod != nil && input.Details.UpdateMethod.Generate {
		lines = append(lines, fmt.Sprintf("var _ sdk.ResourceWithUpdate = %[1]sResource{}", input.ResourceTypeName))
	}
	// TODO: do we need to support state migrations etc in the future? likely not within the generator due to the type hints

	sort.Strings(lines)
	output := fmt.Sprintf(`
%[2]s

type %[1]sResource struct {}
`, input.ResourceTypeName, strings.Join(lines, "\n"))
	return &output, nil
}
