// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids"
)

func (p *apiDefinitionsParser) ParseResourceIds() (*resourceids.ParseResult, error) {
	parser := resourceids.NewParser(p.context.SwaggerSpecExpanded)
	resourceIds, err := parser.Parse()
	if err != nil {
		return nil, fmt.Errorf("finding Resource IDs: %+v", err)
	}

	return resourceIds, nil
}
