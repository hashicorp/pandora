// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func generationNoteForResource(_ models.ResourceInput) (*string, error) {
	output := `

// NOTE: this file is generated - manual changes will be overwritten.

`
	return &output, nil
}
