package transforms

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func MapSDKOperationToRepository(operationName string, input importerModels.OperationDetails, knownConstants map[string]resourcemanager.ConstantDetails, knownModels map[string]importerModels.ModelDetails) (*dataapimodels.Operation, error) {
	contentType := input.ContentType
	if strings.Contains(strings.ToLower(input.ContentType), "application/json") {
		contentType = fmt.Sprintf("%s; charset=utf-8", input.ContentType)
	}

	output := dataapimodels.Operation{
		Name:                             operationName,
		ContentType:                      contentType,
		ExpectedStatusCodes:              input.ExpectedStatusCodes,
		FieldContainingPaginationDetails: input.FieldContainingPaginationDetails,
		LongRunning:                      input.LongRunning,
		HTTPMethod:                       strings.ToUpper(input.Method),
		ResourceIdName:                   input.ResourceIdName,
		UriSuffix:                        input.UriSuffix,
	}

	if input.RequestObject != nil {
		requestObject, err := mapSDKFieldObjectDefinitionToRepositoryInternal(input.RequestObject, knownConstants, knownModels)
		if err != nil {
			return nil, fmt.Errorf("mapping the request object definition: %+v", err)
		}
		output.RequestObject = requestObject
	}

	if input.ResponseObject != nil {
		responseObject, err := mapSDKFieldObjectDefinitionToRepositoryInternal(input.ResponseObject, knownConstants, knownModels)
		if err != nil {
			return nil, fmt.Errorf("mapping the response object definition: %+v", err)
		}
		output.ResponseObject = responseObject
	}

	if len(input.Options) > 0 {
		options := make([]dataapimodels.Option, 0)
		sortedOptionsKeys := make([]string, 0)
		for k := range input.Options {
			sortedOptionsKeys = append(sortedOptionsKeys, k)
		}
		sort.Strings(sortedOptionsKeys)

		for _, optionName := range sortedOptionsKeys {
			optionDetails := input.Options[optionName]

			if optionDetails.ObjectDefinition == nil {
				return nil, fmt.Errorf("missing object definition")
			}

			optionObjectDefinition, err := mapSDKOperationOptionToRepository(optionDetails.ObjectDefinition, knownConstants, knownModels)
			if err != nil {
				return nil, fmt.Errorf("mapping the object definition: %+v", err)
			}

			option := dataapimodels.Option{
				HeaderName:       optionDetails.HeaderName,
				QueryString:      optionDetails.QueryStringName,
				Field:            optionName,
				ObjectDefinition: optionObjectDefinition,
			}

			if !optionDetails.Required {
				option.Optional = true
			} else {
				option.Required = true
			}

			options = append(options, option)
		}
		output.Options = pointer.To(options)
	}

	return &output, nil
}
