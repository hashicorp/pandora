// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

func ReplaceSDKObjectDefinitionsAsNeeded(input sdkModels.APIResource) sdkModels.APIResource {
	output := input
	for modelName, model := range input.Models {
		fields := model.Fields
		for fieldName := range model.Fields {
			field := model.Fields[fieldName]

			// switch out the SDK Object Definition for this field if needed
			for _, matcher := range Matchers {
				if matcher.IsMatch(field, input) {
					field.ObjectDefinition = matcher.ReplacementObjectDefinition()
					break
				}
			}

			fields[fieldName] = field
		}
		model.Fields = fields
		output.Models[modelName] = model
	}

	return output
}
