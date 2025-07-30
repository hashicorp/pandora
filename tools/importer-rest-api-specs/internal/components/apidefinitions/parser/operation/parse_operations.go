// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package operation

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/ignore"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/parsingcontext"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func ParseOperationsWithinTag(parsingContext *parsingcontext.Context, tag *string, operationIdsToParsedOperations map[string]resourceids.ParsedOperation, resourceProvider *string, found parserModels.ParseResult) (map[string]sdkModels.SDKOperation, *parserModels.ParseResult, error) {
	operations := make(map[string]sdkModels.SDKOperation, 0)
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	result.Append(found)

	// first find the operations then pull out everything we can
	operationsForThisTag := findOperationsMatchingTag(parsingContext, tag)
	for _, operation := range *operationsForThisTag {
		logging.Debugf("Operation - %s %q..", operation.httpMethod, operation.uri)

		if ignore.Operation(operation.uri) {
			logging.Debug("Operation should be ignored - skipping..")
			continue
		}

		op, nestedResult, err := parseOperation(parsingContext, operation, resourceProvider, operationIdsToParsedOperations)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing %s operation %q: %+v", operation.httpMethod, operation.uri, err)
		}
		if nestedResult != nil {
			if err := result.Append(*nestedResult); err != nil {
				return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
			}
		}

		if existing, hasExisting := operations[operation.name]; hasExisting {
			return nil, nil, fmt.Errorf("conflicting operations with the Name %q - first %q - second %q", operation.name, existing.Method, op.Method)
		}

		if op == nil {
			continue
		}
		operations[operation.name] = *op
	}

	return operations, &result, nil
}
