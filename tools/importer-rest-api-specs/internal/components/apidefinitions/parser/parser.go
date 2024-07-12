package parser

import (
	"fmt"

	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/parsingcontext"
)

type apiDefinitionsParser struct {
	context *parsingcontext.Context
}

func NewAPIDefinitionsParser(filePath string, supplementaryData parserModels.SupplementaryData) (*apiDefinitionsParser, error) {
	paringContext, err := parsingcontext.BuildFromFile(filePath, supplementaryData)
	if err != nil {
		return nil, fmt.Errorf("building the parsing context: %+v", err)
	}

	return &apiDefinitionsParser{
		context: paringContext,
	}, nil
}
