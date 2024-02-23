// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (p *Parser) findDistinctConstants(input map[string]importerModels.ParsedResourceId) (*map[string]models.SDKConstant, error) {
	intermediate := internal.ParseResult{
		Constants: map[string]models.SDKConstant{},
	}

	for _, item := range input {
		intermediate.AppendConstants(item.Constants)
	}

	return &intermediate.Constants, nil
}
