// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package cleanup

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"
)

// NormalizeAPIResource works through the parsed AzureApiResource and ensures
// that all the Names and References are consistent (TitleCase) as a final effort
// to ensure the Swagger Data is normalized.
func NormalizeAPIResource(input sdkModels.APIResource) sdkModels.APIResource {
	normalizedConstants := make(map[string]sdkModels.SDKConstant)
	for k, v := range input.Constants {
		name := cleanup.NormalizeName(k)
		normalizedConstants[name] = v
	}

	normalizedModels := make(map[string]sdkModels.SDKModel)
	for k, v := range input.Models {
		modelName := cleanup.NormalizeName(k)
		fields := make(map[string]sdkModels.SDKField)
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
		if v.FieldNameContainingDiscriminatedValue != nil {
			val := cleanup.NormalizeName(*v.FieldNameContainingDiscriminatedValue)
			v.FieldNameContainingDiscriminatedValue = &val
		}

		normalizedModels[modelName] = v
	}

	normalizedOperations := make(map[string]sdkModels.SDKOperation)
	for k, v := range input.Operations {
		if v.ResourceIDName != nil {
			normalized := cleanup.NormalizeName(*v.ResourceIDName)
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
			optionKey = cleanup.NormalizeName(optionKey)

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

	return sdkModels.APIResource{
		Constants:   normalizedConstants,
		Models:      normalizedModels,
		Operations:  normalizedOperations,
		ResourceIDs: normalizedResourceIds,
	}
}

func normalizeSDKObjectDefinition(input sdkModels.SDKObjectDefinition) sdkModels.SDKObjectDefinition {
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

func normalizeSDKOptionsObjectDefinition(input sdkModels.SDKOperationOptionObjectDefinition) sdkModels.SDKOperationOptionObjectDefinition {
	if input.ReferenceName != nil {
		normalized := cleanup.NormalizeName(*input.ReferenceName)
		input.ReferenceName = &normalized
	}

	if input.NestedItem != nil {
		nestedItem := normalizeSDKOptionsObjectDefinition(*input.NestedItem)
		input.NestedItem = pointer.To(nestedItem)
	}

	return input
}

func NormalizeOperationName(operationId string, tag *string) string {
	operationName := operationId
	// in some cases the OperationId *is* the Tag, in this instance I guess we take that as ok?
	if tag != nil && !strings.EqualFold(operationName, *tag) {
		// we're intentionally not using `strings.TrimPrefix` here since we want
		// to account for the casing of the tag being different
		if strings.HasPrefix(strings.ToLower(operationName), strings.ToLower(*tag)) {
			operationName = operationName[len(*tag):]

			// however if the Tag is `ManagementGroupsSubscriptions`, then we need to keep the extra `S` around
			if *tag == "ManagementGroups" && !strings.HasPrefix(operationName, "_") {
				operationName = fmt.Sprintf("S%s", operationName)
			}
		}
	}
	operationName = strings.ReplaceAll(operationName, "_", "")
	operationName = strings.TrimPrefix(operationName, "Operations") // sanity checking
	if !strings.HasPrefix(strings.ToLower(operationName), "subscriptions") {
		operationName = strings.TrimPrefix(operationName, "s") // plurals
	}
	operationName = strings.TrimPrefix(operationName, "_")
	operationName = cleanup.NormalizeName(operationName)
	return operationName
}

func NormalizeTag(input string) string {
	// NOTE: we could be smarter here, but given this is a handful of cases it's
	// probably prudent to hard-code these for now (and fix the swaggers as we
	// come across them?)
	output := input
	output = strings.ReplaceAll(output, "EndPoint", "Endpoint")
	output = strings.ReplaceAll(output, "NetWork", "Network")
	output = strings.ReplaceAll(output, "Baremetalinfrastructure", "BareMetalInfrastructure")
	output = strings.ReplaceAll(output, "VirtualWans", "VirtualWANs")

	return output
}
