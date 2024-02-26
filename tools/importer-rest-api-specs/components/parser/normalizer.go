// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// normalizeAzureApiResource works through the parsed AzureApiResource and ensures
// that all the Names and References are consistent (TitleCase) as a final effort
// to ensure the Swagger Data is normalized.
func normalizeAzureApiResource(input importerModels.AzureApiResource) importerModels.AzureApiResource {
	normalizedConstants := make(map[string]models.SDKConstant)
	for k, v := range input.Constants {
		name := cleanup.NormalizeName(k)
		normalizedConstants[name] = v
	}

	normalizedModels := make(map[string]importerModels.ModelDetails)
	for k, v := range input.Models {
		modelName := cleanup.NormalizeName(k)
		fields := make(map[string]importerModels.FieldDetails)
		for fieldName, fieldVal := range v.Fields {
			normalizedFieldName := cleanup.NormalizeName(fieldName)
			fieldVal.ObjectDefinition = normalizeSDKObjectDefinition(fieldVal.ObjectDefinition)
			fields[normalizedFieldName] = fieldVal
		}
		v.Fields = fields

		if v.ParentTypeName != nil {
			val := cleanup.NormalizeName(*v.ParentTypeName)
			v.ParentTypeName = &val
		}

		// Discriminators can be `@type` which get normalized to `Type` so we need to normalize the field name here
		if v.TypeHintIn != nil {
			val := cleanup.NormalizeName(*v.TypeHintIn)
			v.TypeHintIn = &val
		}

		normalizedModels[modelName] = v
	}

	normalizedOperations := make(map[string]importerModels.OperationDetails)
	for k, v := range input.Operations {
		if v.ResourceIdName != nil {
			normalized := cleanup.NormalizeName(*v.ResourceIdName)
			v.ResourceIdName = &normalized
		}

		if v.RequestObject != nil {
			request := normalizeSDKObjectDefinition(*v.RequestObject)
			v.RequestObject = pointer.To(request)
		}

		if v.ResponseObject != nil {
			response := normalizeSDKObjectDefinition(*v.ResponseObject)
			v.ResponseObject = pointer.To(response)
		}

		normalizedOptions := make(map[string]models.SDKOperationOption, 0)
		for optionKey, optionVal := range v.Options {
			optionKey = cleanup.NormalizeName(optionKey)

			optionVal.ObjectDefinition = normalizeOptionsObjectDefinition(optionVal.ObjectDefinition)

			normalizedOptions[optionKey] = optionVal
		}
		v.Options = normalizedOptions

		normalizedOperations[k] = v
	}

	normalizedResourceIds := make(map[string]models.ResourceID)
	for k, v := range input.ResourceIds {
		segments := make([]models.ResourceIDSegment, 0)

		normalizedConstantNames := make([]string, 0)
		for _, cn := range v.ConstantNames {
			name := cleanup.NormalizeName(cn)
			normalizedConstantNames = append(normalizedConstantNames, name)
		}
		v.ConstantNames = normalizedConstantNames

		for _, segment := range v.Segments {
			if segment.ConstantReference != nil {
				normalized := cleanup.NormalizeName(*segment.ConstantReference)
				segment.ConstantReference = &normalized
			}
			segments = append(segments, segment)
		}

		v.Segments = segments
		normalizedResourceIds[k] = v
	}

	return importerModels.AzureApiResource{
		Constants:   normalizedConstants,
		Models:      normalizedModels,
		Operations:  normalizedOperations,
		ResourceIds: normalizedResourceIds,

		// TF Processing is handled elsewhere, so this should be nil in `input`
		// but let's be explicit here since it's another packages responsibility.
		Terraform: nil,
	}
}

func normalizeSDKObjectDefinition(input models.SDKObjectDefinition) models.SDKObjectDefinition {
	if input.ReferenceName != nil {
		normalized := cleanup.NormalizeName(*input.ReferenceName)
		input.ReferenceName = &normalized
	}

	if input.NestedItem != nil {
		nested := normalizeSDKObjectDefinition(*input.NestedItem)
		input.NestedItem = pointer.To(nested)
	}

	return input
}

func normalizeOptionsObjectDefinition(input models.SDKOperationOptionObjectDefinition) models.SDKOperationOptionObjectDefinition {
	if input.ReferenceName != nil {
		normalized := cleanup.NormalizeName(*input.ReferenceName)
		input.ReferenceName = &normalized
	}

	if input.NestedItem != nil {
		nestedItem := normalizeOptionsObjectDefinition(*input.NestedItem)
		input.NestedItem = pointer.To(nestedItem)
	}

	return input
}
