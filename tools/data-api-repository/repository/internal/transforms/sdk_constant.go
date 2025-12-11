// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func MapSDKConstantFromRepository(input repositoryModels.Constant) (*sdkModels.SDKConstant, error) {
	constantType, err := mapSDKConstantTypeFromRepository(input.Type)
	if err != nil {
		return nil, err
	}

	values := make(map[string]string)
	for _, item := range input.Values {
		values[item.Key] = item.Value
	}
	return &sdkModels.SDKConstant{
		Type:   *constantType,
		Values: values,
	}, nil
}

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

	constantType, err := mapSDKConstantTypeToRepository(details.Type)
	if err != nil {
		return nil, fmt.Errorf("mapping constant field type %q: %+v", string(details.Type), err)
	}

	return &repositoryModels.Constant{
		Name:   constantName,
		Type:   pointer.From(constantType),
		Values: values,
	}, nil
}

func mapSDKConstantTypeFromRepository(input repositoryModels.ConstantType) (*sdkModels.SDKConstantType, error) {
	mappings := map[repositoryModels.ConstantType]sdkModels.SDKConstantType{
		repositoryModels.FloatConstant:   sdkModels.FloatSDKConstantType,
		repositoryModels.IntegerConstant: sdkModels.IntegerSDKConstantType,
		repositoryModels.StringConstant:  sdkModels.StringSDKConstantType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Constant Type %q", string(input))
}

func mapSDKConstantTypeToRepository(input sdkModels.SDKConstantType) (*repositoryModels.ConstantType, error) {
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
