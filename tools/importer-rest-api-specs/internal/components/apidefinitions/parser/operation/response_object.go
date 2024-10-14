// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package operation

import (
	"fmt"
	"sort"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/parsingcontext"
)

type operationResponseObjectResult struct {
	objectDefinition    *sdkModels.SDKObjectDefinition
	paginationFieldName *string
}

func responseObjectForOperation(parsingContext *parsingcontext.Context, input parsedOperation, known parserModels.ParseResult) (*operationResponseObjectResult, *parserModels.ParseResult, error) {
	output := operationResponseObjectResult{}
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	result.Append(known)

	// find the same operation in the unexpanded swagger spec since we need the reference name
	_, _, unexpandedOperation, found := parsingContext.SwaggerSpecWithReferences.OperationForName(input.operation.ID)
	if !found {
		return nil, nil, fmt.Errorf("couldn't find Operation ID %q in the unexpanded Swagger spec", input.operation.ID)
	}

	// since it's possible for operations to have multiple status codes, parse out all the objects and then find the most applicable
	statusCodes := make([]int, 0)
	objectDefinitionsByStatusCode := map[int]sdkModels.SDKObjectDefinition{}
	for statusCode, details := range unexpandedOperation.Responses.StatusCodeResponses {
		if !isASuccessResponse(statusCode, details) {
			continue
		}

		if details.ResponseProps.Schema == nil {
			continue
		}

		parsingModel := true
		objectDefinition, nestedResult, err := parsingContext.ParseObjectDefinition(details.ResponseProps.Schema.Title, details.ResponseProps.Schema.Title, details.ResponseProps.Schema, result, parsingModel)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing response object from status code %d: %+v", statusCode, err)
		}

		statusCodes = append(statusCodes, statusCode)
		objectDefinitionsByStatusCode[statusCode] = *objectDefinition
		result.Append(*nestedResult)
	}

	sort.Ints(statusCodes)
	// if there's multiple status codes, pick the first successful one (which should be a 200)
	for _, statusCode := range statusCodes {
		if statusCode < 200 || statusCode >= 300 {
			continue
		}

		object, ok := objectDefinitionsByStatusCode[statusCode]
		if !ok {
			return nil, nil, fmt.Errorf("internal-error: missing object definitions by status code for %d", statusCode)
		}
		output.objectDefinition = &object
		break
	}
	// otherwise just take the first one
	if len(statusCodes) > 0 && output.objectDefinition == nil {
		statusCode := statusCodes[0]
		object, ok := objectDefinitionsByStatusCode[statusCode]
		if !ok {
			return nil, nil, fmt.Errorf("internal-error: missing object definitions by status code for %d", statusCode)
		}
		output.objectDefinition = &object
	}

	return &output, &result, nil
}
