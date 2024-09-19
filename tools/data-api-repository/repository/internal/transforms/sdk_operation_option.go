// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mapSDKOperationOptionFromRepository(input repositoryModels.Option, knownData helpers.KnownData) (*sdkModels.SDKOperationOption, error) {
	var objectDefinition sdkModels.SDKOperationOptionObjectDefinition
	if !input.RetryFunc {
		mapping, err := mapSDKOperationOptionObjectDefinitionFromRepository(input.ObjectDefinition, knownData)
		if err != nil {
			return nil, fmt.Errorf("mapping the ObjectDefinition: %+v", err)
		}
		objectDefinition = *mapping
	}

	return &sdkModels.SDKOperationOption{
		HeaderName:       input.HeaderName,
		ODataFieldName:   input.ODataFieldName,
		QueryStringName:  input.QueryString,
		ObjectDefinition: objectDefinition,
		Required:         input.Required,
		RetryFunc:        input.RetryFunc,
	}, nil
}

func mapSDKOperationOptionToRepository(fieldName string, input sdkModels.SDKOperationOption, knownData helpers.KnownData) (*repositoryModels.Option, error) {
	var objectDefinition repositoryModels.OptionObjectDefinition
	if !input.RetryFunc {
		mapping, err := mapSDKOperationOptionObjectDefinitionToRepository(input.ObjectDefinition, knownData)
		if err != nil {
			return nil, fmt.Errorf("mapping the object definition: %+v", err)
		}
		objectDefinition = *mapping
	}

	option := repositoryModels.Option{
		HeaderName:       input.HeaderName,
		ODataFieldName:   input.ODataFieldName,
		QueryString:      input.QueryStringName,
		Field:            fieldName,
		ObjectDefinition: objectDefinition,
		RetryFunc:        input.RetryFunc,
	}

	if !input.Required {
		option.Optional = true
	} else {
		option.Required = true
	}

	return &option, nil
}
