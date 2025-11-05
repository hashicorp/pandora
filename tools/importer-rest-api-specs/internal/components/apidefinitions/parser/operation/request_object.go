// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

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
	_, _, unexpandedOperation, found := parsingContext.OperationForID(input.operation.OperationID)
	if !found {
		return nil, nil, nil
	}

	for _, param := range unexpandedOperation.Parameters {
		if param == nil || param.Schema == nil || param.Schema.Value == nil {
			continue
		}

		if strings.EqualFold(param.In, "body") {
			parsingModel := true
			objectDefinition, result, err := parsingContext.ParseObjectDefinition(param.Schema.Value.Title, param.Schema.Value.Title, param.Schema, known, parsingModel)
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
