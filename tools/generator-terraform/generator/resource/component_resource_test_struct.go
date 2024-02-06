// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func testResourceStruct(input models.ResourceInput) (*string, error) {
	output := fmt.Sprintf("type %sTestResource struct{}", input.ResourceTypeName)
	return &output, nil
}
