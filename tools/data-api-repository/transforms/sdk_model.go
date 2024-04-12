// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"sort"
	"strings"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func MapSDKModelToRepository(modelName string, model sdkModels.SDKModel, parentModel *sdkModels.SDKModel, knownConstants map[string]sdkModels.SDKConstant, knownModels map[string]sdkModels.SDKModel) (*repositoryModels.Model, error) {
	if len(model.Fields) == 0 {
		return nil, fmt.Errorf("the model %q has no fields", modelName)
	}

	fields, err := mapSDKFieldsForModel(model, parentModel, knownConstants, knownModels)
	if err != nil {
		return nil, fmt.Errorf("mapping fields for model %q: %+v", modelName, err)
	}

	dataApiModel := repositoryModels.Model{
		Name:   modelName,
		Fields: *fields,
	}

	// NOTE: `Parent` types don't get a `DiscriminatedValue`
	if model.ParentTypeName != nil {
		dataApiModel.DiscriminatedParentModelName = model.ParentTypeName
	}
	if model.DiscriminatedValue != nil {
		dataApiModel.DiscriminatedTypeValue = model.DiscriminatedValue
	}

	if model.FieldNameContainingDiscriminatedValue != nil {
		dataApiModel.TypeHintIn = model.FieldNameContainingDiscriminatedValue
	}

	return &dataApiModel, nil
}

func mapSDKFieldsForModel(model sdkModels.SDKModel, parentModel *sdkModels.SDKModel, knownConstants map[string]sdkModels.SDKConstant, knownModels map[string]sdkModels.SDKModel) (*[]repositoryModels.ModelField, error) {
	// ensure consistency in the output
	sortedFieldNames := make([]string, 0)
	for fieldName := range model.Fields {
		sortedFieldNames = append(sortedFieldNames, fieldName)
	}
	sort.Strings(sortedFieldNames)

	fields := make([]repositoryModels.ModelField, 0)

	for _, fieldName := range sortedFieldNames {
		// we should skip outputting this field if it's present on the parent
		fieldInParent := false
		if parentModel != nil {
			// the importer flattens fields from parents/AllOf, since we don't use inheritance for that within the
			// data layer - as such we only want to skip the fields when the parent type is output, e.g. when there's
			// a discriminator involved
			for name := range parentModel.Fields {
				if strings.EqualFold(name, fieldName) {
					fieldInParent = true
					break
				}
			}
		}
		if fieldInParent {
			continue
		}

		field := model.Fields[fieldName]
		isTypeHint := model.FieldNameContainingDiscriminatedValue != nil && strings.EqualFold(*model.FieldNameContainingDiscriminatedValue, fieldName)
		fieldCode, err := mapSDKFieldToRepository(fieldName, field, isTypeHint, knownConstants, knownModels)
		if err != nil {
			return nil, fmt.Errorf("generating code for field %q: %+v", fieldName, err)
		}

		fields = append(fields, *fieldCode)
	}

	return &fields, nil
}
