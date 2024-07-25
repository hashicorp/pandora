// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/normalize"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

func translateModelsToDataApiSdkTypes(models parser.Models, constants parser.Constants) (*sdkModels.CommonTypes, error) {
	sdkConstantsMap := make(map[string]sdkModels.SDKConstant)
	sdkModelsMap := make(map[string]sdkModels.SDKModel)

	for modelName, model := range models {
		sdkModel, err := model.DataApiSdkModel(models)
		if err != nil {
			return nil, err
		}
		sdkModelsMap[modelName] = *sdkModel

	}

	for constantName, constant := range constants {
		constantValues := make(map[string]string)
		for _, value := range constant.Enum {
			constantValues[normalize.CleanName(value)] = value
		}

		// TODO support additional types, if there are any
		sdkConstantsMap[constantName] = sdkModels.SDKConstant{
			Type:   sdkModels.StringSDKConstantType,
			Values: constantValues,
		}
	}

	return &sdkModels.CommonTypes{
		Constants: sdkConstantsMap,
		Models:    sdkModelsMap,
	}, nil
}
