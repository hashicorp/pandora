package operation

import (
	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/parsingcontext"
)

type parsedOperation struct {
	name       string
	uri        string
	httpMethod string
	operation  *spec.Operation
}

func findOperationsMatchingTag(parsingContext *parsingcontext.Context, tag *string) *[]parsedOperation {
	result := make([]parsedOperation, 0)
	for httpMethod, operation := range parsingContext.SwaggerSpecExpanded.Operations() {
		for uri, operationDetails := range operation {
			if !matchesTag(operationDetails, tag) {
				continue
			}

			operationName := cleanup.NormalizeOperationName(operationDetails.ID, tag)
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
