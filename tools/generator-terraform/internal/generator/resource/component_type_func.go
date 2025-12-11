// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func typeFuncForResource(input models.ResourceInput) (*string, error) {
	output := fmt.Sprintf(`
func (r %[1]sResource) ResourceType() string {
	return "%[2]s_%[3]s"
}
`, input.ResourceTypeName, input.ProviderPrefix, input.ResourceLabel)
	return &output, nil
}
