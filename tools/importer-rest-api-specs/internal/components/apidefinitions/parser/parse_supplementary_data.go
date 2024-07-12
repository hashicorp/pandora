package parser

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/constants"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
)

func (p *apiDefinitionsParser) SupplementaryData() (*parserModels.SupplementaryData, error) {
	result := parserModels.SupplementaryData{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}

	for objectName, definition := range p.context.SwaggerSpecRaw.Definitions {
		var parsedConstant *constants.ParsedConstant
		parsedModel, err := p.context.ParseModel(objectName, definition, false)
		if err != nil {
			var err2 error
			parsedConstant, err2 = p.context.ParseConstant(objectName, definition)
			if err != nil {
				return nil, fmt.Errorf("failed to parse %q as a Constant or a Model. Constant error: [%+v]. Model error: [%+v]", objectName, err, err2)
			}
		}
		if parsedModel != nil {
			if err := result.AppendParseResult(*parsedModel); err != nil {
				return nil, fmt.Errorf("appending model %q: %+v", objectName, err)
			}
		}
		if parsedConstant != nil {
			if err := result.AppendConstant(parsedConstant.Name, parsedConstant.Details); err != nil {
				return nil, fmt.Errorf("appending constant %q: %+v", objectName, err)
			}
		}
	}

	// FindNestedItemsYetToBeParsed takes ParseResult and so we need to shim this across
	//shim := parserModels.ParseResult{
	//	Constants: result.Constants,
	//	Models:    result.Models,
	//}
	//// this will also pull out the parent model in the file which will already have been parsed, but that's ok
	//// since they will be de-duplicated when we call combineResourcesWith
	//nestedResult, err := p.context.FindNestedItemsYetToBeParsed(map[string]sdkModels.SDKOperation{}, shim)
	//if err != nil {
	//	return nil, fmt.Errorf("finding nested items yet to be parsed: %+v", err)
	//}
	//if err := result.AppendParseResult(*nestedResult); err != nil {
	//	return nil, fmt.Errorf("appending nestedResult from Models used by existing Items: %+v", err)
	//}

	return &result, nil
}
