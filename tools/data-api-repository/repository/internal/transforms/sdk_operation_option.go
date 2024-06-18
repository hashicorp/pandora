// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mapSDKOperationOptionFromRepository(input repositoryModels.Option, knownConstants map[string]sdkModels.SDKConstant, knownModels map[string]sdkModels.SDKModel) (*sdkModels.SDKOperationOption, error) {
	objectDefinition, err := mapSDKOperationOptionObjectDefinitionFromRepository(input.ObjectDefinition, knownConstants, knownModels)
	if err != nil {
		return nil, fmt.Errorf("mapping the ObjectDefinition: %+v", err)
	}

	return &sdkModels.SDKOperationOption{
		HeaderName:       input.HeaderName,
		QueryStringName:  input.QueryString,
		ObjectDefinition: *objectDefinition,
		Required:         input.Required,
	}, nil
}

func mapSDKOperationOptionToRepository(fieldName string, input sdkModels.SDKOperationOption, knownConstants map[string]sdkModels.SDKConstant, knownModels map[string]sdkModels.SDKModel) (*repositoryModels.Option, error) {
	objectDefinition, err := mapSDKOperationOptionObjectDefinitionToRepository(input.ObjectDefinition, knownConstants, knownModels)
	if err != nil {
		return nil, fmt.Errorf("mapping the object definition: %+v", err)
	}

	option := repositoryModels.Option{
		HeaderName:       input.HeaderName,
		QueryString:      input.QueryStringName,
		Field:            fieldName,
		ObjectDefinition: *objectDefinition,
	}

	if !input.Required {
		option.Optional = true
	} else {
		option.Required = true
	}

	return &option, nil
}
