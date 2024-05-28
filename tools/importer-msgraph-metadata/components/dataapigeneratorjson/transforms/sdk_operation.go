// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapSDKOperationToRepository(operationName string, input models.SDKOperation, knownConstants map[string]models.SDKConstant, knownModels map[string]models.SDKModel, knownCommonTypes models.CommonTypes) (*dataapimodels.Operation, error) {
	contentType := input.ContentType
	if strings.Contains(strings.ToLower(contentType), "application/json") {
		contentType = fmt.Sprintf("%s; charset=utf-8", contentType)
	}

	output := dataapimodels.Operation{
		Name:                             operationName,
		ContentType:                      contentType,
		ExpectedStatusCodes:              input.ExpectedStatusCodes,
		FieldContainingPaginationDetails: input.FieldContainingPaginationDetails,
		LongRunning:                      input.LongRunning,
		HTTPMethod:                       strings.ToUpper(input.Method),
		ResourceIdName:                   input.ResourceIDName,
		UriSuffix:                        input.URISuffix,
	}

	if input.RequestObject != nil {
		requestObject, err := mapSDKObjectDefinitionToRepository(*input.RequestObject, knownConstants, knownModels, knownCommonTypes)
		if err != nil {
			return nil, fmt.Errorf("mapping the request object definition: %+v", err)
		}
		output.RequestObject = requestObject
	}

	if input.ResponseObject != nil {
		responseObject, err := mapSDKObjectDefinitionToRepository(*input.ResponseObject, knownConstants, knownModels, knownCommonTypes)
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

			optionObjectDefinition, err := mapSDKOperationOptionToRepository(optionDetails.ObjectDefinition, knownConstants, knownModels, knownCommonTypes)
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
