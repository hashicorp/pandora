// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package operation

import (
	"fmt"
	"strings"

	"github.com/getkin/kin-openapi/openapi2"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/constants"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
)

func optionsForOperation(input parsedOperation) (map[string]sdkModels.SDKOperationOption, *parserModels.ParseResult, error) {
	output := make(map[string]sdkModels.SDKOperationOption)
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
	}

	for _, param := range input.operation.Parameters {
		// these are (currently) handled elsewhere, so we're good for now
		if strings.EqualFold(param.Name, "$skipToken") {
			// NOTE: we may also need to do the odata ones, media has an example
			continue
		}

		// handled elsewhere
		if strings.EqualFold(param.Name, "api-version") {
			continue
		}

		if strings.EqualFold(param.In, "header") || strings.EqualFold(param.In, "query") {
			val := param.Name
			name := cleanup.NormalizeName(val)

			option := sdkModels.SDKOperationOption{
				Required: param.Required,
			}

			if strings.EqualFold(param.In, "header") {
				option.HeaderName = &val
			}
			if strings.EqualFold(param.In, "query") {
				option.QueryStringName = &val
			}

			// looks like these can be dates etc too
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "name": "reportedEndTime",
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "in": "query",
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "required": true,
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "type": "string",
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json:            "format": "date-time",
			// ./commerce/resource-manager/Microsoft.Commerce/preview/2015-06-01-preview/commerce.json-            "description": "The end of the time range to retrieve data for."
			objectDefinition, err := determineObjectDefinitionForOption(*param)
			if err != nil {
				return nil, nil, fmt.Errorf("determining field type for operation: %+v", err)
			}
			option.ObjectDefinition = *objectDefinition

			if param.Enum != nil {
				types := *param.Type
				constant, err := constants.Parse(types, param.Name, nil, param.Enum, param.Extensions)
				if err != nil {
					return nil, nil, fmt.Errorf("mapping %q: %+v", param.Name, err)
				}
				result.Constants[constant.Name] = constant.Details

				option.ObjectDefinition = sdkModels.SDKOperationOptionObjectDefinition{
					Type:          sdkModels.ReferenceSDKOperationOptionObjectDefinitionType,
					ReferenceName: &constant.Name,
				}
			}

			output[name] = option
		}
	}

	return output, &result, nil
}

func determineObjectDefinitionForOption(input openapi2.Parameter) (*sdkModels.SDKOperationOptionObjectDefinition, error) {
	if input.Type.Is("array") {
		// https://github.com/Azure/azure-rest-api-specs/blob/1b0ed8edd58bb7c9ade9a27430759527bd4eec8e/specification/trafficmanager/resource-manager/Microsoft.Network/stable/2018-03-01/trafficmanager.json#L735-L738
		if input.Items == nil {
			return nil, fmt.Errorf("an array/csv option type was specified with no items")
		}

		innerType, err := determineObjectDefinitionForOptionRaw(input.Items.Value.Type.Slice()[0], input.Items.CollectionName(), input.Items.Value.Format)
		if err != nil {
			return nil, fmt.Errorf("determining nested object definition for option: %+v", err)
		}

		if strings.EqualFold(input.CollectionFormat, "csv") {
			return &sdkModels.SDKOperationOptionObjectDefinition{
				Type:       sdkModels.CSVSDKOperationOptionObjectDefinitionType,
				NestedItem: innerType,
			}, nil
		}

		return &sdkModels.SDKOperationOptionObjectDefinition{
			Type:       sdkModels.ListSDKOperationOptionObjectDefinitionType,
			NestedItem: innerType,
		}, nil
	}

	return determineObjectDefinitionForOptionRaw(input.Type.Slice()[0], input.CollectionFormat, input.Format)
}

func determineObjectDefinitionForOptionRaw(paramType string, collectionFormat string, format string) (*sdkModels.SDKOperationOptionObjectDefinition, error) {
	switch strings.ToLower(paramType) {
	case "array":
		{
			if strings.EqualFold(collectionFormat, "csv") {
				return nil, fmt.Errorf("cannot contain a csv")
			}

			return nil, fmt.Errorf("cannot contain an array")
		}

	case "boolean":
		return &sdkModels.SDKOperationOptionObjectDefinition{
			Type: sdkModels.BooleanSDKOperationOptionObjectDefinitionType,
		}, nil

	case "integer":
		return &sdkModels.SDKOperationOptionObjectDefinition{
			Type: sdkModels.IntegerSDKOperationOptionObjectDefinitionType,
		}, nil

	case "number":
		{
			if strings.EqualFold(format, "double") {
				return &sdkModels.SDKOperationOptionObjectDefinition{
					Type: sdkModels.FloatSDKOperationOptionObjectDefinitionType,
				}, nil
			}

			if strings.EqualFold(format, "decimal") {
				return &sdkModels.SDKOperationOptionObjectDefinition{
					Type: sdkModels.FloatSDKOperationOptionObjectDefinitionType,
				}, nil
			}

			if format != "" {
				// we don't know what this is, better to raise an error and handle it than make
				// it an integer if it should be a float or something
				return nil, fmt.Errorf("unsupported format type for number %q", format)
			}

			return &sdkModels.SDKOperationOptionObjectDefinition{
				Type: sdkModels.IntegerSDKOperationOptionObjectDefinitionType,
			}, nil
		}

	case "string":
		return &sdkModels.SDKOperationOptionObjectDefinition{
			Type: sdkModels.StringSDKOperationOptionObjectDefinitionType,
		}, nil
	}
	return nil, fmt.Errorf("unsupported field type %q", paramType)
}
