// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

type KnownData struct {
	Constants   map[string]sdkModels.SDKConstant
	Models      map[string]sdkModels.SDKModel
	ResourceIds map[string]sdkModels.ResourceID

	CommonTypeConstants    map[string]sdkModels.SDKConstant
	CommonTypeModels       map[string]sdkModels.SDKModel
	CommonTypesResourceIds map[string]sdkModels.ResourceID
}

func (d KnownData) ConstantExists(constantName string) bool {
	_, isConstant := d.Constants[constantName]
	_, isCommonTypesConstant := d.CommonTypeConstants[constantName]
	return isConstant || isCommonTypesConstant
}

func (d KnownData) ModelByName(modelName string) *sdkModels.SDKModel {
	if localModel, isModel := d.Models[modelName]; isModel {
		return &localModel
	}
	if commonModel, isCommonModel := d.CommonTypeModels[modelName]; isCommonModel {
		return &commonModel
	}
	return nil
}

func (d KnownData) ModelExists(modelName string) bool {
	_, isModel := d.Models[modelName]
	_, isCommonTypesModel := d.CommonTypeModels[modelName]
	return isModel || isCommonTypesModel
}

func (d KnownData) ResourceIDExists(resourceIdName string) bool {
	_, resourceIdExists := d.ResourceIds[resourceIdName]
	_, commonTypesResourceIdExists := d.CommonTypesResourceIds[resourceIdName]
	return resourceIdExists || commonTypesResourceIdExists
}
