// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/normalize"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

func (p pipeline) translateCommonTypesToDataApiSdkTypes() (*sdkModels.CommonTypes, error) {
	sdkConstantsMap := make(map[string]sdkModels.SDKConstant)
	sdkModelsMap := make(map[string]sdkModels.SDKModel)
	sdkResourceIdsMap := make(map[string]sdkModels.ResourceID)

	for modelName, model := range p.models {
		if model.Common {
			sdkModel, err := model.DataApiSdkModel(p.models)
			if err != nil {
				return nil, err
			}
			if sdkModel == nil {
				logging.Warnf("skipping invalid model %q as it has no fields", modelName)
				continue
			}
			sdkModelsMap[modelName] = *sdkModel
		}
	}

	for constantName, constant := range p.constants {
		constantValues := make(map[string]string)
		for _, value := range constant.Enum {
			// prefix constant value names with underscore to prevent naming conflicts with similarly named models in the generated SDK
			constantValues[fmt.Sprintf("_%s", normalize.CleanName(value))] = value
		}

		sdkConstantsMap[constantName] = sdkModels.SDKConstant{
			// TODO support additional types, if there are any
			Type:   sdkModels.StringSDKConstantType,
			Values: constantValues,
		}
	}

	for _, resourceId := range p.resourceIds {
		sdkResourceId, err := resourceId.DataApiSdkResourceId()
		if err != nil {
			return nil, err
		}

		sdkResourceIdsMap[resourceId.Name] = *sdkResourceId
	}

	return &sdkModels.CommonTypes{
		Constants:   sdkConstantsMap,
		Models:      sdkModelsMap,
		ResourceIDs: sdkResourceIdsMap,
	}, nil
}
