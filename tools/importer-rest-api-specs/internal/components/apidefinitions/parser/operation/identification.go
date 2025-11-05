// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package operation

import (
	"github.com/getkin/kin-openapi/openapi2"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/parsingcontext"
)

type parsedOperation struct {
	name       string
	uri        string
	httpMethod string
	operation  *openapi2.Operation
}

func findOperationsMatchingTag(parsingContext *parsingcontext.Context, tag *string) *[]parsedOperation {
	result := make([]parsedOperation, 0)
	for httpMethod, operation := range parsingContext.Operations() {
		for uri, operationDetails := range operation {
			if !matchesTag(operationDetails, tag) {
				continue
			}

			operationName := cleanup.NormalizeOperationName(operationDetails.OperationID, tag)
			result = append(result, parsedOperation{
				name:       operationName,
				uri:        uri,
				httpMethod: httpMethod,
				operation:  operationDetails,
			})
		}
	}

	return &result
}
