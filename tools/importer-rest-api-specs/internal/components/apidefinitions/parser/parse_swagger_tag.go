package parser

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/commonschema"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/operation"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids"
)

func (p *apiDefinitionsParser) ParseAPIResourceWithinSwaggerTag(tag, resourceProvider *string, resourceIds resourceids.ParseResult, existingAPIResource sdkModels.APIResource) (*sdkModels.APIResource, error) {
	result := parserModels.ParseResult{
		Constants: existingAPIResource.Constants,
		Models:    existingAPIResource.Models,
	}

	// note that Resource ID's can contain Constants (used as segments)
	if err := result.AppendConstants(resourceIds.Constants); err != nil {
		return nil, fmt.Errorf("appending nestedResult from Constants: %+v", err)
	}

	// pull out the operations and any inlined/top-level constants/models
	operations, nestedResult, err := operation.ParseOperationsWithinTag(p.context, tag, resourceIds.OperationIdsToParsedResourceIds, resourceProvider, result)
	if err != nil {
		return nil, fmt.Errorf("finding operations: %+v", err)
	}
	if err := result.Append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from Operations: %+v", err)
	}

	// pull out each of the remaining models based on what we've got
	nestedResult, err = p.context.FindNestedItemsYetToBeParsed(operations, result)
	if err != nil {
		return nil, fmt.Errorf("finding nested items yet to be parsed: %+v", err)
	}
	if err := result.Append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from Models used by existing Items: %+v", err)
	}

	// then pull out the embedded model for List operations (e.g. we don't want the wrapper type but the type for the `value` field)
	operations, err = operation.RemoveWrapperModelForListOperations(operations, result)
	if err != nil {
		return nil, fmt.Errorf("pulling out model from list operations: %+v", err)
	}

	// if there's nothing here, there's no point generating a package
	if len(operations) == 0 {
		return nil, nil
	}

	resource := sdkModels.APIResource{
		Constants:   result.Constants,
		Models:      result.Models,
		Operations:  operations,
		ResourceIDs: resourceIds.NamesToResourceIDs,
	}

	// then switch out any Common Schema Types (e.g. Identity)
	resource = commonschema.ReplaceSDKObjectDefinitionsAsNeeded(resource)

	return &resource, nil
}
