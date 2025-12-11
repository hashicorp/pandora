// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package cleanup

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// NormalizeAPIResource works through the parsed AzureApiResource and ensures
// that all the Names and References are consistent (TitleCase) as a final effort
// to ensure the Swagger Data is normalized.
func NormalizeAPIResource(input sdkModels.APIResource) sdkModels.APIResource {
	normalizedConstants := make(map[string]sdkModels.SDKConstant)
	for k, v := range input.Constants {
		name := NormalizeName(k)
		normalizedConstants[name] = v
	}

	normalizedModels := make(map[string]sdkModels.SDKModel)
	for k, v := range input.Models {
		modelName := NormalizeName(k)
		fields := make(map[string]sdkModels.SDKField)
		for fieldName, fieldVal := range v.Fields {
			normalizedFieldName := NormalizeName(fieldName)
			fieldVal.ObjectDefinition = normalizeSDKObjectDefinition(fieldVal.ObjectDefinition)
			fields[normalizedFieldName] = fieldVal
		}
		v.Fields = fields

		if v.ParentTypeName != nil {
			val := NormalizeName(*v.ParentTypeName)
			v.ParentTypeName = &val
		}

		// Discriminators can be `@type` which get normalized to `Type` so we need to normalize the field name here
		if v.FieldNameContainingDiscriminatedValue != nil {
			val := NormalizeName(*v.FieldNameContainingDiscriminatedValue)
			v.FieldNameContainingDiscriminatedValue = &val
		}

		normalizedModels[modelName] = v
	}

	normalizedOperations := make(map[string]sdkModels.SDKOperation)
	for k, v := range input.Operations {
		if v.ResourceIDName != nil {
			normalized := NormalizeName(*v.ResourceIDName)
			v.ResourceIDName = &normalized
		}

		if v.RequestObject != nil {
			request := normalizeSDKObjectDefinition(*v.RequestObject)
			v.RequestObject = pointer.To(request)
		}

		if v.ResponseObject != nil {
			response := normalizeSDKObjectDefinition(*v.ResponseObject)
			v.ResponseObject = pointer.To(response)
		}

		normalizedOptions := make(map[string]sdkModels.SDKOperationOption, 0)
		for optionKey, optionVal := range v.Options {
			optionKey = NormalizeName(optionKey)

			optionVal.ObjectDefinition = normalizeSDKOptionsObjectDefinition(optionVal.ObjectDefinition)

			normalizedOptions[optionKey] = optionVal
		}
		v.Options = normalizedOptions

		normalizedOperations[k] = v
	}

	normalizedResourceIds := make(map[string]sdkModels.ResourceID)
	for k, v := range input.ResourceIDs {
		segments := make([]sdkModels.ResourceIDSegment, 0)

		normalizedConstantNames := make([]string, 0)
		for _, cn := range v.ConstantNames {
			name := NormalizeName(cn)
			normalizedConstantNames = append(normalizedConstantNames, name)
		}
		v.ConstantNames = normalizedConstantNames

		for _, segment := range v.Segments {
			if segment.ConstantReference != nil {
				normalized := NormalizeName(*segment.ConstantReference)
				segment.ConstantReference = &normalized
			}
			segments = append(segments, segment)
		}

		v.Segments = segments
		normalizedResourceIds[k] = v
	}

	return sdkModels.APIResource{
		Constants:   normalizedConstants,
		Models:      normalizedModels,
		Operations:  normalizedOperations,
		ResourceIDs: normalizedResourceIds,
	}
}

func normalizeSDKObjectDefinition(input sdkModels.SDKObjectDefinition) sdkModels.SDKObjectDefinition {
	if input.ReferenceName != nil {
		normalized := NormalizeName(*input.ReferenceName)
		input.ReferenceName = pointer.To(Title(normalized))
	}

	if input.NestedItem != nil {
		nested := normalizeSDKObjectDefinition(*input.NestedItem)
		input.NestedItem = pointer.To(nested)
	}

	return input
}

func normalizeSDKOptionsObjectDefinition(input sdkModels.SDKOperationOptionObjectDefinition) sdkModels.SDKOperationOptionObjectDefinition {
	if input.ReferenceName != nil {
		normalized := NormalizeName(*input.ReferenceName)
		input.ReferenceName = &normalized
	}

	if input.NestedItem != nil {
		nestedItem := normalizeSDKOptionsObjectDefinition(*input.NestedItem)
		input.NestedItem = pointer.To(nestedItem)
	}

	return input
}
