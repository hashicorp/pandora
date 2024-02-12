// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func mapSDKOperationOptions(input map[string]repositories.OperationOptions) (*map[string]models.SDKOperationOption, error) {
	output := make(map[string]models.SDKOperationOption)
	for key, value := range input {
		mappedOption, err := mapSDKOperationOption(value)
		if err != nil {
			return nil, fmt.Errorf("mapping Option %q: %+v", key, err)
		}
		output[key] = *mappedOption
	}

	return &output, nil
}

func mapSDKOperationOption(input repositories.OperationOptions) (*models.SDKOperationOption, error) {
	objectDefinition, err := mapSDKOperationOptionObjectDefinition(*input.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("mapping SDKOperationOptionObjectDefinition: %+v", err)
	}

	return &models.SDKOperationOption{
		HeaderName:       input.HeaderName,
		QueryStringName:  input.QueryStringName,
		ObjectDefinition: *objectDefinition,
		Required:         input.Required,
	}, nil
}
