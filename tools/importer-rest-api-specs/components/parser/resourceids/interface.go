package resourceids

import (
	"github.com/go-openapi/analysis"
	"github.com/hashicorp/go-hclog"
)

type Parser struct {
	logger hclog.Logger

	swaggerSpecExpanded *analysis.Spec
}

// NewParser returns a Parser instance which can be used to parse Resource IDs
func NewParser(logger hclog.Logger, swaggerSpecExpanded *analysis.Spec) *Parser {
	return &Parser{
		logger:              logger,
		swaggerSpecExpanded: swaggerSpecExpanded,
	}
}
