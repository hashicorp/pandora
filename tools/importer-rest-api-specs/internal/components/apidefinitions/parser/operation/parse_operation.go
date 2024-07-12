package operation

import (
	"fmt"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/parsingcontext"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids"
)

func parseOperation(parsingContext *parsingcontext.Context, operation parsedOperation, resourceProvider *string, operationIdsToParsedOperations map[string]resourceids.ParsedOperation) (*sdkModels.SDKOperation, *parserModels.ParseResult, error) {
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}

	contentType := determineContentType(operation)
	expectedStatusCodes := expectedStatusCodesForOperation(operation)
	paginationField := fieldContainingPaginationDetailsForOperation(operation)
	requestObject, nestedResult, err := requestObjectForOperation(parsingContext, operation, result)
	if err != nil {
		return nil, nil, fmt.Errorf("determining request operation for %q (method %q / ID %q): %+v", operation.name, operation.httpMethod, operation.operation.ID, err)
	}
	if nestedResult != nil {
		if err := result.Append(*nestedResult); err != nil {
			return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
	}
	responseResult, nestedResult, err := responseObjectForOperation(parsingContext, operation, result)
	if err != nil {
		return nil, nil, fmt.Errorf("determining response operation for %q (method %q / ID %q): %+v", operation.name, operation.httpMethod, operation.operation.ID, err)
	}
	if nestedResult != nil {
		if err := result.Append(*nestedResult); err != nil {
			return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
	}
	if paginationField == nil && responseResult.paginationFieldName != nil {
		paginationField = responseResult.paginationFieldName
	}
	longRunning := isLongRunning(operation)

	options, nestedResult, err := optionsForOperation(operation)
	if err != nil {
		return nil, nil, fmt.Errorf("building options for operation %q: %+v", operation.name, err)
	}
	if nestedResult != nil {
		if err := result.Append(*nestedResult); err != nil {
			return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
	}

	resourceId := operationIdsToParsedOperations[operation.operation.ID]
	usesADifferentResourceProvider, err := resourceIdUsesAResourceProviderOtherThan(resourceId.ResourceId, resourceProvider)
	if err != nil {
		return nil, nil, err
	}
	if usesADifferentResourceProvider != nil && *usesADifferentResourceProvider {
		return nil, nil, nil
	}

	operationData := sdkModels.SDKOperation{
		ContentType:                      contentType,
		ExpectedStatusCodes:              expectedStatusCodes,
		FieldContainingPaginationDetails: paginationField,
		LongRunning:                      longRunning,
		Method:                           strings.ToUpper(operation.httpMethod),
		Options:                          *options,
		RequestObject:                    requestObject,
		ResourceIDName:                   resourceId.ResourceIdName,
		ResponseObject:                   responseResult.objectDefinition,
		URISuffix:                        resourceId.UriSuffix,
	}

	if shouldBeIgnored(operationData) {
		return nil, nil, nil
	}

	return &operationData, &result, nil
}
