// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids"
)

func (d *SwaggerDefinition) ParseResourceIds() (*resourceids.ParseResult, error) {
	parser := resourceids.NewParser(d.swaggerSpecExpanded)

	resourceIds, err := parser.Parse()
	if err != nil {
		return nil, fmt.Errorf("finding Resource IDs: %+v", err)
	}

	return resourceIds, nil
}
