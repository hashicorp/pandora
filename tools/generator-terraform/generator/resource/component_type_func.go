// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func typeFuncForResource(input models.ResourceInput) (*string, error) {
	output := fmt.Sprintf(`
func (r %[1]sResource) ResourceType() string {
	return "%[2]s_%[3]s"
}
`, input.ResourceTypeName, input.ProviderPrefix, input.ResourceLabel)
	return &output, nil
}
