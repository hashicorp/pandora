// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/go-openapi/analysis"
)

type Parser struct {
	swaggerSpecExpanded *analysis.Spec
}

// NewParser returns a Parser instance which can be used to parse Resource IDs
func NewParser(swaggerSpecExpanded *analysis.Spec) *Parser {
	return &Parser{
		swaggerSpecExpanded: swaggerSpecExpanded,
	}
}
