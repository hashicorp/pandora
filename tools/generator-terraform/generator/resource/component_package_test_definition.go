// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func packageTestDefinitionForResource(input models.ResourceInput) (*string, error) {
	output := fmt.Sprintf("package %s_test", input.ServicePackageName)
	return &output, nil
}
