// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	repositoryModels "github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapSDKConstantToRepository(constantName string, details sdkModels.SDKConstant) (*repositoryModels.Constant, error) {
	keys := make([]string, 0)
	keysToValues := make(map[string]repositoryModels.ConstantValue)
	for k, v := range details.Values {
		keys = append(keys, k)
		keysToValues[k] = repositoryModels.ConstantValue{
			Key:   k,
			Value: v,
			// TODO: expose Description in the future when this is surfaced from the Parser
		}
	}
	sort.Strings(keys)

	values := make([]repositoryModels.ConstantValue, 0)
	for _, key := range keys {
		value := keysToValues[key]
		values = append(values, value)
	}

	constantType, err := mapConstantTypeToRepository(details.Type)
	if err != nil {
		return nil, fmt.Errorf("mapping constant field type %q: %+v", string(details.Type), err)
	}

	return &repositoryModels.Constant{
		Name:   constantName,
		Type:   pointer.From(constantType),
		Values: values,
	}, nil
}

func mapConstantTypeToRepository(input sdkModels.SDKConstantType) (*repositoryModels.ConstantType, error) {
	mappings := map[sdkModels.SDKConstantType]repositoryModels.ConstantType{
		sdkModels.FloatSDKConstantType:   repositoryModels.FloatConstant,
		sdkModels.IntegerSDKConstantType: repositoryModels.IntegerConstant,
		sdkModels.StringSDKConstantType:  repositoryModels.StringConstant,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Constant Type %q", string(input))
}
