// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

// MapSDKModels maps the ModelDetails type from the repositories package into the V1 API Response Model.
func MapSDKModels(input map[string]repositories.ModelDetails) (*map[string]models.SDKModel, error) {
	output := make(map[string]models.SDKModel)
	for key, val := range input {
		mapped, err := mapSDKModel(val)
		if err != nil {
			return nil, fmt.Errorf("mapping SDKModel %q: %+v", key, err)
		}
		output[key] = *mapped
	}
	return &output, nil
}

func mapSDKModel(input repositories.ModelDetails) (*models.SDKModel, error) {
	mappedFields, err := MapSDKFields(input.Fields)
	if err != nil {
		return nil, fmt.Errorf("mapping fields: %+v", err)
	}

	return &models.SDKModel{
		Fields:                                *mappedFields,
		ParentTypeName:                        input.ParentTypeName,
		FieldNameContainingDiscriminatedValue: input.TypeHintIn,
		DiscriminatedValue:                    input.TypeHintValue,
	}, nil
}
