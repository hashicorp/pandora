// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func MapSDKOperationFromRepository(input repositoryModels.Operation, knownData helpers.KnownData) (*sdkModels.SDKOperation, error) {
	options := make(map[string]sdkModels.SDKOperationOption)
	if input.Options != nil {
		for _, value := range *input.Options {
			mapped, err := mapSDKOperationOptionFromRepository(value, knownData)
			if err != nil {
				return nil, fmt.Errorf("mapping the SDKOperationOption %q: %+v", value.Field, err)
			}

			options[value.Field] = *mapped
		}
	}
	output := sdkModels.SDKOperation{
		ContentType:                      input.ContentType,
		Description:                      input.Description,
		ExpectedStatusCodes:              input.ExpectedStatusCodes,
		FieldContainingPaginationDetails: input.FieldContainingPaginationDetails,
		LongRunning:                      input.LongRunning,
		Method:                           input.HTTPMethod,
		Options:                          options,
		RequestObject:                    nil,
		ResourceIDName:                   nil,
		ResourceIDNameIsCommonType:       input.ResourceIdNameIsCommonType,
		ResponseObject:                   nil,
		URISuffix:                        input.UriSuffix,
	}

	if input.ResourceIdName != nil {
		if known := knownData.ResourceIDExists(*input.ResourceIdName); !known {
			return nil, fmt.Errorf("the referenced Resource ID %q was not found", *input.ResourceIdName)
		}
		output.ResourceIDName = input.ResourceIdName
	}

	if input.RequestObject != nil {
		objectDefinition, err := mapSDKFieldObjectDefinitionFromRepository(*input.RequestObject)
		if err != nil {
			return nil, fmt.Errorf("mapping the RequestObject: %+v", err)
		}
		output.RequestObject = objectDefinition
	}
	if input.ResponseObject != nil {
		objectDefinition, err := mapSDKFieldObjectDefinitionFromRepository(*input.ResponseObject)
		if err != nil {
			return nil, fmt.Errorf("mapping the ResponseObject: %+v", err)
		}
		output.ResponseObject = objectDefinition
	}

	return &output, nil
}

func MapSDKOperationToRepository(operationName string, input sdkModels.SDKOperation, knownData helpers.KnownData) (*repositoryModels.Operation, error) {
	contentType := input.ContentType
	if strings.Contains(strings.ToLower(contentType), "application/json") {
		contentType = fmt.Sprintf("%s; charset=utf-8", contentType)
	}

	output := repositoryModels.Operation{
		Name:                             operationName,
		ContentType:                      contentType,
		Description:                      input.Description,
		ExpectedStatusCodes:              input.ExpectedStatusCodes,
		FieldContainingPaginationDetails: input.FieldContainingPaginationDetails,
		LongRunning:                      input.LongRunning,
		HTTPMethod:                       strings.ToUpper(input.Method),
		ResourceIdName:                   input.ResourceIDName,
		ResourceIdNameIsCommonType:       input.ResourceIDNameIsCommonType,
		UriSuffix:                        input.URISuffix,
	}

	if input.RequestObject != nil {
		requestObject, err := mapSDKFieldObjectDefinitionToRepository(*input.RequestObject, knownData)
		if err != nil {
			return nil, fmt.Errorf("mapping the request object definition: %+v", err)
		}
		output.RequestObject = requestObject
	}

	if input.ResponseObject != nil {
		responseObject, err := mapSDKFieldObjectDefinitionToRepository(*input.ResponseObject, knownData)
		if err != nil {
			return nil, fmt.Errorf("mapping the response object definition: %+v", err)
		}
		output.ResponseObject = responseObject
	}

	if len(input.Options) > 0 {
		options := make([]repositoryModels.Option, 0)
		sortedOptionsKeys := make([]string, 0)
		for k := range input.Options {
			sortedOptionsKeys = append(sortedOptionsKeys, k)
		}
		sort.Strings(sortedOptionsKeys)

		for _, optionName := range sortedOptionsKeys {
			optionDetails := input.Options[optionName]

			mapped, err := mapSDKOperationOptionToRepository(optionName, optionDetails, knownData)
			if err != nil {
				return nil, fmt.Errorf("mapping SDKOperationOption: %+v", err)
			}

			options = append(options, *mapped)
		}
		output.Options = pointer.To(options)
	}

	return &output, nil
}
