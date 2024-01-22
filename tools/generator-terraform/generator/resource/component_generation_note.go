// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import "github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

func generationNoteForResource(_ models.ResourceInput) (*string, error) {
	output := `

// NOTE: this file is generated - manual changes will be overwritten.

`
	return &output, nil
}
