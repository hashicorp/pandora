// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/getkin/kin-openapi/openapi2"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/parsingcontext"
)

type Parser struct {
	Context *parsingcontext.Context

	Expanded openapi2.SchemaRef
}

// NewParser returns a Parser instance which can be used to parse Resource IDs
func NewParser(ctx *parsingcontext.Context) *Parser {
	return &Parser{
		Context: ctx,
	}
}
