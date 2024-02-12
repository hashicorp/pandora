// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

var constantTypes = map[repositories.ConstantType]models.SDKConstantType{
	repositories.FloatConstant:   models.FloatSDKConstantType,
	repositories.IntegerConstant: models.IntegerSDKConstantType,
	repositories.StringConstant:  models.StringSDKConstantType,
}

// MapConstants maps the ConstantDetails type from the repositories package into the V1 API Response Model.
func MapConstants(input map[string]repositories.ConstantDetails) (*map[string]models.SDKConstant, error) {
	output := make(map[string]models.SDKConstant)
	for key, val := range input {
		mapped, err := mapConstant(val)
		if err != nil {
			return nil, fmt.Errorf("mapping Constant %q: %+v", key, err)
		}
		output[key] = *mapped
	}
	return &output, nil
}

func mapConstant(input repositories.ConstantDetails) (*models.SDKConstant, error) {
	constantType, ok := constantTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Constant Type %q", string(input.Type))
	}

	return &models.SDKConstant{
		Type:   constantType,
		Values: input.Values,
	}, nil
}
