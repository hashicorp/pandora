package parser

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/parsingcontext"
)

type apiDefinitionsParser struct {
	context *parsingcontext.Context
}

func NewAPIDefinitionsParser(filePath string) (*apiDefinitionsParser, error) {
	paringContext, err := parsingcontext.BuildFromFile(filePath)
	if err != nil {
		return nil, fmt.Errorf("building the parsing context: %+v", err)
	}

	return &apiDefinitionsParser{
		context: paringContext,
	}, nil
}
