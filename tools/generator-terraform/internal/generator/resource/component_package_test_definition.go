// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func packageTestDefinitionForResource(input models.ResourceInput) (*string, error) {
	output := fmt.Sprintf("package %s_test", input.ServicePackageName)
	return &output, nil
}
