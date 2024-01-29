// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func packageDefinitionForResource(input models.ResourceInput) (*string, error) {
	output := fmt.Sprintf("package %s", input.ServicePackageName)
	return &output, nil
}
