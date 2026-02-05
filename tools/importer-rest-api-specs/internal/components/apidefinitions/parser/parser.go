// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/parsingcontext"
)

type apiDefinitionsParser struct {
	context *parsingcontext.Context

	DataPlane bool
}

func NewAPIDefinitionsParser(filePath string) (*apiDefinitionsParser, error) {
	parsingContext, err := parsingcontext.BuildFromFile(filePath)
	if err != nil {
		return nil, fmt.Errorf("building the parsing context: %+v", err)
	}

	return &apiDefinitionsParser{
		context: parsingContext,
	}, nil
}
