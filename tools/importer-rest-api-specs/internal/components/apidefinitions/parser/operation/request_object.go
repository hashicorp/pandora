package operation

import (
	"fmt"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/parsingcontext"
)

func requestObjectForOperation(parsingContext *parsingcontext.Context, input parsedOperation, known parserModels.ParseResult) (*sdkModels.SDKObjectDefinition, *parserModels.ParseResult, error) {
	// all we should parse out is the top level object - nothing more.

	// find the same operation in the unexpanded swagger spec since we need the reference name
	_, _, unexpandedOperation, found := parsingContext.SwaggerSpecWithReferences.OperationForName(input.operation.ID)
	if !found {
		return nil, nil, nil
	}

	for _, param := range unexpandedOperation.Parameters {
		if strings.EqualFold(param.In, "body") {
			parsingModel := true
			loadParentType := true
			objectDefinition, result, err := parsingContext.ParseObjectDefinition(param.Schema.Title, param.Schema.Title, param.Schema, known, parsingModel, loadParentType)
			if err != nil {
				return nil, nil, fmt.Errorf("parsing request object for parameter %q: %+v", param.Name, err)
			}
			if objectDefinition != nil {
				return objectDefinition, result, nil
			}
		}
	}

	return nil, nil, nil
}
