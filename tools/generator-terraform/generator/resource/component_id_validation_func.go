// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func idValidationFunctionForResource(input models.ResourceInput) (*string, error) {
	if !input.Details.GenerateIdValidation {
		return nil, nil
	}

	validationLine, err := input.ValidateResourceIdFuncName()
	if err != nil {
		return nil, fmt.Errorf("determining Parse function name for Resource ID: %+v", err)
	}

	output := fmt.Sprintf(`
func (r %[1]sResource) IDValidationFunc() pluginsdk.SchemaValidateFunc {
	return %[2]s
}
`, input.ResourceTypeName, *validationLine)
	return &output, nil
}
